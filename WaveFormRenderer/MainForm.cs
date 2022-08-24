using NAudio.Wave;
using NAudio.WaveFormRenderer;
using SkiaSharp;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveFormRendererApp
{
    public partial class MainForm : Form
    {
        private string selectedFile;
        private string imageFile;
        private readonly WaveFormRenderer waveFormRenderer;
        private readonly WaveFormRendererSettings standardSettings;

        public MainForm()
        {
            InitializeComponent();
            waveFormRenderer = new WaveFormRenderer();

            standardSettings = new StandardWaveFormRendererSettings() { Name = "Standard" };
            var soundcloudOriginalSettings = new SoundCloudOriginalSettings() { Name = "SoundCloud Original" };

            var soundCloudLightBlocks = new SoundCloudBlockWaveFormSettings(new SKColor(102, 102, 102), new SKColor(103, 103, 103), new SKColor(179, 179, 179),
                new SKColor(218, 218, 218))
            { Name = "SoundCloud Light Blocks" };

            var soundCloudDarkBlocks = new SoundCloudBlockWaveFormSettings(new SKColor(52, 52, 52), new SKColor(55, 55, 55), new SKColor(154, 154, 154),
                new SKColor(204, 204, 204))
            { Name = "SoundCloud Darker Blocks" };

            var soundCloudOrangeBlocks = new SoundCloudBlockWaveFormSettings(new SKColor(255, 76, 0), new SKColor(255, 52, 2), new SKColor(255, 171, 141),
                new SKColor(255, 213, 199))
            { Name = "SoundCloud Orange Blocks" };

            var topSpacerColor = new SKColor(83, 22, 3, 64);
            var soundCloudOrangeTransparentBlocks = new SoundCloudBlockWaveFormSettings(new SKColor(197, 53, 0, 196), topSpacerColor, new SKColor(79, 26, 0, 196),
                new SKColor(79, 79, 79, 64))
            {
                Name = "SoundCloud Orange Transparent Blocks",
                PixelsPerPeak = 2,
                SpacerPixels = 1,
                TopSpacerGradientStartColor = topSpacerColor,
                BackgroundColor = SKColors.Transparent
            };

            var topSpacerColor2 = new SKColor(224, 224, 224, 64);
            var soundCloudGrayTransparentBlocks = new SoundCloudBlockWaveFormSettings(new SKColor(224, 225, 224, 196), topSpacerColor2, new SKColor(128, 128, 128, 196),
                new SKColor(128, 128, 128, 64))
            {
                Name = "SoundCloud Gray Transparent Blocks",
                PixelsPerPeak = 2,
                SpacerPixels = 1,
                TopSpacerGradientStartColor = topSpacerColor2,
                BackgroundColor = SKColors.Transparent
            };


            buttonBottomColour.BackColor = Color.Peru;
            buttonTopColour.BackColor = Color.Maroon;
            comboBoxPeakCalculationStrategy.Items.Add("Max Absolute Value");
            comboBoxPeakCalculationStrategy.Items.Add("Max Rms Value");
            comboBoxPeakCalculationStrategy.Items.Add("Sampled Peaks");
            comboBoxPeakCalculationStrategy.Items.Add("Scaled Average");
            comboBoxPeakCalculationStrategy.SelectedIndex = 0;
            comboBoxPeakCalculationStrategy.SelectedIndexChanged += (sender, args) => RenderWaveform();

            comboBoxRenderSettings.DisplayMember = "Name";

            comboBoxRenderSettings.DataSource = new[]
            {
                standardSettings,
                soundcloudOriginalSettings,
                soundCloudLightBlocks,
                soundCloudDarkBlocks,
                soundCloudOrangeBlocks,
                soundCloudOrangeTransparentBlocks,
                soundCloudGrayTransparentBlocks
            };

            comboBoxRenderSettings.SelectedIndex = 5;
            comboBoxRenderSettings.SelectedIndexChanged += (sender, args) => RenderWaveform();

            labelRendering.Visible = false;
        }

        private IPeakProvider GetPeakProvider()
        {
            switch (comboBoxPeakCalculationStrategy.SelectedIndex)
            {
                case 0:
                    return new MaxPeakProvider();
                case 1:
                    return new RmsPeakProvider((int)upDownBlockSize.Value);
                case 2:
                    return new SamplingPeakProvider((int)upDownBlockSize.Value);
                case 3:
                    return new AveragePeakProvider(4);
                default:
                    throw new InvalidOperationException("Unknown calculation strategy");
            }
        }

        private WaveFormRendererSettings GetRendererSettings()
        {
            var settings = (WaveFormRendererSettings)comboBoxRenderSettings.SelectedItem;
            settings.TopHeight = (int)upDownTopHeight.Value;
            settings.BottomHeight = (int)upDownBottomHeight.Value;
            settings.Width = (int)upDownWidth.Value;
            settings.DecibelScale = checkBoxDecibels.Checked;
            return settings;
        }

        private void RenderWaveform()
        {
            if (selectedFile == null) return;
            var settings = GetRendererSettings();
            if (imageFile != null)
            {
                using (var stream = new System.IO.FileStream(imageFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    settings.BackgroundImage = SKBitmap.Decode(stream);
                }
            }
            pictureBox1.Image = null;
            labelRendering.Visible = true;
            Enabled = false;
            var peakProvider = GetPeakProvider();
            Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings));
        }

        private void RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            SKBitmap image = null;
            try
            {
                using (var waveStream = new AudioFileReader(selectedFile))
                {
                    image = waveFormRenderer.Render(waveStream, peakProvider, settings);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            BeginInvoke((Action)(() => FinishedRender(image)));
        }

        private void FinishedRender(SKBitmap image)
        {
            using (var memStream = new MemoryStream())
            using (var wstream = new SKManagedWStream(memStream))
            {
                image.Encode(wstream, SKEncodedImageFormat.Png, 100);
                pictureBox1.Image = Image.FromStream(memStream);
            }

            labelRendering.Visible = false;
            Enabled = true;
        }

        private void OnLoadSoundFileClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files|*.mp3|WAV files|*.wav";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                selectedFile = ofd.FileName;
                RenderWaveform();
            }
        }

        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "PNG files|*.png";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void OnRefreshImageClick(object sender, EventArgs e)
        {
            RenderWaveform();
        }

        private void OnColorButtonClick(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var cd = new ColorDialog();
            cd.Color = button.BackColor;
            if (cd.ShowDialog(this) == DialogResult.OK)
            {
                button.BackColor = cd.Color;

                var topColor = buttonTopColour.BackColor;
                var bottomColor = buttonBottomColour.BackColor;
                standardSettings.TopPeakShader = SKShader.CreateColor(new SKColor(topColor.R, topColor.G, topColor.B, topColor.A));
                standardSettings.BottomPeakShader = SKShader.CreateColor(new SKColor(bottomColor.R, bottomColor.G, bottomColor.B, bottomColor.A));
                RenderWaveform();
            }
        }

        private void OnDecibelsCheckedChanged(object sender, EventArgs e)
        {
            RenderWaveform();
        }

        private void OnButtonLoadImageClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.bmp;*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.imageFile = ofd.FileName;
                RenderWaveform();
            }
        }
    }
}
