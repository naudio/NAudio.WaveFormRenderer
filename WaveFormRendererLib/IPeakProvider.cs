using NAudio.Wave;

namespace WaveFormRendererLib
{
    public interface IPeakProvider
    {
        void Init(ISampleProvider reader, int samplesPerPixel);
        PeakInfo GetNextPeak();
    }
}