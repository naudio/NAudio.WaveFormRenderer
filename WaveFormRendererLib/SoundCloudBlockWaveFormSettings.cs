using System.Drawing;

namespace WaveFormRendererLib
{
    public class SoundCloudBlockWaveFormSettings : WaveFormRendererSettings
    {
        private readonly Color topSpacerStartColor;
        private Pen topPen;
        private Pen topSpacerPen;
        private Pen bottomPen;
        private Pen bottomSpacerPen;

        private int lastTopHeight;
        private int lastBottomHeight;

        public SoundCloudBlockWaveFormSettings(Color topPeakColor, Color topSpacerStartColor, Color bottomPeakColor, Color bottomSpacerColor)
        {
            this.topSpacerStartColor = topSpacerStartColor;
            topPen = new Pen(topPeakColor);
            bottomPen = new Pen(bottomPeakColor);
            bottomSpacerPen = new Pen(bottomSpacerColor);
            PixelsPerPeak = 4;
            SpacerPixels = 2;
            BackgroundColor = Color.White;
            TopSpacerGradientStartColor = Color.White;
        }

        public override Pen TopPeakPen
        {
            get { return topPen; }
            set { topPen = value; }
        }

        public Color TopSpacerGradientStartColor { get; set; }

        public override Pen TopSpacerPen
        {
            get
            {
                if (topSpacerPen == null || lastBottomHeight != BottomHeight || lastTopHeight != TopHeight)
                {
                    topSpacerPen = CreateGradientPen(TopHeight, TopSpacerGradientStartColor, topSpacerStartColor);
                    lastBottomHeight = BottomHeight;
                    lastTopHeight = TopHeight;
                }
                return topSpacerPen;
            }
            set { topSpacerPen = value; }
        }


        public override Pen BottomPeakPen
        {
            get { return bottomPen; }
            set { bottomPen = value; }
        }


        public override Pen BottomSpacerPen
        {
            get { return bottomSpacerPen; }
            set { bottomSpacerPen = value; }
        }

    }
}