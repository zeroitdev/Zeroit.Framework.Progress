// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ZeroitRotatingCompass.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Rotating Compass

    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitRotatingCompass : UserControl
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
        /// Enum representing the Style
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
        /// The g
        /// </summary>
        Graphics g;
        #endregion

        #region Include in Private Field


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
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether automatically animate.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
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
            {

                this.angle = 0;
            }
            else
            {
                this.angle++;
                Invalidate();
            }

            if (pieSweepAngle + 1 > 360)
            {

                this.pieSweepAngle = 0;
            }
            else
            {
                this.pieSweepAngle++;
                Invalidate();
            }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRotatingCompass"/> class.
        /// </summary>
        public ZeroitRotatingCompass()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            if (AutoAnimate)
            {

                timer.Start();

            }


            timer.Tick += Timer_Tick;

        }

        #endregion

        #region Public Properties        
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
        /// Gets or sets a value indicating whether to fill the pie.
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
        /// Gets or sets a value indicating whether to show a rotating border.
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

            Text = "";

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;


            if (rotatingBorder)
            {
                e.Graphics.DrawPie(new Pen(Color.Blue), new Rectangle(0, 0, Width - 2, Height - 2), 180, pieSweepAngle);

                if (fillPie)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width - 2, Height - 2), pieColor1, pieColor2, pieSweepAngle);
                    e.Graphics.FillPie(brush, new Rectangle(0, 0, Width - 2, Height - 2), 180, pieSweepAngle);
                }

            }

            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);

            // Then to rotate, prepending rotation matrix.
            e.Graphics.RotateTransform(angle);

            #region Line
            // Draw rotated, translated ellipse to screen.
            e.Graphics.DrawRectangle(new Pen(lineWidthColor, 1), 0, 0, 1, (Width / 2));

            LinearGradientBrush brushfillrect = new LinearGradientBrush(new Rectangle(0, 0, 1, (Width / 2)), lineColor1, lineColor2, pieSweepAngle);

            e.Graphics.FillRectangle(brushfillrect, 0, 0, size, (Width / 2));
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
