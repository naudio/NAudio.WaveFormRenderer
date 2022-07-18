using NAudio.Wave;

namespace NAudio.WaveFormRenderer
{
    public interface IPeakProvider
    {
        void Init(ISampleProvider reader, int samplesPerPixel);
        PeakInfo GetNextPeak();
    }
}