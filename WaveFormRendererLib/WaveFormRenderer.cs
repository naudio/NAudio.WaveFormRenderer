using System;
using System.Drawing;
using NAudio.Wave;

namespace WaveFormRendererLib
{
    public class WaveFormRenderer
    {
        public Image Render(string selectedFile, WaveFormRendererSettings settings)
        {
            return Render(selectedFile, new MaxPeakProvider(), settings);
        }        

        public Image Render(string selectedFile, IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            using (var reader = new AudioFileReader(selectedFile))
            {
                int bytesPerSample = (reader.WaveFormat.BitsPerSample / 8);
                var samples = reader.Length / (bytesPerSample);
                var samplesPerPixel = (int)(samples / settings.Width);
                var stepSize = settings.PixelsPerPeak + settings.SpacerPixels;
                peakProvider.Init(reader, samplesPerPixel * stepSize);
                return Render(peakProvider, settings);
            }
        }

        private static Image Render(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            if (settings.DecibelScale)
                peakProvider = new DecibelPeakProvider(peakProvider, 48);

            var b = new Bitmap(settings.Width, settings.TopHeight + settings.BottomHeight);
            if (settings.BackgroundColor == Color.Transparent)
            {
                b.MakeTransparent();
            }
            using (var g = Graphics.FromImage(b))
            {
                g.FillRectangle(settings.BackgroundBrush, 0,0,b.Width,b.Height);
                var midPoint = settings.TopHeight;

                int x = 0;
                var currentPeak = peakProvider.GetNextPeak();
                while (x < settings.Width)
                {
                    var nextPeak = peakProvider.GetNextPeak();
                    
                    for (int n = 0; n < settings.PixelsPerPeak; n++)
                    {
                        var lineHeight = settings.TopHeight * currentPeak.Max;
                        g.DrawLine(settings.TopPeakPen, x, midPoint, x, midPoint - lineHeight);
                        lineHeight = settings.BottomHeight * currentPeak.Min;
                        g.DrawLine(settings.BottomPeakPen, x, midPoint, x, midPoint - lineHeight);
                        x++;
                    }

                    for (int n = 0; n < settings.SpacerPixels; n++)
                    {
                        // spacer bars are always the lower of the 
                        var max = Math.Min(currentPeak.Max, nextPeak.Max);
                        var min = Math.Max(currentPeak.Min, nextPeak.Min);

                        var lineHeight = settings.TopHeight * max;
                        g.DrawLine(settings.TopSpacerPen, x, midPoint, x, midPoint - lineHeight);
                        lineHeight = settings.BottomHeight * min;
                        g.DrawLine(settings.BottomSpacerPen, x, midPoint, x, midPoint - lineHeight); 
                        x++;
                    }
                    currentPeak = nextPeak;
                }
            }
            return b;
        }


    }
}
