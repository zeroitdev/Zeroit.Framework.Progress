// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="ZeroitKokonsaSpinningCircles.cs" company="Zeroit Dev Technologies">
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
    /// Class ZeroitKokonsaSpinningCircles.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKokonsaSpinningCircles : Control
    {
        #region Private Fields
        /// <summary>
        /// The full transparency
        /// </summary>
        bool fullTransparency = true;
        /// <summary>
        /// The increment
        /// </summary>
        float increment = 1f;
        /// <summary>
        /// The radius
        /// </summary>
        float radius = 2.5f;
        /// <summary>
        /// The n
        /// </summary>
        int n = 8;
        /// <summary>
        /// The next
        /// </summary>
        int next = 0;
        /// <summary>
        /// The timer
        /// </summary>
        System.Windows.Forms.Timer timer;

        /// <summary>
        /// The fill color
        /// </summary>
        private Color fillColor = Color.Black;
        /// <summary>
        /// The circle border color
        /// </summary>
        private Color circleBorderColor = Color.White;
        /// <summary>
        /// The circle border width
        /// </summary>
        private float circleBorderWidth = 2;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the width of the circle border.
        /// </summary>
        /// <value>The width of the circle border.</value>
        public float CircleBorderWidth
        {
            get { return circleBorderWidth; }
            set
            {
                circleBorderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the circle fill.
        /// </summary>
        /// <value>The color of the circle fill.</value>
        public Color CircleFillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the circle border.
        /// </summary>
        /// <value>The color of the circle border.</value>
        public Color CircleBorderColor
        {
            get { return circleBorderColor; }
            set
            {
                circleBorderColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [full transparent].
        /// </summary>
        /// <value><c>true</c> if [full transparent]; otherwise, <c>false</c>.</value>
        public bool FullTransparent
        {
            get
            {
                return fullTransparency;
            }
            set
            {
                fullTransparency = value;
            }
        }
        /// <summary>
        /// Gets or sets the number of circles.
        /// </summary>
        /// <value>The number of circles.</value>
        public int NumberOfCircles
        {
            get
            {
                return n;
            }
            set
            {
                n = value >= 2 ? value : 2;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the increment.
        /// </summary>
        /// <value>The increment.</value>
        public float Increment
        {
            get
            {
                return increment;
            }
            set
            {
                increment = value >= 0 ? value : 0;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public float Radius
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

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKokonsaSpinningCircles"/> class.
        /// </summary>
        public ZeroitKokonsaSpinningCircles()
        {
            Width = 90;
            Height = 100;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += timer_Tick;
            timer.Enabled = false;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }
        #endregion

        #region Events, Overrides and Private Methods

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (fullTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int length = System.Math.Min(Width, Height);
            PointF center = new PointF(length / 2, length / 2);
            float bigRadius = length / 2 - radius - (n - 1) * increment;
            float unitAngle = 360 / n;
            next++;
            next = next >= n ? 0 : next;
            int a = 0;
            for (int i = next; i < next + n; i++)
            {
                int factor = i % n;
                float c1X = center.X + (float)(bigRadius * System.Math.Cos(unitAngle * factor * System.Math.PI / 180));
                float c1Y = center.Y + (float)(bigRadius * System.Math.Sin(unitAngle * factor * System.Math.PI / 180));
                float currRad = radius + a * increment;
                PointF c1 = new PointF(c1X - currRad, c1Y - currRad);
                e.Graphics.FillEllipse(new SolidBrush(CircleFillColor), c1.X, c1.Y, 2 * currRad, 2 * currRad);
                using (Pen pen = new Pen(CircleBorderColor, CircleBorderWidth))
                    e.Graphics.DrawEllipse(pen, c1.X, c1.Y, CircleBorderWidth * currRad, CircleBorderWidth * currRad);
                a++;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.VisibleChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            timer.Enabled = Visible;
            base.OnVisibleChanged(e);
        }


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


        #endregion


    }
}
