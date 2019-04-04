// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 12-30-2017
// ***********************************************************************
// <copyright file="ProgressAntonio.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ProgressBarGradient

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitProgressBarNormal" />
    public class ZeroitProgressBarNormalGradient : ZeroitProgressBarNormal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarNormalGradient"/> class.
        /// </summary>
        public ZeroitProgressBarNormalGradient() : base()
        {
            _GradientPercent = 100;
            GradientType = GradientTypes.FullWidthGradient;
        }

        #region Drawing

        /// <summary>
        /// Prepare3s the parts.
        /// </summary>
        /// <returns>Rectangle[].</returns>
        public new Rectangle[] Prepare3Parts()
        {
            Rectangle xRec = ClientRectangle;
            int MiddleWidth = Progress.Math.MyMaths.Percent(xRec.Width, _GradientPercent);
            xRec.Inflate(MiddleWidth, 0);
            int Left = Progress.Math.MyMaths.Percent(ClientRectangle.Width + MiddleWidth, _iPercent);
            int Right = xRec.Width - MiddleWidth - Left;
            return Progress.Drawing.MyRectangle.SplitByPixels(xRec, new int[] { Left, MiddleWidth, Right }, Zeroit.Framework.Progress.Drawing.MyRectangle.SplitType.Horizontal);
        }
        /// <summary>
        /// Prepare4s the parts.
        /// </summary>
        /// <returns>Rectangle[].</returns>
        public Rectangle[] Prepare4Parts()
        {
            Rectangle[] xRecs = Prepare3Parts();
            Rectangle[] xMiddleparts = Progress.Drawing.MyRectangle.SplitByPercent(xRecs[1], new int[] { 50, 50 }, Zeroit.Framework.Progress.Drawing.MyRectangle.SplitType.Horizontal);
            return new Rectangle[] { xRecs[0], xMiddleparts[0], xMiddleparts[1], xRecs[2] };
        }
        /// <summary>
        /// Draws the background rolling.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void DrawBackgroundRolling(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = Prepare4Parts();
            xRecs[1].Width++;
            BrushAndFill(g, xRecs[2], _ColorProgress, BackColor);
            BrushAndFill(g, xRecs[1], BackColor, _ColorProgress);

        }
        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void DrawBackground(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = null;
            xRecs = Prepare3Parts();
            Rectangle xRectLeft = xRecs[0];
            Rectangle xRectMiddle = xRecs[1];
            Rectangle xRectRight = xRecs[2];
            xRectLeft.Width++;
            BrushAndFill(g, xRectMiddle, _ColorProgress, BackColor);
            FillRectangle(g, xRectLeft, xBrushes[BrushProgress]);
            FillRectangle(g, xRectRight, xBrushes[BrushBackGround]);

        }
        /// <summary>
        /// Brushes the and fill.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="xRec">The x record.</param>
        /// <param name="xColor1">The x color1.</param>
        /// <param name="xColor2">The x color2.</param>
        protected void BrushAndFill(Graphics g, Rectangle xRec, Color xColor1, Color xColor2)
        {
            if (xRec.Width == 0)
                return;
            Brush xBrush = new LinearGradientBrush(xRec, xColor1, xColor2, 0f);
            g.FillRectangle(xBrush, xRec);
            xBrush.Dispose();
        }


        #endregion

        #region Gradient
        //        protected const string BrushGradient = "BrushGradient";
        //        protected const string BrushGradientReversed = "BrushGradientReversed";

        /// <summary>
        /// The gradient percent
        /// </summary>
        private int _GradientPercent;
        /// <summary>
        /// Gets or sets the gradient percent.
        /// </summary>
        /// <value>The gradient percent.</value>
        /// <exception cref="ArgumentOutOfRangeException">GradientPercent - Must be between 1 and 100</exception>
        [Description("Gradient Percentage of Control"), Category("Gradient")]
        public int GradientPercent
        {
            get
            {
                return _GradientPercent;
            }
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentOutOfRangeException("GradientPercent", "Must be between 1 and 100");
                if (_GradientType == GradientTypes.FullWidthGradient)
                    return;
                _GradientPercent = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The gradient type
        /// </summary>
        private GradientTypes _GradientType;
        /// <summary>
        /// Gets or sets the type of the gradient.
        /// </summary>
        /// <value>The type of the gradient.</value>
        [Description("Gradient Type"), Category("Gradient")]
        public GradientTypes GradientType
        {
            get
            {
                return _GradientType;
            }
            set
            {
                if (value == GradientTypes.SpecificWidthGradient)
                    _GradientPercent = 50;
                if (value == GradientTypes.FullWidthGradient)
                    _GradientPercent = 100;
                _GradientType = value;
                Invalidate();
            }
        }


        #endregion

        #region Hidding Properties
        /// <summary>
        /// Gets the roll block percent.
        /// </summary>
        /// <value>The roll block percent.</value>
        [Browsable(false)]
        public override int RollBlockPercent
        {
            get
            {
                return base.RollBlockPercent;
            }
        }
        #endregion

        /// <summary>
        /// Enum that represents Gradient Types
        /// </summary>
        public enum GradientTypes
        {
            /// <summary>
            /// The specific width gradient
            /// </summary>
            SpecificWidthGradient,
            /// <summary>
            /// The full width gradient
            /// </summary>
            FullWidthGradient
        }




    }

    #endregion
}
