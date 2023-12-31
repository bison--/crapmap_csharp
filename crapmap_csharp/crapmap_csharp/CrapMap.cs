﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace crapmap_csharp
{
    public class CrapMap
    {
        public const byte MIN_FILE_LENGTH = 9;  // byte
        public const byte VERSION = 1;
        public static readonly byte[] FILE_MAGIC_BYTES = { 0x43, 0x52, 0x41, 0x50 };

        public byte version = 0;
        public byte width = 0;
        public byte height = 0;
        public List<Color> colors = new List<Color> { Color.FromArgb(0, 255, 255, 255) };
        public List<byte> colorPixelMap = new List<byte>();

        public bool hasData()
        {
            return colorPixelMap.Count != 0;
        }

        public Image getImage()
        {
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);

            graphics.Clear(Color.Transparent);
            graphics.Flush();

            for(int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = colors[colorPixelMap[y * width + x]];
                    bmp.SetPixel(x, y, color);
                }
            }

            // crashes sometimes with: System.InvalidOperationException: "Das Objekt wird bereits an anderer Stelle verwendet."
            /*
            Parallel.For(0, height, (y) =>
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = colors[colorPixelMap[y * width + x]];
                    bmp.SetPixel(x, y, color);
                }
            });
            */

            return (Image)bmp;
        }

        public bool saveCrapmap(string filePath)
        {
            using (FileStream fsTarget = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // write header
                fsTarget.Write(FILE_MAGIC_BYTES, 0, FILE_MAGIC_BYTES.Length);
                fsTarget.WriteByte(VERSION);
                fsTarget.WriteByte(width);
                fsTarget.WriteByte(height);
                fsTarget.WriteByte((byte)(colors.Count - 1));

                // write colors
                for (int i = 1; i < colors.Count; i++)
                {
                    Color color = colors[i];
                    fsTarget.WriteByte(color.R);
                    fsTarget.WriteByte(color.G);
                    fsTarget.WriteByte(color.B);
                }

                // write color pixel map
                foreach (var colorIndex in colorPixelMap)
                {
                    fsTarget.WriteByte(colorIndex);
                }
            }

            return true;
        }

        public static bool isFileSizeOk(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length < MIN_FILE_LENGTH)
            {
                throw new Exception(
                    String.Format(
                        "File size too small. minimum: {0}, got: {1}, ",
                        MIN_FILE_LENGTH,
                        fileInfo.Length
                    )
                );
            }

            return true;
        }

        private static bool isMagicHeaderOk(FileStream fsSource)
        {
            byte[] magicBytes = new byte[4];
            if (fsSource.Read(magicBytes, 0, FILE_MAGIC_BYTES.Length) != FILE_MAGIC_BYTES.Length)
            {
                throw new Exception("Couldn't read header bytes.");
            }

            if (!magicBytes.SequenceEqual(FILE_MAGIC_BYTES))
            {
                throw new Exception(
                    String.Format(
                        "Magic byte's don't match, got: '{0}' ",
                        BitConverter.ToString(magicBytes)
                    )
                );
            }

            return true;
        }

        private static bool isVersionOk(FileStream fsSource)
        {
            int version = fsSource.ReadByte();
            if (version == -1)
            {
                throw new Exception(
                    "Could not read version."
                );
            }

            if (version != VERSION)
            {
                throw new Exception(
                    String.Format(
                        "Wrong Version. accepted: {0}, got: {1}, ",
                        VERSION,
                        version
                    )
                );
            }

            return true;
        }

        public bool loadFromFile(string filePath)
        {
            isFileSizeOk(filePath);

            using (FileStream fsSource = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                isMagicHeaderOk(fsSource);
                isVersionOk(fsSource);

                width = (byte)fsSource.ReadByte();
                height = (byte)fsSource.ReadByte();

                byte colorsAmount = (byte)fsSource.ReadByte();
                for (int i = 0; i < colorsAmount; i++)
                {
                    byte[] rgb = new byte[3];
                    fsSource.Read(rgb, 0, 3);
                    colors.Add(Color.FromArgb(rgb[0], rgb[1], rgb[2]));
                }

                int imageSize = width * height;
                for (int i = 0; i < imageSize; i++)
                {
                    colorPixelMap.Add((byte)fsSource.ReadByte());
                }
            }

            return true;
        }


        private static bool isImageSizeOk(Image img)
        {
            if (!Helper.isImageSizeOk(img)) {
                throw new Exception(
                    String.Format(
                        "Image too big. max: 255x255, got: {0}x{1}",
                        img.Width,
                        img.Height
                    )
                );
            }

            return true;
        }

        private static bool isColorAmountOk(Image img)
        {
            int colorAmount = Helper.getColorAmount(img);

            if (colorAmount > 255)
            {
                throw new Exception(
                    String.Format(
                        "Too many colors. max: 255, got: {0}",
                        colorAmount
                    )
                );
            }

            return true;
        }

        public bool loadFromImage(Image img)
        {
            isImageSizeOk(img);
            isColorAmountOk(img);

            width = (byte)img.Width;
            height = (byte)img.Height;
            version = VERSION;

            Bitmap bmp = (Bitmap)img;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color currentPixel = bmp.GetPixel(x, y);
                    if (!colors.Contains(currentPixel))
                    {
                        colors.Add(currentPixel);
                    }

                    byte index = (byte)colors.IndexOf(currentPixel);
                    colorPixelMap.Add(index);
                }
            }

            return true;
        }
    }
}
