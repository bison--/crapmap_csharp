using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crapmap_converter
{
    public partial class frmCrapmapConverter : Form
    {
        crapmap_csharp.CrapMap crapMap;

        public frmCrapmapConverter()
        {
            InitializeComponent();
        }

        private void frmCrapmapConverter_Load(object sender, EventArgs e)
        {

        }

        private void tsbLoadImage_Click(object sender, EventArgs e)
        {
            if (ofdLoadImage.ShowDialog() != DialogResult.OK)
            { return; }

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            crapMap = new crapmap_csharp.CrapMap();

            picSource.Image = Image.FromFile(ofdLoadImage.FileName);

            lblOrgSize.Text = String.Format("{0}x{1}", picSource.Image.Width, picSource.Image.Height);
            lblOrgColors.Text = crapmap_csharp.Helper.getColorAmount(picSource.Image).ToString();

            if (!crapmap_csharp.Helper.isImageSizeOk(picSource.Image))
            {
                picSource.Image = DownscaleImageProportionally(picSource.Image, 255, 255);

                lblOrgSize.Text += " downscaled: " + String.Format("{0}x{1}", picSource.Image.Width, picSource.Image.Height);
                lblOrgColors.Text += " downscaled: " + crapmap_csharp.Helper.getColorAmount(picSource.Image).ToString();
            }

            if (!crapmap_csharp.Helper.isColorAmountOk(picSource.Image))
            {
                picTarget.Image = classes.ColorReducer.reduceColors(picSource.Image);
            } 
            else
            {
                picTarget.Image = new Bitmap(picSource.Image);
            }

            stopWatch.Stop();
            tsslConversionDuration.Text = stopWatch.Elapsed.ToString();

            lblNewSize.Text = String.Format("{0}x{1}", picTarget.Image.Width, picTarget.Image.Height);
            lblNewColors.Text = crapmap_csharp.Helper.getColorAmount(picTarget.Image).ToString();

            try
            {
                crapMap.loadFromImage(picTarget.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Image could not be saved/converted to crapmap.\n" + ex.Message,
                    "CRAP!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public static Image DownscaleImageProportionally(Image originalImage, int maxWidth, int maxHeight)
        {
            // Calculate the scaling factor
            double widthRatio = (double)maxWidth / originalImage.Width;
            double heightRatio = (double)maxHeight / originalImage.Height;
            double scaleRatio = Math.Min(widthRatio, heightRatio);

            // Calculate the new width and height
            int newWidth = (int)(originalImage.Width * scaleRatio);
            int newHeight = (int)(originalImage.Height * scaleRatio);

            // Create a new Bitmap with the new dimensions
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            // Draw the original image, scaled down to the new size
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdExport.ShowDialog() != DialogResult.OK)
            { return; } 

            if (sfdExport.FileName.EndsWith(".png"))
            {
                picTarget.Image.Save(sfdExport.FileName);
            }
            else if (sfdExport.FileName.EndsWith(".crapmap"))
            {
                if (!crapMap.hasData())
                {
                    MessageBox.Show(
                        "Image could not be saved/converted to crapmap.",
                        "CRAP, NO MAP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );

                    return;
                }

                try
                {
                    crapMap.saveCrapmap(sfdExport.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Image could not be saved/converted to crapmap.\n" + ex.Message,
                        "CRAP!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
