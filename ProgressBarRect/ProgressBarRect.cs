// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ProgressBarRect.cs" company="Zeroit Dev Technologies">
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
    #region  ZeroitProgressBarRect

    /// <summary>
    /// A class collection for rendering progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressBarRectDesigner))]
    public class ZeroitProgressBarRect : Control
    {

        #region  RoundRect

        /// <summary>
        /// The create round path
        /// </summary>
        private GraphicsPath CreateRoundPath;

        /// <summary>
        /// Creates the round.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="slope">The slope.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

        #region Private Fields
        /// <summary>
        /// The percent
        /// </summary>
        private double Percent;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// The value colour
        /// </summary>
        private Color _ValueColour = Color.FromArgb(42, 119, 220);
        /// <summary>
        /// The color background
        /// </summary>
        private Color _colorBackground = Color.FromArgb(51, 52, 55);
        /// <summary>
        /// The color border
        /// </summary>
        private Color _colorBorder = Color.FromArgb(51, 52, 55);
        /// <summary>
        /// The corner
        /// </summary>
        private int _corner = 8;
        #endregion

        #region  Custom Properties

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;

                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                if (value > _Value)
                {
                    _Value = value;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the corner for the rectangle.
        /// </summary>
        /// <value>The corner.</value>
        public int Corner
        {
            get { return _corner; }
            set
            {
                _corner = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        [Category("Colours")]
        public Color ProgressColor
        {
            get
            {
                return _ValueColour;
            }
            set
            {
                _ValueColour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color ColorBackground
        {
            get { return _colorBackground; }
            set
            {
                _colorBackground = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color ColorBorder
        {
            get { return _colorBorder; }
            set
            {
                _colorBorder = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Include in Private Field

        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;
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
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                Invalidate();
            }
        }

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
        /// Initializes a new instance of the <see cref="ZeroitProgressBarRect" /> class.
        /// </summary>
        public ZeroitProgressBarRect()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(100, 10);

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

        /// <summary>
        /// Increments the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Increment(int value)
        {
            this._Value += value;
            Invalidate();
        }

        /// <summary>
        /// Deincrements the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Deincrement(int value)
        {
            this._Value -= value;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            timer.Interval = interval;

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            this.Percent = (double)this._Value / (double)this._Maximum * 100;

            int Slope = _corner;
            Rectangle MyRect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath BorderPath = CreateRound(MyRect, Slope);
            G.FillPath(new SolidBrush(_colorBackground), BorderPath);

            ColorBlend ProgressBlend = new ColorBlend(3);
            ProgressBlend.Colors[0] = _ValueColour;
            ProgressBlend.Colors[1] = _ValueColour;
            ProgressBlend.Colors[2] = _ValueColour;
            ProgressBlend.Positions = new Single[] { 0, 0.5F, 1 };
            LinearGradientBrush LGB = new LinearGradientBrush(MyRect, Color.Black, Color.Black, 90.0F);
            LGB.InterpolationColors = ProgressBlend;

            Rectangle ProgressRect = new Rectangle(1, 1, (int)System.Math.Round(((double)this.Width / (double)this._Maximum * (double)this._Value - 3.0)), this.Height - 3);
            GraphicsPath ProgressPath = CreateRound(ProgressRect, Slope);

            if (Percent >= 1)
            {
                G.FillPath(LGB, ProgressPath);
            }

            try
            {
                G.DrawPath(new Pen(_colorBorder), BorderPath);
            }
            catch (Exception)
            {
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarRectDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarRectDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarRectSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarRectSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarRectSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarRect colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarRectSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarRectSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarRect;

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
        /// Gets or sets the corner.
        /// </summary>
        /// <value>The corner.</value>
        public int Corner
        {
            get
            {
                return colUserControl.Corner;
            }
            set
            {
                GetPropertyByName("Corner").SetValue(colUserControl, value);
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
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background.</value>
        public Color ColorBackground
        {
            get
            {
                return colUserControl.ColorBackground;
            }
            set
            {
                GetPropertyByName("ColorBackground").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Sets the control to automatically start."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the Maximum Value."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the Minimum Value."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the Value of the Progress control."));

            items.Add(new DesignerActionPropertyItem("Corner",
                                 "Corner", "Appearance",
                                 "Sets the corner round property of the Progress control."));

            items.Add(new DesignerActionPropertyItem("ProgressColor",
                                 "Value Colour", "Appearance",
                                 "Sets the value of the progress control."));

            items.Add(new DesignerActionPropertyItem("ColorBackground",
                                 "Color Background", "Appearance",
                                 "Sets the Background Color."));

            items.Add(new DesignerActionPropertyItem("ColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the Border Color."));

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
