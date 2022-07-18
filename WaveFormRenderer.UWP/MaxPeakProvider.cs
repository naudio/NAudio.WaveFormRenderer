using System.Linq;

namespace NAudio.WaveFormRenderer
{
    public class MaxPeakProvider : PeakProvider
    {
        public override PeakInfo GetNextPeak()
        {
            var samplesRead = Provider.Read(ReadBuffer, 0, ReadBuffer.Length - (ReadBuffer.Length % 4));
            var max = (samplesRead == 0) ? 0 : ReadBuffer.Take(samplesRead).Max();
            var min = (samplesRead == 0) ? 0 : ReadBuffer.Take(samplesRead).Min();
            return new PeakInfo(min, max);
        }
    }
}