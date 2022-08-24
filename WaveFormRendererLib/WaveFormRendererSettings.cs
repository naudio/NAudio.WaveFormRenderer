using SkiaSharp;

namespace NAudio.WaveFormRenderer
{
    public class WaveFormRendererSettings
    {
        protected WaveFormRendererSettings()
        {
            Width = 800;
            TopHeight = 50;
            BottomHeight = 50;
            PixelsPerPeak = 1;
            SpacerPixels = 0;
            BackgroundColor = SKColors.Beige;
        }

        // for display purposes only
        public string Name { get; set; }

        public int Width { get; set; }

        public int TopHeight { get; set; }
        public int BottomHeight { get; set; }
        public int PixelsPerPeak { get; set; }
        public int SpacerPixels { get; set; }
        public virtual SKShader TopPeakShader { get; set; }
        public virtual SKShader TopSpacerShader { get; set; }
        public virtual SKShader BottomPeakShader { get; set; }
        public virtual SKShader BottomSpacerShader { get; set; }
        public bool DecibelScale { get; set; }
        public SKColor BackgroundColor { get; set; }
        public SKBitmap BackgroundImage { get; set; }

        protected static SKShader CreateGradientShader(int height, SKColor startColor, SKColor endColor)
        {
            return SKShader.CreateLinearGradient(
                new SKPoint(0, 0),
                new SKPoint(0, height),
                new SKColor[] { startColor, endColor },
                new float[] { 0, 1 },
                SKShaderTileMode.Clamp);
        }
    }
}