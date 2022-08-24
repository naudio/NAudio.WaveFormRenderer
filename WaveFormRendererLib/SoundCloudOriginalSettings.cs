using SkiaSharp;
using System;

namespace NAudio.WaveFormRenderer
{
    public class SoundCloudOriginalSettings : WaveFormRendererSettings
    {
        private int lastTopHeight;
        private int lastBottomHeight;

        public SoundCloudOriginalSettings()
        {
            PixelsPerPeak = 1;
            SpacerPixels = 0;
            BackgroundColor = SKColors.White;
        }

        public override SKShader TopPeakShader
        {
            get
            {
                if (base.TopPeakShader == null || lastTopHeight != TopHeight)
                {
                    base.TopPeakShader = CreateGradientShader(TopHeight, new SKColor(120, 120, 120), new SKColor(50, 50, 50));
                    lastTopHeight = TopHeight;
                }
                return base.TopPeakShader;
            }
            set { base.TopPeakShader = value; }
        }


        public override SKShader BottomPeakShader
        {
            get
            {
                if (base.BottomPeakShader == null || lastBottomHeight != BottomHeight || lastTopHeight != TopHeight)
                {
                    base.BottomPeakShader = CreateSoundcloudBottomShader(TopHeight, BottomHeight);
                    lastBottomHeight = BottomHeight;
                    lastTopHeight = TopHeight;
                }
                return base.BottomPeakShader;
            }
            set { base.BottomPeakShader = value; }
        }


        public override SKShader BottomSpacerShader
        {
            get { throw new InvalidOperationException("No spacer shader required"); }
        }

        private SKShader CreateSoundcloudBottomShader(int topHeight, int bottomHeight)
        {
            return SKShader.CreateLinearGradient(new SKPoint(0, topHeight), new SKPoint(0, topHeight + bottomHeight),
                new SKColor[] { new SKColor(16, 16, 16), new SKColor(142, 142, 142), new SKColor(150, 150, 150) },
                new float[] { 0, 0.1f, 1 },
                SKShaderTileMode.Clamp);
        }
    }
}