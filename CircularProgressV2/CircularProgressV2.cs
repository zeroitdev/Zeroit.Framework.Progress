// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ZeroitCircularProgressV2.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitCircularProgressV2

    /// <summary>
    /// A class collection for rendering circular progressbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitCircularProgressV2 : Control
    {

        /// <summary>
        /// The progress width
        /// </summary>
        private int progressWidth = 2;
        /// <summary>
        /// The shift
        /// </summary>
        private int shift = 0;
        /// <summary>
        /// The value
        /// </summary>
        private int _value = 40;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum = 100;
        /// <summary>
        /// The remainder angle
        /// </summary>
        int remainderAngle = 0;
        /// <summary>
        /// The startangle
        /// </summary>
        int startangle = 80;

        /// <summary>
        /// The show text
        /// </summary>
        private bool showText = true;



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
        /// Gets or sets a value indicating whether to show text.
        /// </summary>
        /// <value><c>true</c> if show text; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return showText; }
            set
            {
                showText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically start the progress.
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

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public int StartAngle
        {
            get { return startangle; }
            set
            {
                startangle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > _maximum)
                {
                    value = _maximum;
                }

                _value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shift.
        /// </summary>
        /// <value>The shift.</value>
        /// <remarks>This is a little tweak to the progressbar</remarks>
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
        /// Gets or sets the width of the progress.
        /// </summary>
        /// <value>The width of the progress.</value>
        public int ProgressWidth
        {
            get { return progressWidth; }
            set
            {
                progressWidth = value;
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
            if (this.Value + 1 > this.Maximum)
            {
                this.Value = 0;
            }

            else
            {
                this.Value++;

                //Invalidate();
            }

            if (StartAngle + 1 > 300)
            {
                StartAngle = -60;
            }

            else
            {
                remainderAngle++;
                Invalidate();
            }


        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCircularProgressV2" /> class.
        /// </summary>
        public ZeroitCircularProgressV2()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            #region TimerUtility
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion
        }


        #region Public Methods

        #endregion


        #region Paint Events


        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
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

            Graphics g = e.Graphics;
            g.TextRenderingHint = textrendering;

            Rectangle rect = new Rectangle(shift, shift, Width - progressWidth, Height - progressWidth);

            float percentage = _value;

            //float progressAngle = Convert.ToSingle(360 / 100 * percentage);

            float progressAngle = Convert.ToSingle(360 * (percentage / _maximum));

            remainderAngle = 360 - Convert.ToInt32(progressAngle);

            //create pens to use for the arcs
            using (Pen progressPen = new Pen(Color.LightSeaGreen, progressWidth))
            {
                using (Pen remainderPen = new Pen(Color.LightGray, progressWidth))
                {
                    //set the smoothing to high quality for better output
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //draw the blue and white arcs
                    g.DrawArc(progressPen, rect, startangle, progressAngle);
                    g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle);
                }
            }

            //draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
            using (Font fnt = new Font(this.Font.FontFamily, 14))
            {

                string text = percentage.ToString() + "%";
                dynamic textSize = g.MeasureString(text, fnt);
                Point textPoint = new Point(Convert.ToInt32(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), Convert.ToInt32(rect.Top + (rect.Height / 2) - (textSize.Height / 2)));
                //now we have all the values draw the text

                if (showText)
                {
                    g.DrawString(text, Font, new SolidBrush(ForeColor), textPoint);
                }

                else
                {
                    g.DrawString(text, Font, new SolidBrush(Color.Transparent), textPoint);
                }

            }

            //Form2_Paint(e);
        }

        /// <summary>
        /// Form2s the paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Form2_Paint(PaintEventArgs e)
        {

            DrawProgress(e.Graphics, new Rectangle(shift, shift, Width - progressWidth, Height - progressWidth), 180);
            //DrawProgress(e.Graphics, new Rectangle(80, 5, 60, 60), 80);
            //DrawProgress(e.Graphics, new Rectangle(155, 5, 60, 60), 57);


        }

        /// <summary>
        /// Draws the progress.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="percentage">The percentage.</param>
        private void DrawProgress(Graphics g, Rectangle rect, float percentage)
        {
            //work out the angles for each arc
            float progressAngle = Convert.ToSingle(360 / 100 * percentage);
            int remainderAngle = 360 - Convert.ToInt32(progressAngle);

            //create pens to use for the arcs
            using (Pen progressPen = new Pen(Color.LightSeaGreen, progressWidth))
            {
                using (Pen remainderPen = new Pen(Color.LightGray, progressWidth))
                {
                    //set the smoothing to high quality for better output
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //draw the blue and white arcs
                    g.DrawArc(progressPen, rect, -60, progressAngle);
                    g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle);
                }
            }

            //draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
            using (Font fnt = new Font(this.Font.FontFamily, 14))
            {
                string text = percentage.ToString() + "%";
                dynamic textSize = g.MeasureString(text, fnt);
                Point textPoint = new Point(Convert.ToInt32(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), Convert.ToInt32(rect.Top + (rect.Height / 2) - (textSize.Height / 2)));
                //now we have all the values draw the text
                g.DrawString(text, fnt, Brushes.Black, textPoint);
            }
        }

        #endregion

    }

    #endregion
}
