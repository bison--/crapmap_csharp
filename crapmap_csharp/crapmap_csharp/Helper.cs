using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace crapmap_csharp
{
    public class Helper
    {
        public static int getColorAmount(Image img)
        {
            HashSet<Color> colors = new HashSet<Color>();

            Bitmap bmp = (Bitmap)img;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    colors.Add(bmp.GetPixel(x, y));
                }
            }

            return colors.Count;
        }

        public static bool isColorAmountOk(Image img)
        {
            int colorAmount = getColorAmount(img);
            return colorAmount >= 1 && colorAmount <= 255;
        }

        public static bool isImageSizeOk(Image img)
        {
            return 
                img.Width > 0 && img.Height > 0 
                &&
                img.Width <= 255 && img.Height <= 255;
        }
    }
}
