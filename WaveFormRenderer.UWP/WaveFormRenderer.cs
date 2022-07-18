using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using NAudio.Wave;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NAudio.WaveFormRenderer
{
    public class WaveFormRenderer
    {
        public async Task<StackPanel> Render(WaveStream waveStream, IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            int bytesPerSample = (waveStream.WaveFormat.BitsPerSample / 8);
            var samples = waveStream.Length / (bytesPerSample);
            var samplesPerPixel = (int)(samples / settings.Width);
            var stepSize = settings.PixelsPerPeak + settings.SpacerPixels;
            peakProvider.Init(waveStream.ToSampleProvider(), samplesPerPixel * stepSize);
           // if (settings.DecibelScale)
                //peakProvider = new DecibelPeakProvider(peakProvider, 48);
            StackPanel b = null;
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                b = new StackPanel { Width = settings.Width, Height = settings.TopHeight + settings.BottomHeight, Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent) };
                var top = new StackPanel { Orientation = Orientation.Horizontal, Width = settings.Width, Height = settings.TopHeight };
                var bottom = new StackPanel { Orientation = Orientation.Horizontal, Width = settings.Width, Height = settings.BottomHeight };
                b.Children.Add(top);
                b.Children.Add(bottom);
            var midPoint = settings.TopHeight;

            int x = 0;
            var currentPeak = peakProvider.GetNextPeak();
            while (x < settings.Width)
            {
                var nextPeak = peakProvider.GetNextPeak();
                for (int n = 0; n < settings.PixelsPerPeak; n++)
                {
                    var lineHeight = settings.TopHeight * currentPeak.Max;
                    var rectangle = new Windows.UI.Xaml.Shapes.Rectangle
                    {
                        Height = (int)lineHeight,
                        Width = 1,
                        Fill = settings.BackgroundBrush,
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom
                    };
                    top.Children.Add(rectangle);
                    lineHeight = settings.BottomHeight * currentPeak.Min;
                    rectangle = new Windows.UI.Xaml.Shapes.Rectangle
                    {
                        Height = 0 - (int)lineHeight,
                        Width = 1,
                        Fill = settings.BackgroundBrush,
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top
                    };
                    bottom.Children.Add(rectangle);
                    x++;
                }

                for (int n = 0; n < settings.SpacerPixels; n++)
                {
                    // spacer bars are always the lower of the 
                    var max = Math.Min(currentPeak.Max, nextPeak.Max);
                    var min = Math.Max(currentPeak.Min, nextPeak.Min);

                    var lineHeight = settings.TopHeight * max;
                    var rectangle = new Windows.UI.Xaml.Shapes.Rectangle
                    {
                        Height = (int)lineHeight,
                        Width = 1,
                        Fill = new SolidColorBrush(Windows.UI.Colors.Transparent),
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom
                    };
                    top.Children.Add(rectangle);
                    lineHeight = settings.BottomHeight * min;
                    rectangle = new Windows.UI.Xaml.Shapes.Rectangle
                    {
                        Height = 0 - (int)lineHeight,
                        Width = 1,
                        Fill = new SolidColorBrush(Windows.UI.Colors.Transparent),
                        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top
                    };
                    bottom.Children.Add(rectangle);
                    x++;
                }
                Debug.WriteLine(x);

                //for (int n = 0; n < settings.SpacerPixels; n++)
                //{
                //    // spacer bars are always the lower of the 
                //    var max = Math.Min(currentPeak.Max, nextPeak.Max);
                //    var min = Math.Max(currentPeak.Min, nextPeak.Min);

                //    var lineHeight = settings.TopHeight * max;
                //    g.DrawLine(settings.TopSpacerPen, x, midPoint, x, midPoint - lineHeight);
                //    lineHeight = settings.BottomHeight * min;
                //    g.DrawLine(settings.BottomSpacerPen, x, midPoint, x, midPoint - lineHeight); 
                //    x++;
                //}
                currentPeak = nextPeak;
                }
            });
            return b;
        }


    }
}
