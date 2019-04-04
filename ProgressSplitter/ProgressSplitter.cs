// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressSplitter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms.Design;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{


    #region SmartProgressBar

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
    [Designer(typeof(ZeroitProgressSplitterDesinger), typeof(IDesigner))]
    public class ZeroitProgressSplitter : Label
    {
        #region Private Fields
        /// <summary>
        /// The m maximum bar width
        /// </summary>
        private const int m_MaxBarWidth = 20;
        /// <summary>
        /// The m maximum bar space
        /// </summary>
        private const int m_MaxBarSpace = 10;

        /// <summary>
        /// The m value
        /// </summary>
        private int m_Value = 0;
        /// <summary>
        /// The m maximum
        /// </summary>
        private int m_Maximum = 100;

        /// <summary>
        /// The m progress bar block width
        /// </summary>
        private int m_ProgressBarBlockWidth = 6;
        /// <summary>
        /// The m progress bar block space
        /// </summary>
        private int m_ProgressBarBlockSpace = 1;
        /// <summary>
        /// The m progress bar percent
        /// </summary>
        private bool m_ProgressBarPercent = true;
        /// <summary>
        /// The m progress bar margin offset
        /// </summary>
        private bool m_ProgressBarMarginOffset = true;

        /// <summary>
        /// The m progress bar border style
        /// </summary>
        private SplitterBorderStyle m_ProgressBarBorderStyle = SplitterBorderStyle.Flat;
        /// <summary>
        /// The m progress bar fill brush
        /// </summary>
        private SolidBrush m_ProgressBarFillBrush;

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
        /// Gets or sets a value indicating whether to automatically animate the control.
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
                this.Value = 0;
            else
                this.Value++;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressSplitter" /> class.
        /// </summary>
        public ZeroitProgressSplitter()
        {
            m_ProgressBarFillBrush = new SolidBrush(Color.Coral);

            base.BackColor = Color.White;
            base.ForeColor = Color.Blue;

            base.AutoSize = false;  // AutoSize is Designer Attribute
            base.TextAlign = ContentAlignment.MiddleCenter;   // TextAlign is Designer Attribute

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

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Label" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    // release managed resource
                }
                m_ProgressBarFillBrush.Dispose();  // release unmanaged resource
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region  custom or modified properties        
        /// <summary>
        /// Gets or sets the progress bar fill color.
        /// </summary>
        /// <value>The progress bar fill color.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar fill color.")]
        [DefaultValue(typeof(Color), "Coral")]
        public Color ProgressBarFillColor
        {
            get
            {
                return m_ProgressBarFillBrush.Color;
            }

            set
            {
                if (m_ProgressBarFillBrush.Color != value)
                {
                    m_ProgressBarFillBrush.Color = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the small progress bar block.
        /// </summary>
        /// <value>The width of the small progress bar block.</value>
        [Category("Custom")]
        [Description("Set/Get progress small bar width.")]
        [DefaultValue(6)]
        public int ProgressBarBlockWidth
        {
            get { return m_ProgressBarBlockWidth; }
            set
            {
                if (m_ProgressBarBlockWidth != value)
                {
                    if (value < 1)
                    {
                        m_ProgressBarBlockWidth = 1;
                    }
                    else if (value > m_MaxBarWidth)
                    {
                        m_ProgressBarBlockWidth = m_MaxBarWidth;
                    }
                    else
                    {
                        m_ProgressBarBlockWidth = value;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the progress bar space width.
        /// </summary>
        /// <value>The progress bar space width.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar space width(smooth when 0).")]
        [DefaultValue(1)]
        public int ProgressBarBlockSpace
        {
            get { return m_ProgressBarBlockSpace; }
            set
            {
                if (m_ProgressBarBlockSpace != value)
                {
                    if (value < 0)
                    {
                        m_ProgressBarBlockSpace = 0;
                    }
                    else if (value > m_MaxBarSpace)
                    {
                        m_ProgressBarBlockSpace = m_MaxBarSpace;
                    }
                    else
                    {
                        m_ProgressBarBlockSpace = value;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the progress bar boder style.
        /// </summary>
        /// <value>The progress bar boder style.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar boder style.")]
        [DefaultValue(typeof(SplitterBorderStyle), "Flat")]
        public SplitterBorderStyle ProgressBarBoderStyle
        {
            get { return m_ProgressBarBorderStyle; }
            set
            {
                if (m_ProgressBarBorderStyle != value)
                {
                    m_ProgressBarBorderStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show progress bar percent.
        /// </summary>
        /// <value><c>true</c> if show percent; otherwise, <c>false</c>.</value>
        [Category("Custom")]
        [Description("Set/Get show percent text or not.")]
        [DefaultValue(true)]
        public bool ShowPercent
        {
            get { return m_ProgressBarPercent; }
            set
            {
                if (m_ProgressBarPercent != value)
                {
                    m_ProgressBarPercent = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether progress bar margin offset.
        /// </summary>
        /// <value><c>true</c> if progress bar margin offset; otherwise, <c>false</c>.</value>
        [Category("Custom")]
        [Description("Set/Get if progress bar has margin offset.")]
        [DefaultValue(true)]
        public bool ProgressBarMarginOffset
        {
            get { return m_ProgressBarMarginOffset; }
            set
            {
                if (m_ProgressBarMarginOffset != value)
                {
                    m_ProgressBarMarginOffset = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar background color.")]
        [DefaultValue(typeof(Color), "White")]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (base.BackColor != value)
                {
                    base.BackColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar text color.")]
        [DefaultValue(typeof(Color), "Blue")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (base.ForeColor != value)
                {
                    base.ForeColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar maximum value.")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return m_Maximum; }
            set
            {
                if (m_Maximum != value)
                {
                    if (value < 1)
                    {
                        m_Maximum = 1;
                    }
                    else
                    {
                        m_Maximum = value;
                    }
                    if (m_Maximum < m_Value)
                    {
                        m_Value = m_Maximum;
                    }

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Custom")]
        [Description("Set/Get progress bar current value.")]
        [DefaultValue(0)]
        public int Value
        {
            get { return m_Value; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > m_Maximum)
                {
                    m_Value = m_Maximum;
                }
                else
                {
                    m_Value = value;
                }

                this.Invalidate();
                this.Update();
            }
        }

        #endregion

        #region disable base properties

        /// <summary>
        /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the <see cref="T:System.Windows.Forms.Label" />, denoting that the <see cref="T:System.Windows.Forms.Label" /> text extends beyond the specified length of the <see cref="T:System.Windows.Forms.Label" />.
        /// </summary>
        /// <value><c>true</c> if [automatic ellipsis]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AutoEllipsis
        {
            get { return base.AutoEllipsis; }
        }

        /// <summary>
        /// Gets or sets the alignment of text in the label.
        /// </summary>
        /// <value>The text align.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.
        /// </summary>
        /// <value><c>true</c> if [causes validation]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation
        {
            get { return base.CausesValidation; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if [allow drop]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
        }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get { return base.Padding; }
        }

        /// <summary>
        /// Gets or sets the Input Method Editor (IME) mode supported by this control.
        /// </summary>
        /// <value>The IME mode.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can tab to the <see cref="T:System.Windows.Forms.Label" />. This property is not used by this class.
        /// </summary>
        /// <value><c>true</c> if [tab stop]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return base.TabStop; }
        }

        /// <summary>
        /// Gets or sets a value that determines whether to use the <see cref="T:System.Drawing.Graphics" /> class (GDI+) or the <see cref="T:System.Windows.Forms.TextRenderer" /> class (GDI) to render text.
        /// </summary>
        /// <value><c>true</c> if [use compatible text rendering]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseCompatibleTextRendering
        {
            get { return base.UseCompatibleTextRendering; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control interprets an ampersand character (&amp;) in the control's <see cref="P:System.Windows.Forms.Control.Text" /> property to be an access key prefix character.
        /// </summary>
        /// <value><c>true</c> if [use mnemonic]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseMnemonic
        {
            get { return base.UseMnemonic; }
        }

        /// <summary>
        /// Gets or sets the border style for the control.
        /// </summary>
        /// <value>The border style.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
        }

        /// <summary>
        /// Gets or sets the flat style appearance of the label control.
        /// </summary>
        /// <value>The flat style.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
        }

        /// <summary>
        /// Gets or sets the image that is displayed on a <see cref="T:System.Windows.Forms.Label" />.
        /// </summary>
        /// <value>The image.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new Image Image
        {
            get { return base.Image; }
        }

        /// <summary>
        /// Gets or sets the alignment of an image that is displayed in the control.
        /// </summary>
        /// <value>The image align.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Drawing.ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
        }

        /// <summary>
        /// Gets or sets the index value of the image displayed on the <see cref="T:System.Windows.Forms.Label" />.
        /// </summary>
        /// <value>The index of the image.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new int ImageIndex
        {
            get { return base.ImageIndex; }
        }

        /// <summary>
        /// Gets or sets the key accessor for the image in the <see cref="P:System.Windows.Forms.Label.ImageList" />.
        /// </summary>
        /// <value>The image key.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string ImageKey
        {
            get { return base.ImageKey; }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ImageList" /> that contains the images to display in the <see cref="T:System.Windows.Forms.Label" /> control.
        /// </summary>
        /// <value>The image list.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageList ImageList
        {
            get { return base.ImageList; }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            get { return base.Text; }
        }


        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawPrgressBarBorder(e.Graphics);
            this.DrawProgressBar(e.Graphics);

            if (m_ProgressBarPercent)
            {
                base.Text = ((double)m_Value / (double)m_Maximum).ToString("##0 %");
            }
            else
            {
                base.Text = string.Empty;
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Gets the top off set.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetTopOffSet()
        {
            if (!m_ProgressBarMarginOffset)  // use no margin
            {
                if (m_ProgressBarBorderStyle == SplitterBorderStyle.Sunken || m_ProgressBarBorderStyle == SplitterBorderStyle.Flat)
                {
                    return 2;
                }
                else if (m_ProgressBarBorderStyle == SplitterBorderStyle.None)
                {
                    return 0;
                }
                return 1;
            }
            else  // use margin
            {
                if (m_ProgressBarBorderStyle == SplitterBorderStyle.Flat || m_ProgressBarBorderStyle == SplitterBorderStyle.Sunken)
                {
                    return 3;
                }
                else if (m_ProgressBarBorderStyle == SplitterBorderStyle.None)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Gets the left off set.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetLeftOffSet()
        {
            if (!m_ProgressBarMarginOffset)
            {
                if (m_ProgressBarBorderStyle == SplitterBorderStyle.Flat)
                {
                    return 2;
                }
                else if (m_ProgressBarBorderStyle == SplitterBorderStyle.None)
                {
                    return 0;
                }
                return 1;
            }
            else
            {
                if (m_ProgressBarBorderStyle == SplitterBorderStyle.Flat || m_ProgressBarBorderStyle == SplitterBorderStyle.Sunken)
                {
                    return 3;
                }
                else if (m_ProgressBarBorderStyle == SplitterBorderStyle.None)
                {
                    return 1;
                }
                return 2;
            }
        }

        /// <summary>
        /// Draws the progress bar.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawProgressBar(Graphics g)
        {
            decimal percent = (decimal)m_Value / (decimal)m_Maximum;

            int valueWidth = (int)((this.ClientRectangle.Width - this.GetLeftOffSet() * 2) * percent);  // width corresponds to Value
            int oneBlockWidth = m_ProgressBarBlockWidth + m_ProgressBarBlockSpace;  // bar width + space width
            int blockWidth = (valueWidth / oneBlockWidth) * (oneBlockWidth);  // width corresponds to real blocks

            if (percent > 0.99m)  // add block length to avoid trunc error
            {
                if (this.ClientRectangle.Width - this.GetLeftOffSet() * 2 - blockWidth > 0)
                {
                    blockWidth += (this.ClientRectangle.Width - this.GetLeftOffSet() * 2 - blockWidth) / (oneBlockWidth);
                }
            }

            int left = this.ClientRectangle.Left + this.GetLeftOffSet();
            int top = this.ClientRectangle.Top + this.GetTopOffSet();
            int height = this.ClientRectangle.Height - this.GetTopOffSet() * 2;

            int drawnBlockWidth = oneBlockWidth;
            while (drawnBlockWidth <= blockWidth)
            {
                g.FillRectangle(m_ProgressBarFillBrush, left, top, m_ProgressBarBlockWidth, height);
                left += oneBlockWidth;
                drawnBlockWidth += oneBlockWidth;
            }

            // below code used to draw the tail part.

            int tailBarWidth = this.ClientRectangle.Width - left - this.GetLeftOffSet();
            if (tailBarWidth > 0 && tailBarWidth < oneBlockWidth)  // tail is not a full bar
            {
                drawnBlockWidth = this.ClientRectangle.Width - left - this.GetLeftOffSet();
                if (drawnBlockWidth > 0)
                {
                    g.FillRectangle(m_ProgressBarFillBrush, left, top, drawnBlockWidth, height);  // draw partial bar
                }
            }
        }

        /// <summary>
        /// Draws the prgress bar border.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawPrgressBarBorder(Graphics g)
        {
            if (this.m_ProgressBarBorderStyle == SplitterBorderStyle.Single)
            {
                ControlPaint.DrawBorder(g, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            }
            else if (this.m_ProgressBarBorderStyle == SplitterBorderStyle.Flat)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Flat);
            }
            else if (this.m_ProgressBarBorderStyle == SplitterBorderStyle.Sunken)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Sunken);
            }
            else if (this.m_ProgressBarBorderStyle == SplitterBorderStyle.SunkenInner)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenInner);
            }
            else if (this.m_ProgressBarBorderStyle == SplitterBorderStyle.SunkenOut)
            {
                ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenOuter);
            }
        }

    }

    /// <summary>
    /// Enum representing the Border style
    /// </summary>
    public enum SplitterBorderStyle
    {
        /// <summary>
        /// The flat
        /// </summary>
        Flat,
        /// <summary>
        /// The sunken out
        /// </summary>
        SunkenOut,
        /// <summary>
        /// The sunken inner
        /// </summary>
        SunkenInner,
        /// <summary>
        /// The sunken
        /// </summary>
        Sunken,
        /// <summary>
        /// The single
        /// </summary>
        Single,
        /// <summary>
        /// The none
        /// </summary>
        None
    }

    /// <summary>
    /// smart tag design
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class ZeroitProgressSplitterDesinger : ControlDesigner
    {
        /// <summary>
        /// The m action lists
        /// </summary>
        private DesignerActionListCollection m_ActionLists;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressSplitterDesinger"/> class.
        /// </summary>
        public ZeroitProgressSplitterDesinger() { }

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == m_ActionLists)
                {
                    m_ActionLists = new DesignerActionListCollection();
                    m_ActionLists.Add(new ZeroitProgressSplitterDesignerActionList(this.Component));
                }
                return m_ActionLists;
            }
        }
    }

    /// <summary>
    /// custom smart tag item
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressSplitterDesignerActionList : DesignerActionList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressSplitterDesignerActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressSplitterDesignerActionList(IComponent component) : base(component) { }

        /// <summary>
        /// Gets the smart progress bar.
        /// </summary>
        /// <value>The smart progress bar.</value>
        private ZeroitProgressSplitter SmartProgressBar
        {
            get { return this.Component as ZeroitProgressSplitter; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return this.SmartProgressBar.AutoAnimate; }
            set { this.SetProperty("AutoAnimate", value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show percent].
        /// </summary>
        /// <value><c>true</c> if [show percent]; otherwise, <c>false</c>.</value>
        public bool ShowPercent
        {
            get { return this.SmartProgressBar.ShowPercent; }
            set { this.SetProperty("ShowPercent", value); }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [progress bar margin offset].
        /// </summary>
        /// <value><c>true</c> if [progress bar margin offset]; otherwise, <c>false</c>.</value>
        public bool ProgressBarMarginOffset
        {
            get { return this.SmartProgressBar.ProgressBarMarginOffset; }
            set { this.SetProperty("ProgressBarMarginOffset", value); }
        }


        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get { return this.SmartProgressBar.BackColor; }
            set { this.SetProperty("BackColor", value); }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return this.SmartProgressBar.ForeColor; }
            set { this.SetProperty("ForeColor", value); }
        }

        /// <summary>
        /// Gets or sets the color of the progress bar fill.
        /// </summary>
        /// <value>The color of the progress bar fill.</value>
        public Color ProgressBarFillColor
        {
            get { return this.SmartProgressBar.ProgressBarFillColor; }
            set { this.SetProperty("ProgressBarFillColor", value); }
        }

        /// <summary>
        /// Gets or sets the progress bar boder style.
        /// </summary>
        /// <value>The progress bar boder style.</value>
        public SplitterBorderStyle ProgressBarBoderStyle
        {
            get { return this.SmartProgressBar.ProgressBarBoderStyle; }
            set { this.SetProperty("ProgressBarBoderStyle", value); }
        }

        /// <summary>
        /// Gets or sets the width of the progress bar block.
        /// </summary>
        /// <value>The width of the progress bar block.</value>
        public int ProgressBarBlockWidth
        {
            get { return this.SmartProgressBar.ProgressBarBlockWidth; }
            set { this.SetProperty("ProgressBarBlockWidth", value); }
        }

        /// <summary>
        /// Gets or sets the progress bar block space.
        /// </summary>
        /// <value>The progress bar block space.</value>
        public int ProgressBarBlockSpace
        {
            get { return this.SmartProgressBar.ProgressBarBlockSpace; }
            set { this.SetProperty("ProgressBarBlockSpace", value); }
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptorCollection propertyCollection = TypeDescriptor.GetProperties(this.SmartProgressBar);
            PropertyDescriptor property = propertyCollection[propertyName];
            property.SetValue(this.SmartProgressBar, value);
        }


    }

    #endregion


}
