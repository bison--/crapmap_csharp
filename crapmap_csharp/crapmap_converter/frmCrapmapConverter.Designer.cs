namespace crapmap_converter
{
    partial class frmCrapmapConverter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrapmapConverter));
            this.ofdLoadImage = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLoadImage = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrgSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrgColors = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblNewColors = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNewSize = new System.Windows.Forms.Label();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslConversionDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.picSource = new crapmap_csharp_forms.classes.PictureBoxAdvanced();
            this.picTarget = new crapmap_csharp_forms.classes.PictureBoxAdvanced();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.stsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdLoadImage
            // 
            this.ofdLoadImage.Filter = "Images|*.jpg;*.png";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadImage,
            this.tsbSaveAs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLoadImage
            // 
            this.tsbLoadImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadImage.Image")));
            this.tsbLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadImage.Name = "tsbLoadImage";
            this.tsbLoadImage.Size = new System.Drawing.Size(73, 22);
            this.tsbLoadImage.Text = "Load Image";
            this.tsbLoadImage.Click += new System.EventHandler(this.tsbLoadImage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Original Size:";
            // 
            // lblOrgSize
            // 
            this.lblOrgSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrgSize.AutoSize = true;
            this.lblOrgSize.Location = new System.Drawing.Point(90, 267);
            this.lblOrgSize.Name = "lblOrgSize";
            this.lblOrgSize.Size = new System.Drawing.Size(24, 13);
            this.lblOrgSize.TabIndex = 7;
            this.lblOrgSize.Text = "0x0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Original Colors:";
            // 
            // lblOrgColors
            // 
            this.lblOrgColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrgColors.AutoSize = true;
            this.lblOrgColors.Location = new System.Drawing.Point(90, 290);
            this.lblOrgColors.Name = "lblOrgColors";
            this.lblOrgColors.Size = new System.Drawing.Size(13, 13);
            this.lblOrgColors.TabIndex = 9;
            this.lblOrgColors.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picSource);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrgColors);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrgSize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblNewColors);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblNewSize);
            this.splitContainer1.Panel2.Controls.Add(this.picTarget);
            this.splitContainer1.Size = new System.Drawing.Size(547, 313);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 10;
            // 
            // lblNewColors
            // 
            this.lblNewColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewColors.AutoSize = true;
            this.lblNewColors.Location = new System.Drawing.Point(73, 290);
            this.lblNewColors.Name = "lblNewColors";
            this.lblNewColors.Size = new System.Drawing.Size(13, 13);
            this.lblNewColors.TabIndex = 13;
            this.lblNewColors.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "New Size:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "New Colors:";
            // 
            // lblNewSize
            // 
            this.lblNewSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewSize.AutoSize = true;
            this.lblNewSize.Location = new System.Drawing.Point(73, 267);
            this.lblNewSize.Name = "lblNewSize";
            this.lblNewSize.Size = new System.Drawing.Size(24, 13);
            this.lblNewSize.TabIndex = 11;
            this.lblNewSize.Text = "0x0";
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslConversionDuration});
            this.stsMain.Location = new System.Drawing.Point(0, 344);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(568, 22);
            this.stsMain.TabIndex = 11;
            this.stsMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "Duration:";
            // 
            // tsslConversionDuration
            // 
            this.tsslConversionDuration.Name = "tsslConversionDuration";
            this.tsslConversionDuration.Size = new System.Drawing.Size(13, 17);
            this.tsslConversionDuration.Text = "0";
            // 
            // picSource
            // 
            this.picSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSource.Location = new System.Drawing.Point(10, 3);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(255, 255);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSource.TabIndex = 3;
            this.picSource.TabStop = false;
            // 
            // picTarget
            // 
            this.picTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTarget.Location = new System.Drawing.Point(3, 3);
            this.picTarget.Name = "picTarget";
            this.picTarget.Size = new System.Drawing.Size(255, 255);
            this.picTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTarget.TabIndex = 4;
            this.picTarget.TabStop = false;
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAs.Image")));
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(51, 22);
            this.tsbSaveAs.Text = "Save As";
            this.tsbSaveAs.Click += new System.EventHandler(this.tsbSaveAs_Click);
            // 
            // sfdExport
            // 
            this.sfdExport.DefaultExt = "crapmap";
            this.sfdExport.Filter = "crapmap|*.crapmap|png|*.png";
            this.sfdExport.Title = "Save Image as...";
            // 
            // frmCrapmapConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 366);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCrapmapConverter";
            this.Text = "CRAPMAP converter";
            this.Load += new System.EventHandler(this.frmCrapmapConverter_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdLoadImage;
        private crapmap_csharp_forms.classes.PictureBoxAdvanced picSource;
        private crapmap_csharp_forms.classes.PictureBoxAdvanced picTarget;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbLoadImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrgSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrgColors;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblNewColors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNewSize;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslConversionDuration;
        private System.Windows.Forms.ToolStripButton tsbSaveAs;
        private System.Windows.Forms.SaveFileDialog sfdExport;
    }
}

