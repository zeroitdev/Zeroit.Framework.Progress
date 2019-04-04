using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Zeroit.Framework.Progress.CustomControls
{
    [DebuggerStepThrough]
    internal class Graphics
    {
        public Graphics()
        {
        }

        public static Color AddColor(Color col1, Color col2)
        {
            return Color.FromArgb((col1.R + col2.R) / 2, (col1.G + col2.G) / 2, (col1.B + col2.B) / 2);
        }

        public static Color getColorScale(int Passentage, Color startColor, Color endColor)
        {
            double num = Math.Round((double)startColor.R + (double)((endColor.R - startColor.R) * Passentage) * 0.01, 0);
            int num1 = int.Parse(num.ToString());
            num = Math.Round((double)startColor.G + (double)((endColor.G - startColor.G) * Passentage) * 0.01, 0);
            int num2 = int.Parse(num.ToString());
            num = Math.Round((double)startColor.B + (double)((endColor.B - startColor.B) * Passentage) * 0.01, 0);
            int num3 = int.Parse(num.ToString());
            return Color.FromArgb(255, num1, num2, num3);
        }

        public static Image OverlayColor(Image _Image, Color Find, Color Replace)
        {
            Bitmap bitmap = new Bitmap(_Image);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (!smethod_0(bitmap.GetPixel(j, i)))
                    {
                        bitmap.SetPixel(j, i, Replace);
                    }
                }
            }
            return bitmap;
        }

        public static Image OverlayColor(Image _Image, Color Replace)
        {
            Bitmap bitmap = new Bitmap(_Image);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (!smethod_0(bitmap.GetPixel(j, i)))
                    {
                        bitmap.SetPixel(j, i, Replace);
                    }
                }
            }
            return bitmap;
        }

        private static bool smethod_0(Color color_0)
        {
            if (color_0.R != 0 || color_0.G != 0)
            {
                return false;
            }
            return color_0.B == 0;
        }

        public static Image Smoothen(Image _img)
        {
            Bitmap bitmap = new Bitmap(_img);
            List<int[]> numArrays = new List<int[]>();
            for (int i = 0; i < bitmap.Height - 1; i++)
            {
                for (int j = 0; j < bitmap.Width - 1; j++)
                {
                    Color[] pixel = new Color[] { bitmap.GetPixel(j, i), default(Color), bitmap.GetPixel(j, i + 1), default(Color) };
                    pixel[1] = bitmap.GetPixel(j + 1, i);
                    pixel[3] = bitmap.GetPixel(j + 1, i + 1);
                    if (pixel[1] == pixel[2] && !smethod_0(pixel[1]) && smethod_0(pixel[0]))
                    {
                        numArrays.Add(new int[] { j, i });
                    }
                    if (pixel[0] == pixel[3] && !smethod_0(pixel[0]) && smethod_0(pixel[2]))
                    {
                        numArrays.Add(new int[] { j, i + 1 });
                    }
                    if (pixel[0] == pixel[3] && !smethod_0(pixel[0]) && smethod_0(pixel[1]))
                    {
                        numArrays.Add(new int[] { j + 1, i });
                    }
                    if (pixel[1] == pixel[2] && !smethod_0(pixel[1]) && smethod_0(pixel[3]))
                    {
                        numArrays.Add(new int[] { j + 1, i + 1 });
                    }
                }
            }
            for (int k = 0; k < numArrays.Count; k++)
            {
                bitmap.SetPixel(numArrays[k][0], numArrays[k][1], AddColor(Color.Yellow, Color.FromArgb(211, 211, 211)));
            }
            return bitmap;
        }
    }
}
