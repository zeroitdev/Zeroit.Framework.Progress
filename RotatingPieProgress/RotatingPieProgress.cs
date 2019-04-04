// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ZeroitRotatingPie.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Rotating ZeroitRotatingPie with HeartBeat

    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitRotatingPie : UserControl
    {

        #region Private Fields
        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90f;
        /// <summary>
        /// The pie sweep angle
        /// </summary>
        private float pieSweepAngle = 0f;
        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 10;
        /// <summary>
        /// The rotating border
        /// </summary>
        private bool rotatingBorder = false;

        /// <summary>
        /// Enum representing Style
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// The pie
            /// </summary>
            Pie,
            /// <summary>
            /// The arc
            /// </summary>
            Arc
        }
        /// <summary>
        /// The Style
        /// </summary>
        private Style _shape = Style.Arc;
        /// <summary>
        /// The size
        /// </summary>
        private int size = 1;

        /// <summary>
        /// The pie color1
        /// </summary>
        private Color pieColor1 = Color.Beige;
        /// <summary>
        /// The pie color2
        /// </summary>
        private Color pieColor2 = Color.Blue;

        /// <summary>
        /// The line color1
        /// </summary>
        private Color lineColor1 = Color.Yellow;
        /// <summary>
        /// The line color2
        /// </summary>
        private Color lineColor2 = Color.Blue;

        /// <summary>
        /// The line width color
        /// </summary>
        private Color lineWidthColor = Color.Transparent;

        /// <summary>
        /// The fill pie
        /// </summary>
        private bool fillPie = false;
        /// <summary>
        /// The draw line
        /// </summary>
        private bool drawLine = true;

        /// <summary>
        /// The width reduction
        /// </summary>
        private int widthReduction = 10;
        /// <summary>
        /// The height reduction
        /// </summary>
        private int heightReduction = 10;

        /// <summary>
        /// The g
        /// </summary>
        Graphics g;

        /// <summary>
        /// The color outer border
        /// </summary>
        private Color colorOuterBorder = Color.Blue;
        /// <summary>
        /// The inner circle1 grad1
        /// </summary>
        private Color innerCircle1Grad1 = Color.Red;
        /// <summary>
        /// The inner circle1 grad2
        /// </summary>
        private Color innerCircle1Grad2 = Color.Green;

        /// <summary>
        /// The inner circle2 grad1
        /// </summary>
        private Color innerCircle2Grad1 = Color.Yellow;
        /// <summary>
        /// The inner circle2 grad2
        /// </summary>
        private Color innerCircle2Grad2 = Color.Blue;

        /// <summary>
        /// The inner circle3 grad1
        /// </summary>
        private Color innerCircle3Grad1 = Color.Brown;
        /// <summary>
        /// The inner circle3 grad2
        /// </summary>
        private Color innerCircle3Grad2 = Color.Gray;

        /// <summary>
        /// The inner circle4 grad1
        /// </summary>
        private Color innerCircle4Grad1 = Color.RosyBrown;
        /// <summary>
        /// The inner circle4 grad2
        /// </summary>
        private Color innerCircle4Grad2 = Color.LightBlue;

        /// <summary>
        /// The inner circle5 grad1
        /// </summary>
        private Color innerCircle5Grad1 = Color.Violet;
        /// <summary>
        /// The inner circle5 grad2
        /// </summary>
        private Color innerCircle5Grad2 = Color.LightPink;

        /// <summary>
        /// The inner circle6 grad1
        /// </summary>
        private Color innerCircle6Grad1 = SystemColors.Control;
        /// <summary>
        /// The inner circle6 grad2
        /// </summary>
        private Color innerCircle6Grad2 = SystemColors.Control;

        /// <summary>
        /// The show inner circle1
        /// </summary>
        private bool showInnerCircle1 = true;
        /// <summary>
        /// The show inner circle2
        /// </summary>
        private bool showInnerCircle2 = true;
        /// <summary>
        /// The show inner circle3
        /// </summary>
        private bool showInnerCircle3 = true;
        /// <summary>
        /// The show inner circle4
        /// </summary>
        private bool showInnerCircle4 = true;
        /// <summary>
        /// The show inner circle5
        /// </summary>
        private bool showInnerCircle5 = true;
        /// <summary>
        /// The show inner circle6
        /// </summary>
        private bool showInnerCircle6 = true;

        /// <summary>
        /// The outer border width
        /// </summary>
        private int outerBorderWidth = 1;

        /// <summary>
        /// The innercircle border
        /// </summary>
        private int innercircleBorder = 10;

        /// <summary>
        /// The innercircle2 width
        /// </summary>
        private int innercircle2Width = 20;
        /// <summary>
        /// The innercircle2 height
        /// </summary>
        private int innercircle2Height = 20;

        /// <summary>
        /// The innercircle3 width
        /// </summary>
        private int innercircle3Width = 40;
        /// <summary>
        /// The innercircle3 height
        /// </summary>
        private int innercircle3Height = 40;

        /// <summary>
        /// The innercircle4 width
        /// </summary>
        private int innercircle4Width = 60;
        /// <summary>
        /// The innercircle4 height
        /// </summary>
        private int innercircle4Height = 60;

        /// <summary>
        /// The innercircle5 width
        /// </summary>
        private int innercircle5Width = 80;
        /// <summary>
        /// The innercircle5 height
        /// </summary>
        private int innercircle5Height = 80;

        /// <summary>
        /// The innercircle6 width
        /// </summary>
        private int innercircle6Width = 100;
        /// <summary>
        /// The innercircle6 height
        /// </summary>
        private int innercircle6Height = 100;

        /// <summary>
        /// The pie limit
        /// </summary>
        private float pieLimit = 360f;


        #endregion

        #region Timer Utility

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The hearbeat animate
        /// </summary>
        private bool hearbeatAnimate = true;
        /// <summary>
        /// The heart timer
        /// </summary>
        private System.Windows.Forms.Timer heartTimer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

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

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;


                #region Old Code
                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }
                #endregion


                //Invalidate();
            }
        }


        /// <summary>
        /// The heartinterval
        /// </summary>
        int heartinterval = 100;
        /// <summary>
        /// Gets or sets the heart timer interval.
        /// </summary>
        /// <value>The heart timer interval.</value>
        public int HeartTimerInterval
        {
            get { return heartinterval; }
            set
            {
                heartinterval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The heart automatic animate
        /// </summary>
        private bool heartAutoAnimate = true;
        /// <summary>
        /// Gets or sets a value indicating whether [heart automatic animate].
        /// </summary>
        /// <value><c>true</c> if [heart automatic animate]; otherwise, <c>false</c>.</value>
        public bool HeartAutoAnimate
        {
            get { return heartAutoAnimate; }
            set
            {
                heartAutoAnimate = value;


                #region Old Code
                if (value == true)
                {
                    heartTimer.Enabled = true;
                }

                else
                {
                    heartTimer.Enabled = false;
                }
                #endregion


                //Invalidate();
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
            if (this.angle + 1 > pieLimit)
            {

                this.angle = 0;
            }
            else
            {
                this.angle++;
                Invalidate();
            }

            if (pieSweepAngle + 1 > pieLimit)
            {

                this.pieSweepAngle = 0;
            }
            else
            {
                this.pieSweepAngle++;
                Invalidate();
            }

            //if (innercircleBorder + 1 > 10)
            //{

            //    this.innercircleBorder = 1;
            //}
            //else
            //{
            //    this.innercircleBorder++;
            //    Invalidate();
            //}

        }

        /// <summary>
        /// Handles the Tick event of the HeartTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HeartTimer_Tick(object sender, EventArgs e)
        {

            if (innercircleBorder + 1 > 10)
            {

                this.innercircleBorder = 1;
            }
            else
            {
                this.innercircleBorder++;
                Invalidate();
            }

        }

        #endregion

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRotatingPie" /> class.
        /// </summary>
        public ZeroitRotatingPie()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            if (AutoAnimate)
            {

                timer.Start();

            }

            if (HeartAutoAnimate)
            {

                heartTimer.Start();

            }


            timer.Tick += Timer_Tick;

            heartTimer.Tick += HeartTimer_Tick;

        }

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public float StartAngle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pie sweep angle.
        /// </summary>
        /// <value>The pie sweep angle.</value>
        public float PieSweepAngle
        {
            get { return pieSweepAngle; }
            set
            {
                pieSweepAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pie limit.
        /// </summary>
        /// <value>The pie limit.</value>
        public float PieLimit
        {
            get { return pieLimit; }
            set
            {
                pieLimit = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle1 width reduction.</value>
        public int Innercircle1WidthReduction
        {
            get { return widthReduction; }
            set
            {
                widthReduction = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle1 height reduction.</value>
        public int Innercircle1HeightReduction
        {
            get { return heightReduction; }
            set
            {
                heightReduction = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show line.
        /// </summary>
        /// <value><c>true</c> if show line; otherwise, <c>false</c>.</value>
        public bool ShowLine
        {
            get { return drawLine; }
            set
            {
                drawLine = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pie color.
        /// </summary>
        /// <value>The pie color1.</value>
        public Color PieColor1
        {
            get { return pieColor1; }
            set
            {
                pieColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pie color.
        /// </summary>
        /// <value>The pie color2.</value>
        public Color PieColor2
        {
            get { return pieColor2; }
            set
            {
                pieColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the line color.
        /// </summary>
        /// <value>The line color1.</value>
        public Color LineColor1
        {
            get { return lineColor1; }
            set
            {
                pieColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the line color.
        /// </summary>
        /// <value>The line color2.</value>
        public Color LineColor2
        {
            get { return lineColor2; }
            set
            {
                lineColor2 = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether to fill pie.
        /// </summary>
        /// <value><c>true</c> if fill pie; otherwise, <c>false</c>.</value>
        public bool FillPie
        {
            get { return fillPie; }
            set
            {
                fillPie = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the line.
        /// </summary>
        /// <value>The size of the line.</value>
        public int LineSize
        {
            get { return size; }
            set
            {
                size = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show rotating border.
        /// </summary>
        /// <value><c>true</c> if rotating border; otherwise, <c>false</c>.</value>
        public bool RotatingBorder
        {
            get { return rotatingBorder; }
            set
            {
                rotatingBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        [Browsable(false)]
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                //Invalidate();
            }
        }


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

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
        /// Gets or sets the inner circle border.
        /// </summary>
        /// <value>The inner circle border.</value>
        public int InnerCircleBorder
        {
            get { return innercircleBorder; }
            set
            {
                innercircleBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle2 width reduction.</value>
        public int Innercircle2WidthReduction
        {
            get { return innercircle2Width; }
            set
            {
                innercircle2Width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle2 height reduction.</value>
        public int Innercircle2HeightReduction
        {
            get { return innercircle2Height; }
            set
            {
                innercircle2Height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle3 width reduction.</value>
        public int Innercircle3WidthReduction
        {
            get { return innercircle3Width; }
            set
            {
                innercircle3Width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle3 height reduction.</value>
        public int Innercircle3HeightReduction
        {
            get { return innercircle3Height; }
            set
            {
                innercircle3Height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle4 width reduction.</value>
        public int Innercircle4WidthReduction
        {
            get { return innercircle4Width; }
            set
            {
                innercircle4Width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle4 height reduction.</value>
        public int Innercircle4HeightReduction
        {
            get { return innercircle4Height; }
            set
            {
                innercircle4Height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle5 width reduction.</value>
        public int Innercircle5WidthReduction
        {
            get { return innercircle5Width; }
            set
            {
                innercircle5Width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle5 height reduction.</value>
        public int Innercircle5HeightReduction
        {
            get { return innercircle5Height; }
            set
            {
                innercircle5Height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle width reduction.
        /// </summary>
        /// <value>The innercircle6 width reduction.</value>
        public int Innercircle6WidthReduction
        {
            get { return innercircle6Width; }
            set
            {
                innercircle6Width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the innercircle height reduction.
        /// </summary>
        /// <value>The innercircle6 height reduction.</value>
        public int Innercircle6HeightReduction
        {
            get { return innercircle6Height; }
            set
            {
                innercircle6Height = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show inner circle1.
        /// </summary>
        /// <value><c>true</c> if show inner circle1; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle1
        {
            get
            {
                return showInnerCircle1;
            }

            set
            {
                showInnerCircle1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle1 gradient color1 .
        /// </summary>
        /// <value>The inner circle1 gradient color1.</value>
        public Color ColorInnerCircle1Grad1
        {
            get { return innerCircle1Grad1; }
            set
            {
                innerCircle1Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle1 gradient color2 .
        /// </summary>
        /// <value>The inner circle1 gradient color2.</value>
        public Color ColorInnerCircle1Grad2
        {
            get { return innerCircle1Grad2; }
            set
            {
                innerCircle1Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show inner circle2.
        /// </summary>
        /// <value><c>true</c> if show inner circle2; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle2
        {
            get
            {
                return showInnerCircle2;
            }

            set
            {
                showInnerCircle2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle2 gradient color1 .
        /// </summary>
        /// <value>The inner circle2 gradient color1.</value>
        public Color ColorInnerCircle2Grad1
        {
            get { return innerCircle2Grad1; }
            set
            {
                innerCircle2Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle2 gradient color2 .
        /// </summary>
        /// <value>The inner circle2 gradient color2.</value>
        public Color ColorInnerCircle2Grad2
        {
            get { return innerCircle2Grad2; }
            set
            {
                innerCircle2Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show inner circle3.
        /// </summary>
        /// <value><c>true</c> if show inner circle3; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle3
        {
            get
            {
                return showInnerCircle3;
            }

            set
            {
                showInnerCircle3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle3 gradient color1 .
        /// </summary>
        /// <value>The inner circle3 gradient color1.</value>
        public Color ColorInnerCircle3Grad1
        {
            get { return innerCircle3Grad1; }
            set
            {
                innerCircle3Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle3 gradient color2 .
        /// </summary>
        /// <value>The inner circle3 gradient color2.</value>
        public Color ColorInnerCircle3Grad2
        {
            get { return innerCircle3Grad2; }
            set
            {
                innerCircle3Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether show inner circle4.
        /// </summary>
        /// <value><c>true</c> if show inner circle4; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle4
        {
            get
            {
                return showInnerCircle4;
            }

            set
            {
                showInnerCircle4 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle4 gradient color1 .
        /// </summary>
        /// <value>The inner circle4 gradient color1.</value>
        public Color ColorInnerCircle4Grad1
        {
            get { return innerCircle4Grad1; }
            set
            {
                innerCircle4Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle4 gradient color2 .
        /// </summary>
        /// <value>The inner circle4 gradient color2.</value>
        public Color ColorInnerCircle4Grad2
        {
            get { return innerCircle4Grad2; }
            set
            {
                innerCircle4Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show inner circle5.
        /// </summary>
        /// <value><c>true</c> if show inner circle5; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle5
        {
            get
            {
                return showInnerCircle5;
            }

            set
            {
                showInnerCircle5 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle5 gradient color1 .
        /// </summary>
        /// <value>The inner circle5 gradient color1.</value>
        public Color ColorInnerCircle5Grad1
        {
            get { return innerCircle5Grad1; }
            set
            {
                innerCircle5Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle5 gradient color2 .
        /// </summary>
        /// <value>The inner circle5 gradient color2.</value>
        public Color ColorInnerCircle5Grad2
        {
            get { return innerCircle5Grad2; }
            set
            {
                innerCircle5Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show inner circle6.
        /// </summary>
        /// <value><c>true</c> if show inner circle6; otherwise, <c>false</c>.</value>
        public bool ShowInnerCircle6
        {
            get
            {
                return showInnerCircle6;
            }

            set
            {
                showInnerCircle6 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle6 gradient color1 .
        /// </summary>
        /// <value>The inner circle6 gradient color1.</value>
        public Color ColorInnerCircle6Grad1
        {
            get { return innerCircle6Grad1; }
            set
            {
                innerCircle6Grad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle6 gradient color2 .
        /// </summary>
        /// <value>The inner circle6 gradient color2.</value>
        public Color ColorInnerCircle6Grad2
        {
            get { return innerCircle6Grad2; }
            set
            {
                innerCircle6Grad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border color.
        /// </summary>
        /// <value>The outer border color.</value>
        public Color ColorOuterBorder
        {
            get { return colorOuterBorder; }
            set
            {
                colorOuterBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the outer border.
        /// </summary>
        /// <value>The width of the outer border.</value>
        private int OuterBorderWidth
        {
            get { return outerBorderWidth; }
            set
            {
                outerBorderWidth = value;
                Invalidate();
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = smoothing;

            timer.Interval = interval;
            heartTimer.Interval = heartinterval;

            //Text = "";

            //e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;



            if (rotatingBorder)
            {
                e.Graphics.DrawPie(new Pen(colorOuterBorder, outerBorderWidth), new Rectangle(0, 0, Width - 2, Height - 2), 180, pieSweepAngle);

                if (fillPie)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width - 2, Height - 2), pieColor1, pieColor2, pieSweepAngle);

                    e.Graphics.FillPie(brush, new Rectangle(0, 0, Width - 2, Height - 2), 180, pieSweepAngle);
                }

            }


            #region DrawInnerCircles 

            if (showInnerCircle1)
            {
                LinearGradientBrush innercircle1brush = new LinearGradientBrush(new Rectangle(widthReduction, heightReduction, Width - (2 * widthReduction), Height - (2 * heightReduction)), innerCircle1Grad1, innerCircle1Grad2, pieSweepAngle);

                e.Graphics.FillPie(innercircle1brush, new Rectangle(widthReduction, heightReduction, Width - (2 * widthReduction), Height - (2 * heightReduction)), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, innercircleBorder), new Rectangle(widthReduction, heightReduction, Width - (2 * widthReduction), Height - (2 * heightReduction)), 180, pieSweepAngle);

            }

            if (showInnerCircle2)
            {
                LinearGradientBrush innercircle2brush = new LinearGradientBrush(new Rectangle(widthReduction + innercircle2Width, heightReduction + innercircle2Height, Width - (2 * (widthReduction + innercircle2Width)), Height - (2 * (heightReduction + innercircle2Height))), innerCircle2Grad1, innerCircle2Grad2, pieSweepAngle);

                e.Graphics.FillPie(innercircle2brush, new Rectangle(widthReduction + innercircle2Width, heightReduction + innercircle2Height, Width - (2 * (widthReduction + innercircle2Width)), Height - (2 * (heightReduction + innercircle2Height))), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, innercircleBorder), new Rectangle(widthReduction + innercircle2Width, heightReduction + innercircle2Height, Width - (2 * (widthReduction + innercircle2Width)), Height - (2 * (heightReduction + innercircle2Height))), 180, pieSweepAngle);

            }

            if (showInnerCircle3)
            {
                LinearGradientBrush innercircle3brush = new LinearGradientBrush(new Rectangle(widthReduction + innercircle3Width, heightReduction + innercircle3Height, Width - (2 * (widthReduction + innercircle3Width)), Height - (2 * (heightReduction + innercircle3Height))), innerCircle3Grad1, innerCircle3Grad2, pieSweepAngle);

                e.Graphics.FillPie(innercircle3brush, new Rectangle(widthReduction + innercircle3Width, heightReduction + innercircle3Height, Width - (2 * (widthReduction + innercircle3Width)), Height - (2 * (heightReduction + innercircle3Height))), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, innercircleBorder), new Rectangle(widthReduction + innercircle3Width, heightReduction + innercircle3Height, Width - (2 * (widthReduction + innercircle3Width)), Height - (2 * (heightReduction + innercircle3Height))), 180, pieSweepAngle);
            }


            if (showInnerCircle4)
            {
                LinearGradientBrush innercircle4brush = new LinearGradientBrush(new Rectangle(widthReduction + innercircle4Width, heightReduction + innercircle4Height, Width - (2 * (widthReduction + innercircle4Width)), Height - (2 * (heightReduction + innercircle4Height))), Color.RosyBrown, Color.LightBlue, pieSweepAngle);

                e.Graphics.FillPie(innercircle4brush, new Rectangle(widthReduction + innercircle4Width, heightReduction + innercircle4Height, Width - (2 * (widthReduction + innercircle4Width)), Height - (2 * (heightReduction + innercircle4Height))), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, innercircleBorder), new Rectangle(widthReduction + innercircle4Width, heightReduction + innercircle4Height, Width - (2 * (widthReduction + innercircle4Width)), Height - (2 * (heightReduction + innercircle4Height))), 180, pieSweepAngle);
            }

            if (showInnerCircle5)
            {

                LinearGradientBrush innercircle5brush = new LinearGradientBrush(new Rectangle(widthReduction + innercircle5Width, heightReduction + innercircle5Height, Width - (2 * (widthReduction + innercircle5Width)), Height - (2 * (heightReduction + 80))), Color.Violet, Color.LightPink, pieSweepAngle);

                e.Graphics.FillPie(innercircle5brush, new Rectangle(widthReduction + innercircle5Width, heightReduction + innercircle5Height, Width - (2 * (widthReduction + innercircle5Width)), Height - (2 * (heightReduction + innercircle5Height))), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, innercircleBorder), new Rectangle(widthReduction + innercircle5Width, heightReduction + innercircle5Height, Width - (2 * (widthReduction + innercircle5Width)), Height - (2 * (heightReduction + innercircle5Height))), 180, pieSweepAngle);
            }

            if (showInnerCircle6)
            {
                LinearGradientBrush innercircle6brush = new LinearGradientBrush(new Rectangle(widthReduction + innercircle6Width, heightReduction + innercircle6Height, Width - (2 * (widthReduction + innercircle6Width)), Height - (2 * (heightReduction + 100))), Parent.BackColor, Parent.BackColor, pieSweepAngle);

                e.Graphics.FillPie(innercircle6brush, new Rectangle(widthReduction + innercircle6Width, heightReduction + innercircle6Height, Width - (2 * (widthReduction + innercircle6Width)), Height - (2 * (heightReduction + innercircle6Height))), 180, pieSweepAngle);
                e.Graphics.DrawPie(new Pen(Parent.BackColor, 10), new Rectangle(widthReduction + innercircle6Width, heightReduction + innercircle6Height, Width - (2 * (widthReduction + innercircle6Width)), Height - (2 * (heightReduction + innercircle6Height))), 180, pieSweepAngle);
            }
            #endregion

            //e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);

            // Then to rotate, prepending rotation matrix.
            //e.Graphics.RotateTransform(angle);

            #region Line
            //if (drawLine)
            //{
            //    // Draw rotated, translated ellipse to screen.
            //    e.Graphics.DrawRectangle(new Pen(lineWidthColor, 1), 0, 0, 1, (Width / 2));

            //    LinearGradientBrush brushfillrect = new LinearGradientBrush(new Rectangle(0, 0, 1, (Width / 2)), lineColor1, lineColor2, pieSweepAngle);

            //    e.Graphics.FillRectangle(brushfillrect, 0, 0, size, (Width / 2));
            //}


            #endregion

            #region Old Code
            //switch (_shape)
            //{
            //    case Style.Pie:
            //        e.Graphics.DrawPie(new Pen(Color.Black, 1), new Rectangle(0, 0, size, size), angle + 10, angle);

            //        e.Graphics.DrawPie(new Pen(Color.Green, 1), new Rectangle(10, 10, size, size), angle + 10, angle);

            //        e.Graphics.DrawPie(new Pen(Color.Brown, 1), new Rectangle(-10, 10, size, size), angle + 10, angle);

            //        e.Graphics.DrawPie(new Pen(Color.Green, 1), new Rectangle(0, -10, size, size), angle + 10, angle);

            //        e.Graphics.DrawPie(new Pen(Color.Blue, 1), new Rectangle(-10, -10, size, size), angle + 10, angle);

            //        if (fillPie)
            //        {
            //            e.Graphics.FillPie(new SolidBrush(Color.Black), new Rectangle(0, 0, size, size), angle + 10, angle);
            //            e.Graphics.FillPie(new SolidBrush(Color.Green), new Rectangle(10, 10, size, size), angle + 10, angle);
            //            e.Graphics.FillPie(new SolidBrush(Color.Brown), new Rectangle(-10, 10, size, size), angle + 10, angle);
            //            e.Graphics.FillPie(new SolidBrush(Color.Green), new Rectangle(0, -10, size, size), angle + 10, angle);
            //            e.Graphics.FillPie(new SolidBrush(Color.Blue), new Rectangle(-10, -10, size, size), angle + 10, angle);

            //        }


            //        break;
            //    case Style.Arc:
            //        e.Graphics.DrawArc(new Pen(Color.Black, 1), new Rectangle(0, 0, size, size), angle + 10, angle);
            //        //e.Graphics.FillPie(new SolidBrush(Color.Transparent), new Rectangle(0, 0, 20, 20), angle + 10, angle);
            //        e.Graphics.DrawArc(new Pen(Color.Green, 1), new Rectangle(10, 10, size, size), angle + 10, angle);
            //        e.Graphics.DrawArc(new Pen(Color.Brown, 1), new Rectangle(-10, 10, size, size), angle + 10, angle);
            //        e.Graphics.DrawArc(new Pen(Color.Green, 1), new Rectangle(0, -10, size, size), angle + 10, angle);

            //        e.Graphics.DrawArc(new Pen(Color.Blue, 1), new Rectangle(-10, -10, size, size), angle + 10, angle);

            //        break;
            //    default:
            //        break;
            //} 
            #endregion

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawText(Graphics g)
        {
            g.DrawString("Text", new Font("Verdana", 30, FontStyle.Bold),
                Brushes.Black, 0, 10);
        }
        #endregion


    }

    #endregion

}
