using NAudio.Wave;
using System;

namespace NAudio.WaveFormRenderer
{
    public class WaveStreamToSampleProviderAdapter : ISampleProvider
    {
        private readonly WaveStream stream;

        public WaveStreamToSampleProviderAdapter(WaveStream stream) => this.stream = stream;

        public WaveFormat WaveFormat => stream.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            const int fSize = sizeof(float);
            //Reserve a byte buffer with space for all needed floats
            byte[] byteData = new byte[count * fSize];
            
            //Try to read the wanted amount
            var actuallyRead = stream.Read(byteData, 0, byteData.Length);

            //If we read less, change the wanted amount to the present amount of data
            count = actuallyRead / fSize;

            //convert everything
            for(int i = 0; i < count; i++)
                buffer[i + offset] = BitConverter.ToSingle(byteData, i * fSize);

            //return the actual read
            return count;
        }
    }
}
