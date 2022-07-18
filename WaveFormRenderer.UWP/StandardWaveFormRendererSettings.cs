using System.Drawing;

namespace NAudio.WaveFormRenderer
{
    public class StandardWaveFormRendererSettings : WaveFormRendererSettings
    {
        public StandardWaveFormRendererSettings()
        {
            PixelsPerPeak = 1;
            SpacerPixels = 0;
        }
    }
}