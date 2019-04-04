// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ZeroitRotatingProgress.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Rotating Progress

    /// <summary>
    /// A class collection for rendering circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitRotatingProgress : UserControl
    {

        #region Private Fields
        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90f;
        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 10;
        /// <summary>
        /// The rotating border
        /// </summary>
        private bool rotatingBorder = false;

        /// <summary>
        /// Enum representing the rotating Style
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
        /// The shape
        /// </summary>
        private Style _shape = Style.Arc;
        /// <summary>
        /// The size
        /// </summary>
        private int size = 20;

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
        /// Gets or sets a value indicating whether to automatically animate.
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

        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRotatingProgress" /> class.
        /// </summary>
        public ZeroitRotatingProgress()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            timer.Tick += Timer_Tick;
            if (AutoAnimate)
            {

                timer.Start();
            }

            #region MyRegion
            //if (DesignMode)
            //{
            //    timer.Tick += Timer_Tick;
            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}

            //if (!DesignMode)
            //{
            //    timer.Tick += Timer_Tick;

            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}

            #endregion

        }

        #endregion

        #region Public Properties        
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
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>The size of the control.</value>
        public int ControlSize
        {
            get { return size; }
            set
            {
                size = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the Style.
        /// </summary>
        /// <value>The Style.</value>
        public Style Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the rotating border.
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
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                //Invalidate();
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

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            AutoSize = false;
            timer.Interval = interval;

            #region Old Code
            //// Set world transform of graphics object to rotate.
            //e.Graphics.RotateTransform(20f);

            //// Then to translate, prepending to world transform.
            //e.Graphics.TranslateTransform(100f, angle);

            //// Draw translated, rotated ellipse to screen.
            //e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), 0, 0, 200, 80);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), 0, 0, 200, 80);

            //e.Graphics.Dispose();

            //// Set world transform of graphics object to translate.
            //e.Graphics.TranslateTransform(100.0F, angle);

            //// Then to rotate, prepending rotation matrix.
            //e.Graphics.RotateTransform(30.0F);

            //// Draw rotated, translated ellipse to screen.
            //e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);

            // Optimize text quality. 
            #endregion

            Text = "";

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            #region Old Code
            // Move origin to center of form so we can rotate around that.
            //e.Graphics.TranslateTransform(this.Width / 2 - 30, this.Height / 2 - 30);

            //DrawText(e.Graphics);
            //e.Graphics.RotateTransform(angle + 100);
            //DrawText(e.Graphics);
            //e.Graphics.RotateTransform(angle + 20);
            //DrawText(e.Graphics);
            //e.Graphics.RotateTransform(angle + 50);
            //DrawText(e.Graphics); 
            #endregion

            if (rotatingBorder)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(0, 0, Width - 2, Height - 2));
            }

            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);

            // Then to rotate, prepending rotation matrix.
            e.Graphics.RotateTransform(angle);

            // Draw rotated, translated ellipse to screen.
            //e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), 0, 0, 1, (Width/3) + 20);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 0, (Width / 3) + 20);

            switch (_shape)
            {
                case Style.Pie:
                    e.Graphics.DrawPie(new Pen(Color.Black, 1), new Rectangle(0, 0, size, size), angle + 10, angle);

                    e.Graphics.DrawPie(new Pen(Color.Green, 1), new Rectangle(10, 10, size, size), angle + 10, angle);

                    e.Graphics.DrawPie(new Pen(Color.Brown, 1), new Rectangle(-10, 10, size, size), angle + 10, angle);

                    e.Graphics.DrawPie(new Pen(Color.Green, 1), new Rectangle(0, -10, size, size), angle + 10, angle);

                    e.Graphics.DrawPie(new Pen(Color.Blue, 1), new Rectangle(-10, -10, size, size), angle + 10, angle);

                    if (fillPie)
                    {
                        e.Graphics.FillPie(new SolidBrush(Color.Black), new Rectangle(0, 0, size, size), angle + 10, angle);
                        e.Graphics.FillPie(new SolidBrush(Color.Green), new Rectangle(10, 10, size, size), angle + 10, angle);
                        e.Graphics.FillPie(new SolidBrush(Color.Brown), new Rectangle(-10, 10, size, size), angle + 10, angle);
                        e.Graphics.FillPie(new SolidBrush(Color.Green), new Rectangle(0, -10, size, size), angle + 10, angle);
                        e.Graphics.FillPie(new SolidBrush(Color.Blue), new Rectangle(-10, -10, size, size), angle + 10, angle);

                    }


                    break;
                case Style.Arc:
                    e.Graphics.DrawArc(new Pen(Color.Black, 1), new Rectangle(0, 0, size, size), angle + 10, angle);
                    //e.Graphics.FillPie(new SolidBrush(Color.Transparent), new Rectangle(0, 0, 20, 20), angle + 10, angle);
                    e.Graphics.DrawArc(new Pen(Color.Green, 1), new Rectangle(10, 10, size, size), angle + 10, angle);
                    e.Graphics.DrawArc(new Pen(Color.Brown, 1), new Rectangle(-10, 10, size, size), angle + 10, angle);
                    e.Graphics.DrawArc(new Pen(Color.Green, 1), new Rectangle(0, -10, size, size), angle + 10, angle);

                    e.Graphics.DrawArc(new Pen(Color.Blue, 1), new Rectangle(-10, -10, size, size), angle + 10, angle);

                    break;
                default:
                    break;
            }


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
