// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="ZeroitKokonsaProgressBar.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class ZeroitKokonsaProgressBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKokonsaProgressBar : Control
    {
        /// <summary>
        /// The value
        /// </summary>
        int value;
        /// <summary>
        /// The maximum value
        /// </summary>
        int maxValue;
        /// <summary>
        /// The minimum value
        /// </summary>
        int minValue;
        /// <summary>
        /// The old
        /// </summary>
        int old, current;
        /// <summary>
        /// The pr color
        /// </summary>
        Color prColor;
        /// <summary>
        /// The timer
        /// </summary>
        System.Windows.Forms.Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKokonsaProgressBar"/> class.
        /// </summary>
        public ZeroitKokonsaProgressBar()
        {
            prColor = Color.LightBlue;
            maxValue = 100;
            minValue = 0;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Width = 100;
            Height = 20;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }
        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                int a = current - old;
                int k = maxValue / 100;
                int art = k < 1 ? 1 : k;
                old += System.Math.Abs(a) < 2 ? a : art * System.Math.Sign(a);
                this.value = old;
                Invalidate();
            }
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            int length = Width * value / maxValue;
            e.Graphics.DrawRectangle(Pens.Silver, 0, 0, Width - 1, Height - 1);
            using (SolidBrush brush = new SolidBrush(prColor))
                e.Graphics.FillRectangle(brush, 1, 1, length - 2, Height - 2);

            Size textSize = TextRenderer.MeasureText(value + "", this.Font);
            int x = (Width - textSize.Width) / 2;
            int y = (Height - textSize.Height) / 2;
            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
                e.Graphics.DrawString("%" + (value * 100 / maxValue), this.Font, textBrush, x, y);
            base.OnPaint(e);
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="System.Exception">
        /// The value is greater than the maximum value of progress
        /// or
        /// The value is lower than the maximum value of progress
        /// </exception>
        public int Value
        {
            get
            {
                return current;
            }
            set
            {
                old = this.value;
                if (value > maxValue)
                    throw new Exception("The value is greater than the maximum value of progress");
                if (value < minValue)
                    throw new Exception("The value is lower than the maximum value of progress");
                current = value;
            }
        }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get
            {
                return prColor;
            }
            set
            {
                prColor = value;
                Invalidate();
            }
        }
    }
}
