using NAudio.Wave;
using SkiaSharp;
using System;

namespace NAudio.WaveFormRenderer
{
    public class WaveFormRenderer
    {
        public SKBitmap Render(WaveStream waveStream, WaveFormRendererSettings settings)
        {
            return Render(waveStream, new MaxPeakProvider(), settings);
        }

        public SKBitmap Render(WaveStream waveStream, IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            int bytesPerSample = (waveStream.WaveFormat.BitsPerSample / 8);
            var samples = waveStream.Length / (bytesPerSample);
            var samplesPerPixel = (int)(samples / settings.Width);
            var stepSize = settings.PixelsPerPeak + settings.SpacerPixels;
            peakProvider.Init(waveStream.ToSampleProvider(), samplesPerPixel * stepSize);
            return Render(peakProvider, settings);
        }

        private static SKBitmap Render(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            if (settings.DecibelScale)
                peakProvider = new DecibelPeakProvider(peakProvider, 48);

            var b = new SKBitmap(settings.Width, settings.TopHeight + settings.BottomHeight);

            using (var canvas = new SKCanvas(b))
            {
                if (settings.BackgroundImage != null)
                {
                    canvas.DrawImage(SKImage.FromBitmap(settings.BackgroundImage), new SKPoint(0, 0));
                }
                else
                {
                    canvas.DrawRect(0, 0, b.Width, b.Height, new SKPaint { Color = settings.BackgroundColor, Style = SKPaintStyle.Fill });
                }
                var midPoint = settings.TopHeight;

                var topPeakPaint = new SKPaint { Shader = settings.TopPeakShader, StrokeWidth = 1, Style = SKPaintStyle.Stroke };
                var bottomPeakPaint = new SKPaint { Shader = settings.BottomPeakShader, StrokeWidth = 1, Style = SKPaintStyle.Stroke };
                // create SKPaint objects if spacers are needed
                SKPaint topSpacerPaint = null;
                SKPaint bottomSpacerPaint = null;
                if (settings.SpacerPixels > 0)
                {
                    topSpacerPaint = new SKPaint { Shader = settings.TopSpacerShader };
                    bottomSpacerPaint = new SKPaint { Shader = settings.BottomSpacerShader };
                }

                int x = 0;
                var currentPeak = peakProvider.GetNextPeak();
                while (x < settings.Width)
                {
                    var nextPeak = peakProvider.GetNextPeak();

                    for (int n = 0; n < settings.PixelsPerPeak; n++)
                    {
                        var lineHeight = settings.TopHeight * currentPeak.Max;
                        canvas.DrawLine(x, midPoint, x, midPoint - lineHeight, topPeakPaint);
                        lineHeight = settings.BottomHeight * currentPeak.Min;
                        canvas.DrawLine(x, midPoint, x, midPoint - lineHeight, bottomPeakPaint);
                        x++;
                    }

                    for (int n = 0; n < settings.SpacerPixels; n++)
                    {
                        // spacer bars are always the lower of the 
                        var max = Math.Min(currentPeak.Max, nextPeak.Max);
                        var min = Math.Max(currentPeak.Min, nextPeak.Min);

                        var lineHeight = settings.TopHeight * max;
                        canvas.DrawLine(x, midPoint, x, midPoint - lineHeight, topSpacerPaint);
                        lineHeight = settings.BottomHeight * min;
                        canvas.DrawLine(x, midPoint, x, midPoint - lineHeight, bottomSpacerPaint);
                        x++;
                    }
                    currentPeak = nextPeak;
                }
            }
            return b;
        }


    }
}
