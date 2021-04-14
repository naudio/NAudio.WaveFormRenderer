using System;

namespace NAudio.WaveFormRenderer
{
    public sealed class AveragePeakProvider : PeakProvider
    {
        private readonly float scale;

        public AveragePeakProvider(float scale)
        {
            this.scale = scale;
        }

        public override PeakInfo GetNextPeak()
        {
            var samplesRead = Provider.Read(ReadBuffer, 0, ReadBuffer.Length);
            var sum = (samplesRead == 0) ? 0 : ReadBuffer.AsSpan(0, samplesRead).SumOfAbsoluteValues();
            var average = sum / samplesRead;
            
            return new PeakInfo(average * (0 - scale), average * scale);
        }
    }
}