// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="GoogleProgress.cs" company="Zeroit Dev Technologies">
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
    #region Google ProgressIndicator

    #region Control
    // Notes
    //
    //  This project was created using the Microsoft Visual C# 2008 
    //  Express Edition.
    //
    //  This compilation unit contains two classes, in the following 
    //  order:
    //
    //      GoogleProgressIndicator
    //      GraphicsBuffer
    //
    //  The GoogleProgressIndicator class MUST precede the 
    //  GraphicsBuffer class (a requirement of the Visual Studio 
    //  Designer) if both classes are to appear in the same 
    //  compilation unit.  The two classes appear in the same 
    //  compilation unit so that a reference to an external class
    //  (i.e., GraphicsBuffer) is not required.
    // 

    // **************************************************************
    // ******************************** GoogleProgressIndicator class
    // **************************************************************

    /// <summary>
    /// A class collection for rendering google-like progress indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitGoogleProgressIndicatorDesigner))]
    public partial class ZeroitGoogleProgressIndicator : UserControl
    {
        #region E N U M S        
        /// <summary>
        /// Enum representing whether the indicator should be PULSED or ANIMATED.
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


        #endregion

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer inner circle
        /// </summary>
        private System.Windows.Forms.Timer timerInnerCircle = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatic animate inner circle.
        /// </summary>
        /// <value><c>true</c> if automatic animate inner circle; otherwise, <c>false</c>.</value>
        public bool AutoAnimateInnerCircle
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timerInnerCircle.Enabled = true;
                }

                else
                {
                    timerInnerCircle.Enabled = false;
                }
                UpdateStyles();
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
            if (this.angle + 1 > 360)
                this.angle = 0;
            else
            {
                this.angle++;
                this.UpdateStyles();
                this.Invalidate();

            }

        }

        #endregion


        #region Fields

        /// <summary>
        /// The annulus color
        /// </summary>
        private Color annulus_color = Color.PaleTurquoise;
        /// <summary>
        /// The annulus graphic
        /// </summary>
        private ZeroitGoogleProgressGraphicsBuffer annulus_graphic = null;
        /// <summary>
        /// The annulus thickness
        /// </summary>
        private int annulus_thickness;
        /// <summary>
        /// The background color
        /// </summary>
        private Color background_color;
        /// <summary>
        /// The indicator angle
        /// </summary>
        private int indicator_angle = 0;
        /// <summary>
        /// The indicator angular advance
        /// </summary>
        private int indicator_angular_advance = 10;
        /// <summary>
        /// The indicator color
        /// </summary>
        private Color indicator_color = Color.White;
        /// <summary>
        /// The indicator graphic
        /// </summary>
        private ZeroitGoogleProgressGraphicsBuffer indicator_graphic = null;
        /// <summary>
        /// The indicator type
        /// </summary>
        private INDICATORTYPES indicator_type =
                                    INDICATORTYPES.ANIMATED;
        /// <summary>
        /// The inner radius
        /// </summary>
        private int inner_radius = 8;
        /// <summary>
        /// The outer radius
        /// </summary>
        private int outer_radius = 12;
        /// <summary>
        /// The refresh rate
        /// </summary>
        private int refresh_rate = 100;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// The rotate color
        /// </summary>
        private System.Windows.Forms.Timer rotateColor;

        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90;

        /// <summary>
        /// The transition color
        /// </summary>
        private Color transition_color = Color.Gray;

        /// <summary>
        /// The color1bigcircle
        /// </summary>
        private Color color1bigcircle = Color.Red;
        /// <summary>
        /// The color2bigcircle
        /// </summary>
        private Color color2bigcircle = Color.Yellow;
        /// <summary>
        /// The color1indicator
        /// </summary>
        private Color color1indicator = Color.Gray;
        /// <summary>
        /// The color2indicator
        /// </summary>
        private Color color2indicator = Color.DarkBlue;
        /// <summary>
        /// The inner color
        /// </summary>
        private Color inner_color = Color.DarkBlue;
        /// <summary>
        /// The inner border
        /// </summary>
        private int inner_border = 1;

        #endregion

        #region Constructor
        // ********************** GoogleProgressIndicator constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGoogleProgressIndicator" /> class.
        /// </summary>
        public ZeroitGoogleProgressIndicator()
        {

            InitializeComponent();

            Application.ApplicationExit += new EventHandler(
                                                   memory_cleanup);

            //annulus_color = Color.PaleTurquoise;
            //annulus_graphic = null;
            //background_color = BackColor;
            //indicator_angle = 0;
            //indicator_angular_advance = 10;
            //indicator_color = Color.White;
            //indicator_graphic = null;
            //indicator_type = INDICATORTYPES.ANIMATED;
            //inner_radius = 8;
            //outer_radius = 12;
            ////refresh_rate = 150;
            //transition_color = Color.Gray;
            // order important here!!
            annulus_thickness = outer_radius - inner_radius;

            this.SetStyle(ControlStyles.DoubleBuffer |
                                ControlStyles.UserPaint |
                                ControlStyles.AllPaintingInWmPaint |
                                ControlStyles.ResizeRedraw |
                                ControlStyles.SupportsTransparentBackColor,
                            true);
            this.UpdateStyles();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = refresh_rate;
            timer.Tick += new EventHandler(Pulse);
            timer.Start();
            timer.Enabled = true;

            rotateColor = new System.Windows.Forms.Timer();
            rotateColor.Interval = refresh_rate;
            rotateColor.Tick += RotateColor_Tick;
            rotateColor.Start();
            rotateColor.Enabled = true;


            #region MyRegion
            if (DesignMode)
            {
                timerInnerCircle.Tick += Timer_Tick;
                if (AutoAnimateInnerCircle)
                {
                    timerInnerCircle.Interval = 100;
                    timerInnerCircle.Start();
                }
            }

            if (!DesignMode)
            {
                timerInnerCircle.Tick += Timer_Tick;

                if (AutoAnimateInnerCircle)
                {
                    timerInnerCircle.Interval = 100;
                    timerInnerCircle.Start();
                }
            }



            #endregion

            if (DesignMode)
            {
                MessageBox.Show("Please make sure you resize the control on implementation. " +
                "Use the smart tag to set the Inner and Outer Radius to aid in resizing. Thank you. Happy Coding.");
            }



        }

        /// <summary>
        /// Handles the Tick event of the RotateColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RotateColor_Tick(object sender, EventArgs e)
        {
            #region Unused Code
            //throw new NotImplementedException();

            //for(float x = 0; x <=360; x++)
            //{
            //    angle = x;

            //    if(angle == 360)
            //    {
            //        angle = 0;

            //    }
            //} 
            #endregion

            if (DesignMode)
            {

                angle += 1;

                if (angle > 360)
                {
                    rotateColor.Stop();
                    angle = 0;
                    rotateColor.Start();

                    this.UpdateStyles();
                    this.Invalidate();
                }
                this.UpdateStyles();
                this.Invalidate();
            }

            if (!DesignMode)
            {

                angle += 1;

                if (angle > 360)
                {
                    rotateColor.Stop();
                    angle = 0;
                    rotateColor.Start();

                    this.UpdateStyles();
                    this.Invalidate();
                }

                this.UpdateStyles();
                this.Invalidate();

            }

        }

        #endregion

        #region Memory Cleanup Event Handler
        // ***************************** memory_cleanup event handler

        /// <summary>
        /// Handles the cleanup event of the memory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void memory_cleanup(object sender, EventArgs e)
        {

            if (annulus_graphic != null)
            {
                annulus_graphic =
                    annulus_graphic.DeleteGraphicsBuffer();
            }

            if (indicator_graphic != null)
            {
                indicator_graphic =
                    indicator_graphic.DeleteGraphicsBuffer();
            }
        }

        // Pulse is overloaded to allow it to be used as both an 
        // event handler (with parameters) and as a method (without
        // parameters).


        // ************************************** Pulse event handler 
        /// <summary>
        /// Pulses the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void Pulse(object sender, EventArgs e)
        {

            this.UpdateStyles();
            this.Invalidate();
        }
        #endregion

        #region Public Properties

        // ********************************************* Pulse method

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public int InnerBorder
        {
            get { return inner_border; }
            set
            {
                inner_border = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the inner border.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public Color ColorInnerBorder
        {
            get { return inner_color; }
            set
            {
                inner_color = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the bigcircle.
        /// </summary>
        /// <value>The color1 of the bigcircle.</value>
        public Color Color1Bigcircle
        {
            get { return color1bigcircle; }
            set
            {
                color1bigcircle = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the bigcircle.
        /// </summary>
        /// <value>The color2 of the bigcircle.</value>
        public Color Color2Bigcircle
        {
            get { return color2bigcircle; }
            set
            {
                color2bigcircle = value;


                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the indicator color.
        /// </summary>
        /// <value>The indicator color1.</value>
        public Color Color1Indicator
        {
            get { return color1indicator; }
            set
            {
                color1indicator = value;


                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the indicator color.
        /// </summary>
        /// <value>The indicator color2.</value>
        public Color Color2Indicator
        {
            get { return color2indicator; }
            set
            {
                color2indicator = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color angle.
        /// </summary>
        /// <value>The color angle.</value>
        public float ColorAngle
        {
            get { return angle; }
            set
            {
                angle = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();


            }
        }

        /// <summary>
        /// Pulses this instance.
        /// </summary>
        public void Pulse()
        {

            this.UpdateStyles();
            this.Invalidate();
        }

        // ***************************************** Animate property

        /// <summary>
        /// Gets or sets a value to either Start or Stop the indicator animation.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        [Category("GoogleProgressIndicator"),
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

        // ************************************ AnnulusColor property

        /// <summary>
        /// Gets or sets the base color of the annulus.
        /// </summary>
        /// <value>The color of the annulus.</value>
        [Category("GoogleProgressIndicator"),
         Description("Base color of the annulus"),
         DefaultValue(typeof(Color), "PaleTurquoise"),
         Bindable(true)]
        public Color AnnulusColor
        {
            get
            {
                return (annulus_color);
            }

            set
            {
                annulus_color = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // ********************************* BackgroundColor property

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        [Category("GoogleProgressIndicator"),
         Description("Background color of the control"),
         //DefaultValue(typeof(SystemColors), "Control"),
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

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }


        // ********************************** IndicatorAngularAdvance

        /// <summary>
        /// Gets or sets the Degrees the indicator moves on each tick/pulse.
        /// </summary>
        /// <value>The indicator angular advance.</value>
        [Category("GoogleProgressIndicator"),
         Description("Degrees indicator moves on each tick/pulse"),
         DefaultValue(10),
         Bindable(true)]
        public int IndicatorAngularAdvance
        {

            get
            {
                return (indicator_angular_advance);
            }

            set
            {
                indicator_angular_advance = value;

                if (indicator_angular_advance >= 360)
                {
                    indicator_angular_advance = 359;
                }

                if (indicator_angular_advance <= 0)
                {
                    indicator_angular_advance = 1;
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // ********************************** IndicatorColor property

        /// <summary>
        /// Gets or sets the color of the rotating indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        [Category("GoogleProgressIndicator"),
         Description("Color of rotating indicator"),
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
                indicator_color = value;

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // ******************************************** IndicatorType

        /// <summary>
        /// Specifies if control is animated or pulsed.
        /// </summary>
        /// <value>The type of the indicator.</value>
        [Category("GoogleProgressIndicator"),
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

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // ************************************* InnerRadius property

        /// <summary>
        /// Gets or sets radius of annulus inner circle.
        /// </summary>
        /// <value>The inner radius.</value>
        [Category("GoogleProgressIndicator"),
         Description("Radius of annulus inner circle"),
         //DefaultValue(8),
         Bindable(true)]
        public int InnerRadius
        {

            get
            {
                return (inner_radius);
            }

            set
            {
                if (!DesignMode)
                {
                    inner_radius = value;


                    //if (inner_radius >= outer_radius)
                    //{
                    //    inner_radius = outer_radius - 2;
                    //}

                    //if ((inner_radius % 2) != 0)
                    //{
                    //    inner_radius--;
                    //}

                    annulus_thickness = outer_radius - inner_radius;

                    if (annulus_graphic != null)
                    {
                        annulus_graphic =
                            annulus_graphic.DeleteGraphicsBuffer();
                    }

                    if (indicator_graphic != null)
                    {
                        indicator_graphic =
                            indicator_graphic.DeleteGraphicsBuffer();
                    }

                    this.UpdateStyles();
                    this.Invalidate();
                }

                if (DesignMode)
                {

                    inner_radius = value;

                    //if (inner_radius >= outer_radius)
                    //{
                    //    inner_radius = outer_radius - 2;
                    //}

                    //if ((inner_radius % 2) != 0)
                    //{
                    //    inner_radius--;
                    //}

                    annulus_thickness = outer_radius - inner_radius;

                    if (annulus_graphic != null)
                    {
                        annulus_graphic =
                            annulus_graphic.DeleteGraphicsBuffer();
                    }

                    if (indicator_graphic != null)
                    {
                        indicator_graphic =
                            indicator_graphic.DeleteGraphicsBuffer();
                    }



                    this.UpdateStyles();
                    this.Invalidate();
                }

            }
        }

        // ************************************* OuterRadius property

        /// <summary>
        /// Gets or sets the outer radius of the annulus.
        /// </summary>
        /// <value>The outer radius.</value>
        [Category("GoogleProgressIndicator"),
         Description("Radius of annulus outer circle"),
         //DefaultValue(30),
         Bindable(true)]
        public int OuterRadius
        {

            get
            {
                return (outer_radius);
            }

            set
            {
                outer_radius = value;
                if ((outer_radius % 2) != 0)
                {
                    outer_radius--;
                }

                this.Width = 2 * outer_radius;
                this.Height = this.Width;

                annulus_thickness = outer_radius - inner_radius;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // ************************************* RefreshRate property

        /// <summary>
        /// Gets or sets the specified timer tick interval.
        /// </summary>
        /// <value>The refresh rate.</value>
        [Category("GoogleProgressIndicator"),
         Description("Specified timer tick interval"),
         //DefaultValue(150),
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

                if (refresh_rate < 10)
                {
                    refresh_rate = 10;
                }

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

        // ********************************* TransitionColor property

        /// <summary>
        /// Gets or sets the Transition color at annulus' mid-position.
        /// </summary>
        /// <value>The transition color.</value>
        [Category("GoogleProgressIndicator"),
         Description("Transition color at annulus mid-position"),
         DefaultValue(typeof(Color), "Gray"),
         Bindable(true)]
        public Color TransitionColor
        {

            get
            {
                return (transition_color);
            }

            set
            {
                transition_color = value;

                if (annulus_graphic != null)
                {
                    annulus_graphic =
                        annulus_graphic.DeleteGraphicsBuffer();
                }

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        // *********************************** create_annulus_graphic 
        #endregion

        #region Paint Arguments and Methods

        /// <summary>
        /// Creates the annulus graphic.
        /// </summary>
        private void create_annulus_graphic()
        {
            #region Fields
            LinearGradientBrush brush;
            Rectangle control_bounding_rectangle = new Rectangle();
            GraphicsPath inner_path;
            Rectangle inner_rectangle;
            int inner_rectangle_side;
            Region inner_region;
            Region outer_region;
            GraphicsPath outer_path;

            int outer_rectangle_side = 2 * outer_radius;

            #region Unused Code


            Bitmap bit = new Bitmap(5, 5);
            PaintEventArgs e = new PaintEventArgs(Graphics.FromImage(bit), control_bounding_rectangle);

            control_bounding_rectangle = new Rectangle(0, 0, Width - 3, Height - 3);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(new SolidBrush(Color.Green), control_bounding_rectangle);
            e.Graphics.DrawEllipse(new Pen(Color.Yellow, 2), control_bounding_rectangle);

            //// compute outer geometry
            outer_path = new GraphicsPath();

            //outer_path.AddEllipse(control_bounding_rectangle);

            outer_region = new Region(outer_path);
            // compute inner geometry
            inner_rectangle_side = 2 * inner_radius;
            inner_rectangle = new Rectangle(
                                      annulus_thickness,
                                      annulus_thickness,
                                      (2 * inner_radius) - 2,
                                      (2 * inner_radius) - 2);

            inner_path = new GraphicsPath();
            //inner_path.AddEllipse(inner_rectangle);


            e.Graphics.FillEllipse(
                new SolidBrush(BackColor),
                inner_rectangle);

            e.Graphics.DrawEllipse(
                new Pen(Color.Black, 1),
                inner_rectangle);

            inner_region = new Region(inner_path);

            //// exclude inner from outer
            //outer_region.Exclude(inner_region);

            //// paint the outer
            //brush = create_linear_gradient_brush(
            //            new Point(outer_radius, 0),
            //            new Point(outer_radius,
            //                        outer_rectangle_side),
            //            annulus_color,
            //            transition_color);
            //e.Graphics.FillRegion(brush, outer_region);

            //// clean up
            //brush.Dispose();
            //outer_region.Dispose();
            //outer_path.Dispose();
            //inner_region.Dispose();
            //inner_path.Dispose();
            #endregion

            #endregion

            annulus_graphic = new ZeroitGoogleProgressGraphicsBuffer();
            if (annulus_graphic.CreateGraphicsBuffer(
                            this.CreateGraphics(),
                            this.Width,
                            this.Height))
            {
                annulus_graphic.g.SmoothingMode = SmoothingMode.HighQuality;

                //control_bounding_rectangle = this.ClientRectangle;
                control_bounding_rectangle = new Rectangle(0, 0, Width - 2, Height - 2);

                //control_bounding_rectangle.Inflate(1, 1);
                annulus_graphic.g.FillRectangle(
                    new SolidBrush(BackColor),
                    control_bounding_rectangle);

                LinearGradientBrush linbrush = new LinearGradientBrush(control_bounding_rectangle, color1bigcircle, color2bigcircle, angle);
                annulus_graphic.g.FillEllipse(
                    /*new SolidBrush(Color.Red)*/ linbrush,
                    control_bounding_rectangle);

                annulus_graphic.g.DrawEllipse(
                    new Pen(Color.Transparent, 1),
                    control_bounding_rectangle);

                //control_bounding_rectangle.Inflate(-10, -10);


                //// compute outer geometry
                outer_path = new GraphicsPath();

                //outer_path.AddEllipse(control_bounding_rectangle);

                outer_region = new Region(outer_path);
                // compute inner geometry
                inner_rectangle_side = 2 * inner_radius;
                inner_rectangle = new Rectangle(
                                          annulus_thickness,
                                          annulus_thickness,
                                          (2 * inner_radius) - 2,
                                          (2 * inner_radius) - 2);

                inner_path = new GraphicsPath();
                //inner_path.AddEllipse(inner_rectangle);


                annulus_graphic.g.FillEllipse(
                    new SolidBrush(BackColor),
                    inner_rectangle);

                annulus_graphic.g.DrawEllipse(
                    new Pen(inner_color, inner_border),
                    inner_rectangle);

                inner_region = new Region(inner_path);

                // exclude inner from outer
                outer_region.Exclude(inner_region);

                // paint the outer
                brush = create_linear_gradient_brush(
                            new Point(outer_radius, 0),
                            new Point(outer_radius,
                                        outer_rectangle_side),
                            annulus_color,
                            transition_color);
                annulus_graphic.g.FillRegion(brush, outer_region);

                // clean up
                brush.Dispose();
                outer_region.Dispose();
                outer_path.Dispose();
                inner_region.Dispose();
                inner_path.Dispose();
            }
        }

        // ********************************* create_indicator_graphic

        // annulus_graphic MUST HAVE BEEN created before this method
        // is invoked

        /// <summary>
        /// Creates the indicator graphic.
        /// </summary>
        private void create_indicator_graphic()
        {
            SolidBrush brush;
            Rectangle control_bounding_rectangle;
            GraphicsPath indicator_path = new GraphicsPath();
            Rectangle indicator_rectangle = new Rectangle();

            Region indicator_region;

            //Rectangle indicator_rectangle1 = new Rectangle((Width/2) , (Height / 2), 5,5);

            //Rectangle indicator_rectangle1 = new Rectangle(outer_radius - annulus_thickness, -(annulus_thickness / 2), 10, 10);




            if (indicator_graphic != null)
            {
                indicator_graphic = indicator_graphic.DeleteGraphicsBuffer();
            }

            indicator_graphic = new ZeroitGoogleProgressGraphicsBuffer();

            if (indicator_graphic.CreateGraphicsBuffer(this.CreateGraphics(), 2 * OuterRadius, 2 * OuterRadius))
            {
                indicator_graphic.g.SmoothingMode = SmoothingMode.HighQuality;
                control_bounding_rectangle = this.ClientRectangle;

                indicator_graphic.g.FillRectangle(new SolidBrush(Color.Transparent), control_bounding_rectangle);


                // compute region geometry
                indicator_rectangle = new Rectangle(
                    new Point(outer_radius - annulus_thickness,
                                -(annulus_thickness / 2)),
                    new Size(annulus_thickness - 1, annulus_thickness - 1));

                //indicator_rectangle = new Rectangle(new Point(this.ClientRectangle.Width - outer_radius, this.ClientRectangle.Height - outer_radius), new Size(annulus_thickness, annulus_thickness));

                #region Unused Code
                //indicator_path.AddEllipse(indicator_rectangle);
                //indicator_graphic.g.DrawPath(new Pen(Color.White), indicator_path);
                //indicator_graphic.g.FillPath(new SolidBrush(Color.White),indicator_path);

                #endregion

                indicator_path.AddEllipse(indicator_rectangle);

                #region Unique Rectangle
                //indicator_graphic.g.FillEllipse(new SolidBrush(Color.Yellow),
                //    indicator_rectangle1);

                //indicator_graphic.g.DrawEllipse(new Pen(Color.Yellow),
                //    indicator_rectangle1);

                #endregion

                indicator_region = new Region(indicator_path);
                //indicator_region = new Region(indicator_rectangle1);

                // rotate the indicator
                indicator_graphic.g.ResetTransform();
                indicator_graphic.g.RotateTransform(
                                        (float)indicator_angle,
                                        MatrixOrder.Append);

                indicator_graphic.g.TranslateTransform(
                                    (float)outer_radius,
                                    (float)outer_radius,
                                    MatrixOrder.Append);

                LinearGradientBrush linbrushregion = new LinearGradientBrush(indicator_rectangle, color1indicator, color2indicator, angle);
                brush = new SolidBrush(indicator_color);
                //indicator_graphic.g.FillRegion(brush, indicator_region);
                indicator_graphic.g.FillRegion(linbrushregion, indicator_region);

                brush.Dispose();
                indicator_region.Dispose();
                indicator_path.Dispose();
            }
        }

        // ***************************** create_linear_gradient_brush

        /// <summary>
        /// Creates the linear gradient brush.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="annulus_color">Color of the annulus.</param>
        /// <param name="transition_color">Color of the transition.</param>
        /// <returns>LinearGradientBrush.</returns>
        private LinearGradientBrush create_linear_gradient_brush(Point start, Point end, Color annulus_color, Color transition_color)
        {
            Blend blend = new Blend();
            LinearGradientBrush brush;
            float[] factors = { 0.0F, 0.25F, 0.75F, 0.25F, 0.0F };

            float[] positions = { 0.0F, 0.25F, 0.5F, 0.75F, 1.0F };

            blend.Factors = factors;
            blend.Positions = positions;
            brush = new LinearGradientBrush(start, end, annulus_color, transition_color);

            brush.Blend = blend;

            return (brush);
        }

        // ****************************************** OnMove override

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Move" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMove(EventArgs e)
        {

        }

        // ***************************************** OnPaint override

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // create annulus graphic 
            // only if it does not exist
            // (it will not exist if some
            // graphics oriented property
            // is changed)

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            e.Graphics.Clear(BackColor);

            if (annulus_graphic == null)
            {
                create_annulus_graphic();
            }
            // always create indicator 
            // graphic
            create_indicator_graphic();

            // render to screen
            annulus_graphic.RenderGraphicsBuffer(e.Graphics);
            indicator_graphic.RenderGraphicsBuffer(e.Graphics);


            // revise rotation angle
            indicator_angle = (indicator_angle +
                                indicator_angular_advance) % 360;

            e.Dispose();
        }

        // ******************************* OnPaintBackground override

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(
                                    PaintEventArgs e)
        {

        }

        // **************************************** OnResize override

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {

        }
        #endregion

    } // class GoogleProgressIndicator

    // **************************************************************
    // ***************************************** GraphicsBuffer class
    // **************************************************************

    // Notes
    //
    //  The GraphicsBuffer class was derived from 
    //  http://www.codeproject.com/KB/GDI-plus/flickerFreeDrawing.aspx
    //
    //  Because the placement of GoogleProgressIndicator in the final 
    //  file structure is unknown, the GraphicsBuffer class has been 
    //  included in this compilation unit.  Thus, the control can 
    //  stand alone without requiring a reference to GraphicsBuffer.
    //
    //  GraphicsBuffer Ordering:
    //      
    //  1.  GraphicsBuffer private types
    //  2.  GraphicsBuffer constructor
    //  3.  Public methods
    //

    // **************************************************************
    // ******************************** GoogleProgressIndicator class
    // **************************************************************

    #region Custom Graphics Class
    /// <summary>
    /// Class ZeroitGoogleProgressGraphicsBuffer.
    /// </summary>
    public class ZeroitGoogleProgressGraphicsBuffer
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

        // ******************************* GraphicsBuffer constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGoogleProgressGraphicsBuffer"/> class.
        /// </summary>
        public ZeroitGoogleProgressGraphicsBuffer()
        {

            width = 0;
            height = 0;
        }

        // ************************************* CreateGraphicsBuffer

        /// <summary>
        /// Creates buffer object
        /// </summary>
        /// <param name="g">Window forms Graphics Object</param>
        /// <param name="width">Width of paint area</param>
        /// <param name="height">Height of paint area</param>
        /// <returns>true, if buffer created; otherwise, false</returns>
        public bool CreateGraphicsBuffer(Graphics g, int width, int height)
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

        // ************************************* DeleteGraphicsBuffer

        /// <summary>
        /// Deletes the graphics buffer.
        /// </summary>
        /// <returns>ZeroitGoogleProgressGraphicsBuffer.</returns>
        public ZeroitGoogleProgressGraphicsBuffer DeleteGraphicsBuffer()
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

        // ************************************************* g getter

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

        // ************************************* GraphicsBufferExists

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

        // ************************************* RenderGraphicsBuffer

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

    }
    #endregion// class GraphicsBuffer 
    #endregion

    #region Designer Generated Code

    partial class ZeroitGoogleProgressIndicator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroitGoogleProgressIndicator));
            this.SuspendLayout();
            // 
            // GoogleProgressIndicator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            //this.BackColor = Parent.BackColor;
            //this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(8, 8);
            this.Name = "GoogleProgressIndicator";
            this.Size = new System.Drawing.Size(24, 24);
            this.ResumeLayout(false);

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
    /// Class ZeroitGoogleProgressIndicatorDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGoogleProgressIndicatorDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGoogleProgressIndicatorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGoogleProgressIndicatorSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGoogleProgressIndicatorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGoogleProgressIndicator colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGoogleProgressIndicatorSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGoogleProgressIndicatorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGoogleProgressIndicator;

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
        /// Gets or sets the color1 bigcircle.
        /// </summary>
        /// <value>The color1 bigcircle.</value>
        public Color Color1Bigcircle
        {
            get
            {
                return colUserControl.Color1Bigcircle;
            }
            set
            {
                GetPropertyByName("Color1Bigcircle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2 bigcircle.
        /// </summary>
        /// <value>The color2 bigcircle.</value>
        public Color Color2Bigcircle
        {
            get
            {
                return colUserControl.Color2Bigcircle;
            }
            set
            {
                GetPropertyByName("Color2Bigcircle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color1 indicator.
        /// </summary>
        /// <value>The color1 indicator.</value>
        public Color Color1Indicator
        {
            get
            {
                return colUserControl.Color1Indicator;
            }
            set
            {
                GetPropertyByName("Color1Indicator").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2 indicator.
        /// </summary>
        /// <value>The color2 indicator.</value>
        public Color Color2Indicator
        {
            get
            {
                return colUserControl.Color2Indicator;
            }
            set
            {
                GetPropertyByName("Color2Indicator").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle.
        /// </summary>
        /// <value>The color angle.</value>
        public float ColorAngle
        {
            get
            {
                return colUserControl.ColorAngle;
            }
            set
            {
                GetPropertyByName("ColorAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the annulus.
        /// </summary>
        /// <value>The color of the annulus.</value>
        public Color AnnulusColor
        {
            get
            {
                return colUserControl.AnnulusColor;
            }
            set
            {
                GetPropertyByName("AnnulusColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {

            get
            {
                return colUserControl.BackgroundColor;
            }
            set
            {
                GetPropertyByName("BackgroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the indicator angular advance.
        /// </summary>
        /// <value>The indicator angular advance.</value>
        public int IndicatorAngularAdvance
        {

            get
            {
                return colUserControl.IndicatorAngularAdvance;
            }
            set
            {
                GetPropertyByName("IndicatorAngularAdvance").SetValue(colUserControl, value);
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
        /// Gets or sets the type of the indicator.
        /// </summary>
        /// <value>The type of the indicator.</value>
        public Zeroit.Framework.Progress.ZeroitGoogleProgressIndicator.INDICATORTYPES IndicatorType
        {

            get
            {
                return colUserControl.IndicatorType;
            }
            set
            {
                GetPropertyByName("IndicatorType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner radius.
        /// </summary>
        /// <value>The inner radius.</value>
        public int InnerRadius
        {

            get
            {
                return colUserControl.InnerRadius;
            }
            set
            {
                GetPropertyByName("InnerRadius").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the outer radius.
        /// </summary>
        /// <value>The outer radius.</value>
        public int OuterRadius
        {

            get
            {
                return colUserControl.OuterRadius;
            }
            set
            {
                GetPropertyByName("OuterRadius").SetValue(colUserControl, value);
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

        /// <summary>
        /// Gets or sets the color of the transition.
        /// </summary>
        /// <value>The color of the transition.</value>
        public Color TransitionColor
        {

            get
            {
                return colUserControl.TransitionColor;
            }
            set
            {
                GetPropertyByName("TransitionColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGoogleProgressIndicatorSmartTagActionList"/> is animate.
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
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public int InnerBorder
        {
            get
            {
                return colUserControl.InnerBorder;
            }
            set
            {
                GetPropertyByName("InnerBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color inner border.
        /// </summary>
        /// <value>The color inner border.</value>
        public Color ColorInnerBorder
        {
            get
            {
                return colUserControl.ColorInnerBorder;
            }
            set
            {
                GetPropertyByName("ColorInnerBorder").SetValue(colUserControl, value);
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ColorInnerBorder",
                                 "Color Inner Border", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Color1Bigcircle",
                                 "Color1 Bigcircle", "Appearance",
                                 "Sets background color of the outer circle."));

            items.Add(new DesignerActionPropertyItem("Color2Bigcircle",
                                 "Color2 Bigcircle", "Appearance",
                                 "Sets background color of the outer circle."));

            items.Add(new DesignerActionPropertyItem("Color1Indicator",
                                 "Color1 Indicator", "Appearance",
                                 "Sets background color of the indicator circle."));

            items.Add(new DesignerActionPropertyItem("Color2Indicator",
                                 "Color2 Indicator", "Appearance",
                                 "Sets background color of the indicator circle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle",
                                 "Color Angle", "Appearance",
                                 "Sets angle of the background colors of the outer and inner circle."));

            items.Add(new DesignerActionPropertyItem("IndicatorAngularAdvance",
                                 "Indicator Angular Advance", "Appearance",
                                 "Sets the speed."));

            //items.Add(new DesignerActionPropertyItem("IndicatorColor",
            //                     "Indicator Color", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("IndicatorType",
            //                     "Indicator Type", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("InnerRadius",
                                 "Inner Radius", "Appearance",
                                 "Sets the inner radius of the circle."));

            items.Add(new DesignerActionPropertyItem("OuterRadius",
                                 "Outer Radius", "Appearance",
                                 "Sets the size of the circle."));

            items.Add(new DesignerActionPropertyItem("RefreshRate",
                                 "Refresh Rate", "Appearance",
                                 "Sets the speed of the control."));

            items.Add(new DesignerActionPropertyItem("TransitionColor",
                                 "Transition Color", "Appearance",
                                 "Deepens the color of the outer circle."));

            items.Add(new DesignerActionPropertyItem("InnerBorder",
                                 "Inner Border", "Appearance",
                                 "Sets the inner border width."));


            items.Add(new DesignerActionPropertyItem("Animate",
                                 "Animate", "Appearance",
                                 "Enable the control to be animated."));


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
