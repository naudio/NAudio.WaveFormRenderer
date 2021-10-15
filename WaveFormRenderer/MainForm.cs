using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.WaveFormRenderer;

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

            standardSettings = new StandardWaveFormRendererSettings() {Name = "Standard"};
            var soundcloudOriginalSettings = new SoundCloudOriginalSettings() {Name = "SoundCloud Original"};

            var soundCloudLightBlocks = new SoundCloudBlockWaveFormSettings(Color.FromArgb(102, 102, 102), Color.FromArgb(103, 103, 103), Color.FromArgb(179, 179, 179),
                Color.FromArgb(218, 218, 218)) {Name = "SoundCloud Light Blocks"};

            var soundCloudDarkBlocks = new SoundCloudBlockWaveFormSettings(Color.FromArgb(52, 52, 52), Color.FromArgb(55, 55, 55), Color.FromArgb(154, 154, 154),
                Color.FromArgb(204, 204, 204)) {Name = "SoundCloud Darker Blocks"};

            var soundCloudOrangeBlocks = new SoundCloudBlockWaveFormSettings(Color.FromArgb(255, 76, 0), Color.FromArgb(255, 52, 2), Color.FromArgb(255, 171, 141),
                Color.FromArgb(255, 213, 199)) {Name = "SoundCloud Orange Blocks"};

            var topSpacerColor = Color.FromArgb(64, 83, 22, 3);
            var soundCloudOrangeTransparentBlocks = new SoundCloudBlockWaveFormSettings(Color.FromArgb(196, 197, 53, 0), topSpacerColor, Color.FromArgb(196, 79, 26, 0),
                Color.FromArgb(64, 79, 79, 79)) 
                { 
                    Name = "SoundCloud Orange Transparent Blocks", 
                    PixelsPerPeak = 2, 
                    SpacerPixels = 1,
                    TopSpacerGradientStartColor = topSpacerColor,
                    BackgroundColor = Color.Transparent
                };

            var topSpacerColor2 = Color.FromArgb(64, 224, 224, 224);
            var soundCloudGrayTransparentBlocks = new SoundCloudBlockWaveFormSettings(Color.FromArgb(196, 224, 225, 224), topSpacerColor2, Color.FromArgb(196, 128, 128, 128),
                Color.FromArgb(64, 128, 128, 128))
            {
                Name = "SoundCloud Gray Transparent Blocks",
                PixelsPerPeak = 2,
                SpacerPixels = 1,
                TopSpacerGradientStartColor = topSpacerColor2,
                BackgroundColor = Color.Transparent
            };


            buttonBottomColour.BackColor = standardSettings.BottomPeakPen.Color;
            buttonTopColour.BackColor = standardSettings.TopPeakPen.Color;
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
            var settings = (WaveFormRendererSettings) comboBoxRenderSettings.SelectedItem;
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
                settings.BackgroundImage = new Bitmap(imageFile);
            }
            pictureBox1.Image = null;
            labelRendering.Visible = true;
            Enabled = false;
            var peakProvider = GetPeakProvider();
            Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings));
        }

        private void RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            Image image = null;
            try
            {
                using(var waveStream = new AudioFileReader(selectedFile))
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

        private void FinishedRender(Image image)
        {
            labelRendering.Visible = false;
            pictureBox1.Image = image;
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

                standardSettings.TopPeakPen = new Pen(buttonTopColour.BackColor);
                standardSettings.BottomPeakPen = new Pen(buttonBottomColour.BackColor);
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
