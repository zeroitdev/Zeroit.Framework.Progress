// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="SeekBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Progress.Sliders
{
    #region SeekBar

    #region leftLimiterValueChangedEventArgs
    /// <summary>
    /// Class leftLimiterValueChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class leftLimiterValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private string value;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        private string Value
        {
            get { return value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="leftLimiterValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public leftLimiterValueChangedEventArgs(string newValue)
        {
            value = newValue;
        }
    }
    #endregion

    #region leftLimiterValueChangedEventHandler
    /// <summary>
    /// Delegate leftLimiterValueChangedEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="leftLimiterValueChangedEventArgs"/> instance containing the event data.</param>
    public delegate void leftLimiterValueChangedEventHandler(object sender, leftLimiterValueChangedEventArgs e);
    #endregion

    #region rightLimiterValueChangedEventArgs
    /// <summary>
    /// Class rightLimiterValueChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class rightLimiterValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private string value;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        private string Value
        {
            get { return value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="rightLimiterValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public rightLimiterValueChangedEventArgs(string newValue)
        {
            value = newValue;
        }
    }
    #endregion

    #region rightLimiterValueChangedEventHandler
    /// <summary>
    /// Delegate rightLimiterValueChangedEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="rightLimiterValueChangedEventArgs"/> instance containing the event data.</param>
    public delegate void rightLimiterValueChangedEventHandler(object sender, rightLimiterValueChangedEventArgs e);
    #endregion

    #region ValueChangedEventArgs
    /// <summary>
    /// Class ValueChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private float value;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get { return value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public ValueChangedEventArgs(float newValue)
        {
            value = newValue;
        }
    }
    #endregion

    #region ValueChangedEventHandler
    /// <summary>
    /// Delegate ValueChangedEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ValueChangedEventArgs"/> instance containing the event data.</param>
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);
    #endregion

    #region SeekBar

    #region Control

    /// <summary>
    /// A class collection that represents a Seek bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitSeekBarDesigner))]
    public partial class ZeroitSeekBar : Control
    {

        #region Variables and public events

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event ValueChangedEventHandler ValueChanged;
        /// <summary>
        /// Occurs when [left limiter value changed].
        /// </summary>
        [Description("Event fires when the Value changes")]
        [Category("Action")]
        public event leftLimiterValueChangedEventHandler leftLimiterValueChanged;
        /// <summary>
        /// Occurs when [right limiter value changed].
        /// </summary>
        [Description("Event fires when the Value changes")]
        [Category("Action")]
        public event rightLimiterValueChangedEventHandler rightLimiterValueChanged;


        /// <summary>
        /// The main bar
        /// </summary>
        private System.Drawing.Rectangle mainBar;
        /// <summary>
        /// The fill bar
        /// </summary>
        private System.Drawing.Rectangle fillBar;
        /// <summary>
        /// The fill bar two
        /// </summary>
        private System.Drawing.Rectangle fillBarTwo;
        /// <summary>
        /// The background bar
        /// </summary>
        private System.Drawing.Rectangle backgroundBar;
        /// <summary>
        /// The top limiter
        /// </summary>
        private System.Drawing.Rectangle topLimiter;
        /// <summary>
        /// The limiter slider
        /// </summary>
        private System.Drawing.Rectangle limiterSlider;
        /// <summary>
        /// The left limiter
        /// </summary>
        private System.Drawing.Rectangle leftLimiter;
        /// <summary>
        /// The right limiter
        /// </summary>
        private System.Drawing.Rectangle rightLimiter;

        /// <summary>
        /// The seek width
        /// </summary>
        private const int SEEK_WIDTH = 7;
        /// <summary>
        /// The seek height
        /// </summary>
        private const int SEEK_HEIGHT = 10;
        /// <summary>
        /// The xlocation
        /// </summary>
        private int Xlocation = 0;
        /// <summary>
        /// The previous mouse location
        /// </summary>
        private int previousMouseLocation = 0;
        /// <summary>
        /// The percent
        /// </summary>
        private double percent = 0;
        /// <summary>
        /// The previous value
        /// </summary>
        private double prevVal = 0;
        /// <summary>
        /// The left percent
        /// </summary>
        private double leftPercent = 0;
        /// <summary>
        /// The previous left value
        /// </summary>
        private double prevLeftVal = 0;
        /// <summary>
        /// The right percent
        /// </summary>
        private double rightPercent = 0;
        /// <summary>
        /// The previous right value
        /// </summary>
        private double prevRightVal = 0;

        /// <summary>
        /// The maximum value
        /// </summary>
        private int maxValue = 100;
        /// <summary>
        /// The minimum value
        /// </summary>
        private int minValue = 0;
        /// <summary>
        /// The seek value
        /// </summary>
        private int seekValue = 0;
        /// <summary>
        /// The left seek value
        /// </summary>
        private int leftSeekValue = 0;
        /// <summary>
        /// The right seek value
        /// </summary>
        private int rightSeekValue = 0;
        /// <summary>
        /// The one move
        /// </summary>
        private double oneMove = 0;

        /// <summary>
        /// The m left button down
        /// </summary>
        bool m_leftButtonDown = false;
        /// <summary>
        /// The m left button down and moving
        /// </summary>
        bool m_leftButtonDownAndMoving = false;
        /// <summary>
        /// The m left limiter clicked
        /// </summary>
        bool m_leftLimiterClicked = false;
        /// <summary>
        /// The m right limiter clicked
        /// </summary>
        bool m_rightLimiterClicked = false;

        //Colors
        /// <summary>
        /// The c main outline
        /// </summary>
        System.Drawing.Color c_mainOutline;
        /// <summary>
        /// The c fill bar one
        /// </summary>
        System.Drawing.Color c_fillBarOne;
        /// <summary>
        /// The c fill bar two
        /// </summary>
        System.Drawing.Color c_fillBarTwo;
        /// <summary>
        /// The c background fill
        /// </summary>
        System.Drawing.Color c_backgroundFill;
        /// <summary>
        /// The c seeker outline
        /// </summary>
        System.Drawing.Color c_seekerOutline;
        /// <summary>
        /// The c seeker color one
        /// </summary>
        System.Drawing.Color c_seekerColorOne;
        /// <summary>
        /// The c seeker color two
        /// </summary>
        System.Drawing.Color c_seekerColorTwo;
        /// <summary>
        /// The c top limiter background
        /// </summary>
        System.Drawing.Color c_topLimiterBackground;
        /// <summary>
        /// The c top limiter foreground
        /// </summary>
        System.Drawing.Color c_topLimiterForeground;

        /// <summary>
        /// The main control width
        /// </summary>
        private int mainControlWidth;
        /// <summary>
        /// The main control height
        /// </summary>
        private int mainControlHeight;

        /// <summary>
        /// The left limiter location
        /// </summary>
        private int leftLimiterLocation = 0;
        /// <summary>
        /// The right limiter location
        /// </summary>
        private int rightLimiterLocation = 0;

        /// <summary>
        /// The left value set
        /// </summary>
        private bool leftValueSet = false;
        /// <summary>
        /// The draw left information text
        /// </summary>
        private bool drawLeftInfoText = false;
        /// <summary>
        /// The draw right information text
        /// </summary>
        private bool drawRightInfoText = false;

        /// <summary>
        /// The right limiter text
        /// </summary>
        private string rightLimiterText = "t";
        /// <summary>
        /// The left limiter text
        /// </summary>
        private string leftLimiterText = "t";

        /// <summary>
        /// The bw
        /// </summary>
        BackgroundWorker bw;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSeekBar" /> class.
        /// </summary>
        public ZeroitSeekBar()
        {
            InitializeComponent();

            mainControlHeight = this.Height;
            mainControlWidth = this.Width;

            this.Resize += new EventHandler(SeekBar_Resize);
            this.SizeChanged += new EventHandler(SeekBar_SizeChanged);
            this.MaximumSize = new Size(10000, 40);
            this.DoubleBuffered = true;
            setInitialColor();
            Xlocation = 0;
            setRectangleSize();

            this.ValueChanged += ZeroitSeekBar_ValueChanged;
            //this.valueText.ForeColor = Color.White;
            this.valueText.BackColor = Color.Transparent;

            this.valueText.Location = new Point(5, 30);
        }

        /// <summary>
        /// Handles the ValueChanged event of the ZeroitSeekBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ValueChangedEventArgs"/> instance containing the event data.</param>
        private void ZeroitSeekBar_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            valueText.Text = this.Value.ToString();

            if (this.Value < this.LeftLimiterValue)
            {
                this.Value = this.LeftLimiterValue;
            }

            //if (this.Value > this.RightLimiterValue)
            //{
            //    if (t.Enabled)
            //    {
            //        t.Stop();
            //        runTheTimer();
            //    }
            //    else
            //    {
            //        this.Value = this.RightLimiterValue;
            //    }
            //}
        }

        /// <summary>
        /// Handles the SizeChanged event of the SeekBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void SeekBar_SizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Resize event of the SeekBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void SeekBar_Resize(object sender, EventArgs e)
        {
            this.SetWidth = this.Width;
            this.SetHeight = this.Height;
            mainBar.Width = this.Width - 20;
            calculateDivisions();
        }
        /// <summary>
        /// Method used to set color on creation of control
        /// </summary>
        private void setInitialColor()
        {
            c_mainOutline = System.Drawing.Color.Black;
            c_fillBarOne = System.Drawing.Color.Blue;
            c_fillBarTwo = System.Drawing.Color.White;
            c_backgroundFill = System.Drawing.Color.Gray;
            c_seekerColorOne = System.Drawing.Color.White;
            c_seekerColorTwo = System.Drawing.Color.DarkSlateGray;
            c_seekerOutline = System.Drawing.Color.Black;
            c_topLimiterBackground = System.Drawing.Color.DarkSlateGray;
            c_topLimiterForeground = System.Drawing.Color.LimeGreen;
        }

        /// <summary>
        /// Sets the size of the rectangle.
        /// </summary>
        public void setRectangleSize()
        {
            mainBar = new System.Drawing.Rectangle(8, 20, this.Width, 10);
        }
        /// <summary>
        /// Changes position of seek marker
        /// </summary>
        public void setPos()
        {
            Xlocation = (int)(oneMove * seekValue);
        }

        #region DRAWING
        /// <summary>
        /// This method is here if the need arises to draw lines on each
        /// gradation its not used here but control can easily be adapted
        /// to use bolean switch to draw lines or not
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        //private void drawDivisions(Graphics g)
        //{
        //    for (int i = 1; i <= maxValue; i++)
        //    {
        //        int val = (int)(oneMove * i);
        //        g.DrawLine(Pens.Black, new Point(mainBar.X + val, mainBar.Y + mainBar.Height), new Point(mainBar.X + val, mainBar.Y + mainBar.Height + 30));
        //    }
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.valueText.ForeColor = ForeColor;
            mainControlHeight = this.Height;
            mainControlWidth = this.Width;
            createMainBar(e.Graphics);
            createFill(e.Graphics, Xlocation);
            createTracker(e.Graphics, Xlocation);
        }

        /// <summary>
        /// Creates the main bar.
        /// </summary>
        /// <param name="g">The g.</param>
        private void createMainBar(Graphics g)
        {
            Pen p = new Pen(c_mainOutline);
            g.DrawRectangle(p, mainBar);
        }

        /// <summary>
        /// Creates the tracker.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="Xloc">The xloc.</param>
        private void createTracker(Graphics g, int Xloc)
        {
            Point[] points = {
                                 new Point(mainBar.X + Xloc, mainBar.Y -  3),
                                 new Point(mainBar.X + Xloc + SEEK_WIDTH, mainBar.Y + (mainBar.Height/2)),
                                 new Point(mainBar.X + Xloc, mainBar.Y + mainBar.Height + 3),
                                 new Point(mainBar.X + Xloc - SEEK_WIDTH, mainBar.Y + (mainBar.Height /2))
                             };
            Point[] outerPoints = {
                                 new Point(mainBar.X + Xloc, mainBar.Y -  3),
                                 new Point(mainBar.X + Xloc + SEEK_WIDTH + 1, mainBar.Y + (mainBar.Height/2)),
                                 new Point(mainBar.X + Xloc, mainBar.Y + mainBar.Height + 3),
                                 new Point(mainBar.X + Xloc - SEEK_WIDTH - 1, mainBar.Y + (mainBar.Height /2))
                             };
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(mainBar.X + Xloc, mainBar.Y - 3), new Point(mainBar.X + Xloc, mainBar.Y + mainBar.Height + 3),
                 c_seekerColorOne, c_seekerColorTwo);
            g.FillPolygon(lgb, points);

            Pen p = new Pen(c_seekerOutline, 1.0f);
            g.DrawPolygon(p, outerPoints);
        }

        /// <summary>
        /// Creates the fill.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="width">The width.</param>
        private void createFill(Graphics g, int width)
        {
            fillBar = new System.Drawing.Rectangle(mainBar.X + 1, mainBar.Y + 1, width, ((mainBar.Height - 1) / 2));
            fillBarTwo = new System.Drawing.Rectangle(mainBar.X + 1, mainBar.Y + ((mainBar.Height - 1) / 2), width, ((mainBar.Height) / 2) + 1);
            backgroundBar = new System.Drawing.Rectangle(mainBar.X + 1, mainBar.Y + 1, mainBar.Width - 1, mainBar.Height - 1);
            topLimiter = new System.Drawing.Rectangle(mainBar.X, mainBar.Y - 9, mainBar.Width + 1, 7);
            leftLimiter = new System.Drawing.Rectangle(mainBar.X + leftLimiterLocation, mainBar.Y - 10, 5, 9);

            if (rightLimiterLocation > 0)
            {
                rightLimiter = new System.Drawing.Rectangle(mainBar.Right - (mainBar.Right - rightLimiterLocation), mainBar.Y - 10, 5, 9);
            }
            else
            {
                rightLimiter = new System.Drawing.Rectangle(mainBar.Right, mainBar.Y - 10, 5, 9);
            }

            LinearGradientBrush lb = new LinearGradientBrush(new Point(0, 0), new Point(0, fillBar.Height), c_fillBarOne, c_fillBarTwo);
            LinearGradientBrush lbTwo = new LinearGradientBrush(new Point(0, 0), new Point(0, fillBar.Height + 2), c_fillBarTwo, c_fillBarOne);

            SolidBrush b = new SolidBrush(c_backgroundFill);

            g.FillRectangle(b, backgroundBar);
            g.FillRectangle(lb, fillBar);
            g.FillRectangle(lbTwo, fillBarTwo);
            b.Color = c_topLimiterBackground;
            g.FillRectangle(b, topLimiter);
            g.DrawRectangle(new Pen(System.Drawing.Color.Black), topLimiter);
            g.DrawLine(new Pen(c_topLimiterForeground, 6), new Point(leftLimiter.X, leftLimiter.Y + 5), new Point(rightLimiter.X, rightLimiter.Y + 5));
            b.Color = System.Drawing.Color.Gray;
            g.FillRectangle(b, leftLimiter);
            g.FillRectangle(b, rightLimiter);
            g.DrawRectangle(new Pen(System.Drawing.Color.Black), leftLimiter);
            g.DrawRectangle(new Pen(System.Drawing.Color.Black), rightLimiter);

            if (drawRightInfoText)
            {
                System.Drawing.Font fnt = new System.Drawing.Font("Verdana", 6, System.Drawing.FontStyle.Bold);
                b.Color = System.Drawing.Color.Black;
                g.DrawString(rightLimiterText, fnt, b, new Point(rightLimiter.X + 7, rightLimiter.Y - 9));
            }
            if (drawLeftInfoText)
            {
                System.Drawing.Font fnt = new System.Drawing.Font("Verdana", 6, System.Drawing.FontStyle.Bold);
                b.Color = System.Drawing.Color.Black;
                g.DrawString(leftLimiterText, fnt, b, new Point(leftLimiter.X + 7, leftLimiter.Y - 9));
            }
        }

        #endregion

        #region MOUSE ARGs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mainBar.Contains(e.Location))
            {
                m_leftButtonDown = true;
                checkRegion(e.Location);
            }
            if (e.Button == MouseButtons.Left && leftLimiter.Contains(e.Location))
            {
                m_leftLimiterClicked = true;
                drawLeftInfoText = true;
                checkRegion(e.Location);
            }
            if (e.Button == MouseButtons.Left && rightLimiter.Contains(e.Location))
            {
                m_rightLimiterClicked = true;
                drawRightInfoText = true;
                checkRegion(e.Location);
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (m_leftButtonDown || m_leftLimiterClicked || m_rightLimiterClicked)
            {
                m_leftButtonDownAndMoving = true;
                checkRegion(e.Location);
                leftValueSet = false;
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_leftButtonDown = false;
                m_leftButtonDownAndMoving = false;
                m_leftLimiterClicked = false;
                m_rightLimiterClicked = false;
                drawLeftInfoText = false;
                drawRightInfoText = false;
            }
            this.Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        /// <summary>
        /// Checks wether mouse is in region
        /// </summary>
        /// <param name="p">Point that should hold mouse coords</param>
        private void checkRegion(Point p)
        {
            if (m_leftButtonDown)
            {
                Xlocation = p.X - 7;

                if (m_leftButtonDown && !m_leftButtonDownAndMoving)
                {
                    if (p.X < mainBar.Left || p.X > mainBar.Right)
                    {
                        return;
                    }
                }
                else if (m_leftButtonDownAndMoving)
                {
                    if (p.X < mainBar.Left)
                    {
                        Xlocation = 0;
                    }
                    else if (p.X >= mainBar.Right)
                    {
                        Xlocation = mainBar.Right - 5;
                    }
                }
                else
                {
                    return;
                }

                calculatePercentage();
                calculateDivisions();
                this.Invalidate();

                if (ValueChanged != null)
                {
                    ValueChanged(this, new ValueChangedEventArgs(seekValue));
                }
            }
            if (m_leftLimiterClicked)
            {
                if (p.X < rightLimiter.Location.X)
                {
                    leftLimiterLocation = p.X - 9;

                    if (m_leftLimiterClicked && !m_leftButtonDownAndMoving)
                    {
                        return;
                    }
                    else if (m_leftButtonDownAndMoving)
                    {
                        if (p.X < mainBar.Left)
                        {
                            leftLimiterLocation = 0;
                        }
                        else if (p.X >= mainBar.Right)
                        {
                            leftLimiterLocation = mainBar.Right - 5;
                        }
                    }
                    else
                    {
                        return;
                    }
                    calculateLeftPercentage();
                    calculateDivisions();
                    this.Invalidate();
                    if (leftLimiterValueChanged != null)
                    {
                        leftLimiterValueChanged(this, new leftLimiterValueChangedEventArgs(leftLimiterText));
                    }
                }
            }
            if (m_rightLimiterClicked)
            {
                if (p.X > leftLimiter.Location.X + 6)
                {
                    rightLimiterLocation = (p.X - 2);

                    if (m_rightLimiterClicked && !m_leftButtonDownAndMoving)
                    {
                        return;
                    }
                    else if (m_leftButtonDownAndMoving)
                    {
                        if (p.X < mainBar.Left)
                        {
                            rightLimiterLocation = 0;
                        }
                        else if (p.X >= mainBar.Right)
                        {
                            rightLimiterLocation = mainBar.Right - 5;
                        }
                    }
                    else
                    {
                        return;
                    }
                    calculateRightPercentage();
                    calculateDivisions();
                    this.Invalidate();

                    if (leftLimiterValueChanged != null)
                    {
                        rightLimiterValueChanged(this, new rightLimiterValueChangedEventArgs(rightLimiterText));
                    }
                }
            }
        }

        //
        //The next five methods are used to calculate current value of seek mark
        //or to calulate how much percent is one value depending on min and max
        //they are mostly simple math that should be easy to understaind
        //you can allways ask me if need arises: list3ner@gmail.com
        //
        /// <summary>
        /// Calculates the percentage.
        /// </summary>
        private void calculatePercentage()
        {
            int val = maxValue - minValue;
            percent = (val * Xlocation) / (this.Width - 20);
            prevVal = percent;
            seekValue = Convert.ToInt32(percent);
            //Console.WriteLine(percent.ToString());
        }

        /// <summary>
        /// Calculates the value.
        /// </summary>
        /// <param name="mousePos">The mouse position.</param>
        private void calculateValue(int mousePos)
        {
            int result = mousePos - previousMouseLocation;
            previousMouseLocation = mousePos;
        }

        /// <summary>
        /// Calculates the divisions.
        /// </summary>
        private void calculateDivisions()
        {
            int range = mainBar.Width;
            double val = maxValue - minValue;
            oneMove = range / val;
            //MessageBox.Show(mainBar.Width + ":" + (this.Width - 20).ToString());
        }

        /// <summary>
        /// Calculates the left percentage.
        /// </summary>
        private void calculateLeftPercentage()
        {
            int val = maxValue - minValue;
            leftPercent = (val * leftLimiter.Location.X) / (this.Width - 20);
            prevLeftVal = leftPercent;
            leftSeekValue = Convert.ToInt32(leftPercent);
            //Console.WriteLine(leftPercent.ToString());
        }

        /// <summary>
        /// Calculates the right percentage.
        /// </summary>
        private void calculateRightPercentage()
        {
            int val = maxValue - minValue;
            rightPercent = (val * rightLimiter.Location.X) / (this.Width - 20);
            prevRightVal = rightPercent;
            rightSeekValue = Convert.ToInt32(rightPercent);
            //Console.WriteLine(rightPercent.ToString());
        }

        #region COLOR PROPERTIES

        /// <summary>
        /// Gets or sets the main outline color.
        /// </summary>
        /// <value>The main outline color.</value>
        [Description("Set controls main outline color")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "Black")]
        public Color MainOutline
        {
            get { return c_mainOutline; }
            set
            {
                c_mainOutline = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the first color of progress indicator bar.
        /// </summary>
        /// <value>The first fill bar color.</value>
        [Description("Set first color of progress indicator bar")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "Blue")]
        public Color FillBarColorOne
        {
            get { return c_fillBarOne; }
            set
            {
                c_fillBarOne = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the second color of progress indicator bar.
        /// </summary>
        /// <value>The second fill bar color.</value>
        [Description("Set second color of progress indicator bar")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "White")]
        public Color FillBarColorTwo
        {
            get { return c_fillBarTwo; }
            set
            {
                c_fillBarTwo = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        [Description("Set background color")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "Gray")]
        public Color BackgroundFillColor
        {
            get { return c_backgroundFill; }
            set
            {
                c_backgroundFill = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the seeker outline.
        /// </summary>
        /// <value>The color of the seeker outline.</value>
        [Description("Set seeker outline color")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "Gray")]
        public Color SeekerOutlineColor
        {
            get { return c_seekerOutline; }
            set
            {
                c_seekerOutline = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the first seeker gradient color.
        /// </summary>
        /// <value>The first seeker gradient color.</value>
        [Description("Set seeker gradient color one")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "White")]
        public Color SeekerGradientColorOne
        {
            get { return c_seekerColorOne; }
            set
            {
                c_seekerColorOne = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the first seeker gradient color.
        /// </summary>
        /// <value>The first seeker gradient color.</value>
        [Description("Set seeker gradient color two")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "DarkSlateGray")]
        public Color SeekerGradientColorTwo
        {
            get { return c_seekerColorTwo; }
            set
            {
                c_seekerColorTwo = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the limiter bar background.
        /// </summary>
        /// <value>The limiter bar background.</value>
        [Description("Set background of limiter bar")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "DarkSlateGray")]
        public Color LimiterBarBackground
        {
            get { return c_topLimiterBackground; }
            set
            {
                c_topLimiterBackground = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the limiter bar foreground color.
        /// </summary>
        /// <value>The limiter bar foreground.</value>
        [Description("Set foreground of limiter bar")]
        [Category("SeekBar")]
        [DefaultValue(typeof(System.Drawing.Color), "DarkSlateGray")]
        public Color LimiterBarForeground
        {
            get { return c_topLimiterForeground; }
            set
            {
                c_topLimiterForeground = value;
                Invalidate();
            }
        }

        #endregion

        #region SIZE PROPERTIES

        /// <summary>
        /// Gets or sets the width of the main control.
        /// </summary>
        /// <value>The width of the main control.</value>
        [Description("Set Width")]
        [Category("SeekBar")]
        [DefaultValue(320)]
        public int SetWidth
        {
            get { return mainControlWidth; }
            set
            {
                mainControlWidth = value;
                this.Width = mainControlWidth;
                calculateDivisions();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the main control.
        /// </summary>
        /// <value>The height of the main control.</value>
        [Description("Set Height")]
        [Category("SeekBar")]
        [DefaultValue(40)]
        public int SetHeight
        {
            get { return mainControlHeight; }
            set
            {
                mainControlHeight = value;
                this.Height = mainControlHeight;
                calculateDivisions();
                Invalidate();
            }
        }

        #endregion

        #region MAXIMUM MINIMUM

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("Set Maximum")]
        [Category("SeekBar")]
        [DefaultValue(100)]
        public int SetMaximum
        {
            get { return maxValue; }
            set
            {
                if (maxValue < minValue)
                {
                    MessageBox.Show("Maximum Value canot be smaller than Minimum!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    maxValue = value;
                    calculateDivisions();
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Description("Set Minimum")]
        [Category("SeekBar")]
        [DefaultValue(0)]
        public int SetMinimum
        {
            get { return minValue; }
            set
            {
                if (minValue > maxValue)
                {
                    MessageBox.Show("Minimum value canot be larger than Maximum!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    minValue = value;
                    calculateDivisions();
                    this.Refresh();
                }
            }
        }

        #endregion

        #region VALUE PROPERTIES

        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        /// <value>The value.</value>
        [Description("Set Initial Value")]
        [Category("SeekBar")]
        [DefaultValue(0)]
        public int Value
        {
            get { return seekValue; }
            set
            {
                if (value > maxValue)
                {
                    MessageBox.Show("Lets not go overboard!");
                }
                else if (value < minValue)
                {
                    MessageBox.Show("How low can u go?");
                }
                else
                {
                    seekValue = value;
                    setPos();

                    if (ValueChanged != null)
                    {
                        ValueChanged(this, new ValueChangedEventArgs(seekValue));
                    }

                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the left limiter value.
        /// </summary>
        /// <value>The left limiter value.</value>
        [Description("Set the left limiter value")]
        [Category("SeekBar")]
        public int LeftLimiterValue
        {
            get { return leftSeekValue; }
            set
            {
                if (value > maxValue)
                {
                    MessageBox.Show("Lets not go overboard!");
                }
                else if (value < minValue)
                {
                    MessageBox.Show("How low can u go?");
                }
                else
                {
                    leftSeekValue = value;
                    setPos();
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the right limiter value.
        /// </summary>
        /// <value>The right limiter value.</value>
        [Description("Set the right limiter value")]
        [Category("SeekBar")]
        public int RightLimiterValue
        {
            get { return rightSeekValue; }

            set
            {
                if (value > maxValue)
                {
                    MessageBox.Show("Lets not go overboard!");
                }
                else if (value < minValue)
                {
                    MessageBox.Show("How low can u go?");
                }
                else
                {
                    rightSeekValue = value;
                    setPos();
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the left limiter location.
        /// </summary>
        /// <value>The left limiter location.</value>
        [Description("Set the left limiter location")]
        [Category("SeekBar")]
        public int LeftLimiterLocation
        {
            get { return leftLimiterLocation; }
            set { leftLimiterLocation = value; }
        }

        /// <summary>
        /// Gets or sets the right limiter location.
        /// </summary>
        /// <value>The right limiter location.</value>
        [Description("Set the right limiter location")]
        [Category("SeekBar")]
        public int RightLimiterLocation
        {
            get { return rightLimiterLocation; }
            set { rightLimiterLocation = value; }
        }

        /// <summary>
        /// Gets or sets the left limiter text.
        /// </summary>
        /// <value>The left limiter text.</value>
        [Description("Set the left limiter text")]
        [Category("SeekBar")]
        public string LeftLimiterText
        {
            get
            {
                return leftLimiterText;
            }
            set { leftLimiterText = value; }
        }

        /// <summary>
        /// Gets or sets the right limiter text.
        /// </summary>
        /// <value>The right limiter text.</value>
        [Description("Set the right limiter text")]
        [Category("SeekBar")]
        public string RightLimiterText
        {
            get
            {
                return rightLimiterText;
            }
            set { rightLimiterText = value; }
        }

        #endregion

        /// <summary>
        /// Moves the left.
        /// </summary>
        /// <param name="value">The value.</param>
        public void moveLeft(int value)
        {
            if (value > maxValue)
            {
                MessageBox.Show("Lets not go overboard!");
            }
            else if (value < minValue)
            {
                MessageBox.Show("How low can u go?");
            }
            else
            {
                if (!leftValueSet)
                {
                    this.Value = leftSeekValue;
                    leftValueSet = true;
                }
                if (this.Value < rightSeekValue && rightSeekValue != 0)
                {
                    this.Value = value;
                }
                else if (this.Value < maxValue && rightSeekValue == 0)
                {
                    this.Value = value;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl" /> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            calculateDivisions();
            calculateLeftPercentage();
            calculateRightPercentage();
            if (seekValue > 0)
            {
                setPos();
            }
            this.RightLimiterValue = this.maxValue;
            base.OnCreateControl();
        }

        /// <summary>
        /// Gets or sets the set left text.
        /// </summary>
        /// <value>The set left text.</value>
        private string setLeftText
        {
            get { return leftLimiterText; }
            set
            {
                leftLimiterText = value;
            }
        }

        /// <summary>
        /// Gets or sets the set right text.
        /// </summary>
        /// <value>The set right text.</value>
        private string setRightText
        {
            get { return rightLimiterText; }
            set
            {
                rightLimiterText = value;
            }
        }
    }
    #endregion

    #region Designer Generated Code
    partial class ZeroitSeekBar
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
            components = new System.ComponentModel.Container();

            this.valueText = new System.Windows.Forms.Label();

            //valueText
            this.valueText.AutoSize = true;
            this.valueText.Font = new System.Drawing.Font("Verdana", 7F);
            this.valueText.Location = new System.Drawing.Point(0, 28);
            this.valueText.Name = "valueText";
            this.valueText.Size = new System.Drawing.Size(8, 8);
            this.valueText.TabIndex = 3;
            this.valueText.Text = "0";

            this.Controls.Add(this.valueText);
        }

        /// <summary>
        /// The value text
        /// </summary>
        private System.Windows.Forms.Label valueText;

        #endregion
    }
    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSeekBarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSeekBarDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSeekBarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSeekBarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSeekBarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSeekBar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSeekBarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSeekBarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSeekBar;

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

        #region COLOR PROPERTIES

        /// <summary>
        /// Gets or sets the main outline.
        /// </summary>
        /// <value>The main outline.</value>
        public Color MainOutline
        {
            get
            {
                return colUserControl.MainOutline;
            }
            set
            {
                GetPropertyByName("MainOutline").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill bar color one.
        /// </summary>
        /// <value>The fill bar color one.</value>
        public Color FillBarColorOne
        {
            get
            {
                return colUserControl.FillBarColorOne;
            }
            set
            {
                GetPropertyByName("FillBarColorOne").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill bar color two.
        /// </summary>
        /// <value>The fill bar color two.</value>
        public Color FillBarColorTwo
        {
            get
            {
                return colUserControl.FillBarColorTwo;
            }
            set
            {
                GetPropertyByName("FillBarColorTwo").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the background fill.
        /// </summary>
        /// <value>The color of the background fill.</value>
        public Color BackgroundFillColor
        {
            get
            {
                return colUserControl.BackgroundFillColor;
            }
            set
            {
                GetPropertyByName("BackgroundFillColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the seeker outline.
        /// </summary>
        /// <value>The color of the seeker outline.</value>
        public Color SeekerOutlineColor
        {
            get
            {
                return colUserControl.SeekerOutlineColor;
            }
            set
            {
                GetPropertyByName("SeekerOutlineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the seeker gradient color one.
        /// </summary>
        /// <value>The seeker gradient color one.</value>
        public Color SeekerGradientColorOne
        {
            get
            {
                return colUserControl.SeekerGradientColorOne;
            }
            set
            {
                GetPropertyByName("SeekerGradientColorOne").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the seeker gradient color two.
        /// </summary>
        /// <value>The seeker gradient color two.</value>
        public Color SeekerGradientColorTwo
        {
            get
            {
                return colUserControl.SeekerGradientColorTwo;
            }
            set
            {
                GetPropertyByName("SeekerGradientColorTwo").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the limiter bar background.
        /// </summary>
        /// <value>The limiter bar background.</value>
        public Color LimiterBarBackground
        {
            get
            {
                return colUserControl.LimiterBarBackground;
            }
            set
            {
                GetPropertyByName("LimiterBarBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the limiter bar foreground.
        /// </summary>
        /// <value>The limiter bar foreground.</value>
        public Color LimiterBarForeground
        {
            get
            {
                return colUserControl.LimiterBarForeground;
            }
            set
            {
                GetPropertyByName("LimiterBarForeground").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region SIZE PROPERTIES

        /// <summary>
        /// Gets or sets the width of the set.
        /// </summary>
        /// <value>The width of the set.</value>
        public int SetWidth
        {
            get
            {
                return colUserControl.SetWidth;
            }
            set
            {
                GetPropertyByName("SetWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the set.
        /// </summary>
        /// <value>The height of the set.</value>
        public int SetHeight
        {
            get
            {
                return colUserControl.SetHeight;
            }
            set
            {
                GetPropertyByName("SetHeight").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region MAXIMUM MINIMUM

        /// <summary>
        /// Gets or sets the set maximum.
        /// </summary>
        /// <value>The set maximum.</value>
        public int SetMaximum
        {
            get
            {
                return colUserControl.SetMaximum;
            }
            set
            {
                GetPropertyByName("SetMaximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the set minimum.
        /// </summary>
        /// <value>The set minimum.</value>
        public int SetMinimum
        {
            get
            {
                return colUserControl.SetMinimum;
            }
            set
            {
                GetPropertyByName("SetMinimum").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region VALUE PROPERTIES

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
        /// Gets or sets the left limiter value.
        /// </summary>
        /// <value>The left limiter value.</value>
        public int LeftLimiterValue
        {
            get
            {
                return colUserControl.LeftLimiterValue;
            }
            set
            {
                GetPropertyByName("LeftLimiterValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the right limiter value.
        /// </summary>
        /// <value>The right limiter value.</value>
        public int RightLimiterValue
        {
            get
            {
                return colUserControl.RightLimiterValue;
            }
            set
            {
                GetPropertyByName("RightLimiterValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the left limiter location.
        /// </summary>
        /// <value>The left limiter location.</value>
        public int LeftLimiterLocation
        {
            get
            {
                return colUserControl.LeftLimiterLocation;
            }
            set
            {
                GetPropertyByName("LeftLimiterLocation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the right limiter location.
        /// </summary>
        /// <value>The right limiter location.</value>
        public int RightLimiterLocation
        {
            get
            {
                return colUserControl.RightLimiterLocation;
            }
            set
            {
                GetPropertyByName("RightLimiterLocation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the left limiter text.
        /// </summary>
        /// <value>The left limiter text.</value>
        public string LeftLimiterText
        {
            get
            {
                return colUserControl.LeftLimiterText;
            }
            set
            {
                GetPropertyByName("LeftLimiterText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the right limiter text.
        /// </summary>
        /// <value>The right limiter text.</value>
        public string RightLimiterText
        {
            get
            {
                return colUserControl.RightLimiterText;
            }
            set
            {
                GetPropertyByName("RightLimiterText").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("MainOutline",
                                 "Main Outline", "Appearance",
                                 "Sets the main outline color."));

            items.Add(new DesignerActionPropertyItem("FillBarColorOne",
                                 "Fill Bar Color One", "Appearance",
                                 "Sets the bar color fill."));

            items.Add(new DesignerActionPropertyItem("FillBarColorTwo",
                                 "Fill Bar Color Two", "Appearance",
                                 "Sets the bar color fill."));

            items.Add(new DesignerActionPropertyItem("BackgroundFillColor",
                                 "Background Fill Color", "Appearance",
                                 "Sets the background color fill."));

            items.Add(new DesignerActionPropertyItem("SeekerOutlineColor",
                                 "Seeker Outline Color", "Appearance",
                                 "Sets the seeker outline color."));

            items.Add(new DesignerActionPropertyItem("SeekerGradientColorOne",
                                 "Seeker Gradient Color One", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SeekerGradientColorTwo",
                                 "Seeker Gradient Color Two", "Appearance",
                                 "Sets the seeker gradient color."));

            items.Add(new DesignerActionPropertyItem("LimiterBarBackground",
                                 "Limiter Bar Background", "Appearance",
                                 "Sets the background limiter color."));

            items.Add(new DesignerActionPropertyItem("LimiterBarForeground",
                                 "Limiter Bar Foreground", "Appearance",
                                 "Sets the foreground limiter color."));

            items.Add(new DesignerActionPropertyItem("SetWidth",
                                 "Set Width", "Appearance",
                                 "Sets the width."));

            items.Add(new DesignerActionPropertyItem("SetHeight",
                                 "Set Height", "Appearance",
                                 "Sets the height."));

            items.Add(new DesignerActionPropertyItem("SetMaximum",
                                 "Set Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("SetMinimum",
                                 "Set Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value."));

            items.Add(new DesignerActionPropertyItem("LeftLimiterValue",
                                 "Left Limiter Value", "Appearance",
                                 "Sets the left limiter value."));

            items.Add(new DesignerActionPropertyItem("RightLimiterValue",
                                 "Right Limiter Value", "Appearance",
                                 "Sets the right limiter value."));

            items.Add(new DesignerActionPropertyItem("LeftLimiterLocation",
                                 "Left Limiter Location", "Appearance",
                                 "Sets the limiter location."));

            items.Add(new DesignerActionPropertyItem("RightLimiterLocation",
                                 "Right Limiter Location", "Appearance",
                                 "Sets the right limiter location."));

            items.Add(new DesignerActionPropertyItem("LeftLimiterText",
                                 "Set Left Limiter Text", "Appearance",
                                 "Sets the left limiter text."));

            items.Add(new DesignerActionPropertyItem("RightLimiterText",
                                 "Set Right LimiterText", "Appearance",
                                 "Sets the right limiter text."));


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

    #endregion
}
