#region Imports

//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarUnique

    //#region ProgressIndicator
    ///// <summary>
    ///// Firefox like circular progress indicator.
    ///// </summary>
    //public class ZeroitProgressBarUnique : Control
    //{
    //    #region Constructor

    //    /// <summary>
    //    /// Default constructor for the ProgressIndicator.
    //    /// </summary>
    //    public ZeroitProgressBarUnique()
    //    {
    //        //InitializeComponent1();
    //        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    //        SetStyle(ControlStyles.ResizeRedraw, true);
    //        SetStyle(ControlStyles.SupportsTransparentBackColor, true);

    //        if (AutoStart)
    //            timerAnimation1.Start();
    //    }

    //    #endregion

    //    #region Private Fields

    //    private int _value = 1;

    //    private int _interval = 100;

    //    private Color _circleColor = Color.FromArgb(20, 20, 20);

    //    private System.Windows.Forms.Timer timerAnimation1 = new System.Windows.Forms.Timer();

    //    private bool _autoStart;

    //    private bool _stopped = true;

    //    private float _circleSize = 0.2F;

    //    private int _numberOfCircles = 500;

    //    private int _numberOfVisibleCircles = 100;

    //    private RotationType1 _rotation = RotationType1.Clockwise;

    //    private float _percentage;

    //    private bool _showPercentage;

    //    private bool _showText;

    //    private TextDisplayModes _textDisplay = TextDisplayModes.None;

    //    #endregion

    //    #region Public Properties

    //    /// <summary>
    //    /// Gets or sets the base color for the circles.
    //    /// </summary>
    //    [DefaultValue(typeof(Color), "20, 20, 20")]
    //    [Description("Gets or sets the base color for the circles.")]
    //    [Category("Appearance")]
    //    public Color CircleColor
    //    {
    //        get { return _circleColor; }
    //        set
    //        {
    //            _circleColor = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the animation should start automatically.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the animation should start automatically.")]
    //    [Category("Behavior")]
    //    public bool AutoStart
    //    {
    //        get { return _autoStart; }
    //        set
    //        {
    //            _autoStart = value;

    //            if (_autoStart && !DesignMode)
    //                Start();
    //            else
    //                Stop();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the scale for the circles raging from 0.1 to 1.0.
    //    /// </summary>
    //    [DefaultValue(1.0F)]
    //    [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0.")]
    //    [Category("Appearance")]
    //    public float CircleSize
    //    {
    //        get { return _circleSize; }
    //        set
    //        {
    //            if (value <= 0.0F)
    //                _circleSize = 0.1F;
    //            else
    //                _circleSize = value > 1.0F ? 1.0F : value;

    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the animation speed.
    //    /// </summary>
    //    [DefaultValue(100)]
    //    [Description("Gets or sets the animation speed.")]
    //    [Category("Behavior")]
    //    public int AnimationSpeed
    //    {
    //        get { return (-_interval + 400) / 4; }
    //        set
    //        {
    //            checked
    //            {
    //                int interval = 400 - (value * 4);

    //                if (interval < 10)
    //                    _interval = 10;
    //                else
    //                    _interval = interval > 400 ? 400 : interval;

    //                timerAnimation1.Interval = _interval;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the number of circles used in the animation.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
    //    [DefaultValue(8)]
    //    [Description("Gets or sets the number of circles used in the animation.")]
    //    [Category("Behavior")]
    //    public int NumberOfCircles
    //    {
    //        get { return _numberOfCircles; }
    //        set
    //        {
    //            if (value <= 0)
    //                throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");

    //            _numberOfCircles = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the number of circles used in the animation.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
    //    [DefaultValue(8)]
    //    [Description("Gets or sets the number of circles used in the animation.")]
    //    [Category("Behavior")]
    //    public int NumberOfVisibleCircles
    //    {
    //        get { return _numberOfVisibleCircles; }
    //        set
    //        {
    //            if (value <= 0 || value > _numberOfCircles)
    //                throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer and less than or equal to the number of circles.");

    //            _numberOfVisibleCircles = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.
    //    /// </summary>
    //    [DefaultValue(RotationType1.Clockwise)]
    //    [Description("Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.")]
    //    [Category("Behavior")]
    //    public RotationType1 Rotation
    //    {
    //        get { return _rotation; }
    //        set { _rotation = value; }
    //    }

    //    /// <summary>
    //    /// Gets or sets the percentage to show on the control.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
    //    [DefaultValue(0)]
    //    [Description("Gets or sets the percentage to show on the control.")]
    //    [Category("Appearance")]
    //    public float Percentage
    //    {
    //        get { return _percentage; }
    //        set
    //        {
    //            if (value < 0 || value > 100)
    //                throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

    //            _percentage = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the percentage value should be shown.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the percentage value should be shown.")]
    //    [Category("Behavior")]
    //    public bool ShowPercentage
    //    {
    //        get { return _showPercentage; }
    //        set
    //        {
    //            _showPercentage = value;

    //            _textDisplay = _showPercentage
    //                               ? _textDisplay | TextDisplayModes.Percentage
    //                               : _textDisplay & ~TextDisplayModes.Percentage;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the control text should be shown.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the control text should be shown.")]
    //    [Category("Behavior")]
    //    public bool ShowText
    //    {
    //        get { return _showText; }
    //        set
    //        {
    //            _showText = value;

    //            _textDisplay = _showText
    //                               ? _textDisplay | TextDisplayModes.Text
    //                               : _textDisplay & ~TextDisplayModes.Text;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the property that will be shown in the control.
    //    /// </summary>
    //    [DefaultValue(TextDisplayModes.None)]
    //    [Description("Gets or sets the property that will be shown in the control.")]
    //    [Category("Appearance")]
    //    public TextDisplayModes TextDisplay
    //    {
    //        get { return _textDisplay; }
    //        set
    //        {
    //            _textDisplay = value;

    //            _showText = (_textDisplay & TextDisplayModes.Text) == TextDisplayModes.Text;
    //            _showPercentage = (_textDisplay & TextDisplayModes.Percentage) == TextDisplayModes.Percentage;
    //            Invalidate();
    //        }
    //    }

    //    #endregion

    //    #region Public Methods

    //    /// <summary>
    //    /// Starts the animation.
    //    /// </summary>
    //    public void Start()
    //    {
    //        timerAnimation1.Interval = _interval;
    //        _stopped = false;
    //        timerAnimation1.Start();
    //    }

    //    /// <summary>
    //    /// Stops the animation.
    //    /// </summary>
    //    public void Stop()
    //    {
    //        timerAnimation1.Stop();
    //        _value = 1;
    //        _stopped = true;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region Overrides

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        float angle = 360.0F / _numberOfCircles;

    //        GraphicsState oldState = e.Graphics.Save();

    //        e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
    //        e.Graphics.RotateTransform(angle * _value * (int)_rotation);
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        for (int i = 1; i <= _numberOfCircles; i++)
    //        {
    //            int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
    //            int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

    //            Color drawColor = Color.FromArgb(alpha, _circleColor);

    //            using (SolidBrush brush = new SolidBrush(drawColor))
    //            {
    //                float sizeRate = 4.5F / _circleSize;
    //                float size = Width / sizeRate;

    //                float diff = (Width / 4.5F) - size;

    //                float x = (Width / 9.0F) + diff;
    //                float y = (Height / 9.0F) + diff;
    //                e.Graphics.FillEllipse(brush, x, y, size, size);
    //                e.Graphics.RotateTransform(angle * (int)_rotation);
    //            }
    //        }

    //        e.Graphics.Restore(oldState);

    //        string percent = GetDrawText();

    //        if (!string.IsNullOrEmpty(percent))
    //        {
    //            SizeF textSize = e.Graphics.MeasureString(percent, Font);
    //            float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
    //            float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
    //            StringFormat format = new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            };

    //            RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);


    //            using (SolidBrush textBrush = new SolidBrush(ForeColor))
    //            {
    //                e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
    //            }
    //        }

    //        base.OnPaint(e);
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        SetNewSize();
    //        base.OnResize(e);
    //    }

    //    protected override void OnSizeChanged(EventArgs e)
    //    {
    //        SetNewSize();
    //        base.OnSizeChanged(e);
    //    }

    //    #endregion

    //    #region Private Methods

    //    private string GetDrawText()
    //    {
    //        string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

    //        if (_showText && _showPercentage)
    //            return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

    //        if (_showText)
    //            return Text;

    //        if (_showPercentage)
    //            return percent;

    //        return string.Empty;
    //    }

    //    private void SetNewSize()
    //    {
    //        int size = System.Math.Max(Width, Height);
    //        Size = new Size(size, size);
    //    }

    //    private void IncreaseValue()
    //    {
    //        if (_value + 1 <= _numberOfCircles)
    //            _value++;
    //        else
    //            _value = 1;
    //    }

    //    #endregion

    //    #region Timer

    //    //private void timerAnimation1_Tick(object sender, EventArgs e)
    //    //{
    //    //    if (!DesignMode)
    //    //    {
    //    //        IncreaseValue();
    //    //        Invalidate();
    //    //    }
    //    //}

    //    #endregion
    //}

    //#endregion
    //#region RotationType
    ///// <summary>
    ///// An enum used to indicate the rotational direction of the control.
    ///// </summary>
    //public enum RotationType1
    //{
    //    /// <summary>
    //    /// Indicates that the rotation should move clockwise.
    //    /// </summary>
    //    Clockwise = 1,
    //    /// <summary>
    //    /// Indicates that the rotation should move counter-clockwise.
    //    /// </summary>
    //    CounterClockwise = -1,
    //}
    //#endregion
    //#region TextDisplayModes
    ///// <summary>
    ///// This enum is used to choose what text should be shown in the control.
    ///// </summary>
    //[Flags]
    //public enum TextDisplayMode1
    //{
    //    /// <summary>
    //    /// No text will be shown by the control.
    //    /// </summary>
    //    None = 0,

    //    /// <summary>
    //    /// The control will show the value of the Percentage property.
    //    /// </summary>
    //    Percentage = 1,

    //    /// <summary>
    //    /// The control will show the value of the Text property.
    //    /// </summary>
    //    Text = 2,

    //    /// <summary>
    //    /// The control will show the values of the Text and Percentage properties.
    //    /// </summary>
    //    Both = Percentage | Text
    //}
    //#endregion
    //#region ProgressIndicator.designer.cs
    //partial class ZeroitProgressIndicatorUnique
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private static System.ComponentModel.IContainer components1 = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    //protected override void Dispose(bool disposing)
    //    //{
    //    //    if (disposing && (components1 != null))
    //    //    {
    //    //        components1.Dispose();
    //    //    }
    //    //    base.Dispose(disposing);
    //    //}

    //    #region Component Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify 
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    public void InitializeComponent1()
    //    {
    //        components1 = new System.ComponentModel.Container();
    //        timerAnimation1 = new System.Windows.Forms.Timer(components1);
    //        this.SuspendLayout();
    //        // 
    //        // timerAnimation
    //        // 
    //        timerAnimation1.Tick += new System.EventHandler(timerAnimation1_Tick);
    //        // 
    //        // ProgressIndicator
    //        // 
    //        Size = new System.Drawing.Size(90, 90);
    //        ResumeLayout(false);

    //    }

    //    //private static void timerAnimation1_Tick(object sender, EventArgs e)
    //    //{

    //    //    for (int x = 0; x >= 1; x++)
    //    //    {
    //    //        timerAnimation1.Start();
    //    //    }
    //    //}

    //    private void timerAnimation1_Tick(object sender, EventArgs e)
    //    {
    //        if (!DesignMode)
    //        {
    //            IncreaseValue();
    //            Invalidate();
    //        }
    //    }

    //    #endregion

    //    private static System.Windows.Forms.Timer timerAnimation1;
    //}

    //#endregion

    #endregion
}
