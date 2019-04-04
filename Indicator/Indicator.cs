// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Indicator.cs" company="Zeroit Dev Technologies">
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
    #region Indicator Control

    /// <summary>
    /// a class collection for rendering progress bar indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitIndicator : UserControl
    {

        #region Private Fields
        /// <summary>
        /// The maximum
        /// </summary>
        Int32 _Maximum;
        /// <summary>
        /// The minimum
        /// </summary>
        Int32 _Minimum;
        /// <summary>
        /// The value
        /// </summary>
        Int32 _Value;
        /// <summary>
        /// The graph width
        /// </summary>
        Int32 _GraphWidth;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitIndicator" /> class.
        /// </summary>
        public ZeroitIndicator()
        {
            SetStyle(
                ControlStyles.UserPaint |
                //ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
                );
            _Maximum = Int32.MaxValue;
            _Minimum = 0;
            _Value = 0;
            _GraphWidth = 33;

            #region MyRegion
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

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="ArgumentException"></exception>
        public Int32 Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < this.Minimum)
                    throw new ArgumentException();
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="ArgumentException"></exception>
        public Int32 Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Int32 Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value < this.Minimum || value > this.Maximum)
                    throw new ArgumentOutOfRangeException();
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the graph.
        /// </summary>
        /// <value>The width of the graph.</value>
        public Int32 GraphWidth
        {
            get
            {
                return _GraphWidth;
            }
            set
            {
                _GraphWidth = value;
                Invalidate();
            }
        }

        #endregion

        #region Overrides

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000200; // WS_EX_CLIENTEDGE
        //        return cp;
        //    }
        //}


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graph = CreateGraphics();

            SolidBrush b = new SolidBrush(this.ForeColor);
            Int32 w = this.ClientSize.Width;
            Int32 h = this.ClientSize.Height;
            Int32 y = h;
            // draw text
            y -= this.Font.Height + 4;
            RectangleF r = new RectangleF(0, y, w, h);
            StringFormat f = new StringFormat(StringFormatFlags.NoWrap);
            f.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Text, this.Font, b, r, f);
            // draw graph
            Int32 graphheight = h - 6 - 4 - this.Font.Height - 4;
            graphheight += 1;
            Int32 lines = graphheight / 3;
            Byte red = (Byte)(this.ForeColor.R / 2);
            Byte green = (Byte)(this.ForeColor.G / 2);
            Byte blue = (Byte)(this.ForeColor.B / 2);
            Color dimmed = Color.FromArgb(red, green, blue);
            Pen dpen = new Pen(dimmed);
            Pen hpen = new Pen(this.ForeColor);
            dpen.DashStyle = DashStyle.Dot;
            Int32 lx = (w - this.GraphWidth) / 2;
            Int32 ly = h - 4 - this.Font.Height - 7;
            Int32 lw = this.GraphWidth / 2;
            Int32 x0 = lx;
            Int32 y0 = 0;
            Int32 x1 = 0;
            Int32 y1 = 0;
            Int32 linestohighlite = (Int32)System.Math.Ceiling(
                (this.Value - this.Minimum) * 1.0 /
                ((this.Maximum - this.Minimum * 1.0) / lines)
                );
            for (Int32 i = 0; i < lines; i++)
            {
                x0 = lx;
                y0 = ly - (i * 3) - 1;
                x1 = x0 + lw;
                y1 = y0;
                if (i < linestohighlite)
                {
                    e.Graphics.FillRectangle(b, x0, y0, lw, 2);
                    e.Graphics.FillRectangle(b, x1 + 1, y0, lw, 2);
                }
                else
                {
                    // left two lines
                    e.Graphics.DrawLine(dpen, x0, y0, x1, y1);
                    e.Graphics.DrawLine(dpen, x0 + 1, y0 + 1, x1, y1 + 1);
                    // right two lines
                    x0 = x1 + 1;
                    x1 = x0 + lw;
                    e.Graphics.DrawLine(dpen, x0, y0, x1, y1);
                    e.Graphics.DrawLine(dpen, x0 + 1, y0 + 1, x1, y1 + 1);
                }
            }
            hpen.Dispose();
            dpen.Dispose();
            b.Dispose();
        }


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
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
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
            if (this.Value + 1 > this.Maximum)
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





    }

    #endregion
}
