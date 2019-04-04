// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ExtendedProgressBar.cs" company="Zeroit Dev Technologies">
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
    #region Extended Controls

    #region Enums

    /// <summary>
    /// Enum for the <c><see cref="ZeroitExtendedProgressBar" /></c> border style.
    /// </summary>
    public enum ExtendedBorderStyle
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The single
        /// </summary>
        Single,
        /// <summary>
        /// The raised3 d
        /// </summary>
        Raised3D,
        /// <summary>
        /// The sunken3 d
        /// </summary>
        Sunken3D,
        /// <summary>
        /// The shadow
        /// </summary>
        Shadow
    };

    /// <summary>
    /// Enum that represents the orientation of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ExtendedOrientation
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical
    };

    #endregion

    #region Progress Bar

    #region Enum
    //#####    
    /// <summary>
    /// Enum that represents the caption mode of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ProgressCaptionMode
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The percent
        /// </summary>
        Percent,
        /// <summary>
        /// The value
        /// </summary>
        Value,
        /// <summary>
        /// The custom
        /// </summary>
        Custom
    }
    //#####    
    /// <summary>
    /// Enum that represents the flood style of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ProgressFloodStyle
    {
        /// <summary>
        /// The standard
        /// </summary>
        Standard,
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal
    }

    //#####    
    /// <summary>
    /// Enum that represents the bar edge of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ProgressBarEdge
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The rectangle
        /// </summary>
        Rectangle,
        /// <summary>
        /// The rounded
        /// </summary>
        Rounded
    }


    //#####    
    /// <summary>
    /// Enum that represents the Direction of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ProgressBarDirection
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal,
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical
    }

    //#####    
    /// <summary>
    /// Enum that represents the Progress Style of the <c><see cref="ZeroitExtendedProgressBar" /></c> control.
    /// </summary>
    public enum ProgressStyle
    {
        /// <summary>
        /// The dashed
        /// </summary>
        Dashed,
        /// <summary>
        /// The solid
        /// </summary>
        Solid
    }
    //#####
    #endregion

    #region Control    
    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxBitmapAttribute(typeof(ZeroitExtendedProgressBar), "ExDotNet.ico")]
    [Designer(typeof(ZeroitExtendedProgressBarDesigner))]
    public class ZeroitExtendedProgressBar : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Direction
        //#####
        /// <summary>
        /// The m bool invert
        /// </summary>
        private bool m_bool_Invert = false;

        /// <summary>
        /// Gets or sets a value indicating whether to <c>Invert</c> the progress direction.
        /// </summary>
        /// <value><c>true</c> if invert; otherwise, <c>false</c>.</value>
        [Description("Invert the progress direction")]
        [Category("_Orientation")]
        [Browsable(true)]
        public bool Invert
        {
            get
            {
                return m_bool_Invert;
            }
            set
            {
                m_bool_Invert = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m direction
        /// </summary>
        private ProgressBarDirection m_Direction = ProgressBarDirection.Horizontal;

        /// <summary>
        /// Gets or sets the progress control horizontally or vertically.
        /// </summary>
        /// <value>The orientation.</value>
        [Description("Set the progress control horizontal or vertical")]
        [Category("_Orientation")]
        [Browsable(true)]
        public ProgressBarDirection Orientation
        {
            get
            {
                return m_Direction;
            }
            set
            {
                m_Direction = value;
                Invalidate();
            }
        }
        #endregion

        #region Edge
        //#####
        /// <summary>
        /// The m edge
        /// </summary>
        private ProgressBarEdge m_Edge = ProgressBarEdge.Rounded;

        /// <summary>
        /// Gets or sets the edge.
        /// </summary>
        /// <value>The edge.</value>
        [Description("Set the edge of the control")]
        [Category("_Edge")]
        [Browsable(true)]
        public ProgressBarEdge Edge
        {
            get
            {
                return m_Edge;
            }
            set
            {
                m_Edge = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m edge color
        /// </summary>
        private Color m_EdgeColor = Color.FromKnownColor(KnownColor.Gray);

        /// <summary>
        /// Gets or sets the color of the edge.
        /// </summary>
        /// <value>The color of the edge.</value>
        [Description("Set the edge color")]
        [Category("_Edge")]
        [Browsable(true)]
        public Color EdgeColor
        {
            get
            {
                return m_EdgeColor;
            }
            set
            {
                m_EdgeColor = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m edge light color
        /// </summary>
        private Color m_EdgeLightColor = Color.FromKnownColor(KnownColor.LightGray);

        /// <summary>
        /// Gets or sets the light color of the edge.
        /// </summary>
        /// <value>The light color of the edge.</value>
        [Description("Set the edge light color")]
        [Category("_Edge")]
        [Browsable(true)]
        public Color EdgeLightColor
        {
            get
            {
                return m_EdgeLightColor;
            }
            set
            {
                m_EdgeLightColor = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m edge width
        /// </summary>
        private int m_EdgeWidth = 1;

        /// <summary>
        /// Gets or sets the width of the edge.
        /// </summary>
        /// <value>The width of the edge.</value>
        [Description("Set the edge width")]
        [Category("_Edge")]
        [Browsable(true)]
        public int EdgeWidth
        {
            get
            {
                return m_EdgeWidth;
            }
            set
            {
                m_EdgeWidth = value;
                if (m_EdgeWidth < 0) m_EdgeWidth = 0;
                if (m_EdgeWidth > Int16.MaxValue) m_EdgeWidth = Int16.MaxValue;
                Invalidate();
            }
        }
        //#####
        #endregion

        #region Progress
        //#####
        /// <summary>
        /// The m flood style
        /// </summary>
        private ProgressFloodStyle m_FloodStyle = ProgressFloodStyle.Standard;

        /// <summary>
        /// Gets or sets the flood style.
        /// Standard draws a standard xp-themed progressbar,
        /// and with Horizontal you can create a horizontal
        /// flood bar (for the best effect, set FloodPercentage to 1.0.
        /// </summary>
        /// <value>The flood style.</value>
        [Description("Set the floodstyle. Standard draws a standard xp-themed progressbar, and with Horizontal you can create a horizontal flood bar (for the best effect, set FloodPercentage to 1.0.")]
        [Category("_Progress")]
        [Browsable(true)]
        public ProgressFloodStyle FloodStyle
        {
            get
            {
                return m_FloodStyle;
            }
            set
            {
                m_FloodStyle = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m float bar flood
        /// </summary>
        private float m_float_BarFlood = 0.20f;

        /// <summary>
        /// Gets or sets the percentage of the flood color, a value between 0.0 and 1.0.
        /// </summary>
        /// <value>The flood percentage.</value>
        [Description("Set the percentage of the flood color, a value between 0.0 and 1.0.")]
        [Category("_Progress")]
        [Browsable(true)]
        public float FloodPercentage
        {
            get
            {
                return m_float_BarFlood;
            }
            set
            {
                m_float_BarFlood = value;
                if (m_float_BarFlood < 0.0f) m_float_BarFlood = 0.0f;
                if (m_float_BarFlood > 1.0f) m_float_BarFlood = 1.0f;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m int bar offset
        /// </summary>
        private int m_int_BarOffset = 1;

        /// <summary>
        /// Gets or sets the offset for the left, top, right and bottom.
        /// </summary>
        /// <value>The bar offset.</value>
        [Description("Set the offset for the left, top, right and bottom")]
        [Category("_Progress")]
        [Browsable(true)]
        public int BarOffset
        {
            get
            {
                return m_int_BarOffset;
            }
            set
            {
                m_int_BarOffset = value;
                if (m_int_BarOffset < 0) m_int_BarOffset = 0;
                if (m_int_BarOffset > Int16.MaxValue) m_int_BarOffset = Int16.MaxValue;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m int dash width
        /// </summary>
        private int m_int_DashWidth = 5;

        /// <summary>
        /// Gets or sets the width of the dash if Dashed mode.
        /// </summary>
        /// <value>The width of the dash.</value>
        [Description("Set the width of a dash if Dashed mode")]
        [Category("_Progress")]
        [Browsable(true)]
        public int DashWidth
        {
            get
            {
                return m_int_DashWidth;
            }
            set
            {
                m_int_DashWidth = value;
                if (m_int_DashWidth < 0) m_int_DashWidth = 0;
                if (m_int_DashWidth > Int16.MaxValue) m_int_DashWidth = Int16.MaxValue;
                Invalidate();
            }
        }

        //#####
        /// <summary>
        /// The m int dash space
        /// </summary>
        private int m_int_DashSpace = 2;

        /// <summary>
        /// Gets or sets the space between every dash if Dashed mode.
        /// </summary>
        /// <value>The dash space.</value>
        [Description("Set the space between every dash if Dashed mode")]
        [Category("_Progress")]
        [Browsable(true)]
        public int DashSpace
        {
            get
            {
                return m_int_DashSpace;
            }
            set
            {
                m_int_DashSpace = value;
                if (m_int_DashSpace < 0) m_int_DashSpace = 0;
                if (m_int_DashSpace > Int16.MaxValue) m_int_DashSpace = Int16.MaxValue;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m style
        /// </summary>
        private ProgressStyle m_Style = ProgressStyle.Dashed;

        /// <summary>
        /// Gets or sets the progress bar style.
        /// </summary>
        /// <value>The progress bar style.</value>
        [Description("Set progressbar style")]
        [Category("_Progress")]
        [Browsable(true)]
        public ProgressStyle ProgressBarStyle
        {
            get
            {
                return m_Style;
            }
            set
            {
                m_Style = value;
                Invalidate();
            }
        }

        //#####
        /// <summary>
        /// The m color1
        /// </summary>
        private Color m_Color1 = Color.FromArgb(0, 255, 0);

        /// <summary>
        /// Gets or sets the main color.
        /// </summary>
        /// <value>The main color.</value>
        [Description("Set the main color")]
        [Category("_Progress")]
        [Browsable(true)]
        public Color MainColor
        {
            get
            {
                return m_Color1;
            }
            set
            {
                m_Color1 = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m color2
        /// </summary>
        private Color m_Color2 = Color.FromKnownColor(KnownColor.White);

        /// <summary>
        /// Gets or sets the second color.
        /// </summary>
        /// <value>The second color.</value>
        [Description("Set the second color")]
        [Category("_Progress")]
        [Browsable(true)]
        public Color SecondColor
        {
            get
            {
                return m_Color2;
            }
            set
            {
                m_Color2 = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m color back
        /// </summary>
        private Color m_color_Back = Color.FromKnownColor(KnownColor.White);

        /// <summary>
        /// Gets or sets the color of the progress background.
        /// </summary>
        /// <value>The color of the progress background.</value>
        [Description("Set the background color")]
        [Category("_Progress")]
        [Browsable(true)]
        public Color ProgressBackColor
        {
            get
            {
                return m_color_Back;
            }
            set
            {
                m_color_Back = value;
                Invalidate();
            }
        }
        //#####
        #endregion

        #region Properties

        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;

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
        /// Gets or sets a value indicating whether to automatically animate the progress control.
        /// </summary>
        /// <value><c>true</c> if automatically animate; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
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
        /// The m int minimum
        /// </summary>
        private int m_int_Minimum = 0;

        /// <summary>
        /// Gets or sets the minimum value of this progress control.
        /// </summary>
        /// <value>The minimum.</value>
        [Description("Set the minimum value of this progress control")]
        [Category("Properties")]
        [Browsable(true)]
        public int Minimum
        {
            get
            {
                return m_int_Minimum;
            }
            set
            {
                if (value < m_int_Maximum) m_int_Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The m int maximum
        /// </summary>
        private int m_int_Maximum = 100;

        /// <summary>
        /// Gets or sets the maximum value of this progress control.
        /// </summary>
        /// <value>The maximum.</value>
        [Description("Set the maximum value of this progress control")]
        [Category("Properties")]
        [Browsable(true)]
        public int Maximum
        {
            get
            {
                return m_int_Maximum;
            }
            set
            {
                if (value > m_int_Minimum) m_int_Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The m int value
        /// </summary>
        private int m_int_Value = 33;

        /// <summary>
        /// Gets or sets the current value of this progress control.
        /// </summary>
        /// <value>The value.</value>
        [Description("Set the current value of this progress control")]
        [Category("Properties")]
        [Browsable(true)]
        public int Value
        {
            get
            {
                return m_int_Value;
            }
            set
            {
                m_int_Value = value;
                if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
                if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
                Invalidate();
            }
        }

        /// <summary>
        /// The m int step
        /// </summary>
        private int m_int_Step = 1;

        /// <summary>
        /// Gets or sets the step value.
        /// </summary>
        /// <value>The step.</value>
        [Description("Set the step value")]
        [Category("Properties")]
        [Browsable(true)]
        public int Step
        {
            get
            {
                return m_int_Step;
            }
            set
            {
                m_int_Step = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitExtendedProgressBar" /> class.
        /// </summary>
        public ZeroitExtendedProgressBar()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            #region MyRegion
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
        }
        #endregion

        #region Caption        
        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Description("Change the font")]
        [Category("_Caption")]
        [Browsable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m bool shadow
        /// </summary>
        private bool m_bool_Shadow = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedProgressBar" /> has shadow enabled.
        /// </summary>
        /// <value><c>true</c> if shadow; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable shadow")]
        [Category("_Caption")]
        [Browsable(true)]
        public bool Shadow
        {
            get
            {
                return m_bool_Shadow;
            }
            set
            {
                m_bool_Shadow = value;
                Invalidate();
            }
        }

        //#####
        /// <summary>
        /// The m int shadow offset
        /// </summary>
        private int m_int_ShadowOffset = 1;

        /// <summary>
        /// Gets or sets the shadow offset.
        /// </summary>
        /// <value>The shadow offset.</value>
        [Description("Set shadow offset")]
        [Category("_Caption")]
        [Browsable(true)]
        public int ShadowOffset
        {
            get
            {
                return m_int_ShadowOffset;
            }
            set
            {
                m_int_ShadowOffset = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m bool antialias
        /// </summary>
        private bool m_bool_Antialias = true;

        /// <summary>
        /// Gets or sets a value indicating whether to enable/disable text antialias.
        /// </summary>
        /// <value><c>true</c> if [text antialias]; otherwise, <c>false</c>.</value>
        [Description("Enable/Disable antialiasing")]
        [Category("_Caption")]
        [Browsable(true)]
        public bool TextAntialias
        {
            get
            {
                return m_bool_Antialias;
            }
            set
            {
                m_bool_Antialias = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m color shadow
        /// </summary>
        private Color m_color_Shadow = Color.FromKnownColor(KnownColor.White);

        /// <summary>
        /// Gets or sets the color of the caption shadow.
        /// </summary>
        /// <value>The color of the caption shadow.</value>
        [Description("Set the caption shadow color.")]
        [Category("_Caption")]
        [Browsable(true)]
        public Color CaptionShadowColor
        {
            get
            {
                return m_color_Shadow;
            }
            set
            {
                m_color_Shadow = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m color caption
        /// </summary>
        private Color m_color_Caption = Color.FromKnownColor(KnownColor.Black);

        /// <summary>
        /// Gets or sets the color of the caption.
        /// </summary>
        /// <value>The color of the caption.</value>
        [Description("Set the caption color.")]
        [Category("_Caption")]
        [Browsable(true)]
        public Color CaptionColor
        {
            get
            {
                return m_color_Caption;
            }
            set
            {
                m_color_Caption = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m caption mode
        /// </summary>
        private ProgressCaptionMode m_CaptionMode = ProgressCaptionMode.Percent;

        /// <summary>
        /// Gets or sets the caption mode.
        /// </summary>
        /// <value>The caption mode.</value>
        [Description("Set the caption mode.")]
        [Category("_Caption")]
        [Browsable(true)]
        public ProgressCaptionMode CaptionMode
        {
            get
            {
                return m_CaptionMode;
            }
            set
            {
                m_CaptionMode = value;
                Invalidate();
            }
        }
        //#####
        /// <summary>
        /// The m string caption
        /// </summary>
        private String m_str_Caption = "Progress";

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        [Description("Set the caption.")]
        [Category("_Caption")]
        [Browsable(true)]
        public String Caption
        {
            get
            {
                return m_str_Caption;
            }
            set
            {
                m_str_Caption = value;
                Invalidate();
            }
        }
        //#####
        #endregion

        #region Custom
        //#####
        /// <summary>
        /// The m bool change by mouse
        /// </summary>
        private bool m_bool_ChangeByMouse = false;

        /// <summary>
        /// Allows the user to change the value by clicking the mouse.
        /// </summary>
        /// <value><c>true</c> if change by mouse; otherwise, <c>false</c>.</value>
        [Description("Allows the user to change the value by clicking the mouse")]
        [Category("_Custom")]
        [Browsable(true)]
        public bool ChangeByMouse
        {
            get
            {
                return m_bool_ChangeByMouse;
            }
            set
            {
                m_bool_ChangeByMouse = value;
                Invalidate();
            }
        }
        #endregion

        #region GetCustomCaption
        /// <summary>
        /// Gets the custom caption.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <returns>String.</returns>
        private String GetCustomCaption(String caption)
        {
            float float_Percentage = ((float)(m_int_Value - m_int_Minimum) / (float)(m_int_Maximum - m_int_Minimum)) * 100.0f;

            String toReturn = caption.Replace("<VALUE>", m_int_Value.ToString());
            toReturn = caption.Replace("<PERCENTAGE>", float_Percentage.ToString());

            return toReturn;
        }
        #endregion

        #region User Methods
        /// <summary>
        /// Performs the step.
        /// </summary>
        public void PerformStep()
        {
            m_int_Value += m_int_Step;
            if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
            if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
        }

        /// <summary>
        /// Increments the specified value.
        /// </summary>
        /// <param name="val">The value.</param>
        public void Increment(int val)
        {
            m_int_Value += val;
            if (m_int_Value < m_int_Minimum) m_int_Value = m_int_Minimum;
            if (m_int_Value > m_int_Maximum) m_int_Value = m_int_Maximum;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            #region OnPaint - Draw Background

            timer.Interval = interval;

            SolidBrush brsh = new SolidBrush(m_color_Back);
            e.Graphics.FillRectangle(brsh, 0, 0, this.Width, this.Height);
            #endregion

            #region OnPaint - Draw ProgressBar
            switch (m_Direction)
            {
                #region Horizontal
                case ProgressBarDirection.Horizontal:
                    {
                        float float_ProgressHeight = (float)(this.Height - m_EdgeWidth * 2 - m_int_BarOffset * 2);
                        float float_ProgressTotalWidth = this.Width - m_EdgeWidth * 2 - m_int_BarOffset * 2;
                        float float_ProgressDrawWidth = float_ProgressTotalWidth / (float)(m_int_Maximum - m_int_Minimum) * (float)(m_int_Value - m_int_Minimum);

                        int int_NumberOfDashes = (int)(float_ProgressDrawWidth / (float)(m_int_DashWidth + m_int_DashSpace));
                        int int_TotalDashes = (int)(float_ProgressTotalWidth / (float)(m_int_DashWidth + m_int_DashSpace));

                        Rectangle rect_Bar2 = new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset, (int)float_ProgressTotalWidth, (int)float_ProgressHeight);
                        Rectangle rect_Bar;
                        if (m_bool_Invert)
                        {
                            rect_Bar = new Rectangle(
                                      m_EdgeWidth + m_int_BarOffset + (int)(float_ProgressTotalWidth - float_ProgressDrawWidth)
                                    , m_EdgeWidth + m_int_BarOffset
                                    , (int)float_ProgressDrawWidth
                                    , (int)float_ProgressHeight);
                        }
                        else
                        {
                            rect_Bar = new Rectangle(
                                      m_EdgeWidth + m_int_BarOffset
                                    , m_EdgeWidth + m_int_BarOffset
                                    , (int)float_ProgressDrawWidth
                                    , (int)float_ProgressHeight);
                        }

                        LinearGradientBrush brsh_Bar = new LinearGradientBrush(rect_Bar2, m_Color2, m_Color1, (m_FloodStyle == ProgressFloodStyle.Standard) ? 90.0f : 0.0f);
                        float[] factors = { 0.0f, 1.0f, 1.0f, 0.0f };
                        float[] positions = { 0.0f, m_float_BarFlood, 1.0f - m_float_BarFlood, 1.0f };

                        Blend blend = new Blend();
                        blend.Factors = factors;
                        blend.Positions = positions;
                        brsh_Bar.Blend = blend;

                        switch (m_Style)
                        {
                            case ProgressStyle.Solid:
                                {
                                    e.Graphics.FillRectangle(brsh_Bar, rect_Bar);
                                    break;
                                }
                            case ProgressStyle.Dashed:
                                {
                                    if (m_bool_Invert)
                                    {
                                        if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
                                        for (int i = 0; i < int_NumberOfDashes + 1; i++)
                                        {
                                            int j = i + (int_TotalDashes - int_NumberOfDashes);
                                            e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset + (j * (m_int_DashWidth + m_int_DashSpace)), m_EdgeWidth + m_int_BarOffset, m_int_DashWidth, (int)float_ProgressHeight));
                                        }
                                    }
                                    else
                                    {
                                        if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
                                        for (int i = 0; i < int_NumberOfDashes + 1; i++)
                                        {
                                            e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset + (i * (m_int_DashWidth + m_int_DashSpace)), m_EdgeWidth + m_int_BarOffset, m_int_DashWidth, (int)float_ProgressHeight));
                                        }
                                    }
                                    break;
                                }
                        }
                        brsh_Bar.Dispose();
                        break;
                    }
                #endregion
                #region Vertical
                case ProgressBarDirection.Vertical:
                    {
                        float float_ProgressWidth = (float)(this.Width - m_EdgeWidth * 2 - m_int_BarOffset * 2);
                        float float_ProgressTotalHeight = this.Height - m_EdgeWidth * 2 - m_int_BarOffset * 2;
                        float float_ProgressDrawHeight = float_ProgressTotalHeight / (float)(m_int_Maximum - m_int_Minimum) * (float)(m_int_Value - m_int_Minimum);

                        int int_NumberOfDashes = (int)(float_ProgressDrawHeight / (float)(m_int_DashWidth + m_int_DashSpace));
                        int int_TotalDashes = (int)(float_ProgressTotalHeight / (float)(m_int_DashWidth + m_int_DashSpace));

                        Rectangle rect_Bar2 = new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset, (int)float_ProgressWidth, (int)float_ProgressTotalHeight);
                        Rectangle rect_Bar;
                        if (m_bool_Invert)
                        {
                            rect_Bar = new Rectangle(
                                  m_EdgeWidth + m_int_BarOffset
                                , m_EdgeWidth + m_int_BarOffset + (int)(float_ProgressTotalHeight - float_ProgressDrawHeight)
                                , (int)float_ProgressWidth
                                , (int)float_ProgressDrawHeight);
                        }
                        else
                        {
                            rect_Bar = new Rectangle(
                                  m_EdgeWidth + m_int_BarOffset
                                , m_EdgeWidth + m_int_BarOffset
                                , (int)float_ProgressWidth
                                , (int)float_ProgressDrawHeight);
                        }

                        LinearGradientBrush brsh_Bar = new LinearGradientBrush(rect_Bar2, m_Color2, m_Color1, (m_FloodStyle == ProgressFloodStyle.Standard) ? 0.0f : 90.0f);
                        float[] factors = { 0.0f, 1.0f, 1.0f, 0.0f };
                        float[] positions = { 0.0f, m_float_BarFlood, 1.0f - m_float_BarFlood, 1.0f };

                        Blend blend = new Blend();
                        blend.Factors = factors;
                        blend.Positions = positions;
                        brsh_Bar.Blend = blend;

                        switch (m_Style)
                        {
                            case ProgressStyle.Solid:
                                {
                                    e.Graphics.FillRectangle(brsh_Bar, rect_Bar);
                                    break;
                                }
                            case ProgressStyle.Dashed:
                                {
                                    if (m_bool_Invert)
                                    {
                                        if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
                                        for (int i = 0; i < int_NumberOfDashes + 1; i++)
                                        {
                                            int j = i + (int_TotalDashes - int_NumberOfDashes);
                                            e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset + (j * (m_int_DashWidth + m_int_DashSpace)), (int)float_ProgressWidth, m_int_DashWidth));
                                        }
                                    }
                                    else
                                    {
                                        if (int_NumberOfDashes == 0) int_NumberOfDashes = -1;
                                        for (int i = 0; i < int_NumberOfDashes + 1; i++)
                                        {
                                            e.Graphics.FillRectangle(brsh_Bar, new Rectangle(m_EdgeWidth + m_int_BarOffset, m_EdgeWidth + m_int_BarOffset + (i * (m_int_DashWidth + m_int_DashSpace)), (int)float_ProgressWidth, m_int_DashWidth));
                                        }
                                    }
                                    break;
                                }
                        }
                        brsh_Bar.Dispose();
                        break;
                    }
                    #endregion
            }
            #endregion

            #region OnPaint - Draw Edge
            switch (m_Edge)
            {
                case ProgressBarEdge.Rectangle:
                    {
                        Pen pen = new Pen(m_EdgeColor);
                        Pen pen3 = new Pen(m_EdgeLightColor);
                        for (int i = 0; i < m_EdgeWidth; i++)
                        {
                            e.Graphics.DrawRectangle(pen, 0 + i, 0 + i, this.Width - 1 - i * 2, this.Height - 1 - i * 2);
                        }
                        e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth, this.Width - 1 - m_EdgeWidth, m_EdgeWidth);
                        e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth, m_EdgeWidth, this.Height - 1 - m_EdgeWidth);
                        break;
                    }
                case ProgressBarEdge.Rounded:
                    {
                        Pen pen = new Pen(m_EdgeColor);
                        Pen pen2 = new Pen(this.BackColor);
                        Pen pen3 = new Pen(m_EdgeLightColor);
                        for (int i = 0; i < m_EdgeWidth; i++)
                        {
                            e.Graphics.DrawRectangle(pen, 0 + i, 0 + i, this.Width - 1 - i * 2, this.Height - 1 - i * 2);
                        }
                        e.Graphics.DrawLine(pen2, 0, 0, 1, 0);
                        e.Graphics.DrawLine(pen2, 0, 0, 0, 1);
                        e.Graphics.DrawLine(pen2, 0, this.Height - 1, 1, this.Height - 1);
                        e.Graphics.DrawLine(pen2, 0, this.Height - 1, 0, this.Height - 2);
                        e.Graphics.DrawLine(pen2, this.Width - 2, 0, this.Width - 1, 0);
                        e.Graphics.DrawLine(pen2, this.Width - 1, 0, this.Width - 1, 1);
                        e.Graphics.DrawLine(pen2, this.Width - 2, this.Height - 1, this.Width - 1, this.Height - 1);
                        e.Graphics.DrawLine(pen2, this.Width - 1, this.Height - 2, this.Width - 1, this.Height - 1);

                        e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), m_EdgeWidth, m_EdgeWidth, 1, 1);
                        e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), m_EdgeWidth, this.Height - 1 - m_EdgeWidth, 1, 1);
                        e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), this.Width - 1 - m_EdgeWidth, m_EdgeWidth, 1, 1);
                        e.Graphics.FillRectangle(new SolidBrush(m_EdgeColor), this.Width - 1 - m_EdgeWidth, this.Height - 1 - m_EdgeWidth, 1, 1);

                        e.Graphics.DrawLine(pen3, m_EdgeWidth + 1, m_EdgeWidth, this.Width - 2 - m_EdgeWidth, m_EdgeWidth);
                        e.Graphics.DrawLine(pen3, m_EdgeWidth, m_EdgeWidth + 1, m_EdgeWidth, this.Height - 2 - m_EdgeWidth);

                        break;
                    }
            }
            #endregion

            #region OnPaint - Draw Caption
            if (m_bool_Antialias) e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            switch (m_CaptionMode)
            {
                case ProgressCaptionMode.Value:
                    {
                        if (m_bool_Shadow)
                        {
                            e.Graphics.DrawString(m_int_Value.ToString(), this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
                        }
                        e.Graphics.DrawString(m_int_Value.ToString(), this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
                        break;
                    }
                case ProgressCaptionMode.Percent:
                    {
                        float float_Percentage = ((float)(m_int_Value - m_int_Minimum) / (float)(m_int_Maximum - m_int_Minimum)) * 100.0f;
                        if (m_bool_Shadow)
                        {
                            e.Graphics.DrawString(float_Percentage.ToString() + "%", this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
                        }
                        e.Graphics.DrawString(float_Percentage.ToString() + "%", this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
                        break;
                    }
                case ProgressCaptionMode.Custom:
                    {
                        if (m_bool_Shadow)
                        {
                            e.Graphics.DrawString(GetCustomCaption(m_str_Caption), this.Font, new SolidBrush(m_color_Shadow), new Rectangle(m_int_ShadowOffset, m_int_ShadowOffset, this.Width, this.Height), format);
                        }
                        e.Graphics.DrawString(GetCustomCaption(m_str_Caption), this.Font, new SolidBrush(m_color_Caption), new Rectangle(0, 0, this.Width, this.Height), format);
                        break;
                    }
            }
            #endregion

            base.OnPaint(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ProgressBar
            // 
            this.Name = "ProgressBar";
            this.Size = new System.Drawing.Size(256, 24);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseDown);

        }
        #endregion

        #region ChangeByMouse
        /// <summary>
        /// Handles the MouseDown event of the ProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ProgressBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /**/
        }

        /// <summary>
        /// Handles the MouseMove event of the ProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ProgressBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_bool_ChangeByMouse && e.Button == MouseButtons.Left)
            {
                if (m_Direction == ProgressBarDirection.Horizontal)
                {
                    int int_ProgressWidth = this.Width - m_int_BarOffset * 2 - m_EdgeWidth * 2;
                    int int_MousePos = e.X - m_int_BarOffset - m_EdgeWidth;

                    float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

                    int int_Range = m_int_Maximum - m_int_Minimum;
                    int int_NewValue = (int)((float)int_Range * percentageClick);
                    if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
                    int_NewValue += m_int_Minimum;
                    if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
                    if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
                    m_int_Value = int_NewValue;
                }
                else
                {
                    int int_ProgressWidth = this.Height - m_int_BarOffset * 2 - m_EdgeWidth * 2;
                    int int_MousePos = e.Y - m_int_BarOffset - m_EdgeWidth;

                    float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

                    int int_Range = m_int_Maximum - m_int_Minimum;
                    int int_NewValue = (int)((float)int_Range * percentageClick);
                    if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
                    int_NewValue += m_int_Minimum;
                    if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
                    if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
                    m_int_Value = int_NewValue;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the ProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ProgressBar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_bool_ChangeByMouse)
            {
                if (m_Direction == ProgressBarDirection.Horizontal)
                {
                    int int_ProgressWidth = this.Width - m_int_BarOffset * 2 - m_EdgeWidth * 2;
                    int int_MousePos = e.X - m_int_BarOffset - m_EdgeWidth;

                    float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

                    int int_Range = m_int_Maximum - m_int_Minimum;
                    int int_NewValue = (int)((float)int_Range * percentageClick);
                    if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
                    int_NewValue += m_int_Minimum;
                    if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
                    if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
                    m_int_Value = int_NewValue;
                }
                else
                {
                    int int_ProgressWidth = this.Height - m_int_BarOffset * 2 - m_EdgeWidth * 2;
                    int int_MousePos = e.Y - m_int_BarOffset - m_EdgeWidth;

                    float percentageClick = (float)int_MousePos / (float)int_ProgressWidth;

                    int int_Range = m_int_Maximum - m_int_Minimum;
                    int int_NewValue = (int)((float)int_Range * percentageClick);
                    if (m_bool_Invert) int_NewValue = int_Range - int_NewValue;
                    int_NewValue += m_int_Minimum;
                    if (int_NewValue < m_int_Minimum) int_NewValue = m_int_Minimum;
                    if (int_NewValue > m_int_Maximum) int_NewValue = m_int_Maximum;
                    m_int_Value = int_NewValue;
                }
                Invalidate();
            }
        }
        #endregion
    }


    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitExtendedProgressBarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitExtendedProgressBarDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitExtendedProgressBarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitExtendedProgressBarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitExtendedProgressBarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitExtendedProgressBar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitExtendedProgressBarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitExtendedProgressBarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitExtendedProgressBar;

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

        #region Direction

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitExtendedProgressBarSmartTagActionList"/> is invert.
        /// </summary>
        /// <value><c>true</c> if invert; otherwise, <c>false</c>.</value>
        public bool Invert
        {
            get
            {
                return colUserControl.Invert;
            }
            set
            {
                GetPropertyByName("Invert").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get
            {
                return colUserControl.AutoAnimate;
            }
            set
            {
                GetPropertyByName("AutoAnimate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public ProgressBarDirection Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }
        #endregion

        #region Edge
        /// <summary>
        /// Gets or sets the edge.
        /// </summary>
        /// <value>The edge.</value>
        public ProgressBarEdge Edge
        {
            get
            {
                return colUserControl.Edge;
            }
            set
            {
                GetPropertyByName("Edge").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the edge.
        /// </summary>
        /// <value>The color of the edge.</value>
        public Color EdgeColor
        {
            get
            {
                return colUserControl.EdgeColor;
            }
            set
            {
                GetPropertyByName("EdgeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the edge light.
        /// </summary>
        /// <value>The color of the edge light.</value>
        public Color EdgeLightColor
        {
            get
            {
                return colUserControl.EdgeLightColor;
            }
            set
            {
                GetPropertyByName("EdgeLightColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the edge.
        /// </summary>
        /// <value>The width of the edge.</value>
        public int EdgeWidth
        {
            get
            {
                return colUserControl.EdgeWidth;
            }
            set
            {
                GetPropertyByName("EdgeWidth").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region Progress
        /// <summary>
        /// Gets or sets the flood style.
        /// </summary>
        /// <value>The flood style.</value>
        public ProgressFloodStyle FloodStyle
        {
            get
            {
                return colUserControl.FloodStyle;
            }
            set
            {
                GetPropertyByName("FloodStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the flood percentage.
        /// </summary>
        /// <value>The flood percentage.</value>
        public float FloodPercentage
        {
            get
            {
                return colUserControl.FloodPercentage;
            }
            set
            {
                GetPropertyByName("FloodPercentage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar offset.
        /// </summary>
        /// <value>The bar offset.</value>
        public int BarOffset
        {
            get
            {
                return colUserControl.BarOffset;
            }
            set
            {
                GetPropertyByName("BarOffset").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the dash.
        /// </summary>
        /// <value>The width of the dash.</value>
        public int DashWidth
        {
            get
            {
                return colUserControl.DashWidth;
            }
            set
            {
                GetPropertyByName("DashWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the dash space.
        /// </summary>
        /// <value>The dash space.</value>
        public int DashSpace
        {
            get
            {
                return colUserControl.DashSpace;
            }
            set
            {
                GetPropertyByName("DashSpace").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress bar style.
        /// </summary>
        /// <value>The progress bar style.</value>
        public ProgressStyle ProgressBarStyle
        {
            get
            {
                return colUserControl.ProgressBarStyle;
            }
            set
            {
                GetPropertyByName("ProgressBarStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the main.
        /// </summary>
        /// <value>The color of the main.</value>
        public Color MainColor
        {
            get
            {
                return colUserControl.MainColor;
            }
            set
            {
                GetPropertyByName("MainColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the second.
        /// </summary>
        /// <value>The color of the second.</value>
        public Color SecondColor
        {
            get
            {
                return colUserControl.SecondColor;
            }
            set
            {
                GetPropertyByName("SecondColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress back.
        /// </summary>
        /// <value>The color of the progress back.</value>
        public Color ProgressBackColor
        {
            get
            {
                return colUserControl.ProgressBackColor;
            }
            set
            {
                GetPropertyByName("ProgressBackColor").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
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
        /// Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        public int Step
        {
            get
            {
                return colUserControl.Step;
            }
            set
            {
                GetPropertyByName("Step").SetValue(colUserControl, value);
            }
        }
        #endregion

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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "AutoAnimate", "Appearance",
                                 "Automatically animates the control."));

            items.Add(new DesignerActionPropertyItem("Invert",
                                 "Invert", "Appearance",
                                 "Inverts the progress control."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the animation speed."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                                 "Orientation", "Appearance",
                                 "Sets the progress orientation. Either vertical or horizontal."));

            items.Add(new DesignerActionPropertyItem("Edge",
                                 "Edge", "Appearance",
                                 "Sets the type of edge."));

            items.Add(new DesignerActionPropertyItem("EdgeColor",
                                 "Edge Color", "Appearance",
                                 "Sets the edge color."));

            items.Add(new DesignerActionPropertyItem("EdgeLightColor",
                                 "Edge Light Color", "Appearance",
                                 "Sets the edge light color."));

            items.Add(new DesignerActionPropertyItem("EdgeWidth",
                                 "Edge Width", "Appearance",
                                 "Sets the edgh width."));

            items.Add(new DesignerActionPropertyItem("FloodStyle",
                                 "Flood Style", "Appearance",
                                 "Sets the flood style."));

            items.Add(new DesignerActionPropertyItem("FloodPercentage",
                                 "Flood Percentage", "Appearance",
                                 "Sets the flood level."));

            items.Add(new DesignerActionPropertyItem("BarOffset",
                                 "Bar Offset", "Appearance",
                                 "Sets the bar offset."));

            items.Add(new DesignerActionPropertyItem("DashWidth",
                                 "Dash Width", "Appearance",
                                 "Sets the dash width."));

            items.Add(new DesignerActionPropertyItem("DashSpace",
                                 "Dash Space", "Appearance",
                                 "Sets the dash space."));

            items.Add(new DesignerActionPropertyItem("ProgressBarStyle",
                                 "Progress Bar Style", "Appearance",
                                 "Sets the progressbar style."));

            items.Add(new DesignerActionPropertyItem("MainColor",
                                 "Main Color", "Appearance",
                                 "Sets the main color to use for the control."));

            items.Add(new DesignerActionPropertyItem("SecondColor",
                                 "Second Color", "Appearance",
                                 "Sets the second bacground gradient color."));

            items.Add(new DesignerActionPropertyItem("ProgressBackColor",
                                 "Progress BackColor", "Appearance",
                                 "Sets the progress background color."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value for the progress."));

            items.Add(new DesignerActionPropertyItem("Step",
                                 "Step", "Appearance",
                                 "Sets the progress step."));

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

    #region Info

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        public Info()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    #endregion

    #endregion
}
