﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MyRectangle.cs" company="Zeroit Dev Technologies">
//    This program is for creating Progress controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.Progress.Drawing
{
    /// <summary>
    /// Description of Rectangle.
    /// </summary>
    public class MyRectangle
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="MyRectangle"/> class.
        /// </summary>
        public MyRectangle()
		{
		}
        /// <summary>
        /// Middles the point.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <returns>Point.</returns>
        public static Point MiddlePoint(Rectangle xRec)
		{
            return new Point(xRec.Left + (int)((float)xRec.Width / 2), xRec.Top + (int)((float)xRec.Height / 2));
		}

        /// <summary>
        /// Enum SplitType
        /// </summary>
        public enum SplitType{Horizontal,Vertical};

        /// <summary>
        /// Splits the horizontal by percent.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Percents">The percents.</param>
        /// <returns>Rectangle[].</returns>
        protected static Rectangle[] SplitHorizontalByPercent(Rectangle xRec, int[] Percents)
        {
            if(Percents.Length<1)
                return new Rectangle[] { xRec };
            Rectangle[] xOut = new Rectangle[Percents.Length];
            xOut[0].X = xRec.X;
            xOut[0].Y = xRec.Y;
            xOut[0].Width = Math.MyMaths.Percent(xRec.Width, Percents[0]);
            xOut[0].Height = xRec.Height;
            for (int i = 1; i < xOut.Length; i++)
            {
                xOut[i].X = xOut[i-1].Right;
                xOut[i].Y = xRec.Y;
                xOut[i].Width = Math.MyMaths.Percent(xRec.Width, Percents[i]);
                xOut[i].Height = xRec.Height;
            }
            return xOut;
        }
        /// <summary>
        /// Splits the horizontal by pixels.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Pixels">The pixels.</param>
        /// <returns>Rectangle[].</returns>
        protected static Rectangle[] SplitHorizontalByPixels(Rectangle xRec, int[] Pixels)
        {
            if (Pixels.Length < 1)
                return new Rectangle[] { xRec };
            Rectangle[] xOut = new Rectangle[Pixels.Length];
            xOut[0].X = xRec.X;
            xOut[0].Y = xRec.Y;
            xOut[0].Width = Pixels[0];
            xOut[0].Height = xRec.Height;
            for (int i = 1; i < xOut.Length; i++)
            {
                xOut[i].X = xOut[i - 1].Right;
                xOut[i].Y = xRec.Y;
                xOut[i].Width = Pixels[i];
                xOut[i].Height = xRec.Height;
            }
            return xOut;
        }
        /// <summary>
        /// Splits the horizontal in parts.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Parts">The parts.</param>
        /// <returns>Rectangle[].</returns>
        protected static Rectangle[] SplitHorizontalInParts(Rectangle xRec, int Parts)
        {
            if (Parts<2)
                return new Rectangle[] { xRec };
            Rectangle[] xOut = new Rectangle[Parts];
            int PartWidth =(int)System.Math.Ceiling((float)xRec.Width / Parts);
            xOut[0].X = xRec.X;
            xOut[0].Y = xRec.Y;
            xOut[0].Width = PartWidth;
            xOut[0].Height = xRec.Height;
            for (int i = 1; i < Parts; i++)
            {
                xOut[i].X = xOut[i - 1].Right;
                xOut[i].Y = xRec.Y;
                xOut[i].Width = PartWidth;
                xOut[i].Height = xRec.Height;
            }
            if (xOut[Parts - 1].Right != xRec.Right)
                xOut[Parts - 1].Width = xRec.Right - xOut[Parts - 1].X;
            return xOut;
        }

        /// <summary>
        /// Splits the by percent.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Percents">The percents.</param>
        /// <param name="xSplitType">Type of the x split.</param>
        /// <returns>Rectangle[].</returns>
        public static Rectangle[] SplitByPercent(Rectangle xRec, int[] Percents, SplitType xSplitType)
        {
            Rectangle[] xOutput = null;
            switch (xSplitType)
            {
                case SplitType.Horizontal:
                    xOutput = MyRectangle.SplitHorizontalByPercent(xRec, Percents);
                    break;
                case SplitType.Vertical:
                    break;
            }
            return xOutput;
        }
        /// <summary>
        /// Splits the by pixels.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Pixels">The pixels.</param>
        /// <param name="xSplitType">Type of the x split.</param>
        /// <returns>Rectangle[].</returns>
        public static Rectangle[] SplitByPixels(Rectangle xRec, int[] Pixels, SplitType xSplitType)
        {
            Rectangle[] xOutput = null;
            switch (xSplitType)
            {
                case SplitType.Horizontal:
                    xOutput = MyRectangle.SplitHorizontalByPixels(xRec, Pixels);
                    break;
                case SplitType.Vertical:
                    break;
            }
            return xOutput;
        }
        /// <summary>
        /// Splits the in parts.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Parts">The parts.</param>
        /// <param name="xSplitType">Type of the x split.</param>
        /// <returns>Rectangle[].</returns>
        public static Rectangle[] SplitInParts(Rectangle xRec, int Parts, SplitType xSplitType)
        {
            Rectangle[] xOutput = null;
            switch (xSplitType)
            {
                case SplitType.Horizontal:
                    xOutput = MyRectangle.SplitHorizontalInParts(xRec, Parts);
                    break;
                case SplitType.Vertical:
                    break;
            }
            return xOutput;
        }

        /// <summary>
        /// Pathes the around.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <returns>Point[].</returns>
        public static Point[] PathAround(Rectangle xRec)
        {
            Point[] xPath = new Point[5];
            xPath[0] = new Point(xRec.Left, xRec.Top);
            xPath[1] = new Point(xRec.Right-1, xRec.Top);
            xPath[2] = new Point(xRec.Right-1, xRec.Bottom-1);
            xPath[3] = new Point(xRec.Left, xRec.Bottom-1);
            xPath[4] = new Point(xRec.Left, xRec.Top);
            return xPath;
        }

        /// <summary>
        /// Moves the specified x record.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Horizontal">The horizontal.</param>
        /// <param name="Vertical">The vertical.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle Move(Rectangle xRec, int Horizontal, int Vertical)
        {
            xRec.Width += Horizontal;
            xRec.Height += Vertical;
            return xRec;
        }

        /// <summary>
        /// Resizes the specified x record.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="DifferenceW">The difference w.</param>
        /// <param name="DifferenceH">The difference h.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle Resize(Rectangle xRec, int DifferenceW, int DifferenceH)
        {
            Rectangle xNew = xRec;
            xNew.X -= DifferenceW;
            xNew.Y -= DifferenceH;
            xNew.Width += DifferenceW * 2;
            xNew.Height += DifferenceH * 2;
            return xNew;
        }
        /// <summary>
        /// Resizes the specified x record.
        /// </summary>
        /// <param name="xRec">The x record.</param>
        /// <param name="Difference">The difference.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle Resize(Rectangle xRec, int Difference)
        {
            return MyRectangle.Resize(xRec, Difference, Difference);
        }

        /// <summary>
        /// Joins the specified x rec1.
        /// </summary>
        /// <param name="xRec1">The x rec1.</param>
        /// <param name="xRec2">The x rec2.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle Join(Rectangle xRec1, Rectangle xRec2)
        {
            Rectangle xOut=new Rectangle();
            xOut.X=xRec1.X<xRec2.X?xRec1.X:xRec2.X;
            xOut.Y = xRec1.Y < xRec2.Y ? xRec1.Y : xRec2.Y;
            int Right=xRec1.Right>xRec2.Right?xRec1.Right:xRec2.Right;
            int Bottom=xRec1.Bottom>xRec2.Bottom?xRec1.Bottom:xRec2.Bottom;
            xOut.Width = Right - xOut.X;
            xOut.Height = Bottom - xOut.Y;

            return xOut;
        }


	}
}
