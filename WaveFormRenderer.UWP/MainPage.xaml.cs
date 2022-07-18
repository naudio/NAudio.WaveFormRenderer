using System;
using System.Numerics;
using Microsoft.Graphics.Canvas.Effects;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using EF = Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionFunctions;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Composition.Interactions;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.Storage.Pickers;
using Windows.Storage;
using NAudio.WaveFormRenderer;
using NAudio.Wave;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.FileProperties;
using Windows.UI;
using Windows.Media.MediaProperties;
using Windows.Media.Editing;
using System.Collections.Generic;
using System.IO;
using Microsoft.Toolkit.Uwp.UI;
using System.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TabbedConcept
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private double height;
        private WaveFormRendererSettings settings;
        private WaveFormRenderer waveFormRenderer;
        private double PageWidth;
        private double PageHeight;
        private StorageFile mediafile;
        private MusicProperties props;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (s, o) =>
            {
                PageWidth = this.ActualWidth;
                
            settings = GetRendererSettings();
            waveFormRenderer = new WaveFormRenderer();
            };
        }
        private async Task LoadMedia()
        {
            await LaunchFilePicker();
        }
        private async Task LaunchFilePicker()
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".wav");
            filePicker.FileTypeFilter.Add(".wma");
            filePicker.FileTypeFilter.Add(".m4a");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            mediafile = await filePicker.PickSingleFileAsync();

            // File can be null if cancel is hit in the file picker
            if (mediafile == null)
            {
                return;
            }
            RenderWaveform(mediafile);
        }
        private WaveFormRendererSettings GetRendererSettings()
        {
            settings = new WaveFormRendererSettings();
            settings.TopHeight = (int)200;
            settings.BottomHeight = (int)200;
            settings.Width = (int)1920;
            settings.PixelsPerPeak = 2;
            settings.SpacerPixels = 1;
            settings.DecibelScale = true;
            //settings.BackgroundBrush = new SolidColorBrush(Windows.UI.Colors.Blue);
            return settings;
        }
        private async void RenderThreadFunc(IPeakProvider peakProvider, StorageFile file, WaveFormRendererSettings settings)
        {
            try
            {
                using (var waveStream = new MediaFoundationReader(file.Path))
                {
                        var waveForm = await waveFormRenderer.Render(waveStream, peakProvider, settings);
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        Headrer.Children.Add((StackPanel)waveForm);
                    });
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }
        private IPeakProvider GetPeakProvider()
        {
            return new MaxPeakProvider();
        }
        private async void RenderWaveform(StorageFile mediafile)
        {
            if (mediafile == null) 
                return;
            var peakProvider = GetPeakProvider();
            mediafile = await mediafile.CopyAsync(ApplicationData.Current.LocalFolder, mediafile.Name, NameCollisionOption.GenerateUniqueName);
            props = await mediafile.Properties.GetMusicPropertiesAsync();
            settings.Width = (int)(props.Duration.TotalMilliseconds / 100);
            Blah.Width = settings.Width;
            await Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, mediafile, settings));
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoadMedia();
        }
    }
}
