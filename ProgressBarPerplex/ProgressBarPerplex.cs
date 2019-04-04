// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressBarPerplex.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarPerplex

    /// <summary>
    /// A class collection for rendering a rectangular progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressBarPerplexDesigner))]
    public class ZeroitProgressBarPerplex : Control
    {

        #region Include in Private Field
        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;

        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether automatically animate the control.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {

            if (this.Value + 1 > this.Maximum)
            {
                this.Value = 0;
            }

            else
            {
                this.Value++;
            }


            if (this.colorGradientAngle + 1 > this.Maximum)
            {
                this.colorGradientAngle = 0;
            }

            else
            {
                this.colorGradientAngle++;
            }

        }

        #endregion

        #region HatchBrush

        /// <summary>
        /// The hatch brushgradient1
        /// </summary>
        private Color hatchBrushgradient1 = Color.Black;
        /// <summary>
        /// The hatch brushgradient2
        /// </summary>
        private Color hatchBrushgradient2 = Color.Transparent;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchBrushType hatchBrushType = HatchBrushType.ForwardDiagonal;

        /// <summary>
        /// Enum representing the type of Hatch Brush.
        /// </summary>
        public enum HatchBrushType
        {
            /// <summary>
            /// The backward diagonal
            /// </summary>
            BackwardDiagonal,
            /// <summary>
            /// The cross
            /// </summary>
            Cross,
            /// <summary>
            /// The dark downward diagonal
            /// </summary>
            DarkDownwardDiagonal,
            /// <summary>
            /// The dark horizontal
            /// </summary>
            DarkHorizontal,
            /// <summary>
            /// The dark upward diagonal
            /// </summary>
            DarkUpwardDiagonal,
            /// <summary>
            /// The dark vertical
            /// </summary>
            DarkVertical,
            /// <summary>
            /// The dashed downward diagonal
            /// </summary>
            DashedDownwardDiagonal,
            /// <summary>
            /// The dashed horizontal
            /// </summary>
            DashedHorizontal,
            /// <summary>
            /// The dashed upward diagonal
            /// </summary>
            DashedUpwardDiagonal,
            /// <summary>
            /// The dashed vertical
            /// </summary>
            DashedVertical,
            /// <summary>
            /// The diagonal brick
            /// </summary>
            DiagonalBrick,
            /// <summary>
            /// The diagonal cross
            /// </summary>
            DiagonalCross,
            /// <summary>
            /// The divot
            /// </summary>
            Divot,
            /// <summary>
            /// The dotted diamond
            /// </summary>
            DottedDiamond,
            /// <summary>
            /// The dotted grid
            /// </summary>
            DottedGrid,
            /// <summary>
            /// The forward diagonal
            /// </summary>
            ForwardDiagonal,
            /// <summary>
            /// The horizontal
            /// </summary>
            Horizontal,
            /// <summary>
            /// The horizontal brick
            /// </summary>
            HorizontalBrick,
            /// <summary>
            /// The large checker board
            /// </summary>
            LargeCheckerBoard,
            /// <summary>
            /// The large confetti
            /// </summary>
            LargeConfetti,
            /// <summary>
            /// The large grid
            /// </summary>
            LargeGrid,
            /// <summary>
            /// The light downward diagonal
            /// </summary>
            LightDownwardDiagonal,
            /// <summary>
            /// The light horizontal
            /// </summary>
            LightHorizontal,
            /// <summary>
            /// The light upward diagonal
            /// </summary>
            LightUpwardDiagonal,
            /// <summary>
            /// The light vertical
            /// </summary>
            LightVertical,
            /// <summary>
            /// The maximum
            /// </summary>
            Max,
            /// <summary>
            /// The minimum
            /// </summary>
            Min,
            /// <summary>
            /// The narrow horizontal
            /// </summary>
            NarrowHorizontal,
            /// <summary>
            /// The narrow vertical
            /// </summary>
            NarrowVertical,
            /// <summary>
            /// The outlined diamond
            /// </summary>
            OutlinedDiamond,
            /// <summary>
            /// The percent05
            /// </summary>
            Percent05,
            /// <summary>
            /// The percent10
            /// </summary>
            Percent10,
            /// <summary>
            /// The percent20
            /// </summary>
            Percent20,
            /// <summary>
            /// The percent25
            /// </summary>
            Percent25,
            /// <summary>
            /// The percent30
            /// </summary>
            Percent30,
            /// <summary>
            /// The percent40
            /// </summary>
            Percent40,
            /// <summary>
            /// The percent50
            /// </summary>
            Percent50,
            /// <summary>
            /// The percent60
            /// </summary>
            Percent60,
            /// <summary>
            /// The percent70
            /// </summary>
            Percent70,
            /// <summary>
            /// The percent75
            /// </summary>
            Percent75,
            /// <summary>
            /// The percent80
            /// </summary>
            Percent80,
            /// <summary>
            /// The percent90
            /// </summary>
            Percent90,
            /// <summary>
            /// The plaid
            /// </summary>
            Plaid,
            /// <summary>
            /// The shingle
            /// </summary>
            Shingle,
            /// <summary>
            /// The small checker board
            /// </summary>
            SmallCheckerBoard,
            /// <summary>
            /// The small confetti
            /// </summary>
            SmallConfetti,
            /// <summary>
            /// The small grid
            /// </summary>
            SmallGrid,
            /// <summary>
            /// The solid diamond
            /// </summary>
            SolidDiamond,
            /// <summary>
            /// The sphere
            /// </summary>
            Sphere,
            /// <summary>
            /// The trellis
            /// </summary>
            Trellis,
            /// <summary>
            /// The vertical
            /// </summary>
            Vertical,
            /// <summary>
            /// The wave
            /// </summary>
            Wave,
            /// <summary>
            /// The weave
            /// </summary>
            Weave,
            /// <summary>
            /// The wide downward diagonal
            /// </summary>
            WideDownwardDiagonal,
            /// <summary>
            /// The wide upward diagonal
            /// </summary>
            WideUpwardDiagonal,
            /// <summary>
            /// The zig zag
            /// </summary>
            ZigZag
        }
        #endregion

        #region HatchBrush Property        
        /// <summary>
        /// Gets or sets the color of the gradient hatch brush.
        /// </summary>
        /// <value>The color1 of the gradient hatch brush.</value>
        public Color ColorHatchBrushgradient1
        {
            get { return hatchBrushgradient1; }
            set
            {
                hatchBrushgradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the gradient hatch brush.
        /// </summary>
        /// <value>The color2 of the gradient hatch brush.</value>
        public Color ColorHatchBrushgradient2
        {
            get { return hatchBrushgradient2; }
            set
            {
                hatchBrushgradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of hatch brush.
        /// </summary>
        /// <value>The type hatch brush.</value>
        public HatchBrushType HatchBrush
        {
            get
            {
                return hatchBrushType;
            }

            set
            {
                hatchBrushType = value;
                Invalidate();
            }
        }
        #endregion


        #region Private Fields
        /// <summary>
        /// The color gradient1
        /// </summary>
        private Color colorGradient1 = Color.FromArgb(26, 26, 26);
        /// <summary>
        /// The color gradient2
        /// </summary>
        private Color colorGradient2 = Color.FromArgb(30, 30, 30);
        /// <summary>
        /// The color gradient3
        /// </summary>
        private Color colorGradient3 = Color.FromArgb(174, 195, 30);
        /// <summary>
        /// The color gradient4
        /// </summary>
        private Color colorGradient4 = Color.FromArgb(141, 153, 16);
        /// <summary>
        /// The color hatch brush1
        /// </summary>
        private Color colorHatchBrush1 = Color.FromArgb(174, 195, 30);
        /// <summary>
        /// The color hatch brush2
        /// </summary>
        private Color colorHatchBrush2 = Color.FromArgb(141, 153, 16);
        /// <summary>
        /// The color pen
        /// </summary>
        private Color colorPen = Color.FromArgb(97, 94, 90);
        /// <summary>
        /// The color gradient angle
        /// </summary>
        private float colorGradientAngle = 90f;


        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The show percentage
        /// </summary>
        private bool _ShowPercentage = false;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;

        #endregion

        #region Properties


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion



        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }
        
        #endregion

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color ColorGradient1
        {
            get { return colorGradient1; }
            set
            {
                colorGradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color ColorGradient2
        {
            get { return colorGradient2; }
            set
            {
                colorGradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color for the value.
        /// </summary>
        /// <value>The gradient color1 for the value.</value>
        public Color ColorGradient1Value
        {
            get { return colorGradient3; }
            set
            {
                colorGradient3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color for the value.
        /// </summary>
        /// <value>The gradient color2 for the value.</value>
        public Color ColorGradient2Value
        {
            get { return colorGradient4; }
            set
            {
                colorGradient4 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the hatch brush.
        /// </summary>
        /// <value>The color1 of the hatch brush.</value>
        public Color ColorHatchBrush1
        {
            get { return colorHatchBrush1; }
            set
            {
                colorHatchBrush1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the hatch brush.
        /// </summary>
        /// <value>The color2 of the hatch brush.</value>
        public Color ColorHatchBrush2
        {
            get { return colorHatchBrush2; }
            set
            {
                colorHatchBrush2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return colorPen; }
            set
            {
                colorPen = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the gradient angle.
        /// </summary>
        /// <value>The color of the gradient angle.</value>
        public float ColorGradientAngle
        {
            get { return colorGradientAngle; }
            set
            {
                colorGradientAngle = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                if (_Value == 0)
                    return 0;
                else return _Value;
            }
            set
            {
                _Value = value;
                if (_Value > _Maximum)
                    _Value = _Maximum;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the percentage.
        /// </summary>
        /// <value><c>true</c> if show percentage; otherwise, <c>false</c>.</value>
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarPerplex" /> class.
        /// </summary>
        public ZeroitProgressBarPerplex()
            : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

            Size = new Size(192, 20);

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            timer.Interval = interval;

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = smoothing;
            G.TextRenderingHint = textrendering;

            double val = (double)_Value / _Maximum;
            int intValue = Convert.ToInt32(val * Width);

            if (intValue < 2)
            {
                intValue = 2;
            }

            G.Clear(BackColor);
            Color C1 = Color.FromArgb(174, 195, 30);
            Color C2 = Color.FromArgb(141, 153, 16);
            Rectangle R1 = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle R2 = new Rectangle(0, 0, intValue - 1, Height - 1);
            Rectangle R3 = new Rectangle(0, 0, intValue - 1, Height - 2);
            GraphicsPath GP1 = Zeroit.Framework.Progress.Draw.RoundRect(R1, 1);
            GraphicsPath GP2 = Zeroit.Framework.Progress.Draw.RoundRect(R2, 2);
            GraphicsPath GP3 = Zeroit.Framework.Progress.Draw.RoundRect(R3, 1);
            //LinearGradientBrush gB = new LinearGradientBrush(R1, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 30, 30), 90);
            LinearGradientBrush gB = new LinearGradientBrush(R1, colorGradient1, colorGradient2, colorGradientAngle);
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 1, Height - 2), colorGradient3, colorGradient4, colorGradientAngle);
            //HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(50, C1), Color.FromArgb(25, C2));
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, colorHatchBrush1, colorHatchBrush2);
            Pen P1 = new Pen(colorPen);


            G.FillPath(gB, GP1);
            G.FillPath(g1, GP3);


            #region HatchBrush Paint
            switch (hatchBrushType)
            {
                case HatchBrushType.BackwardDiagonal:
                    HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB, GP3);
                    break;
                case HatchBrushType.Cross:
                    HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB1, GP3);
                    break;
                case HatchBrushType.DarkDownwardDiagonal:
                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB2, GP3);
                    break;
                case HatchBrushType.DarkHorizontal:
                    HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB3, GP3);
                    break;
                case HatchBrushType.DarkUpwardDiagonal:
                    HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB4, GP3);
                    break;
                case HatchBrushType.DarkVertical:
                    HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB5, GP3);
                    break;
                case HatchBrushType.DashedDownwardDiagonal:
                    HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB6, GP3);
                    break;
                case HatchBrushType.DashedHorizontal:
                    HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB7, GP3);
                    break;
                case HatchBrushType.DashedUpwardDiagonal:
                    HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB8, GP3);
                    break;
                case HatchBrushType.DashedVertical:
                    HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB9, GP3);
                    break;
                case HatchBrushType.DiagonalBrick:
                    HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBA, GP3);
                    break;
                case HatchBrushType.DiagonalCross:
                    HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBB, GP3);
                    break;
                case HatchBrushType.Divot:
                    HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBC, GP3);
                    break;
                case HatchBrushType.DottedDiamond:
                    HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBD, GP3);
                    break;
                case HatchBrushType.DottedGrid:
                    HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBE, GP3);
                    break;
                case HatchBrushType.ForwardDiagonal:
                    HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBF, GP3);
                    break;
                case HatchBrushType.Horizontal:
                    HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBG, GP3);
                    break;
                case HatchBrushType.HorizontalBrick:
                    HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBH, GP3);
                    break;
                case HatchBrushType.LargeCheckerBoard:
                    HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBI, GP3);
                    break;
                case HatchBrushType.LargeConfetti:
                    HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBJ, GP3);
                    break;
                case HatchBrushType.LargeGrid:
                    HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBK, GP3);
                    break;
                case HatchBrushType.LightDownwardDiagonal:
                    HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBL, GP3);
                    break;
                case HatchBrushType.LightHorizontal:
                    HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBM, GP3);
                    break;
                case HatchBrushType.LightUpwardDiagonal:
                    HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBN, GP3);
                    break;
                case HatchBrushType.LightVertical:
                    HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBO, GP3);
                    break;
                case HatchBrushType.Max:
                    HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBP, GP3);
                    break;
                case HatchBrushType.Min:
                    HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBQ, GP3);
                    break;
                case HatchBrushType.NarrowHorizontal:
                    HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBR, GP3);
                    break;
                case HatchBrushType.NarrowVertical:
                    HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBS, GP3);
                    break;
                case HatchBrushType.OutlinedDiamond:
                    HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBT, GP3);
                    break;
                case HatchBrushType.Percent05:
                    HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBU, GP3);
                    break;
                case HatchBrushType.Percent10:
                    HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBV, GP3);
                    break;
                case HatchBrushType.Percent20:
                    HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBW, GP3);
                    break;
                case HatchBrushType.Percent25:
                    HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBX, GP3);
                    break;
                case HatchBrushType.Percent30:
                    HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBY, GP3);
                    break;
                case HatchBrushType.Percent40:
                    HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HBZ, GP3);
                    break;
                case HatchBrushType.Percent50:
                    HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB10, GP3);
                    break;
                case HatchBrushType.Percent60:
                    HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB11, GP3);
                    break;
                case HatchBrushType.Percent70:
                    HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB12, GP3);
                    break;
                case HatchBrushType.Percent75:
                    HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB13, GP3);
                    break;
                case HatchBrushType.Percent80:
                    HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB14, GP3);
                    break;
                case HatchBrushType.Percent90:
                    HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB15, GP3);
                    break;
                case HatchBrushType.Plaid:
                    HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB16, GP3);
                    break;
                case HatchBrushType.Shingle:
                    HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB17, GP3);
                    break;
                case HatchBrushType.SmallCheckerBoard:
                    HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB18, GP3);
                    break;
                case HatchBrushType.SmallConfetti:
                    HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB19, GP3);
                    break;
                case HatchBrushType.SmallGrid:
                    HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB20, GP3);
                    break;
                case HatchBrushType.SolidDiamond:
                    HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB21, GP3);
                    break;
                case HatchBrushType.Sphere:
                    HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB22, GP3);
                    break;
                case HatchBrushType.Trellis:
                    HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB23, GP3);
                    break;
                case HatchBrushType.Vertical:
                    HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB24, GP3);
                    break;
                case HatchBrushType.Wave:
                    HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB25, GP3);
                    break;
                case HatchBrushType.Weave:
                    HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB26, GP3);
                    break;
                case HatchBrushType.WideDownwardDiagonal:
                    HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB27, GP3);
                    break;
                case HatchBrushType.WideUpwardDiagonal:
                    HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB28, GP3);
                    break;
                case HatchBrushType.ZigZag:
                    HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillPath(HB29, GP3);
                    break;
                default:
                    break;
            }
            #endregion


            //G.FillPath(h1, GP3);
            G.DrawPath(P1, GP1);
            //G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), GP2);
            G.DrawPath(new Pen(colorPen), GP2);
            G.DrawPath(P1, GP2);

            if (_ShowPercentage)
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), Font, new SolidBrush(ForeColor), R1, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarPerplexDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarPerplexDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitProgressBarPerplexSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarPerplexSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarPerplexSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarPerplex colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarPerplexSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarPerplexSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarPerplex;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get
            {
                return colUserControl.TextRendering;
            }
            set
            {
                GetPropertyByName("TextRendering").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get
            {
                return colUserControl.AutoAnimate;
            }
            set
            {
                GetPropertyByName("AutoAnimate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color hatch brushgradient1.
        /// </summary>
        /// <value>The color hatch brushgradient1.</value>
        public Color ColorHatchBrushgradient1
        {
            get
            {
                return colUserControl.ColorHatchBrushgradient1;
            }
            set
            {
                GetPropertyByName("ColorHatchBrushgradient1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color hatch brushgradient2.
        /// </summary>
        /// <value>The color hatch brushgradient2.</value>
        public Color ColorHatchBrushgradient2
        {
            get
            {
                return colUserControl.ColorHatchBrushgradient2;
            }
            set
            {
                GetPropertyByName("ColorHatchBrushgradient2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
        public Zeroit.Framework.Progress.ZeroitProgressBarPerplex.HatchBrushType HatchBrush
        {
            get
            {
                return colUserControl.HatchBrush;
            }
            set
            {
                GetPropertyByName("HatchBrush").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color gradient1.
        /// </summary>
        /// <value>The color gradient1.</value>
        public Color ColorGradient1
        {
            get
            {
                return colUserControl.ColorGradient1;
            }
            set
            {
                GetPropertyByName("ColorGradient1").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color gradient2.
        /// </summary>
        /// <value>The color gradient2.</value>
        public Color ColorGradient2
        {
            get
            {
                return colUserControl.ColorGradient2;
            }
            set
            {
                GetPropertyByName("ColorGradient2").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color gradient1 value.
        /// </summary>
        /// <value>The color gradient1 value.</value>
        public Color ColorGradient1Value
        {
            get
            {
                return colUserControl.ColorGradient1Value;
            }
            set
            {
                GetPropertyByName("ColorGradient1Value").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color gradient2 value.
        /// </summary>
        /// <value>The color gradient2 value.</value>
        public Color ColorGradient2Value
        {
            get
            {
                return colUserControl.ColorGradient2Value;
            }
            set
            {
                GetPropertyByName("ColorGradient2Value").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color hatch brush1.
        /// </summary>
        /// <value>The color hatch brush1.</value>
        public Color ColorHatchBrush1
        {
            get
            {
                return colUserControl.ColorHatchBrush1;
            }
            set
            {
                GetPropertyByName("ColorHatchBrush1").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color hatch brush2.
        /// </summary>
        /// <value>The color hatch brush2.</value>
        public Color ColorHatchBrush2
        {
            get
            {
                return colUserControl.ColorHatchBrush2;
            }
            set
            {
                GetPropertyByName("ColorHatchBrush2").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color gradient angle.
        /// </summary>
        /// <value>The color gradient angle.</value>
        public float ColorGradientAngle
        {
            get
            {
                return colUserControl.ColorGradientAngle;
            }
            set
            {
                GetPropertyByName("ColorGradientAngle").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [show percentage].
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        public bool ShowPercentage
        {
            get
            {
                return colUserControl.ShowPercentage;
            }
            set
            {
                GetPropertyByName("ShowPercentage").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Sets the progress to autostart."));

            items.Add(new DesignerActionPropertyItem("ShowPercentage",
                                 "Show Percentage", "Appearance",
                                 "Set if the Percentage text should be displayed."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("TextRendering",
                                 "Text Rendering", "Appearance",
                                 "Sets the text rendering of the control."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the Smoothing mode."));

            items.Add(new DesignerActionPropertyItem("HatchBrush",
                                 "Hatch Brush", "Appearance",
                                 "Sets the hatch brush."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient1",
                                 "Color Hatch Brush gradient1", "Appearance",
                                 "Sets the hatch brush gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient2",
                                 "Color Hatch Brush gradient2", "Appearance",
                                 "Sets the hatch brush gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorGradient1",
                                 "Color Gradient1", "Appearance",
                                 "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorGradient2",
                                 "Color Gradient2", "Appearance",
                                 "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorGradient1Value",
                                 "Color Gradient1Value", "Appearance",
                                 "Sets the value gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorGradient2Value",
                                 "Color Gradient2Value", "Appearance",
                                 "Sets the value gradient color."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrush1",
                                 "Color Hatch Brush1", "Appearance",
                                 "Sets the hatchbrush color."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrush2",
                                 "Color Hatch Brush2", "Appearance",
                                 "Sets the hatchbrush color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the color of the border."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Sets the color of the progress text."));

            items.Add(new DesignerActionPropertyItem("ColorGradientAngle",
                                 "Color GradientAngle", "Appearance",
                                 "Sets the angle of the gradient color."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the progress control."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the progress control."));



            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion
}
