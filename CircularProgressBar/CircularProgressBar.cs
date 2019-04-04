// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CircularProgressBar.cs" company="Zeroit Dev Technologies">
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
    #region Circular ProgressBar

    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressBarCircularDesigner))]
    public class ZeroitProgressBarCircular : Control
    {

        #region Enums        
        /// <summary>
        /// Enum representing the type of circular progress.
        /// </summary>
        public enum ProgressBarShape
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
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        /// <summary>
        /// The progress color2
        /// </summary>
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        /// <summary>
        /// The fill ellipse1
        /// </summary>
        private Color _FillEllipse1 = Color.Black;
        /// <summary>
        /// The fill ellipse2
        /// </summary>
        private Color _FillEllipse2 = Color.Gray;
        /// <summary>
        /// The text color
        /// </summary>
        private Color _TextColor = Color.White;
        /// <summary>
        /// The progress color inner border
        /// </summary>
        private Color _ProgressColorInnerBorder = Color.Transparent;
        /// <summary>
        /// The progress shape value
        /// </summary>
        private ProgressBarShape ProgressShapeVal;
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
        private Double _ProgressWidth = 5f;
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
        /// The transparency
        /// </summary>
        private bool transparency = false;

        #endregion

        #region Custom Properties                
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressBarCircular" /> is transparent.
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
        /// Gets or sets a value indicating whether show text.
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
        /// Gets or sets the color of the progress inner border.
        /// </summary>
        /// <value>The color of the progress inner border.</value>
        public Color ProgressInnerBorderColor
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
        /// This changes the angle of gradient button
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
        /// Gets or sets the progress color.
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
        /// Gets or sets the color to fill ellipse.
        /// </summary>
        /// <value>The fill ellipse1.</value>
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
        /// Gets or sets the color to fill ellipse.
        /// </summary>
        /// <value>The fill ellipse2.</value>
        public Color FillEllipse2
        {
            get { return _FillEllipse2; }
            set
            {
                _FillEllipse2 = value;
                Invalidate();
            }
        }

        //public ProgressBarShape ProgressShape
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

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarCircular" /> class.
        /// </summary>
        public ZeroitProgressBarCircular()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            //SetStyle(ControlStyles.SupportsTransparentBackColor, transparency);

            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            //MinimumSize = new Size(10, 100);
            DoubleBuffered = true;
            _Smoothing = SmoothingMode.HighQuality;

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

        #region Private Methods
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

        #endregion

        #region Overrides


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
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.Clear(Color.Transparent);

                    graphics.TextRenderingHint = textrendering;
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, _ProgressWidthToFloat))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case ProgressBarShape.AnchorMask:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.ArrowAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.Custom:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.DiamondAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.Flat:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.NoAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.Round:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.RoundAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.Square:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.SquareAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case ProgressBarShape.Triangle:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                default:
                                    break;
                            }
                            try
                            {
                                graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)System.Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
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
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                        Pen BorderColor = new Pen(_ProgressColorInnerBorder, _PenWidth);
                        graphics.DrawArc(BorderColor, new Rectangle(0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1), 0f, 360f);

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

        #endregion


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






    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarCircularDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarCircularDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarCircularSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarCircularSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarCircularSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarCircular colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarCircularSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarCircularSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarCircular;

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
        /// Gets or sets the color of the progress inner border.
        /// </summary>
        /// <value>The color of the progress inner border.</value>
        public Color ProgressInnerBorderColor
        {
            get
            {
                return colUserControl.ProgressInnerBorderColor;
            }
            set
            {
                GetPropertyByName("ProgressInnerBorderColor").SetValue(colUserControl, value);
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
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
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
                                 "Sets the background color."));

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

            items.Add(new DesignerActionPropertyItem("ProgressInnerBorderColor",
                                 "Color5 ProgressInnerBorder", "Appearance",
                                 "Sets the progress inner border color."));

            items.Add(new DesignerActionPropertyItem("TextColor",
                                 "Color6 TextColor", "Appearance",
                                 "Sets the progress text color."));

            items.Add(new DesignerActionPropertyItem("ShowText",
                                 "Percentage Text", "Appearance",
                                 "Sets whether the progress text should be shown."));

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
