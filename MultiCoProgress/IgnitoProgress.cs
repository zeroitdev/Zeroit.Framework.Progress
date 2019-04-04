// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-25-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="ZeroitIgnitoProgress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    /// <summary>
    /// A class collection for rendering circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitIgnitoProgress : Control
    {

        #region Enumerations        
        /// <summary>
        /// Enum representing the way to paint the control.
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
            Gradient
        }

        /// <summary>
        /// Enum representing the inner rotating angle.
        /// </summary>
        public enum InRotateAngle
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
        /// Enum representing the inner rotating angle.
        /// </summary>
        public enum OutRotateAngle
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
        /// Enum representing the easing function to use.
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

        #endregion

        #region Private Fields

        /// <summary>
        /// The starting angle
        /// </summary>
        private float startingAngle = 270f;

        /// <summary>
        /// The automatic increment
        /// </summary>
        private bool autoIncrement = false;

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
        /// The value
        /// </summary>
        private float value = 0;

        /// <summary>
        /// The maximum
        /// </summary>
        private float maximum = 100;

        /// <summary>
        /// The outerborder
        /// </summary>
        private float outerborder = 1;

        /// <summary>
        /// The innerborder
        /// </summary>
        private float innerborder = 1;

        /// <summary>
        /// The colors
        /// </summary>
        Color[] colors = new Color[]
        {
            Color.Orange,
            Color.FromArgb(152, 212, 204),
            Color.Gray,
            Color.Black,
            Color.DarkSlateGray,
            Color.LightGray,
            Color.DimGray,
            Color.Black,
            Color.Green,
            Color.LightGray,
            Color.Gray,
            Color.LightGray,
        };

        /// <summary>
        /// The enable hatch
        /// </summary>
        private bool enableHatch = false;

        /// <summary>
        /// The cap
        /// </summary>
        private LineCap cap = LineCap.Round;

        /// <summary>
        /// The inner rotating angle
        /// </summary>
        private InRotateAngle _innerRotatingAngle = InRotateAngle.AntiClockwise;

        /// <summary>
        /// The outter rotating angle
        /// </summary>
        private OutRotateAngle _outterRotatingAngle = OutRotateAngle.Clockwise;

        /// <summary>
        /// The draw mode
        /// </summary>
        private RenderMode _drawMode = RenderMode.Solid;

        /// <summary>
        /// The easing type
        /// </summary>
        private Easing _easingType = Easing.BounceEaseIn;

        /// <summary>
        /// The border styleouter
        /// </summary>
        private DashStyle borderStyleouter = DashStyle.DashDot;

        /// <summary>
        /// The border style inner
        /// </summary>
        private DashStyle borderStyleInner = DashStyle.DashDot;


        /// <summary>
        /// The peace animator
        /// </summary>
        Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator peaceAnimator = new Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.PeaceAnimator();


        #endregion

        #region Public Properties

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
        /// Enum representing the type of hatch brush to use.
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
        /// Gets or sets the hatch brush to use.
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
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int[] AnimationSpeed
        {
            get { return speed; }
            set
            {
                for(int i = 0; i <=1; i++)
                if( value[0] < 1)
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

        /// <summary>
        /// Gets or sets the starting angle.
        /// </summary>
        /// <value>The starting angle.</value>
        public float StartingAngle
        {
            get { return startingAngle; }
            set
            {
                startingAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner rotating anlge.
        /// </summary>
        /// <value>The inner rotating anlge.</value>
        public InRotateAngle InnerRotatingAnlge
        {
            get { return _innerRotatingAngle; }
            set
            {
                _innerRotatingAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outter rotating angle.
        /// </summary>
        /// <value>The outter rotating angle.</value>
        public OutRotateAngle OutterRotatingAngle
        {
            get { return _outterRotatingAngle; }
            set
            {
                _outterRotatingAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border.
        /// </summary>
        /// <value>The outer border.</value>
        public float OuterBorder
        {
            get { return outerborder; }
            set
            {
                outerborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public float InnerBorder
        {
            get { return innerborder;}
            set
            {
                innerborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the line caps.
        /// </summary>
        /// <value>The caps.</value>
        public LineCap Caps
        {
            get { return cap; }
            set
            {
                cap = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border style.
        /// </summary>
        /// <value>The outer border style.</value>
        public DashStyle BorderStyleOuter
        {
            get { return borderStyleouter; }
            set
            {
                borderStyleouter = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border style.
        /// </summary>
        /// <value>The inner border style.</value>
        public DashStyle BorderStyleInner
        {
            get { return borderStyleInner; }
            set
            {
                borderStyleInner = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the colors used in this control.
        /// </summary>
        /// <value>The colors.</value>
        public Color [] Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable hatch drawing.
        /// </summary>
        /// <value><c>true</c> if enable hatch; otherwise, <c>false</c>.</value>
        public bool EnableHatch
        {
            get { return enableHatch; }
            set
            {
                enableHatch = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate the progress with easing functionalities.
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
        /// Gets or sets the draw mode.
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get { return this.value; }
            set
            {

                this.value = value;
                Invalidate();
            }
        }

        #endregion

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
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
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
        /// Gets or sets a value indicating whether [animate start angle].
        /// </summary>
        /// <value><c>true</c> if [animate start angle]; otherwise, <c>false</c>.</value>
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

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitIgnitoProgress" /> class.
        /// </summary>
        public ZeroitIgnitoProgress()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

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
            peaceAnimator.EndValue = 100;


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


        #endregion

        #region Paint Event Arguments

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            timerStartingAngle.Interval = speed[1];
            timer.Interval = speed[0];

            Graphics G = e.Graphics;
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

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


            Rectangle circRect = new Rectangle(2, 2, Width - 5, Height - 5);
            Pen outera = new Pen(colors[0], 10);
            outera.EndCap = cap;
            outera.DashStyle = borderStyleouter;

            Pen outerb = new Pen(colors[1], 10);
            outerb.EndCap = cap;
            outerb.DashStyle = borderStyleInner;

            Pen outergradienta = new Pen(new LinearGradientBrush(new Rectangle(10, 10, Width - 20, Height - 20), Color.AliceBlue, Color.Azure, 90f), 10);
            Pen outergradientb = new Pen(new LinearGradientBrush(new Rectangle(45, 45, Width - 90, Height - 90), Color.GreenYellow, Color.Orange, 90f), 15);

            g.FillEllipse(new SolidBrush(colors[2]), circRect);
            g.DrawEllipse(new Pen(colors[3], outerborder), circRect);

            
            switch (_drawMode)
            {
                case RenderMode.Solid:
                    switch (_outterRotatingAngle)
                    {
                        case OutRotateAngle.Clockwise:
                            g.FillPie(new SolidBrush(colors[4]), new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * 360f);

                            g.DrawPie(outera, new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * 360f);

                            break;
                        case OutRotateAngle.AntiClockwise:
                            g.FillPie(new SolidBrush(colors[4]), new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * -360f);

                            g.DrawPie(outera, new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * -360f);

                            break;
                        default:
                            break;
                    }
                    break;
                case RenderMode.Gradient:
                    switch (_outterRotatingAngle)
                    {
                        case OutRotateAngle.Clockwise:
                            g.FillPie(new SolidBrush(colors[4]), new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * 360f);

                            g.DrawPie(outergradienta, new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * 360f);

                            break;
                        case OutRotateAngle.AntiClockwise:
                            g.FillPie(new SolidBrush(colors[4]), new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * -360f);

                            g.DrawPie(outergradienta, new Rectangle(10, 10, Width - 20, Height - 20), startingAngle, (this.value / 100) * -360f);

                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }


            if(enableHatch)
            {
                #region HatchBrush Paint
                switch (hatchBrushType)
                {
                    case HatchBrushType.BackwardDiagonal:
                        HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Cross:
                        HatchBrush HB1 = new HatchBrush(HatchStyle.Cross, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB1, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DarkDownwardDiagonal:
                        HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB2, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DarkHorizontal:
                        HatchBrush HB3 = new HatchBrush(HatchStyle.DarkHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB3, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DarkUpwardDiagonal:
                        HatchBrush HB4 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB4, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DarkVertical:
                        HatchBrush HB5 = new HatchBrush(HatchStyle.DarkVertical, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB5, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DashedDownwardDiagonal:
                        HatchBrush HB6 = new HatchBrush(HatchStyle.DashedDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB6, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DashedHorizontal:
                        HatchBrush HB7 = new HatchBrush(HatchStyle.DashedHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB7, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DashedUpwardDiagonal:
                        HatchBrush HB8 = new HatchBrush(HatchStyle.DashedUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB8, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DashedVertical:
                        HatchBrush HB9 = new HatchBrush(HatchStyle.DashedVertical, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB9, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DiagonalBrick:
                        HatchBrush HBA = new HatchBrush(HatchStyle.DiagonalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBA, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DiagonalCross:
                        HatchBrush HBB = new HatchBrush(HatchStyle.DiagonalCross, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBB, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Divot:
                        HatchBrush HBC = new HatchBrush(HatchStyle.Divot, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBC, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DottedDiamond:
                        HatchBrush HBD = new HatchBrush(HatchStyle.DottedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBD, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.DottedGrid:
                        HatchBrush HBE = new HatchBrush(HatchStyle.DottedGrid, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBE, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.ForwardDiagonal:
                        HatchBrush HBF = new HatchBrush(HatchStyle.ForwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBF, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Horizontal:
                        HatchBrush HBG = new HatchBrush(HatchStyle.Horizontal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBG, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.HorizontalBrick:
                        HatchBrush HBH = new HatchBrush(HatchStyle.HorizontalBrick, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBH, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LargeCheckerBoard:
                        HatchBrush HBI = new HatchBrush(HatchStyle.LargeCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBI, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LargeConfetti:
                        HatchBrush HBJ = new HatchBrush(HatchStyle.LargeConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBJ, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LargeGrid:
                        HatchBrush HBK = new HatchBrush(HatchStyle.LargeGrid, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBK, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LightDownwardDiagonal:
                        HatchBrush HBL = new HatchBrush(HatchStyle.LightDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBL, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LightHorizontal:
                        HatchBrush HBM = new HatchBrush(HatchStyle.LightHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBM, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LightUpwardDiagonal:
                        HatchBrush HBN = new HatchBrush(HatchStyle.LightUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBN, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.LightVertical:
                        HatchBrush HBO = new HatchBrush(HatchStyle.LightVertical, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBO, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Max:
                        HatchBrush HBP = new HatchBrush(HatchStyle.Max, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBP, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Min:
                        HatchBrush HBQ = new HatchBrush(HatchStyle.Min, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBQ, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.NarrowHorizontal:
                        HatchBrush HBR = new HatchBrush(HatchStyle.NarrowHorizontal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBR, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.NarrowVertical:
                        HatchBrush HBS = new HatchBrush(HatchStyle.NarrowVertical, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBS, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.OutlinedDiamond:
                        HatchBrush HBT = new HatchBrush(HatchStyle.OutlinedDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBT, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent05:
                        HatchBrush HBU = new HatchBrush(HatchStyle.Percent05, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBU, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent10:
                        HatchBrush HBV = new HatchBrush(HatchStyle.Percent10, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBV, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent20:
                        HatchBrush HBW = new HatchBrush(HatchStyle.Percent20, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBW, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent25:
                        HatchBrush HBX = new HatchBrush(HatchStyle.Percent25, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBX, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent30:
                        HatchBrush HBY = new HatchBrush(HatchStyle.Percent30, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBY, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent40:
                        HatchBrush HBZ = new HatchBrush(HatchStyle.Percent40, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HBZ, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent50:
                        HatchBrush HB10 = new HatchBrush(HatchStyle.Percent50, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB10, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent60:
                        HatchBrush HB11 = new HatchBrush(HatchStyle.Percent60, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB11, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent70:
                        HatchBrush HB12 = new HatchBrush(HatchStyle.Percent70, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB12, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent75:
                        HatchBrush HB13 = new HatchBrush(HatchStyle.Percent75, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB13, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent80:
                        HatchBrush HB14 = new HatchBrush(HatchStyle.Percent80, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB14, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Percent90:
                        HatchBrush HB15 = new HatchBrush(HatchStyle.Percent90, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB15, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Plaid:
                        HatchBrush HB16 = new HatchBrush(HatchStyle.Plaid, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB16, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Shingle:
                        HatchBrush HB17 = new HatchBrush(HatchStyle.Shingle, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB17, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.SmallCheckerBoard:
                        HatchBrush HB18 = new HatchBrush(HatchStyle.SmallCheckerBoard, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB18, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.SmallConfetti:
                        HatchBrush HB19 = new HatchBrush(HatchStyle.SmallConfetti, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB19, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.SmallGrid:
                        HatchBrush HB20 = new HatchBrush(HatchStyle.SmallGrid, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB20, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.SolidDiamond:
                        HatchBrush HB21 = new HatchBrush(HatchStyle.SolidDiamond, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB21, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Sphere:
                        HatchBrush HB22 = new HatchBrush(HatchStyle.Sphere, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB22, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Trellis:
                        HatchBrush HB23 = new HatchBrush(HatchStyle.Trellis, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB23, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Vertical:
                        HatchBrush HB24 = new HatchBrush(HatchStyle.Vertical, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB24, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Wave:
                        HatchBrush HB25 = new HatchBrush(HatchStyle.Wave, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB25, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.Weave:
                        HatchBrush HB26 = new HatchBrush(HatchStyle.Weave, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB26, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.WideDownwardDiagonal:
                        HatchBrush HB27 = new HatchBrush(HatchStyle.WideDownwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB27, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.WideUpwardDiagonal:
                        HatchBrush HB28 = new HatchBrush(HatchStyle.WideUpwardDiagonal, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB28, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    case HatchBrushType.ZigZag:
                        HatchBrush HB29 = new HatchBrush(HatchStyle.ZigZag, hatchBrushgradient1, hatchBrushgradient2);
                        g.FillEllipse(HB29, new Rectangle(15, 15, Width - 30, Height - 30));
                        break;
                    default:
                        break;
                }
                #endregion
            }

            else
            {
                g.FillEllipse(new SolidBrush(Color.LightGray), new Rectangle(15, 15, Width - 30, Height - 30));
            }
            g.DrawEllipse(new Pen(colors[5], 3), new Rectangle(15, 15, Width - 30, Height - 30));

            g.FillEllipse(new SolidBrush(colors[6]), new Rectangle(30, 30, Width - 60, Height - 60));
            g.DrawEllipse(new Pen(colors[7], innerborder), new Rectangle(30, 30, Width - 60, Height - 60));

            g.FillPie(new SolidBrush(colors[8]), new Rectangle(50, 50, Width - 100, Height - 100), 270f, /*(this.value / 100)*/ -360f);

            switch (_drawMode)
            {
                case RenderMode.Solid:

                    switch (_innerRotatingAngle)
                    {
                        case InRotateAngle.Clockwise:
                            g.DrawPie(outerb, new Rectangle(45, 45, Width - 90, Height - 90), startingAngle, (this.value / 100) * 360f);

                            break;
                        case InRotateAngle.AntiClockwise:
                            g.DrawPie(outerb, new Rectangle(45, 45, Width - 90, Height - 90), startingAngle, (this.value / 100) * -360f);

                            break;
                        default:
                            break;
                    }

                    
                    break;
                case RenderMode.Gradient:
                    switch (_innerRotatingAngle)
                    {
                        case InRotateAngle.Clockwise:
                            g.DrawPie(outergradientb, new Rectangle(45, 45, Width - 90, Height - 90), startingAngle, (this.value / 100) * 360f);

                            break;
                        case InRotateAngle.AntiClockwise:
                            g.DrawPie(outergradientb, new Rectangle(45, 45, Width - 90, Height - 90), startingAngle, (this.value / 100) * -360f);

                            break;
                        default:
                            break;
                    }
                    
                    break;
                default:
                    break;
            }

            g.FillPie(new SolidBrush(colors[9]), new Rectangle(50, 50, Width - 100, Height - 100), 270f, /*(this.value / 100) **/ -360f);
            g.DrawPie(new Pen(colors[10], 5), new Rectangle(55, 55, Width - 110, Height - 110), 270f, -360f);

            g.FillEllipse(new SolidBrush(colors[11]), new Rectangle(55, 55, Width - 110, Height - 110));

            g.DrawString(((int)Value).ToString() + " %", Font, new SolidBrush(ForeColor), (Width / 2) - Font.Size, (Height / 2) - Font.Size);

        }

        #endregion


    }






}
