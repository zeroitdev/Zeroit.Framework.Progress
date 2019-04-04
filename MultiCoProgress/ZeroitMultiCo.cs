// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-25-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="ZeroitMultiCo.cs" company="Zeroit Dev Technologies">
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
    public class ZeroitProgressMultiCo : Control
    {
        #region Private Properties



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
        /// Gets or sets the colors used for the control.
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
        /// Gets or sets the way to correct the shifts.
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
        /// Gets or sets the rectangular shift.
        /// </summary>
        /// <value>The rect shift.</value>
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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressMultiCo" /> class.
        /// </summary>
        public ZeroitProgressMultiCo()
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

        #region Animation Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {

            switch (noOfRings)
            {
                case Rings.Default:
                    break;
                case Rings.One:
                    if (this.oneRingb[0] + 1 > oneRingMax)
                    {
                        this.oneRingb[0] = 0;
                    }

                    else
                    {
                        this.oneRingb[0]++;
                        Invalidate();
                    }
                    break;
                case Rings.Two:

                    if (this.twoRinga[1] + 1 > twoRingMax)
                    {
                        this.twoRinga[1] = twoRingMax;

                        if (twoRinga[1] + 1 > twoRingMax)
                        {
                            this.twoRingb[1]++;
                            Invalidate();

                            if (twoRingb[1] + 1 > twoRingMax)
                            {
                                this.twoRinga[1] = 0f;
                                this.twoRingb[1] = 0f;
                                Invalidate();
                            }
                        }


                        //else
                        //{
                        //    this.twoRinga[1]++;
                        //    Invalidate();
                        //}



                    }

                    else
                    {
                        this.twoRinga[1]++;
                        Invalidate();
                    }

                    break;
                case Rings.Four:

                    if (this.fourRingb[0] + 1 > fourRingMax)
                    {
                        this.fourRingb[0] = fourRingMax;

                        if (fourRingb[0] + 1 > fourRingMax)
                        {
                            this.fourRingb[1]++;
                            Invalidate();

                            if (fourRingb[1] + 1 > fourRingMax)
                            {
                                this.fourRingb[2]++;
                                Invalidate();

                                if (fourRingb[2] + 1 > fourRingMax)
                                {
                                    this.fourRingb[3]++;
                                    Invalidate();

                                    if (fourRingb[3] + 1 > fourRingMax)
                                    {
                                        this.fourRingb[0] = 0f;
                                        this.fourRingb[1] = 0f;
                                        this.fourRingb[2] = 0f;
                                        this.fourRingb[3] = 0f;
                                        Invalidate();
                                    }

                                }

                            }
                        }


                        //else
                        //{
                        //    this.twoRinga[1]++;
                        //    Invalidate();
                        //}



                    }

                    else
                    {
                        this.fourRingb[0]++;
                        Invalidate();
                    }

                    break;
                case Rings.Eight:

                    if (this.eightRingb[0] + 1 > eightRingMax)
                    {
                        this.eightRingb[0] = eightRingMax;

                        if (eightRingb[0] + 1 > eightRingMax)
                        {
                            this.eightRingb[1]++;
                            Invalidate();

                            if (eightRingb[1] + 1 > eightRingMax)
                            {

                                this.eightRingb[2]++;
                                Invalidate();

                                if (eightRingb[2] + 1 > eightRingMax)
                                {

                                    this.eightRingb[3]++;
                                    Invalidate();

                                    if (eightRingb[3] + 1 > eightRingMax)
                                    {
                                        this.eightRingb[3] = eightRingMax;
                                        this.eightRingb[4]++;
                                        Invalidate();

                                        if (eightRingb[4] + 1 > eightRingMax)
                                        {
                                            this.eightRingb[4] = eightRingMax;
                                            this.eightRingb[5]++;
                                            Invalidate();

                                            if (eightRingb[5] + 1 > eightRingMax)
                                            {
                                                this.eightRingb[6]++;
                                                Invalidate();

                                                if (eightRingb[6] + 1 > eightRingMax)
                                                {
                                                    this.eightRingb[7]++;
                                                    Invalidate();

                                                    if (eightRingb[7] + 1 > eightRingMax)
                                                    {
                                                        this.eightRingb[0] = 0f;
                                                        this.eightRingb[1] = 0f;
                                                        this.eightRingb[2] = 0f;
                                                        this.eightRingb[3] = 0f;
                                                        this.eightRingb[4] = 0f;
                                                        this.eightRingb[5] = 0f;
                                                        this.eightRingb[6] = 0f;
                                                        this.eightRingb[7] = 0f;
                                                        Invalidate();

                                                    }

                                                }
                                            }
                                        }


                                    }

                                }

                            }
                        }


                        //else
                        //{
                        //    this.twoRinga[1]++;
                        //    Invalidate();
                        //}



                    }

                    else
                    {
                        this.eightRingb[0]++;
                        Invalidate();
                    }

                    break;
                case Rings.Twelve:

                    if (this.twelveRingb[0] + 1 > twelveRingMax)
                    {
                        this.twelveRingb[0] = twelveRingMax;

                        if (twelveRingb[0] + 1 > twelveRingMax)
                        {
                            this.twelveRingb[1]++;
                            Invalidate();

                            if (twelveRingb[1] + 1 > twelveRingMax)
                            {

                                this.twelveRingb[2]++;
                                Invalidate();

                                if (twelveRingb[2] + 1 > twelveRingMax)
                                {

                                    this.twelveRingb[3]++;
                                    Invalidate();

                                    if (twelveRingb[3] + 1 > twelveRingMax)
                                    {
                                        this.twelveRingb[3] = twelveRingMax;
                                        this.twelveRingb[4]++;
                                        Invalidate();

                                        if (twelveRingb[4] + 1 > twelveRingMax)
                                        {
                                            this.twelveRingb[4] = twelveRingMax;
                                            this.twelveRingb[5]++;
                                            Invalidate();

                                            if (twelveRingb[5] + 1 > twelveRingMax)
                                            {
                                                this.twelveRingb[6]++;
                                                Invalidate();

                                                if (twelveRingb[6] + 1 > twelveRingMax)
                                                {
                                                    this.twelveRingb[7]++;
                                                    Invalidate();

                                                    if (twelveRingb[7] + 1 > twelveRingMax)
                                                    {
                                                        this.twelveRingb[8]++;
                                                        Invalidate();

                                                        if (twelveRingb[8] + 1 > twelveRingMax)
                                                        {
                                                            this.twelveRingb[9]++;
                                                            Invalidate();

                                                            if (twelveRingb[9] + 1 > twelveRingMax)
                                                            {
                                                                this.twelveRingb[10]++;
                                                                Invalidate();

                                                                if (twelveRingb[10] + 1 > twelveRingMax)
                                                                {
                                                                    this.twelveRingb[11]++;
                                                                    Invalidate();

                                                                    if (twelveRingb[11] + 1 > twelveRingMax)
                                                                    {
                                                                        this.twelveRingb[0] = 0f;
                                                                        this.twelveRingb[1] = 0f;
                                                                        this.twelveRingb[2] = 0f;
                                                                        this.twelveRingb[3] = 0f;
                                                                        this.twelveRingb[4] = 0f;
                                                                        this.twelveRingb[5] = 0f;
                                                                        this.twelveRingb[6] = 0f;
                                                                        this.twelveRingb[7] = 0f;
                                                                        this.twelveRingb[8] = 0f;
                                                                        this.twelveRingb[9] = 0f;
                                                                        this.twelveRingb[10] = 0f;
                                                                        this.twelveRingb[11] = 0f;

                                                                        Invalidate();
                                                                    }
                                                                }
                                                            }
                                                        }



                                                    }

                                                }
                                            }
                                        }


                                    }

                                }

                            }
                        }


                        //else
                        //{
                        //    this.twoRinga[1]++;
                        //    Invalidate();
                        //}



                    }

                    else
                    {
                        this.twelveRingb[0]++;
                        Invalidate();
                    }

                    break;
                case Rings.TwentyFour:

                    if (this.twentyFourRingb[0] + 1 > twentyFourRingMax)
                    {
                        this.twentyFourRingb[0] = twentyFourRingMax;

                        if (twentyFourRingb[0] + 1 > twentyFourRingMax)
                        {
                            this.twentyFourRingb[1]++;
                            Invalidate();

                            if (twentyFourRingb[1] + 1 > twentyFourRingMax)
                            {

                                this.twentyFourRingb[2]++;
                                Invalidate();

                                if (twentyFourRingb[2] + 1 > twentyFourRingMax)
                                {

                                    this.twentyFourRingb[3]++;
                                    Invalidate();

                                    if (twentyFourRingb[3] + 1 > twentyFourRingMax)
                                    {
                                        this.twentyFourRingb[3] = twentyFourRingMax;
                                        this.twentyFourRingb[4]++;
                                        Invalidate();

                                        if (twentyFourRingb[4] + 1 > twentyFourRingMax)
                                        {
                                            this.twentyFourRingb[4] = twentyFourRingMax;
                                            this.twentyFourRingb[5]++;
                                            Invalidate();

                                            if (twentyFourRingb[5] + 1 > twentyFourRingMax)
                                            {
                                                this.twentyFourRingb[6]++;
                                                Invalidate();

                                                if (twentyFourRingb[6] + 1 > twentyFourRingMax)
                                                {
                                                    this.twentyFourRingb[7]++;
                                                    Invalidate();

                                                    if (twentyFourRingb[7] + 1 > twentyFourRingMax)
                                                    {
                                                        this.twentyFourRingb[8]++;
                                                        Invalidate();

                                                        if (twentyFourRingb[8] + 1 > twentyFourRingMax)
                                                        {
                                                            this.twentyFourRingb[9]++;
                                                            Invalidate();

                                                            if (twentyFourRingb[9] + 1 > twentyFourRingMax)
                                                            {
                                                                this.twentyFourRingb[10]++;
                                                                Invalidate();

                                                                if (twentyFourRingb[10] + 1 > twentyFourRingMax)
                                                                {
                                                                    this.twentyFourRingb[11]++;
                                                                    Invalidate();

                                                                    if (twentyFourRingb[11] + 1 > twentyFourRingMax)
                                                                    {
                                                                        this.twentyFourRingb[12]++;
                                                                        Invalidate();

                                                                        if (twentyFourRingb[12] + 1 > twentyFourRingMax)
                                                                        {
                                                                            this.twentyFourRingb[13]++;
                                                                            Invalidate();

                                                                            if (twentyFourRingb[13] + 1 > twentyFourRingMax)
                                                                            {

                                                                                this.twentyFourRingb[14]++;
                                                                                Invalidate();

                                                                                if (twentyFourRingb[14] + 1 > twentyFourRingMax)
                                                                                {

                                                                                    this.twentyFourRingb[15]++;
                                                                                    Invalidate();

                                                                                    if (twentyFourRingb[15] + 1 > twentyFourRingMax)
                                                                                    {

                                                                                        this.twentyFourRingb[16]++;
                                                                                        Invalidate();

                                                                                        if (twentyFourRingb[16] + 1 > twentyFourRingMax)
                                                                                        {

                                                                                            this.twentyFourRingb[17]++;
                                                                                            Invalidate();

                                                                                            if (twentyFourRingb[17] + 1 > twentyFourRingMax)
                                                                                            {
                                                                                                this.twentyFourRingb[18]++;
                                                                                                Invalidate();

                                                                                                if (twentyFourRingb[18] + 1 > twentyFourRingMax)
                                                                                                {
                                                                                                    this.twentyFourRingb[19]++;
                                                                                                    Invalidate();

                                                                                                    if (twentyFourRingb[19] + 1 > twentyFourRingMax)
                                                                                                    {
                                                                                                        this.twentyFourRingb[20]++;
                                                                                                        Invalidate();

                                                                                                        if (twentyFourRingb[20] + 1 > twentyFourRingMax)
                                                                                                        {
                                                                                                            this.twentyFourRingb[21]++;
                                                                                                            Invalidate();

                                                                                                            if (twentyFourRingb[21] + 1 > twentyFourRingMax)
                                                                                                            {
                                                                                                                this.twentyFourRingb[22]++;
                                                                                                                Invalidate();

                                                                                                                if (twentyFourRingb[22] + 1 > twentyFourRingMax)
                                                                                                                {
                                                                                                                    this.twentyFourRingb[23]++;
                                                                                                                    Invalidate();

                                                                                                                    if (twentyFourRingb[23] + 1 > twentyFourRingMax)
                                                                                                                    {
                                                                                                                        this.twentyFourRingb[0] = 0f;
                                                                                                                        this.twentyFourRingb[1] = 0f;
                                                                                                                        this.twentyFourRingb[2] = 0f;
                                                                                                                        this.twentyFourRingb[3] = 0f;
                                                                                                                        this.twentyFourRingb[4] = 0f;
                                                                                                                        this.twentyFourRingb[5] = 0f;
                                                                                                                        this.twentyFourRingb[6] = 0f;
                                                                                                                        this.twentyFourRingb[7] = 0f;
                                                                                                                        this.twentyFourRingb[8] = 0f;
                                                                                                                        this.twentyFourRingb[9] = 0f;
                                                                                                                        this.twentyFourRingb[10] = 0f;
                                                                                                                        this.twentyFourRingb[11] = 0f;
                                                                                                                        this.twentyFourRingb[12] = 0f;
                                                                                                                        this.twentyFourRingb[13] = 0f;
                                                                                                                        this.twentyFourRingb[14] = 0f;
                                                                                                                        this.twentyFourRingb[15] = 0f;
                                                                                                                        this.twentyFourRingb[16] = 0f;
                                                                                                                        this.twentyFourRingb[17] = 0f;
                                                                                                                        this.twentyFourRingb[18] = 0f;
                                                                                                                        this.twentyFourRingb[19] = 0f;
                                                                                                                        this.twentyFourRingb[20] = 0f;
                                                                                                                        this.twentyFourRingb[21] = 0f;
                                                                                                                        this.twentyFourRingb[22] = 0f;
                                                                                                                        this.twentyFourRingb[23] = 0f;


                                                                                                                        Invalidate();
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }



                                                                                                    }

                                                                                                }
                                                                                            }
                                                                                        }


                                                                                    }

                                                                                }

                                                                            }
                                                                        }


                                                                    }
                                                                }
                                                            }
                                                        }



                                                    }

                                                }
                                            }
                                        }


                                    }

                                }

                            }
                        }


                        //else
                        //{
                        //    this.twoRinga[1]++;
                        //    Invalidate();
                        //}



                    }

                    else
                    {
                        this.twentyFourRingb[0]++;
                        Invalidate();
                    }


                    break;
                default:
                    break;
            }


        }

        #endregion



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
                g.FillEllipse(new SolidBrush(Color.Blue), rect);
                g.DrawEllipse(new Pen(Color.Black, innerBorder), rect);
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

                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, oneRinga[0], oneRingb[0]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Two:

                    #region 2 rings

                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, twoRinga[1]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 90f, twoRingb[1]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Four:

                    #region 4 rings

                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, fourRingb[0]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 0f, fourRingb[1]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 90f, fourRingb[2]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 180f, fourRingb[3]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Eight:


                    #region 8 Rings
                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, eightRingb[0]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 315f, eightRingb[1]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 0f, eightRingb[2]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 45f, eightRingb[3]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 90f, eightRingb[4]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 135f, eightRingb[5]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 180f, eightRingb[6]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 225f, eightRingb[7]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Twelve:

                    #region 12 Rings
                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, twelveRingb[0]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 300f, twelveRingb[1]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 330f, twelveRingb[2]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);


                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 0f, twelveRingb[3]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 30f, twelveRingb[4]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 60f, twelveRingb[5]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);


                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 90f, twelveRingb[6]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 120f, twelveRingb[7]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 150f, twelveRingb[8]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);


                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 180f, twelveRingb[9]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 210f, twelveRingb[10]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 240f, twelveRingb[11]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.TwentyFour:

                    #region 24 Rings
                    g.FillPie(new SolidBrush(colors[0]), coloredRectangle, 270f, twentyFourRingb[0]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[1]), coloredRectangle, 285f, twentyFourRingb[1]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[2]), coloredRectangle, 300f, twentyFourRingb[2]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[3]), coloredRectangle, 315f, twentyFourRingb[3]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[4]), coloredRectangle, 330f, twentyFourRingb[4]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);

                    g.FillPie(new SolidBrush(colors[5]), coloredRectangle, 345f, twentyFourRingb[5]);
                    //g.DrawPie(new Pen(Color.Yellow, 2), coloredRectangle, 270f, 90f);



                    g.FillPie(new SolidBrush(colors[6]), coloredRectangle, 0f, twentyFourRingb[6]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[7]), coloredRectangle, 15f, twentyFourRingb[7]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[8]), coloredRectangle, 30f, twentyFourRingb[8]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[9]), coloredRectangle, 45f, twentyFourRingb[9]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[10]), coloredRectangle, 60f, twentyFourRingb[10]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);

                    g.FillPie(new SolidBrush(colors[11]), coloredRectangle, 75f, twentyFourRingb[11]);
                    //g.DrawPie(new Pen(Color.Red, 2), coloredRectangle, 0f, 90f);



                    g.FillPie(new SolidBrush(colors[12]), coloredRectangle, 90f, twentyFourRingb[12]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[13]), coloredRectangle, 105f, twentyFourRingb[13]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[14]), coloredRectangle, 120f, twentyFourRingb[14]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[15]), coloredRectangle, 135f, twentyFourRingb[15]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[16]), coloredRectangle, 150f, twentyFourRingb[16]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);

                    g.FillPie(new SolidBrush(colors[17]), coloredRectangle, 165f, twentyFourRingb[17]);
                    //g.DrawPie(new Pen(Color.Coral, 2), coloredRectangle, 90f, 90f);



                    g.FillPie(new SolidBrush(colors[18]), coloredRectangle, 180f, twentyFourRingb[18]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[19]), coloredRectangle, 195f, twentyFourRingb[19]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[20]), coloredRectangle, 210f, twentyFourRingb[20]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 

                    g.FillPie(new SolidBrush(colors[21]), coloredRectangle, 225f, twentyFourRingb[21]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[22]), coloredRectangle, 240f, twentyFourRingb[22]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f);

                    g.FillPie(new SolidBrush(colors[23]), coloredRectangle, 255f, twentyFourRingb[23]);
                    //g.DrawPie(new Pen(Color.BlueViolet, 2), coloredRectangle, 180f, 90f); 


                    g.FillEllipse(new SolidBrush(BackColor), rect);
                    //g.DrawEllipse(new Pen(BackColor, 1), rect);

                    #endregion

                    break;
                case Rings.Default:

                    g.FillPie(new SolidBrush(Color.Gray), coloredRectangle, 270f, 360f);
                    //g.DrawPie(new Pen(Color.Black, 2), coloredRectangle, 270f, 90f);


                    g.FillEllipse(new SolidBrush(Color.Transparent), rect);
                    g.DrawEllipse(new Pen(Color.Black, 2), rect);

                    break;
            }


        }



    }

}
