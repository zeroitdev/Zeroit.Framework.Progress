// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ZeroitGorgeous.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a circular progress control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitGorgeous : Control
    {
        #region E N U M S

        /// <summary>
        /// Enum that represents the rotating angle.
        /// </summary>
        public enum RotateAngle
        {
            /// <summary>
            /// The clockwise
            /// </summary>
            Clockwise,
            /// <summary>
            /// The anti clockwise
            /// </summary>
            AntiClockwise
        }

        /// <summary>
        /// Enum that represents the draw mode.
        /// </summary>
        public enum RenderMode
        {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The gradient
            /// </summary>
            Gradient,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch
        }

        /// <summary>
        /// Enum representing the type of easing.
        /// </summary>
        public enum Easing
        {
            /// <summary>
            /// The bounce ease in
            /// </summary>
            BounceEaseIn,
            /// <summary>
            /// The bounce ease in out
            /// </summary>
            BounceEaseInOut,
            /// <summary>
            /// The bounce ease out
            /// </summary>
            BounceEaseOut,
            /// <summary>
            /// The bounce ease out in
            /// </summary>
            BounceEaseOutIn,
            /// <summary>
            /// The circular ease in
            /// </summary>
            CircularEaseIn,
            /// <summary>
            /// The circular ease in out
            /// </summary>
            CircularEaseInOut,
            /// <summary>
            /// The circular ease out
            /// </summary>
            CircularEaseOut,
            /// <summary>
            /// The cubic ease in
            /// </summary>
            CubicEaseIn,
            /// <summary>
            /// The cubic ease in out
            /// </summary>
            CubicEaseInOut,
            /// <summary>
            /// The cubic ease out
            /// </summary>
            CubicEaseOut,
            /// <summary>
            /// The exponential ease in
            /// </summary>
            ExponentialEaseIn,
            /// <summary>
            /// The exponential ease in out
            /// </summary>
            ExponentialEaseInOut,
            /// <summary>
            /// The exponential ease out
            /// </summary>
            ExponentialEaseOut,
            /// <summary>
            /// The liner
            /// </summary>
            Liner,
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The quadratic ease in
            /// </summary>
            QuadraticEaseIn,
            /// <summary>
            /// The quadratic ease in out
            /// </summary>
            QuadraticEaseInOut,
            /// <summary>
            /// The quadratic ease out
            /// </summary>
            QuadraticEaseOut,
            /// <summary>
            /// The quartic ease in
            /// </summary>
            QuarticEaseIn,
            /// <summary>
            /// The quartic ease in out
            /// </summary>
            QuarticEaseInOut,
            /// <summary>
            /// The quartic ease out
            /// </summary>
            QuarticEaseOut,
            /// <summary>
            /// The quintic ease in
            /// </summary>
            QuinticEaseIn,
            /// <summary>
            /// The quintic ease in out
            /// </summary>
            QuinticEaseInOut,
            /// <summary>
            /// The quintic ease out
            /// </summary>
            QuinticEaseOut,
            /// <summary>
            /// The sinusoidal ease in
            /// </summary>
            SinusoidalEaseIn,
            /// <summary>
            /// The sinusoidal ease in out
            /// </summary>
            SinusoidalEaseInOut,
            /// <summary>
            /// The sinusoidal ease out
            /// </summary>
            SinusoidalEaseOut
        }

        /// <summary>
        /// Enum representing the transparent easing function to use.
        /// </summary>
        public enum TransparencyEasing
        {
            /// <summary>
            /// The bounce ease in
            /// </summary>
            BounceEaseIn,
            /// <summary>
            /// The bounce ease in out
            /// </summary>
            BounceEaseInOut,
            /// <summary>
            /// The bounce ease out
            /// </summary>
            BounceEaseOut,
            /// <summary>
            /// The bounce ease out in
            /// </summary>
            BounceEaseOutIn,
            /// <summary>
            /// The circular ease in
            /// </summary>
            CircularEaseIn,
            /// <summary>
            /// The circular ease in out
            /// </summary>
            CircularEaseInOut,
            /// <summary>
            /// The circular ease out
            /// </summary>
            CircularEaseOut,
            /// <summary>
            /// The cubic ease in
            /// </summary>
            CubicEaseIn,
            /// <summary>
            /// The cubic ease in out
            /// </summary>
            CubicEaseInOut,
            /// <summary>
            /// The cubic ease out
            /// </summary>
            CubicEaseOut,
            /// <summary>
            /// The exponential ease in
            /// </summary>
            ExponentialEaseIn,
            /// <summary>
            /// The exponential ease in out
            /// </summary>
            ExponentialEaseInOut,
            /// <summary>
            /// The exponential ease out
            /// </summary>
            ExponentialEaseOut,
            /// <summary>
            /// The liner
            /// </summary>
            Liner,
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The quadratic ease in
            /// </summary>
            QuadraticEaseIn,
            /// <summary>
            /// The quadratic ease in out
            /// </summary>
            QuadraticEaseInOut,
            /// <summary>
            /// The quadratic ease out
            /// </summary>
            QuadraticEaseOut,
            /// <summary>
            /// The quartic ease in
            /// </summary>
            QuarticEaseIn,
            /// <summary>
            /// The quartic ease in out
            /// </summary>
            QuarticEaseInOut,
            /// <summary>
            /// The quartic ease out
            /// </summary>
            QuarticEaseOut,
            /// <summary>
            /// The quintic ease in
            /// </summary>
            QuinticEaseIn,
            /// <summary>
            /// The quintic ease in out
            /// </summary>
            QuinticEaseInOut,
            /// <summary>
            /// The quintic ease out
            /// </summary>
            QuinticEaseOut,
            /// <summary>
            /// The sinusoidal ease in
            /// </summary>
            SinusoidalEaseIn,
            /// <summary>
            /// The sinusoidal ease in out
            /// </summary>
            SinusoidalEaseInOut,
            /// <summary>
            /// The sinusoidal ease out
            /// </summary>
            SinusoidalEaseOut
        }


        #endregion

        #region Private Fields
        /// <summary>
        /// The graphics
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// The value
        /// </summary>
        private float value = 70f;
        /// <summary>
        /// The maximum
        /// </summary>
        private float maximum = 100f;
        /// <summary>
        /// The post fix
        /// </summary>
        private string postFix = "%";
        /// <summary>
        /// The enable inner cover
        /// </summary>
        private bool enableInnerCover = false;

        /// <summary>
        /// The outer shift
        /// </summary>
        private int outerShift = 16;
        /// <summary>
        /// The inner shift
        /// </summary>
        private int innerShift = 26;
        /// <summary>
        /// The inner cover shift
        /// </summary>
        private int innerCoverShift = 32;
        /// <summary>
        /// The small rect shift
        /// </summary>
        private int smallRectShift = 180;

        /// <summary>
        /// The gradient colors
        /// </summary>
        private Color[] gradientColors = new Color[]
        {
            Color.FromArgb(254, 84, 84),
            Color.DarkSlateGray
        };

        /// <summary>
        /// The solidcolors
        /// </summary>
        private Color[] solidcolors = new Color[]
        {
            Color.FromArgb(255,255,255),
            Color.FromArgb(37, 37, 38),
            Color.FromArgb(254, 84, 84),
            Color.FromArgb(37, 37, 38),
            Color.Gray
        };

        /// <summary>
        /// The border
        /// </summary>
        private int border = 10;

        /// <summary>
        /// The starting angle
        /// </summary>
        private float startingAngle = 270f;

        /// <summary>
        /// The automatic increment
        /// </summary>
        private bool autoIncrement = false;

        /// <summary>
        /// The glow
        /// </summary>
        private bool glow = false;

        /// <summary>
        /// The speed
        /// </summary>
        private int[] speed = new int[]
        {
            100,
            100,
            5000
        };

        /// <summary>
        /// The transparency
        /// </summary>
        private int transparency = 255;

        /// <summary>
        /// The show text
        /// </summary>
        public bool showText = true;

        /// <summary>
        /// The rotating angle
        /// </summary>
        private RotateAngle _rotatingAngle = RotateAngle.Clockwise;

        /// <summary>
        /// The draw mode
        /// </summary>
        private RenderMode _drawMode = RenderMode.Solid;

        /// <summary>
        /// The easing type
        /// </summary>
        private Easing _easingType = Easing.BounceEaseIn;

        /// <summary>
        /// The transparency easing type
        /// </summary>
        private TransparencyEasing _transparencyEasingType = TransparencyEasing.BounceEaseIn;



        /// <summary>
        /// The peace animator
        /// </summary>
        Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator peaceAnimator = new Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator();
        /// <summary>
        /// The transparency animator
        /// </summary>
        Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator transparencyAnimator = new Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator();

        #endregion

        #region HatchBrush

        /// <summary>
        /// The hatch brushgradient1
        /// </summary>
        private Color hatchBrushgradient1 = Color.FromArgb(254, 84, 84);
        /// <summary>
        /// The hatch brushgradient2
        /// </summary>
        private Color hatchBrushgradient2 = Color.DeepPink;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchBrushType hatchBrushType = HatchBrushType.ForwardDiagonal;

        /// <summary>
        /// Enum representing the type of Hatch brush to use.
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
        /// Gets or sets the gradient color of the hatch brush.
        /// </summary>
        /// <value>The gradient color1 of the hatch brush.</value>
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
        /// Gets or sets the gradient color of the hatch brush.
        /// </summary>
        /// <value>The gradient color2 of the hatch brush.</value>
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
        /// Gets or sets the type hatch brush.
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
        /// Gets or sets the fill transparency.
        /// </summary>
        /// <value>The fill transparency.</value>
        public int FillTransparency
        {
            get { return transparency; }
            set
            {
                transparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets how the control should be drawn.
        /// </summary>
        /// <value>The draw mode.</value>
        public RenderMode DrawMode
        {
            get { return _drawMode; }
            set
            {
                _drawMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the easing.
        /// </summary>
        /// <value>The type of the easing.</value>
        public Easing EasingType
        {
            get { return _easingType; }
            set
            {
                _easingType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotating angle.
        /// </summary>
        /// <value>The rotating angle.</value>
        public RotateAngle RotatingAngle
        {
            get { return _rotatingAngle; }
            set
            {
                _rotatingAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transparent easing.
        /// </summary>
        /// <value>The transparent easing.</value>
        public TransparencyEasing TransparentEasing
        {
            get { return _transparencyEasingType; }
            set
            {
                _transparencyEasingType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the solid colors used in the control.
        /// </summary>
        /// <value>The solid colors.</value>
        public Color[] SolidColors
        {
            get { return solidcolors; }
            set
            {
                solidcolors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient colors used in the control.
        /// </summary>
        /// <value>The gradient colors.</value>
        public Color[] GradientColor
        {
            get { return gradientColors; }
            set
            {
                gradientColors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public int Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the inner cover.
        /// </summary>
        /// <value><c>true</c> if enable inner cover; otherwise, <c>false</c>.</value>
        public bool EnableInnerCover
        {
            get { return enableInnerCover; }
            set
            {
                enableInnerCover = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value for the outer shift.
        /// </summary>
        /// <value>The outer shift.</value>
        public int ShiftOuter
        {
            get { return outerShift; }
            set
            {
                outerShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value for the inner shift.
        /// </summary>
        /// <value>The inner shift.</value>
        public int ShiftInner
        {
            get { return innerShift; }
            set
            {
                innerShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value for the inner cover shift.
        /// </summary>
        /// <value>The inner cover shift.</value>
        public int ShiftInnerCover
        {
            get { return innerCoverShift; }
            set
            {
                innerCoverShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shift value for the small rectangle.
        /// </summary>
        /// <value>The small rectangle's.</value>
        public int ShiftSmallRect
        {
            get { return smallRectShift; }
            set
            {
                smallRectShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the post fix text. Default is %.
        /// </summary>
        /// <value>The post fix text.</value>
        public string PostFix
        {
            get { return postFix; }
            set
            {
                postFix = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets initial the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get { return value; }
            set
            {
                this.value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public float Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable easing animation.
        /// </summary>
        /// <value><c>true</c> if automatic increment; otherwise, <c>false</c>.</value>
        public bool AutoIncrement
        {
            get { return autoIncrement; }
            set
            {

                if (value == true)
                {

                    peaceAnimator.Start();
                }

                else
                {
                    peaceAnimator.Stop();
                }

                autoIncrement = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGorgeous" /> glows.
        /// </summary>
        /// <value><c>true</c> if glow; otherwise, <c>false</c>.</value>
        public bool Glow
        {
            get { return glow; }
            set
            {

                if (value == true)
                {

                    transparencyAnimator.Start();
                }

                else
                {
                    transparencyAnimator.Stop();
                    
                }

                glow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int[] AnimationSpeed
        {
            get { return speed; }
            set
            {
                for (int i = 0; i <= 1; i++)
                    if (value[0] < 1)
                    {
                        value[0] = 1;
                    }

                if (value[1] < 1)
                {
                    value[1] = 1;
                }

                speed = value;
                Invalidate();
            }
        }


        #region Animation Code


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


        #region Include in Private Field


        /// <summary>
        /// The automatic animate stating angle
        /// </summary>
        private bool autoAnimateStatingAngle = false;
        /// <summary>
        /// The timer starting angle
        /// </summary>
        private System.Windows.Forms.Timer timerStartingAngle = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate the start angle].
        /// </summary>
        /// <value><c>true</c> if animate start angle; otherwise, <c>false</c>.</value>
        public bool AnimateStartAngle
        {
            get { return autoAnimateStatingAngle; }
            set
            {
                autoAnimateStatingAngle = value;

                if (value == true)
                {
                    timerStartingAngle.Enabled = true;
                }

                else
                {
                    timerStartingAngle.Enabled = false;
                }

                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the StartAngle event of the Timer_Tick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick_StartAngle(object sender, EventArgs e)
        {
            if (this.startingAngle + 1 > 360)
            {
                this.startingAngle = 0;
            }

            else
            {
                this.startingAngle++;
                Invalidate();
            }
        }

        #endregion



        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGorgeous" /> class.
        /// </summary>
        public ZeroitGorgeous()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.SupportsTransparentBackColor, true);


            #region AutoAnimate
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

            #region AutoIncrement Animation

            peaceAnimator.Control = this;
            peaceAnimator.DurationValue = (ulong)speed[2];
            peaceAnimator.Repeat = true;
            peaceAnimator.Reverse = true;
            peaceAnimator.OneDProperty = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Animator.KnownProperties.Value;
            peaceAnimator.StartValue = 0;
            peaceAnimator.EndValue = maximum;


            #endregion

            #region Glow Animation

            transparencyAnimator.Control = this;
            transparencyAnimator.DurationValue = (ulong)speed[2];
            transparencyAnimator.Repeat = true;
            transparencyAnimator.Reverse = true;
            transparencyAnimator.OneDProperty = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Animator.KnownProperties.Custom;
            transparencyAnimator.StartValue = 0;
            transparencyAnimator.EndValue = 255;
            transparencyAnimator.PropertyName = "FillTransparency";
            transparencyAnimator.DurationValue = 1000;


            #endregion


            #region StartingAngle Animation
            if (DesignMode)
            {
                timerStartingAngle.Tick += Timer_Tick_StartAngle;
                if (AnimateStartAngle)
                {
                    //timerStartingAngle.Interval = 100;
                    timerStartingAngle.Start();
                }
            }

            if (!DesignMode)
            {
                timerStartingAngle.Tick += Timer_Tick_StartAngle;

                if (AnimateStartAngle)
                {
                    //timerStartingAngle.Interval = 100;
                    timerStartingAngle.Start();
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
            base.OnPaint(e);

            timerStartingAngle.Interval = speed[1];
            timer.Interval = speed[0];

            

            switch (_easingType)
            {
                case Easing.BounceEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseIn;

                    break;
                case Easing.BounceEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseInOut;

                    break;
                case Easing.BounceEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOut;

                    break;
                case Easing.BounceEaseOutIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOutIn;

                    break;
                case Easing.CircularEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseIn;

                    break;
                case Easing.CircularEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseInOut;

                    break;
                case Easing.CircularEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseOut;

                    break;
                case Easing.CubicEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseIn;

                    break;
                case Easing.CubicEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseInOut;

                    break;
                case Easing.CubicEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseOut;

                    break;
                case Easing.ExponentialEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseIn;

                    break;
                case Easing.ExponentialEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseInOut;

                    break;
                case Easing.ExponentialEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseOut;

                    break;
                case Easing.Liner:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.Liner;

                    break;
                case Easing.None:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.None;

                    break;
                case Easing.QuadraticEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseIn;

                    break;
                case Easing.QuadraticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseInOut;

                    break;
                case Easing.QuadraticEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseOut;

                    break;
                case Easing.QuarticEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseIn;

                    break;
                case Easing.QuarticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseInOut;

                    break;
                case Easing.QuarticEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseOut;

                    break;
                case Easing.QuinticEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseIn;

                    break;
                case Easing.QuinticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseInOut;

                    break;
                case Easing.QuinticEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseOut;

                    break;
                case Easing.SinusoidalEaseIn:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseIn;

                    break;
                case Easing.SinusoidalEaseInOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseInOut;

                    break;
                case Easing.SinusoidalEaseOut:
                    peaceAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseOut;

                    break;
                default:
                    break;
            }

            switch (_transparencyEasingType)
            {
                case TransparencyEasing.BounceEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseIn;

                    break;
                case TransparencyEasing.BounceEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseInOut;

                    break;
                case TransparencyEasing.BounceEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOut;

                    break;
                case TransparencyEasing.BounceEaseOutIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOutIn;

                    break;
                case TransparencyEasing.CircularEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseIn;

                    break;
                case TransparencyEasing.CircularEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseInOut;

                    break;
                case TransparencyEasing.CircularEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseOut;

                    break;
                case TransparencyEasing.CubicEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseIn;

                    break;
                case TransparencyEasing.CubicEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseInOut;

                    break;
                case TransparencyEasing.CubicEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseOut;

                    break;
                case TransparencyEasing.ExponentialEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseIn;

                    break;
                case TransparencyEasing.ExponentialEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseInOut;

                    break;
                case TransparencyEasing.ExponentialEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseOut;

                    break;
                case TransparencyEasing.Liner:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.Liner;

                    break;
                case TransparencyEasing.None:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.None;

                    break;
                case TransparencyEasing.QuadraticEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseIn;

                    break;
                case TransparencyEasing.QuadraticEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseInOut;

                    break;
                case TransparencyEasing.QuadraticEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseOut;

                    break;
                case TransparencyEasing.QuarticEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseIn;

                    break;
                case TransparencyEasing.QuarticEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseInOut;

                    break;
                case TransparencyEasing.QuarticEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseOut;

                    break;
                case TransparencyEasing.QuinticEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseIn;

                    break;
                case TransparencyEasing.QuinticEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseInOut;

                    break;
                case TransparencyEasing.QuinticEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseOut;

                    break;
                case TransparencyEasing.SinusoidalEaseIn:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseIn;

                    break;
                case TransparencyEasing.SinusoidalEaseInOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseInOut;

                    break;
                case TransparencyEasing.SinusoidalEaseOut:
                    transparencyAnimator.OneD_Path_Easing = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseOut;

                    break;
                default:
                    break;
            }

            graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            ForeColor = Color.White;
            Font = new Font("Century Gothic", 12); 

            Rectangle region = new Rectangle(outerShift/2, outerShift/2, Width - outerShift, Height - outerShift);
            Rectangle region1 = new Rectangle(innerShift/2, innerShift/2, Width - innerShift, Height - innerShift);
            Rectangle region2 = new Rectangle(smallRectShift/2, smallRectShift/2, Width - smallRectShift, Height - smallRectShift);
            Rectangle region3 = new Rectangle(innerCoverShift / 2, innerCoverShift / 2, Width - innerCoverShift, Height - innerCoverShift);

            graphics.FillEllipse(new SolidBrush(solidcolors[0]), region);
            graphics.DrawEllipse(new Pen(solidcolors[1], border), region);

            switch (_drawMode)
            {
                case RenderMode.Solid:
                    switch (_rotatingAngle)
                    {
                        case RotateAngle.Clockwise:
                            graphics.FillPie(new SolidBrush(Color.FromArgb(transparency,solidcolors[2])), region1, startingAngle, (value / maximum) * 360f);
                            break;
                        case RotateAngle.AntiClockwise:
                            graphics.FillPie(new SolidBrush(Color.FromArgb(transparency, solidcolors[2])), region1, startingAngle, (value / maximum) * -360f);
                            break;
                        default:
                            break;
                    }
                    
                    break;
                case RenderMode.Gradient:
                    LinearGradientBrush linbrush = new LinearGradientBrush(region1, Color.FromArgb(transparency,gradientColors[0]), Color.FromArgb(transparency, gradientColors[1]), 90f);

                    switch (_rotatingAngle)
                    {
                        case RotateAngle.Clockwise:
                            graphics.FillPie(linbrush, region1, startingAngle, (value / maximum) * 360f);

                            break;
                        case RotateAngle.AntiClockwise:
                            graphics.FillPie(linbrush, region1, startingAngle, (value / maximum) * -360f);

                            break;
                        default:
                            break;
                    }
                    
                    break;
                case RenderMode.Hatch:

                    switch (_rotatingAngle)
                    {
                        case RotateAngle.Clockwise:
                            #region HatchBrush Paint
                            switch (hatchBrushType)
                            {
                                case HatchBrushType.BackwardDiagonal:
                                    HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Cross:
                                    HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB1, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DarkDownwardDiagonal:
                                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB2, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DarkHorizontal:
                                    HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB3, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DarkUpwardDiagonal:
                                    HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB4, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DarkVertical:
                                    HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB5, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DashedDownwardDiagonal:
                                    HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB6, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DashedHorizontal:
                                    HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB7, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DashedUpwardDiagonal:
                                    HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB8, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DashedVertical:
                                    HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB9, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DiagonalBrick:
                                    HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBA, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DiagonalCross:
                                    HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBB, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Divot:
                                    HatchBrush HBC = new HatchBrush(HatchStyle.Divot, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBC, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DottedDiamond:
                                    HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBD, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.DottedGrid:
                                    HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBE, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.ForwardDiagonal:
                                    HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBF, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Horizontal:
                                    HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBG, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.HorizontalBrick:
                                    HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBH, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LargeCheckerBoard:
                                    HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBI, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LargeConfetti:
                                    HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBJ, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LargeGrid:
                                    HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBK, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LightDownwardDiagonal:
                                    HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBL, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LightHorizontal:
                                    HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBM, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LightUpwardDiagonal:
                                    HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBN, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.LightVertical:
                                    HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBO, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Max:
                                    HatchBrush HBP = new HatchBrush(HatchStyle.Max, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBP, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Min:
                                    HatchBrush HBQ = new HatchBrush(HatchStyle.Min, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBQ, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.NarrowHorizontal:
                                    HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBR, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.NarrowVertical:
                                    HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBS, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.OutlinedDiamond:
                                    HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBT, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent05:
                                    HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBU, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent10:
                                    HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBV, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent20:
                                    HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBW, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent25:
                                    HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBX, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent30:
                                    HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBY, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent40:
                                    HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBZ, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent50:
                                    HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB10, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent60:
                                    HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB11, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent70:
                                    HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB12, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent75:
                                    HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB13, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent80:
                                    HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB14, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Percent90:
                                    HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB15, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Plaid:
                                    HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB16, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Shingle:
                                    HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB17, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.SmallCheckerBoard:
                                    HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB18, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.SmallConfetti:
                                    HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB19, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.SmallGrid:
                                    HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB20, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.SolidDiamond:
                                    HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB21, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Sphere:
                                    HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB22, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Trellis:
                                    HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB23, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Vertical:
                                    HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB24, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Wave:
                                    HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB25, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.Weave:
                                    HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB26, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.WideDownwardDiagonal:
                                    HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB27, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.WideUpwardDiagonal:
                                    HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB28, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                case HatchBrushType.ZigZag:
                                    HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB29, region1, startingAngle, (value / maximum) * 360f);
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                            break;
                        case RotateAngle.AntiClockwise:
                            #region HatchBrush Paint
                            switch (hatchBrushType)
                            {
                                case HatchBrushType.BackwardDiagonal:
                                    HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Cross:
                                    HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB1, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DarkDownwardDiagonal:
                                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB2, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DarkHorizontal:
                                    HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB3, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DarkUpwardDiagonal:
                                    HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB4, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DarkVertical:
                                    HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB5, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DashedDownwardDiagonal:
                                    HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB6, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DashedHorizontal:
                                    HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB7, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DashedUpwardDiagonal:
                                    HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB8, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DashedVertical:
                                    HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB9, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DiagonalBrick:
                                    HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBA, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DiagonalCross:
                                    HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBB, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Divot:
                                    HatchBrush HBC = new HatchBrush(HatchStyle.Divot, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBC, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DottedDiamond:
                                    HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBD, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.DottedGrid:
                                    HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBE, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.ForwardDiagonal:
                                    HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBF, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Horizontal:
                                    HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBG, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.HorizontalBrick:
                                    HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBH, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LargeCheckerBoard:
                                    HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBI, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LargeConfetti:
                                    HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBJ, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LargeGrid:
                                    HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBK, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LightDownwardDiagonal:
                                    HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBL, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LightHorizontal:
                                    HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBM, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LightUpwardDiagonal:
                                    HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBN, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.LightVertical:
                                    HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBO, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Max:
                                    HatchBrush HBP = new HatchBrush(HatchStyle.Max, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBP, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Min:
                                    HatchBrush HBQ = new HatchBrush(HatchStyle.Min, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBQ, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.NarrowHorizontal:
                                    HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBR, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.NarrowVertical:
                                    HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBS, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.OutlinedDiamond:
                                    HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBT, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent05:
                                    HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBU, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent10:
                                    HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBV, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent20:
                                    HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBW, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent25:
                                    HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBX, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent30:
                                    HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBY, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent40:
                                    HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HBZ, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent50:
                                    HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB10, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent60:
                                    HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB11, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent70:
                                    HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB12, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent75:
                                    HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB13, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent80:
                                    HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB14, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Percent90:
                                    HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB15, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Plaid:
                                    HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB16, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Shingle:
                                    HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB17, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.SmallCheckerBoard:
                                    HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB18, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.SmallConfetti:
                                    HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB19, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.SmallGrid:
                                    HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB20, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.SolidDiamond:
                                    HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB21, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Sphere:
                                    HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB22, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Trellis:
                                    HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB23, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Vertical:
                                    HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB24, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Wave:
                                    HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB25, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.Weave:
                                    HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB26, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.WideDownwardDiagonal:
                                    HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB27, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.WideUpwardDiagonal:
                                    HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB28, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                case HatchBrushType.ZigZag:
                                    HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, Color.FromArgb(transparency, hatchBrushgradient1), Color.FromArgb(transparency, hatchBrushgradient2));
                                    graphics.FillPie(HB29, region1, startingAngle, (value / maximum) * -360f);
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                    
                    break;
                default:
                    break;
            }

            if(enableInnerCover)
            {
                graphics.FillEllipse(new SolidBrush(solidcolors[4]), region3);

            }

            graphics.FillEllipse(new SolidBrush(solidcolors[3]), region2);

            if(showText)
            {
                graphics.DrawString(((int)Value).ToString() + " " + postFix, Font, new SolidBrush(ForeColor), (Width / 2) - Font.Size, (Height / 2) - Font.Size);
            }

        }
    }
}