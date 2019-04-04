// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="KokonsaProgress Bar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class ZeroitKokonsaCircluar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKokonsaCircluar : Control
    {
        #region Values
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
        /// The outer radius
        /// </summary>
        int outerRadius;
        /// <summary>
        /// The inner radius
        /// </summary>
        int innerRadius;
        /// <summary>
        /// The stroke
        /// </summary>
        int stroke;
        /// <summary>
        /// The automatic font calculation
        /// </summary>
        bool automaticFontCalculation;
        /// <summary>
        /// The allow text
        /// </summary>
        bool allowText;
        /// <summary>
        /// The transparency
        /// </summary>
        bool transparency;
        /// <summary>
        /// The progress color
        /// </summary>
        Color progressColor;
        /// <summary>
        /// The brush
        /// </summary>
        SolidBrush brush;
        /// <summary>
        /// The timer
        /// </summary>
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        #endregion
        #region CircularPB
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKokonsaCircluar"/> class.
        /// </summary>
        public ZeroitKokonsaCircluar()
        {
            maxValue = 100;
            value = maxValue;
            minValue = 0;
            progressColor = Color.LightBlue;
            innerRadius = 30;
            outerRadius = 50;
            stroke = 10;
            MinimumSize = new System.Drawing.Size(60, 60);
            automaticFontCalculation = true;
            allowText = true;
            transparency = true;
            brush = new SolidBrush(progressColor);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            Location = new Point(100, 100);
            BackColor = Color.Transparent;
            timer.Tick += timer_Tick;
            timer.Interval = 1;
            timer.Enabled = true;
        }
        #endregion
        /// <summary>
        /// The old
        /// </summary>
        int old, current;
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
                if (current == old)
                    timer.Stop();
            }
        }
        #region Events
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            #region Transparency
            if (transparency && Parent != null)
            {
                Bitmap behind = new Bitmap(Parent.Width, Parent.Height);
                foreach (Control c in Parent.Controls)
                    if (c.Bounds.IntersectsWith(this.Bounds) & c != this)
                        c.DrawToBitmap(behind, c.Bounds);
                e.Graphics.DrawImage(behind, -Left, -Top);
                behind.Dispose();
            }
            #endregion
            #region DrawCircle
            float angle = (value * 360.0f / maxValue);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF outerRect = new RectangleF(0, 0, outerRadius * 2, outerRadius * 2);
            RectangleF innerRect = new RectangleF(outerRadius - innerRadius,
                                                  outerRadius - innerRadius, innerRadius * 2, innerRadius * 2);
            using (GraphicsPath progPath = new GraphicsPath())
            {
                progPath.AddArc(outerRect, angle - 90, -angle);
                if (allowText)
                {
                    progPath.AddArc(innerRect, -90, angle);
                }
                else
                {
                    progPath.AddLine(new Point(outerRadius, 0), new Point(outerRadius, outerRadius));
                }
                progPath.CloseFigure();
                e.Graphics.FillPath(brush, progPath);
            }


            #endregion
            #region DrawString
            if (!allowText) return;
            string text = "%" + (value * 100.0 / maxValue).ToString("0");
            Size textSize;
            float ratio = 1.0f;
            if (automaticFontCalculation)
            {
                string fullPercText = "%100";
                Size temp = TextRenderer.MeasureText(fullPercText, this.Font);
                float properWidth = innerRadius * 1.2f;
                ratio = properWidth / temp.Width;
            }
            Font font = new Font(Font.Name, Font.Height * ratio);
            textSize = TextRenderer.MeasureText(text, font);
            float x = (2 * outerRadius - textSize.Width) / 2f;
            float y = (2 * outerRadius - textSize.Height) / 2f;
            using (SolidBrush textBrush = new SolidBrush(ForeColor))
                e.Graphics.DrawString(text, font, textBrush, x + 1, y);
            #endregion
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            if (allowText && outerRadius - stroke <= 15)
            {
                stroke--;
                return;
            }
            base.OnResize(e);
            Height = Width;
            outerRadius = Width / 2 - 1;
            innerRadius = outerRadius - stroke;

            Invalidate();
        }

        #endregion
        #region Properties
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
                timer.Start();
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
                return progressColor;
            }
            set
            {
                progressColor = value;
                brush = new SolidBrush(progressColor);
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [automatic font calculation].
        /// </summary>
        /// <value><c>true</c> if [automatic font calculation]; otherwise, <c>false</c>.</value>
        public bool AutomaticFontCalculation
        {
            get
            {
                return automaticFontCalculation;
            }
            set
            {
                automaticFontCalculation = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the stroke.
        /// </summary>
        /// <value>The stroke.</value>
        public int Stroke
        {
            get
            {
                return stroke;
            }
            set
            {
                if (outerRadius - value >= 15)
                    stroke = value;
                innerRadius = outerRadius - stroke;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [allow text].
        /// </summary>
        /// <value><c>true</c> if [allow text]; otherwise, <c>false</c>.</value>
        public bool AllowText
        {
            get
            {
                return allowText;
            }
            set
            {
                allowText = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitKokonsaCircluar"/> is transparency.
        /// </summary>
        /// <value><c>true</c> if transparency; otherwise, <c>false</c>.</value>
        public bool Transparency
        {
            get
            {
                return transparency;
            }
            set
            {
                transparency = value;
                Invalidate();
            }
        }
        #endregion
    }
}
