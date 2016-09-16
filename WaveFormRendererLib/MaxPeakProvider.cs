using System.Linq;

namespace WaveFormRendererLib
{
    public class MaxPeakProvider : PeakProvider
    {
        public override PeakInfo GetNextPeak()
        {
            var samplesRead = Provider.Read(ReadBuffer,0,ReadBuffer.Length);
            var max = (samplesRead == 0) ? 0 : ReadBuffer.Take(samplesRead).Max();
            var min = (samplesRead == 0) ? 0 : ReadBuffer.Take(samplesRead).Min();
            return new PeakInfo(min, max);
        }
    }
}