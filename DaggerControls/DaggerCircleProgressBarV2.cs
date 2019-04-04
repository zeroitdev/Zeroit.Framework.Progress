// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="DaggerCircleProgressBarV2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitDaggerCircularV2 : Control
	{
        #region Private Fields
        /// <summary>
        /// The buffered graphics
        /// </summary>
        private BufferedGraphics bufferedGraphics;

        /// <summary>
        /// The update UI
        /// </summary>
        private System.Windows.Forms.Timer updateUI = new System.Windows.Forms.Timer();

        /// <summary>
        /// The start point
        /// </summary>
        private int StartPoint = 270;

        /// <summary>
        /// The un filled color
        /// </summary>
        private Color unFilledColor = Color.FromArgb(114, 114, 114);

        /// <summary>
        /// The filled color
        /// </summary>
        private Color filledColor = Color.FromArgb(60, 220, 210);

        //private Color innerColor = Color.FromArgb(39, 193, 6);

        /// <summary>
        /// The inner color
        /// </summary>
        private Color innerColor = Color.Orange;

        /// <summary>
        /// The innerfilled alpha
        /// </summary>
        private int innerfilledAlpha = 200;

        /// <summary>
        /// The innerfilled thickness
        /// </summary>
        private int innerfilledThickness = 30;

        /// <summary>
        /// The filled color alpha
        /// </summary>
        private int filledColorAlpha = 130;

        /// <summary>
        /// The unfilled thickness
        /// </summary>
        private int unfilledThickness = 24;

        /// <summary>
        /// The filled thickness
        /// </summary>
        private int filledThickness = 40;

        /// <summary>
        /// The percentage
        /// </summary>
        public int percentage = 63;

        /// <summary>
        /// The animation speed
        /// </summary>
        public int animationSpeed = 5;

        /// <summary>
        /// The is animated
        /// </summary>
        public bool isAnimated = false;

        /// <summary>
        /// The text size
        /// </summary>
        public int textSize = 25;

        /// <summary>
        /// The text color
        /// </summary>
        public Color textColor = Color.Gray;

        /// <summary>
        /// The show text
        /// </summary>
        public bool showText = true;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the color of the inner filled area.
        /// </summary>
        /// <value>The color of the inner filled area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set to fill the Inner Color")]
        public Color InnerFilledColor
        {
            get { return innerColor; }
            set
            {
                innerColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the filled thickness inner area.
        /// </summary>
        /// <value>The filled thickness inner area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the thickness of the Inner circle")]
        public int FilledThicknessInner
        {
            get { return innerfilledThickness; }
            set
            {
                innerfilledThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the filled color alpha of the inner area.
        /// </summary>
        /// <value>The filled color alpha of the inner area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the Alpha of the Inner color")]
        public int FilledColorAlphaInner
        {
            get { return innerfilledAlpha; }
            set
            {
                if (value > 255)
                {
                    value = 255;
                    Invalidate();
                }

                innerfilledAlpha = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        [Browsable(true)]
        [Category("Behaviour")]
        [Description("The animation speed")]
        public int AnimationSpeed
        {
            get
            {
                return this.animationSpeed;
            }
            set
            {
                this.animationSpeed = value;
                if (value < 1)
                {
                    this.animationSpeed = 1;
                }
                if (this.animationSpeed > 10)
                {
                    this.animationSpeed = 10;
                }
                this.updateUI.Interval = 200 / this.animationSpeed;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the filled area.
        /// </summary>
        /// <value>The color of the filled area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Filled circle color")]
        public Color FilledColor
        {
            get
            {
                return this.filledColor;
            }
            set
            {
                this.filledColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the filled area's color alpha.
        /// </summary>
        /// <value>The filled area's color alpha.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Filled colors alpha value")]
        public int FilledColorAlpha
        {
            get
            {
                return this.filledColorAlpha;
            }
            set
            {
                this.filledColorAlpha = value;
                if (value > 255)
                {
                    this.filledColorAlpha = 255;
                }
                if (value < 1)
                {
                    this.filledColorAlpha = 1;
                }
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the filled thickness.
        /// </summary>
        /// <value>The filled thickness.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Unfilled circle thickness")]
        public int FilledThickness
        {
            get
            {
                return this.filledThickness;
            }
            set
            {
                this.filledThickness = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether control is animated.
        /// </summary>
        /// <value><c>true</c> if this instance is animated; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behaviour")]
        [Description("Is the control animated")]
        public bool IsAnimated
        {
            get
            {
                return this.isAnimated;
            }
            set
            {
                this.isAnimated = value;
                if (!value)
                {
                    this.updateUI.Enabled = false;
                }
                else
                {
                    this.updateUI.Enabled = true;
                }
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The progress circle percentage")]
        public int Percentage
        {
            get
            {
                return this.percentage;
            }
            set
            {
                this.percentage = value;
                if (value < 0)
                {
                    this.percentage = 0;
                }
                if (value > 100)
                {
                    this.percentage = 100;
                }
                this.OnPercentageChanged();
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show text.
        /// </summary>
        /// <value><c>true</c> if show text; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behaviour")]
        [Description("Show text")]
        public bool ShowText
        {
            get
            {
                return this.showText;
            }
            set
            {
                this.showText = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Text color")]
        public Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                this.textColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the text.
        /// </summary>
        /// <value>The size of the text.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The text size")]
        public int TextSize
        {
            get
            {
                return this.textSize;
            }
            set
            {
                this.textSize = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the unfilled area.
        /// </summary>
        /// <value>The color of the unfilled area.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Unfilled circle color")]
        public Color UnFilledColor
        {
            get
            {
                return this.unFilledColor;
            }
            set
            {
                this.unFilledColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the unfilled thickness.
        /// </summary>
        /// <value>The unfilled thickness.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Unfilled circle thickness")]
        public int UnfilledThickness
        {
            get
            {
                return this.unfilledThickness;
            }
            set
            {
                this.unfilledThickness = value;
                base.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDaggerCircularV2" /> class.
        /// </summary>
        public ZeroitDaggerCircularV2()
		{
            
            base.Size = new System.Drawing.Size(200, 200);
			this.updateUI.Tick += new EventHandler(this.Animate);
			this.updateUI.Interval = 200 / this.animationSpeed;
            
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        /// <summary>
        /// Animates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Animate(object sender, EventArgs e)
		{
			if (this.StartPoint == 360)
			{
				this.StartPoint = 0;
			}
			this.StartPoint = this.StartPoint + this.animationSpeed;
			this.Refresh();
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            BufferedGraphicsContext current = BufferedGraphicsManager.Current;
            current.MaximumBuffer = new System.Drawing.Size(base.Width + 1, base.Height + 1);
            this.bufferedGraphics = current.Allocate(base.CreateGraphics(), new Rectangle(0, 0, 1, 1));
            this.bufferedGraphics = current.Allocate(base.CreateGraphics(), base.ClientRectangle);
            this.bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.bufferedGraphics.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            this.bufferedGraphics.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            this.bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.bufferedGraphics.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (this.BackgroundImage != null)
            {
                this.bufferedGraphics.Graphics.DrawImage(this.BackgroundImage, 0, 0);
            }
            else
            {
                this.bufferedGraphics.Graphics.Clear(this.BackColor);
            }
            Rectangle rectangle = new Rectangle(this.filledThickness / 2 + 1, this.filledThickness / 2 + 1, base.Width - this.filledThickness - 2, base.Height - this.filledThickness - 2);
            this.bufferedGraphics.Graphics.DrawArc(new Pen(this.unFilledColor, (float)this.unfilledThickness), rectangle, (float)this.StartPoint, 360f);

            this.bufferedGraphics.Graphics.DrawArc(new Pen(Color.FromArgb(innerfilledAlpha, innerColor.R, innerColor.G, innerColor.B), (float)this.filledThickness - innerfilledThickness), new Rectangle(this.filledThickness / 2 + 1, this.filledThickness / 2 + 1, base.Width - this.filledThickness - 2, base.Height - this.filledThickness - 2), (float)this.StartPoint, (float)((int)((double)this.Percentage * 3.6)));


            this.bufferedGraphics.Graphics.DrawArc(new Pen(Color.FromArgb(this.filledColorAlpha, (int)this.filledColor.R, (int)this.filledColor.G, (int)this.filledColor.B), (float)this.filledThickness), rectangle, (float)this.StartPoint, (float)((int)((double)this.Percentage * 3.6)));
            if (this.ShowText)
            {
                Rectangle rectangle1 = new Rectangle(0, 0, base.Width, base.Height);
                StringFormat stringFormat = new StringFormat()
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                this.bufferedGraphics.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                Graphics graphics = this.bufferedGraphics.Graphics;
                int percentage = this.Percentage;
                graphics.DrawString(string.Concat(percentage.ToString(), "%"), new System.Drawing.Font("Ariel", (float)this.textSize), new SolidBrush(this.textColor), rectangle1, stringFormat);
            }
            this.bufferedGraphics.Render(e.Graphics);
            base.OnPaint(e);
        }




        /// <summary>
        /// Called when [percentage changed].
        /// </summary>
        protected virtual void OnPercentageChanged()
		{
			if (this.PercentageChanged != null)
			{
				this.PercentageChanged(this, EventArgs.Empty);
			}
		}

        /// <summary>
        /// Occurs when [percentage changed].
        /// </summary>
        public event EventHandler PercentageChanged;
	}
}