using System;

namespace NAudio.WaveFormRenderer
{
    public sealed class MaxPeakProvider : PeakProvider
    {
        public override PeakInfo GetNextPeak()
        {
            var samplesRead = Provider.Read(ReadBuffer,0,ReadBuffer.Length);
            var max = (samplesRead == 0) ? 0 : ReadBuffer.AsSpan(0, samplesRead).Max();
            var min = (samplesRead == 0) ? 0 : ReadBuffer.AsSpan(0, samplesRead).Min();
            return new PeakInfo(min, max);
        }
    }
}