namespace NAudio.WaveFormRenderer
{
    public readonly struct PeakInfo
    {
        public PeakInfo(float min, float max)
        {
            Max = max;
            Min = min;
        }

        public float Min { get; }

        public float Max { get; }
    }
}