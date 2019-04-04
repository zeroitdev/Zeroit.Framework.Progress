// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressBarClear.cs" company="Zeroit Dev Technologies">
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
using System.Text;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarClear

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ThemeControl154" />
    [Designer(typeof(ZeroitProgressBarClearDesigner))]
    public class ZeroitProgressBarClear : Zeroit.Framework.Progress.ThemeControl154
    {
        #region Private Fields
        /// <summary>
        /// The g1
        /// </summary>
        Color G1;
        /// <summary>
        /// The g2
        /// </summary>
        Color G2;
        /// <summary>
        /// The glow
        /// </summary>
        Color Glow;
        /// <summary>
        /// The edge
        /// </summary>
        Color Edge;

        /// <summary>
        /// The glow
        /// </summary>
        private Color glow = Color.FromArgb(230, 230, 230);
        /// <summary>
        /// The edge
        /// </summary>
        private Color edge = Color.FromArgb(170, 170, 170);
        /// <summary>
        /// The gradient1
        /// </summary>
        private Color gradient1 = Color.FromArgb(230, 230, 230);
        /// <summary>
        /// The gradient2
        /// </summary>
        private Color gradient2 = Color.FromArgb(210, 210, 210);
        /// <summary>
        /// The hatch brushgradient1
        /// </summary>
        private Color hatchBrushgradient1 = Color.Black;
        /// <summary>
        /// The hatch brushgradient2
        /// </summary>
        private Color hatchBrushgradient2 = Color.Transparent;



        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The glow position
        /// </summary>
        int GlowPosition;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchBrushType hatchBrushType = HatchBrushType.ForwardDiagonal;
        /// <summary>
        /// Enum representing a type of Hatch Brush
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

        #region Properties

        /// <summary>
        /// Gets or sets the glow color.
        /// </summary>
        /// <value>The glow color.</value>
        public Color ColorGlow
        {
            get { return glow; }
            set
            {
                glow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color ColorBorder
        {
            get { return edge; }
            set
            {
                edge = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color ColorGradient1
        {
            get { return gradient1; }
            set
            {
                gradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color ColorGradient2
        {
            get { return gradient2; }
            set
            {
                gradient2 = value;
                Invalidate();
            }
        }

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
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="Exception">Property value is not valid.</exception>
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="Exception">Property value is not valid.</exception>
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressBarClear" /> should be animated.
        /// </summary>
        /// <value><c>true</c> if animated; otherwise, <c>false</c>.</value>
        public bool Animated
        {
            get { return IsAnimated; }
            set
            {
                IsAnimated = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="Exception">Property value is not valid.</exception>
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
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

        /// <summary>
        /// Increments the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        private void Increment(int amount)
        {
            Value += amount;


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarClear" /> class.
        /// </summary>
        public ZeroitProgressBarClear()
        {
            SetColor("Gradient 1", gradient1);
            SetColor("Gradient 2", gradient2);
            SetColor("Glow", glow);
            SetColor("Edge", edge);
            IsAnimated = true;

            #region Timer
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion

        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edge");
        }

        /// <summary>
        /// Called when [animation].
        /// </summary>
        protected override void OnAnimation()
        {
            if (GlowPosition == 0)
            {
                GlowPosition = 7;
            }
            else
            {
                GlowPosition -= 1;
            }
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            Graphics B = CreateGraphics();
            G.Clear(G1);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), G1, G2, 90f);
            G.FillRectangle(LGB, new Rectangle(new Point(1, 1), new Size((Value / Maximum) * Width - 1, Height - 2)));
            G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(1, 1), new Size((Value / Maximum) * Width - 1, (Height / 2) - 3)));

            G.RenderingOrigin = new Point(GlowPosition, 0);

            switch (hatchBrushType)
            {
                case HatchBrushType.BackwardDiagonal:
                    HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Cross:
                    HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB1, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DarkDownwardDiagonal:
                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB2, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DarkHorizontal:
                    HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB3, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DarkUpwardDiagonal:
                    HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB4, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DarkVertical:
                    HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB5, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DashedDownwardDiagonal:
                    HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB6, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DashedHorizontal:
                    HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB7, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DashedUpwardDiagonal:
                    HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB8, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DashedVertical:
                    HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB9, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DiagonalBrick:
                    HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBA, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DiagonalCross:
                    HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBB, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Divot:
                    HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBC, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DottedDiamond:
                    HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBD, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.DottedGrid:
                    HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBE, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.ForwardDiagonal:
                    HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBF, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Horizontal:
                    HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBG, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.HorizontalBrick:
                    HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBH, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LargeCheckerBoard:
                    HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBI, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LargeConfetti:
                    HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBJ, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LargeGrid:
                    HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBK, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LightDownwardDiagonal:
                    HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBL, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LightHorizontal:
                    HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBM, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LightUpwardDiagonal:
                    HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBN, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.LightVertical:
                    HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBO, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Max:
                    HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBP, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Min:
                    HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBQ, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.NarrowHorizontal:
                    HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBR, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.NarrowVertical:
                    HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBS, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.OutlinedDiamond:
                    HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBT, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent05:
                    HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBU, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent10:
                    HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBV, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent20:
                    HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBW, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent25:
                    HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBX, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent30:
                    HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBY, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent40:
                    HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HBZ, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent50:
                    HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB10, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent60:
                    HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB11, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent70:
                    HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB12, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent75:
                    HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB13, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent80:
                    HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB14, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Percent90:
                    HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB15, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Plaid:
                    HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB16, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Shingle:
                    HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB17, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.SmallCheckerBoard:
                    HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB18, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.SmallConfetti:
                    HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB19, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.SmallGrid:
                    HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB20, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.SolidDiamond:
                    HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB21, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Sphere:
                    HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB22, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Trellis:
                    HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB23, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Vertical:
                    HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB24, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Wave:
                    HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB25, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.Weave:
                    HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB26, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.WideDownwardDiagonal:
                    HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB27, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.WideUpwardDiagonal:
                    HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB28, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                case HatchBrushType.ZigZag:
                    HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                    G.FillRectangle(HB29, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));
                    break;
                default:
                    break;
            }

            G.DrawLine(new Pen(Edge), new Point((Value / Maximum) * Width - 1, 1), new Point((Value / Maximum) * Width - 1, Height - 1));
            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(1, 1), new Size(Width, Height)));
        }


        #region Include in Private Field


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
        /// Gets or sets a value indicating whether to automatically animate.
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
                Invalidate();
            }
        }

        #endregion

        
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarClearDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarClearDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarClearSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarClearSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarClearSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarClear colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarClearSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarClearSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarClear;

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
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
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
        /// Gets or sets the color glow.
        /// </summary>
        /// <value>The color glow.</value>
        public Color ColorGlow
        {
            get
            {
                return colUserControl.ColorGlow;
            }
            set
            {
                GetPropertyByName("ColorGlow").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
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
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
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
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressBarClearSmartTagActionList"/> is animated.
        /// </summary>
        /// <value><c>true</c> if animated; otherwise, <c>false</c>.</value>
        public bool Animated
        {
            get
            {
                return colUserControl.Animated;
            }
            set
            {
                GetPropertyByName("Animated").SetValue(colUserControl, value);
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
        /// Gets or sets the hatch brush.
        /// </summary>
        /// <value>The hatch brush.</value>
        public Zeroit.Framework.Progress.ZeroitProgressBarClear.HatchBrushType HatchBrush
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ColorGlow",
                                 "Color Glow", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ColorGradient1",
                                 "Color Gradient1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ColorGradient2",
                                 "Color Gradient2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient1",
                                 "Color HatchBrush gradient1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ColorHatchBrushgradient2",
                                 "Color HatchBrush gradient2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Animated",
                                 "Animated", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HatchBrush",
                                 "Hatch Brush", "Appearance",
                                 "Sets the Hatch Brush Type."));


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
