// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="PieProgressCircle.cs" company="Zeroit Dev Technologies">
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
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Pie Progress
    /// <summary>
    /// This control is designed primarily to be a progress bar. But it's shape is circular.<br />
    /// Unlike the <c><see cref="System.Windows.Forms.ProgressBar" /></c>, it has no upper limit. You may use it in the processes that you don't know when it finishes.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
	[ToolboxBitmap(typeof(Zeroit.Framework.Progress.ZeroitPieProgressCircle), "CircleToolboxBitmap.bmp")]
    [Designer(typeof(ZeroitPieProgressCircleDesigner))]
    public class ZeroitPieProgressCircle : System.Windows.Forms.UserControl
    {
        #region Private Fields
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// The seperator angle
        /// </summary>
        private int SeperatorAngle = 5;

        /// <summary>
        /// The index
        /// </summary>
        private int _index;
        /// <summary>
        /// The number of arcs
        /// </summary>
        private int _numberOfArcs;
        /// <summary>
        /// The ring thickness
        /// </summary>
        private int _ringThickness;
        /// <summary>
        /// The ring color
        /// </summary>
        private Color _ringColor;
        /// <summary>
        /// The number of tail
        /// </summary>
        private int _numberOfTail;

        /// <summary>
        /// The animate
        /// </summary>
        private bool animate = false;


        #endregion

        #region Unused Code
        /// <summary>
        /// To start the animation, set this true.<br />
        /// To stop, set it false.
        /// </summary>
        //[
        //System.ComponentModel.Browsable(true),
        //DefaultValue(false),
        //DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        //]
        //public bool Animate
        //{
        //    get
        //    {
        //        return animate;
        //    }
        //    set
        //    {

        //        animate = value;

        //        if(value == true)
        //        {
        //            this.Rotate = true;

        //        }

        //        else
        //        {
        //            this.Rotate = false;

        //        }

        //        Invalidate();
        //    }
        //} 
        #endregion

        #region Public Properties


        #region Smoothing Mode

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
        /// This is the number of pies, following the moving pie.
        /// </summary>
        /// <value>The number of tail.</value>
        /// <exception cref="ArgumentOutOfRangeException">Value can not be zero</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Value can not be less than zero</exception>
        [
        Category("ProgressRing"),
        DefaultValue(4),
        Bindable(true)
        ]
        public int NumberOfTail
        {
            get
            {
                return this._numberOfTail;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Value can not be zero");

                this._numberOfTail = value;

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Background color for the moving pie.
        /// </summary>
        /// <value>The color of the ring.</value>
        /// <remarks>Default color is white</remarks>
        [
        Category("ProgressRing"),
        Bindable(true)
        ]
        public Color RingColor
        {
            get
            {
                // Default ring color is White
                if (this._ringColor == Color.Empty)
                    return Color.White;

                return this._ringColor;
            }
            set
            {
                this._ringColor = value;

                // Redraw the control
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Background color for the background pies.
        /// </summary>
        /// <value>The color of the fore.</value>
        [
        Category("ProgressRing"),
        Bindable(true)
        ]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;

                // Redraw the control
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Number of pies that will be places inside the cicle.
        /// </summary>
        /// <value>The number of arcs.</value>
        /// <exception cref="ArgumentOutOfRangeException">Value must be greater than zero</exception>
        /// <exception cref="ArgumentException">360 should be divisible by NumberOfArcs property. 360 is not divisible by " + value.ToString()</exception>
        /// <exception cref="System.ArgumentException">360 should be divisible by the value given.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be greater than zero.</exception>
        /// <remarks>Value should be a divisor of 360 (In other words when 360 is divided to value, the result must be integer).</remarks>
        [
        Category("ProgressRing"),
        DefaultValue(8),
        Bindable(true)
        ]
        public int NumberOfArcs
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value must be greater than zero");

                // 360 degree is the total angle of a circle.
                if ((360 % value) != 0)
                    throw new ArgumentException("360 should be divisible by NumberOfArcs property. 360 is not divisible by " + value.ToString());

                this._numberOfArcs = value;

                this.UpdateStyles();
                this.Invalidate();
            }
            get
            {
                return this._numberOfArcs;
            }
        }

        /// <summary>
        /// Radius of the circle.
        /// </summary>
        /// <value>The ring thickness.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Value must be greater than zero
        /// or
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be greater than zero<br /></exception>
        /// <remarks>Value must be greater than the half of the width or height.</remarks>
        [
        Category("ProgressRing"),
        DefaultValue(5),
        Bindable(true)
        ]
        public int RingThickness
        {
            get
            {
                return this._ringThickness;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value must be greater than zero");

                // Value cannot be bigger than the rectanle.
                int limit = System.Math.Min(this.Width, this.Height) / 2;
                if (value >= limit)
                    throw new ArgumentOutOfRangeException(string.Format("Value must be smaller than {0} for this size, {1}", limit, this.ClientRectangle.ToString()));

                this._ringThickness = value;

                // Redraw control
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// To start the animation, set this true.<br />
        /// To stop, set it false.
        /// </summary>
        /// <value><c>true</c> if rotate; otherwise, <c>false</c>.</value>
        /// <remarks>After stopping the animation, you may clear the rotating part, by calling <c>Clear</c> method.</remarks>
        [
        System.ComponentModel.Browsable(true),
        DefaultValue(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]

        public bool Rotate
        {
            get
            {
                return this.timer.Enabled;
            }
            set
            {
                this.timer.Enabled = value;
            }
        }

        /// <summary>
        /// This value is in miliseconds. Greater interval, slow animation.
        /// </summary>
        /// <value>The interval.</value>
        [
        Category("ProgressRing"),
        DefaultValue(150),
        Bindable(true)
        ]
        public int Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is transparent.
        /// </summary>
        /// <value><c>true</c> if this instance is transparent; otherwise, <c>false</c>.</value>
        public bool IsTransparent
        {
            get
            {
                return (this.BackColor == Color.Transparent);
            }
        }

        /// <summary>
        /// Gets the pie angle.
        /// </summary>
        /// <value>The pie angle.</value>
        private int PieAngle
        {
            get
            {
                // value is the pie that will be drawn and the seperator angle
                int angleOfPieWithSeperator = 360 / this.NumberOfArcs;

                // This is the pie that will be drawn to the client
                int pieAngle = angleOfPieWithSeperator - this.SeperatorAngle;

                return pieAngle;
            }
        }

        #endregion


        /// <summary>
        /// Default constructor.
        /// </summary>
        public ZeroitPieProgressCircle()
        {
            // To minimize the flicking
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            // Enable transparent BackColor
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Redraw the control after its size is changed
            this.ResizeRedraw = true;

            // Never use this property. This indicated which pie will be drawn.
            this._index = 1;

            this._numberOfArcs = 8;
            this._ringThickness = 5;
            this._ringColor = Color.Empty;
            this._numberOfTail = 4;


            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 150; // Each 150 miliseconds, the progress circle will be drawn again
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Enabled = true;

        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            // Clears the pies with default ring color
            using (Graphics grp = this.CreateGraphics())
                this.FillEmptyArcs(grp);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!this.IsTransparent)
                base.OnPaintBackground(pevent);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
            {
                this.timer.Enabled = false;
            }
        }

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                if (IsTransparent)
                    p.ExStyle |= 0x20;
                return p;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Move" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMove(EventArgs e)
        {
            if (!IsTransparent)
                base.OnMove(e);
            else
                this.RecreateHandle();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            this.UpdateStyles();
            base.OnBackColorChanged(e);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothing;

            // Fill static ring part
            this.FillEmptyArcs(e.Graphics);

            // Fill animation part
            this.FillPieAndTail();
        }

        /// <summary>
        /// This method draws the static, non-animation part.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        private void FillEmptyArcs(Graphics grp)
        {
            grp.SmoothingMode = smoothing;
            int startAngle = 0;

            for (int i = 0; i < this.NumberOfArcs; i++)
            {
                this.DrawFilledArc(grp, this.RingColor, startAngle);

                startAngle += this.PieAngle + this.SeperatorAngle;
            }
        }

        /// <summary>
        /// Draws the filled arc.
        /// </summary>
        /// <param name="grp">The GRP.</param>
        /// <param name="color">The color.</param>
        /// <param name="startAngle">The start angle.</param>
        private void DrawFilledArc(Graphics grp, Color color, int startAngle)
        {
            grp.SmoothingMode = smoothing;

            Rectangle main = this.ClientRectangle;

            // If there is no region to be drawn, then this method terminates itself
            if (main.Width - (2 * this._ringThickness) < 1 || main.Height - (2 * this._ringThickness) <= 1)
                return;

            // Calculates the region that will be filled
            GraphicsPath outerPath = new GraphicsPath();
            outerPath.AddPie(main, startAngle, this.PieAngle);

            Rectangle sub = new Rectangle(main.X + this._ringThickness, main.Y + this._ringThickness, main.Width - (2 * this._ringThickness), main.Height - (2 * this._ringThickness));
            GraphicsPath innerPath = new GraphicsPath();
            innerPath.AddPie(sub, startAngle - 1, this.PieAngle + 2);

            System.Drawing.Region mainRegion = new Region(outerPath);
            System.Drawing.Region subRegion = new Region(innerPath);
            mainRegion.Exclude(subRegion);


            // Fill that region
            grp.FillRegion(new SolidBrush(color), mainRegion);


        }

        /// <summary>
        /// Changes the index.
        /// </summary>
        private void ChangeIndex()
        {
            // Fills the animation part
            this.FillPieAndTail();

            // After the invocation of this method, index is changed. So at another invocation of this method, next pie will be drawn
            this._index = (this._index + 1) % this.NumberOfArcs;
        }

        /// <summary>
        /// Draws the animation part
        /// </summary>
        private void FillPieAndTail()
        {
            Color color = this.ForeColor;

            for (int i = 0; i <= this.NumberOfTail; i++)
            {
                this.FillPieAccordingToTheIndex(this._index - i, color);

                // If there is tail, then the tail color is the lighter of the ForeColor
                color = ControlPaint.Light(color);

            }

            // Background Pie
            this.FillPieAccordingToTheIndex(this._index - (this.NumberOfTail + 1), this.RingColor);
        }

        /// <summary>
        /// Fills the index of the pie according to the.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="color">The color.</param>
        private void FillPieAccordingToTheIndex(int index, Color color)
        {
            int count = index % this.NumberOfArcs;
            int angle = count * (this.PieAngle + this.SeperatorAngle);

            using (Graphics grp = this.CreateGraphics())
            {
                grp.SmoothingMode = smoothing;
                this.DrawFilledArc(grp, color, angle);
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ChangeIndex();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPieProgressCircleDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPieProgressCircleDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPieProgressCircleSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPieProgressCircleSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPieProgressCircleSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPieProgressCircle colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPieProgressCircleSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPieProgressCircleSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPieProgressCircle;

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

        #region Public Properties


        #region Smoothing Mode


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

        #endregion


        /// <summary>
        /// Gets or sets the number of tail.
        /// </summary>
        /// <value>The number of tail.</value>
        public int NumberOfTail
        {
            get
            {
                return colUserControl.NumberOfTail;
            }
            set
            {
                GetPropertyByName("NumberOfTail").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the ring.
        /// </summary>
        /// <value>The color of the ring.</value>
        public Color RingColor
        {
            get
            {
                return colUserControl.RingColor;
            }
            set
            {
                GetPropertyByName("RingColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of arcs.
        /// </summary>
        /// <value>The number of arcs.</value>
        public int NumberOfArcs
        {
            get
            {
                return colUserControl.NumberOfArcs;
            }
            set
            {
                GetPropertyByName("NumberOfArcs").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ring thickness.
        /// </summary>
        /// <value>The ring thickness.</value>
        public int RingThickness
        {
            get
            {
                return colUserControl.RingThickness;
            }
            set
            {
                GetPropertyByName("RingThickness").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitPieProgressCircleSmartTagActionList"/> is rotate.
        /// </summary>
        /// <value><c>true</c> if rotate; otherwise, <c>false</c>.</value>
        public bool Rotate
        {
            get
            {
                return colUserControl.Rotate;
            }
            set
            {
                GetPropertyByName("Rotate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
        {
            get
            {
                return colUserControl.Interval;
            }
            set
            {
                GetPropertyByName("Interval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is transparent.
        /// </summary>
        /// <value><c>true</c> if this instance is transparent; otherwise, <c>false</c>.</value>
        public bool IsTransparent
        {
            get
            {
                return colUserControl.IsTransparent;
            }
            set
            {
                GetPropertyByName("IsTransparent").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the paint mode."));

            items.Add(new DesignerActionPropertyItem("NumberOfTail",
                                 "Number Of Tail", "Appearance",
                                 "Sets the number of visible tail."));

            items.Add(new DesignerActionPropertyItem("RingColor",
                                 "Ring Color", "Appearance",
                                 "Sets the ring color of the control."));

            items.Add(new DesignerActionPropertyItem("NumberOfArcs",
                                 "Number Of Arcs", "Appearance",
                                 "Sets the number of arcs."));

            items.Add(new DesignerActionPropertyItem("RingThickness",
                                 "Ring Thickness", "Appearance",
                                 "Sets the ring thickness."));

            items.Add(new DesignerActionPropertyItem("Rotate",
                                 "Rotate", "Appearance",
                                 "Set to allow rotating animation."));

            items.Add(new DesignerActionPropertyItem("Interval",
                                 "Interval", "Appearance",
                                 "Sets the animation speed."));


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
