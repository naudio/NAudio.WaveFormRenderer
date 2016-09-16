namespace WaveFormRendererApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadSoundFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxPeakCalculationStrategy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.upDownBlockSize = new System.Windows.Forms.NumericUpDown();
            this.buttonRefreshImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.upDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.upDownTopHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.upDownBottomHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDecibels = new System.Windows.Forms.CheckBox();
            this.labelRendering = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonTopColour = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonBottomColour = new System.Windows.Forms.Button();
            this.comboBoxRenderSettings = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTopHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBottomHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadSoundFile
            // 
            this.buttonLoadSoundFile.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadSoundFile.Name = "buttonLoadSoundFile";
            this.buttonLoadSoundFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadSoundFile.TabIndex = 0;
            this.buttonLoadSoundFile.Text = "Load Audio";
            this.buttonLoadSoundFile.UseVisualStyleBackColor = true;
            this.buttonLoadSoundFile.Click += new System.EventHandler(this.OnLoadSoundFileClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(819, 173);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxPeakCalculationStrategy
            // 
            this.comboBoxPeakCalculationStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeakCalculationStrategy.FormattingEnabled = true;
            this.comboBoxPeakCalculationStrategy.Location = new System.Drawing.Point(228, 14);
            this.comboBoxPeakCalculationStrategy.Name = "comboBoxPeakCalculationStrategy";
            this.comboBoxPeakCalculationStrategy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPeakCalculationStrategy.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Peak Calculation Strategy";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(654, 42);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnButtonSaveClick);
            // 
            // upDownBlockSize
            // 
            this.upDownBlockSize.Location = new System.Drawing.Point(228, 42);
            this.upDownBlockSize.Maximum = new decimal(new int[] {
            44100,
            0,
            0,
            0});
            this.upDownBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownBlockSize.Name = "upDownBlockSize";
            this.upDownBlockSize.Size = new System.Drawing.Size(60, 20);
            this.upDownBlockSize.TabIndex = 5;
            this.upDownBlockSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // buttonRefreshImage
            // 
            this.buttonRefreshImage.Location = new System.Drawing.Point(654, 8);
            this.buttonRefreshImage.Name = "buttonRefreshImage";
            this.buttonRefreshImage.Size = new System.Drawing.Size(100, 23);
            this.buttonRefreshImage.TabIndex = 6;
            this.buttonRefreshImage.Text = "Refresh Image";
            this.buttonRefreshImage.UseVisualStyleBackColor = true;
            this.buttonRefreshImage.Click += new System.EventHandler(this.OnRefreshImageClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Block Size";
            // 
            // upDownWidth
            // 
            this.upDownWidth.Location = new System.Drawing.Point(80, 44);
            this.upDownWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownWidth.Name = "upDownWidth";
            this.upDownWidth.Size = new System.Drawing.Size(57, 20);
            this.upDownWidth.TabIndex = 5;
            this.upDownWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image Width";
            // 
            // upDownTopHeight
            // 
            this.upDownTopHeight.Location = new System.Drawing.Point(244, 76);
            this.upDownTopHeight.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.upDownTopHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownTopHeight.Name = "upDownTopHeight";
            this.upDownTopHeight.Size = new System.Drawing.Size(56, 20);
            this.upDownTopHeight.TabIndex = 5;
            this.upDownTopHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Top Height";
            // 
            // upDownBottomHeight
            // 
            this.upDownBottomHeight.Location = new System.Drawing.Point(244, 105);
            this.upDownBottomHeight.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.upDownBottomHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownBottomHeight.Name = "upDownBottomHeight";
            this.upDownBottomHeight.Size = new System.Drawing.Size(56, 20);
            this.upDownBottomHeight.TabIndex = 5;
            this.upDownBottomHeight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Bottom Height";
            // 
            // checkBoxDecibels
            // 
            this.checkBoxDecibels.AutoSize = true;
            this.checkBoxDecibels.Location = new System.Drawing.Point(354, 17);
            this.checkBoxDecibels.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxDecibels.Name = "checkBoxDecibels";
            this.checkBoxDecibels.Size = new System.Drawing.Size(67, 17);
            this.checkBoxDecibels.TabIndex = 10;
            this.checkBoxDecibels.Text = "Decibels";
            this.checkBoxDecibels.UseVisualStyleBackColor = true;
            this.checkBoxDecibels.CheckedChanged += new System.EventHandler(this.OnDecibelsCheckedChanged);
            // 
            // labelRendering
            // 
            this.labelRendering.AutoSize = true;
            this.labelRendering.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRendering.ForeColor = System.Drawing.Color.Silver;
            this.labelRendering.Location = new System.Drawing.Point(15, 165);
            this.labelRendering.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRendering.Name = "labelRendering";
            this.labelRendering.Size = new System.Drawing.Size(286, 55);
            this.labelRendering.TabIndex = 11;
            this.labelRendering.Text = "Rendering...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Top Colour:";
            // 
            // buttonTopColour
            // 
            this.buttonTopColour.Location = new System.Drawing.Point(115, 73);
            this.buttonTopColour.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTopColour.Name = "buttonTopColour";
            this.buttonTopColour.Size = new System.Drawing.Size(28, 23);
            this.buttonTopColour.TabIndex = 9;
            this.buttonTopColour.UseVisualStyleBackColor = true;
            this.buttonTopColour.Click += new System.EventHandler(this.OnColorButtonClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Bottom Colour:";
            // 
            // buttonBottomColour
            // 
            this.buttonBottomColour.Location = new System.Drawing.Point(115, 102);
            this.buttonBottomColour.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBottomColour.Name = "buttonBottomColour";
            this.buttonBottomColour.Size = new System.Drawing.Size(28, 23);
            this.buttonBottomColour.TabIndex = 9;
            this.buttonBottomColour.UseVisualStyleBackColor = true;
            this.buttonBottomColour.Click += new System.EventHandler(this.OnColorButtonClick);
            // 
            // comboBoxRenderSettings
            // 
            this.comboBoxRenderSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRenderSettings.DropDownWidth = 250;
            this.comboBoxRenderSettings.FormattingEnabled = true;
            this.comboBoxRenderSettings.Location = new System.Drawing.Point(445, 43);
            this.comboBoxRenderSettings.Name = "comboBoxRenderSettings";
            this.comboBoxRenderSettings.Size = new System.Drawing.Size(171, 21);
            this.comboBoxRenderSettings.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rendering Style";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Background Image:";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(427, 102);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(100, 23);
            this.buttonLoadImage.TabIndex = 15;
            this.buttonLoadImage.Text = "Load...";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.OnButtonLoadImageClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 349);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxRenderSettings);
            this.Controls.Add(this.labelRendering);
            this.Controls.Add(this.checkBoxDecibels);
            this.Controls.Add(this.buttonBottomColour);
            this.Controls.Add(this.buttonTopColour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.upDownBottomHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.upDownTopHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.upDownWidth);
            this.Controls.Add(this.buttonRefreshImage);
            this.Controls.Add(this.upDownBlockSize);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPeakCalculationStrategy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLoadSoundFile);
            this.Name = "MainForm";
            this.Text = "Waveform Renderer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTopHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBottomHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadSoundFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxPeakCalculationStrategy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NumericUpDown upDownBlockSize;
        private System.Windows.Forms.Button buttonRefreshImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown upDownWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown upDownTopHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown upDownBottomHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxDecibels;
        private System.Windows.Forms.Label labelRendering;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonTopColour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBottomColour;
        private System.Windows.Forms.ComboBox comboBoxRenderSettings;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonLoadImage;
    }
}

