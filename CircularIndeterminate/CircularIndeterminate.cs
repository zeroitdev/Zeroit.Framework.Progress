// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CircularIndeterminate.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Indeterminate ProgressBar

    // *************************** class ZeroitCircularIndeterminate

    /// <summary>
    /// A class collection for rendering a progress indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ZeroitCircularIndeterminate : UserControl
    {
        /// <summary>
        /// Enum that represents the type of indicator for <c><see cref="ZeroitCircularIndeterminate" /></c>.
        /// </summary>
        public enum INDICATORTYPES
        {
            /// <summary>
            /// The animated
            /// </summary>
            ANIMATED,
            /// <summary>
            /// The pulsed
            /// </summary>
            PULSED
        };

        #region Private Fields
        /// <summary>
        /// The maximum circles count
        /// </summary>
        const int MAXIMUM_CIRCLES_COUNT = 10;
        /// <summary>
        /// The minimum circles count
        /// </summary>
        const int MINIMUM_CIRCLES_COUNT = 5;
        /// <summary>
        /// The default circles count
        /// </summary>
        const int DEFAULT_CIRCLES_COUNT = 5;

        /// <summary>
        /// The maximum control width height
        /// </summary>
        const int MAXIMUM_CONTROL_WIDTH_HEIGHT = 400;
        /// <summary>
        /// The minimum control width height
        /// </summary>
        const int MINIMUM_CONTROL_WIDTH_HEIGHT = 20;
        /// <summary>
        /// The default control width height
        /// </summary>
        const int DEFAULT_CONTROL_WIDTH_HEIGHT = 30;

        /// <summary>
        /// The maximum indicator diameter
        /// </summary>
        const int MAXIMUM_INDICATOR_DIAMETER = 100;
        /// <summary>
        /// The minimum indicator diameter
        /// </summary>
        const int MINIMUM_INDICATOR_DIAMETER = 4;
        /// <summary>
        /// The default indicator diameter
        /// </summary>
        const int DEFAULT_INDICATOR_DIAMETER = 8;

        /// <summary>
        /// The maximum refresh rate
        /// </summary>
        const int MAXIMUM_REFRESH_RATE = 300;
        /// <summary>
        /// The minimum refresh rate
        /// </summary>
        const int MINIMUM_REFRESH_RATE = 10;
        /// <summary>
        /// The default refresh rate
        /// </summary>
        const int DEFAULT_REFRESH_RATE = 100;

        /// <summary>
        /// The background color
        /// </summary>
        private Color background_color =
                                    SystemColors.Control;
        /// <summary>
        /// The circles count
        /// </summary>
        private int circles_count = DEFAULT_CIRCLES_COUNT;
        /// <summary>
        /// The control color
        /// </summary>
        private Color control_color = SystemColors.Control;
        /// <summary>
        /// The control graphic
        /// </summary>
        private IndeterminateProgressGraphicsBuffer control_graphic = null;
        /// <summary>
        /// The control width height
        /// </summary>
        private int control_width_height =
                                    DEFAULT_CONTROL_WIDTH_HEIGHT;
        /// <summary>
        /// The indicator angle
        /// </summary>
        private float indicator_angle = 0.0F;
        /// <summary>
        /// The indicator angular advance
        /// </summary>
        private float indicator_angular_advance = 0.7F;
        /// <summary>
        /// The indicator color
        /// </summary>
        private Color indicator_color = Color.Black;
        /// <summary>
        /// The indicator diameter
        /// </summary>
        private int indicator_diameter =
                                    DEFAULT_INDICATOR_DIAMETER;
        /// <summary>
        /// The indicator graphic
        /// </summary>
        private IndeterminateProgressGraphicsBuffer indicator_graphic = null;
        /// <summary>
        /// The indicator type
        /// </summary>
        private INDICATORTYPES indicator_type =
                                    INDICATORTYPES.ANIMATED;
        /// <summary>
        /// The phi
        /// </summary>
        private float phi;
        /// <summary>
        /// The r
        /// </summary>
        private float R;
        /// <summary>
        /// The r
        /// </summary>
        private float r;
        /// <summary>
        /// The refresh rate
        /// </summary>
        private int refresh_rate = DEFAULT_REFRESH_RATE;
        /// <summary>
        /// The theta
        /// </summary>
        private float theta;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer;

        #endregion

        // ********************************* update_indicator_geometry

        /// <summary>
        /// phi is one-half the angle subtended by one indicator
        /// circle as measured from the center of the control; phi is
        /// dependent upon the control and indicator diameters; theta
        /// is two times phi and is the angular shift from center to
        /// center of two adjacent indicator circles
        /// the centers of the indicator circle are at
        /// ( R, phi + i * theta ) | i = 0, n;
        /// n = number of circles
        /// invoke this method when ever the indicator diameter or the
        /// control width/height are changed
        /// </summary>
        /// <remarks>note that phi is negative because when drawing the
        /// indicator circles, we move counterclockwise; likewise
        /// because the indicator moves clockwise, we must flip the
        /// sign of theta</remarks>
        void update_indicator_geometry()
        {

            r = (float)IndicatorDiameter / 2.0F;
            R = ((float)ControlWidthHeight / 2.0F) - r;
            phi = -(float)System.Math.Atan2((double)r,
                                          (double)R);
            theta = 2.0F * phi;
            indicator_angular_advance = -theta;
        }

        // ********************************************* lighter_color

        // http://stackoverflow.com/questions/801406/
        //     c-create-a-lighter-darker-color-based-on-a-system-color

        /// <summary>
        /// Lighters the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>Color.</returns>
        Color lighter_color(Color color,
                              float factor)
        {
            Color new_color = Color.Black;

            try
            {
                float red = (255 - color.R) * factor + color.R;
                float green = (255 - color.G) * factor + color.G;
                float blue = (255 - color.B) * factor + color.B;

                new_color = Color.FromArgb(color.A,
                                             (int)red,
                                             (int)green,
                                             (int)blue);
            }
            catch (Exception ex)
            {
                new_color = Color.Black;
            }

            return (new_color);
        }

        // ****************************** memory_cleanup event handler

        /// <summary>
        /// Handles the cleanup event of the memory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void memory_cleanup(object sender,
                                      EventArgs e)
        {

            if (control_graphic != null)
            {
                control_graphic =
                    control_graphic.DeleteGraphicsBuffer();
            }

            if (indicator_graphic != null)
            {
                indicator_graphic =
                    indicator_graphic.DeleteGraphicsBuffer();
            }
        }

        // ***************************** ZeroitCircularIndeterminate

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCircularIndeterminate" /> class.
        /// </summary>
        public ZeroitCircularIndeterminate()
        {

            InitializeComponent();

            Application.ApplicationExit += new EventHandler(
                                                   memory_cleanup);
            memory_cleanup(this, EventArgs.Empty);
            // order important
            indicator_diameter = DEFAULT_INDICATOR_DIAMETER;
            control_width_height = DEFAULT_CONTROL_WIDTH_HEIGHT;
            update_indicator_geometry();

            this.Width = ControlWidthHeight;
            this.Height = this.Width;

            background_color = SystemColors.Control;
            circles_count = DEFAULT_CIRCLES_COUNT;
            control_color = SystemColors.Control;
            indicator_angle = 0.0F;
            indicator_color = Color.Black;
            indicator_type = INDICATORTYPES.ANIMATED;
            refresh_rate = DEFAULT_REFRESH_RATE;
            // order important here!!
            this.SetStyle((ControlStyles.DoubleBuffer |
                              ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint),
                            true);
            this.UpdateStyles();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = refresh_rate;
            timer.Tick += new EventHandler(Pulse);
            timer.Start();
            timer.Enabled = true;
        }

        // ************************************ create_control_graphic

        /// <summary>
        /// deletes any existing control graphic and then creates a
        /// new one
        /// </summary>
        void create_control_graphic()
        {
            Rectangle bounding_rectangle;

            if (control_graphic != null)
            {
                control_graphic =
                    control_graphic.DeleteGraphicsBuffer();
            }

            control_graphic = new IndeterminateProgressGraphicsBuffer();

            if (control_graphic.CreateGraphicsBuffer(
                            this.CreateGraphics(),
                            ControlWidthHeight,
                            ControlWidthHeight))
            {
                control_graphic.g.SmoothingMode =
                                  SmoothingMode.HighQuality;
                bounding_rectangle = this.ClientRectangle;
                bounding_rectangle.Inflate(1, 1);
                control_graphic.g.FillRectangle(
                    new SolidBrush(BackgroundColor),
                    bounding_rectangle);
                bounding_rectangle.Inflate(-1, -1);
            }
        }

        // **************************************** polar_to_cartesian

        // http://en.wikipedia.org/wiki/Polar_coordinate_system

        /// <summary>
        /// Polars to cartesian.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="theta">The theta.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void polar_to_cartesian(float radius,
                                             float theta,  // radians
                                         out int x,
                                         out int y)
        {
            double r = (double)radius;
            double t = (double)theta;

            x = (int)(r * System.Math.Cos(t));
            y = (int)(r * System.Math.Sin(t));
        }

        // ********************************** create_indicator_graphic

        /// <summary>
        /// this method creates a new indicator graphic that is the
        /// size of the control graphic; it rotates clockwise around
        /// the center of the control graphic; the indicator graphic
        /// initially has its leading edge at the x-axis; any existing
        /// indicator graphic will be deleted
        /// </summary>
        void create_indicator_graphic()
        {
            // effectively erases the 
            // background
            if (control_graphic == null)
            {
                create_control_graphic();
            }

            if (indicator_graphic != null)
            {
                indicator_graphic =
                    indicator_graphic.DeleteGraphicsBuffer();
            }

            indicator_graphic = new IndeterminateProgressGraphicsBuffer();

            update_indicator_geometry();

            if (indicator_graphic.CreateGraphicsBuffer(
                            this.CreateGraphics(),
                            ControlWidthHeight,
                            ControlWidthHeight))
            {
                Color color = IndicatorColor;
                Graphics graphics = indicator_graphic.g;
                Rectangle indicator_bounding_rectangle;
                Size size = new Size((int)(2.0F * r),
                                              (int)(2.0F * r));

                indicator_graphic.g.SmoothingMode =
                                  SmoothingMode.HighQuality;
                indicator_bounding_rectangle = this.ClientRectangle;
                indicator_graphic.g.FillRectangle(
                    new SolidBrush(Color.Transparent),
                    indicator_bounding_rectangle);
                for (int i = 0; (i < CirclesCount); i++)
                {
                    float angle;
                    Rectangle bounding_rectangle;
                    Brush brush = new SolidBrush(color);
                    Point top_left = new Point();
                    int x;
                    int y;

                    angle = (phi + (float)i * theta) +
                            indicator_angle;
                    polar_to_cartesian(R,
                                             angle,
                                         out x,
                                         out y);
                    top_left.X = (int)((float)x - r) +
                                 this.Width / 2;
                    top_left.Y = (int)((float)y - r) +
                                 this.Height / 2;

                    bounding_rectangle = new Rectangle(top_left,
                                                         size);
                    graphics.FillEllipse(brush,
                                           bounding_rectangle);

                    brush.Dispose();

                    color = lighter_color(color, 0.25F);
                }
            }
        }

        // *************************************** Pulse event handler

        /// <summary>
        /// Pulse is overloaded to allow it to be used as both an
        /// event handler (with parameters) and as a method (without
        /// parameters)
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void Pulse(object sender,
                            EventArgs e)
        {

            this.UpdateStyles();
            this.Invalidate();
        }

        // ********************************************** Pulse method

        /// <summary>
        /// Pulses this instance.
        /// </summary>
        public void Pulse()
        {

            this.UpdateStyles();
            this.Invalidate();
        }

        // *************************************************** Animate

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCircularIndeterminate" /> should Start/stop indicator animation.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        [Category("ZeroitCircularIndeterminate"),
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

        // ******************************************* BackgroundColor

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Background color of the control"),
         DefaultValue(typeof(SystemColors), "Control"),
         Bindable(true)]
        public Color BackgroundColor
        {

            get
            {
                return (background_color);
            }

            set
            {
                background_color = value;

                if (control_graphic != null)
                {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer();
                }

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                this.Invalidate();
            }
        }

        // ********************************************** CirclesCount

        /// <summary>
        /// Gets or sets the number of indicator circles.
        /// </summary>
        /// <value>The circles count.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Number of indicator circles"),
         DefaultValue(5),
         Bindable(true)]
        public int CirclesCount
        {
            get
            {
                return (circles_count);
            }
            set
            {
                circles_count = value;
                circles_count =
                    System.Math.Min(
                        System.Math.Max(circles_count,
                                   MINIMUM_CIRCLES_COUNT),
                        MAXIMUM_CIRCLES_COUNT);

                if (control_graphic != null)
                {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer();
                }
                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                update_indicator_geometry();

                this.Invalidate();
            }
        }

        // **************************************** ControlWidthHeight

        /// <summary>
        /// Gets or sets the Width and height of control.
        /// </summary>
        /// <value>The Width and height of control.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Width and height of control"),
         DefaultValue(30),
         Bindable(true)]
        public int ControlWidthHeight
        {

            get
            {
                return (control_width_height);
            }

            set
            {
                control_width_height = value;
                if ((control_width_height % 2) != 0)
                {
                    control_width_height++;
                }
                control_width_height =
                    System.Math.Min(
                        System.Math.Max(control_width_height,
                                   MINIMUM_CONTROL_WIDTH_HEIGHT),
                        MAXIMUM_CONTROL_WIDTH_HEIGHT);

                this.Width = control_width_height;
                this.Height = control_width_height;

                if (control_graphic != null)
                {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer();
                }
                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                update_indicator_geometry();

                this.Invalidate();
            }
        }

        // ******************************************** IndicatorColor

        /// <summary>
        /// Gets or sets the color of first rotating indicator.
        /// </summary>
        /// <value>The color of first rotating indicator.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Color of first rotating indicator"),
         DefaultValue(typeof(Color), "Black"),
         Bindable(true)]
        public Color IndicatorColor
        {

            get
            {
                return (indicator_color);
            }

            set
            {
                indicator_color = value;

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                this.Invalidate();
            }
        }

        // ***************************************** IndicatorDiameter

        /// <summary>
        /// Gets or sets the diameter of indicator circles.
        /// </summary>
        /// <value>The diameter of indicator circles.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Diameter of indicator circles"),
         DefaultValue(8),
         Bindable(true)]
        public int IndicatorDiameter
        {

            get
            {
                return (indicator_diameter);
            }

            set
            {
                indicator_diameter = value;
                indicator_diameter =
                    System.Math.Min(
                        System.Math.Max(indicator_diameter,
                                   MINIMUM_INDICATOR_DIAMETER),
                        (ControlWidthHeight / 2));

                if ((indicator_diameter % 2) != 0)
                {
                    indicator_diameter--;
                }

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                update_indicator_geometry();

                this.Invalidate();
            }
        }

        // ********************************************* IndicatorType

        /// <summary>
        /// Gets or sets the value which Specifies if control is animated or pulsed.
        /// </summary>
        /// <value>The type of the indicator.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Specifies if control is animated or pulsed"),
         DefaultValue(INDICATORTYPES.ANIMATED),
         Bindable(true)]
        public INDICATORTYPES IndicatorType
        {

            get
            {
                return (indicator_type);
            }

            set
            {
                indicator_type = value;

                this.Invalidate();
            }
        }

        // *********************************************** RefreshRate        
        /// <summary>
        /// Gets or sets the Interval between indicator movements.
        /// </summary>
        /// <value>The refresh rate.</value>
        [Category("ZeroitCircularIndeterminate"),
         Description("Interval between indicator movements"),
         DefaultValue(100),
         Bindable(true)]
        public int RefreshRate
        {

            get
            {
                return (refresh_rate);
            }

            set
            {
                bool timer_running = timer.Enabled;

                refresh_rate = value;
                refresh_rate = System.Math.Min(
                                   System.Math.Max(refresh_rate,
                                              MINIMUM_REFRESH_RATE),
                                   MAXIMUM_REFRESH_RATE);

                if (timer_running)
                {
                    timer.Stop();
                }
                timer.Interval = refresh_rate;
                if (timer_running)
                {
                    timer.Start();
                }
            }
        }

        // ****************************************** OnPaint override

        /// <summary>
        /// take over the event handling for the control's OnPaint
        /// event
        /// </summary>
        /// <param name="e">The PaintEventArgs class contains data for the Paint
        /// event; of particular interest here is e.Graphics that has
        /// methods to draw points, strings, lines, arcs, ellipses,
        /// and other shapes</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            if (control_graphic == null)
            {
                create_control_graphic();
            }
            control_graphic.RenderGraphicsBuffer(e.Graphics);

            create_indicator_graphic();
            indicator_graphic.RenderGraphicsBuffer(e.Graphics);
            // revise rotation angle and
            // avoid overflow
            indicator_angle += indicator_angular_advance;
            if (indicator_angle > (float)(2.0 * System.Math.PI))
            {
                indicator_angle -= (float)(2.0 * System.Math.PI);
            }
        }

    } // class ZeroitCircularIndeterminate

    // ****************************************** class GraphicsBuffer

    #region Designer Generated

    partial class ZeroitCircularIndeterminate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(564, 461);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Class IndeterminateProgressGraphicsBuffer.
    /// </summary>
    public class IndeterminateProgressGraphicsBuffer
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        private Bitmap bitmap;
        /// <summary>
        /// The graphics
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// The height
        /// </summary>
        private int height;
        /// <summary>
        /// The width
        /// </summary>
        private int width;

        // ******************************** GraphicsBuffer constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IndeterminateProgressGraphicsBuffer"/> class.
        /// </summary>
        public IndeterminateProgressGraphicsBuffer()
        {

            width = 0;
            height = 0;
        }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// Creates buffer object
        /// </summary>
        /// <param name="g">Window forms Graphics Object</param>
        /// <param name="width">Width of paint area</param>
        /// <param name="height">Height of paint area</param>
        /// <returns>true, if buffer created; otherwise, false</returns>
        public bool CreateGraphicsBuffer(Graphics g,
                                           int width,
                                           int height)
        {
            bool success = true;

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            if (graphics != null)
            {
                graphics.Dispose();
                graphics = null;
            }

            if ((width == 0) || (height == 0))
            {
                success = false;
            }
            else if ((width != this.width) ||
                      (height != this.height))
            {
                this.width = width;
                this.height = height;

                bitmap = new Bitmap(width, height);
                graphics = Graphics.FromImage(bitmap);

                success = true;
            }
            else
            {
                success = true;
            }

            return (success);
        }

        // ************************************** DeleteGraphicsBuffer

        /// <summary>
        /// Deletes the graphics buffer.
        /// </summary>
        /// <returns>IndeterminateProgressGraphicsBuffer.</returns>
        public IndeterminateProgressGraphicsBuffer DeleteGraphicsBuffer()
        {

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            if (graphics != null)
            {
                graphics.Dispose();
                graphics = null;
            }

            width = 0;
            height = 0;

            return (null);
        }

        // ************************************************** g getter

        /// <summary>
        /// Gets the g.
        /// </summary>
        /// <value>The g.</value>
        public Graphics g
        {

            get
            {
                return (graphics);
            }
        }

        // ************************************** GraphicsBufferExists

        /// <summary>
        /// Gets a value indicating whether [graphics buffer exists].
        /// </summary>
        /// <value><c>true</c> if [graphics buffer exists]; otherwise, <c>false</c>.</value>
        public bool GraphicsBufferExists
        {

            get
            {
                return (graphics != null);
            }
        }

        // ************************************** RenderGraphicsBuffer

        /// <summary>
        /// Renders the buffer to the graphics object identified by g
        /// </summary>
        /// <param name="g">Window forms graphics object</param>
        public void RenderGraphicsBuffer(Graphics g)
        {

            if (bitmap != null)
            {
                g.DrawImage(bitmap,
                              new Rectangle(0, 0, width, height),
                              0, 0,
                              width, height,
                              GraphicsUnit.Pixel);
            }
        }

    } // class GraphicsBuffer

    #endregion

}
