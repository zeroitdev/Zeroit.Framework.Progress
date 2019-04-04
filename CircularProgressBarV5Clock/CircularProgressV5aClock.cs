// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CircularProgressV5aClock.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using Microsoft.VisualBasic;
#endregion

namespace Zeroit.Framework.Progress
{
    #region CircularProgressv5aClock

    /// <summary>
    /// Class ZeroitCircularProgressBarv5Clock.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitCircularProgressBarv5Clock : UserControl
    {


        #region Include in Private Field

        /// <summary>
        /// The marquee angle
        /// </summary>
        private int marqueeAngle = 90;

        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();




        #endregion

        #region Include in Public Properties




        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            string DateTime = System.DateTime.Now.ToString("HH:mm:ss");
            string Hour = System.DateTime.Now.ToString("HH");
            string Minute = System.DateTime.Now.ToString("mm");
            string Second = System.DateTime.Now.ToString("ss");

            Bar3.Enabled = true;
            Bar2.Enabled = true;

            Bar3.Value = Convert.ToInt32(Hour) + 30;
            Bar2.Value = Convert.ToInt32(Minute);
            Bar1.Value = Convert.ToInt32(Second);

            Bar2.ActiveColor = Color.Yellow;

            Bar3.ActiveColor = Color.Red;


            DisplayPercentage = false;


            Text = DateTime.ToString();


        }



        #endregion



        #region "Declares"
        /// <summary>
        /// The minimum size allowed
        /// </summary>
        private Size minimumSizeAllowed;
        /// <summary>
        /// The minimum size
        /// </summary>
        private Size _minimumSize;
        /// <summary>
        /// The bar count
        /// </summary>
        private int _barCount = 4;
        /// <summary>
        /// The bars
        /// </summary>
        private BarData[] _bars = new BarData[5];
        /// <summary>
        /// The smooth timer
        /// </summary>
        private System.Timers.Timer _smoothTimer;
        /// <summary>
        /// The border enabled
        /// </summary>
        private bool _borderEnabled = false;
        /// <summary>
        /// The image
        /// </summary>
        private Image _image = null;
        /// <summary>
        /// The bar seperation
        /// </summary>
        private int _barSeperation = 1;
        /// <summary>
        /// The bar width
        /// </summary>
        private int _barWidth = 4;
        /// <summary>
        /// The display percentage
        /// </summary>
        private bool _displayPercentage = true;
        /// <summary>
        /// The display total percentage
        /// </summary>
        private bool _displayTotalPercentage = false;
        /// <summary>
        /// The smooth bars
        /// </summary>
        private bool _smoothBars = false;
        /// <summary>
        /// The information
        /// </summary>
        private string _info = "Data";
        /// <summary>
        /// The text shadow
        /// </summary>
        private bool _textShadow = false;
        /// <summary>
        /// The text shadow color
        /// </summary>
        private Color _textShadowColor = Color.White;
        /// <summary>
        /// The inactive color enabled
        /// </summary>
        private bool _inactiveColorEnabled = true;
        #endregion
        /// <summary>
        /// The image enabled
        /// </summary>
        private bool _imageEnabled = true;

        /// <summary>
        /// The real percentage
        /// </summary>
        float[] realPercentage;
        /// <summary>
        /// The set percentage
        /// </summary>
        float[] setPercentage;
        /// <summary>
        /// The current angle
        /// </summary>
        float[] currentAngle;
        /// <summary>
        /// The remainder angle
        /// </summary>
        float[] remainderAngle;

        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCircularProgressBarv5Clock"/> class.
        /// </summary>
        public ZeroitCircularProgressBarv5Clock()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            for (int i = 0; i <= _bars.Count() - 1; i++)
            {
                _bars[i] = new BarData(i + 1);
                _bars[i].PropertyChanged += Bars_PropertyChanged;
            }

            Size = new Size(150, 150);
            Font = new Font("Verdana", 14f);
            _smoothTimer = new System.Timers.Timer();
            _smoothTimer.Elapsed += Smoother_Tick;
            _smoothTimer.Enabled = false;
            _smoothTimer.Interval = 1;



            #region Timer
            if (DesignMode)
            {
                timer.Enabled = true;
                timer.Start();
                timer.Tick += Timer_Tick;

                timer.Interval = 100;


            }

            if (!DesignMode)
            {
                timer.Enabled = true;
                timer.Start();
                timer.Tick += Timer_Tick;

                timer.Interval = 100;
            }





            #endregion



            SetMinimumSize();
        }
        #endregion

        #region "Overrides"
        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x20;
                return cp;
            }
        }

        /// <summary>
        /// Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <value>The minimum size.</value>
        public override Size MinimumSize
        {
            get { return _minimumSize; }
            set
            {
                if (value.Height < minimumSizeAllowed.Height)
                    value.Height = minimumSizeAllowed.Height;
                if (value.Width < minimumSizeAllowed.Width)
                    value.Height = minimumSizeAllowed.Height;
                _minimumSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get { return _info; }
            set
            {
                _info = value;
                RefreshControl();
            }
        }


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
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int circleSize = _barWidth;
            realPercentage = new float[_barCount + 1];
            setPercentage = new float[_barCount + 1];
            currentAngle = new float[_barCount + 1];
            remainderAngle = new float[_barCount + 1];

            for (int i = 0; i <= _barCount; i++)
            {
                if (!_bars[i].Enabled)
                    continue;
                //setPercentage[i] = (_bars[i].SmoothValue / _bars[i].Maximum) * 100;
                //realPercentage[i] = (_bars[i].Value / _bars[i].Maximum) * 100;
                //currentAngle[i] = Convert.ToSingle(360 / 100 * setPercentage[i]);
                //remainderAngle[i] = 360 - currentAngle[i];
                //float progressAngle = Convert.ToSingle(360 / 100 * percentage);

                setPercentage[i] = _bars[i].Value * 1.68f;

                currentAngle[i] = Convert.ToSingle(360 * (setPercentage[i] / _bars[i].Maximum));

                remainderAngle[i] = 360 - Convert.ToInt32(currentAngle[i]);
            }

            Bitmap B = new Bitmap(Width, Height);

            Graphics G = e.Graphics;

            G.TextRenderingHint = textrendering;

            G.SmoothingMode = SmoothingMode.HighQuality;
            if (BackColor != Color.Transparent)
            {
                G.Clear(BackColor);
            }

            for (int i = 0; i <= _barCount; i++)
            {
                if (!_bars[i].Enabled)
                    continue;
                Color colorToUse = default(Color);
                if (_bars[i].SmoothValue >= _bars[i].Maximum)
                {
                    colorToUse = _bars[i].FinishColor;
                }
                else
                {
                    colorToUse = _bars[i].ActiveColor;
                }

                using (Pen progressPen = new Pen(colorToUse, circleSize))
                {
                    using (Pen remainderPen = new Pen(_bars[i].InactiveColor, circleSize))
                    {
                        using (Pen BorderPen = new Pen(_bars[i].BorderColor, circleSize + 2))
                        {
                            if (_borderEnabled)
                            {
                                if (_inactiveColorEnabled)
                                {
                                    G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), 0, 360);
                                }
                                else
                                {
                                    G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -marqueeAngle, currentAngle[i]);
                                }
                            }
                            G.DrawArc(progressPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -marqueeAngle, currentAngle[i]);
                            if (_inactiveColorEnabled)
                                G.DrawArc(remainderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), currentAngle[i] - marqueeAngle, remainderAngle[i]);
                        }
                    }
                }
            }

            if (Image != null)
                G.DrawImage(Image, new Point(Convert.ToInt32(Width / 2) - (Image.Width / 2), Convert.ToInt32(Height / 2) - (Image.Height / 2)));

            using (Font fnt = new Font(Font.FontFamily, Font.Size))
            {
                string textDisplay = string.Empty;

                if (_displayPercentage)
                {
                    if (_displayTotalPercentage)
                    {
                        int percentageCalculate = 0;
                        for (int i = 0; i <= _barCount; i++)
                        {
                            if (!_bars[i].Enabled)
                                continue;
                            percentageCalculate += (int)setPercentage[i];
                        }
                        percentageCalculate /= _barCount;
                        textDisplay += percentageCalculate.ToString() + "%";
                    }
                    else
                    {
                        for (int i = 0; i <= _barCount; i++)
                        {
                            if (!_bars[i].Enabled)
                                continue;
                            if (textDisplay == string.Empty)
                            {
                                textDisplay += setPercentage[i].ToString() + "%";
                            }
                            else
                            {
                                textDisplay += Constants.vbNewLine + setPercentage[i].ToString() + "%";
                            }
                        }
                    }
                }
                else
                {
                    textDisplay = _info;
                }
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                Rectangle textRect = new Rectangle(0, 0, Width, Height);
                if (_textShadow)
                {
                    Rectangle textRectShadow = new Rectangle(1, 1, Width, Height);
                    G.DrawString(textDisplay, fnt, new SolidBrush(_textShadowColor), textRectShadow, stringFormat);
                }
                G.DrawString(textDisplay, fnt, new SolidBrush(ForeColor), textRect, stringFormat);
            }
            e.Graphics.DrawImageUnscaled(B, 0, 0);


        }

        #region Public Properties
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [DisplayName("BackColor")]
        [Description("Gets or Sets the enabled value of the back color to use.")]
        [Category("Bar Info")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                RefreshControl();
            }
        }


        #region "Properties"
        /// <summary>
        /// Gets or sets the bar1.
        /// </summary>
        /// <value>The bar1.</value>
        [DisplayName("Bar #1")]
        [Description("Bar #1 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar1
        {
            get { return _bars[0]; }
            set { _bars[0] = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar2.
        /// </summary>
        /// <value>The bar2.</value>
        [DisplayName("Bar #2")]
        [Description("Bar #2 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar2
        {
            get { return _bars[1]; }
            set { _bars[1] = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar3.
        /// </summary>
        /// <value>The bar3.</value>
        [DisplayName("Bar #3")]
        [Description("Bar #3 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar3
        {
            get { return _bars[2]; }
            set { _bars[2] = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar4.
        /// </summary>
        /// <value>The bar4.</value>
        [DisplayName("Bar #4")]
        [Description("Bar #4 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar4
        {
            get { return _bars[3]; }
            set { _bars[3] = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the bar5.
        /// </summary>
        /// <value>The bar5.</value>
        [DisplayName("Bar #5")]
        [Description("Bar #5 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar5
        {
            get { return _bars[4]; }
            set { _bars[4] = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the seperation.
        /// </summary>
        /// <value>The seperation.</value>
        [DefaultValue(1)]
        [DisplayName("Bar Seperation")]
        [Description("Gets or Sets the bar seperation value. This is the amount in pixels the distance between each bar defined.")]
        [Category("Bar Info")]
        public int Seperation
        {
            get { return _barSeperation; }
            set
            {
                if (value < 0)
                    value = 0;
                _barSeperation = value;

                SetMinimumSize();

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the bar.
        /// </summary>
        /// <value>The width of the bar.</value>
        [DefaultValue(4)]
        [DisplayName("Bar Width")]
        [Description("Gets or Sets the bar width. This is the actual bar width, per bar.")]
        [Category("Bar Info")]
        public int BarWidth
        {
            get { return _barWidth; }
            set
            {
                _barWidth = value;

                SetMinimumSize();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display percentage].
        /// </summary>
        /// <value><c>true</c> if [display percentage]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [DisplayName("Display Percentages")]
        [Description("Gets or Sets the display of bar percentages. This will display a percentage per bar displayed.")]
        [Category("Bar Info")]
        public bool DisplayPercentage
        {
            get { return _displayPercentage; }
            set
            {
                _displayPercentage = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display total percentage].
        /// </summary>
        /// <value><c>true</c> if [display total percentage]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [DisplayName("Display Total Percentage")]
        [Description("Gets or Sets the display of a total percentage. This will calculate all the bars and display only one percentage.")]
        [Category("Bar Info")]
        public bool DisplayTotalPercentage
        {
            get { return _displayTotalPercentage; }
            set
            {
                _displayTotalPercentage = value;
                RefreshControl();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [smooth bars].
        /// </summary>
        /// <value><c>true</c> if [smooth bars]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [DisplayName("Smooth Bars")]
        [Description("Gets or Sets if the bars will increment in a smooth motion. This is good if your values change heavier and you want a smooth look to them.")]
        [Category("Bar Info")]
        public bool SmoothBars
        {
            get { return _smoothBars; }
            set
            {
                _smoothBars = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [DefaultValue("Data")]
        [DisplayName("Text Data")]
        [Description("Gets or Sets the text when percentages is not enabled. This will display a set text (that can be edited at runtime) rather then percentages if 'Display Percentages' is disabled.")]
        [Category("Appearance")]
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text shadow].
        /// </summary>
        /// <value><c>true</c> if [text shadow]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [DisplayName("Text Shadow")]
        [Description("Gets or Sets there will be text shadowing.")]
        [Category("Appearance")]
        public bool TextShadow
        {
            get { return _textShadow; }
            set
            {
                _textShadow = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text shadow.
        /// </summary>
        /// <value>The color of the text shadow.</value>
        [DefaultValue(typeof(Color), "Color.White")]
        [DisplayName("Text Shadow Color")]
        [Description("Gets or Sets the color of text shadowing. This requires the Text Shadow boolean to be true.")]
        [Category("Appearance")]
        public Color TextShadowColor
        {
            get { return _textShadowColor; }
            set
            {
                _textShadowColor = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [DefaultValue("Nothing")]
        [DisplayName("Image")]
        [Description("Gets or Sets the bar image. This will display a bar image in the middle of the bar.")]
        [Category("Bar Info")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [border enabled].
        /// </summary>
        /// <value><c>true</c> if [border enabled]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [DisplayName("Borders Enabled")]
        [Description("Gets or Sets the enabled value of the border around the bar.")]
        [Category("Bar Info")]
        public bool BorderEnabled
        {
            get { return _borderEnabled; }
            set
            {
                _borderEnabled = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [inactive color enabled].
        /// </summary>
        /// <value><c>true</c> if [inactive color enabled]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [DisplayName("Inactive Colors Enabled")]
        [Description("Gets or Sets the enabled value of the inactive colors. If this is disabled, then the inactive bars won't be displayed.")]
        [Category("Bar Info")]
        public bool InactiveColorEnabled
        {
            get { return _inactiveColorEnabled; }
            set
            {
                _inactiveColorEnabled = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [image enabled].
        /// </summary>
        /// <value><c>true</c> if [image enabled]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [DisplayName("Image Enabled")]
        [Description("Gets or Sets the enabled value of the image. If this is disabled, the image will not be rendered.")]
        [Category("Bar Info")]
        public bool ImageEnabled
        {
            get { return _imageEnabled; }
            set
            {
                _imageEnabled = value;
                RefreshControl();
            }
        }
        #endregion

        #endregion
        #endregion

        #region "Subs/Functions"
        /// <summary>
        /// Handles the Tick event of the Smoother control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void Smoother_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            bool allDone = true;
            for (int i = 0; i <= _barCount; i++)
            {
                if (_bars[i].Value > _bars[i].SmoothValue)
                {
                    _bars[i].SmoothValue += _bars[i].SmoothAmount;
                    if (_bars[i].SmoothValue > _bars[i].Value)
                        _bars[i].SmoothValue = _bars[i].Value;
                    allDone = false;
                }
                else if (_bars[i].Value < _bars[i].SmoothValue)
                {
                    _bars[i].SmoothValue -= _bars[i].SmoothAmount;
                    if (_bars[i].SmoothValue < _bars[i].Value)
                        _bars[i].SmoothValue = _bars[i].Value;
                    allDone = false;
                }
            }
            if (allDone)
                _smoothTimer.Enabled = false;
        }

        /// <summary>
        /// Refreshes the control.
        /// </summary>
        private void RefreshControl()
        {
            Invalidate();
        }

        /// <summary>
        /// Shoulds the serialize bars.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBars()
        {
            return (_bars != null);
        }

        /// <summary>
        /// Resets the bars.
        /// </summary>
        public void ResetBars()
        {
            for (int i = 0; i <= _bars.Count() - 1; i++)
            {
                _bars[i] = new BarData(i);
                _bars[i].PropertyChanged += Bars_PropertyChanged;
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Bars control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        private void Bars_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Enabled")
                SetMinimumSize();
            if (e.PropertyName == "Value")
            {
                if (_smoothBars == true)
                {
                    _smoothTimer.Enabled = true;
                }
                else
                {
                    BarData bar = (BarData)sender;
                    bar.SmoothValue = bar.Value;
                }
            }
            RefreshControl();
        }

        /// <summary>
        /// Sets the minimum size.
        /// </summary>
        private void SetMinimumSize()
        {
            int bCount = 0;
            for (int i = _bars.Count() - 1; i >= 0; i += -1)
            {
                if (_bars[i].Enabled)
                {
                    bCount = i + 1;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            int minSize = (bCount + 1) * (_barWidth + _barSeperation) * 2;
            minimumSizeAllowed = new Size(minSize, minSize);
            MinimumSize = minimumSizeAllowed;
            int width = Size.Width;
            int height = Size.Width;
            if (width < minSize)
                width = minSize;
            if (height < minSize)
                height = minSize;
            Size = new Size(width, height);
        }
        #endregion



    }

    #endregion
}
