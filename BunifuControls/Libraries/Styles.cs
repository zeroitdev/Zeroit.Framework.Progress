using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{

    [DebuggerStepThrough]
    internal static class Styles
    {
        private static int int_0;

        private static int int_1;

        private static int int_2;

        private static int int_3;

        private static bool bool_0;

        static Styles()
        {
            Styles.bool_0 = true;
        }

        public static void onclick(Control pic)
        {
            Styles.ZoomOut(pic);
        }

        public static void unclick(Control pic)
        {
        }

        public static void ZoomIn(Control pic, int by)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (!Styles.bool_0)
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                Styles.int_0 = pic.Height;
                Styles.int_1 = pic.Width;
                int num3 = Convert.ToInt32(Math.Round((double)by * 0.01 * (double)Styles.int_0) * 0.5);
                int num4 = Convert.ToInt32(Math.Round((double)by * 0.01 * (double)Styles.int_1) * 0.5);
                int int0 = Styles.int_0 + num3 * 2;
                int int1 = Styles.int_1 + num4 * 2;
                Styles.int_2 = num3;
                Styles.int_3 = num4;
                pic.Width = int1;
                pic.Height = int0;
                pic.Top = pic.Top - Styles.int_2;
                pic.Left = pic.Left - Styles.int_3;
                Styles.bool_0 = false;
            }
        }

        public static void ZoomOut(Control pic)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (Styles.bool_0)
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                pic.SuspendLayout();
                pic.Width = Styles.int_1;
                pic.Left = pic.Left + Styles.int_3;
                pic.Height = Styles.int_0;
                pic.Top = pic.Top + Styles.int_2;
                pic.ResumeLayout();
                Styles.bool_0 = true;
            }
        }
    }

}
