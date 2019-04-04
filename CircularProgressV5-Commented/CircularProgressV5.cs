#region Imports

//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region CircularProgressv5

    //[TypeConverter(typeof(ExpandableObjectConverter))]
    //public class BarData
    //{

    //    #region Declares
    //    private int _barID;
    //    private bool _enabled = false;
    //    private int _smoothAmount = 1;
    //    private int _smoothValue = 0;
    //    private int _value = 0;
    //    private int _maximum = 100;
    //    private Color _borderColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
    //    private Color _finishColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
    //    private Color _activeColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
    //    private Color _inactiveColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
    //    #endregion

    //    #region Events

    //    #endregion

    //    #region Constructor
    //    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
    //    public BarData(int barID)
    //    {
    //        // VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
    //        _borderColor = Color.Black;
    //        _finishColor = Color.LightGreen;
    //        _activeColor = Color.LightSeaGreen;
    //        _inactiveColor = Color.LightGray;

    //        _barID = barID;
    //        if (_barID == 1)
    //        {
    //            Enabled = true;
    //        }
    //    }

    //    public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;


    //    //event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
    //    //{
    //    //    add
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }

    //    //    remove
    //    //    {
    //    //        throw new NotImplementedException();
    //    //    }
    //    //}
    //    #endregion

    //    #region Overrides
    //    public override string ToString()
    //    {
    //        return "Data #" + System.Convert.ToString(_barID);
    //    }
    //    #endregion

    //    #region Properties
    //    [DefaultValue(false)]
    //    [DisplayName("Enabled")]
    //    [Description("Gets or Sets the enabled value of the bar. If the bar is enabled, then the bar will be visible.")]
    //    public bool Enabled
    //    {
    //        get
    //        {
    //            return _enabled;
    //        }
    //        set
    //        {
    //            if (_barID == 1)
    //            {
    //                value = true;
    //            }
    //            _enabled = value;

    //        }
    //    }
    //    [DefaultValue(1)]
    //    [DisplayName("Smooth Amount")]
    //    [Description("Gets or Sets the smooth amount per timer tick. The higher this is, the less smooth it will look, but the faster it will go. Setting it lower will feel more smooth, but may take too long.")]
    //    public int SmoothAmount
    //    {
    //        get
    //        {
    //            return _smoothAmount;
    //        }
    //        set
    //        {
    //            _smoothAmount = value;

    //        }
    //    }

    //    internal int SmoothValue
    //    {
    //        get
    //        {
    //            return _smoothValue;
    //        }
    //        set
    //        {
    //            if (value < 0)
    //            {
    //                value = 0;
    //            }
    //            if (value > _maximum)
    //            {
    //                value = _maximum;
    //            }
    //            _smoothValue = value;

    //        }
    //    }

    //    [DefaultValue(0)]
    //    [DisplayName("Value")]
    //    [Description("Gets or Sets the value. The value cannot be higher then maximum, and less then 0.")]
    //    public int Value
    //    {
    //        get
    //        {
    //            return _value;
    //        }
    //        set
    //        {
    //            if (value < 0)
    //            {
    //                value = 0;
    //            }
    //            if (value > _maximum)
    //            {
    //                value = _maximum;
    //            }
    //            _value = value;

    //        }
    //    }

    //    [DefaultValue(100)]
    //    [DisplayName("Maximum")]
    //    [Description("Gets or Sets the maximum value. The value cannot lower then 1.")]
    //    public int Maximum
    //    {
    //        get
    //        {
    //            return _maximum;
    //        }
    //        set
    //        {
    //            if (value < 1)
    //            {
    //                value = 1;
    //            }
    //            if (_value > value)
    //            {
    //                _smoothValue = value;
    //                _value = value;
    //            }
    //            _maximum = value;

    //        }
    //    }

    //    [DefaultValue(typeof(Color), "Color.Black")]
    //    [DisplayName("Border Color")]
    //    [Description("Gets or Sets the border color. This is the color for the border itself aroudn the bar.")]
    //    public Color BorderColor
    //    {
    //        get
    //        {
    //            return _borderColor;
    //        }
    //        set
    //        {
    //            _borderColor = value;

    //        }
    //    }

    //    [DefaultValue(typeof(Color), "Color.LightGreen")]
    //    [DisplayName("Finish Color")]
    //    [Description("Gets or Sets the finish color. This is the color of the bar when the bar value is equal to maximum value.")]
    //    public Color FinishColor
    //    {
    //        get
    //        {
    //            return _finishColor;
    //        }
    //        set
    //        {
    //            _finishColor = value;

    //        }
    //    }

    //    [DefaultValue(typeof(Color), "Color.LightSeaGreen")]
    //    [DisplayName("Active Color")]
    //    [Description("Gets or Sets the active color. This is the color of the active portion of the bar while not complete.")]
    //    public Color ActiveColor
    //    {
    //        get
    //        {
    //            return _activeColor;
    //        }
    //        set
    //        {
    //            _activeColor = value;

    //        }
    //    }

    //    [DefaultValue(typeof(Color), "Color.LightGray")]
    //    [DisplayName("Inactive Color")]
    //    [Description("Gets or Sets the inactive color. This is the color of the inactive portion of the bar while not complete.")]
    //    public Color InactiveColor
    //    {
    //        get
    //        {
    //            return _inactiveColor;
    //        }
    //        set
    //        {
    //            _inactiveColor = value;

    //        }
    //    }
    //    #endregion

    //    #region Subs
    //    public void Increment(int amount)
    //    {
    //        Value += amount;
    //    }

    //    public void Decrement(int amount)
    //    {
    //        Value -= amount;
    //    }

    //    public void Reset()
    //    {
    //        Value = 0;
    //    }

    //    public void Max()
    //    {
    //        Value = Maximum;
    //    }
    //    #endregion

    //}

    //public class CircularProgressBar : UserControl
    //{

    //    #region Declares
    //    private Size minimumSizeAllowed;
    //    private Size _minimumSize;
    //    private int _barCount = 4;
    //    private BarData[] _bars = new BarData[5];
    //    private System.Timers.Timer _smoothTimer;
    //    private bool _borderEnabled = false;
    //    private Image _image = null;
    //    private int _barSeperation = 1;
    //    private int _barWidth = 4;
    //    private bool _displayPercentage = true;
    //    private bool _displayTotalPercentage = false;
    //    private bool _smoothBars = false;
    //    private string _info = "Data";
    //    private bool _textShadow = false;
    //    private Color _textShadowColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
    //    private bool _inactiveColorEnabled = true;
    //    private bool _imageEnabled = true;
    //    #endregion

    //    #region Constructor
    //    public CircularProgressBar()
    //    {
    //        // VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
    //        _textShadowColor = Color.White;

    //        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //        SetStyle(ControlStyles.ResizeRedraw, true);
    //        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //        SetStyle(ControlStyles.SupportsTransparentBackColor, true);

    //        for (int i = 0; i <= _bars.Count() - 1; i++)
    //        {
    //            _bars[i] = new BarData(i + 1);
    //            //_bars[i].PropertyChanged += Bars_PropertyChanged;
    //        }

    //        Size = new Size(150, 150);
    //        Font = new Font("Verdana", (float)(14.0F));
    //        _smoothTimer = new System.Timers.Timer();
    //        _smoothTimer.Elapsed += Smoother_Tick;
    //        _smoothTimer.Enabled = false;
    //        _smoothTimer.Interval = 1;
    //        SetMinimumSize();
    //    }
    //    #endregion

    //    #region Overrides
    //    protected override System.Windows.Forms.CreateParams CreateParams
    //    {
    //        get
    //        {
    //            CreateParams cp = base.CreateParams;
    //            cp.ExStyle = 0x20;
    //            return cp;
    //        }
    //    }

    //    public override Size MinimumSize
    //    {
    //        get
    //        {
    //            return _minimumSize;
    //        }
    //        set
    //        {
    //            if (value.Height < minimumSizeAllowed.Height)
    //            {
    //                value.Height = minimumSizeAllowed.Height;
    //            }
    //            if (value.Width < minimumSizeAllowed.Width)
    //            {
    //                value.Height = minimumSizeAllowed.Height;
    //            }
    //            _minimumSize = value;
    //        }
    //    }

    //    public override string Text
    //    {
    //        get
    //        {
    //            return _info;
    //        }
    //        set
    //        {
    //            _info = value;
    //            RefreshControl();
    //        }
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);
    //        int circleSize = _barWidth;
    //        float[] realPercentage = new float[_barCount + 1];
    //        float[] setPercentage = new float[_barCount + 1];
    //        float[] currentAngle = new float[_barCount + 1];
    //        float[] remainderAngle = new float[_barCount + 1];
    //        for (int i = 0; i <= _barCount; i++)
    //        {
    //            if (!_bars[i].Enabled)
    //            {
    //                continue;
    //            }
    //            setPercentage[i] = (float)(((double)_bars[i].SmoothValue / _bars[i].Maximum) * 100);
    //            realPercentage[i] = (float)(((double)_bars[i].Value / _bars[i].Maximum) * 100);
    //            currentAngle[i] = (float)((double)360 / 100 * setPercentage[i]);
    //            remainderAngle[i] = 360 - currentAngle[i];
    //        }

    //        Bitmap B = new Bitmap(Width, Height);

    //        Graphics G = e.Graphics;

    //        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //        if (BackColor != Color.Transparent)
    //        {
    //            G.Clear(BackColor);
    //        }

    //        for (int i = 0; i <= _barCount; i++)
    //        {
    //            if (!_bars[i].Enabled)
    //            {
    //                continue;
    //            }
    //            Color colorToUse = new Color();
    //            if (_bars[i].SmoothValue >= _bars[i].Maximum)
    //            {
    //                colorToUse = _bars[i].FinishColor;
    //            }
    //            else
    //            {
    //                colorToUse = _bars[i].ActiveColor;
    //            }

    //            using (Pen progressPen = new Pen(colorToUse, circleSize))
    //            {
    //                using (Pen remainderPen = new Pen(_bars[i].InactiveColor, circleSize))
    //                {
    //                    using (Pen BorderPen = new Pen(_bars[i].BorderColor, circleSize + 2))
    //                    {
    //                        if (_borderEnabled)
    //                        {
    //                            if (_inactiveColorEnabled)
    //                            {
    //                                G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), 0, 360);
    //                            }
    //                            else
    //                            {
    //                                G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -90, System.Convert.ToInt32(currentAngle[i]));
    //                            }
    //                        }
    //                        G.DrawArc(progressPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -90, System.Convert.ToInt32(currentAngle[i]));
    //                        if (_inactiveColorEnabled)
    //                        {
    //                            G.DrawArc(remainderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), System.Convert.ToInt32(currentAngle[i] - 90), System.Convert.ToInt32(remainderAngle[i]));
    //                        }
    //                    }
    //                }
    //            }



    //            if (Image != null)
    //            {
    //                G.DrawImage(Image, new Point(System.Convert.ToInt32((System.Convert.ToInt32((double)Width / 2)) - ((double)Image.Width / 2)), System.Convert.ToInt32((System.Convert.ToInt32((double)Height / 2)) - ((double)Image.Height / 2))));
    //            }

    //            using (Font fnt = new Font(Font.FontFamily, Font.Size))
    //            {
    //                string textDisplay = string.Empty;

    //                if (_displayPercentage)
    //                {
    //                    if (_displayTotalPercentage)
    //                    {
    //                        int percentageCalculate = 0;
    //                        for (int a = 0; a <= _barCount; a++)
    //                        {
    //                            if (!_bars[i].Enabled)
    //                            {
    //                                continue;
    //                            }
    //                            percentageCalculate += System.Convert.ToInt32(realPercentage[a]);
    //                        }
    //                        percentageCalculate /= _barCount;
    //                        textDisplay += percentageCalculate.ToString() + "%";
    //                    }
    //                    else
    //                    {
    //                        for (int b = 0; b <= _barCount; b++)
    //                        {
    //                            if (!_bars[b].Enabled)
    //                            {
    //                                continue;
    //                            }
    //                            if (textDisplay == string.Empty)
    //                            {
    //                                textDisplay += realPercentage[i].ToString() + "%";
    //                            }
    //                            else
    //                            {
    //                                textDisplay += Constants.vbNewLine + (realPercentage[b].ToString() + "%");
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    textDisplay = _info;
    //                }
    //                StringFormat stringFormat = new StringFormat();
    //                stringFormat.Alignment = StringAlignment.Center;
    //                stringFormat.LineAlignment = StringAlignment.Center;

    //                Rectangle textRect = new Rectangle(0, 0, Width, Height);
    //                if (_textShadow)
    //                {
    //                    Rectangle textRectShadow = new Rectangle(1, 1, Width, Height);
    //                    G.DrawString(textDisplay, fnt, new SolidBrush(_textShadowColor), textRectShadow, stringFormat);
    //                }
    //                G.DrawString(textDisplay, fnt, new SolidBrush(ForeColor), textRect, stringFormat);
    //            }

    //            //e.Graphics.DrawImageUnscaled(B, 0, 0);


    //        }

    //    }

    //    [DisplayName("BackColor")]
    //    [Description("Gets or Sets the enabled value of the back color to use.")]
    //    [Category("Bar Info")]
    //    public override Color BackColor
    //    {
    //        get
    //        {
    //            return base.BackColor;
    //        }
    //        set
    //        {
    //            base.BackColor = value;
    //            RefreshControl();
    //        }
    //    }
    //    #endregion

    //    #region Properties
    //    [DisplayName("Bar #1")]
    //    [Description("Bar #1 Data")]
    //    [Category("Bars")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //    public BarData Bar1
    //    {
    //        get
    //        {
    //            return _bars[0];
    //        }
    //        set
    //        {
    //            _bars[0] = value;
    //        }
    //    }

    //    [DisplayName("Bar #2")]
    //    [Description("Bar #2 Data")]
    //    [Category("Bars")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //    public BarData Bar2
    //    {
    //        get
    //        {
    //            return _bars[1];
    //        }
    //        set
    //        {
    //            _bars[1] = value;
    //        }
    //    }

    //    [DisplayName("Bar #3")]
    //    [Description("Bar #3 Data")]
    //    [Category("Bars")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //    public BarData Bar3
    //    {
    //        get
    //        {
    //            return _bars[2];
    //        }
    //        set
    //        {
    //            _bars[2] = value;
    //        }
    //    }

    //    [DisplayName("Bar #4")]
    //    [Description("Bar #4 Data")]
    //    [Category("Bars")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //    public BarData Bar4
    //    {
    //        get
    //        {
    //            return _bars[3];
    //        }
    //        set
    //        {
    //            _bars[3] = value;
    //        }
    //    }

    //    [DisplayName("Bar #5")]
    //    [Description("Bar #5 Data")]
    //    [Category("Bars")]
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    //    public BarData Bar5
    //    {
    //        get
    //        {
    //            return _bars[2];
    //        }
    //        set
    //        {
    //            _bars[2] = value;
    //        }
    //    }

    //    [DefaultValue(1)]
    //    [DisplayName("Bar Seperation")]
    //    [Description("Gets or Sets the bar seperation value. This is the amount in pixels the distance between each bar defined.")]
    //    [Category("Bar Info")]
    //    public int Seperation
    //    {
    //        get
    //        {
    //            return _barSeperation;
    //        }
    //        set
    //        {
    //            if (value < 0)
    //            {
    //                value = 0;
    //            }
    //            _barSeperation = value;
    //            RefreshControl();
    //            SetMinimumSize();
    //        }
    //    }

    //    [DefaultValue(4)]
    //    [DisplayName("Bar Width")]
    //    [Description("Gets or Sets the bar width. This is the actual bar width, per bar.")]
    //    [Category("Bar Info")]
    //    public int BarWidth
    //    {
    //        get
    //        {
    //            return _barWidth;
    //        }
    //        set
    //        {
    //            _barWidth = value;
    //            RefreshControl();
    //            SetMinimumSize();
    //        }
    //    }

    //    [DefaultValue(true)]
    //    [DisplayName("Display Percentages")]
    //    [Description("Gets or Sets the display of bar percentages. This will display a percentage per bar displayed.")]
    //    [Category("Bar Info")]
    //    public bool DisplayPercentage
    //    {
    //        get
    //        {
    //            return _displayPercentage;
    //        }
    //        set
    //        {
    //            _displayPercentage = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(false)]
    //    [DisplayName("Display Total Percentage")]
    //    [Description("Gets or Sets the display of a total percentage. This will calculate all the bars and display only one percentage.")]
    //    [Category("Bar Info")]
    //    public bool DisplayTotalPercentage
    //    {
    //        get
    //        {
    //            return _displayTotalPercentage;
    //        }
    //        set
    //        {
    //            _displayTotalPercentage = value;
    //            RefreshControl();
    //        }
    //    }
    //    [DefaultValue(false)]
    //    [DisplayName("Smooth Bars")]
    //    [Description("Gets or Sets if the bars will increment in a smooth motion. This is good if your values change heavier and you want a smooth look to them.")]
    //    [Category("Bar Info")]
    //    public bool SmoothBars
    //    {
    //        get
    //        {
    //            return _smoothBars;
    //        }
    //        set
    //        {
    //            _smoothBars = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue("Data")]
    //    [DisplayName("Text Data")]
    //    [Description("Gets or Sets the text when percentages is not enabled. This will display a set text (that can be edited at runtime) rather then percentages if 'Display Percentages' is disabled.")]
    //    [Category("Appearance")]
    //    public string Info
    //    {
    //        get
    //        {
    //            return _info;
    //        }
    //        set
    //        {
    //            _info = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(false)]
    //    [DisplayName("Text Shadow")]
    //    [Description("Gets or Sets there will be text shadowing.")]
    //    [Category("Appearance")]
    //    public bool TextShadow
    //    {
    //        get
    //        {
    //            return _textShadow;
    //        }
    //        set
    //        {
    //            _textShadow = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(typeof(Color), "Color.White")]
    //    [DisplayName("Text Shadow Color")]
    //    [Description("Gets or Sets the color of text shadowing. This requires the Text Shadow boolean to be true.")]
    //    [Category("Appearance")]
    //    public Color TextShadowColor
    //    {
    //        get
    //        {
    //            return _textShadowColor;
    //        }
    //        set
    //        {
    //            _textShadowColor = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue("Nothing")]
    //    [DisplayName("Image")]
    //    [Description("Gets or Sets the bar image. This will display a bar image in the middle of the bar.")]
    //    [Category("Bar Info")]
    //    public Image Image
    //    {
    //        get
    //        {
    //            return _image;
    //        }
    //        set
    //        {
    //            _image = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(false)]
    //    [DisplayName("Borders Enabled")]
    //    [Description("Gets or Sets the enabled value of the border around the bar.")]
    //    [Category("Bar Info")]
    //    public bool BorderEnabled
    //    {
    //        get
    //        {
    //            return _borderEnabled;
    //        }
    //        set
    //        {
    //            _borderEnabled = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(true)]
    //    [DisplayName("Inactive Colors Enabled")]
    //    [Description("Gets or Sets the enabled value of the inactive colors. If this is disabled, then the inactive bars won't be displayed.")]
    //    [Category("Bar Info")]
    //    public bool InactiveColorEnabled
    //    {
    //        get
    //        {
    //            return _inactiveColorEnabled;
    //        }
    //        set
    //        {
    //            _inactiveColorEnabled = value;
    //            RefreshControl();
    //        }
    //    }

    //    [DefaultValue(true)]
    //    [DisplayName("Image Enabled")]
    //    [Description("Gets or Sets the enabled value of the image. If this is disabled, the image will not be rendered.")]
    //    [Category("Bar Info")]
    //    public bool ImageEnabled
    //    {
    //        get
    //        {
    //            return _imageEnabled;
    //        }
    //        set
    //        {
    //            _imageEnabled = value;
    //            RefreshControl();
    //        }
    //    }
    //    #endregion

    //    #region Subs/Functions
    //    private void Smoother_Tick(object source, System.Timers.ElapsedEventArgs e)
    //    {
    //        bool allDone = true;
    //        for (int i = 0; i <= _barCount; i++)
    //        {
    //            if (_bars[i].Value > _bars[i].SmoothValue)
    //            {
    //                _bars[i].SmoothValue += _bars[i].SmoothAmount;
    //                if (_bars[i].SmoothValue > _bars[i].Value)
    //                {
    //                    _bars[i].SmoothValue = _bars[i].Value;
    //                }
    //                allDone = false;
    //            }
    //            else if (_bars[i].Value < _bars[i].SmoothValue)
    //            {
    //                _bars[i].SmoothValue -= _bars[i].SmoothAmount;
    //                if (_bars[i].SmoothValue < _bars[i].Value)
    //                {
    //                    _bars[i].SmoothValue = _bars[i].Value;
    //                }
    //                allDone = false;
    //            }
    //        }
    //        if (allDone)
    //        {
    //            _smoothTimer.Enabled = false;
    //        }
    //    }

    //    private void RefreshControl()
    //    {
    //        Invalidate();
    //    }

    //    public bool ShouldSerializeBars()
    //    {
    //        return !(ReferenceEquals(_bars, null));
    //    }

    //    public void ResetBars()
    //    {
    //        for (int i = 0; i <= _bars.Count() - 1; i++)
    //        {
    //            _bars[i] = new BarData(i + 1);
    //            _bars[i].PropertyChanged += Bars_PropertyChanged;
    //        }
    //    }

    //    [System.ComponentModel.Browsable(false)]
    //    [EditorBrowsable(EditorBrowsableState.Never)]
    //    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    //    private void Bars_PropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //        if (e.PropertyName == "Enabled")
    //        {
    //            SetMinimumSize();
    //        }
    //        if (e.PropertyName == "Value")
    //        {
    //            if (_smoothBars == true)
    //            {
    //                _smoothTimer.Enabled = true;
    //            }
    //            else
    //            {
    //                BarData bar = (BarData)sender;
    //                bar.SmoothValue = bar.Value;
    //            }
    //        }
    //        RefreshControl();
    //    }

    //    private void SetMinimumSize()
    //    {
    //        int bCount = 0;
    //        for (int i = _bars.Count() - 1; i >= 0; i--)
    //        {
    //            if (_bars[i].Enabled)
    //            {
    //                bCount = i + 1;
    //                break;
    //            }
    //        }

    //        int minSize = (bCount + 1) * (_barWidth + _barSeperation) * 2;
    //        minimumSizeAllowed = new Size(minSize, minSize);
    //        MinimumSize = minimumSizeAllowed;
    //        int width = Size.Width;
    //        int height = Size.Width;
    //        if (width < minSize)
    //        {
    //            width = minSize;
    //        }
    //        if (height < minSize)
    //        {
    //            height = minSize;
    //        }
    //        Size = new Size(width, height);
    //    }
    //    #endregion

    //}



    #endregion
}
