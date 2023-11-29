using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using crapmap_csharp;

namespace crapmap_csharp_forms
{
    public partial class frmShowCrapmap : Form
    {
        private string windowBaseTitle = "";
        crapmap_csharp.CrapMap crapmap = new CrapMap();

        public frmShowCrapmap()
        {
            InitializeComponent();
            windowBaseTitle = Text;
        }

        private void frmShowCrapmap_Load(object sender, EventArgs e)
        {
            string imagePath = "images/sample2.crapmap";

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            { imagePath = args[1]; }

            FileInfo imageInfo = new FileInfo(imagePath);

            Text = string.Format(
                "{0} - {1}",
                windowBaseTitle,
                imageInfo.Name
            );

            if (imageInfo.Exists)
            {
                try
                {
                    crapmap.loadFile(imagePath);
                    picImage.Image = crapmap.getImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "ERROR READING FILE",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
        }
    }
}
