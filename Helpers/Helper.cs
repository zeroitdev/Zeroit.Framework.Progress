// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Helper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{



    #region Helper Class For ZeroitButtonAlert
    /// <summary>
    /// Class Helpers.
    /// </summary>
    public static class Helpers
    {


        /// <summary>
        /// Fulls the rectangle.
        /// </summary>
        /// <param name="S">The s.</param>
        /// <param name="Subtract">if set to <c>true</c> [subtract].</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle FullRectangle(Size S, bool Subtract)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
            }
            else
            {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        /// <summary>
        /// Greys the color.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <returns>Color.</returns>
        public static Color GreyColor(uint G)
        {
            return Color.FromArgb((int)G, (int)G, (int)G);
        }

        /// <summary>
        /// Centers the string.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="T">The t.</param>
        /// <param name="F">The f.</param>
        /// <param name="C">The c.</param>
        /// <param name="R">The r.</param>
        public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point(R.Width / 2 - (int)(TS.Width / 2), R.Height / 2 - (int)(TS.Height / 2)));
            }
        }


        /// <summary>
        /// Fills the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R">The r.</param>
        /// <param name="Curve">The curve.</param>
        /// <param name="C">The c.</param>
        public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
                G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
            }

        }


        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R">The r.</param>
        /// <param name="Curve">The curve.</param>
        /// <param name="C">The c.</param>
        public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            }

        }

        /// <summary>
        /// Enum Direction
        /// </summary>
        public enum Direction : byte
        {
            /// <summary>
            /// Up
            /// </summary>
            Up = 0,
            /// <summary>
            /// Down
            /// </summary>
            Down = 1,
            /// <summary>
            /// The left
            /// </summary>
            Left = 2,
            /// <summary>
            /// The right
            /// </summary>
            Right = 3
        }

        /// <summary>
        /// Draws the triangle.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="Rect">The rect.</param>
        /// <param name="D">The d.</param>
        /// <param name="C">The c.</param>
        public static void DrawTriangle(Graphics G, Rectangle Rect, Direction D, Color C)
        {
            int halfWidth = Rect.Width / 2;
            int halfHeight = Rect.Height / 2;
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;

            switch (D)
            {
                case Direction.Up:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Top);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Down:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Bottom);
                    p1 = new Point(Rect.Left, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Top);

                    break;
                case Direction.Left:
                    p0 = new Point(Rect.Left, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Right, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Right:
                    p0 = new Point(Rect.Right, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Left, Rect.Top);

                    break;
            }

            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPolygon(B, new Point[] {
                p0,
                p1,
                p2
            });
            }

        }

    }

    #endregion




}
