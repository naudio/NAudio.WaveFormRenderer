using System;

namespace NAudio.WaveFormRenderer
{
    internal static class MathHelper
    {
        public static float SumOfAbsoluteValues(this Span<float> samples)
        {
            float result = 0;

            for (int i = 0; i < samples.Length; i++)
            {
                result += Math.Abs(samples[i]);
            }

            return result;
        }

        public static float Min(this Span<float> samples)
        {
            float result = samples[0];

            for (int i = 1; i < samples.Length; i++)
            {
                if (samples[i] < result)
                {
                    result = samples[i];
                }
            }

            return result;
        }

        public static float Max(this Span<float> samples)
        {
            float result = samples[0];

            for (int i = 1; i < samples.Length; i++)
            {
                if (samples[i] > result)
                {
                    result = samples[i];
                }
            }

            return result;
        }
    }
}