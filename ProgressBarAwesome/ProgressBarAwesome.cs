// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressBarAwesome.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation;

#endregion

namespace Zeroit.Framework.Progress
{

    #region Awesome ProgressBar

    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ProgressBar" />
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ZeroitProgressBarAwesome), "CircularProgressBar.bmp")]
    [DefaultBindingProperty("Value")]
    [Designer(typeof(ZeroitProgressBarAwesomeDesigner))]
    public class ZeroitProgressBarAwesome : ProgressBar
    {

        #region Zeroit Additions
        /// <summary>
        /// The outer margin
        /// </summary>
        private int outerMargin = -25;
        /// <summary>
        /// The outer width
        /// </summary>
        private int outerWidth = 26;
        /// <summary>
        /// The outer color
        /// </summary>
        private Color outerColor = Color.Gray;

        /// <summary>
        /// The progress width
        /// </summary>
        private int progressWidth = 25;
        /// <summary>
        /// The progress color
        /// </summary>
        private Color progressColor = Color.FromArgb(156, 39, 176);

        /// <summary>
        /// The inner margin
        /// </summary>
        private int innerMargin = 2;
        /// <summary>
        /// The inner width
        /// </summary>
        private int innerWidth = -1;
        /// <summary>
        /// The inner color
        /// </summary>
        private Color innerColor = Color.FromArgb(224, 224, 224);


        #region Zeroit Code
        //private int _value = 1;

        //private int _interval = 1000;

        //private bool _autoStart;

        //private bool _stopped = true;

        /// <summary>
        /// The timer animation
        /// </summary>
        private System.Windows.Forms.Timer timerAnimation = new System.Windows.Forms.Timer();

        #endregion

        #region Zeroit AutoStart
        /// <summary>
        /// Gets or sets a value indicating if the animation should start automatically.
        /// </summary>
        //[DefaultValue(false)]
        //[Description("Gets or sets a value indicating if the animation should start automatically.")]
        //[Category("Behavior")]
        //public bool AutoStart
        //{
        //    get { return _autoStart; }
        //    set
        //    {
        //        _autoStart = value;

        //        if (_autoStart && !DesignMode)
        //            Start();
        //        else
        //            Stop();
        //    }
        //}
        #endregion

        #endregion

        private readonly Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Animator _animator;
        /// <summary>
        /// The animated start angle
        /// </summary>
        private int? _animatedStartAngle;

        /// <summary>
        /// The animated value
        /// </summary>
        private float? _animatedValue;

        /// <summary>
        /// The animation function
        /// </summary>
        private Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.AnimationFunctions.Function _animationFunction;

        /// <summary>
        /// The back brush
        /// </summary>
        private Brush _backBrush;

        /// <summary>
        /// The known animation function
        /// </summary>
        private Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions _knownAnimationFunction;

        /// <summary>
        /// The last style
        /// </summary>
        private ProgressBarStyle? _lastStyle;

        /// <summary>
        /// The last value
        /// </summary>
        private int _lastValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarAwesome" /> class.
        /// </summary>
        public ZeroitProgressBarAwesome()
        {
            SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            _animator = DesignMode ? null : new Animator();
            AnimationFunction = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.Liner;
            AnimationSpeed = 500;
            MarqueeAnimationSpeed = 2000;
            StartAngle = 270;

            _lastValue = Value;

            // Child class should be responsible for handling this values at the constructor
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(64, 64, 64);
            DoubleBuffered = true;
            Font = new Font(Font.FontFamily, 20, FontStyle.Bold);
            SecondaryFont = new Font(Font.FontFamily, (float)(Font.Size * .7), FontStyle.Regular);
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            //OuterMargin = -25;
            //OuterWidth = 26;
            //OuterColor = Color.Gray;

            //ProgressWidth = 25;
            //ProgressColor = Color.FromArgb(156, 39, 176);

            //InnerMargin = 2;
            //InnerWidth = -1;
            //InnerColor = Color.FromArgb(224, 224, 224);

            TextMargin = new Padding(8, 8, 0, 0);
            Value = 0;

            SuperscriptMargin = new Padding(10, 35, 0, 0);
            SuperscriptColor = Color.FromArgb(166, 166, 166);
            SuperscriptText = "°C";

            SubscriptMargin = new Padding(10, -35, 0, 0);
            SubscriptColor = Color.FromArgb(166, 166, 166);
            SubscriptText = ".23";

            Size = new Size(200, 200);
            ProgressWidth = 5;
            ProgressColor = Color.Teal;

            #region Zeroit AutoStart Code (Work in Progress)
            timerAnimation.Tick += new System.EventHandler(timerAnimation_Tick);
            if (AutoStart)
                timerAnimation.Start();
            #endregion
        }

        #region Timer

        #region Zeroit Timer Old Code
        //private void timerAnimation_Tick(object sender, EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        IncreaseValue();
        //        Invalidate();
        //    }

        //    if (DesignMode)
        //    {
        //        IncreaseValue();
        //        Invalidate();
        //    }
        //}

        //private void IncreaseValue()
        //{
        //    //if (_value + 1 <= _numberOfCircles)
        //    //    _value++;

        //    //else
        //    //    _value = 1;

        //    //Value++;

        //    int i;

        //    this.Minimum = 0;
        //    this.Maximum = 200;

        //    for (i = 0; i <= 200; i++)
        //    {
        //        this.Value = i;
        //    }
        //}



        ///// <summary>
        ///// Starts the animation.
        ///// </summary>
        //public void Start()
        //{
        //    timerAnimation.Interval = _interval;
        //    _stopped = false;
        //    timerAnimation.Start();
        //}

        ///// <summary>
        ///// Stops the animation.
        ///// </summary>
        //public void Stop()
        //{
        //    timerAnimation.Stop();
        //    _value = 1;
        //    _stopped = true;
        //    Invalidate();
        //}
        #endregion

        /// <summary>
        /// The enabletime
        /// </summary>
        private bool enabletime;
        /// <summary>
        /// The automatic start interval
        /// </summary>
        private int _autoStartInterval = 100;

        /// <summary>
        /// Gets or sets the automatic start interval.
        /// </summary>
        /// <value>The automatic start interval.</value>
        public int AutoStartInterval
        {
            get { return _autoStartInterval; }
            set
            {
                _autoStartInterval = value;
                timerAnimation.Interval = _autoStartInterval;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether automatically start animation.
        /// </summary>
        /// <value><c>true</c> if automatic start; otherwise, <c>false</c>.</value>
        public bool AutoStart
        {
            get { return enabletime; }
            set
            {
                if (value == true)
                {
                    timerAnimation.Enabled = true;
                }

                else
                {
                    timerAnimation.Enabled = false;
                    this.Value = 0;
                    this.Text = Value.ToString();
                }

                enabletime = value;
                Invalidate();

            }
        }
        /// <summary>
        /// Handles the Tick event of the timerAnimation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    Value += 1;
                    Text = Value.ToString();

                    if (Value == Maximum)
                    {
                        Value = 0;
                    }
                }
                catch (Exception ex)
                {


                }
            }

            if (DesignMode)
            {
                try
                {
                    Value += 1;
                    Text = Value.ToString();

                    if (Value == Maximum)
                    {
                        Value = 0;
                    }
                }
                catch (Exception ex)
                {


                }
            }

            //if (DesignMode)
            //{

            //}
        }

        #endregion

        /// <summary>
        /// Gets or sets the font of text in the <see cref="ZeroitProgressBarAwesome" />.
        /// </summary>
        /// <value>The font.</value>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Gets or sets the text in the <see cref="ZeroitProgressBarAwesome" />.
        /// </summary>
        /// <value>The text.</value>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Sets a known animation function.
        /// </summary>
        /// <value>The animation function.</value>
        [Category("Behavior")]
        public Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions AnimationFunction
        {
            get { return _knownAnimationFunction; }
            set
            {
                _animationFunction = AnimationFunctions.FromKnown(value);
                _knownAnimationFunction = value;
            }
        }

        /// <summary>
        /// Sets a custom animation function.
        /// </summary>
        /// <value>The custom animation function.</value>
        /// <exception cref="ArgumentNullException">value</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.AnimationFunctions.Function CustomAnimationFunction
        {
            private get { return _animationFunction; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _knownAnimationFunction = Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.None;
                _animationFunction = value;
            }
        }

        /// <summary>
        /// Gets or sets the animation speed in milliseconds.
        /// </summary>
        /// <value>The animation speed.</value>
        [Category("Behavior")]
        public int AnimationSpeed { get; set; }

        /// <summary>
        /// Gets or sets the text margin.
        /// </summary>
        /// <value>The text margin.</value>
        [Category("Layout")]
        public Padding TextMargin { get; set; }

        /// <summary>
        /// Gets or sets the superscript margin.
        /// </summary>
        /// <value>The superscript margin.</value>
        [Category("Layout")]
        public Padding SuperscriptMargin { get; set; }


        /// <summary>
        /// Gets or sets the subscript margin.
        /// </summary>
        /// <value>The subscript margin.</value>
        [Category("Layout")]
        public Padding SubscriptMargin { get; set; }

        /// <summary>
        /// Gets or sets the color of the inner.
        /// </summary>
        /// <value>The color of the inner.</value>
        [Category("Appearance")]
        public Color InnerColor
        {
            get { return innerColor; }
            set
            {
                innerColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner margin.
        /// </summary>
        /// <value>The inner margin.</value>
        [Category("Layout")]
        public int InnerMargin
        {
            get { return innerMargin; }
            set
            {
                innerMargin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the inner.
        /// </summary>
        /// <value>The width of the inner.</value>
        [Category("Layout")]
        public int InnerWidth
        {
            get { return innerWidth; }
            set
            {
                innerWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the outer.
        /// </summary>
        /// <value>The color of the outer.</value>
        [Category("Appearance")]
        public Color OuterColor
        {
            get { return outerColor; }
            set
            {
                outerColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer margin.
        /// </summary>
        /// <value>The outer margin.</value>
        [Category("Layout")]
        public int OuterMargin
        {
            get { return outerMargin; }
            set
            {
                outerMargin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the outer.
        /// </summary>
        /// <value>The width of the outer.</value>
        [Category("Layout")]
        public int OuterWidth
        {
            get { return outerWidth; }
            set
            {
                outerWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        [Category("Appearance")]
        public Color ProgressColor { get; set; }

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        [Category("Layout")]
        public int StartAngle { get; set; }

        /// <summary>
        /// Gets or sets the width of the progress.
        /// </summary>
        /// <value>The width of the progress.</value>
        [Category("Layout")]
        public int ProgressWidth { get; set; }

        /// <summary>
        /// Gets or sets the subscript text.
        /// </summary>
        /// <value>The subscript text.</value>
        [Category("Appearance")]
        public string SubscriptText { get; set; }

        /// <summary>
        /// Gets or sets the color of the subscript.
        /// </summary>
        /// <value>The color of the subscript.</value>
        [Category("Appearance")]
        public Color SubscriptColor { get; set; }

        /// <summary>
        /// Gets or sets the secondary font.
        /// </summary>
        /// <value>The secondary font.</value>
        [Category("Appearance")]
        public Font SecondaryFont { get; set; }

        /// <summary>
        /// Gets or sets the superscript text.
        /// </summary>
        /// <value>The superscript text.</value>
        [Category("Appearance")]
        public string SuperscriptText { get; set; }

        /// <summary>
        /// Gets or sets the color of the superscript.
        /// </summary>
        /// <value>The color of the superscript.</value>
        [Category("Appearance")]
        public Color SuperscriptColor { get; set; }



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LocationChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <inheritdoc />
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.StyleChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <inheritdoc />
        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <inheritdoc />
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidated -= ParentOnInvalidated;
                Parent.Resize -= ParentOnResize;
            }
            base.OnParentChanged(e);
            if (Parent != null)
            {
                Parent.Invalidated += ParentOnInvalidated;
                Parent.Resize += ParentOnResize;
            }
        }

        /// <summary>
        /// Occurs when parent's display requires redrawing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="invalidateEventArgs">The <see cref="InvalidateEventArgs"/> instance containing the event data.</param>
        protected virtual void ParentOnInvalidated(object sender, InvalidateEventArgs invalidateEventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        /// Occurs when the parent resized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void ParentOnResize(object sender, EventArgs eventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        /// Update or create the brush used for drawing the background
        /// </summary>
        protected virtual void RecreateBackgroundBrush()
        {
            lock (this)
            {
                _backBrush?.Dispose();
                _backBrush = new SolidBrush(BackColor);
                if (BackColor.A == 255)
                    return;
                if (Parent != null)
                    using (var parentImage = new Bitmap(Parent.Width, Parent.Height))
                    {
                        using (var parentGraphic = Graphics.FromImage(parentImage))
                        {
                            var pe = new PaintEventArgs(parentGraphic, new Rectangle(new Point(0, 0), parentImage.Size));
                            InvokePaintBackground(Parent, pe);
                            InvokePaint(Parent, pe);

                            if (BackColor.A > 0) // Translucent
                                parentGraphic.FillRectangle(_backBrush, Bounds);
                        }
                        _backBrush = new TextureBrush(parentImage);
                        ((TextureBrush)_backBrush).TranslateTransform(-Bounds.X, -Bounds.Y);
                    }
                else
                    _backBrush = new SolidBrush(Color.FromArgb(255, BackColor));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event when the <see cref="P:System.Windows.Forms.Control.BackColor" /> property value of the control's container changes.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <inheritdoc />
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackgroundImageChanged" /> event when the <see cref="P:System.Windows.Forms.Control.BackgroundImage" /> property value of the control's container changes.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <inheritdoc />
        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (Style == ProgressBarStyle.Marquee)
                        InitializeMarquee(_lastStyle != Style);
                    else
                        InitializeContinues(_lastStyle != Style);
                    _lastStyle = Style;
                }
                if (_backBrush == null)
                    RecreateBackgroundBrush();
                StartPaint(e.Graphics);
            }
            catch
            {
                // ignored
            }

            this.Text = Value.ToString();
        }

        /// <summary>
        /// Initialize the animation for the continues styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeContinues(bool firstTime)
        {
            if ((_lastValue == Value) && !firstTime)
                return;

            _lastValue = Value;

            _animator.Stop();
            _animator.Paths =
                new Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Path(_animatedValue ?? Value, Value, (ulong)AnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = false;
            _animatedStartAngle = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedValue = v;
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        /// Initialize the animation for the marquee styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeMarquee(bool firstTime)
        {
            if (!firstTime &&
                ((_animator.ActivePath == null) ||
                 ((_animator.ActivePath.Duration == (ulong)MarqueeAnimationSpeed) &&
                  (_animator.ActivePath.Function == CustomAnimationFunction))))
                return;

            _animator.Stop();
            _animator.Paths = new Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.Path(0, 359, (ulong)MarqueeAnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = true;
            _animatedValue = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedStartAngle = (int)(v % 360);
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        /// The function responsible for painting the control
        /// </summary>
        /// <param name="g">The <see cref="Graphics" /> object to draw into</param>
        protected virtual void StartPaint(Graphics g)
        {
            try
            {
                lock (this)
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    var point = AddPoint(Point.Empty, 2);
                    var size = AddSize(Size, -2 * 2);
                    if (OuterWidth + OuterMargin < 0)
                    {
                        var offset = System.Math.Abs(OuterWidth + OuterMargin);
                        point = AddPoint(Point.Empty, offset);
                        size = AddSize(Size, -2 * offset);
                    }

                    if ((OuterColor != Color.Empty) && (OuterColor != Color.Transparent) && (OuterWidth != 0))
                    {
                        g.FillEllipse(new SolidBrush(OuterColor), new RectangleF(point, size));
                        if (OuterWidth >= 0)
                        {
                            point = AddPoint(point, OuterWidth);
                            size = AddSize(size, -2 * OuterWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    point = AddPoint(point, OuterMargin);
                    size = AddSize(size, -2 * OuterMargin);

                    g.FillPie(
                        new SolidBrush(ProgressColor),
                        ToRectangle(new RectangleF(point, size)),
                        _animatedStartAngle ?? StartAngle,
                        (_animatedValue ?? Value) / (Maximum - Minimum) * 360);
                    if (ProgressWidth >= 0)
                    {
                        point = AddPoint(point, ProgressWidth);
                        size = AddSize(size, -2 * ProgressWidth);
                        g.FillEllipse(_backBrush, new RectangleF(point, size));
                    }

                    point = AddPoint(point, InnerMargin);
                    size = AddSize(size, -2 * InnerMargin);

                    if ((InnerColor != Color.Empty) && (InnerColor != Color.Transparent) && (InnerWidth != 0))
                    {
                        g.FillEllipse(new SolidBrush(InnerColor), new RectangleF(point, size));
                        if (InnerWidth >= 0)
                        {
                            point = AddPoint(point, InnerWidth);
                            size = AddSize(size, -2 * InnerWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    if (Text == string.Empty)
                        return;

                    point.X += TextMargin.Left;
                    point.Y += TextMargin.Top;
                    size.Width -= TextMargin.Right;
                    size.Height -= TextMargin.Bottom;
                    var stringFormat =
                        new StringFormat(RightToLeft == RightToLeft.Yes ? StringFormatFlags.DirectionRightToLeft : 0)
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Near
                        };
                    var textSize = g.MeasureString(Text, Font);
                    var textPoint = new PointF(
                        point.X + (size.Width - textSize.Width) / 2,
                        point.Y + (size.Height - textSize.Height) / 2);
                    if ((SubscriptText != string.Empty) || (SuperscriptText != string.Empty))
                    {
                        float maxSWidth = 0;
                        var supSize = SizeF.Empty;
                        var subSize = SizeF.Empty;
                        if (SuperscriptText != string.Empty)
                        {
                            supSize = g.MeasureString(SuperscriptText, SecondaryFont);
                            maxSWidth = System.Math.Max(supSize.Width, maxSWidth);
                            supSize.Width -= SuperscriptMargin.Right;
                            supSize.Height -= SuperscriptMargin.Bottom;
                        }

                        if (SubscriptText != string.Empty)
                        {
                            subSize = g.MeasureString(SubscriptText, SecondaryFont);
                            maxSWidth = System.Math.Max(subSize.Width, maxSWidth);
                            subSize.Width -= SubscriptMargin.Right;
                            subSize.Height -= SubscriptMargin.Bottom;
                        }

                        textPoint.X -= maxSWidth / 4;
                        if (SuperscriptText != string.Empty)
                        {
                            var supPoint = new PointF(
                                textPoint.X + textSize.Width - supSize.Width / 2,
                                textPoint.Y - supSize.Height * 0.85f);
                            supPoint.X += SuperscriptMargin.Left;
                            supPoint.Y += SuperscriptMargin.Top;
                            g.DrawString(
                                SuperscriptText,
                                SecondaryFont,
                                new SolidBrush(SuperscriptColor),
                                new RectangleF(supPoint, supSize),
                                stringFormat);
                        }

                        if (SubscriptText != string.Empty)
                        {
                            var subPoint = new PointF(
                                textPoint.X + textSize.Width - subSize.Width / 2,
                                textPoint.Y + textSize.Height * 0.85f);
                            subPoint.X += SubscriptMargin.Left;
                            subPoint.Y += SubscriptMargin.Top;
                            g.DrawString(
                                SubscriptText,
                                SecondaryFont,
                                new SolidBrush(SubscriptColor),
                                new RectangleF(subPoint, subSize),
                                stringFormat);
                        }
                    }

                    g.DrawString(
                        Text,
                        Font,
                        new SolidBrush(ForeColor),
                        new RectangleF(textPoint, textSize),
                        stringFormat);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Adds the point.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="v">The v.</param>
        /// <returns>PointF.</returns>
        private static PointF AddPoint(PointF p, int v)
        {
            p.X += v;
            p.Y += v;
            return p;
        }

        /// <summary>
        /// Adds the size.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="v">The v.</param>
        /// <returns>SizeF.</returns>
        private static SizeF AddSize(SizeF s, int v)
        {
            s.Height += v;
            s.Width += v;
            return s;
        }

        /// <summary>
        /// To the rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Rectangle.</returns>
        private static Rectangle ToRectangle(RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarAwesomeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarAwesomeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarAwesomeSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarAwesomeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarAwesomeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarAwesome colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarAwesomeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarAwesomeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarAwesome;

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
        /// Gets or sets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        public bool AutoStart
        {
            get
            {
                return colUserControl.AutoStart;
            }
            set
            {
                GetPropertyByName("AutoStart").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the automatic start interval.
        /// </summary>
        /// <value>The automatic start interval.</value>
        public int AutoStartInterval
        {
            get
            {
                return colUserControl.AutoStartInterval;
            }
            set
            {
                GetPropertyByName("AutoStartInterval").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the animation function.
        /// </summary>
        /// <value>The animation function.</value>
        public Zeroit.Framework.Progress.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions AnimationFunction
        {
            get
            {
                return colUserControl.AnimationFunction;
            }
            set
            {
                GetPropertyByName("AnimationFunction").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int AnimationSpeed
        {
            get
            {
                return colUserControl.AnimationSpeed;
            }
            set
            {
                GetPropertyByName("AnimationSpeed").SetValue(colUserControl, value);
            }

        }
        /// <summary>
        /// Gets or sets the text margin.
        /// </summary>
        /// <value>The text margin.</value>
        public Padding TextMargin
        {
            get
            {
                return colUserControl.TextMargin;
            }
            set
            {
                GetPropertyByName("TextMargin").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the superscript margin.
        /// </summary>
        /// <value>The superscript margin.</value>
        public Padding SuperscriptMargin
        {
            get
            {
                return colUserControl.SuperscriptMargin;
            }
            set
            {
                GetPropertyByName("SuperscriptMargin").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the subscript margin.
        /// </summary>
        /// <value>The subscript margin.</value>
        public Padding SubscriptMargin
        {
            get
            {
                return colUserControl.SubscriptMargin;
            }
            set
            {
                GetPropertyByName("SubscriptMargin").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the inner.
        /// </summary>
        /// <value>The color of the inner.</value>
        public Color InnerColor
        {
            get
            {
                return colUserControl.InnerColor;
            }
            set
            {
                GetPropertyByName("InnerColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the inner margin.
        /// </summary>
        /// <value>The inner margin.</value>
        public int InnerMargin
        {
            get
            {
                return colUserControl.InnerMargin;
            }
            set
            {
                GetPropertyByName("InnerMargin").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the inner.
        /// </summary>
        /// <value>The width of the inner.</value>
        public int InnerWidth
        {
            get
            {
                return colUserControl.InnerWidth;
            }
            set
            {
                GetPropertyByName("InnerWidth").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the outer margin.
        /// </summary>
        /// <value>The outer margin.</value>
        public int OuterMargin
        {
            get
            {
                return colUserControl.OuterMargin;
            }
            set
            {
                GetPropertyByName("OuterMargin").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the outer.
        /// </summary>
        /// <value>The width of the outer.</value>
        public int OuterWidth
        {
            get
            {
                return colUserControl.OuterWidth;
            }
            set
            {
                GetPropertyByName("OuterWidth").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the outer.
        /// </summary>
        /// <value>The color of the outer.</value>
        public Color OuterColor
        {
            get
            {
                return colUserControl.OuterColor;
            }
            set
            {
                GetPropertyByName("OuterColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get
            {
                return colUserControl.ProgressColor;
            }
            set
            {
                GetPropertyByName("ProgressColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public int StartAngle
        {
            get
            {
                return colUserControl.StartAngle;
            }
            set
            {
                GetPropertyByName("StartAngle").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the progress.
        /// </summary>
        /// <value>The width of the progress.</value>
        public int ProgressWidth
        {
            get
            {
                return colUserControl.ProgressWidth;
            }
            set
            {
                GetPropertyByName("ProgressWidth").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the subscript text.
        /// </summary>
        /// <value>The subscript text.</value>
        public string SubscriptText
        {
            get
            {
                return colUserControl.SubscriptText;
            }
            set
            {
                GetPropertyByName("SubscriptText").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the subscript.
        /// </summary>
        /// <value>The color of the subscript.</value>
        public Color SubscriptColor
        {
            get
            {
                return colUserControl.SubscriptColor;
            }
            set
            {
                GetPropertyByName("SubscriptColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the secondary font.
        /// </summary>
        /// <value>The secondary font.</value>
        public Font SecondaryFont
        {
            get
            {
                return colUserControl.SecondaryFont;
            }
            set
            {
                GetPropertyByName("SecondaryFont").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the superscript text.
        /// </summary>
        /// <value>The superscript text.</value>
        public string SuperscriptText
        {
            get
            {
                return colUserControl.SuperscriptText;
            }
            set
            {
                GetPropertyByName("SuperscriptText").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the superscript.
        /// </summary>
        /// <value>The color of the superscript.</value>
        public Color SuperscriptColor
        {
            get
            {
                return colUserControl.SuperscriptColor;
            }
            set
            {
                GetPropertyByName("SuperscriptColor").SetValue(colUserControl, value);
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
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public ProgressBarStyle Style
        {
            get
            {
                return colUserControl.Style;
            }
            set
            {
                GetPropertyByName("Style").SetValue(colUserControl, value);
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

            //items.Add(new DesignerActionPropertyItem("BackColor",
            //                     "Back Color", "Appearance",
            //                     "Selects the background color."));

            //items.Add(new DesignerActionPropertyItem("ForeColor",
            //                     "Fore Color", "Appearance",
            //                     "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("AutoStart",
                                 "Auto Start", "Appearance",
                                 "Automatically start the progress control."));

            items.Add(new DesignerActionPropertyItem("AutoStartInterval",
                                 "Auto Start Interval", "Appearance",
                                 "Sets the timer interval when automatically started."));

            items.Add(new DesignerActionPropertyItem("AnimationFunction",
                                 "Animation Function", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("AnimationSpeed",
                                 "Animation Speed", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TextMargin",
                                 "Text Margin", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("InnerColor",
                                 "Inner Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("InnerMargin",
                                 "Inner Margin", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("InnerWidth",
                                 "Inner Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("OuterMargin",
                                 "Outer Margin", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("OuterWidth",
                                 "Outer Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("OuterColor",
                                 "Outer Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ProgressColor",
                                 "Progress Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("StartAngle",
                                 "Start Angle", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ProgressWidth",
                                 "Progress Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SubscriptText",
                                 "Subscript Text", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SubscriptColor",
                                 "Subscript Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SubscriptMargin",
                                 "Subscript Margin", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SuperscriptText",
                                 "Superscript Text", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SuperscriptColor",
                                 "Superscript Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SuperscriptMargin",
                                 "Superscript Margin", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondaryFont",
                                 "Secondary Font", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the ProgressBar."));

            items.Add(new DesignerActionPropertyItem("Style",
                                 "Style", "Appearance",
                                 "This property allows the user to set the style of the ProgressBar."));




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
