// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-25-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="ZeroitMultiCoExtended.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitProgressMultiCoExtended : Control
    {
        #region Private Fields

        /// <summary>
        /// The value
        /// </summary>
        private float value = 0;

        /// <summary>
        /// The show inner border
        /// </summary>
        private bool showInnerBorder = true;

        /// <summary>
        /// The speed
        /// </summary>
        public int speed = 100;

        /// <summary>
        /// The inner border
        /// </summary>
        private int innerBorder = 2;

        /// <summary>
        /// The shift
        /// </summary>
        private int shift = 15;

        /// <summary>
        /// The correct shift
        /// </summary>
        private int correctShift = 6;

        /// <summary>
        /// The rect shift
        /// </summary>
        private int rectShift = 3;

        /// <summary>
        /// The no of rings
        /// </summary>
        private Rings noOfRings = Rings.Default;

        /// <summary>
        /// The inner border color
        /// </summary>
        private Color innerBorderColor = Color.Gray;

        /// <summary>
        /// The colors
        /// </summary>
        Color[] colors = new Color[]
            {
                Color.Red,
                Color.Yellow,
                Color.Green,
                Color.AliceBlue,
                Color.Brown,
                Color.Chocolate,
                Color.DarkOrange,
                Color.DarkRed,
                Color.DeepPink,
                Color.Indigo,
                Color.Ivory,
                Color.Lavender,
                Color.LightSeaGreen,
                Color.Maroon,
                Color.OrangeRed,
                Color.Orchid,
                Color.PaleGoldenrod,
                Color.PapayaWhip,
                Color.Teal,
                Color.Tomato,
                Color.YellowGreen,
                Color.Thistle,
                Color.Tan,
                Color.SlateGray,
            };

        /// <summary>
        /// The one ringa
        /// </summary>
        private float[] oneRinga = new float[] { 270f };
        /// <summary>
        /// The one ringb
        /// </summary>
        private float[] oneRingb = new float[] { 0f };
        /// <summary>
        /// The one ring maximum
        /// </summary>
        private float oneRingMax = 360;

        /// <summary>
        /// The two ringa
        /// </summary>
        private float[] twoRinga = new float[] { 270f, 0f };
        /// <summary>
        /// The two ringb
        /// </summary>
        private float[] twoRingb = new float[] { 90f, 0f };
        /// <summary>
        /// The two ring maximum
        /// </summary>
        private float twoRingMax = 180;

        /// <summary>
        /// The four ringa
        /// </summary>
        private float[] fourRinga = new float[] { 270f, 0f, 90f, 180f };
        /// <summary>
        /// The four ringb
        /// </summary>
        private float[] fourRingb = new float[] { 0f, 0f, 0f, 0f };
        /// <summary>
        /// The four ring maximum
        /// </summary>
        private float fourRingMax = 90;

        /// <summary>
        /// The eight ringa
        /// </summary>
        private float[] eightRinga = new float[] { 270f, 315f, 0f, 45f, 90f, 135f, 180f, 225f };
        /// <summary>
        /// The eight ringb
        /// </summary>
        private float[] eightRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The eight ring maximum
        /// </summary>
        private float eightRingMax = 45;

        /// <summary>
        /// The twelve ringa
        /// </summary>
        private float[] twelveRinga = new float[] { 270f, 300f, 330f, 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f };
        /// <summary>
        /// The twelve ringb
        /// </summary>
        private float[] twelveRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The twelve ring maximum
        /// </summary>
        private float twelveRingMax = 30;



        /// <summary>
        /// The twenty four ringa
        /// </summary>
        private float[] twentyFourRinga = new float[] { 270f, 285f, 300f, 315f, 330f, 345f, 0f, 15f, 30f, 45f, 60f, 75f, 90f, 105f, 120f, 135f, 150f, 165f, 180f, 195f, 210, 225, 240f, 255 };
        /// <summary>
        /// The twenty four ringb
        /// </summary>
        private float[] twentyFourRingb = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        /// <summary>
        /// The twenty four ring maximum
        /// </summary>
        private float twentyFourRingMax = 15;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color of the inner border.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public Color InnerBorderColor
        {
            get { return innerBorderColor; }
            set
            {
                innerBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the speed of the animation.
        /// </summary>
        /// <value>The speed.</value>
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public Color[] Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Enum representing the number of rings.
        /// </summary>
        public enum Rings
        {
            /// <summary>
            /// The default
            /// </summary>
            Default,
            /// <summary>
            /// The one
            /// </summary>
            One,
            /// <summary>
            /// The two
            /// </summary>
            Two,
            /// <summary>
            /// The four
            /// </summary>
            Four,
            /// <summary>
            /// The eight
            /// </summary>
            Eight,
            /// <summary>
            /// The twelve
            /// </summary>
            Twelve,
            /// <summary>
            /// The twenty four
            /// </summary>
            TwentyFour
        }

        /// <summary>
        /// Gets or sets the no of rings.
        /// </summary>
        /// <value>The no of rings.</value>
        public Rings NoOfRings
        {
            get { return noOfRings; }
            set
            {
                noOfRings = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
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
        /// Gets or sets a value indicating whether to show inner border.
        /// </summary>
        /// <value><c>true</c> if show inner border; otherwise, <c>false</c>.</value>
        public bool ShowInnerBorder
        {
            get { return showInnerBorder; }
            set
            {
                showInnerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public int InnerBorder
        {
            get { return innerBorder; }
            set
            {
                innerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner shift.
        /// </summary>
        /// <value>The inner shift.</value>
        public int InnerShift
        {
            get { return rectShift; }
            set
            {
                rectShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the way to correct shifts.
        /// </summary>
        /// <value>The correct shift.</value>
        public int CorrectShift
        {
            get { return correctShift; }
            set
            {
                correctShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shift.
        /// </summary>
        /// <value>The shift.</value>
        public int Shift
        {
            get { return shift; }
            set
            {
                shift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rectangular shifts.
        /// </summary>
        /// <value>The rectangular shift.</value>
        public int RectShift
        {
            get { return rectShift; }
            set
            {
                rectShift = value;
                Invalidate();
            }
        }


        #endregion


        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = false;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatically start animation.
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
            if (this.Value + 1 > 100)
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


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressMultiCoExtended"/> class.
        /// </summary>
        public ZeroitProgressMultiCoExtended()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);


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
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            timer.Interval = speed;


            Graphics G = e.Graphics;

            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = smoothing;


            Rectangle rect = new Rectangle(correctShift, correctShift, Width - shift, Height - shift);
            Rectangle coloredRectangle = new Rectangle(0, 0, Width - rectShift, Height - rectShift);



            if (showInnerBorder)
            {
                g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                g.DrawEllipse(new Pen(innerBorderColor, innerBorder), rect);
            }

            else
            {
                g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                g.DrawEllipse(new Pen(Color.Transparent, innerBorder), rect);

            }


            switch (noOfRings)
            {
                case Rings.One:

                    #region 1 ring


                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, oneRinga[0], (this.value / 100) * (360f /*+ oneRingb[0]*/));
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);


                    #endregion

                    break;
                case Rings.Two:

                    #region 2 rings

                    if (value >= 0 && value < 51)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    }

                    else
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 50) * 180f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 90f, ((this.value - 50) / 50) * 180f);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    }

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Four:

                    #region 4 rings

                    if (value >= 0 && value < 26)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 25 && value < 51)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                    }

                    else if (value > 50 && value < 76)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                    }

                    else
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, ((this.value - 25) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, ((this.value - 50) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 180f, ((this.value - 75) / 25) * 90f);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);


                    }

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);


                    #endregion

                    break;
                case Rings.Eight:


                    #region 8 Rings

                    if (value >= 0 && value < 13f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 12f && value < 26)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 25f && value < 38)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                    }

                    else if (value > 37f && value < 51)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    }

                    else if (value > 50 && value < 63)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                    }

                    else if (value > 62 && value < 76)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                    }

                    else if (value > 75 && value < 88)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    }


                    else
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, ((this.value - 12.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, ((this.value - 25) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, ((this.value - 37.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, ((this.value - 50) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, ((this.value - 62.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, ((this.value - 75f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 225f, ((this.value - 87.5f) / 12.5f) * 45);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                    }


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Twelve:

                    #region 12 Rings


                    if (value >= 0 && value < 8.4f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 8.5 && value < 17f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    }

                    else if (value > 16.6 && value < 26f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    }

                    else if (value > 25 && value < 34f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                    }

                    else if (value > 33 && value < 43f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                    }

                    else if (value > 42 && value < 51f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                    }

                    else if (value > 50 && value < 60f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    }

                    else if (value > 59 && value < 68f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                    }

                    else if (value > 67 && value < 76f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);




                    }

                    else if (value > 75f && value < 85f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    }

                    else if (value > 84f && value < 93f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    }

                    else
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, ((this.value - 8.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, ((this.value - 16.6666f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, ((this.value - 24.9999f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, ((this.value - 33.3332f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, ((this.value - 41.6665f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, ((this.value - 49.9998f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, ((this.value - 58.3331f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, ((this.value - 66.6664f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, ((this.value - 74.9997f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, ((this.value - 83.3333f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 240f, ((this.value - 91.6663f) / 8.3333f) * 30);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                    }


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.TwentyFour:

                    #region 24 Rings

                    if (value >= 0 && value < 5f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    }

                    else if (value > 4 && value < 9f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    }

                    else if (value > 8 && value < 14f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    }

                    else if (value > 13 && value < 18f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 17 && value < 22f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);
                    }

                    else if (value > 21 && value < 26f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    }

                    else if (value > 25 && value < 31f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    }

                    else if (value > 30 && value < 35f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    }

                    else if (value > 34 && value < 39f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                    }

                    else if (value > 38 && value < 43f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);
                    }

                    else if (value > 42 && value < 47f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    }

                    else if (value > 46 && value < 51f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                    }

                    else if (value > 50 && value < 56f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                    }

                    else if (value > 55 && value < 60f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                    }

                    else if (value > 59 && value < 64f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                    }

                    else if (value > 63 && value < 68f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                    }

                    else if (value > 67 && value < 72f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);
                    }

                    else if (value > 71 && value < 76f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                    }

                    else if (value > 75 && value < 81f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                    }

                    else if (value > 80 && value < 85f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                    }

                    else if (value > 84 && value < 89f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 
                    }

                    else if (value > 88 && value < 93f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                        g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                    }

                    else if (value > 92 && value < 97f)
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                        g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);
                    }

                    else
                    {
                        g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, (this.value / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, ((this.value - 4.1666f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, ((this.value - 8.3332f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, ((this.value - 12.4999f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, ((this.value - 16.6664f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, ((this.value - 20.8331f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                        g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, ((this.value - 24.9997f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, ((this.value - 29.1662f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, ((this.value - 33.3325f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, ((this.value - 37.4991f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, ((this.value - 41.6657f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, ((this.value - 45.8322f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                        g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, ((this.value - 49.9989f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                        g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, ((this.value - 54.1655f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, ((this.value - 58.3321f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, ((this.value - 62.4987f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, ((this.value - 66.6653f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, ((this.value - 70.8319f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                        g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, ((this.value - 74.9985f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, ((this.value - 79.1651f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, ((this.value - 83.3316f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                        g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, ((this.value - 87.4983f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, ((this.value - 91.6649f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                        g.FillPie(new SolidBrush(colors[23]), coloredRectangle, 255f, ((this.value - 95.8315f) / 4.1666f) * 15);
                        //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                    }

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Default:

                    g.FillPie(new SolidBrush(Color.Transparent), coloredRectangle, 270f, 360f);
                    //g.DrawPie(new Pen(Color.Black, 2), coloredRectangle, 270f, 90f);

                    g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                    g.DrawEllipse(new Pen(Color.Gray, 2), rect);

                    break;
            }

        }



    }


}
