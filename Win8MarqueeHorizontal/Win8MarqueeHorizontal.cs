// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Win8MarqueeHorizontal.cs" company="Zeroit Dev Technologies">
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
using System.Timers;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Marquee Progress Ring
    // **************************** class Win8MarqueeProgressIndicator    
    /// <summary>
    /// A class collection for rendering a windows 8 progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitWin8MarqueeHorizontalDesigner))]
    public class ZeroitWin8MarqueeHorizontal : Control
    {

        /// <summary>
        /// The control width
        /// </summary>
        const int CONTROL_WIDTH = 462;            // pixels
        /// <summary>
        /// The indicator color
        /// </summary>
        static Color INDICATOR_COLOR = Color.White;  // Color

        /// <summary>
        /// The initial fixed index
        /// </summary>
        const int INITIAL_FIXED_INDEX = 4;        // count
        /// <summary>
        /// The maximum indicators
        /// </summary>
        const int MAXIMUM_INDICATORS = 6;         // count
        /// <summary>
        /// The maximum positions
        /// </summary>
        const int MAXIMUM_POSITIONS = 33;         // count
        /// <summary>
        /// The maximum timer interval
        /// </summary>
        const double MAXIMUM_TIMER_INTERVAL = 200.0; // ms
        /// <summary>
        /// The maximum width
        /// </summary>
        const int MAXIMUM_WIDTH = 462;            // count
        /// <summary>
        /// The minimum timer interval
        /// </summary>
        const double MINIMUM_TIMER_INTERVAL = 10.0;  // ms
        /// <summary>
        /// The minimum width
        /// </summary>
        const int MINIMUM_WIDTH = 99;             // count
        /// <summary>
        /// The positions
        /// </summary>
        const int POSITIONS = 14;                 // count
        /// <summary>
        /// The timer interval
        /// </summary>
        const double TIMER_INTERVAL = 100.0;         // ms

        // ***********************************************************

        /// <summary>
        /// The background
        /// </summary>
        ZeroitWin8MarqueeHorizontalGraphicsBuffer background = null;
        /// <summary>
        /// The control height
        /// </summary>
        int control_height;
        /// <summary>
        /// The control width
        /// </summary>
        int control_width = CONTROL_WIDTH;
        /// <summary>
        /// The indicator
        /// </summary>
        ZeroitWin8MarqueeHorizontalGraphicsBuffer indicator = null;
        /// <summary>
        /// The indicator color
        /// </summary>
        Color indicator_color = INDICATOR_COLOR;
        /// <summary>
        /// The indicator diameter
        /// </summary>
        int indicator_diameter = 0;
        /// <summary>
        /// The position indices
        /// </summary>
        int[] position_indices = new int[
                                               MAXIMUM_INDICATORS];
        /// <summary>
        /// The positions
        /// </summary>
        double[] positions = new double[POSITIONS]
                                {
                                 0.0,
                                 5.0,
                                 9.0,
                                11.0,
                                13.0,   // initial index points here
                                14.0,
                                15.0,
                                16.0,
                                17.0,
                                18.0,
                                20.0,
                                23.0,
                                27.0,
                                32.0,
                                };
        /// <summary>
        /// The refresh rate
        /// </summary>
        int refresh_rate = (int)TIMER_INTERVAL;
        /// <summary>
        /// The revise background graphic
        /// </summary>
        bool revise_background_graphic = true;
        /// <summary>
        /// The timer
        /// </summary>
        System.Timers.Timer timer = null;
        /// <summary>
        /// The timer interval
        /// </summary>
        double timer_interval = TIMER_INTERVAL;

        // ******************************************** memory_cleanup

        /// <summary>
        /// Memories the cleanup.
        /// </summary>
        void memory_cleanup()
        {
            // DeleteGraphicsBuffer 
            // returns null
            if (background != null)
            {
                background = background.DeleteGraphicsBuffer();
            }

            if (indicator != null)
            {
                indicator = indicator.DeleteGraphicsBuffer();
            }

            if (timer != null)
            {
                if (timer.Enabled)
                {
                    timer.Enabled = false;
                }
                timer.Dispose();
                timer = null;
            }
        }

        // ***************************** initialize_indicators_indices

        /// <summary>
        /// Initializes the indicators indices.
        /// </summary>
        void initialize_indicators_indices()
        {
            int index = INITIAL_FIXED_INDEX;

            for (int i = 0; (i < MAXIMUM_INDICATORS); i++)
            {
                position_indices[i] = new int();

                position_indices[i] = index;
                index += 1;
            }
        }

        // ********************************* create_background_graphic

        /// <summary>
        /// Creates the background graphic.
        /// </summary>
        void create_background_graphic()
        {

            if (background != null)
            {
                background = background.DeleteGraphicsBuffer();
            }
            background = new ZeroitWin8MarqueeHorizontalGraphicsBuffer();
            background.CreateGraphicsBuffer(control_width,
                                              control_height);
            background.Graphic.SmoothingMode = SmoothingMode.
                                               HighQuality;
        }

        // ********************************** create_indicator_graphic

        /// <summary>
        /// Creates the indicator graphic.
        /// </summary>
        void create_indicator_graphic()
        {

            if (indicator != null)
            {
                indicator = indicator.DeleteGraphicsBuffer();
            }
            indicator = new ZeroitWin8MarqueeHorizontalGraphicsBuffer();
            indicator.CreateGraphicsBuffer(control_width,
                                             control_height);
            indicator.Graphic.SmoothingMode = SmoothingMode.
                                              HighQuality;
        }

        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        /// <summary>
        /// Rounds the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>System.Int32.</returns>
        int round(double parameter)
        {

            return ((int)(parameter + 0.5));
        }

        // ********************** adjust_control_dimensions_from_width

        /// <summary>
        /// Adjusts the width of the control dimensions from.
        /// </summary>
        /// <param name="new_width">The new width.</param>
        void adjust_control_dimensions_from_width(int new_width)
        {

            indicator_diameter = round(
                                     (double)new_width /
                                     (double)MAXIMUM_POSITIONS);

            control_width = indicator_diameter * MAXIMUM_POSITIONS;
            control_height = indicator_diameter;

            this.Width = control_width;
            this.Height = control_height;
        }

        // ****************************** Win8MarqueeProgressIndicator        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWin8MarqueeHorizontal" /> class.
        /// </summary>
        public ZeroitWin8MarqueeHorizontal()
        {

            initialize_indicators_indices();
            adjust_control_dimensions_from_width(CONTROL_WIDTH);

            this.SetStyle(
                (ControlStyles.DoubleBuffer |
                  ControlStyles.UserPaint |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.SupportsTransparentBackColor),
                true);
            this.UpdateStyles();

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(tick);
            timer.Interval = TIMER_INTERVAL;
            timer.Enabled = true;


        }

        // *************************************************** Animate        

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitWin8MarqueeHorizontal" /> should start/stop animation.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        [Category("Appearance"),
         Description("Start/stops indicator animation"),
         DefaultValue(true),
         Bindable(true)]
        public bool Animate
        {

            get
            {
                return (timer.Enabled);
            }

            set
            {
                timer.Enabled = value;
            }
        }

        // ********************************************* ControlWidth

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width of the control.</value>
        [Category("Appearance"),
         Description("Gets/Sets control width"),
         DefaultValue(100),
         Bindable(true)]
        public int ControlWidth
        {

            get
            {
                return (control_width);
            }
            set
            {
                int old_control_width = control_width;

                control_width = value;

                if (control_width < MINIMUM_WIDTH)
                {
                    control_width = MINIMUM_WIDTH;
                }
                if (control_width > MAXIMUM_WIDTH)
                {
                    control_width = MAXIMUM_WIDTH;
                }

                if (old_control_width != control_width)
                {
                    adjust_control_dimensions_from_width(
                                                    control_width);
                    revise_background_graphic = true;
                    this.Invalidate();
                }
            }
        }

        // ******************************************* IndicatorColor        
        /// <summary>
        /// Gets or sets the color of the moving indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        [Category("Appearance"),
         Description("Gets/Sets color of the moving indicators"),
         DefaultValue(typeof(Color), "White"),
         Bindable(true)]
        public Color IndicatorColor
        {

            get
            {
                return (indicator_color);
            }
            set
            {
                Color old_indicator_color = indicator_color;

                indicator_color = value;
                if (old_indicator_color != indicator_color)
                {
                    revise_background_graphic = true;
                    this.Invalidate();
                }
            }
        }

        // ***************************************************** Pulse

        /// <summary>
        /// Pulses this instance.
        /// </summary>
        public void Pulse()
        {

            this.Invalidate();
        }

        // ********************************************** RefreshRate        
        /// <summary>
        /// Gets or sets how often the indicators move.
        /// </summary>
        /// <value>The refresh rate.</value>
        [Category("Appearance"),
         Description("Specifies how often the indicators move"),
         DefaultValue(200),
         Bindable(true)]
        public int RefreshRate
        {

            get
            {
                return (refresh_rate);
            }

            set
            {
                int old_refresh_rate = refresh_rate;
                bool timer_running = timer.Enabled;

                refresh_rate = value;
                if (refresh_rate < (int)MINIMUM_TIMER_INTERVAL)
                {
                    refresh_rate = (int)MINIMUM_TIMER_INTERVAL;
                }
                if (refresh_rate > (int)MAXIMUM_TIMER_INTERVAL)
                {
                    refresh_rate = (int)MAXIMUM_TIMER_INTERVAL;
                }

                if (timer_running)
                {
                    timer.Stop();
                }

                timer_interval = (double)refresh_rate;
                timer.Interval = timer_interval;

                if (timer_running)
                {
                    timer.Start();
                }

                if (old_refresh_rate != refresh_rate)
                {
                    revise_background_graphic = true;
                    this.Invalidate();
                }
            }
        }

        // *********************************** draw_background_graphic

        /// <summary>
        /// Draws the background graphic.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void draw_background_graphic(Graphics graphics)
        {
            // currently nothing to do
        }

        // ************************************ draw_indicator_graphic

        /// <summary>
        /// Draws the indicator graphic.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void draw_indicator_graphic(Graphics graphics)
        {
            Brush brush = new SolidBrush(IndicatorColor);
            Rectangle rectangle = new Rectangle();

            for (int i = (MAXIMUM_INDICATORS - 1);
                      (i >= 0);
                      i--)
            {
                int index;
                double position;
                int x;
                int y;

                index = position_indices[i];

                if (index >= POSITIONS)
                {
                    index = 0;
                }
                position = positions[index];

                x = round(position *
                            (double)indicator_diameter);
                y = 0;

                rectangle.Location = new Point(x, y);
                rectangle.Size = new Size(indicator_diameter,
                                            indicator_diameter);
                graphics.FillEllipse(brush, rectangle);

                index++;
                position_indices[i] = index;
            }

            brush.Dispose();
        }

        // ****************************************************** tick

        /// <summary>
        /// Ticks the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        void tick(object source,
                    ElapsedEventArgs e)
        {

            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(
                        new EventHandler(
                            delegate
                            {
                                this.Refresh();
                            }
                            )
                        );
                }
                else
                {
                    this.Refresh();
                }
            }

            catch (Exception ex)
            {

            }
        }

        // ****************************************** OnControlRemoved

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlRemoved(
                                                ControlEventArgs e)
        {

            base.OnControlRemoved(e);

            memory_cleanup();
        }

        // ************************************************** OnResize

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);

            adjust_control_dimensions_from_width(this.Width + 1);

            revise_background_graphic = true;

            this.Refresh();
        }

        // *************************************************** OnPaint

        // see community additions in
        // http://msdn.microsoft.com/en-us/library/wk5b13s4(v=vs.90).aspx
        // regarding transparent background

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            {                       // begin transparent background
                Rectangle clip;
                PaintEventArgs pea;
                GraphicsContainer state;

                state = e.Graphics.BeginContainer();
                e.Graphics.TranslateTransform(-this.Left,
                                                -this.Top);
                clip = e.ClipRectangle;
                clip.Offset(this.Left, this.Top);
                pea = new PaintEventArgs(e.Graphics, clip);
                // paint the container's 
                // background
                InvokePaintBackground(this.Parent, pea);
                // paint the container's 
                // foreground
                InvokePaint(this.Parent, pea);
                // restores graphics to 
                // original state
                e.Graphics.EndContainer(state);
            }                       // end transparent background

            if ((background == null) || revise_background_graphic)
            {
                if (revise_background_graphic)
                {
                    revise_background_graphic = false;
                }
                create_background_graphic();
                draw_background_graphic(background.Graphic);
            }
            background.RenderGraphicsBuffer(e.Graphics);

            create_indicator_graphic();
            draw_indicator_graphic(indicator.Graphic);

            indicator.RenderGraphicsBuffer(e.Graphics);
        }

    } // class Win8MarqueeProgressIndicator

    // ****************************************** class GraphicsBuffer

    /// <summary>
    /// Class ZeroitWin8MarqueeHorizontalGraphicsBuffer.
    /// </summary>
    public class ZeroitWin8MarqueeHorizontalGraphicsBuffer
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        Bitmap bitmap;
        /// <summary>
        /// The graphics
        /// </summary>
        Graphics graphics;
        /// <summary>
        /// The height
        /// </summary>
        int height;
        /// <summary>
        /// The width
        /// </summary>
        int width;

        // ******************************************** GraphicsBuffer

        /// <summary>
        /// constructor for the GraphicsBuffer
        /// </summary>
        public ZeroitWin8MarqueeHorizontalGraphicsBuffer()
        {

            width = 0;
            height = 0;
        }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// completes the creation of the GraphicsBuffer object
        /// </summary>
        /// <param name="width">width of the bitmap</param>
        /// <param name="height">height of the bitmap</param>
        /// <returns>true, if GraphicsBuffer created; otherwise, false</returns>
        public bool CreateGraphicsBuffer(int width,
                                           int height)
        {
            bool success = true;

            DeleteGraphicsBuffer();

            this.width = 0;
            this.height = 0;

            if ((width == 0) || (height == 0))
            {
                success = false;
            }
            else
            {
                this.width = width;
                this.height = height;

                bitmap = new Bitmap(this.width, this.height);
                graphics = Graphics.FromImage(bitmap);

                success = true;
            }

            return (success);
        }

        // ************************************** DeleteGraphicsBuffer

        /// <summary>
        /// deletes the current GraphicsBuffer
        /// </summary>
        /// <returns>null, always</returns>
        public ZeroitWin8MarqueeHorizontalGraphicsBuffer DeleteGraphicsBuffer()
        {

            if (graphics != null)
            {
                graphics.Dispose();
                graphics = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            width = 0;
            height = 0;

            return (null);
        }

        // *************************************************** Graphic

        /// <summary>
        /// returns the current Graphic Graphics object
        /// </summary>
        /// <value>The graphic.</value>
        public Graphics Graphic
        {

            get
            {
                return (graphics);
            }
        }

        // ************************************** RenderGraphicsBuffer

        /// <summary>
        /// Renders the buffer to the graphics object identified by
        /// graphic
        /// </summary>
        /// <param name="graphic">target graphics object (e.g., PaintEventArgs e.Graphics)</param>
        public void RenderGraphicsBuffer(Graphics graphic)
        {

            if (bitmap != null)
            {
                graphic.DrawImage(
                            bitmap,
                            new Rectangle(0, 0, width, height),
                            new Rectangle(0, 0, width, height),
                            GraphicsUnit.Pixel);
            }
        }

    } // class GraphicsBuffer



    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitWin8MarqueeHorizontalDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitWin8MarqueeHorizontalDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitWin8MarqueeHorizontalDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitWin8MarqueeHorizontalSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitWin8MarqueeHorizontalSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitWin8MarqueeHorizontalSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitWin8MarqueeHorizontal colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWin8MarqueeHorizontalSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitWin8MarqueeHorizontalSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitWin8MarqueeHorizontal;

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
        /// Gets or sets a value indicating whether this <see cref="ZeroitWin8MarqueeHorizontalSmartTagActionList"/> is animate.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        public bool Animate
        {

            get
            {
                return colUserControl.Animate;
            }
            set
            {
                GetPropertyByName("Animate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width of the control.</value>
        public int ControlWidth
        {

            get
            {
                return colUserControl.ControlWidth;
            }
            set
            {
                GetPropertyByName("ControlWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        public Color IndicatorColor
        {

            get
            {
                return colUserControl.IndicatorColor;
            }
            set
            {
                GetPropertyByName("IndicatorColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the refresh rate.
        /// </summary>
        /// <value>The refresh rate.</value>
        public int RefreshRate
        {

            get
            {
                return colUserControl.RefreshRate;
            }
            set
            {
                GetPropertyByName("RefreshRate").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Animate",
                                 "Animate", "Appearance",
                                 "Sets the control to automatically animate."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("IndicatorColor",
                                 "Indicator Color", "Appearance",
                                 "Sets the indicator color."));

            items.Add(new DesignerActionPropertyItem("ControlWidth",
                                 "Control Width", "Appearance",
                                 "Sets the width of the control."));

            items.Add(new DesignerActionPropertyItem("RefreshRate",
                                 "Refresh Rate", "Appearance",
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
