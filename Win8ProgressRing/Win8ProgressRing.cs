// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Win8ProgressRing.cs" company="Zeroit Dev Technologies">
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
    #region ProgressRing

    #region Control
    // *************************************** class Win8_ProgressRing    
    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitWin8ProgressRingDesigner))]
    public partial class ZeroitWin8ProgressRing : Control
    {

        #region Constants
        // *********************************** constants and variables

        /// <summary>
        /// The control height
        /// </summary>
        const int CONTROL_HEIGHT = 100;           // pixels
        /// <summary>
        /// The control width
        /// </summary>
        const int CONTROL_WIDTH = CONTROL_HEIGHT; // pixels
        /// <summary>
        /// The indicator color
        /// </summary>
        static Color INDICATOR_COLOR = Color.White;  // Color
        /// <summary>
        /// The indicator offset
        /// </summary>
        const double INDICATOR_OFFSET = 11.25;       // deg
        /// <summary>
        /// The maximum indicators
        /// </summary>
        const int MAXIMUM_INDICATORS = 6;         // units
        /// <summary>
        /// The size factor
        /// </summary>
        const int SIZE_FACTOR = 20;               // pixels
        /// <summary>
        /// The start at
        /// </summary>
        const double START_AT = 120.0;                // deg
        /// <summary>
        /// The timer interval
        /// </summary>
        const double TIMER_INTERVAL = 100.0;         // ms 
        #endregion

        #region Variables
        // ***********************************************************

        /// <summary>
        /// The background
        /// </summary>
        ZeroitWin8ProgressRingGraphicsBuffer background = null;
        /// <summary>
        /// The control height
        /// </summary>
        int control_height = CONTROL_HEIGHT;
        /// <summary>
        /// The control width
        /// </summary>
        int control_width = CONTROL_WIDTH;
        /// <summary>
        /// The indicator
        /// </summary>
        ZeroitWin8ProgressRingGraphicsBuffer indicator = null;
        /// <summary>
        /// The indicator center radius
        /// </summary>
        int indicator_center_radius = 0;
        /// <summary>
        /// The indicator color
        /// </summary>
        Color indicator_color = INDICATOR_COLOR;
        /// <summary>
        /// The indicator diameter
        /// </summary>
        int indicator_diameter = 0;
        /// <summary>
        /// The indicator radius
        /// </summary>
        int indicator_radius = 0;
        /// <summary>
        /// The indicators
        /// </summary>
        Indicator[] indicators = new Indicator[
                                                MAXIMUM_INDICATORS];
        /// <summary>
        /// The inner radius
        /// </summary>
        int inner_radius = 0;
        /// <summary>
        /// The outer radius
        /// </summary>
        int outer_radius = 0;
        /// <summary>
        /// The p0
        /// </summary>
        Point P0 = Point.Empty;
        /// <summary>
        /// The refresh rate
        /// </summary>
        int refresh_rate = (int)TIMER_INTERVAL;
        /// <summary>
        /// The revise background graphic
        /// </summary>
        bool revise_background_graphic = true;
        /// <summary>
        /// The start at
        /// </summary>
        double start_at = START_AT;
        /// <summary>
        /// The timer
        /// </summary>
        System.Timers.Timer timer = null;
        /// <summary>
        /// The timer interval
        /// </summary>
        double timer_interval = TIMER_INTERVAL;
        // trigonometry tables
        /// <summary>
        /// The cosine
        /// </summary>
        double[] cosine = new double[1440];
        /// <summary>
        /// The sine
        /// </summary>
        double[] sine = new double[1440];
        #endregion

        #region Private Methods
        // ************************************************* deg_2_rad

        /// <summary>
        /// Degs the 2 RAD.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Double.</returns>
        double deg_2_rad(double degrees)
        {

            return (System.Math.PI * (degrees / 180.0));
        }



        // **************************** initialize_trigonometry_tables

        /// <summary>
        /// Initializes the trigonometry tables.
        /// </summary>
        void initialize_trigonometry_tables()
        {

            for (int i = 0; (i < sine.Length); i++)
            {
                double degrees = 0.25 * (double)i;
                double radians = deg_2_rad(degrees);

                sine[i] = System.Math.Sin(radians);
                cosine[i] = System.Math.Cos(radians);
            }
        }

        // ******************************************************* cos

        /// <summary>
        /// Coses the specified degrees.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Double.</returns>
        double cos(double degrees)
        {
            int index = round(degrees / 0.25);

            return (cosine[index]);
        }

        // ******************************************************* sin

        /// <summary>
        /// Sins the specified degrees.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns>System.Double.</returns>
        double sin(double degrees)
        {
            int index = round(degrees / 0.25);

            return (sine[index]);
        }

        // ************************************* initialize_indicators

        /// <summary>
        /// Initializes the indicators.
        /// </summary>
        void initialize_indicators()
        {
            double degrees = start_at;

            for (int i = 0; (i < MAXIMUM_INDICATORS); i++)
            {
                if (degrees < 0.0)
                {
                    degrees += 360.0;
                }

                indicators[i] = new Indicator(degrees);

                degrees -= INDICATOR_OFFSET;
            }
        }
        #endregion

        #region Memory Cleanup
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
        }
        #endregion

        #region Round Method
        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        /// <summary>
        /// Rounds the specified control value.
        /// </summary>
        /// <param name="control_value">The control value.</param>
        /// <returns>System.Int32.</returns>
        int round(double control_value)
        {

            return ((int)(control_value + 0.5));
        }
        #endregion

        #region Create Background Graphic
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
            background = new ZeroitWin8ProgressRingGraphicsBuffer();
            background.CreateGraphicsBuffer(control_width,
                                              control_height);
            background.Graphic.SmoothingMode = SmoothingMode.
                                               HighQuality;
        }
        #endregion

        #region Create Indicator Graphic
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
            indicator = new ZeroitWin8ProgressRingGraphicsBuffer();
            indicator.CreateGraphicsBuffer(control_width,
                                             control_height);
            indicator.Graphic.SmoothingMode = SmoothingMode.
                                              HighQuality;
        }
        #endregion

        #region Adjust Control Dimensions from height
        // ********************* adjust_control_dimensions_from_height

        /// <summary>
        /// Adjusts the height of the control dimensions from.
        /// </summary>
        /// <param name="new_height">The new height.</param>
        void adjust_control_dimensions_from_height(int new_height)
        {

            indicator_radius = round((double)new_height /
                                       (double)SIZE_FACTOR);
            indicator_diameter = 2 * indicator_radius;

            control_height = SIZE_FACTOR * indicator_radius;
            control_width = control_height;

            outer_radius = control_height / 2;
            inner_radius = outer_radius - indicator_diameter;

            indicator_center_radius = inner_radius +
                                      indicator_radius;

            this.Height = control_height;
            this.Width = control_width;
        }
        #endregion

        #region Constructor
        // ***************************************** Win8_ProgressRing        

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWin8ProgressRing" /> class.
        /// </summary>
        public ZeroitWin8ProgressRing()
        {

            initialize_trigonometry_tables();
            adjust_control_dimensions_from_height(CONTROL_HEIGHT);
            initialize_indicators();

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

        #endregion

        #region Public Properties
        // *************************************************** Animate        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitWin8ProgressRing" /> should start or stop.
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

        // ******************************************** ControlHeight        
        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        [Category("Appearance"),
         Description("Gets/Sets control height"),
         DefaultValue(100),
         Bindable(true)]
        public int ControlHeight
        {

            get
            {
                return (control_height);
            }
            set
            {
                int old_control_height = control_height;

                control_height = value;
                if (old_control_height != control_height)
                {
                    adjust_control_dimensions_from_height(value);
                    revise_background_graphic = true;
                    this.Invalidate();
                }
            }
        }

        // ******************************************* IndicatorColor        
        /// <summary>
        /// Gets or sets the color of the indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        [Category("Appearance"),
         Description("Gets/Sets color of the rotating indicators"),
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
        /// Gets or sets the indicator rotational refresh.
        /// </summary>
        /// <value>The refresh rate.</value>
        [Category("Appearance"),
         Description("Specifies indicator rotational refresh"),
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
                if (refresh_rate < 10)
                {
                    refresh_rate = 10;
                }
                if (refresh_rate > 200)
                {
                    refresh_rate = 200;
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

        #endregion

        #region Draw Background Graphics
        // *********************************** draw_background_graphic

        /// <summary>
        /// Draws the background graphic.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        void draw_background_graphic(Graphics graphics)
        {
            // currently nothing to do
        }
        #endregion

        #region Draw Indicator Graphic
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
                double degrees = indicators[i].Degrees;
                int dx;
                int dy;

                if (degrees < 0.0)
                {
                    degrees += 360.0;
                }

                dx = round((double)indicator_center_radius *
                             cos(degrees)) +
                     indicator_center_radius;
                dy = indicator_center_radius -
                     round((double)indicator_center_radius *
                             sin(degrees));

                rectangle.Location = new Point(dx, dy);
                rectangle.Size = new Size(indicator_diameter,
                                            indicator_diameter);
                graphics.FillEllipse(brush, rectangle);

                degrees -= (double)indicators[i].Fast *
                           INDICATOR_OFFSET;

                if (indicators[i].Fast > 1.0)
                {
                    indicators[i].Fast += 0.25;
                }

                if (degrees < 0.0)
                {
                    indicators[i].Fast = 1.25;
                }
                else if (degrees < START_AT)
                {
                    indicators[i].Fast = 1.0;
                }

                indicators[i].Degrees = degrees;
            }

            brush.Dispose();
        }
        #endregion

        #region Events and Overrides
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

            adjust_control_dimensions_from_height(this.Height);

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

        #endregion

    } // class Win8_ProgressRing

    #endregion

    #region Class Indicator

    // *********************************************** class Indicator

    /// <summary>
    /// Class Indicator.
    /// </summary>
    public class Indicator
    {
        /// <summary>
        /// The degrees
        /// </summary>
        double degrees = 0.0;
        /// <summary>
        /// The fast
        /// </summary>
        double fast = 1.0;

        // ************************************************* Indicator

        /// <summary>
        /// Initializes a new instance of the <see cref="Indicator"/> class.
        /// </summary>
        public Indicator()
        {

            Degrees = 0.0;
            Fast = 1.0;
        }

        // ************************************************* Indicator

        /// <summary>
        /// Initializes a new instance of the <see cref="Indicator"/> class.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        public Indicator(double degrees)
        {

            Degrees = degrees;
            Fast = 1.0;
        }

        // *************************************************** Degrees

        /// <summary>
        /// Gets or sets the degrees.
        /// </summary>
        /// <value>The degrees.</value>
        public double Degrees
        {

            get
            {
                return (degrees);
            }
            set
            {
                degrees = value;
            }
        }

        // ****************************************************** Fast

        /// <summary>
        /// Gets or sets the fast.
        /// </summary>
        /// <value>The fast.</value>
        public double Fast
        {

            get
            {
                return (fast);
            }
            set
            {
                fast = value;
            }
        }

    } // class Indicator 
    #endregion

    #region Graphics Buffer
    // ****************************************** class GraphicsBuffer

    /// <summary>
    /// Class ZeroitWin8ProgressRingGraphicsBuffer.
    /// </summary>
    public class ZeroitWin8ProgressRingGraphicsBuffer
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
        public ZeroitWin8ProgressRingGraphicsBuffer()
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
        public ZeroitWin8ProgressRingGraphicsBuffer DeleteGraphicsBuffer()
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
    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitWin8MarqueeHorizontalDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitWin8ProgressRingDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitWin8ProgressRingDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitWin8ProgressRingSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitWin8ProgressRingSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitWin8ProgressRingSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitWin8ProgressRing colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitWin8ProgressRingSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitWin8ProgressRingSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitWin8ProgressRing;

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
        /// Gets or sets a value indicating whether this <see cref="ZeroitWin8ProgressRingSmartTagActionList"/> is animate.
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
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        public int ControlHeight
        {

            get
            {
                return colUserControl.ControlHeight;
            }
            set
            {
                GetPropertyByName("ControlHeight").SetValue(colUserControl, value);
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
                                 "Sets the color of the indicator."));

            items.Add(new DesignerActionPropertyItem("ControlHeight",
                                 "Control Height", "Appearance",
                                 "Sets the control height."));

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
