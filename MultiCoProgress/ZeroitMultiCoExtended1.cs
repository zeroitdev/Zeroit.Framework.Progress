// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-25-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 11-03-2017
// ***********************************************************************
// <copyright file="ZeroitMultiCoExtended1.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation;



#endregion

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class ZeroitProgressMultiCoExtended1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitProgressMultiCoExtended1 : Control 
    {

        #region Iconvertible Parameters

        //double x;
        //double y;


        //public TypeCode GetTypeCode()
        //{
        //    return TypeCode.Object;
        //}

        //bool IConvertible.ToBoolean(IFormatProvider provider)
        //{
        //    if ((x != 0.0) || (y != 0.0))
        //        return true;
        //    else
        //        return false;
        //}

        //Color[][] GetDoubleValue()
        //{
        //    return linColors;
        //}



        //byte IConvertible.ToByte(IFormatProvider provider)
        //{
        //    return Convert.ToByte(GetDoubleValue());
        //}

        //char IConvertible.ToChar(IFormatProvider provider)
        //{
        //    return Convert.ToChar(GetDoubleValue());
        //}

        //DateTime IConvertible.ToDateTime(IFormatProvider provider)
        //{
        //    return Convert.ToDateTime(GetDoubleValue());
        //}

        //decimal IConvertible.ToDecimal(IFormatProvider provider)
        //{
        //    return Convert.ToDecimal(GetDoubleValue());
        //}

        //double IConvertible.ToDouble(IFormatProvider provider)
        //{

        //    return linColors.GetLength(1);
        //}

        //short IConvertible.ToInt16(IFormatProvider provider)
        //{
        //    return Convert.ToInt16(GetDoubleValue());
        //}

        //int IConvertible.ToInt32(IFormatProvider provider)
        //{
        //    return Convert.ToInt32(GetDoubleValue());
        //}

        //long IConvertible.ToInt64(IFormatProvider provider)
        //{
        //    return Convert.ToInt64(GetDoubleValue());
        //}

        //sbyte IConvertible.ToSByte(IFormatProvider provider)
        //{
        //    return Convert.ToSByte(GetDoubleValue());
        //}

        //float IConvertible.ToSingle(IFormatProvider provider)
        //{
        //    return Convert.ToSingle(GetDoubleValue());
        //}

        //string IConvertible.ToString(IFormatProvider provider)
        //{
        //    return String.Format("({0}, {1})", x, y);
        //}

        //object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        //{
        //    return Convert.ChangeType(GetDoubleValue(), conversionType);
        //}

        //ushort IConvertible.ToUInt16(IFormatProvider provider)
        //{
        //    return Convert.ToUInt16(GetDoubleValue());
        //}

        //uint IConvertible.ToUInt32(IFormatProvider provider)
        //{
        //    return Convert.ToUInt32(GetDoubleValue());
        //}

        //ulong IConvertible.ToUInt64(IFormatProvider provider)
        //{
        //    return Convert.ToUInt64(GetDoubleValue());
        //}

        #endregion

        #region Private Properties

        /// <summary>
        /// The outer border start
        /// </summary>
        private LineCap outerBorderStart = LineCap.Round;
        /// <summary>
        /// The outer border end
        /// </summary>
        private LineCap outerBorderEnd = LineCap.ArrowAnchor;

        /// <summary>
        /// The outer border style
        /// </summary>
        private DashStyle outerBorderStyle = DashStyle.Dash;


        /// <summary>
        /// The gradient angle
        /// </summary>
        private float gradientAngle = 90f;

        /// <summary>
        /// The outerborder
        /// </summary>
        bool outerborder = false;
        /// <summary>
        /// The rotatingborder
        /// </summary>
        bool rotatingborder = true;

        /// <summary>
        /// The divisions
        /// </summary>
        bool divisions = true;
        /// <summary>
        /// The divisions width
        /// </summary>
        int divisionsWidth = 5;

        /// <summary>
        /// Enum RenderMode
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
        /// The draw mode
        /// </summary>
        private RenderMode _drawMode = RenderMode.Solid;

        /// <summary>
        /// The peace animator
        /// </summary>
        PeaceAnimator peaceAnimator = new PeaceAnimator();

        /// <summary>
        /// Enum Easing
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
        /// The easing type
        /// </summary>
        private Easing _easingType = Easing.BounceEaseIn;

        /// <summary>
        /// The value
        /// </summary>
        private float value = 0;

        /// <summary>
        /// The show inner border
        /// </summary>
        private bool showInnerBorder = true;

        /// <summary>
        /// The automatic increment
        /// </summary>
        private bool autoIncrement = false;

        /// <summary>
        /// The speed
        /// </summary>
        public int speed = 100;

        /// <summary>
        /// The inner border
        /// </summary>
        private int innerBorder = 2;

        /// <summary>
        /// The shift
        /// </summary>
        private int shift = 15;

        /// <summary>
        /// The correct shift
        /// </summary>
        private int correctShift = 6;

        /// <summary>
        /// The rect shift
        /// </summary>
        private int rectShift = 3;

        /// <summary>
        /// The no of rings
        /// </summary>
        private Rings noOfRings = Rings.Default;

        /// <summary>
        /// The inner hole color
        /// </summary>
        private Color innerHoleColor = Color.Transparent;
        /// <summary>
        /// The inner hole grad color
        /// </summary>
        private Color[][] innerHoleGradColor = new Color[][]
        {
            new []{Color.Azure, Color.Bisque}
        };

        /// <summary>
        /// The inner border color
        /// </summary>
        private Color innerBorderColor = Color.Gray;

        /// <summary>
        /// The lin colors
        /// </summary>
        Color[][] linColors = new Color[][] {

            new [] {Color.Red, Color.Yellow },
            new [] {Color.Blue, Color.LightGreen },
            new [] {Color.LightPink, Color.LightSkyBlue },
            new [] {Color.Yellow, Color.Green },
            new [] {Color.BlanchedAlmond, Color.DarkGoldenrod },
            new [] {Color.DarkTurquoise, Color.DimGray },
            new [] {Color.Beige, Color.BlanchedAlmond },
            new [] {Color.BurlyWood, Color.Chartreuse },
            new [] {Color.DarkOrange, Color.DarkOrchid },
            new [] {Color.GreenYellow, Color.Honeydew },
            new [] {Color.HotPink, Color.Indigo },
            new [] {Color.Magenta, Color.Maroon },
            new [] {Color.OldLace, Color.Plum },
            new [] {Color.PowderBlue, Color.Purple },
            new [] {Color.SlateBlue, Color.Thistle },
            new [] {Color.Sienna, Color.SeaShell },
            new [] {Color.Peru, Color.Navy },
            new [] {Color.MistyRose, Color.MidnightBlue },
            new [] {Color.LemonChiffon, Color.LawnGreen },
            new [] {Color.Khaki, Color.HotPink },
            new [] {Color.ForestGreen, Color.Yellow },
            new [] {Color.DarkSlateGray, Color.Crimson },
            new [] {Color.Cornsilk, Color.CornflowerBlue },
            new [] {Color.Beige, Color.Cyan }

        };


        /// <summary>
        /// The colors
        /// </summary>
        Color[] colors = new Color[]
            {
                Color.Red,
                Color.Yellow,
                Color.Green,
                Color.AliceBlue,
                Color.Brown,
                Color.Chocolate,
                Color.DarkOrange,
                Color.DarkRed,
                Color.DeepPink,
                Color.Indigo,
                Color.Ivory,
                Color.Lavender,
                Color.LightSeaGreen,
                Color.Maroon,
                Color.OrangeRed,
                Color.Orchid,
                Color.PaleGoldenrod,
                Color.PapayaWhip,
                Color.Teal,
                Color.Tomato,
                Color.YellowGreen,
                Color.Thistle,
                Color.Tan,
                Color.SlateGray,
            };

        /// <summary>
        /// The one ringa
        /// </summary>
        private float[] oneRinga = new float[] { 270f };
        /// <summary>
        /// The one ringb
        /// </summary>
        private float[] oneRingb = new float[] { 0f };
        /// <summary>
        /// The one ring maximum
        /// </summary>
        private float oneRingMax = 360;

        /// <summary>
        /// The two ringa
        /// </summary>
        private float[] twoRinga = new float[] { 270f, 0f };
        /// <summary>
        /// The two ringb
        /// </summary>
        private float[] twoRingb = new float[] { 90f, 0f };
        /// <summary>
        /// The two ring maximum
        /// </summary>
        private float twoRingMax = 180;

        /// <summary>
        /// The four ringa
        /// </summary>
        private float[] fourRinga = new float[] { 270f, 0f, 90f, 180f };
        /// <summary>
        /// The four ringb
        /// </summary>
        private float[] fourRingb = new float[] { 0f, 0f, 0f, 0f };
        /// <summary>
        /// The four ring maximum
        /// </summary>
        private float fourRingMax = 90;

        /// <summary>
        /// The eight ringa
        /// </summary>
        private float[] eightRinga = new float[] { 270f, 315f, 0f, 45f, 90f, 135f, 180f, 225f };
        /// <summary>
        /// The eight ringb
        /// </summary>
        private float[] eightRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The eight ring maximum
        /// </summary>
        private float eightRingMax = 45;

        /// <summary>
        /// The twelve ringa
        /// </summary>
        private float[] twelveRinga = new float[] { 270f, 300f, 330f, 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f };
        /// <summary>
        /// The twelve ringb
        /// </summary>
        private float[] twelveRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The twelve ring maximum
        /// </summary>
        private float twelveRingMax = 30;



        /// <summary>
        /// The twenty four ringa
        /// </summary>
        private float[] twentyFourRinga = new float[] { 270f, 285f, 300f, 315f, 330f, 345f, 0f, 15f, 30f, 45f, 60f, 75f, 90f, 105f, 120f, 135f, 150f, 165f, 180f, 195f, 210, 225, 240f, 255 };
        /// <summary>
        /// The twenty four ringb
        /// </summary>
        private float[] twentyFourRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The twenty four ring maximum
        /// </summary>
        private float twentyFourRingMax = 15;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to enable rotating border.
        /// </summary>
        /// <value><c>true</c> if [rotating border]; otherwise, <c>false</c>.</value>
        public bool RotatingBorder
        {
            get { return rotatingborder; }
            set
            {
                rotatingborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border start.
        /// </summary>
        /// <value>The outer border start.</value>
        public LineCap OuterBorderStart
        {
            get { return outerBorderStart; }
            set
            {
                outerBorderStart = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border end.
        /// </summary>
        /// <value>The outer border end.</value>
        public LineCap OuterBorderEnd
        {
            get { return outerBorderEnd; }
            set
            {
                outerBorderEnd = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border style.
        /// </summary>
        /// <value>The outer border style.</value>
        public DashStyle OuterBorderStyle
        {
            get { return outerBorderStyle; }
            set
            {
                outerBorderStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether enable or disable outer border.
        /// </summary>
        /// <value><c>true</c> if [outer border]; otherwise, <c>false</c>.</value>
        public bool OuterBorder
        {
            get { return outerborder; }
            set
            {
                outerborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner hole gradient colors.
        /// </summary>
        /// <value>The inner hole gradient colors.</value>
        public Color[][] InnerHoleGradCol
        {
            get { return innerHoleGradColor; }
            set
            {
                innerHoleGradColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner hole color.
        /// </summary>
        /// <value>The inner hole color.</value>
        public Color InnerHole
        {
            get
            {
                return innerHoleColor;
            }

            set
            {
                innerHoleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressMultiCoExtended1"/> should have divisions.
        /// </summary>
        /// <value><c>true</c> if divisions; otherwise, <c>false</c>.</value>
        public bool Divisions
        {
            get { return divisions; }
            set
            {
                divisions = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the divisions.
        /// </summary>
        /// <value>The width of the divisions.</value>
        public int DivisionsWidth
        {
            get { return divisionsWidth; }
            set
            {
                divisionsWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient colors.
        /// </summary>
        /// <value>The gradient colors.</value>
        public Color[][] GradientColors
        {
            get { return linColors; }
            set
            {
                linColors = value;
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
        /// Gets or sets a value indicating whether to automatically start animation with some easing functionalities.
        /// </summary>
        /// <value><c>true</c> if [automatic increment]; otherwise, <c>false</c>.</value>
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
        /// Gets or sets the type of easing animation.
        /// </summary>
        /// <value>The type of easing animation.</value>
        public Easing AnimationType
        {
            get { return _easingType; }
            set
            {
                _easingType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the inner border.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public Color InnerBorderColor
        {
            get { return innerBorderColor; }
            set
            {
                innerBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the speed of the animation.
        /// </summary>
        /// <value>The speed.</value>
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the colors used in the control.
        /// </summary>
        /// <value>The colors.</value>
        public Color[] Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Enum representing the number of rings
        /// </summary>
        public enum Rings
        {
            /// <summary>
            /// The default
            /// </summary>
            Default,
            /// <summary>
            /// The one
            /// </summary>
            One,
            /// <summary>
            /// The two
            /// </summary>
            Two,
            /// <summary>
            /// The four
            /// </summary>
            Four,
            /// <summary>
            /// The eight
            /// </summary>
            Eight,
            /// <summary>
            /// The twelve
            /// </summary>
            Twelve,
            /// <summary>
            /// The twenty four
            /// </summary>
            TwentyFour
        }

        /// <summary>
        /// Gets or sets the number of rings.
        /// </summary>
        /// <value>The number of rings.</value>
        public Rings NoOfRings
        {
            get { return noOfRings; }
            set
            {
                noOfRings = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.AntiAlias;

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

        /// <summary>
        /// Gets or sets a value indicating whether to show the inner border.
        /// </summary>
        /// <value><c>true</c> if show inner border; otherwise, <c>false</c>.</value>
        public bool ShowInnerBorder
        {
            get { return showInnerBorder; }
            set
            {
                showInnerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border value.
        /// </summary>
        /// <value>The inner border.</value>
        public int InnerBorder
        {
            get { return innerBorder; }
            set
            {
                innerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner shift.
        /// </summary>
        /// <value>The inner shift.</value>
        public int InnerShift
        {
            get { return rectShift; }
            set
            {
                rectShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the way to correct the shift.
        /// </summary>
        /// <value>The correct shift.</value>
        public int CorrectShift
        {
            get { return correctShift; }
            set
            {
                correctShift = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the shift.
        /// </summary>
        /// <value>The shift.</value>
        public int Shift
        {
            get { return shift; }
            set
            {
                shift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rectangular shift.
        /// </summary>
        /// <value>The rect shift.</value>
        public int RectShift
        {
            get { return rectShift; }
            set
            {
                rectShift = value;
                Invalidate();
            }
        }


        #endregion

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = false;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatically  start animation.
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
            if (this.Value + 1 > 100)
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
        

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressMultiCoExtended1"/> class.
        /// </summary>
        public ZeroitProgressMultiCoExtended1()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            
            #region Animation

            peaceAnimator.Control = this;
            peaceAnimator.DurationValue = 5000;
            peaceAnimator.Repeat = true;
            peaceAnimator.Reverse = true;
            peaceAnimator.OneDProperty = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Animator.KnownProperties.Value;
            peaceAnimator.StartValue = 0;
            peaceAnimator.EndValue = 100;


            #endregion


            #region MyRegion
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

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            timer.Interval = speed;

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


            Graphics G = e.Graphics;
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = smoothing;


            Rectangle rect = new Rectangle(correctShift, correctShift, Width - shift, Height - shift);
            Rectangle coloredRectangle = new Rectangle(0, 0, Width - rectShift, Height - rectShift);
            Rectangle outerborderRectangle = new Rectangle(0, 0, Width - rectShift + 1, Height - rectShift + 1);

            Pen outsideBorder = new Pen(Color.Gray, 2);
            Pen outerBorder = new Pen(Color.Black, 2);



            outsideBorder.DashStyle = outerBorderStyle;
            outsideBorder.EndCap = outerBorderEnd;
            outsideBorder.StartCap = outerBorderStart;

            outerBorder.DashStyle = outerBorderStyle;
            outerBorder.EndCap = outerBorderEnd;
            outerBorder.StartCap = outerBorderStart;

            if (showInnerBorder)
            {
                g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                g.DrawEllipse(new Pen(innerBorderColor, innerBorder), rect);
            }

            else
            {
                g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                g.DrawEllipse(new Pen(Color.Transparent, innerBorder), rect);

            }


            switch (noOfRings)
            {
                case Rings.One:

                    #region 1 ring

                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }

                    if (rotatingborder)
                    {
                        g.DrawPie(outerBorder, outerborderRectangle, 270f, (this.value / 100) * (360f /*+ oneRingb[0]*/));
                    }

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            if (divisions)
                            {
                                g.FillPie(new SolidBrush(colors[0]), coloredRectangle, oneRinga[0], (this.value / 100) * (360f /*+ oneRingb[0]*/));
                                g.DrawPie(new Pen(Color.Transparent, divisionsWidth), coloredRectangle, 270f, 360f);


                                g.FillEllipse(new SolidBrush(BackColor), rect);
                                //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            }

                            else
                            {
                                g.FillPie(new SolidBrush(colors[0]), coloredRectangle, oneRinga[0], (this.value / 100) * (360f /*+ oneRingb[0]*/));

                                //g.DrawPie(new Pen(Color.Transparent, 2), coloredRectangle, 270f, 90f);

                                g.FillEllipse(new SolidBrush(BackColor), rect);
                                //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            }

                            //if(rotatingborder)
                            //{
                            //    g.DrawPie(outerBorder, outerborderRectangle, 270f, (this.value / 100) * (360f /*+ oneRingb[0]*/));
                            //}

                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, oneRinga[0], (this.value / 100) * (360f /*+ oneRingb[0]*/));
                                g.DrawPie(new Pen(Color.Transparent, divisionsWidth), coloredRectangle, 270f, 360f);

                                g.FillEllipse(new SolidBrush(BackColor), rect);
                                //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            }

                            else
                            {
                                g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, oneRinga[0], (this.value / 100) * (360f /*+ oneRingb[0]*/));
                                //g.DrawPie(new Pen(Color.Transparent, 2), coloredRectangle, 270f, 90f);

                                g.FillEllipse(new SolidBrush(BackColor), rect);
                                //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            }


                            break;
                        default:
                            break;
                    }

                    #endregion

                    break;
                case Rings.Two:

                    #region 2 rings

                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }



                    switch (_drawMode)
                    {
                        case RenderMode.Solid:


                            if (divisions)
                            {
                                if (value >= 0 && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 180f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 180f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 90f, ((this.value - 50) / 50) * 180f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 180f);

                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);

                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 270f, 180f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 270f, 180f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 90f, ((this.value - 50) / 50) * 180f);
                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 90f, 180f);

                                }
                            }



                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);



                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                if (value >= 0 && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 180f);

                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 180f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 50) * 180f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 180f);

                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 270f, 180f);

                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 50) * 180f);
                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 270f, 180f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 50) * 180f);
                                    //g.DrawPie(new Pen(BackColor, 5), coloredRectangle, 90f, 180f);

                                }
                            }


                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            break;
                        default:
                            break;
                    }


                    #endregion

                    break;
                case Rings.Four:

                    #region 4 rings

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            if (divisions)
                            {
                                if (value >= 0 && value < 26)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 25 && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 50 && value < 76)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);


                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 180f, ((this.value - 75) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);


                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 26)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 25 && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 50 && value < 76)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 180f, ((this.value - 75) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);


                                }
                            }



                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);


                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                if (value >= 0 && value < 26)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 25 && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 50 && value < 76)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);


                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75) / 25) * 90f);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 90f);


                                }

                            }

                            else
                            {
                                if (value >= 0 && value < 26)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 25 && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 50 && value < 76)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75) / 25) * 90f);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);


                                }

                            }


                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            break;
                        default:
                            break;
                    }

                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }
                    #endregion

                    break;
                case Rings.Eight:


                    #region 8 Rings

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            if (divisions)
                            {
                                if (value >= 0 && value < 13f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 12f && value < 26)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 25f && value < 38)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 37f && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);

                                }

                                else if (value > 50 && value < 63)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);

                                }

                                else if (value > 62 && value < 76)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);



                                }

                                else if (value > 75 && value < 88)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 225f, ((this.value - 87.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);


                                }

                            }

                            else
                            {
                                if (value >= 0 && value < 13f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 12f && value < 26)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 25f && value < 38)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 37f && value < 51)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 50 && value < 63)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                                }

                                else if (value > 62 && value < 76)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                                }

                                else if (value > 75 && value < 88)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 225f, ((this.value - 87.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                                }

                            }

                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);


                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                if (value >= 0 && value < 13f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 12f && value < 26)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 25f && value < 38)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);
                                }

                                else if (value > 37f && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);

                                }

                                else if (value > 50 && value < 63)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);



                                }

                                else if (value > 62 && value < 76)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);



                                }

                                else if (value > 75 && value < 88)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);

                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 45f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.5f) / 12.5f) * 45);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 45f);


                                }

                            }

                            else
                            {
                                if (value >= 0 && value < 13f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 12f && value < 26)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 25f && value < 38)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 37f && value < 51)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 50 && value < 63)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                                }

                                else if (value > 62 && value < 76)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                                }

                                else if (value > 75 && value < 88)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }


                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.5f) / 12.5f) * 45);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                                }

                            }

                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);


                            break;
                        default:
                            break;
                    }


                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }
                    #endregion

                    break;
                case Rings.Twelve:

                    #region 12 Rings

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            if (divisions)
                            {
                                if (value >= 0 && value < 8.4f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);
                                }

                                else if (value > 8.5 && value < 17f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);


                                }

                                else if (value > 16.6 && value < 26f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }

                                else if (value > 25 && value < 34f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);


                                }

                                else if (value > 33 && value < 43f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);


                                }

                                else if (value > 42 && value < 51f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);



                                }

                                else if (value > 50 && value < 60f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }

                                else if (value > 59 && value < 68f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);


                                }

                                else if (value > 67 && value < 76f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);




                                }

                                else if (value > 75f && value < 85f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }

                                else if (value > 84f && value < 93f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 240f, ((this.value - 91.6663f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }

                            }

                            else
                            {
                                if (value >= 0 && value < 8.4f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 8.5 && value < 17f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                                }

                                else if (value > 16.6 && value < 26f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 25 && value < 34f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                                }

                                else if (value > 33 && value < 43f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                                }

                                else if (value > 42 && value < 51f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                                }

                                else if (value > 50 && value < 60f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                }

                                else if (value > 59 && value < 68f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 67 && value < 76f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);




                                }

                                else if (value > 75f && value < 85f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }

                                else if (value > 84f && value < 93f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 240f, ((this.value - 91.6663f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                }

                            }

                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);


                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                if (value >= 0 && value < 8.4f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);
                                }

                                else if (value > 8.5 && value < 17f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);


                                }

                                else if (value > 16.6 && value < 26f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                }

                                else if (value > 25 && value < 34f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);


                                }

                                else if (value > 33 && value < 43f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);


                                }

                                else if (value > 42 && value < 51f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);



                                }

                                else if (value > 50 && value < 60f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                }

                                else if (value > 59 && value < 68f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);


                                }

                                else if (value > 67 && value < 76f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);


                                }

                                else if (value > 75f && value < 85f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                }

                                else if (value > 84f && value < 93f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 30f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6663f) / 8.3333f) * 30);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 30f);

                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 8.4f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 8.5 && value < 17f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                                }

                                else if (value > 16.6 && value < 26f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 25 && value < 34f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                                }

                                else if (value > 33 && value < 43f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                                }

                                else if (value > 42 && value < 51f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                                }

                                else if (value > 50 && value < 60f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                }

                                else if (value > 59 && value < 68f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 67 && value < 76f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 75f && value < 85f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }

                                else if (value > 84f && value < 93f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6663f) / 8.3333f) * 30);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                }
                            }



                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            break;
                        default:
                            break;
                    }


                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }

                    #endregion

                    break;
                case Rings.TwentyFour:

                    #region 24 Rings

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            if (divisions)
                            {
                                if (value >= 0 && value < 5f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 4 && value < 9f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 8 && value < 14f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 13 && value < 18f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 17 && value < 22f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 21 && value < 26f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 25 && value < 31f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 30 && value < 35f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 34 && value < 39f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 38 && value < 43f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 42 && value < 47f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 46 && value < 51f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);



                                }

                                else if (value > 50 && value < 56f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 55 && value < 60f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 59 && value < 64f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 63 && value < 68f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 67 && value < 72f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 71 && value < 76f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 75 && value < 81f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 80 && value < 85f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 84 && value < 89f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 88 && value < 93f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 92 && value < 97f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.FillPie(new SolidBrush(colors[23]), coloredRectangle, 255f, ((this.value - 95.8315f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 5f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 4 && value < 9f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 8 && value < 14f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 13 && value < 18f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 17 && value < 22f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 21 && value < 26f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                                }

                                else if (value > 25 && value < 31f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 30 && value < 35f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 34 && value < 39f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 38 && value < 43f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 42 && value < 47f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 46 && value < 51f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                                }

                                else if (value > 50 && value < 56f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 55 && value < 60f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 59 && value < 64f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 63 && value < 68f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 67 && value < 72f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 71 && value < 76f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 75 && value < 81f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 80 && value < 85f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 84 && value < 89f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 
                                }

                                else if (value > 88 && value < 93f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 92 && value < 97f)
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else
                                {
                                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);

                                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new SolidBrush(colors[23]), coloredRectangle, 255f, ((this.value - 95.8315f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                                }
                            }

                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);

                            break;
                        case RenderMode.Gradient:

                            if (divisions)
                            {
                                if (value >= 0 && value < 5f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 4 && value < 9f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 8 && value < 14f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 13 && value < 18f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 17 && value < 22f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 21 && value < 26f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 25 && value < 31f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 30 && value < 35f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 34 && value < 39f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 38 && value < 43f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 42 && value < 47f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }

                                else if (value > 46 && value < 51f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);



                                }

                                else if (value > 50 && value < 56f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 55 && value < 60f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 59 && value < 64f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 63 && value < 68f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 67 && value < 72f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 71 && value < 76f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);


                                }

                                else if (value > 75 && value < 81f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 80 && value < 85f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 84 && value < 89f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 88 && value < 93f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 90f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else if (value > 92 && value < 97f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[22][0], linColors[22][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);
                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 270f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 285f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 300f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 315f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 330f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 345f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 15f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 30f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 45f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 60f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 75f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 15f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 105f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 120f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 135f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 150f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 165f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 180f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 195f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 210f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 225f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[22][0], linColors[22][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 240f, 15f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[23][0], linColors[23][1], gradientAngle), coloredRectangle, 255f, ((this.value - 95.8315f) / 4.1666f) * 15);
                                    g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 255f, 15f);

                                }
                            }

                            else
                            {
                                if (value >= 0 && value < 5f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 4 && value < 9f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 8 && value < 14f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                }

                                else if (value > 13 && value < 18f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 17 && value < 22f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                                }

                                else if (value > 21 && value < 26f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                                }

                                else if (value > 25 && value < 31f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 30 && value < 35f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 34 && value < 39f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 38 && value < 43f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                                }

                                else if (value > 42 && value < 47f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                }

                                else if (value > 46 && value < 51f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                                }

                                else if (value > 50 && value < 56f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 55 && value < 60f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(BackColor, divisionsWidth), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 59 && value < 64f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 63 && value < 68f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 67 && value < 72f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                                }

                                else if (value > 71 && value < 76f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                }

                                else if (value > 75 && value < 81f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 80 && value < 85f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 84 && value < 89f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 
                                }

                                else if (value > 88 && value < 93f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else if (value > 92 && value < 97f)
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[22][0], linColors[22][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                                }

                                else
                                {
                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[0][0], linColors[0][1], gradientAngle), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[1][0], linColors[1][1], gradientAngle), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[2][0], linColors[2][1], gradientAngle), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[3][0], linColors[3][1], gradientAngle), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[4][0], linColors[4][1], gradientAngle), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[5][0], linColors[5][1], gradientAngle), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[6][0], linColors[6][1], gradientAngle), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[7][0], linColors[7][1], gradientAngle), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[8][0], linColors[8][1], gradientAngle), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[9][0], linColors[9][1], gradientAngle), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[10][0], linColors[10][1], gradientAngle), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[11][0], linColors[11][1], gradientAngle), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[12][0], linColors[12][1], gradientAngle), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[13][0], linColors[13][1], gradientAngle), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[14][0], linColors[14][1], gradientAngle), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[15][0], linColors[15][1], gradientAngle), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[16][0], linColors[16][1], gradientAngle), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[17][0], linColors[17][1], gradientAngle), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[18][0], linColors[18][1], gradientAngle), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[19][0], linColors[19][1], gradientAngle), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[20][0], linColors[20][1], gradientAngle), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[21][0], linColors[21][1], gradientAngle), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[22][0], linColors[22][1], gradientAngle), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                                    g.FillPie(new LinearGradientBrush(coloredRectangle, linColors[23][0], linColors[23][1], gradientAngle), coloredRectangle, 255f, ((this.value - 95.8315f) / 4.1666f) * 15);
                                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                                }
                            }



                            g.FillEllipse(new SolidBrush(BackColor), rect);
                            //g.DrawEllipse(new Pen(BackColor, 1), rect);


                            break;
                        default:
                            break;
                    }


                    //Experimental
                    if (outerborder)
                    {
                        g.DrawEllipse(outsideBorder, coloredRectangle);
                    }

                    #endregion

                    break;
                case Rings.Default:

                    switch (_drawMode)
                    {
                        case RenderMode.Solid:

                            g.FillPie(new SolidBrush(innerHoleColor), coloredRectangle, 270f, 360f);
                            //g.DrawPie(new Pen(Color.Black, 2), coloredRectangle, 270f, 90f);

                            g.FillEllipse(new SolidBrush(innerHoleColor), rect);
                            g.DrawEllipse(new Pen(Color.Gray, 2), rect);

                            break;
                        case RenderMode.Gradient:

                            g.FillPie(new SolidBrush(innerHoleColor), coloredRectangle, 270f, 360f);
                            //g.DrawPie(new Pen(Color.Black, 2), coloredRectangle, 270f, 90f);

                            g.FillEllipse(new LinearGradientBrush(coloredRectangle, innerHoleGradColor[0][0], innerHoleGradColor[0][1], 90f), rect);
                            g.DrawEllipse(new Pen(Color.Gray, 2), rect);
                            break;
                        default:
                            break;
                    }

                    break;

            }

        }



    }

}
