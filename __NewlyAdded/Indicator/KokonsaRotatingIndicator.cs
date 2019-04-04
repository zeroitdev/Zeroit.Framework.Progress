// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="ZeroitKokonsaRotatingIndicator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class ZeroitKokonsaRotatingIndicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKokonsaRotatingIndicator : Control
    {
        #region Variables
        /// <summary>
        /// The n
        /// </summary>
        int n, circleIndex, radius, interval;
        /// <summary>
        /// The spin
        /// </summary>
        bool spin;
        /// <summary>
        /// The timer
        /// </summary>
        System.Windows.Forms.Timer timer;
        /// <summary>
        /// The other
        /// </summary>
        Color other, index;
        #endregion
        #region ProcessingControl
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKokonsaRotatingIndicator"/> class.
        /// </summary>
        public ZeroitKokonsaRotatingIndicator()
        {
            Width = 85;
            Height = 85;
            n = 6;
            circleIndex = 0;
            interval = 100;
            radius = 10;
            spin = true;
            other = Color.LightGray;
            index = Color.Gray;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = interval;
            timer.Tick += timer_Tick;
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            timer.Enabled = spin;
            BackColor = Color.Transparent;
        }
        #endregion
        #region Events


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if(AllowTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }
            

            #region Drawing
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int length = System.Math.Min(Width, Height);
            PointF center = new PointF(length / 2, length / 2);
            int bigRadius = length / 2 - radius;
            float unitAngle = 360 / n;
            if (spin)
            {
                circleIndex++;
                circleIndex = circleIndex >= n ? circleIndex % n : circleIndex;
            }
            for (int i = 0; i < n; i++)
            {
                float c1X = center.X + (float)(bigRadius * System.Math.Cos(unitAngle * i * System.Math.PI / 180));
                float c1Y = center.Y + (float)(bigRadius * System.Math.Sin(unitAngle * i * System.Math.PI / 180));
                PointF loc1 = new PointF(c1X - radius, c1Y - radius);
                if (i == circleIndex)
                    using (SolidBrush brush = new SolidBrush(index))
                        e.Graphics.FillEllipse(brush, loc1.X, loc1.Y, 2 * radius, 2 * radius);
                else
                    using (SolidBrush brush = new SolidBrush(other))
                        e.Graphics.FillEllipse(brush, loc1.X, loc1.Y, 2 * radius, 2 * radius);
            }
            #endregion
        }
        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (!spin) timer.Stop();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the n circle.
        /// </summary>
        /// <value>The n circle.</value>
        public int NCircle
        {
            get
            {
                return n;
            }
            set
            {
                n = value > 1 ? value : 2;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value >= 1 ? value : 1;
                timer.Interval = interval;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitKokonsaRotatingIndicator"/> is spin.
        /// </summary>
        /// <value><c>true</c> if spin; otherwise, <c>false</c>.</value>
        public bool Spin
        {
            get
            {
                return spin;
            }
            set
            {
                spin = value;
                timer.Enabled = spin;
            }
        }
        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value >= 1 ? value : 1;
                Invalidate();

            }
        }
        /// <summary>
        /// Gets or sets the others.
        /// </summary>
        /// <value>The others.</value>
        public Color Others
        {
            get
            {
                return other;
            }
            set
            {
                other = value;
                if (!spin) Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the color of the index.
        /// </summary>
        /// <value>The color of the index.</value>
        public Color IndexColor
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                if (!spin) Invalidate();
            }
        }

        #endregion





        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion



    }
}
