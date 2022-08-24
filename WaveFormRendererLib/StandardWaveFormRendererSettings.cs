using SkiaSharp;

namespace NAudio.WaveFormRenderer
{
    public class StandardWaveFormRendererSettings : WaveFormRendererSettings
    {
        public StandardWaveFormRendererSettings()
        {
            PixelsPerPeak = 1;
            SpacerPixels = 0;
            TopPeakShader = SKShader.CreateColor(SKColors.Maroon);
            BottomPeakShader = SKShader.CreateColor(SKColors.Peru);
        }


        public override SKShader TopPeakShader { get; set; }

        // not needed
        public override SKShader TopSpacerShader { get; set; }

        public override SKShader BottomPeakShader { get; set; }

        // not needed
        public override SKShader BottomSpacerShader { get; set; }
    }
}