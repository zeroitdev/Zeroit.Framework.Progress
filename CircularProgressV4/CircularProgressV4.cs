// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ZeroitCircularProgressV4.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region CircularProgressv4

    /// <summary>
    /// A class collection for rendering a circular progressbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitCircularProgressV4 : Control
    {

        #region Private Fields
        /// <summary>
        /// The start angle
        /// </summary>
        private int startAngle = -90;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The thickness
        /// </summary>
        private int _Thickness = 20;
        /// <summary>
        /// The grad angle
        /// </summary>
        private float gradAngle = 90f;

        /// <summary>
        /// The start cap
        /// </summary>
        private LineCap startCap = LineCap.Round;
        /// <summary>
        /// The end cap
        /// </summary>
        private LineCap endCap = LineCap.Round;
        /// <summary>
        /// The inner border
        /// </summary>
        private Color innerBorder = Color.Black;
        /// <summary>
        /// The outer border
        /// </summary>
        private Color outerBorder = Color.Black;

        /// <summary>
        /// The prog grad1
        /// </summary>
        private Color progGrad1 = Color.DarkSlateGray;
        /// <summary>
        /// The prog grad2
        /// </summary>
        private Color progGrad2 = Color.Orange;

        /// <summary>
        /// The prog back grad1
        /// </summary>
        private Color progBackGrad1 = Color.White;
        /// <summary>
        /// The prog back grad2
        /// </summary>
        private Color progBackGrad2 = Color.White;

        /// <summary>
        /// The speed
        /// </summary>
        private int speed = 100;



        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCircularProgressV4" /> class.
        /// </summary>
        public ZeroitCircularProgressV4()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(150, 150);
            Font = new Font("Verdana", 14f);

            ForeColor = Color.White;

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

        #region Public Properties

        /// <summary>
        /// Gets or sets the speed.
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
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get { return gradAngle; }
            set
            {
                gradAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress background color using gradient.
        /// </summary>
        /// <value>The progress background gradient color1.</value>
        public Color ProgressBackGrad1
        {
            get { return progBackGrad1; }
            set
            {
                progBackGrad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress background color using gradient.
        /// </summary>
        /// <value>The progress background gradient color2.</value>
        public Color ProgressBackGrad2
        {
            get { return progBackGrad2; }
            set
            {
                progBackGrad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color using gradient.
        /// </summary>
        /// <value>The progress gradient color1.</value>
        public Color ProgressGrad1
        {
            get { return progGrad1; }
            set
            {
                progGrad1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color using gradient.
        /// </summary>
        /// <value>The progress gradient color2.</value>
        public Color ProgressGrad2
        {
            get { return progGrad2; }
            set
            {
                progGrad2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the inner border.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public Color InnerBorder
        {
            get { return innerBorder; }
            set
            {
                innerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the outer border.
        /// </summary>
        /// <value>The color of the outer border.</value>
        public Color OuterBorder
        {
            get { return outerBorder; }
            set
            {
                outerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }

                _Value = value;
                Invalidate();
            }
        }

        #region Old Code
        //public long Value
        //{
        //    get { return _Value; }
        //    set
        //    {
        //        if (value > _Maximum)
        //            value = _Maximum;
        //        _Value = value;
        //        Invalidate();
        //    }
        //}


        //public long Maximum
        //{
        //    get { return _Maximum; }
        //    set
        //    {
        //        if (value < 1)
        //            value = 1;
        //        _Maximum = value;
        //        Invalidate();
        //    }
        //} 
        #endregion

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        public int Thickness
        {
            get { return _Thickness; }
            set
            {
                _Thickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public int StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the start cap.
        /// </summary>
        /// <value>The start cap.</value>
        public LineCap StartCap
        {
            get { return startCap; }
            set
            {
                startCap = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end cap.
        /// </summary>
        /// <value>The end cap.</value>
        public LineCap EndCap
        {
            get { return endCap; }
            set
            {
                endCap = value;
                Invalidate();
            }
        }
        #endregion

        #region Paint Events
        //Handle PaintBackground to prevent flicker
        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="p">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs p)
        {

        }


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

            //Create image buffer
            //Bitmap B = new Bitmap(Width, Height);
            timer.Interval = speed;
            Graphics G = e.Graphics;

            G.TextRenderingHint = textrendering;

            //Enable anti-aliasing to prevent rough edges
            G.SmoothingMode = SmoothingMode.HighQuality;

            //Fill background color
            G.Clear(BackColor);

            float percentage = _Value;

            //float progressAngle = Convert.ToSingle(360 / 100 * percentage);

            float progressAngle = Convert.ToSingle(360 * (percentage / _Maximum));

            int remainderAngle = 360 - Convert.ToInt32(progressAngle);


            //Draw progress background
            using (LinearGradientBrush T = new LinearGradientBrush(ClientRectangle, progGrad1, progGrad2, LinearGradientMode.Vertical))
            {
                using (Pen P = new Pen(T, Thickness))
                {
                    G.DrawArc(P, Convert.ToInt32(Thickness / 2), Convert.ToInt32(Thickness / 2), Width - Thickness - 1, Height - Thickness - 1, 0, /*360 * (_Value / _Maximum)*/ 360);
                }
            }

            //Draw progress
            using (LinearGradientBrush T = new LinearGradientBrush(ClientRectangle, progBackGrad1, progBackGrad2, LinearGradientMode.Vertical))
            {
                using (Pen P = new Pen(T, Thickness))
                {
                    P.StartCap = startCap;
                    P.EndCap = endCap;
                    G.DrawArc(P, Convert.ToInt32(Thickness / 2), Convert.ToInt32(Thickness / 2), Width - Thickness - 1, Height - Thickness - 1, /*startAngle*/progressAngle - 90, /*360 * (_Value/_Maximum)*/ remainderAngle);
                }
            }

            //Draw center
            using (LinearGradientBrush T = new LinearGradientBrush(ClientRectangle, Color.Gray, Color.Black, gradAngle))
            {
                G.FillEllipse(T, Thickness, Thickness, Width - Thickness * 2 - 1, Height - Thickness * 2 - 1);
            }

            //Draw progress string
            SizeF S = G.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
            G.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, new SolidBrush(ForeColor), Convert.ToInt32(Width / 2 - S.Width / 2), Convert.ToInt32(Height / 2 - S.Height / 2));

            //Draw outter border
            G.DrawEllipse(new Pen(outerBorder), 0, 0, Width - 1, Height - 1);

            //Draw inner border
            G.DrawEllipse(new Pen(innerBorder), Thickness, Thickness, Width - Thickness * 2 - 1, Height - Thickness * 2 - 1);

            //Output the buffered image
            //e.Graphics.DrawImage(B, 0, 0);

            base.OnPaint(e);


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
        /// Gets or sets a value indicating whether  to automatically start the progress.
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

            if (this.GradientAngle + 1 > 360)
            {
                this.GradientAngle = 0;
            }

            else
            {
                this.GradientAngle++;
                Invalidate();
            }
        }

        #endregion

    }

    #endregion
}
