using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace crapmap_converter.classes
{
    public class ColorReducer
    {
        // https://www.compuphase.com/cmetric.htm
        // https://stackoverflow.com/a/33782458/18775205

        public static double ColourDistance(Color e1, Color e2)
        {
            long rmean = ((long)e1.R + (long)e2.R) / 2;

            long r = (long)e1.R - (long)e2.R;
            long g = (long)e1.G - (long)e2.G;
            long b = (long)e1.B - (long)e2.B;

            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

        public static Image reduceColors(Image sourceImg, int transparencyCutoff = 254, int targetColors = 255)
        {
            Bitmap newImage = new Bitmap(sourceImg);
            int colorAmount = 0;
            int lastColorAmount = 0;

            cutTransparency(newImage, transparencyCutoff);

            while ((colorAmount = crapmap_csharp.Helper.getColorAmount((Image)newImage)) > targetColors)
            {
                // method stopped working / can't reduce colors anymoe
                if (lastColorAmount == colorAmount)
                {
                    break;
                }

                lastColorAmount = colorAmount;

                Dictionary<Color, int> colors = getColors(newImage);
                int colorRemoveAmount = colorAmount - targetColors;

                // Order by values ascending and take the first 'colorRemoveAmount' elements
                Dictionary<Color, int> orderedColors = colors
                    .OrderBy(kvp => kvp.Value)
                    .Take(colorRemoveAmount)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                replaceColors(newImage, orderedColors);
            }

            return (Bitmap)newImage;
        }

        public static void cutTransparency(Bitmap bmp, int transparencyCutoff = 254)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color currentPixel = bmp.GetPixel(x, y);
                    if (currentPixel.A < transparencyCutoff)
                    {
                        bmp.SetPixel(x, y, Color.Transparent);
                    }
                }
            }
        }

        public static Dictionary<Color, int> getColors(Bitmap bmp)
        {
            Dictionary<Color, int> colors = new Dictionary<Color, int>();

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color color = bmp.GetPixel(x, y);
                    if (!colors.ContainsKey(color))
                    {
                        colors.Add(color, 0);
                    }

                    colors[color]++;
                }
            }

            return colors;
        }

        public static void replaceColors(Bitmap bmp, Dictionary<Color, int> colors)
        {
            // debug counter
            int counter = 0;
            foreach (var color in colors.Keys)
            {
                counter++;
                replaceColor(bmp, color, colors[color]);
            }
        }

        public static void replaceColor(Bitmap bmp, Color colorToReplace, int replacements)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color currentPixel = bmp.GetPixel(x, y);
                    if (currentPixel == colorToReplace)
                    {
                        bmp.SetPixel(x, y, getClosestColor(bmp, currentPixel, x, y));

                        replacements--;

                        if (replacements == 0)
                        { return; }
                    }
                }
            }
        }

        public static Color getClosestColor(Bitmap bmp, Color currentPixel, int x, int y)
        {
            //List<Color> surroundingColors = GetSurroundingPixels(bmp, x, y);
            List<Color> surroundingColors = GetSpreadingPixels(bmp, x, y);

            Color closestColor = currentPixel;
            double closestColorDistance = double.MaxValue;
            for (int i = 0; i < surroundingColors.Count; i++)
            {
                double colorDistance = ColourDistance(closestColor, surroundingColors[i]);
                if (colorDistance < closestColorDistance)
                {
                    closestColorDistance = colorDistance;
                    closestColor = surroundingColors[i];
                }
            }

            return closestColor;
        }

        public static List<Color> GetSpreadingPixels(Bitmap bmp, int x, int y)
        {
            // chatGPT's try

            List<Color> surroundingPixels = new List<Color>();
            Color centerPixelColor = bmp.GetPixel(x, y);

            int range = 1; // Starting range
            bool foundDifferentPixel = false;

            while (!foundDifferentPixel)
            {
                for (int i = -range; i <= range; i++)
                {
                    for (int j = -range; j <= range; j++)
                    {
                        // Skip the center pixel
                        if (i == 0 && j == 0) continue;

                        int targetX = x + i;
                        int targetY = y + j;

                        // Check if the target coordinates are within the image bounds
                        if (targetX >= 0 && targetX < bmp.Width && targetY >= 0 && targetY < bmp.Height)
                        {
                            Color targetColor = bmp.GetPixel(targetX, targetY);

                            // Check if the color is different from the center pixel
                            if (targetColor != centerPixelColor)
                            {
                                surroundingPixels.Add(targetColor);
                                foundDifferentPixel = true;
                            }
                        }
                    }
                }
                range++; // Expand the search range for the next iteration
            }

            return surroundingPixels;
        }


        public static List<Color> GetSurroundingPixels(Bitmap bmp, int x, int y)
        {
            List<Color> surroundingPixels = new List<Color>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int targetX = x + i;
                    int targetY = y + j;

                    // Check if the target coordinates are within the image bounds
                    if (targetX >= 0 && targetX < bmp.Width && targetY >= 0 && targetY < bmp.Height)
                    {
                        surroundingPixels.Add(bmp.GetPixel(targetX, targetY));
                    }
                }
            }

            return surroundingPixels;
        }
    }
}
