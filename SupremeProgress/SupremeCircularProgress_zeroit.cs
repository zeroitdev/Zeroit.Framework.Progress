// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="SupremeCircularProgress_zeroit.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a circular progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitSupremeCircular : Control
    {

        #region Private Fields        
        /// <summary>
        /// Enum representing the rendering mode.
        /// </summary>
        public enum RenderMode
        {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The gradient
            /// </summary>
            Gradient
        }

        /// <summary>
        /// The color mode
        /// </summary>
        private RenderMode _colorMode = RenderMode.Solid;

        //private Color[] borderColors = new Color[]
        //{
        //    SystemColors.HotTrack,
        //    Color.LightGray
        //};

        /// <summary>
        /// The progress color
        /// </summary>
        private Color progressColor = SystemColors.HotTrack;

        /// <summary>
        /// The outer color
        /// </summary>
        private Color outerColor = Color.LightGray;

        /// <summary>
        /// The solid color
        /// </summary>
        private Color solidColor = SystemColors.Control;

        /// <summary>
        /// The gradient color
        /// </summary>
        private Color[] gradientColor = new Color[]
        {
            Color.Orange,
            Color.DarkSlateGray
        };

        /// <summary>
        /// The lin mode
        /// </summary>
        private LinearGradientMode linMode = LinearGradientMode.BackwardDiagonal;


        /// <summary>
        /// The show text
        /// </summary>
        private bool showText = true;

        //private int[] integerValues = new int[]
        //{
        //    5,
        //    15,
        //    -90,

        //};

        /// <summary>
        /// The value
        /// </summary>
        private float _Value = 0;

        /// <summary>
        /// The maximum
        /// </summary>
        private float _Maximum = 100;

        /// <summary>
        /// The minimum
        /// </summary>
        float _Minimum = 0;

        //int Int0 = 10;
        //int Int1 = 15;
        //int Int3 = 100;
        //this.Int5 = -90;
        //this.Int6 = 1;
        //this.Int20 = 5;
        //this.Int21 = 2;
        //this.Int22 = 20;
        //this.Int23 = 90;
        //this.Dir = 1;
        //this.Color0 = SystemColors.HotTrack;
        //this.Color1 = Color.LightGray;
        //this.Supreme_Color2 = Color.Transparent;
        //this.Bool = false;
        //this.Bool2 = false;

        /// <summary>
        /// The angle
        /// </summary>
        private float angle = -90f;

        /// <summary>
        /// The outerborder
        /// </summary>
        private int outerborder = 5;

        /// <summary>
        /// The innerborder
        /// </summary>
        private int innerborder = 15;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        public float SupremeAngle
        {
            get
            {
                return angle;

            }
            set
            {
                angle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border.
        /// </summary>
        /// <value>The outer border.</value>
        public int SupremeOuterBorder
        {
            get { return outerborder; }
            set
            {
                outerborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public int SupremeInnerBorder
        {
            get { return innerborder; }
            set
            {
                innerborder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return linMode; }
            set
            {
                linMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
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

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public float Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;



                _Maximum = value;



                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        public float Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the draw mode.
        /// </summary>
        /// <value>The draw mode.</value>
        public RenderMode DrawMode
        {
            get { return _colorMode; }
            set
            {
                _colorMode = value;
                Invalidate();
            }
        }

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
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSupremeCircular" /> class.
        /// </summary>
        public ZeroitSupremeCircular()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.UserPaint | 
                ControlStyles.DoubleBuffer | 
                ControlStyles.SupportsTransparentBackColor, true);


            

        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Supremes the center string.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="T">The t.</param>
        /// <param name="F">The f.</param>
        /// <param name="C">The c.</param>
        /// <param name="R">The r.</param>
        public static void Supreme_CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point(R.Width / 2 - (int)(TS.Width / 2), R.Height / 2 - (int)(TS.Height / 2)));
            }
        }

        /// <summary>
        /// Paints the progress bar.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintProgressBar(PaintEventArgs e)
        {
            //Bitmap bitmap = new Bitmap(base.Size.Width, base.Size.Height);
            //Graphics graphic = Graphics.FromImage(bitmap);

            Graphics graphic = e.Graphics;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.Clear(BackColor);

            Rectangle rectangle = new Rectangle(10, 10, checked(base.Width - 20),
                checked(base.Height - 20));
            Pen pen = new Pen(outerColor)
            {
                Width = (float)this.outerborder
            };

            graphic.DrawArc(pen, rectangle, 0f, 360f);

            switch (_colorMode)
            {
                case RenderMode.Solid:
                    graphic.FillEllipse(new SolidBrush(solidColor), 10f + (float)((double)this.outerborder / 2), 10f + (float)((double)this.outerborder / 2),
                        (float)(checked(checked(base.Width - 20) - this.outerborder)),
                        (float)(checked(checked(base.Height - 20) - this.outerborder)));
                    break;
                case RenderMode.Gradient:
                    LinearGradientBrush linbrBrush = new LinearGradientBrush(
                        new RectangleF(10f + (float)((double)this.outerborder / 2),
                        10f + (float)((double)this.outerborder / 2),
                        (float)(checked(checked(base.Width - 20) - this.outerborder)),
                        (float)(checked(checked(base.Height - 20) - this.outerborder))),
                        gradientColor[0], gradientColor[1], linMode);
                    graphic.FillEllipse(linbrBrush, 10f + (float)((double)this.outerborder / 2),
                    10f + (float)((double)this.outerborder / 2),
                    (float)(checked(checked(base.Width - 20) - this.outerborder)),
                    (float)(checked(checked(base.Height - 20) - this.outerborder)));
                    break;
                default:
                    break;
            }


            Rectangle rectangle1 = new Rectangle(10, 10, checked(base.Width - 20),
                checked(base.Height - 20));
            pen = new Pen(this.progressColor)
            {
                Width = (float)this.innerborder
            };

            graphic.DrawArc(
                pen,
                rectangle1,
                (float)this.angle,
                (float)checked((int)System.Math.Round((double)(checked(360 * Value)) / Maximum)));


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

            PaintProgressBar(e);

            if (ShowText)
            {
                Supreme_CenterString(e.Graphics, Convert.ToInt32(Value).ToString() + "%", Font, ForeColor, this.ClientRectangle);

            }

        }


        #endregion

        
    }
}
