// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressBarPie.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarPie    
    /// <summary>
    /// A class collection for rendering a pie progress control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressBarPieDesigner))]
    public class ZeroitProgressBarPie : Control
    {

        #region Enums

        /// <summary>
        /// Enum representing the shape of the progress.
        /// </summary>
        public enum ShapeOfProgress
        {
            /// <summary>
            /// The anchor mask
            /// </summary>
            AnchorMask,
            /// <summary>
            /// The arrow anchor
            /// </summary>
            ArrowAnchor,
            /// <summary>
            /// The custom
            /// </summary>
            Custom,
            /// <summary>
            /// The diamond anchor
            /// </summary>
            DiamondAnchor,
            /// <summary>
            /// The flat
            /// </summary>
            Flat,
            /// <summary>
            /// The no anchor
            /// </summary>
            NoAnchor,
            /// <summary>
            /// The round
            /// </summary>
            Round,
            /// <summary>
            /// The round anchor
            /// </summary>
            RoundAnchor,
            /// <summary>
            /// The square
            /// </summary>
            Square,
            /// <summary>
            /// The square anchor
            /// </summary>
            SquareAnchor,
            /// <summary>
            /// The triangle
            /// </summary>
            Triangle
        }

        #endregion

        #region Variables

        /// <summary>
        /// The value
        /// </summary>
        private long _Value;
        /// <summary>
        /// The maximum
        /// </summary>
        private long _Maximum = 100;
        /// <summary>
        /// The progress color1
        /// </summary>
        private Color _ProgressColor1 = Color.DarkSlateGray;
        /// <summary>
        /// The progress color2
        /// </summary>
        private Color _ProgressColor2 = Color.DarkOrange;
        /// <summary>
        /// The fill ellipse1
        /// </summary>
        private Color _FillEllipse1 = Color.Transparent;
        /// <summary>
        /// The fill ellipse2
        /// </summary>
        private Color _FillEllipse2 = Color.Transparent;
        /// <summary>
        /// The text color
        /// </summary>
        private Color _TextColor = Color.Transparent;
        /// <summary>
        /// The progress color inner border
        /// </summary>
        private Color _ProgressColorInnerBorder = Color.Transparent;
        /// <summary>
        /// The progress shape value
        /// </summary>
        private ShapeOfProgress ProgressShapeVal;
        /// <summary>
        /// The start
        /// </summary>
        private LineCap _Start = LineCap.Flat;
        /// <summary>
        /// The end
        /// </summary>
        private LineCap _End = LineCap.Flat;
        /// <summary>
        /// The progress width
        /// </summary>
        private Double _ProgressWidth = 1f;
        /// <summary>
        /// The pen width
        /// </summary>
        private float _PenWidth = 1f;
        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode _Smoothing = SmoothingMode.HighQuality;
        /// <summary>
        /// The progress width to float
        /// </summary>
        private float _ProgressWidthToFloat;
        /// <summary>
        /// The show text
        /// </summary>
        private bool _showText = true;

        /// <summary>
        /// The position
        /// </summary>
        private float position = 180.0f;
        /// <summary>
        /// The sweep angle
        /// </summary>
        private float sweepAngle = 180.0f;

        #endregion

        #region Custom Properties        
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public float Position
        {
            get { return position; }
            set
            {
                position = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the sweep angle.
        /// </summary>
        /// <value>The sweep angle.</value>
        public float SweepAngle
        {
            get { return sweepAngle; }
            set
            {
                sweepAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show text.
        /// </summary>
        /// <value><c>true</c> if show text; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return this._showText; }
            set
            {
                if (value == false)
                {
                    this._TextColor = Color.Transparent;
                }

                else
                {
                    this._TextColor = Color.White;
                }
                this._showText = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the progress inner border.
        /// </summary>
        /// <value>The width of the progress inner border.</value>
        public float ProgressInnerBorderWidth
        {
            get { return this._PenWidth; }
            set
            {
                if (value > 5)
                {
                    value = 5;
                }
                this._PenWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return this._Smoothing; }
            set
            {
                this._Smoothing = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress inner border.
        /// </summary>
        /// <value>The progress inner border.</value>
        public Color ProgressInnerBorder
        {
            get { return this._ProgressColorInnerBorder; }
            set
            {
                this._ProgressColorInnerBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return this._TextColor; }
            set
            {
                this._TextColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress width start cap.
        /// </summary>
        /// <value>The progress width start cap.</value>
        public LineCap ProgressWidthStartCap
        {
            get { return this._Start; }
            set
            {
                if (_Start == null)
                {
                    _Start = LineCap.Flat;
                }
                this._Start = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress width end cap.
        /// </summary>
        /// <value>The progress width end cap.</value>
        public LineCap ProgressWidthEndCap
        {
            get { return this._End; }
            set
            {
                if (_End == null)
                {
                    _End = LineCap.Flat;
                }
                this._End = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This changes the angle of gradient
        /// </summary>
        /// <value>The width of the progress.</value>
        [Description("This changes the angle of gradient button"),
        Category("Appearance"),
        Browsable(true)]
        public Double ProgressWidth
        {
            get { return this._ProgressWidth; }
            set
            {
                if (_ProgressWidth == null)
                {
                    this._ProgressWidth = 5f;
                }

                this._ProgressWidth = value;
                _ProgressWidthToFloat = DoubleToFloat(_ProgressWidth);

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color.
        /// </summary>
        /// <value>The progress color1.</value>
        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color2.
        /// </summary>
        /// <value>The progress color2.</value>
        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the circle.
        /// </summary>
        /// <value>The color1 of the circle.</value>
        public Color FillEllipse1
        {
            get { return _FillEllipse1; }
            set
            {
                _FillEllipse1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the circle.
        /// </summary>
        /// <value>The color2 of the circle.</value>
        public Color FillEllipse2
        {
            get { return _FillEllipse2; }
            set
            {
                _FillEllipse2 = value;
                Invalidate();
            }
        }

        //public ShapeOfProgress ProgressShape
        //{
        //    get { return ProgressShapeVal; }
        //    set
        //    {
        //        ProgressShapeVal = value;
        //        Invalidate();
        //    }
        //}


        /// <summary>
        /// Doubles to float.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <returns>System.Single.</returns>
        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="p">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        /// <summary>
        /// The transparency
        /// </summary>
        private bool transparency = false;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressBarPie" /> is transparent.
        /// </summary>
        /// <value><c>true</c> if transparent; otherwise, <c>false</c>.</value>
        public bool Transparent
        {
            get { return transparency; }
            set
            {
                transparency = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarPie" /> class.
        /// </summary>
        public ZeroitProgressBarPie()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            //SetStyle(ControlStyles.SupportsTransparentBackColor, transparency);
            BackColor = Color.Transparent;
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            //MinimumSize = new Size(10, 100);
            DoubleBuffered = true;
            _Smoothing = SmoothingMode.HighQuality;


            #region Zeroit AutoStart Code (Work in Progress)
            timerAnimation.Tick += new System.EventHandler(timerAnimation_Tick);
            if (AutoStart)
                timerAnimation.Start();
            #endregion

            #region Zeroit AutoStartSpinner Code (Work in Progress)
            timerAnimationAutoSpin.Tick += new System.EventHandler(timerAnimationAutoSpin_Tick);
            if (AutoStartSpinner)
                timerAnimationAutoSpin.Start();
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
        /// The timer animation
        /// </summary>
        private System.Windows.Forms.Timer timerAnimation = new System.Windows.Forms.Timer();
        /// <summary>
        /// The timer animation automatic spin
        /// </summary>
        private System.Windows.Forms.Timer timerAnimationAutoSpin = new System.Windows.Forms.Timer();
        /// <summary>
        /// The enabletime
        /// </summary>
        private bool enabletime;
        /// <summary>
        /// The enable automatic spin
        /// </summary>
        private bool enableAutoSpin;
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
        /// Gets or sets the automatic spin start interval.
        /// </summary>
        /// <value>The automatic spin start interval.</value>
        public int AutoSpinStartInterval
        {
            get { return _autoStartInterval; }
            set
            {
                _autoStartInterval = value;
                timerAnimationAutoSpin.Interval = _autoStartInterval;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
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
        /// Gets or sets a value indicating whether [automatic start spinner].
        /// </summary>
        /// <value><c>true</c> if [automatic start spinner]; otherwise, <c>false</c>.</value>
        public bool AutoStartSpinner
        {
            get { return enableAutoSpin; }
            set
            {
                if (value == true)
                {
                    timerAnimationAutoSpin.Enabled = true;
                }

                else
                {
                    timerAnimationAutoSpin.Enabled = false;
                    this.position = 180f;
                    //this.Text = Value.ToString();
                }

                enableAutoSpin = value;
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

        /// <summary>
        /// Handles the Tick event of the timerAnimationAutoSpin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timerAnimationAutoSpin_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    Value += 1;
                    //Value = 100;
                    position += 10;
                    //Text = Value.ToString();

                    if (Value == Maximum)
                    {

                        Value = 0;
                        position = 0;
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
                    position += 10;
                    //Text = Value.ToString();

                    if (Value == Maximum)
                    {
                        Value = 0;
                        position = 0;
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
        /// Sets the size of the standard.
        /// </summary>
        private void SetStandardSize()
        {
            int _Size = System.Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        /// <summary>
        /// Increments the specified value.
        /// </summary>
        /// <param name="Val">The value.</param>
        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        /// <summary>
        /// Decrements the specified value.
        /// </summary>
        /// <param name="Val">The value.</param>
        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.Clear(Color.Transparent);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, _ProgressWidthToFloat))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case ShapeOfProgress.AnchorMask:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.ArrowAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.Custom:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.DiamondAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.Flat:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.NoAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.Round:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.RoundAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.Square:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.SquareAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ShapeOfProgress.Triangle:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                default:
                                    break;
                            }
                            try
                            {
                                graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, position, (int)System.Math.Round((double)((sweepAngle / ((double)this._Maximum)) * this._Value)));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Add this code to the form constructor:  SetStyle(ControlStyles.SupportsTransparentBackColor, true);");
                                throw;
                            }

                        }
                    }
                    //using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0x34, 0x34, 0x34), Color.FromArgb(0x34, 0x34, 0x34), LinearGradientMode.Vertical))
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, _FillEllipse1, _FillEllipse2, LinearGradientMode.Vertical))
                    {
                        graphics.FillPie(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1, position, sweepAngle);
                        Pen BorderColor = new Pen(_ProgressColorInnerBorder, _PenWidth);
                        graphics.DrawArc(BorderColor, new Rectangle(0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1), position /*90f*//*sweepAngle / 2*/, sweepAngle);

                    }
                    SolidBrush TexTColor = new SolidBrush(_TextColor);
                    SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, TexTColor, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));


                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarPieDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarPieDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarPieSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarPieSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarPieSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarPie colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarPieSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarPieSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarPie;

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
        /// Gets or sets the progress color1.
        /// </summary>
        /// <value>The progress color1.</value>
        public Color ProgressColor1
        {
            get
            {
                return colUserControl.ProgressColor1;
            }
            set
            {
                GetPropertyByName("ProgressColor1").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the progress color2.
        /// </summary>
        /// <value>The progress color2.</value>
        public Color ProgressColor2
        {
            get
            {
                return colUserControl.ProgressColor2;
            }
            set
            {
                GetPropertyByName("ProgressColor2").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the fill ellipse1.
        /// </summary>
        /// <value>The fill ellipse1.</value>
        public Color FillEllipse1
        {
            get
            {
                return colUserControl.FillEllipse1;
            }
            set
            {
                GetPropertyByName("FillEllipse1").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the fill ellipse2.
        /// </summary>
        /// <value>The fill ellipse2.</value>
        public Color FillEllipse2
        {
            get
            {
                return colUserControl.FillEllipse2;
            }
            set
            {
                GetPropertyByName("FillEllipse2").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the progress inner border.
        /// </summary>
        /// <value>The progress inner border.</value>
        public Color ProgressInnerBorder
        {
            get
            {
                return colUserControl.ProgressInnerBorder;
            }
            set
            {
                GetPropertyByName("ProgressInnerBorder").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get
            {
                return colUserControl.TextColor;
            }
            set
            {
                GetPropertyByName("TextColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public float Position
        {
            get
            {
                return colUserControl.Position;
            }
            set
            {
                GetPropertyByName("Position").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the sweep angle.
        /// </summary>
        /// <value>The sweep angle.</value>
        public float SweepAngle
        {
            get
            {
                return colUserControl.SweepAngle;
            }
            set
            {
                GetPropertyByName("SweepAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the show text.
        /// </summary>
        /// <value>The show text.</value>
        public Boolean ShowText
        {
            get
            {
                return colUserControl.ShowText;
            }
            set
            {
                GetPropertyByName("ShowText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the progress inner border.
        /// </summary>
        /// <value>The width of the progress inner border.</value>
        public float ProgressInnerBorderWidth
        {
            get
            {
                return colUserControl.ProgressInnerBorderWidth;
            }
            set
            {
                GetPropertyByName("ProgressInnerBorderWidth").SetValue(colUserControl, value);
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
        /// Gets or sets the progress width start cap.
        /// </summary>
        /// <value>The progress width start cap.</value>
        public LineCap ProgressWidthStartCap
        {
            get
            {
                return colUserControl.ProgressWidthStartCap;
            }
            set
            {
                GetPropertyByName("ProgressWidthStartCap").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress width end cap.
        /// </summary>
        /// <value>The progress width end cap.</value>
        public LineCap ProgressWidthEndCap
        {
            get
            {
                return colUserControl.ProgressWidthEndCap;
            }
            set
            {
                GetPropertyByName("ProgressWidthEndCap").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the progress.
        /// </summary>
        /// <value>The width of the progress.</value>
        public Double ProgressWidth
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
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
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public long Maximum
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
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
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
        /// Gets or sets a value indicating whether [automatic start spinner].
        /// </summary>
        /// <value><c>true</c> if [automatic start spinner]; otherwise, <c>false</c>.</value>
        public bool AutoStartSpinner
        {
            get
            {
                return colUserControl.AutoStartSpinner;
            }
            set
            {
                GetPropertyByName("AutoStartSpinner").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("ShowText",
                                 "Percentage Text", "Appearance",
                                 "Sets whether the progress text should be shown."));

            items.Add(new DesignerActionPropertyItem("AutoStart",
                                 "Auto Start", "Appearance",
                                 "Sets the control to autostart."));

            items.Add(new DesignerActionPropertyItem("AutoStartSpinner",
                                 "Auto Start Spinner", "Appearance",
                                 "Sets the control to spin automatically."));

            items.Add(new DesignerActionPropertyItem("AutoStartInterval",
                                 "Auto Start Interval", "Appearance",
                                 "Sets the animation speed."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the Font of the text."));

            items.Add(new DesignerActionPropertyItem("ProgressColor1",
                                 "Color1 Progress", "Appearance",
                                 "Sets the progress color."));

            items.Add(new DesignerActionPropertyItem("ProgressColor2",
                                 "Color2 Progress", "Appearance",
                                 "Sets the progress color."));

            items.Add(new DesignerActionPropertyItem("FillEllipse1",
                                 "Color3 FillEllipse", "Appearance",
                                 "Sets the progress inner fill color."));

            items.Add(new DesignerActionPropertyItem("FillEllipse2",
                                 "Color4 FillEllipse", "Appearance",
                                 "Sets the progress inner fill color."));

            items.Add(new DesignerActionPropertyItem("ProgressInnerBorder",
                                 "Color5 ProgressInnerBorder", "Appearance",
                                 "Sets the progress inner border color."));

            items.Add(new DesignerActionPropertyItem("TextColor",
                                 "Color6 TextColor", "Appearance",
                                 "Sets the progress text color."));

            items.Add(new DesignerActionPropertyItem("Position",
                                 "Position", "Appearance",
                                 "Sets the location."));

            items.Add(new DesignerActionPropertyItem("SweepAngle",
                                 "Sweep Angle", "Appearance",
                                 "Sets the start angle."));

            items.Add(new DesignerActionPropertyItem("ProgressInnerBorderWidth",
                                 "Progress Inner Border Width", "Appearance",
                                 "Sets border width of the progress control."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets smoothing mode."));

            items.Add(new DesignerActionPropertyItem("ProgressWidthStartCap",
                                 "Progress Width Start Cap", "Appearance",
                                 "Sets start cap of the progress control."));

            items.Add(new DesignerActionPropertyItem("ProgressWidthEndCap",
                                 "Progress Width End Cap", "Appearance",
                                 "Sets end cap of the progress control."));

            items.Add(new DesignerActionPropertyItem("ProgressWidth",
                                 "ProgressWidth", "Appearance",
                                 "Sets width of the progress control."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the progress control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets maximum value to be reached."));



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
