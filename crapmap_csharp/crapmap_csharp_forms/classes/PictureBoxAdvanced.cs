using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace crapmap_csharp_forms.classes
{
    public class PictureBoxAdvanced : PictureBox
    {
        private InterpolationMode _interpolationMode = InterpolationMode.NearestNeighbor;

        [Category("Behavior")]
        [DefaultValue(InterpolationMode.NearestNeighbor)]
        public InterpolationMode InterpolationMode
        {
            get { return _interpolationMode; }
            set { _interpolationMode = value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.InterpolationMode = this.InterpolationMode;

            // Fix half-pixel shift on NearestNeighbor
            if (this.InterpolationMode == InterpolationMode.NearestNeighbor)
                g.PixelOffsetMode = PixelOffsetMode.Half;

            base.OnPaint(pe);
        }
    }
}
