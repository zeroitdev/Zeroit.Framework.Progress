// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="Ultimate.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Ultimate

    #region AbstractProgressBar
    /// <summary>
    /// Enum representing a type of progress.
    /// </summary>
    public enum ProgressType
    {
        /// <summary>
        /// The smooth
        /// </summary>
        Smooth,
        /// <summary>
        /// The marquee wrap
        /// </summary>
        MarqueeWrap,
        /// <summary>
        /// The marquee bounce
        /// </summary>
        MarqueeBounce,
        /// <summary>
        /// The marquee bounce deep
        /// </summary>
        MarqueeBounceDeep,
        /// <summary>
        /// The animated
        /// </summary>
        Animated
    }

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public abstract class ZeroitUltimateAbstractProgressBar : Control
    {
        /// <summary>
        /// The minimum
        /// </summary>
        protected int minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        protected int maximum = 100;
        /// <summary>
        /// The value
        /// </summary>
        protected int value = 0;
        /// <summary>
        /// The borderbox
        /// </summary>
        protected Rectangle borderbox;
        /// <summary>
        /// The progressbox
        /// </summary>
        protected Rectangle progressbox;
        /// <summary>
        /// The backbox
        /// </summary>
        protected Rectangle backbox;
        /// <summary>
        /// The show percent
        /// </summary>
        private bool showPercent = false;
        /// <summary>
        /// The padding
        /// </summary>
        private int padding = 0;

        #region Marquee
        /// <summary>
        /// The type
        /// </summary>
        protected ProgressType type = ProgressType.Smooth;
        /// <summary>
        /// The marquee speed
        /// </summary>
        protected int marqueeSpeed = 30;
        /// <summary>
        /// The marquee percentage
        /// </summary>
        protected int marqueePercentage = 25;
        /// <summary>
        /// The marquee step
        /// </summary>
        protected int marqueeStep = 1;
        #endregion

        /// <summary>
        /// The on value changed
        /// </summary>
        protected EventHandler OnValueChanged;
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event EventHandler ValueChanged
        {
            add
            {
                if (OnValueChanged != null)
                {
                    foreach (Delegate d in OnValueChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                OnValueChanged = (EventHandler)Delegate.Combine(OnValueChanged, value);
            }
            remove { OnValueChanged = (EventHandler)Delegate.Remove(OnValueChanged, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateAbstractProgressBar" /> class.
        /// </summary>
        public ZeroitUltimateAbstractProgressBar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Gets or sets whether or not to draw the percentage text.
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        [Category("Progress"), Description("Gets or sets whether or not to draw the percentage text"), Browsable(true)]
        public bool ShowPercentage
        {
            get { return showPercent; }
            set
            {
                showPercent = value;
                Invalidate();
                if (!showPercent)
                {
                    this.Text = "";
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="ArgumentException">Minimum must be smaller than maximum.</exception>
        [Category("Progress"), Description("Gets or sets the minimum value"), Browsable(true)]
        public virtual int Minimum
        {
            get { return this.minimum; }
            set
            {
                if (value > maximum) { throw new ArgumentException("Minimum must be smaller than maximum."); }
                this.minimum = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="ArgumentException">Maximum must be larger than minimum.</exception>
        [Category("Progress"), Description("Gets or sets the maximum value"), Browsable(true)]
        public virtual int Maximum
        {
            get { return this.maximum; }
            set
            {
                if (value < minimum) { throw new ArgumentException("Maximum must be larger than minimum."); }
                this.maximum = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentException">Value must be greater than or equal to minimum.
        /// or
        /// Value must be less than or equal to maximum.</exception>
        [Category("Progress"), Description("Gets or sets the current value"), Browsable(true)]
        public int Value
        {
            get { return this.value; }
            set
            {
                if (value < minimum) { throw new ArgumentException("Value must be greater than or equal to minimum."); }
                if (value > maximum) { throw new ArgumentException("Value must be less than or equal to maximum."); }
                this.value = value;
                if (showPercent)
                {
                    int percent = (int)(((float)this.value / (float)(this.maximum - 1f)) * 100f);
                    if (percent > 0)
                    {
                        if (percent > 100) { percent = 100; }
                        this.Text = string.Format("{0}%", percent.ToString());
                    }
                    else { this.Text = ""; }
                }
                if (OnValueChanged != null)
                {
                    OnValueChanged(this, EventArgs.Empty);
                }
                ResizeProgress();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels to pad between the border and progress.
        /// </summary>
        /// <value>The progress padding.</value>
        [Category("Progress"), Description("Gets or sets the number of pixels to pad between the border and progress"), Browsable(true)]
        public int ProgressPadding
        {
            get { return this.padding; }
            set
            {
                this.padding = value;
                if (OnValueChanged != null)
                {
                    OnValueChanged(this, EventArgs.Empty);
                }
                //ResizeProgress();
                OnResize(EventArgs.Empty);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the progress.
        /// </summary>
        /// <value>The type of the progress.</value>
        [Category("Progress"), Description("Gets or sets the type of progress"), Browsable(true)]
        public virtual ProgressType ProgressType
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #region Marquee        
        /// <summary>
        /// Gets or sets the marquee speed.
        /// </summary>
        /// <value>The marquee speed.</value>
        [Category("Marquee"), Description("Gets or sets the number of milliseconds between marquee steps"), Browsable(true)]
        public int MarqueeSpeed
        {
            get { return this.marqueeSpeed; }
            set
            {
                this.marqueeSpeed = value;
                if (this.marqueeSpeed < 10) { this.marqueeSpeed = 10; }
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels to progress the marquee bar.
        /// </summary>
        /// <value>The marquee step.</value>
        [Category("Marquee"), Description("Gets or sets the number of pixels to progress the marquee bar"), Browsable(true)]
        public int MarqueeStep
        {
            get { return this.marqueeStep; }
            set { this.marqueeStep = value; }
        }

        /// <summary>
        /// Gets or sets the percentage of the width that the marquee progress fills.
        /// </summary>
        /// <value>The marquee percentage.</value>
        /// <exception cref="ArgumentException">Marquee percentage width must be between 5% and 95%.</exception>
        [Category("Marquee"), Description("Gets or sets the percentage of the width that the marquee progress fills"), Browsable(true)]
        public int MarqueePercentage
        {
            get { return this.marqueePercentage; }
            set
            {
                if (value < 5 || value > 95)
                {
                    throw new ArgumentException("Marquee percentage width must be between 5% and 95%.");
                }
                this.marqueePercentage = value;
            }
        }

        #endregion

        /// <summary>
        /// Gets the border box.
        /// </summary>
        /// <value>The border box.</value>
        [Browsable(false)]
        public Rectangle BorderBox
        {
            get { return this.borderbox; }
        }

        /// <summary>
        /// Gets the back box.
        /// </summary>
        /// <value>The back box.</value>
        [Browsable(false)]
        public Rectangle BackBox
        {
            get { return this.backbox; }
        }

        /// <summary>
        /// Gets the progress box.
        /// </summary>
        /// <value>The progress box.</value>
        [Browsable(false)]
        public Rectangle ProgressBox
        {
            get { return this.progressbox; }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="gr">The gr.</param>
        protected abstract void PaintBackground(Graphics gr);

        /// <summary>
        /// Paints the progress.
        /// </summary>
        /// <param name="gr">The gr.</param>
        protected abstract void PaintProgress(Graphics gr);

        /// <summary>
        /// Paints the text.
        /// </summary>
        /// <param name="gr">The gr.</param>
        protected abstract void PaintText(Graphics gr);

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="gr">The gr.</param>
        protected abstract void PaintBorder(Graphics gr);

        /// <summary>
        /// Resizes the progress.
        /// </summary>
        protected abstract void ResizeProgress();

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            borderbox = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            backbox = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            ResizeProgress();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintBackground(e.Graphics);
            PaintProgress(e.Graphics);
            e.Graphics.Clip = new Region(new Rectangle(0, 0, this.Width, this.Height));
            PaintText(e.Graphics);
            PaintBorder(e.Graphics);
        }

        /// <summary>
        /// Marquees the start.
        /// </summary>
        public abstract void MarqueeStart();
        /// <summary>
        /// Marquees the pause.
        /// </summary>
        public abstract void MarqueePause();
        /// <summary>
        /// Marquees the stop.
        /// </summary>
        public abstract void MarqueeStop();
    }

    #endregion

    #region AbstractProgressPainter
    /// <summary>
    /// Class ZeroitUltimateAbstractProgressPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    public abstract class ZeroitUltimateAbstractProgressPainter : Component, IProgressPainter
    {
        /// <summary>
        /// The gloss
        /// </summary>
        protected IGlossPainter gloss;
        /// <summary>
        /// The border
        /// </summary>
        protected IProgressBorderPainter border;
        /// <summary>
        /// The padding
        /// </summary>
        internal int padding = 0;

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        [Category("Painters"), Description("Gets or sets the gloss painter chain"), Browsable(true)]
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the progress border painter.
        /// </summary>
        /// <value>The progress border painter.</value>
        [Category("Painters"), Description("Gets or sets the border painter for this progress painter"), Browsable(true)]
        public IProgressBorderPainter ProgressBorderPainter
        {
            get { return this.border; }
            set
            {
                this.border = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Paints the progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="gr">The gr.</param>
        public void PaintProgress(Rectangle box, Graphics gr)
        {
            PaintThisProgress(box, gr);
            //if (this.gloss != null && box.Width > 1) {
            //    Rectangle b = new Rectangle(box.X, box.Y, box.Width - 1, box.Height - 1);
            //    //gr.DrawRectangle(Pens.Red, b);
            //    this.gloss.PaintGloss(box, gr);
            //}
            if (this.border != null && box.Width > 1)
            {
                int w = box.Width;
                //if (padding > 0) { w += 3; } else { w += 1; }
                //Rectangle b = new Rectangle(box.X - 1, box.Y - 1, w, box.Height + 3);
                Rectangle b = new Rectangle(box.X, box.Y, box.Width - 1, box.Height - 1);
                b.Inflate(1, 1);
                this.border.PaintBorder(b, gr);
            }
        }
        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="gr">The gr.</param>
        protected abstract void PaintThisProgress(Rectangle box, Graphics gr);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public virtual void Resize(Rectangle box)
        {
            if (gloss != null) { gloss.Resize(box); }
            if (border != null) { border.Resize(box); }
            ResizeThis(box);
        }
        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected virtual void ResizeThis(Rectangle box) { }

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        protected void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            DisposeThis(disposing);
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected virtual void DisposeThis(bool disposing)
        {
        }
    }
    #endregion

    #region BarberPoleProgressPainter
    /// <summary>
    /// Class ZeroitUltimateBarberPoleProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateBarberPoleProgressPainter), "Resources.BarberPoleProgressPainter.ico")]
    public class ZeroitUltimateBarberPoleProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The base color
        /// </summary>
        private Color baseColor;
        /// <summary>
        /// The highlight color
        /// </summary>
        private Color highlightColor;
        /// <summary>
        /// The stripe color
        /// </summary>
        private Color stripeColor;
        /// <summary>
        /// The base shade color
        /// </summary>
        private Color baseShadeColor;
        /// <summary>
        /// The highlight shade color
        /// </summary>
        private Color highlightShadeColor;
        /// <summary>
        /// The stripe shade color
        /// </summary>
        private Color stripeShadeColor;
        /// <summary>
        /// The shade height
        /// </summary>
        private int shadeHeight;
        /// <summary>
        /// The stripe width
        /// </summary>
        private int stripeWidth;
        /// <summary>
        /// The img
        /// </summary>
        private Image img;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateBarberPoleProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateBarberPoleProgressPainter()
        {
            baseColor = Color.FromArgb(226, 138, 078);
            highlightColor = Color.FromArgb(225, 132, 068);
            stripeColor = Color.FromArgb(222, 123, 055);
            baseShadeColor = Color.FromArgb(215, 097, 020);
            highlightShadeColor = Color.FromArgb(213, 087, 007);
            stripeShadeColor = Color.FromArgb(210, 078, 000);
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color"), Browsable(true)]
        public Color Color
        {
            get { return baseColor; }
            set
            {
                baseColor = value;
                ZeroitUltimateHSV baseHsv = new ZeroitUltimateHSV(baseColor);

                bool change = false;
                if (baseHsv.Saturation > 166) { baseHsv.Saturation = 166; change = true; }
                if (baseHsv.Value > 239) { baseHsv.Value = 239; change = true; }
                if (change) { baseColor = baseHsv.Color; }

                highlightColor = ZeroitUltimateHSV.FromHsv(baseHsv.Hue, baseHsv.Saturation + 11, baseHsv.Value);
                stripeColor = ZeroitUltimateHSV.FromHsv(baseHsv.Hue, baseHsv.Saturation + 25, baseHsv.Value - 4);

                ZeroitUltimateHSV shade = new ZeroitUltimateHSV(baseHsv.Hue, baseHsv.Saturation + 65, baseHsv.Value - 11);
                baseShadeColor = shade.Color;
                highlightShadeColor = ZeroitUltimateHSV.FromHsv(shade.Hue, shade.Saturation + 15, shade.Value - 2);
                stripeShadeColor = ZeroitUltimateHSV.FromHsv(shade.Hue, shade.Saturation + 24, shade.Value - 5);

                try { if (box != null) { RepaintImage(box); } } catch { }
                FireChange();
            }
        }

        /// <summary>
        /// Repaints the image.
        /// </summary>
        /// <param name="box">The box.</param>
        private void RepaintImage(Rectangle box)
        {
            if (box.Width == 0 || box.Height == 0) { img = null; return; }
            img = new Bitmap(box.Width - (box.X * 2), box.Height - (box.Y * 2));
            Bitmap tile = new Bitmap(img.Height * 2, img.Height);

            shadeHeight = (int)((double)box.Height * 0.4D);
            stripeWidth = box.Height;

            using (Graphics g = Graphics.FromImage(tile))
            {
                g.FillRectangle(new SolidBrush(baseColor), 0, 0, tile.Width, tile.Height);
                g.FillRectangle(new SolidBrush(baseShadeColor), 0, tile.Height - shadeHeight, tile.Width, tile.Height);

                Pen highlightPen = new Pen(new SolidBrush(highlightColor), 1f);
                Pen highlightShadePen = new Pen(new SolidBrush(highlightShadeColor), 1f);
                Pen stripePen = new Pen(new SolidBrush(stripeColor), 1f);
                Pen stripeShadePen = new Pen(new SolidBrush(stripeShadeColor), 1f);

                for (int y = 0; y < stripeWidth; y++)
                {
                    if (y < tile.Height - shadeHeight)
                    {
                        g.DrawLine(highlightPen, stripeWidth - y - 1, y, (stripeWidth * 2) - y + 1, y);
                        g.DrawLine(stripePen, stripeWidth - y, y, (stripeWidth * 2) - y, y);
                    }
                    else
                    {
                        g.DrawLine(highlightShadePen, stripeWidth - y - 1, y, (stripeWidth * 2) - y + 1, y);
                        g.DrawLine(stripeShadePen, stripeWidth - y, y, (stripeWidth * 2) - y, y);
                    }
                }
            }

            int x = box.X;
            using (Graphics i = Graphics.FromImage(img))
            {
                while (true)
                {
                    if (x > img.Width) { break; }
                    i.DrawImageUnscaled(tile, x, box.Y);
                    x += tile.Width;
                }
            }

            tile.Dispose();
        }
        /// <summary>
        /// Offsets the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Point.</returns>
        private Point Offset(Point p, int x, int y)
        {
            return new Point(p.X + x, p.Y + y);
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Width -= 1;
                box.Height -= 1;
            }
            catch { }
            if (box.Width <= 1) { return; }

            if (img == null) { RepaintImage(box); }
            Rectangle off = new Rectangle(box.Location, box.Size);
            off.Offset(box.Right - img.Width, 0);
            g.DrawImageUnscaled(img, off);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            this.box = box;
            try
            {
                box.Width -= 1;
                box.Height -= 1;
            }
            catch { }
            shadeHeight = (int)((double)box.Height * 0.4D);
            stripeWidth = box.Height;
            RepaintImage(box);
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            if (img != null) { img.Dispose(); }
        }
    }
    #endregion

    #region BevelledGradientProgressPainter
    /// <summary>
    /// Class ZeroitUltimateBevelledGradientProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateBevelledGradientProgressPainter), "Resources.BevelledGradientProgressPainter.ico")]
    public class ZeroitUltimateBevelledGradientProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The minimum
        /// </summary>
        private ColorRange min;
        /// <summary>
        /// The maximum
        /// </summary>
        private ColorRange max;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateBevelledGradientProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateBevelledGradientProgressPainter()
        {
            this.MinColor = Color.Cornsilk;
            this.MaxColor = Color.Gold;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateBevelledGradientProgressPainter"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ZeroitUltimateBevelledGradientProgressPainter(Color min, Color max)
        {
            this.MinColor = min;
            this.MaxColor = max;
        }

        /// <summary>
        /// Gets or sets the minimum color.
        /// </summary>
        /// <value>The minimum color.</value>
        [Category("Appearance"), Description("Gets or sets the left progress color"), Browsable(true)]
        public Color MinColor
        {
            get { return min.BaseColor; }
            set
            {
                min = new ColorRange(value);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the maximum color.
        /// </summary>
        /// <value>The maximum color.</value>
        [Category("Appearance"), Description("Gets or sets the right progress color"), Browsable(true)]
        public Color MaxColor
        {
            get { return max.BaseColor; }
            set
            {
                max = new ColorRange(value);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Height -= 1;
                box.Width -= 1;
            }
            catch { }

            if (box.Width < 2) { return; }

            Point left = new Point(box.X, box.Y);
            Point right = new Point(box.Right, box.Y);
            Brush bottomOuter = new System.Drawing.Drawing2D.LinearGradientBrush(left, right, min.Darker, max.Darker);
            Brush bottomInner = new System.Drawing.Drawing2D.LinearGradientBrush(left, right, min.Dark, max.Dark);
            Brush topInner = new System.Drawing.Drawing2D.LinearGradientBrush(left, right, min.Light, max.Light);
            Brush topOuter = new System.Drawing.Drawing2D.LinearGradientBrush(left, right, min.Lighter, max.Lighter);
            Brush fill = new System.Drawing.Drawing2D.LinearGradientBrush(left, right, min.BaseColor, max.BaseColor);

            // fill box
            g.FillRectangle(fill, box);

            using (Pen p = new Pen(topInner, 1))
            {
                // inner top
                g.DrawLine(p, box.X + 1, box.Y + 1, box.Right - 1, box.Y + 1);
            }
            using (Pen p = new Pen(min.Light, 1))
            {
                // inner left
                g.DrawLine(p, box.X + 1, box.Y + 1, box.X + 1, box.Bottom - 1);
            }

            using (Pen p = new Pen(topOuter, 1))
            {
                // outer top
                g.DrawLine(p, box.X, box.Y, box.Right, box.Y);
            }
            using (Pen p = new Pen(min.Lighter, 1))
            {
                // outer left
                g.DrawLine(p, box.X, box.Y, box.X, box.Bottom);
            }

            // draw border
            using (Pen p = new Pen(bottomInner, 1))
            {
                // inner bottom
                g.DrawLine(p, box.X + 1, box.Bottom - 1, box.Right - 1, box.Bottom - 1);
            }
            using (Pen p = new Pen(max.Dark, 1))
            {
                // inner right
                g.DrawLine(p, box.Right - 1, box.Y + 1, box.Right - 1, box.Bottom - 1);
            }

            using (Pen p = new Pen(bottomOuter, 1))
            {
                // outer bottom
                g.DrawLine(p, box.X, box.Bottom, box.Right, box.Bottom);
            }
            using (Pen p = new Pen(max.Darker, 1))
            {
                // outer right
                g.DrawLine(p, box.Right, box.Y, box.Right, box.Bottom);
            }

            bottomOuter.Dispose();
            bottomInner.Dispose();
            topInner.Dispose();
            topOuter.Dispose();
            fill.Dispose();

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }
    }
    #endregion

    #region BevelledProgressPainter
    /// <summary>
    /// Class ZeroitUltimateBevelledProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateBevelledProgressPainter), "Resources.BevelledProgressPainter.ico")]
    public class ZeroitUltimateBevelledProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The bender
        /// </summary>
        private ColorRange bender;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateBevelledProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateBevelledProgressPainter()
        {
            this.Color = Color.FromArgb(151, 151, 234);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateBevelledProgressPainter"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimateBevelledProgressPainter(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color"), Browsable(true)]
        public Color Color
        {
            get { return bender.BaseColor; }
            set
            {
                bender = new ColorRange(value);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            if (box.Width < 2) { return; }
            g.PageUnit = GraphicsUnit.Pixel;

            // fill box
            Rectangle back = new Rectangle(box.X, box.Y, box.Width, box.Height);
            try
            {
                back.Height -= 1;
                back.Width -= 1;
            }
            catch { }
            using (SolidBrush b = new SolidBrush(bender.BaseColor))
            {
                g.FillRectangle(b, back);
            }

            box = new Rectangle(box.X, box.Y, box.Width - 1, box.Height - 1);

            using (Pen p = new Pen(bender.Light, 1))
            {
                // inner top
                g.DrawLine(p, box.X + 1, box.Y + 1, box.Right - 1, box.Y + 1);
                // inner left
                g.DrawLine(p, box.X + 1, box.Y + 1, box.X + 1, box.Bottom - 1);
            }

            using (Pen p = new Pen(bender.Lighter, 1))
            {
                // outer top
                g.DrawLine(p, box.X, box.Y, box.Right, box.Y);
                // outer left
                g.DrawLine(p, box.X, box.Y, box.X, box.Bottom);
            }

            // draw border
            using (Pen p = new Pen(bender.Dark, 1))
            {
                // inner bottom
                g.DrawLine(p, box.X + 1, box.Bottom - 1, box.Right - 1, box.Bottom - 1);
                // inner right
                g.DrawLine(p, box.Right - 1, box.Y + 1, box.Right - 1, box.Bottom - 1);

                //g.DrawRectangle(p, box.X + 1, box.Y + 1, box.Width - 3, box.Height - 3);
            }

            using (Pen p = new Pen(bender.Darker, 1))
            {
                // outer bottom
                g.DrawLine(p, box.X, box.Bottom, box.Right, box.Bottom);
                // outer right
                g.DrawLine(p, box.Right, box.Y, box.Right, box.Bottom);

                //g.DrawRectangle(p, box.X, box.Y, box.Width - 1, box.Height - 1);
            }

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }
    }
    #endregion

    #region CandyCaneBackgroundPainter
    /// <summary>
    /// Class ZeroitUltimateCandyCaneBackgroundPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBackgroundPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateCandyCaneBackgroundPainter), "Resources.CandyCaneBackgroundPainter.ico")]
    public class ZeroitUltimateCandyCaneBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable
    {
        /// <summary>
        /// The img
        /// </summary>
        private Image img;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;
        /// <summary>
        /// The gloss
        /// </summary>
        private IGlossPainter gloss;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        [Category("Painters"), Description("Gets or sets the chain of gloss painters"), Browsable(true)]
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBackground(Rectangle box, Graphics g)
        {
            if (img == null)
            {
                Resize(box);
            }
            g.DrawImageUnscaled(img, box.X, box.Y);
            //g.FillRectangle(brush, box);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
            this.box = box;
            RepaintImage(box);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (img != null)
            {
                img.Dispose();
            }
        }

        /// <summary>
        /// Repaints the image.
        /// </summary>
        /// <param name="box">The box.</param>
        private void RepaintImage(Rectangle box)
        {
            Bitmap source = BuildTile(box.Width);
            img = new Bitmap(box.Width, box.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(source, 0, 0, box.Width, box.Height + 1); // box
            }
            source.Dispose();

            //Bitmap source = BuildTile();
            //Bitmap tile = new Bitmap((int)(((float)box.Height * (float)source.Width) / (float)source.Height), box.Height);
            //using (Graphics g = Graphics.FromImage(tile)) {
            //    g.DrawImage(source, 0, 0, tile.Width, tile.Height);
            //}
            //source.Dispose();

            //img = new Bitmap(box.Width, box.Height);
            //using (Graphics g = Graphics.FromImage(img)) {
            //    int i = 0;
            //    while (i < box.Width) {
            //        g.DrawImageUnscaled(tile, i, 0);
            //        i += tile.Width;
            //    }
            //}
        }

        /// <summary>
        /// Builds the tile.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns>Bitmap.</returns>
        private Bitmap BuildTile(int width)
        {
            Bitmap bmp = new Bitmap(width, 9);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(245, 245, 245))), new Point(0, 0), new Point(width - 1, 0));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(236, 236, 236))), new Point(0, 1), new Point(width - 1, 1));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(234, 234, 235))), new Point(0, 2), new Point(width - 1, 2));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(234, 234, 235))), new Point(0, 3), new Point(width - 1, 3));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(222, 222, 222))), new Point(0, 4), new Point(width - 1, 4));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(229, 229, 230))), new Point(0, 5), new Point(width - 1, 5));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(239, 239, 239))), new Point(0, 6), new Point(width - 1, 6));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(247, 247, 247))), new Point(0, 7), new Point(width - 1, 7));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(254, 254, 255))), new Point(0, 8), new Point(width - 1, 8));

            g.Dispose();
            return bmp;
        }
    }
    #endregion

    #region CandyCaneProgressPainter
    /// <summary>
    /// Class ZeroitUltimateCandyCaneProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateCandyCaneProgressPainter), "Resources.CandyCaneProgressPainter.ico")]
    public class ZeroitUltimateCandyCaneProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The base color
        /// </summary>
        private Color baseColor;
        /// <summary>
        /// The img
        /// </summary>
        private Image img;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateCandyCaneProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateCandyCaneProgressPainter()
        {
            baseColor = Color.FromArgb(049, 129, 222);
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color"), Browsable(true)]
        public Color Color
        {
            get { return baseColor; }
            set
            {
                baseColor = value;
                try { if (box != null) { RepaintImage(box); } } catch { }
                FireChange();
            }
        }

        /// <summary>
        /// Repaints the image.
        /// </summary>
        /// <param name="box">The box.</param>
        private void RepaintImage(Rectangle box)
        {
            this.box = box;
            this.img = new Bitmap(box.Width, box.Height);
            // BuildTile() then resize it to fix the box.Height, then tile it.
            Bitmap source = BuildTile(this.baseColor);
            img = new Bitmap((int)(((float)box.Height * (float)source.Width) / (float)source.Height), box.Height + 1);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(source, 0, 0, img.Width, img.Height + 1);
            }

            source.Dispose();
        }
        /// <summary>
        /// Offsets the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Point.</returns>
        private Point Offset(Point p, int x, int y)
        {
            return new Point(p.X + x, p.Y + y);
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            if (img == null) { RepaintImage(box); }
            if (box.Width <= 1) { return; }

            int x = box.Width - img.Width;
            while (x > (0 - img.Width))
            {
                g.DrawImageUnscaled(img, x, 0);
                x -= img.Width;
            }

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            this.box = box;
            RepaintImage(box);
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            if (img != null)
            {
                img.Dispose();
            }
        }

        /// <summary>
        /// Builds the tile.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Bitmap.</returns>
        public Bitmap BuildTile(Color color)
        {
            ZeroitUltimateHSV clr = new ZeroitUltimateHSV(color);
            Bitmap src = GetSource();
            Bitmap bmp = new Bitmap(src.Width, src.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color original = src.GetPixel(x, y);
                    Color altered = Color.FromArgb(0, 255, 255, 255);
                    ZeroitUltimateHSV orighsv = new ZeroitUltimateHSV(original);
                    Color origrgb = orighsv.Color;
                    origrgb = Color.FromArgb(original.A, origrgb.R, origrgb.G, origrgb.B);
                    if (!origrgb.Equals(altered))
                    {
                        orighsv.Hue = clr.Hue;
                        //orighsv.Saturation = clr.Saturation;
                        //orighsv.Value = clr.Value;
                        altered = orighsv.Color;
                        altered = Color.FromArgb(original.A, altered.R, altered.G, altered.B);
                    }
                    bmp.SetPixel(x, y, altered);
                }
            }
            src.Dispose();
            return bmp;
        }
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>Bitmap.</returns>
        private Bitmap GetSource()
        {
            Bitmap bmp = new Bitmap(16, 9);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(0, 255, 255, 255));

            bmp.SetPixel(0, 0, Color.FromArgb(77, 140, 177, 225));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(140, 177, 225))), new Point(1, 0), new Point(7, 0));
            bmp.SetPixel(8, 0, Color.FromArgb(77, 140, 177, 225));

            bmp.SetPixel(0, 1, Color.FromArgb(38, 99, 158, 222));
            bmp.SetPixel(1, 1, Color.FromArgb(128, 99, 158, 222));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(99, 158, 222))), new Point(2, 1), new Point(8, 1));
            bmp.SetPixel(9, 1, Color.FromArgb(64, 99, 158, 222));

            bmp.SetPixel(1, 2, Color.FromArgb(38, 94, 156, 222));
            bmp.SetPixel(2, 2, Color.FromArgb(205, 94, 156, 222));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(94, 156, 222))), new Point(3, 2), new Point(8, 2));
            bmp.SetPixel(9, 2, Color.FromArgb(192, 94, 156, 222));
            bmp.SetPixel(10, 2, Color.FromArgb(38, 94, 156, 222));

            bmp.SetPixel(2, 3, Color.FromArgb(77, 93, 158, 228));
            bmp.SetPixel(3, 3, Color.FromArgb(251, 93, 158, 228));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(93, 158, 228))), new Point(4, 3), new Point(9, 3));
            bmp.SetPixel(10, 3, Color.FromArgb(154, 93, 158, 228));
            bmp.SetPixel(11, 3, Color.FromArgb(26, 93, 158, 228));

            bmp.SetPixel(2, 4, Color.FromArgb(13, 49, 129, 222));
            bmp.SetPixel(3, 4, Color.FromArgb(51, 49, 129, 222));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(49, 129, 222))), new Point(4, 4), new Point(9, 4));
            bmp.SetPixel(10, 4, Color.FromArgb(251, 49, 129, 222));
            bmp.SetPixel(11, 4, Color.FromArgb(90, 49, 129, 222));

            bmp.SetPixel(3, 5, Color.FromArgb(64, 81, 159, 247));
            bmp.SetPixel(4, 5, Color.FromArgb(205, 81, 159, 247));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(81, 159, 247))), new Point(5, 5), new Point(10, 5));
            bmp.SetPixel(11, 5, Color.FromArgb(218, 81, 159, 247));
            bmp.SetPixel(12, 5, Color.FromArgb(77, 81, 159, 247));

            bmp.SetPixel(4, 6, Color.FromArgb(77, 110, 186, 255));
            bmp.SetPixel(5, 6, Color.FromArgb(243, 110, 186, 255));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(110, 186, 255))), new Point(6, 6), new Point(11, 6));
            bmp.SetPixel(12, 6, Color.FromArgb(154, 110, 186, 255));
            bmp.SetPixel(13, 6, Color.FromArgb(38, 110, 186, 255));

            bmp.SetPixel(4, 7, Color.FromArgb(26, 121, 201, 255));
            bmp.SetPixel(5, 7, Color.FromArgb(141, 121, 201, 255));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(121, 201, 255))), new Point(6, 7), new Point(12, 7));
            bmp.SetPixel(13, 7, Color.FromArgb(102, 121, 201, 255));
            bmp.SetPixel(14, 7, Color.FromArgb(26, 121, 201, 255));

            bmp.SetPixel(5, 8, Color.FromArgb(26, 135, 227, 255));
            bmp.SetPixel(6, 8, Color.FromArgb(192, 135, 227, 255));
            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(135, 227, 255))), new Point(7, 8), new Point(12, 8));
            bmp.SetPixel(13, 8, Color.FromArgb(243, 135, 227, 255));
            bmp.SetPixel(14, 8, Color.FromArgb(64, 135, 227, 255));
            bmp.SetPixel(15, 8, Color.FromArgb(13, 135, 227, 255));

            g.Dispose();
            return bmp;
        }
    }
    #endregion

    #region ChainedGlossPainter
    /// <summary>
    /// Extending this class allows you to chain multiple IGlossPainters together.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IGlossPainter" />
    /// <seealso cref="System.IDisposable" />
	public abstract class ZeroitUltimateChainedGlossPainter : Component, IGlossPainter, IDisposable
    {
        /// <summary>
        /// The successor
        /// </summary>
        private IGlossPainter successor = null;

        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        /// <value>The successor.</value>
        /// <exception cref="ArgumentException">Gloss cannot eventually be it's own successor, an infinite loop will result</exception>
        [Category("Painters"), Description("Gets or sets the next gloss in the chain"), Browsable(true)]
        public IGlossPainter Successor
        {
            get { return successor; }
            set
            {
                IGlossPainter nextPainter = value;
                while (nextPainter != null && nextPainter is ZeroitUltimateChainedGlossPainter)
                {
                    if (object.ReferenceEquals(this, nextPainter))
                    {
                        throw new ArgumentException("Gloss cannot eventually be it's own successor, an infinite loop will result");
                    }
                    nextPainter = ((ZeroitUltimateChainedGlossPainter)nextPainter).Successor;
                }

                successor = value;
                if (successor != null)
                {
                    successor.PropertiesChanged += new EventHandler(successor_PropertiesChanged);
                }
                FireChange();
            }
        }
        /// <summary>
        /// Handles the PropertiesChanged event of the successor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void successor_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        protected void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Paints the gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintGloss(Rectangle box, Graphics g)
        {
            if (box.Width < 1) { return; }
            PaintThisGloss(box, g);
            if (successor != null) { successor.PaintGloss(box, g); }
        }

        /// <summary>
        /// Paints the this gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected abstract void PaintThisGloss(Rectangle box, Graphics g);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
            ResizeThis(box);
            if (successor != null) { successor.Resize(box); }
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected abstract void ResizeThis(Rectangle box);

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (successor != null) { successor.Dispose(); }
        }
    }
    #endregion

    #region ColorUtility
    /// <summary>
    /// Class ZeroitUltimateColorUtility.
    /// </summary>
	public class ZeroitUltimateColorUtility
    {
        /// <summary>
        /// Initializes static members of the <see cref="ZeroitUltimateColorUtility"/> class.
        /// </summary>
        static ZeroitUltimateColorUtility()
        {
        }

        /// <summary>
        /// Reverses the color.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        public static Color ReverseColor(Color c)
        {
            return Color.FromArgb(ReverseInt(c.R), ReverseInt(c.G), ReverseInt(c.B));
        }

        /// <summary>
        /// Reverses the int.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>System.Int32.</returns>
        private static int ReverseInt(int x)
        {
            int val = x - 255;
            if (val < 0) { val = val * -1; }
            return val;
        }

        /// <summary>
        /// To the hexadecimal string.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(Color c)
        {
            string hex = string.Empty;
            hex += DoHex(c.R);
            hex += DoHex(c.G);
            hex += DoHex(c.B);
            return "#" + hex;
        }

        /// <summary>
        /// Does the hexadecimal.
        /// </summary>
        /// <param name="xor">The xor.</param>
        /// <returns>System.String.</returns>
        private static string DoHex(int xor)
        {
            string hex = xor.ToString("x");
            if (xor < 16)
            {
                hex = "0" + hex;
            }
            if (xor == 0)
            {
                hex = "00";
            }
            return hex.ToUpper();
        }

        /// <summary>
        /// Des the hexadecimal.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.Int32.</returns>
        private static int DeHex(string input)
        {
            int val;
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string chunk = input.Substring(i, 1).ToUpper();
                switch (chunk)
                {
                    case "A":
                        val = 10; break;
                    case "B":
                        val = 11; break;
                    case "C":
                        val = 12; break;
                    case "D":
                        val = 13; break;
                    case "E":
                        val = 14; break;
                    case "F":
                        val = 15; break;
                    default:
                        val = int.Parse(chunk); break;
                }
                if (i == 0)
                {
                    result += val * 16;
                }
                else
                {
                    result += val;
                }
            }
            return result;
        }
    }

    // System.Drawing.Drawing2D.ColorBlend
    /// <summary>
    /// Class ColorBlender.
    /// </summary>
    public class ColorBlender
    {
        /// <summary>
        /// The colorleft
        /// </summary>
        private Color colorleft;
        /// <summary>
        /// The colorright
        /// </summary>
        private Color colorright;
        /// <summary>
        /// The steps
        /// </summary>
        private int steps;

        /// <summary>
        /// The step
        /// </summary>
        private float step;
        /// <summary>
        /// The stepsize
        /// </summary>
        private float stepsize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBlender"/> class.
        /// </summary>
        /// <param name="numberofsteps">The numberofsteps.</param>
        /// <param name="one">The one.</param>
        /// <param name="two">The two.</param>
        public ColorBlender(int numberofsteps, Color one, Color two)
        {
            steps = numberofsteps;
            colorleft = one;
            colorright = two;
            stepsize = 1.0f / Convert.ToSingle(steps);
            step = 0;
        }

        /// <summary>
        /// Determines whether this instance has next.
        /// </summary>
        /// <returns><c>true</c> if this instance has next; otherwise, <c>false</c>.</returns>
        public bool HasNext()
        {
            return step < 1;
        }

        /// <summary>
        /// Nexts this instance.
        /// </summary>
        /// <returns>Color.</returns>
        /// <exception cref="Exception">Past threshold.</exception>
        public Color Next()
        {
            if (!HasNext()) { throw new Exception("Past threshold."); }
            step += stepsize;
            return Morph(step, colorleft, colorright);
        }

        /// <summary>
        /// Morphes the specified ratio.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <returns>Color.</returns>
        public Color Morph(float ratio, Color c1, Color c2)
        {
            int r = (int)(c1.R + ratio * (c2.R - c1.R));
            int g = (int)(c1.G + ratio * (c2.G - c1.G));
            int b = (int)(c1.B + ratio * (c2.B - c1.B));
            return Color.FromArgb(r, g, b);
        }
    }

    /// <summary>
    /// Struct ColorRange
    /// </summary>
    public struct ColorRange
    {
        /// <summary>
        /// The light
        /// </summary>
        public Color Light;
        /// <summary>
        /// The lighter
        /// </summary>
        public Color Lighter;
        /// <summary>
        /// The base color
        /// </summary>
        public Color BaseColor;
        /// <summary>
        /// The dark
        /// </summary>
        public Color Dark;
        /// <summary>
        /// The darker
        /// </summary>
        public Color Darker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRange"/> struct.
        /// </summary>
        /// <param name="color">The color.</param>
        public ColorRange(Color color)
        {
            BaseColor = color;
            Light = ColorRange.Tint(0.6f, color);
            Lighter = ColorRange.Tint(0.3f, color);
            Dark = ColorRange.Shade(0.8f, color);
            Darker = ColorRange.Shade(0.6f, color);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRange"/> struct.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="lightratio">The lightratio.</param>
        /// <param name="lighterratio">The lighterratio.</param>
        public ColorRange(Color color, float lightratio, float lighterratio)
        {
            BaseColor = color;
            Light = ColorRange.Tint(lightratio, color);
            Lighter = ColorRange.Tint(lighterratio, color);
            Dark = ColorRange.Shade(lightratio, color);
            Darker = ColorRange.Shade(lighterratio, color);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRange"/> struct.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="lightratio">The lightratio.</param>
        /// <param name="lighterratio">The lighterratio.</param>
        /// <param name="darkratio">The darkratio.</param>
        /// <param name="darkerratio">The darkerratio.</param>
        public ColorRange(Color color, float lightratio, float lighterratio, float darkratio, float darkerratio)
        {
            BaseColor = color;
            Light = ColorRange.Tint(lightratio, color);
            Lighter = ColorRange.Tint(lighterratio, color);
            Dark = ColorRange.Shade(darkratio, color);
            Darker = ColorRange.Shade(darkerratio, color);
        }

        /// <summary>
        /// Tints the specified ratio.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        /// <param name="c1">The c1.</param>
        /// <returns>Color.</returns>
        public static Color Tint(float ratio, Color c1)
        {
            return Morph(ratio, Color.White, c1);
        }

        /// <summary>
        /// Shades the specified ratio.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        /// <param name="c1">The c1.</param>
        /// <returns>Color.</returns>
        public static Color Shade(float ratio, Color c1)
        {
            return Morph(ratio, Color.Black, c1);
        }

        /// <summary>
        /// Morphes the specified ratio.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <returns>Color.</returns>
        public static Color Morph(float ratio, Color c1, Color c2)
        {
            int r = (int)(c1.R + ratio * (c2.R - c1.R));
            int g = (int)(c1.G + ratio * (c2.G - c1.G));
            int b = (int)(c1.B + ratio * (c2.B - c1.B));
            return Color.FromArgb(r, g, b);
        }
    }

    /// <summary>
    /// Class ColorSet.
    /// </summary>
    public class ColorSet
    {
        /// <summary>
        /// The shade
        /// </summary>
        private bool shade;
        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// The factor
        /// </summary>
        private float factor;
        /// <summary>
        /// The colors
        /// </summary>
        private int colors;
        /// <summary>
        /// The range
        /// </summary>
        private Color[] range;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSet"/> class.
        /// </summary>
        /// <param name="shade">if set to <c>true</c> [shade].</param>
        /// <param name="color">The color.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="colors">The colors.</param>
        /// <exception cref="ArgumentException">
        /// Number of colors must be greater than 0.
        /// or
        /// Factor must be between 0 and 1.
        /// </exception>
        public ColorSet(bool shade, Color color, float factor, int colors)
        {
            if (colors < 1) { throw new ArgumentException("Number of colors must be greater than 0."); }
            if (factor < 0 || factor > 1) { throw new ArgumentException("Factor must be between 0 and 1."); }
            this.shade = shade;
            this.color = color;
            this.factor = factor;
            this.colors = colors;
            Build();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            this.range = new Color[colors];
            Color current = color;
            range[0] = current;
            for (int i = 1; i < colors; i++)
            {
                if (shade)
                {
                    range[i] = ColorRange.Shade(factor, current);
                }
                else
                {
                    range[i] = ColorRange.Tint(factor, current);
                }
                current = range[i];
            }
        }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public Color[] Colors
        {
            get { return range; }
        }
    }

    /// <summary>
    /// Class BlendSet.
    /// </summary>
    public class BlendSet
    {
        /// <summary>
        /// The color1
        /// </summary>
        private Color color1;
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2;
        /// <summary>
        /// The factor
        /// </summary>
        private float factor;
        /// <summary>
        /// The colors
        /// </summary>
        private int colors;
        /// <summary>
        /// The range
        /// </summary>
        private Color[] range;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlendSet"/> class.
        /// </summary>
        /// <param name="one">The one.</param>
        /// <param name="two">The two.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="colors">The colors.</param>
        /// <exception cref="ArgumentException">
        /// Number of colors must be greater than 0.
        /// or
        /// Factor must be between 0 and 1.
        /// </exception>
        public BlendSet(Color one, Color two, float factor, int colors)
        {
            if (colors < 1) { throw new ArgumentException("Number of colors must be greater than 0."); }
            if (factor < 0 || factor > 1) { throw new ArgumentException("Factor must be between 0 and 1."); }
            this.color1 = one;
            this.color2 = two;
            this.factor = factor;
            this.colors = colors;
            Build();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            this.range = new Color[colors];
            Color current = color1;
            range[0] = current;
            for (int i = 1; i < colors; i++)
            {
                range[i] = ColorRange.Morph(factor, current, color2);
                current = range[i];
            }
        }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public Color[] Colors
        {
            get { return range; }
        }
    }
    #endregion

    #region DualProgressBar
    /// <summary>
    /// Class ZeroitUltimateDualProgressBar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateProgressBarEx" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateDualProgressBar), "Resources.DualProgressBar.ico")]
    public class ZeroitUltimateDualProgressBar : ZeroitUltimateProgressBarEx
    {
        /// <summary>
        /// The masterval
        /// </summary>
        private int masterval = 0;
        /// <summary>
        /// The mastermax
        /// </summary>
        private int mastermax = 100;
        /// <summary>
        /// The masterpainter
        /// </summary>
        private IProgressPainter masterpainter;
        /// <summary>
        /// The master bottom
        /// </summary>
        private bool masterBottom = false;
        /// <summary>
        /// The masterbox
        /// </summary>
        private Rectangle masterbox;
        /// <summary>
        /// The padding
        /// </summary>
        private int padding = 0;

        /// <summary>
        /// The on master value changed
        /// </summary>
        protected EventHandler OnMasterValueChanged;
        /// <summary>
        /// Occurs when [master value changed].
        /// </summary>
        public event EventHandler MasterValueChanged
        {
            add
            {
                if (OnMasterValueChanged != null)
                {
                    foreach (Delegate d in OnMasterValueChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                OnMasterValueChanged = (EventHandler)Delegate.Combine(OnMasterValueChanged, value);
            }
            remove { OnMasterValueChanged = (EventHandler)Delegate.Remove(OnMasterValueChanged, value); }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Progress"), Description("Gets or sets the maximum value"), Browsable(true)]
        public override int Maximum
        {
            get { return base.maximum; }
            set
            {
                base.Maximum = value;
                mastermax = value;
            }
        }

        /// <summary>
        /// Gets or sets the master value.
        /// </summary>
        /// <value>The master value.</value>
        [Category("Progress"), Description("Gets or sets the value of the master progress"), Browsable(true)]
        public int MasterValue
        {
            get { return this.masterval; }
            set
            {
                this.masterval = value;
                if (OnMasterValueChanged != null)
                {
                    OnMasterValueChanged(this, EventArgs.Empty);
                }
                ResizeMasterProgress();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the master maximum.
        /// </summary>
        /// <value>The master maximum.</value>
        [Category("Progress"), Description("Gets or sets the maximum value for the master progress"), Browsable(true)]
        public int MasterMaximum
        {
            get { return mastermax; }
            set
            {
                this.mastermax = value;
                ResizeMasterProgress();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the master progress padding.
        /// </summary>
        /// <value>The master progress padding.</value>
        [Category("Progress"), Description("Gets or sets the padding for the master progress"), Browsable(true)]
        public int MasterProgressPadding
        {
            get { return this.padding; }
            set
            {
                this.padding = value;
                if (OnValueChanged != null)
                {
                    OnValueChanged(this, EventArgs.Empty);
                }
                ResizeMasterProgress();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the master painter.
        /// </summary>
        /// <value>The master painter.</value>
        [Category("Painters"), Description("Paints this progress bar's master progress"), Browsable(true)]
        public IProgressPainter MasterPainter
        {
            get { return this.masterpainter; }
            set
            {
                this.masterpainter = value;
                if (this.masterpainter is ZeroitUltimateAbstractProgressPainter)
                {
                    ((ZeroitUltimateAbstractProgressPainter)this.masterpainter).padding = base.ProgressPadding;
                }
                this.masterpainter.PropertiesChanged += new EventHandler(component_PropertiesChanged);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [paint master first].
        /// </summary>
        /// <value><c>true</c> if [paint master first]; otherwise, <c>false</c>.</value>
        [Category("Progress"), Description("Determines whether or not the master progress is painted under the main progress"), Browsable(true)]
        public bool PaintMasterFirst
        {
            get { return this.masterBottom; }
            set
            {
                this.masterBottom = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeProgress();
            ResizeMasterProgress();
            if (this.backgroundpainter != null) { this.backgroundpainter.Resize(borderbox); }
            if (masterBottom && this.masterpainter != null) { this.masterpainter.Resize(masterbox); }
            if (this.progresspainter != null) { this.progresspainter.Resize(borderbox); }
            if (!masterBottom && this.masterpainter != null) { this.masterpainter.Resize(masterbox); }
            if (this.borderpainter != null) { this.borderpainter.Resize(borderbox); }
        }

        /// <summary>
        /// Resizes the master progress.
        /// </summary>
        private void ResizeMasterProgress()
        {
            Rectangle newprog = base.borderbox;
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);
            base.backbox = newprog;

            int val = masterval; if (val > 0) { val++; }
            int progWidth = mastermax > 0 ? (backbox.Width * val / mastermax) : 1;
            if (value >= mastermax && mastermax > 0)
            {
                progWidth = backbox.Width;
            } /*else if (value > 0) {
				progWidth++;
			}*/
              //newprog = new Rectangle(backbox.X + base.ProgressPadding, backbox.Y + base.ProgressPadding, progWidth - (base.ProgressPadding * 2), backbox.Height - (base.ProgressPadding * 2));
              //newprog = new Rectangle(backbox.X, backbox.Y, progWidth, backbox.Height);
            newprog = new Rectangle(backbox.X + this.padding, backbox.Y + this.padding, progWidth - (this.padding * 2), backbox.Height - (this.padding * 2));
            masterbox = newprog;
        }

        ///// <summary></summary>
        //protected override void MarqueeStart() {
        //}
        ///// <summary></summary>
        //protected override void MarqueePause() {
        //}
        ///// <summary></summary>
        //protected override void MarqueeStop() {
        //}

        /// <summary>
        /// Paints the progress.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void PaintProgress(Graphics g)
        {
            if (this.progresspainter != null)
            {
                if (masterBottom && this.masterpainter != null)
                {
                    this.masterpainter.PaintProgress(masterbox, g);
                }
                this.progresspainter.PaintProgress(progressbox, g);
                if (!masterBottom && this.masterpainter != null)
                {
                    this.masterpainter.PaintProgress(masterbox, g);
                }
            }
        }
    }
    #endregion

    #region FlatGlossPainter
    /// <summary>
    /// Class ZeroitUltimateFlatGlossPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateChainedGlossPainter" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateFlatGlossPainter), "Resources.FlatGlossPainter.ico")]
    public class ZeroitUltimateFlatGlossPainter : ZeroitUltimateChainedGlossPainter
    {
        /// <summary>
        /// The style
        /// </summary>
        private GlossStyle style = GlossStyle.Bottom;
        /// <summary>
        /// The percent
        /// </summary>
        private int percent = 50;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.White;
        /// <summary>
        /// The alpha
        /// </summary>
        private int alpha = 128;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category("Appearance"), Description("Gets or sets the style for this progress gloss"), Browsable(true)]
        public GlossStyle Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the percentage covered.
        /// </summary>
        /// <value>The percentage covered.</value>
        /// <exception cref="ArgumentException">Percentage value must be between 0 and 100.</exception>
        [Category("Appearance"), Description("Gets or sets the percentage of surface this gloss should cover"), Browsable(true)]
        public int PercentageCovered
        {
            get { return this.percent; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Percentage value must be between 0 and 100.");
                }
                this.percent = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets color to gloss"), Browsable(true)]
        public Color Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        /// <value>The alpha.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the alpha value"), Browsable(true)]
        public int Alpha
        {
            get { return this.alpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.alpha = value;
                box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisGloss(Rectangle box, Graphics g)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
            }

            int y = (int)(((float)box.Height * (float)percent) / 100f);
            if (box.Y + y > box.Height) { y = box.Height; }

            Rectangle cover = box;
            switch (style)
            {
                case GlossStyle.Bottom:
                    int start = box.Height + box.Y - y;
                    cover = new Rectangle(box.X, start, box.Width, box.Bottom - start);
                    break;
                case GlossStyle.Top:
                    cover = new Rectangle(box.X, box.Y, box.Width, y + 1);
                    break;
                case GlossStyle.Both:
                    cover = box;
                    break;
            }

            Color ccv = Color.FromArgb(alpha, color.R, color.G, color.B);
            brush = new SolidBrush(ccv);
            g.FillRectangle(brush, cover);
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (brush != null) { brush.Dispose(); }
        }
    }
    #endregion

    #region FruityLoopsBackgroundPainter
    /// <summary>
    /// Class ZeroitUltimateFruityLoopsBackgroundPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBackgroundPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateFruityLoopsBackgroundPainter), "Resources.FruityLoopsBackgroundPainter.ico")]
    public class ZeroitUltimateFruityLoopsBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable
    {
        /// <summary>
        /// The gloss
        /// </summary>
        private IGlossPainter gloss;
        /// <summary>
        /// The type
        /// </summary>
        private ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType type;
        /// <summary>
        /// The img
        /// </summary>
        private Image img;

        /// <summary>
        /// The off lit
        /// </summary>
        private Color OffLit = Color.FromArgb(49, 69, 74);
        /// <summary>
        /// The p off lit
        /// </summary>
        private Pen pOffLit; // = new Pen(new SolidBrush(OffLit),1f);
        /// <summary>
        /// The off lit top
        /// </summary>
        private Color OffLitTop = Color.FromArgb(66, 85, 90);
        /// <summary>
        /// The p off lit top
        /// </summary>
        private Pen pOffLitTop; // = new Pen(new SolidBrush(OffLitTop),1f);
        /// <summary>
        /// The off lit bot
        /// </summary>
        private Color OffLitBot = Color.FromArgb(24, 48, 49);
        /// <summary>
        /// The p off lit bot
        /// </summary>
        private Pen pOffLitBot; // = new Pen(new SolidBrush(OffLitBot),1f);

        /// <summary>
        /// The off mid
        /// </summary>
        private Color OffMid = Color.FromArgb(24, 48, 49);
        /// <summary>
        /// The p off mid
        /// </summary>
        private Pen pOffMid; // = new Pen(new SolidBrush(OffMid),1f);
        /// <summary>
        /// The off mid top
        /// </summary>
        private Color OffMidTop = Color.FromArgb(24, 48, 49);
        /// <summary>
        /// The p off mid top
        /// </summary>
        private Pen pOffMidTop; // = new Pen(new SolidBrush(OffMidTop),1f);
        /// <summary>
        /// The off mid bot
        /// </summary>
        private Color OffMidBot = Color.FromArgb(8, 28, 24);
        /// <summary>
        /// The p off mid bot
        /// </summary>
        private Pen pOffMidBot; // = new Pen(new SolidBrush(OffMidBot),1f);

        /// <summary>
        /// The off DRK
        /// </summary>
        private Color OffDrk = Color.FromArgb(0, 24, 24);
        /// <summary>
        /// The p off DRK
        /// </summary>
        private Pen pOffDrk; // = new Pen(new SolidBrush(OffDrk),1f);
        /// <summary>
        /// The off DRK top
        /// </summary>
        private Color OffDrkTop = Color.FromArgb(8, 28, 24);
        /// <summary>
        /// The p off DRK top
        /// </summary>
        private Pen pOffDrkTop; // = new Pen(new SolidBrush(OffDrkTop),1f);
        /// <summary>
        /// The off DRK bot
        /// </summary>
        private Color OffDrkBot = Color.FromArgb(0, 16, 16);
        /// <summary>
        /// The p off DRK bot
        /// </summary>
        private Pen pOffDrkBot; // = new Pen(new SolidBrush(OffDrkBot),1f);

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        [Category("Painters"), Description("Gets or sets the chain of gloss painters"), Browsable(true)]
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the type of the fruity.
        /// </summary>
        /// <value>The type of the fruity.</value>
        [Category("Appearance"), Description("Gets or sets the type of FruityLoops progress style"), Browsable(true)]
        public ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType FruityType
        {
            get { return type; }
            set
            {
                type = value;
                if (type == ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType.DoubleLayer)
                {
                    OffLit = Color.FromArgb(49, 69, 74);
                    pOffLit = new Pen(new SolidBrush(OffLit), 1f);
                    OffLitTop = Color.FromArgb(57, 77, 82);
                    pOffLitTop = new Pen(new SolidBrush(OffLitTop), 1f);
                    OffLitBot = Color.FromArgb(24, 48, 49);
                    pOffLitBot = new Pen(new SolidBrush(OffLitBot), 1f);

                    OffDrk = Color.FromArgb(24, 48, 49);
                    pOffDrk = new Pen(new SolidBrush(OffDrk), 1f);
                    OffDrkTop = Color.FromArgb(16, 40, 41);
                    pOffDrkTop = new Pen(new SolidBrush(OffDrkTop), 1f);
                    OffDrkBot = Color.FromArgb(8, 18, 24);
                    pOffDrkBot = new Pen(new SolidBrush(OffDrkBot), 1f);
                }
                else if (type == ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType.TripleLayer)
                {
                    OffLit = Color.FromArgb(49, 69, 74);
                    pOffLit = new Pen(new SolidBrush(OffLit), 1f);
                    OffLitTop = Color.FromArgb(66, 85, 90);
                    pOffLitTop = new Pen(new SolidBrush(OffLitTop), 1f);
                    OffLitBot = Color.FromArgb(24, 48, 49);
                    pOffLitBot = new Pen(new SolidBrush(OffLitBot), 1f);

                    OffMid = Color.FromArgb(24, 48, 49);
                    pOffMid = new Pen(new SolidBrush(OffMid), 1f);
                    OffMidTop = Color.FromArgb(24, 48, 49);
                    pOffMidTop = new Pen(new SolidBrush(OffMidTop), 1f);
                    OffMidBot = Color.FromArgb(8, 28, 24);
                    pOffMidBot = new Pen(new SolidBrush(OffMidBot), 1f);

                    OffDrk = Color.FromArgb(0, 24, 24);
                    pOffDrk = new Pen(new SolidBrush(OffDrk), 1f);
                    OffDrkTop = Color.FromArgb(8, 28, 24);
                    pOffDrkTop = new Pen(new SolidBrush(OffDrkTop), 1f);
                    OffDrkBot = Color.FromArgb(0, 16, 16);
                    pOffDrkBot = new Pen(new SolidBrush(OffDrkBot), 1f);
                }
                FireChange();
            }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBackground(Rectangle box, Graphics g)
        {
            if (img == null)
            {
                if (type == ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType.DoubleLayer)
                {
                    PaintDouble(box, g);
                }
                else if (type == ZeroitUltimateFruityLoopsProgressPainter.FruityLoopsProgressType.TripleLayer)
                {
                    PaintTriple(box, g);
                }
            }
            g.DrawImageUnscaled(img, 0, 0);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Paints the double.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        protected virtual void PaintDouble(Rectangle r, Graphics g)
        {
            bool lite = true;
            img = new Bitmap(r.Width + 1, r.Height + 1);
            Graphics gi = Graphics.FromImage(img);

            for (int i = 1; i < r.Width + 1; i++)
            {
                if (lite)
                {
                    gi.DrawLine(pOffLitTop, i, r.Y, i, r.Y + 1);
                    gi.DrawLine(pOffLitBot, i, r.Height, i, r.Height - 1);
                    gi.DrawLine(pOffLit, i, r.Y + 1, i, r.Height - 1);
                }
                else
                {
                    gi.DrawLine(pOffDrkTop, i, r.Y, i, r.Y + 1);
                    gi.DrawLine(pOffDrkBot, i, r.Height, i, r.Height - 1);
                    gi.DrawLine(pOffDrk, i, r.Y + 1, i, r.Height - 1);
                }
                lite = !lite;
            }
            gi.Dispose();
        }

        /// <summary>
        /// Paints the triple.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        protected virtual void PaintTriple(Rectangle r, Graphics g)
        {
            int lite = 1;
            img = new Bitmap(r.Width + 1, r.Height + 1);
            Graphics gi = Graphics.FromImage(img);

            for (int i = 1; i < r.Width + 1; i++)
            {
                if (lite == 2)
                {
                    gi.DrawLine(pOffLitTop, i, r.Y, i, r.Y + 1);
                    gi.DrawLine(pOffLitBot, i, r.Height, i, r.Height - 1);
                    gi.DrawLine(pOffLit, i, r.Y + 1, i, r.Height - 1);
                    lite = 0;
                }
                else if (lite == 1)
                {
                    gi.DrawLine(pOffMidTop, i, r.Y, i, r.Y + 1);
                    gi.DrawLine(pOffMidBot, i, r.Height, i, r.Height - 1);
                    gi.DrawLine(pOffMid, i, r.Y + 1, i, r.Height - 1);
                    lite = 2;
                }
                else if (lite == 0)
                {
                    gi.DrawLine(pOffDrkTop, i, r.Y, i, r.Y + 1);
                    gi.DrawLine(pOffDrkBot, i, r.Height, i, r.Height - 1);
                    gi.DrawLine(pOffDrk, i, r.Y + 1, i, r.Height - 1);
                    lite = 1;
                }
            }
            gi.Dispose();
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
            img = null;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (img != null) { img.Dispose(); }

            if (pOffLit != null) { pOffLit.Dispose(); }
            if (pOffLitTop != null) { pOffLitTop.Dispose(); }
            if (pOffLitBot != null) { pOffLitBot.Dispose(); }
            if (pOffMid != null) { pOffMid.Dispose(); }
            if (pOffMidTop != null) { pOffMidTop.Dispose(); }
            if (pOffMidBot != null) { pOffMidBot.Dispose(); }
            if (pOffDrk != null) { pOffDrk.Dispose(); }
            if (pOffDrkTop != null) { pOffDrkTop.Dispose(); }
            if (pOffDrkBot != null) { pOffDrkBot.Dispose(); }
        }
    }
    #endregion

    #region FruityLoopsProgressPainter
    /// <summary>
    /// Class ZeroitUltimateFruityLoopsProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateFruityLoopsProgressPainter), "Resources.FruityLoopsProgressPainter.ico")]
    public class ZeroitUltimateFruityLoopsProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The type
        /// </summary>
        private FruityLoopsProgressType type;

        /// <summary>
        /// The on lit
        /// </summary>
        private Color OnLit = Color.FromArgb(148, 170, 173);
        /// <summary>
        /// The p on lit
        /// </summary>
        private Pen pOnLit; // = new Pen(new SolidBrush(OnLit),1f);
        /// <summary>
        /// The on lit top
        /// </summary>
        private Color OnLitTop = Color.FromArgb(206, 227, 231);
        /// <summary>
        /// The p on lit top
        /// </summary>
        private Pen pOnLitTop; // = new Pen(new SolidBrush(OnLitTop),1f);
        /// <summary>
        /// The on lit bot
        /// </summary>
        private Color OnLitBot = Color.FromArgb(90, 117, 123);
        /// <summary>
        /// The p on lit bot
        /// </summary>
        private Pen pOnLitBot; // = new Pen(new SolidBrush(OnLitBot),1f);

        /// <summary>
        /// The on mid
        /// </summary>
        private Color OnMid = Color.FromArgb(107, 130, 132);
        /// <summary>
        /// The p on mid
        /// </summary>
        private Pen pOnMid; // = new Pen(new SolidBrush(OnMid),1f);
        /// <summary>
        /// The on mid top
        /// </summary>
        private Color OnMidTop = Color.FromArgb(140, 154, 156);
        /// <summary>
        /// The p on mid top
        /// </summary>
        private Pen pOnMidTop; // = new Pen(new SolidBrush(OnMidTop),1f);
        /// <summary>
        /// The on mid bot
        /// </summary>
        private Color OnMidBot = Color.FromArgb(57, 85, 82);
        /// <summary>
        /// The p on mid bot
        /// </summary>
        private Pen pOnMidBot; // = new Pen(new SolidBrush(OnMidBot),1f);

        /// <summary>
        /// The on DRK
        /// </summary>
        private Color OnDrk = Color.FromArgb(57, 85, 82);
        /// <summary>
        /// The p on DRK
        /// </summary>
        private Pen pOnDrk; // = new Pen(new SolidBrush(OnDrk),1f);
        /// <summary>
        /// The on DRK top
        /// </summary>
        private Color OnDrkTop = Color.FromArgb(107, 125, 123);
        /// <summary>
        /// The p on DRK top
        /// </summary>
        private Pen pOnDrkTop; // = new Pen(new SolidBrush(OnDrkTop),1f);
        /// <summary>
        /// The on DRK bot
        /// </summary>
        private Color OnDrkBot = Color.FromArgb(33, 60, 66);
        /// <summary>
        /// The p on DRK bot
        /// </summary>
        private Pen pOnDrkBot; // = new Pen(new SolidBrush(OnDrkBot),1f);

        /// <summary>
        /// Gets or sets the type of the fruity.
        /// </summary>
        /// <value>The type of the fruity.</value>
        [Category("Appearance"), Description("Gets or sets the type of FruityLoops progress style"), Browsable(true)]
        public FruityLoopsProgressType FruityType
        {
            get { return type; }
            set
            {
                type = value;
                if (type == FruityLoopsProgressType.DoubleLayer)
                {
                    OnLit = Color.FromArgb(148, 170, 173);
                    pOnLit = new Pen(new SolidBrush(OnLit), 1f);
                    OnLitTop = Color.FromArgb(206, 227, 231);
                    pOnLitTop = new Pen(new SolidBrush(OnLitTop), 1f);
                    OnLitBot = Color.FromArgb(90, 113, 115);
                    pOnLitBot = new Pen(new SolidBrush(OnLitBot), 1f);

                    OnDrk = Color.FromArgb(115, 142, 148);
                    pOnDrk = new Pen(new SolidBrush(OnDrk), 1f);
                    OnDrkTop = Color.FromArgb(181, 199, 198);
                    pOnDrkTop = new Pen(new SolidBrush(OnDrkTop), 1f);
                    OnDrkBot = Color.FromArgb(66, 89, 90);
                    pOnDrkBot = new Pen(new SolidBrush(OnDrkBot), 1f);
                }
                else if (type == FruityLoopsProgressType.TripleLayer)
                {
                    OnLit = Color.FromArgb(148, 170, 173);
                    pOnLit = new Pen(new SolidBrush(OnLit), 1f);
                    OnLitTop = Color.FromArgb(206, 227, 231);
                    pOnLitTop = new Pen(new SolidBrush(OnLitTop), 1f);
                    OnLitBot = Color.FromArgb(90, 117, 123);
                    pOnLitBot = new Pen(new SolidBrush(OnLitBot), 1f);

                    OnMid = Color.FromArgb(107, 130, 132);
                    pOnMid = new Pen(new SolidBrush(OnMid), 1f);
                    OnMidTop = Color.FromArgb(140, 154, 156);
                    pOnMidTop = new Pen(new SolidBrush(OnMidTop), 1f);
                    OnMidBot = Color.FromArgb(57, 85, 82);
                    pOnMidBot = new Pen(new SolidBrush(OnMidBot), 1f);

                    OnDrk = Color.FromArgb(57, 85, 82);
                    pOnDrk = new Pen(new SolidBrush(OnDrk), 1f);
                    OnDrkTop = Color.FromArgb(107, 125, 123);
                    pOnDrkTop = new Pen(new SolidBrush(OnDrkTop), 1f);
                    OnDrkBot = Color.FromArgb(33, 60, 66);
                    pOnDrkBot = new Pen(new SolidBrush(OnDrkBot), 1f);
                }
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Height -= 1;
            }
            catch { }

            if (box.Width <= 1) { return; }
            if (type == FruityLoopsProgressType.DoubleLayer)
            {
                PaintDouble(box, g);
            }
            else if (type == FruityLoopsProgressType.TripleLayer)
            {
                PaintTriple(box, g);
            }

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Paints the double.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        private void PaintDouble(Rectangle r, Graphics g)
        {
            bool lite = true;

            Brush b = new SolidBrush(pOnLit.Color);
            g.FillRectangle(b, r);
            g.DrawLine(pOnLitTop, r.X, r.Y, r.Right - 1, r.Y);
            g.DrawLine(pOnLitBot, r.X, r.Bottom, r.Right - 1, r.Bottom);
            for (int i = r.X; i < r.Right; i++)
            {
                if (lite)
                {
                    //g.DrawLine(off ? pOffLitTop : pOnLitTop, i, r.Y, i, r.Y + 1);
                    //g.DrawLine(off ? pOffLitBot : pOnLitBot, i, r.Height, i, r.Height - 1);
                    //g.DrawLine(off ? pOffLit : pOnLit, i, r.Y + 1, i, r.Height - 1);
                }
                else
                {
                    g.DrawLine(pOnDrkTop, i, r.Y, i, r.Y + 1);
                    g.DrawLine(pOnDrkBot, i, r.Bottom, i, r.Bottom - 1);
                    g.DrawLine(pOnDrk, i, r.Y + 1, i, r.Bottom - 1);
                }
                lite = !lite;
            }
        }

        /// <summary>
        /// Paints the triple.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        private void PaintTriple(Rectangle r, Graphics g)
        {
            int lite = 1;

            Brush b = new SolidBrush(pOnMid.Color);
            g.FillRectangle(b, r);
            g.DrawLine(pOnMidTop, r.X, r.Y, r.Right - 1, r.Y);
            g.DrawLine(pOnMidBot, r.X, r.Bottom, r.Right - 1, r.Bottom);
            for (int i = r.X; i < r.Right; i++)
            {
                if (lite == 2)
                {
                    g.DrawLine(pOnLitTop, i, r.Y, i, r.Y + 1);
                    g.DrawLine(pOnLitBot, i, r.Bottom, i, r.Bottom - 1);
                    g.DrawLine(pOnLit, i, r.Y + 1, i, r.Bottom - 1);
                    lite = 0;
                }
                else if (lite == 1)
                {
                    //g.DrawLine(pOnMidTop, i, r.Y, i, r.Y + 1);
                    //g.DrawLine(pOnMidBot, i, r.Height, i, r.Height - 1);
                    //g.DrawLine(pOnMid, i, r.Y + 1, i, r.Height - 1);
                    lite = 2;
                }
                else if (lite == 0)
                {
                    g.DrawLine(pOnDrkTop, i, r.Y, i, r.Y + 1);
                    g.DrawLine(pOnDrkBot, i, r.Bottom, i, r.Bottom - 1);
                    g.DrawLine(pOnDrk, i, r.Y + 1, i, r.Bottom - 1);
                    lite = 1;
                }
            }
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            if (pOnLit != null) { pOnLit.Dispose(); }
            if (pOnLitTop != null) { pOnLitTop.Dispose(); }
            if (pOnLitBot != null) { pOnLitBot.Dispose(); }
            if (pOnMid != null) { pOnMid.Dispose(); }
            if (pOnMidTop != null) { pOnMidTop.Dispose(); }
            if (pOnMidBot != null) { pOnMidBot.Dispose(); }
            if (pOnDrk != null) { pOnDrk.Dispose(); }
            if (pOnDrkTop != null) { pOnDrkTop.Dispose(); }
            if (pOnDrkBot != null) { pOnDrkBot.Dispose(); }
        }

        /// <summary>
        /// Enum representing the type of Fruity Loops Progress 
        /// </summary>
        public enum FruityLoopsProgressType
        {
            /// <summary>
            /// The double layer
            /// </summary>
            DoubleLayer,
            /// <summary>
            /// The triple layer
            /// </summary>
            TripleLayer
        }
    }
    #endregion

    #region GradientBackgroundPainter
    /// <summary>
    /// Class ZeroitUltimateGradientBackgroundPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBackgroundPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateGradientBackgroundPainter), "Resources.GradientBackgroundPainter.ico")]
    public class ZeroitUltimateGradientBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable
    {
        /// <summary>
        /// The top
        /// </summary>
        private Color top;
        /// <summary>
        /// The bottom
        /// </summary>
        private Color bottom;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;
        /// <summary>
        /// The gloss
        /// </summary>
        private IGlossPainter gloss;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateGradientBackgroundPainter"/> class.
        /// </summary>
        public ZeroitUltimateGradientBackgroundPainter()
        {
            this.top = Color.FromArgb(240, 240, 240);
            this.bottom = Color.FromArgb(224, 224, 224);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateGradientBackgroundPainter"/> class.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="bottom">The bottom.</param>
        public ZeroitUltimateGradientBackgroundPainter(Color top, Color bottom)
        {
            this.top = top;
            this.bottom = bottom;
        }

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        [Category("Painters"), Description("Gets or sets the chain of gloss painters"), Browsable(true)]
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color of the top.
        /// </summary>
        /// <value>The color of the top.</value>
        [Category("Appearance"), Description("Gets or sets the top gradient color"), Browsable(true)]
        public Color TopColor
        {
            get { return top; }
            set { top = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets the color of the bottom.
        /// </summary>
        /// <value>The color of the bottom.</value>
        [Category("Appearance"), Description("Gets or sets the bottom gradient color"), Browsable(true)]
        public Color BottomColor
        {
            get { return bottom; }
            set { bottom = value; FireChange(); }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBackground(Rectangle box, Graphics g)
        {
            Resize(box);
            g.FillRectangle(brush, box);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
            brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, box.Height), bottom, top);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (brush != null) { brush.Dispose(); }
        }
    }
    #endregion

    #region GradientGlossPainter
    /// <summary>
    /// Class ZeroitUltimateGradientGlossPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateChainedGlossPainter" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateGradientGlossPainter), "Resources.GradientGlossPainter.ico")]
    public class ZeroitUltimateGradientGlossPainter : ZeroitUltimateChainedGlossPainter
    {
        /// <summary>
        /// The style
        /// </summary>
        private GlossStyle style = GlossStyle.Bottom;
        /// <summary>
        /// The percent
        /// </summary>
        private int percent = 50;
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.White;
        /// <summary>
        /// The high alpha
        /// </summary>
        private int highAlpha = 240;
        /// <summary>
        /// The low alpha
        /// </summary>
        private int lowAlpha = 0;
        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90f;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category("Appearance"), Description("Gets or sets the style for this progress gloss"), Browsable(true)]
        public GlossStyle Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the percentage covered.
        /// </summary>
        /// <value>The percentage covered.</value>
        [Category("Appearance"), Description("Gets or sets the percentage of surface this gloss should cover"), Browsable(true)]
        public int PercentageCovered
        {
            get { return this.percent; }
            set
            {
                this.percent = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets color to gloss"), Browsable(true)]
        public Color Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha high.
        /// </summary>
        /// <value>The alpha high.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the high alpha value"), Browsable(true)]
        public int AlphaHigh
        {
            get { return this.highAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.highAlpha = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha low.
        /// </summary>
        /// <value>The alpha low.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the low alpha value"), Browsable(true)]
        public int AlphaLow
        {
            get { return this.lowAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.lowAlpha = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        [Category("Blending"), Description("Gets or sets angle for the gradient"), Browsable(true)]
        public float Angle
        {
            get { return this.angle; }
            set
            {
                this.angle = value;
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisGloss(Rectangle box, Graphics g)
        {
            int y = (int)(((float)box.Height * (float)percent) / 100f);
            if (box.Y + y > box.Height) { y = box.Height; }

            Rectangle cover = box;
            switch (style)
            {
                case GlossStyle.Bottom:
                    int start = box.Height + box.Y - y;
                    cover = new Rectangle(box.X, start - 1, box.Width /*- 1*/, box.Bottom - start);
                    break;
                case GlossStyle.Top:
                    cover = new Rectangle(box.X, box.Y - 1, box.Width /*- 1*/, y + 2);
                    break;
                case GlossStyle.Both:
                    cover = box;
                    break;
            }

            Color hcolor = Color.FromArgb(highAlpha, color.R, color.G, color.B);
            Color lcolor = Color.FromArgb(lowAlpha, color.R, color.G, color.B);
            brush = new LinearGradientBrush(cover, hcolor, lcolor, angle, true);
            g.FillRectangle(brush, cover);
            //g.DrawRectangle(Pens.Red, cover);
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (brush != null) { brush.Dispose(); }
        }
    }
    #endregion

    #region HSV
    /// <summary>
    /// Struct ZeroitUltimateHSV
    /// </summary>
    public struct ZeroitUltimateHSV
    {
        /// <summary>
        /// The hue
        /// </summary>
        private int hue;
        /// <summary>
        /// The sat
        /// </summary>
        private int sat;
        /// <summary>
        /// The value
        /// </summary>
        private int val;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateHSV"/> struct.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="v">The v.</param>
        public ZeroitUltimateHSV(int h, int s, int v)
        {
            hue = h;
            sat = s;
            val = v;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateHSV"/> struct.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimateHSV(Color color)
        {
            hue = 0;
            sat = 0;
            val = 0;
            FromRGB(color);
        }

        /// <summary>
        /// Froms the HSV.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="s">The s.</param>
        /// <param name="v">The v.</param>
        /// <returns>Color.</returns>
        public static Color FromHsv(int h, int s, int v)
        {
            ZeroitUltimateHSV hsv = new ZeroitUltimateHSV(h, s, v);
            return hsv.Color;
        }

        /// <summary>
        /// Gets or sets the hue.
        /// </summary>
        /// <value>The hue.</value>
        public int Hue
        {
            get { return hue; }
            set { hue = value; }
        }

        /// <summary>
        /// Gets or sets the saturation.
        /// </summary>
        /// <value>The saturation.</value>
        public int Saturation
        {
            get { return sat; }
            set { sat = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return val; }
            set { val = value; }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get { return ToRGB(); }
            set { FromRGB(value); }
        }

        /// <summary>
        /// Froms the RGB.
        /// </summary>
        /// <param name="color">The color.</param>
        private void FromRGB(Color color)
        {
            /*
			if (max = min)
				h = 0
			if (max = r)
				h = (60deg * (g-b)/(max-min) + 0deg) % 360deg
			if (max = g)
				h = (60deg * (b-r)/(max-min) + 120deg)
			if (max = b)
				h = (60deg * (r-g)/(max-min) + 240deg)
			
			if (max = 0)
				s = 0
			else
				s = 1 - min/max
			
			v = max
			*/

            double min;
            double max;
            double delta;

            double r = (double)color.R / 255D;
            double g = (double)color.G / 255D;
            double b = (double)color.B / 255D;

            double h;
            double s;
            double v;

            min = System.Math.Min(System.Math.Min(r, g), b);
            max = System.Math.Max(System.Math.Max(r, g), b);
            v = max;
            delta = max - min;
            if (max == 0 || delta == 0)
            {
                s = 0;
                h = 0;
            }
            else
            {
                s = delta / max;
                if (r == max)
                {
                    h = (60D * ((g - b) / delta)) % 360D;
                }
                else if (g == max)
                {
                    h = 60D * ((b - r) / delta) + 120D;
                }
                else
                {
                    h = 60D * ((r - g) / delta) + 240D;
                }
            }
            if (h < 0)
            {
                h += 360D;
            }

            Hue = (int)(h / 360D * 255D);
            Saturation = (int)(s * 255D);
            Value = (int)(v * 255D);
        }
        /// <summary>
        /// To the RGB.
        /// </summary>
        /// <returns>Color.</returns>
        private Color ToRGB()
        {
            double h;
            double s;
            double v;

            double r = 0;
            double g = 0;
            double b = 0;

            // Scale Hue to be between 0 and 360. Saturation
            // and value scale to be between 0 and 1.
            h = ((double)Hue / 255D * 360D) % 360D;
            s = (double)Saturation / 255D;
            v = (double)Value / 255D;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                double p;
                double q;
                double t;

                double fractionalSector;
                int sectorNumber;
                double sectorPos;

                sectorPos = h / 60D;
                sectorNumber = (int)(System.Math.Floor(sectorPos));

                fractionalSector = sectorPos - sectorNumber;

                p = v * (1D - s);
                q = v * (1D - (s * fractionalSector));
                t = v * (1D - (s * (1D - fractionalSector)));

                switch (sectorNumber)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }
            }
            return Color.FromArgb((int)(r * 255D), (int)(g * 255D), (int)(b * 255D));
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ZeroitUltimateHSV left, ZeroitUltimateHSV right)
        {
            return !(left == right);
        }
        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ZeroitUltimateHSV left, ZeroitUltimateHSV right)
        {
            return (left.Hue == right.Hue && left.Value == right.Value && left.Saturation == right.Saturation);
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            string s = string.Format("HSV({0:f2}, {1:f2}, {2:f2})", Hue, Saturation, Value);
            return s;
        }
    }
    #endregion

    #region IAnimatedProgressPainter
    /// <summary>
    /// Interface IAnimatedProgressPainter
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
	public interface IAnimatedProgressPainter : IProgressPainter
    {
        ///// <summary></summary>
        ///// <param name="box"></param>
        ///// <param name="g"></param>
        ///// <param name="marqueeX"></param>
        //void AnimateFrame(Rectangle box, Graphics g, ref int marqueeX);

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        int AnimationSpeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IAnimatedProgressPainter"/> is animating.
        /// </summary>
        /// <value><c>true</c> if animating; otherwise, <c>false</c>.</value>
        bool Animating { get; set; }
    }
    #endregion

    #region IGlossPainter
    /// <summary>
    /// Interface IGlossPainter
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IGlossPainter : IDisposable
    {
        /// <summary>
        /// Paints the gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        void PaintGloss(Rectangle box, Graphics g);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        void Resize(Rectangle box);

        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        event EventHandler PropertiesChanged;
    }
    #endregion

    #region IProgressBackgroundPainter
    /// <summary>
    /// Interface IProgressBackgroundPainter
    /// </summary>
    /// <seealso cref="System.IDisposable" />
	public interface IProgressBackgroundPainter : IDisposable
    {
        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        IGlossPainter GlossPainter { get; set; }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="gr">The gr.</param>
        void PaintBackground(Rectangle box, Graphics gr);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        void Resize(Rectangle box);

        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        event EventHandler PropertiesChanged;
    }
    #endregion

    #region IProgressBorderPainter
    /// <summary>
    /// Interface IProgressBorderPainter
    /// </summary>
    /// <seealso cref="System.IDisposable" />
	public interface IProgressBorderPainter : IDisposable
    {
        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="gr">The gr.</param>
        void PaintBorder(Rectangle box, Graphics gr);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        void Resize(Rectangle box);

        /// <summary>
        /// Gets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        int BorderWidth { get; }

        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        event EventHandler PropertiesChanged;
    }
    #endregion

    #region IProgressPainter
    /// <summary>
    /// Interface IProgressPainter
    /// </summary>
    /// <seealso cref="System.IDisposable" />
	public interface IProgressPainter : IDisposable
    {
        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        IGlossPainter GlossPainter { get; set; }

        /// <summary>
        /// Gets or sets the progress border painter.
        /// </summary>
        /// <value>The progress border painter.</value>
        IProgressBorderPainter ProgressBorderPainter { get; set; }

        /// <summary>
        /// Paints the progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="gr">The gr.</param>
        void PaintProgress(Rectangle box, Graphics gr);

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        void Resize(Rectangle box);

        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        event EventHandler PropertiesChanged;
    }
    #endregion

    #region JavaProgressPainter
    /// <summary>
    /// Class ZeroitUltimateJavaProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateJavaProgressPainter), "Resources.JavaProgressPainter.ico")]
    public class ZeroitUltimateJavaProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// The colors
        /// </summary>
        private ColorSet colors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateJavaProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateJavaProgressPainter()
        {
            color = Color.SkyBlue;
            colors = new ColorSet(false, color, 0.95f, 8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateJavaProgressPainter"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimateJavaProgressPainter(Color color)
        {
            this.color = color;
            colors = new ColorSet(false, color, 0.95f, 8);
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color."), Browsable(true)]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                colors = new ColorSet(false, color, 0.95f, 8);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Width -= 1;
                box.Height -= 1;
            }
            catch { }
            if (box.Width <= 1) { return; }

            float x = (float)box.X;
            float y = (float)box.Y;
            float w = (float)box.Right;
            float h = (float)box.Bottom;

            //Color corner
            Pen p;
            x += 2f; //x += 3f; //x += 2f; //x = x + 3f;
            y += 4f; //y += 5f; //y += 4f; //y = y + 5f;
            w -= 2f; //w -= 3f; //w -= 1f; //w = w - 2f;
            h -= 4f; //h -= 6f; //h -= 4f; //h = h - 6f;

            // Progress
            colors = new ColorSet(true, this.color, 0.95f, (int)h);
            float z = 2;
            float ni;
            float th = box.Height - 4;
            for (int i = -2; i < th; i++)
            {
                //for (int i = -2; i < th; i++) {
                z = (i < 0 ? i * -1 : i);
                Color c = colors.Colors[colors.Colors.Length - 1];
                try
                {
                    c = colors.Colors[(int)z];
                }
                catch { }
                p = new Pen(c);
                ni = y + i;
                g.DrawLine(p, x, ni, w, ni);
            }

            Color progborder = ColorRange.Morph(0.2f, Color.FromArgb(98, 98, 89), this.color);

            Color fade = Color.FromArgb(64, progborder.R, progborder.G, progborder.B);
            p = new Pen(new SolidBrush(fade), 1);
            //g.DrawRectangle(p, x - 1f, y - 3f, w - 1f, h + 1f);
            Rectangle bbox = box;
            bbox.Inflate(-1, -1);
            g.DrawRectangle(p, bbox);

            // Border
            p = new Pen(progborder, 1);
            ////g.DrawRectangle(p, x - 1f, y - 3f, w - 1f, h + 1f);
            //g.DrawLine(p, x, y - 3f, w, y - 3f);
            //g.DrawLine(p, x, h + 3f, w, h + 3f);
            //g.DrawLine(p, x - 1f, y - 2f, x - 1f, h + 2f);
            //g.DrawLine(p, w + 1f, y - 2f, w + 1f, h + 2f);
            g.DrawLine(p, x + 1f, y - 3f, w - 1f, y - 3f);
            g.DrawLine(p, x + 1f, h + 3f, w - 1f, h + 3f);
            g.DrawLine(p, x - 1f, y - 1f, x - 1f, h + 1f);
            g.DrawLine(p, w + 1f, y - 1f, w + 1f, h + 1f);

            // Border corner skirt
            //Color skirt = ColorRange.Morph(0.8f, this.color, progborder);
            Color skirt = Color.FromArgb(210, progborder.R, progborder.G, progborder.B);
            p = new Pen(skirt, 1);
            //// Upper Left
            //g.DrawLine(p, x - 1f, y - 3f, x, y - 3f);
            //g.DrawLine(p, x - 1f, y - 3f, x - 1f, y - 2f);
            g.DrawLine(p, x, y - 3f, x - 1f, y - 2f);
            //// Lower Left
            //g.DrawLine(p, x - 1f, h + 3f, x - 1f, h + 2f);
            //g.DrawLine(p, x - 1f, h + 3f, x, h + 3f);
            g.DrawLine(p, x, h + 3f, x - 1f, h + 2f);
            //// Upper Right
            //g.DrawLine(p, w + 1f, y - 3f, w + 1f, y - 2f);
            //g.DrawLine(p, w + 1f, y - 3f, w, y - 3f);
            g.DrawLine(p, w, y - 3f, w + 1f, y - 2f);
            //// Lower Right
            //g.DrawLine(p, w + 1f, h + 3f, w, h + 3f);
            //g.DrawLine(p, w + 1f, h + 3f, w + 1f, h + 2f);
            g.DrawLine(p, w, h + 3f, w + 1f, h + 2f);

            //// Border corner  x-1f, y-3f, w-2f, h+1f
            //Color corners = ColorRange.Morph(0.5f, this.color, progborder); //Color.FromArgb(229, 229, 222)
            //p = new Pen(corners, 1);
            //g.DrawLine(p, x - 1f, y - 3f, x, y - 2f);  // ul
            //g.DrawLine(p, x - 1f, h + 3f, x, h + 2f);  // ll
            //g.DrawLine(p, w + 1f, y - 3f, w, y - 2f);  // ur
            //g.DrawLine(p, w + 1f, h + 3f, w, h + 2f);  // lr

            ////// Outer corner (Left side only)
            ////Color outcorner = ColorRange.Morph(0.5f, progborder, Color.FromArgb(229, 229, 222));
            ////p = new Pen(outcorner, 1);
            ////g.DrawLine(p, x - 2f, y - 4f, x - 1f, y - 3f);
            ////g.DrawLine(p, x - 2f, h + 4f, x - 1f, h + 3f);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }
    }
    #endregion

    #region MetalProgressPainter
    /// <summary>
    /// Class ZeroitUltimateMetalProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateMetalProgressPainter), "Resources.MetalProgressPainter.ico")]
    public class ZeroitUltimateMetalProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The prog color
        /// </summary>
        private Color progColor = Color.FromArgb(201, 202, 201);
        /// <summary>
        /// The bk color
        /// </summary>
        private Color bkColor = Color.FromArgb(240, 240, 240);

        #region Default Colors
        /// <summary>
        /// The back color
        /// </summary>
        private Color backColor = Color.FromArgb(176, 177, 176);
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(69, 68, 69);
        /// <summary>
        /// The backtop color
        /// </summary>
        private Color backtopColor = Color.FromArgb(160, 157, 160);
        /// <summary>
        /// The bar color12
        /// </summary>
        private Color barColor12 = Color.FromArgb(193, 194, 193);
        /// <summary>
        /// The bar color3
        /// </summary>
        private Color barColor3 = Color.FromArgb(201, 202, 201);
        /// <summary>
        /// The bar color8
        /// </summary>
        private Color barColor8 = Color.FromArgb(226, 226, 226);
        /// <summary>
        /// The bar border top color
        /// </summary>
        private Color barBorderTopColor = Color.FromArgb(250, 250, 250);
        /// <summary>
        /// The bar border bottom color
        /// </summary>
        private Color barBorderBottomColor = Color.FromArgb(176, 173, 176);
        #endregion

        #region Pens & Brushes
        /// <summary>
        /// The border
        /// </summary>
        private Pen border;
        /// <summary>
        /// The backtop
        /// </summary>
        private Pen backtop;
        /// <summary>
        /// The back
        /// </summary>
        private Brush back;

        /// <summary>
        /// The bar12
        /// </summary>
        private Pen bar12;
        /// <summary>
        /// The bar8
        /// </summary>
        private Pen bar8;

        /// <summary>
        /// The bar border top
        /// </summary>
        private Pen barBorderTop;
        /// <summary>
        /// The bar border bottom
        /// </summary>
        private Pen barBorderBottom;

        /// <summary>
        /// The prog
        /// </summary>
        private Brush prog;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateMetalProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateMetalProgressPainter()
        {
            progColor = barColor3;
            back = new SolidBrush(bkColor); //backColor);

            border = new Pen(new SolidBrush(borderColor), 1f);
            backtop = new Pen(new SolidBrush(backtopColor), 1f);

            bar12 = new Pen(new SolidBrush(barColor12), 1f);
            bar8 = new Pen(new SolidBrush(barColor8), 1f);

            barBorderTop = new Pen(new SolidBrush(barBorderTopColor), 1f);
            barBorderBottom = new Pen(new SolidBrush(barBorderBottomColor), 1f);

            prog = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, 20), barColor12, barColor8);
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color"), Browsable(true)]
        public Color Color
        {
            get { return progColor; }
            set
            {
                progColor = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the highlight.
        /// </summary>
        /// <value>The highlight.</value>
        [Category("Appearance"), Description("Gets or sets the color that the highlights are blended with"), Browsable(true)]
        public Color Highlight
        {
            get { return backColor; }
            set
            {
                backColor = value;
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Width -= 1;
                box.Height -= 1;
            }
            catch { }
            float x = box.X;
            float y = box.Y;
            float w = box.Right;
            float h = box.Bottom;
            if (w < 2) { return; }

            RebuildBrushes(box.Bottom - 1);

            //g.FillRectangle(prog, x + 1, y + 1, w - 2, h - 1);
            //
            //g.DrawRectangle(barBorderBottom, box.X, box.Y, box.Right, box.Height - 1);
            //g.DrawLine(barBorderTop, box.X, box.Y, box.Width + 2, box.Y);
            //g.DrawLine(barBorderTop, box.X, box.Y, box.X, box.Height + 2);

            g.FillRectangle(prog, box);

            g.DrawLine(barBorderTop, x, y, w, y); // top
            g.DrawLine(barBorderTop, x, y, x, h); // left
            g.DrawLine(barBorderBottom, x, h, w, h); // bottom
            g.DrawLine(barBorderBottom, w, h, w, y); // right

            //g.DrawRectangle(border, x + 2, y + 2, w - 3, h - 4);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            //RebuildBrushes();
        }

        /// <summary>
        /// Rebuilds the brushes.
        /// </summary>
        /// <param name="height">The height.</param>
        private void RebuildBrushes(int height)
        {
            Color top = Cross(barColor3, progColor, barColor12);
            Color bottom = Cross(barColor3, progColor, barColor8);
            bar12 = new Pen(new SolidBrush(top), 1f);
            bar8 = new Pen(new SolidBrush(bottom), 1f);
            barBorderTop = new Pen(new SolidBrush(Cross(barColor3, progColor, barBorderTopColor)), 1f);
            barBorderBottom = new Pen(new SolidBrush(Cross(barColor3, progColor, barBorderBottomColor)), 1f);
            int h = height;
            //if (h == 0) { h = 20; }
            prog = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 1), new Point(0, h + 2), top, bottom);

            backtop = new Pen(new SolidBrush(Cross(backColor, bkColor, backtopColor)), 1f);
            back = new SolidBrush(bkColor);
        }

        /// <summary>
        /// Crosses the specified color x.
        /// </summary>
        /// <param name="colorX">The color x.</param>
        /// <param name="colorY">The color y.</param>
        /// <param name="colorX2">The color x2.</param>
        /// <returns>Color.</returns>
        private Color Cross(Color colorX, Color colorY, Color colorX2)
        {
            int r = (int)(((float)colorY.R * (float)colorX2.R) / (float)colorX.R);
            int g = (int)(((float)colorY.G * (float)colorX2.G) / (float)colorX.G);
            int b = (int)(((float)colorY.B * (float)colorX2.B) / (float)colorX.B);
            if (r > 255) { r = 255; } else if (r < 0) { r = 0; }
            if (g > 255) { g = 255; } else if (g < 0) { g = 0; }
            if (b > 255) { b = 255; } else if (b < 0) { b = 0; }
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            if (border != null) { border.Dispose(); }
            if (backtop != null) { backtop.Dispose(); }
            if (back != null) { back.Dispose(); }
            if (bar12 != null) { bar12.Dispose(); }
            if (bar8 != null) { bar8.Dispose(); }
            if (barBorderTop != null) { barBorderTop.Dispose(); }
            if (barBorderBottom != null) { barBorderBottom.Dispose(); }
            if (prog != null) { prog.Dispose(); }
        }
    }
    #endregion

    #region MiddleGlossPainter
    /// <summary>
    /// Class ZeroitUltimateMiddleGlossPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateChainedGlossPainter" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateMiddleGlossPainter), "Resources.MiddleGlossPainter.ico")]
    public class ZeroitUltimateMiddleGlossPainter : ZeroitUltimateChainedGlossPainter
    {
        /// <summary>
        /// The style
        /// </summary>
        private GlossStyle style = GlossStyle.Both;
        /// <summary>
        /// The high alpha
        /// </summary>
        private int highAlpha = 240;
        /// <summary>
        /// The low alpha
        /// </summary>
        private int lowAlpha = 0;
        /// <summary>
        /// The fadewidth
        /// </summary>
        private int fadewidth = 4;
        /// <summary>
        /// The high brush
        /// </summary>
        private Brush highBrush;
        /// <summary>
        /// The low brush
        /// </summary>
        private Brush lowBrush;
        /// <summary>
        /// The both brush
        /// </summary>
        private Brush bothBrush;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.White;
        /// <summary>
        /// The top color
        /// </summary>
        private Color topColor;
        /// <summary>
        /// The bot color
        /// </summary>
        private Color botColor;

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category("Appearance"), Description("Gets or sets the style for this progress gloss"), Browsable(true)]
        public GlossStyle Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha high.
        /// </summary>
        /// <value>The alpha high.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the high alpha value"), Browsable(true)]
        public int AlphaHigh
        {
            get { return this.highAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.highAlpha = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha low.
        /// </summary>
        /// <value>The alpha low.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the low alpha value"), Browsable(true)]
        public int AlphaLow
        {
            get { return this.lowAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.lowAlpha = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }
        /// <summary>
        /// Gets or sets the height of the taper.
        /// </summary>
        /// <value>The height of the taper.</value>
        [Category("Blending"), Description("Gets or sets the number of pixels to blend over"), Browsable(true)]
        public int TaperHeight
        {
            get { return this.fadewidth; }
            set
            {
                this.fadewidth = value;
                this.box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets color to gloss"), Browsable(true)]
        public Color Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                this.topColor = Color.FromArgb(highAlpha, this.color.R, this.color.G, this.color.B);
                this.botColor = Color.FromArgb(lowAlpha, this.color.R, this.color.G, this.color.B);
                box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisGloss(Rectangle box, Graphics g)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
                ResetBrushes(box);
            }

            int midpoint = box.X + (int)((float)box.Height / 2f);
            Rectangle topBox = new Rectangle(box.X, midpoint - fadewidth, box.Width - 1, fadewidth);
            Rectangle botBox = new Rectangle(box.X, midpoint, box.Width - 1, fadewidth);
            Rectangle fullBox = new Rectangle(box.X, midpoint - fadewidth, box.Width - 1, fadewidth * 2);

            switch (style)
            {
                case GlossStyle.Bottom:
                    g.FillRectangle(lowBrush, botBox);
                    //g.DrawRectangle(Pens.Fuchsia, botBox);
                    break;
                case GlossStyle.Top:
                    g.FillRectangle(highBrush, topBox);
                    //g.DrawRectangle(Pens.Fuchsia, topBox);
                    break;
                case GlossStyle.Both:
                    //g.FillRectangle(highBrush, topBox);
                    //g.FillRectangle(lowBrush, botBox);
                    g.FillRectangle(bothBrush, fullBox);
                    break;
            }
            //g.DrawRectangle(Pens.Purple, fullBox);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(64, 255, 255, 0))), topBox);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(64, 0, 255, 0))), botBox);
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
                ResetBrushes(box);
            }
        }

        /// <summary>
        /// Resets the brushes.
        /// </summary>
        /// <param name="box">The box.</param>
        private void ResetBrushes(Rectangle box)
        {
            int midpoint = box.X + (int)((float)box.Height / 2f);
            Rectangle topBox = new Rectangle(box.X, midpoint - fadewidth, box.Width - 1, fadewidth);
            Rectangle botBox = new Rectangle(box.X, midpoint, box.Width - 1, fadewidth);
            Rectangle fullBox = new Rectangle(box.X, midpoint - fadewidth, box.Width - 1, fadewidth * 2);

            //int midpoint = box.X + (int)((float)box.Height / 2f);
            Point top = new Point(box.X, fullBox.Top);
            Point topmid = new Point(box.X, topBox.Bottom);
            Point botmid = new Point(box.X, botBox.Top);
            Point bot = new Point(box.X, botBox.Bottom);
            Color high = topColor;
            Color low = botColor;
            //Rectangle fullBox = new Rectangle(box.X, midpoint - fadewidth, box.Width - 1, fadewidth * 2);
            switch (style)
            {
                case GlossStyle.Top:
                    highBrush = new LinearGradientBrush(top, topmid, low, high);
                    break;
                case GlossStyle.Bottom:
                    lowBrush = new LinearGradientBrush(botmid, bot, high, low);
                    break;
                case GlossStyle.Both:
                    //highBrush = new LinearGradientBrush(top, topmid, low, high);
                    //lowBrush = new LinearGradientBrush(botmid, bot, high, low);
                    bothBrush = new LinearGradientBrush(fullBox, low, high, LinearGradientMode.Vertical);
                    //((LinearGradientBrush)bothBrush).SetSigmaBellShape(0.5f, 0.5f);
                    ((LinearGradientBrush)bothBrush).SetBlendTriangularShape(0.5f);
                    break;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (highBrush != null) { highBrush.Dispose(); }
            if (lowBrush != null) { lowBrush.Dispose(); }
            if (bothBrush != null) { bothBrush.Dispose(); }
        }
    }
    #endregion

    #region PlainBackgroundPainter
    /// <summary>
    /// Class ZeroitUltimatePlainBackgroundPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBackgroundPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimatePlainBackgroundPainter), "Resources.PlainBackgroundPainter.ico")]
    public class ZeroitUltimatePlainBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable
    {
        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;
        /// <summary>
        /// The gloss
        /// </summary>
        private IGlossPainter gloss;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainBackgroundPainter"/> class.
        /// </summary>
        public ZeroitUltimatePlainBackgroundPainter()
        {
            this.Color = Color.FromArgb(240, 240, 240);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainBackgroundPainter"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimatePlainBackgroundPainter(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        [Category("Painters"), Description("Gets or sets the chain of gloss painters"), Browsable(true)]
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the background color"), Browsable(true)]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                brush = new SolidBrush(color);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBackground(Rectangle box, Graphics g)
        {
            g.FillRectangle(brush, box);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            brush.Dispose();
        }
    }
    #endregion

    #region PlainBorderPainter
    /// <summary>
    /// Class ZeroitUltimatePlainBorderPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBorderPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimatePlainBorderPainter), "Resources.PlainBorderPainter.ico")]
    public class ZeroitUltimatePlainBorderPainter : Component, IProgressBorderPainter, IDisposable
    {
        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// The pent
        /// </summary>
        private Pen pent;
        /// <summary>
        /// The penb
        /// </summary>
        private Pen penb;
        /// <summary>
        /// The cleart
        /// </summary>
        private Pen cleart;
        /// <summary>
        /// The clearb
        /// </summary>
        private Pen clearb;
        /// <summary>
        /// The rounded
        /// </summary>
        private bool rounded = false;
        /// <summary>
        /// The style
        /// </summary>
        private PlainBorderStyle style = PlainBorderStyle.Flat;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainBorderPainter"/> class.
        /// </summary>
        public ZeroitUltimatePlainBorderPainter()
        {
            this.Color = Color.Black;
            //this.clear = new Pen(new SolidBrush(SystemColors.Control));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainBorderPainter"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimatePlainBorderPainter(Color color)
        {
            this.Color = color;
            //this.clear = new Pen(new SolidBrush(SystemColors.Control));
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the border color"), Browsable(true)]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                if (style == PlainBorderStyle.Flat)
                {
                    pent = new Pen(new SolidBrush(color), 1f);
                    penb = pent;
                    this.cleart = new Pen(new SolidBrush(Color.FromArgb(64, color.R, color.G, color.B)));
                    this.clearb = cleart;
                    FireChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [rounded corners].
        /// </summary>
        /// <value><c>true</c> if [rounded corners]; otherwise, <c>false</c>.</value>
        [Category("Appearance"), Description("Determines wether or not to make the border a flat sqaure"), Browsable(true)]
        public bool RoundedCorners
        {
            get { return rounded; }
            set { rounded = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category("Appearance"), Description("Gets or sets the border style"), Browsable(true)]
        public PlainBorderStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                switch (style)
                {
                    case PlainBorderStyle.Flat:
                        pent = new Pen(new SolidBrush(color), 1f);
                        penb = pent;
                        this.cleart = new Pen(new SolidBrush(Color.FromArgb(64, color.R, color.G, color.B)));
                        this.clearb = cleart;
                        break;
                    case PlainBorderStyle.Raised:
                        pent = new Pen(new SolidBrush(SystemColors.ControlLightLight), 1f);
                        penb = new Pen(new SolidBrush(SystemColors.ControlDark), 1f);
                        this.cleart = new Pen(new SolidBrush(Color.FromArgb(64, SystemColors.ControlLightLight.R, SystemColors.ControlLightLight.G, SystemColors.ControlLightLight.B)));
                        this.clearb = new Pen(new SolidBrush(Color.FromArgb(64, SystemColors.ControlDark.R, SystemColors.ControlDark.G, SystemColors.ControlDark.B)));
                        break;
                    case PlainBorderStyle.Sunken:
                        pent = new Pen(new SolidBrush(SystemColors.ControlDark), 1f);
                        penb = new Pen(new SolidBrush(SystemColors.ControlLightLight), 1f);
                        this.cleart = new Pen(new SolidBrush(Color.FromArgb(64, SystemColors.ControlDark.R, SystemColors.ControlDark.G, SystemColors.ControlDark.B)));
                        this.clearb = new Pen(new SolidBrush(Color.FromArgb(64, SystemColors.ControlLightLight.R, SystemColors.ControlLightLight.G, SystemColors.ControlLightLight.B)));
                        break;
                }
                FireChange();
            }
        }

        /// <summary>
        /// Gets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Browsable(false)]
        public int BorderWidth
        {
            get { return 1; }
        }

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBorder(Rectangle box, Graphics g)
        {
            //try {
            //    box.Width -= 1;
            //    box.Height -= 1;
            //} catch {}
            if (rounded)
            {
                //// draws the left and right side (because they're shorter) to cover the corner pixels.
                //g.DrawLine(clear, box.X, 0, box.X, box.Height);
                //g.DrawLine(clear, box.Width, 0, box.Width, box.Height);

                g.DrawLine(cleart, box.X, box.Y, box.Right - 1, box.Y); // top
                g.DrawLine(cleart, box.X, box.Y, box.X, box.Bottom - 1); // left
                g.DrawLine(clearb, box.X, box.Bottom, box.Right, box.Bottom); // bottom
                g.DrawLine(clearb, box.Right, box.Y, box.Right, box.Bottom); // right

                //g.DrawRectangle(clear, box);
                g.DrawLine(pent, box.X + 1, box.Y, box.Right - 1, box.Y); // top
                g.DrawLine(penb, box.X + 1, box.Bottom, box.Right - 1, box.Bottom); // bottom
                g.DrawLine(pent, box.X, box.Y + 1, box.X, box.Bottom - 1); // left
                g.DrawLine(penb, box.Right, box.Y + 1, box.Right, box.Bottom - 1); // right
            }
            else
            {
                //g.DrawRectangle(pen, box);
                g.DrawLine(pent, box.X, box.Y, box.Right, box.Y); // top
                g.DrawLine(pent, box.X, box.Y, box.X, box.Bottom); // left
                g.DrawLine(penb, box.X, box.Bottom, box.Right, box.Bottom); // bottom
                g.DrawLine(penb, box.Right, box.Y, box.Right, box.Bottom); // right
            }
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            pent.Dispose();
            penb.Dispose();
            cleart.Dispose();
            clearb.Dispose();
        }

        /// <summary>
        /// Enum representing the Plain Border Style
        /// </summary>
        public enum PlainBorderStyle
        {
            /// <summary>
            /// The flat
            /// </summary>
            Flat,
            /// <summary>
            /// The sunken
            /// </summary>
            Sunken,
            /// <summary>
            /// The raised
            /// </summary>
            Raised
        }
    }
    #endregion

    #region PlainProgressPainter
    /// <summary>
    /// Class ZeroitUltimatePlainProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimatePlainProgressPainter), "Resources.PlainProgressPainter.ico")]
    public class ZeroitUltimatePlainProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The color
        /// </summary>
        private Color color;
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;
        /// <summary>
        /// The edge
        /// </summary>
        private Color edge = Color.Transparent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimatePlainProgressPainter()
        {
            this.Color = Color.FromArgb(151, 151, 234);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimatePlainProgressPainter"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ZeroitUltimatePlainProgressPainter(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets the leading edge.
        /// </summary>
        /// <value>The leading edge.</value>
        [Category("Appearance"), Description("Gets or sets the color to draw the leading edge of the progress with"), Browsable(true)]
        public Color LeadingEdge
        {
            get { return this.edge; }
            set { this.edge = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets the base progress color"), Browsable(true)]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                brush = new SolidBrush(color);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            if (box.Width <= 1)
            {
                return;
            }

            g.FillRectangle(brush, box);
            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
            if (!edge.Equals(Color.Transparent))
            {
                g.DrawLine(new Pen(new SolidBrush(edge), 1f), box.Right, box.Y, box.Right, box.Bottom - 1);
            }
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            brush.Dispose();
        }
    }
    #endregion

    #region ProgressBarEx
    /// <summary>
    /// Class ZeroitUltimateProgressBarEx.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressBar" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateProgressBarEx), "Resources.ProgressBarEx.ico")]
    public class ZeroitUltimateProgressBarEx : ZeroitUltimateAbstractProgressBar
    {
        /// <summary>
        /// The backgroundpainter
        /// </summary>
        protected IProgressBackgroundPainter backgroundpainter;
        /// <summary>
        /// The progresspainter
        /// </summary>
        protected IProgressPainter progresspainter;
        /// <summary>
        /// The borderpainter
        /// </summary>
        protected IProgressBorderPainter borderpainter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateProgressBarEx"/> class.
        /// </summary>
        public ZeroitUltimateProgressBarEx()
        {
            backgroundpainter = new ZeroitUltimatePlainBackgroundPainter();
            progresspainter = new ZeroitUltimatePlainProgressPainter(Color.Gold);
            borderpainter = new ZeroitUltimatePlainBorderPainter();
        }

        /// <summary>
        /// Gets or sets the background painter.
        /// </summary>
        /// <value>The background painter.</value>
        [Category("Painters"), Description("Paints this progress bar's background"), Browsable(true)]
        public IProgressBackgroundPainter BackgroundPainter
        {
            get { return this.backgroundpainter; }
            set
            {
                this.backgroundpainter = value;
                this.backgroundpainter.PropertiesChanged += new EventHandler(component_PropertiesChanged);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Gets or sets the progress painter.
        /// </summary>
        /// <value>The progress painter.</value>
        [Category("Painters"), Description("Paints this progress bar's progress"), Browsable(true)]
        public IProgressPainter ProgressPainter
        {
            get { return this.progresspainter; }
            set
            {
                if (!(value is IAnimatedProgressPainter) && base.ProgressType == ProgressType.Animated)
                {
                    base.ProgressType = ProgressType.Smooth;
                }
                this.progresspainter = value;
                if (this.progresspainter is ZeroitUltimateAbstractProgressPainter)
                {
                    ((ZeroitUltimateAbstractProgressPainter)this.progresspainter).padding = base.ProgressPadding;
                }
                this.progresspainter.PropertiesChanged += new EventHandler(component_PropertiesChanged);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the progress.
        /// </summary>
        /// <value>The type of the progress.</value>
        /// <exception cref="ArgumentException">Animated is not available with the current Progress Painter</exception>
        [Category("Progress"), Description("Gets or sets the type of progress"), Browsable(true)]
        public override ProgressType ProgressType
        {
            get { return base.type; }
            set
            {
                if (value == ProgressType.Animated && !(progresspainter is IAnimatedProgressPainter))
                {
                    throw new ArgumentException("Animated is not available with the current Progress Painter");
                }
                this.type = value;
            }
        }

        /// <summary>
        /// Gets or sets the border painter.
        /// </summary>
        /// <value>The border painter.</value>
        [Category("Painters"), Description("Paints this progress bar's border"), Browsable(true)]
        public IProgressBorderPainter BorderPainter
        {
            get { return this.borderpainter; }
            set
            {
                this.borderpainter = value;
                this.borderpainter.PropertiesChanged += new EventHandler(component_PropertiesChanged);
                ResizeProgress();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Resizes the progress.
        /// </summary>
        protected override void ResizeProgress()
        {
            if (base.ProgressType != ProgressType.Smooth) { return; }
            Rectangle newprog = base.borderbox;
            //newprog.Inflate(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);
            base.backbox = newprog;

            int val = value; if (val > 0) { val++; }
            int progWidth = maximum > 0 ? (backbox.Width * val / maximum) : 1;
            if (value >= maximum && maximum > 0)
            {
                progWidth = backbox.Width;
            } /*else if (value > 0) {
				progWidth++;
			}*/
            newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            newprog.Width = progWidth - (base.ProgressPadding * 2);
            //newprog.Offset(base.ProgressPadding, base.ProgressPadding);
            //newprog = new Rectangle(backbox.X + base.ProgressPadding, backbox.Y + base.ProgressPadding, progWidth - (base.ProgressPadding * 2), backbox.Height - (base.ProgressPadding * 2));
            base.progressbox = newprog;
        }

        #region Animation
        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void StartAnimation()
        {
            if (running) { return; }
            IAnimatedProgressPainter iapp = this.progresspainter as IAnimatedProgressPainter;
            if (iapp == null) { return; }
            iapp.Animating = true;
            running = true;
            timerMethod = new EventHandler(DoAnimation);
            timer.Interval = iapp.AnimationSpeed;
            timer.Tick += timerMethod;
            timer.Enabled = true;
        }
        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void StopAnimation()
        {
            timer.Enabled = false;
            timer.Tick -= timerMethod;
            running = false;
            IAnimatedProgressPainter iapp = this.progresspainter as IAnimatedProgressPainter;
            if (iapp == null) { return; }
            iapp.Animating = false;
        }
        /// <summary>
        /// Does the animation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoAnimation(object sender, EventArgs e)
        {
            IAnimatedProgressPainter iapp = this.progresspainter as IAnimatedProgressPainter;
            if (iapp == null) { return; }

            //Rectangle newprog = base.borderbox;
            //newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            //newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);
            ////int progWidth = (int)(((float)marqueePercentage * (float)backbox.Width) / 100f);
            //int progWidth = (int)(((float)marqueePercentage * (float)backbox.Width) / 100f);
            //newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            //newprog.Width = progWidth - (base.ProgressPadding * 2);

            //base.progressbox = newprog;

            ////iapp.AnimateFrame(newprog, g, ref marqueeX);

            this.Invalidate();
            this.Refresh();
        }
        #endregion

        #region Marquee
        /// <summary>
        /// The running
        /// </summary>
        private bool running = false;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// The timer method
        /// </summary>
        private EventHandler timerMethod;
        /// <summary>
        /// Marquees the start.
        /// </summary>
        public override void MarqueeStart()
        {
            if (running) { return; }
            running = true;
            switch (base.ProgressType)
            {
                case ProgressType.MarqueeWrap: timerMethod = new EventHandler(DoMarqueeWrap); break;
                case ProgressType.MarqueeBounce: timerMethod = new EventHandler(DoMarqueeBounce); break;
                case ProgressType.MarqueeBounceDeep: timerMethod = new EventHandler(DoMarqueeDeep); break;
            }
            timer.Interval = base.marqueeSpeed;
            timer.Tick += timerMethod;
            timer.Enabled = true;
        }

        /// <summary>
        /// The marquee x
        /// </summary>
        private int marqueeX = 0;
        /// <summary>
        /// Does the marquee wrap.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoMarqueeWrap(object sender, EventArgs e)
        {
            Rectangle newprog = base.borderbox;
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);

            int progWidth = (int)(((float)marqueePercentage * (float)backbox.Width) / 100f);

            marqueeX += marqueeStep;
            if (marqueeX > backbox.Width)
            {
                marqueeX = 0 - progWidth;
            }

            newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            newprog.Width = progWidth - (base.ProgressPadding * 2);
            newprog.X += marqueeX;

            int leftBoundry = backbox.X + this.borderpainter.BorderWidth + base.ProgressPadding;
            int rightBoundry = backbox.X + backbox.Width - (this.borderpainter.BorderWidth + base.ProgressPadding);
            if (marqueeX <= leftBoundry)
            {
                newprog.Width -= leftBoundry - marqueeX;
                newprog.X = leftBoundry;
            }
            else if (marqueeX + newprog.Width >= rightBoundry)
            {
                newprog.Width -= (marqueeX + newprog.Width + base.ProgressPadding) - rightBoundry;
            }

            base.progressbox = newprog;

            this.Invalidate();
            this.Refresh();
        }
        /// <summary>
        /// The marquee forward
        /// </summary>
        private bool marqueeForward = true;
        /// <summary>
        /// Does the marquee bounce.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoMarqueeBounce(object sender, EventArgs e)
        {
            Rectangle newprog = base.borderbox;
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);

            int progWidth = (int)(((float)marqueePercentage * (float)backbox.Width) / 100f);

            if (marqueeForward)
            {
                marqueeX += marqueeStep;
            }
            else
            {
                marqueeX -= marqueeStep;
            }

            newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            newprog.Width = progWidth - (base.ProgressPadding * 2);
            newprog.X += marqueeX;

            int leftBoundry = backbox.X + this.borderpainter.BorderWidth + base.ProgressPadding;
            int rightBoundry = backbox.X + backbox.Width - (this.borderpainter.BorderWidth + base.ProgressPadding);
            if (marqueeX + progWidth >= rightBoundry)
            {
                marqueeForward = false;
            }
            else if (marqueeX <= leftBoundry)
            {
                marqueeForward = true;
            }

            base.progressbox = newprog;

            this.Invalidate();
            this.Refresh();
        }
        /// <summary>
        /// Does the marquee deep.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DoMarqueeDeep(object sender, EventArgs e)
        {
            Rectangle newprog = base.borderbox;
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);

            int progWidth = (int)(((float)marqueePercentage * (float)backbox.Width) / 100f);

            if (marqueeForward)
            {
                marqueeX += marqueeStep;
            }
            else
            {
                marqueeX -= marqueeStep;
            }
            if (marqueeX > backbox.Width)
            {
                marqueeForward = false;
            }
            else if (marqueeX < backbox.X - progWidth)
            {
                marqueeForward = true;
            }

            newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            newprog.Width = progWidth - (base.ProgressPadding * 2);
            newprog.X += marqueeX;

            int leftBoundry = backbox.X + this.borderpainter.BorderWidth + base.ProgressPadding;
            int rightBoundry = backbox.X + backbox.Width - (this.borderpainter.BorderWidth + base.ProgressPadding);
            if (marqueeX <= leftBoundry)
            {
                newprog.Width -= leftBoundry - marqueeX;
                newprog.X = leftBoundry;
            }
            else if (marqueeX + newprog.Width >= rightBoundry)
            {
                newprog.Width -= (marqueeX + newprog.Width + base.ProgressPadding) - rightBoundry;
            }

            base.progressbox = newprog;

            this.Invalidate();
            this.Refresh();
        }

        /// <summary>
        /// Marquees the pause.
        /// </summary>
        public override void MarqueePause()
        {
            running = false;
            timer.Enabled = false;
            timer.Tick -= timerMethod;
        }
        /// <summary>
        /// Marquees the stop.
        /// </summary>
        public override void MarqueeStop()
        {
            Rectangle newprog = base.borderbox;
            newprog.Offset(this.borderpainter.BorderWidth, this.borderpainter.BorderWidth);
            newprog.Size = new Size(newprog.Size.Width - this.borderpainter.BorderWidth, newprog.Size.Height - this.borderpainter.BorderWidth);

            newprog.Inflate(-base.ProgressPadding, -base.ProgressPadding);
            newprog.Width = 1;
            base.progressbox = newprog;

            running = false;
            timer.Enabled = false;
            timer.Tick -= timerMethod;

            marqueeX = 0;
            this.Invalidate();
        }
        #endregion

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (running) { running = false; }
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeProgress();
            if (this.backgroundpainter != null) { this.backgroundpainter.Resize(borderbox); }
            if (this.progresspainter != null) { this.progresspainter.Resize(borderbox); }
            if (this.borderpainter != null) { this.borderpainter.Resize(borderbox); }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void PaintBackground(Graphics g)
        {
            if (this.backgroundpainter != null)
            {
                this.backgroundpainter.PaintBackground(backbox, g);
            }
        }

        /// <summary>
        /// Paints the progress.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void PaintProgress(Graphics g)
        {
            if (this.progresspainter != null)
            {
                this.progresspainter.PaintProgress(progressbox, g);
            }
        }

        /// <summary>
        /// Paints the text.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void PaintText(Graphics g)
        {
            if (base.ProgressType != ProgressType.Smooth) { return; }
            Brush b = new SolidBrush(ForeColor);
            SizeF sf = g.MeasureString(Text, Font, Convert.ToInt32(Width), StringFormat.GenericDefault);
            float m = sf.Width;
            float x = (Width / 2) - (m / 2);
            float w = (Width / 2) + (m / 2);
            float h = (float)borderbox.Height - (2f * (float)this.borderpainter.BorderWidth);
            float y = (float)this.borderpainter.BorderWidth + ((h - sf.Height) / 2f);
            g.DrawString(Text, Font, b, RectangleF.FromLTRB(x, y, w, Height - 1), StringFormat.GenericDefault);
        }

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void PaintBorder(Graphics g)
        {
            if (this.borderpainter != null)
            {
                this.borderpainter.PaintBorder(borderbox, g);
            }
        }
    }
    #endregion

    #region RarBackgroundPainter
    /// <summary>
    /// Class ZeroitUltimateRarBackgroundPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBackgroundPainter" />
    /// <seealso cref="System.IDisposable" />
    [ToolboxBitmapAttribute(typeof(ZeroitUltimateRarBackgroundPainter), "Resources.RarBackgroundPainter.ico")]
    public class ZeroitUltimateRarBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable
    {
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;
        /// <summary>
        /// The gloss
        /// </summary>
        private IGlossPainter gloss;
        /// <summary>
        /// The outer
        /// </summary>
        private Pen outer, inner, border;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Handles the PropertiesChanged event of the component control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void component_PropertiesChanged(object sender, EventArgs e)
        {
            FireChange();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateRarBackgroundPainter"/> class.
        /// </summary>
        public ZeroitUltimateRarBackgroundPainter()
        {
            brush = new SolidBrush(Color.FromArgb(148, 110, 110));
            inner = new Pen(new SolidBrush(Color.FromArgb(158, 128, 128)), 1f);
            outer = new Pen(new SolidBrush(Color.FromArgb(180, 148, 148)), 1f);
            border = new Pen(new SolidBrush(Color.FromArgb(096, 096, 096)), 1f);
        }

        /// <summary>
        /// Gets or sets the gloss painter.
        /// </summary>
        /// <value>The gloss painter.</value>
        public IGlossPainter GlossPainter
        {
            get { return this.gloss; }
            set
            {
                this.gloss = value;
                if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
                FireChange();
            }
        }

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBackground(Rectangle box, Graphics g)
        {
            g.FillRectangle(brush, box);
            g.DrawRectangle(inner, 2, 2, box.Width - 3, box.Height - 4);
            g.DrawRectangle(outer, 1, 1, box.Width - 1, box.Height - 2);
            g.DrawLine(border, 1, box.Height, box.Width, box.Height);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            brush.Dispose();
            inner.Dispose();
            outer.Dispose();
            border.Dispose();
        }
    }
    #endregion

    #region RarBorderPainter
    /// <summary>
    /// Class ZeroitUltimateRarBorderPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBorderPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateRarBorderPainter), "Resources.RarBorderPainter.ico")]
    public class ZeroitUltimateRarBorderPainter : Component, IProgressBorderPainter, IDisposable
    {
        /// <summary>
        /// The border
        /// </summary>
        private Pen border;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateRarBorderPainter"/> class.
        /// </summary>
        public ZeroitUltimateRarBorderPainter()
        {
            border = new Pen(new SolidBrush(Color.FromArgb(064, 064, 070)), 1f);
        }

        /// <summary>
        /// Gets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Browsable(false)]
        public int BorderWidth
        {
            get { return 1; }
        }

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBorder(Rectangle box, Graphics g)
        {
            g.DrawRectangle(new Pen(new SolidBrush(SystemColors.Control), 1f), 0, 0, box.Width, box.Height);
            g.DrawLine(border, 2, box.Height, box.Width, box.Height);
            g.DrawLine(border, box.Width, 3, box.Width, box.Height);
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            border.Dispose();
        }
    }
    #endregion

    #region RarProgressBar
    /// <summary>
    /// Class ZeroitUltimateRarProgressBar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateDualProgressBar" />
    [ToolboxBitmapAttribute(typeof(ZeroitUltimateRarProgressBar), "Resources.RarProgressBar.ico")]
    public class ZeroitUltimateRarProgressBar : ZeroitUltimateDualProgressBar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateRarProgressBar"/> class.
        /// </summary>
        public ZeroitUltimateRarProgressBar()
        {
            this.MasterPainter = new ZeroitUltimateRarProgressPainter(ZeroitUltimateRarProgressPainter.RarProgressType.Silver);
            ((ZeroitUltimateRarProgressPainter)this.MasterPainter).ShowEdge = false;
            this.ProgressPainter = new ZeroitUltimateRarProgressPainter(ZeroitUltimateRarProgressPainter.RarProgressType.Gold);
            ((ZeroitUltimateRarProgressPainter)this.ProgressPainter).ShowEdge = true;
            this.BorderPainter = new ZeroitUltimateRarBorderPainter();
            this.BackgroundPainter = new ZeroitUltimateRarBackgroundPainter();
            this.PaintMasterFirst = true;
            this.OnValueChanged += new EventHandler(onValueChanged);
            this.OnMasterValueChanged += new EventHandler(onValueChanged);
        }

        /// <summary>
        /// Ons the value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void onValueChanged(object sender, EventArgs e)
        {
            bool masterAhead = false;
            if (this.MasterValue > this.Value)
            {
                masterAhead = true;
            }
            ((ZeroitUltimateRarProgressPainter)this.MasterPainter).ShowEdge = masterAhead;
            ((ZeroitUltimateRarProgressPainter)this.ProgressPainter).ShowEdge = !masterAhead;
        }
    }
    #endregion

    #region RarProgressPainter
    /// <summary>
    /// Class ZeroitUltimateRarProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateRarProgressPainter), "Resources.RarProgressPainter.ico")]
    public class ZeroitUltimateRarProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IDisposable
    {
        /// <summary>
        /// The brush
        /// </summary>
        private Brush brush;
        /// <summary>
        /// The inner
        /// </summary>
        private Pen inner, outer, edge;
        /// <summary>
        /// The show edge
        /// </summary>
        private bool showEdge = false;
        /// <summary>
        /// The type
        /// </summary>
        private RarProgressType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateRarProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateRarProgressPainter()
        {
            this.ProgressType = RarProgressType.Silver;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateRarProgressPainter"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ZeroitUltimateRarProgressPainter(RarProgressType type)
        {
            this.ProgressType = type;
        }

        /// <summary>
        /// Gets or sets the type of the progress.
        /// </summary>
        /// <value>The type of the progress.</value>
        [Category("Appearance"), Description("Gets or sets the type of rar progress color"), Browsable(true)]
        public RarProgressType ProgressType
        {
            get { return type; }
            set
            {
                this.type = value;
                switch (type)
                {
                    case RarProgressType.Silver:
                        brush = new SolidBrush(Color.FromArgb(214, 214, 220));
                        inner = new Pen(new SolidBrush(Color.FromArgb(232, 232, 238)), 1f);
                        outer = new Pen(new SolidBrush(Color.FromArgb(255, 255, 255)), 1f);
                        edge = new Pen(new SolidBrush(Color.FromArgb(096, 096, 096)), 1f);
                        break;
                    case RarProgressType.Gold:
                        brush = new SolidBrush(Color.FromArgb(208, 192, 160));
                        inner = new Pen(new SolidBrush(Color.FromArgb(228, 212, 180)), 1f);
                        outer = new Pen(new SolidBrush(Color.FromArgb(255, 255, 192)), 1f);
                        edge = new Pen(new SolidBrush(Color.FromArgb(096, 096, 096)), 1f);
                        break;
                }
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show edge].
        /// </summary>
        /// <value><c>true</c> if [show edge]; otherwise, <c>false</c>.</value>
        [Category("Appearance"), Description("Gets or sets whether or not this progress has a leading edge"), Browsable(true)]
        public bool ShowEdge
        {
            get { return showEdge; }
            set
            {
                showEdge = value;
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            try
            {
                box.Width -= 1;
                box.Height -= 1;
            }
            catch { }
            if (box.Width <= 1)
            {
                return;
            }

            g.FillRectangle(brush, box);
            Rectangle innerBox = box;
            innerBox.Inflate(-1, -1);
            g.DrawRectangle(inner, innerBox);
            g.DrawLine(outer, box.X, box.Y, box.Right, box.Y);
            g.DrawLine(outer, box.X, box.Y, box.X, box.Bottom);
            g.DrawLine(edge, box.X, box.Bottom, box.Right, box.Bottom);

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }

            if (showEdge)
            {
                g.DrawLine(edge, box.Right, box.Y, box.Right, box.Bottom);
            }
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
            brush.Dispose();
            inner.Dispose();
            outer.Dispose();
            edge.Dispose();
        }

        /// <summary>
        /// Enum representing the type of rar progress 
        /// </summary>
        public enum RarProgressType
        {
            /// <summary>
            /// The gold
            /// </summary>
            Gold,
            /// <summary>
            /// The silver
            /// </summary>
            Silver
        }
    }
    #endregion

    #region RoundGlossPainter
    /// <summary>
    /// Enum representing the gloss style.
    /// </summary>
	public enum GlossStyle
    {
        /// <summary>
        /// The top
        /// </summary>
        Top,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom,
        /// <summary>
        /// The both
        /// </summary>
        Both
    }

    /// <summary>
    /// Class ZeroitUltimateRoundGlossPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateChainedGlossPainter" />
    [ToolboxBitmapAttribute(typeof(ZeroitUltimateRoundGlossPainter), "Resources.RoundGlossPainter.ico")]
    public class ZeroitUltimateRoundGlossPainter : ZeroitUltimateChainedGlossPainter
    {

        /// <summary>
        /// The style
        /// </summary>
        private GlossStyle style = GlossStyle.Both;
        /// <summary>
        /// The high alpha
        /// </summary>
        private int highAlpha = 240;
        /// <summary>
        /// The low alpha
        /// </summary>
        private int lowAlpha = 0;
        /// <summary>
        /// The fadewidth
        /// </summary>
        private int fadewidth = 4;
        /// <summary>
        /// The high brush
        /// </summary>
        private Brush highBrush;
        /// <summary>
        /// The low brush
        /// </summary>
        private Brush lowBrush;
        /// <summary>
        /// The box
        /// </summary>
        private Rectangle box;
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.White;
        /// <summary>
        /// The top color
        /// </summary>
        private Color topColor;
        /// <summary>
        /// The bot color
        /// </summary>
        private Color botColor;

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category("Appearance"), Description("Gets or sets the style for this progress gloss"), Browsable(true)]
        public GlossStyle Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha high.
        /// </summary>
        /// <value>The alpha high.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the high alpha value"), Browsable(true)]
        public int AlphaHigh
        {
            get { return this.highAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.highAlpha = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the alpha low.
        /// </summary>
        /// <value>The alpha low.</value>
        /// <exception cref="ArgumentException">Alpha values must be between 0 and 255.</exception>
        [Category("Blending"), Description("Gets or sets the low alpha value"), Browsable(true)]
        public int AlphaLow
        {
            get { return this.lowAlpha; }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Alpha values must be between 0 and 255.");
                }
                this.lowAlpha = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the height of the taper.
        /// </summary>
        /// <value>The height of the taper.</value>
        [Category("Blending"), Description("Gets or sets the number of pixels to blend over"), Browsable(true)]
        public int TaperHeight
        {
            get { return this.fadewidth; }
            set
            {
                this.fadewidth = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance"), Description("Gets or sets color to gloss"), Browsable(true)]
        public Color Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                this.topColor = Color.FromArgb(highAlpha, this.color.R, this.color.G, this.color.B);
                this.botColor = Color.FromArgb(lowAlpha, this.color.R, this.color.G, this.color.B);
                box = new Rectangle(0, 0, 1, 1);
                FireChange();
            }
        }

        /// <summary>
        /// Paints the this gloss.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisGloss(Rectangle box, Graphics g)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
                ResetBrushes(box);
            }

            //int midpoint = (int)((float)box.Height / 2f);
            //int toppoint = midpoint > (fadewidth + 2) ? midpoint - (fadewidth / 2) : midpoint;
            //int botpoint = midpoint > (fadewidth + 2) ? midpoint + (fadewidth / 2) : midpoint;

            //Rectangle topBox = new Rectangle(box.X, box.Y, box.Width - 1, box.Y + fadewidth);
            //Rectangle botBox = new Rectangle(box.X, box.Bottom - fadewidth - 2, box.Width - 1, fadewidth + 1);
            Rectangle topBox = new Rectangle(box.X, box.Y, box.Width, fadewidth);
            Rectangle botBox = new Rectangle(box.X, box.Bottom - fadewidth, box.Width, fadewidth);

            //if (midpoint - fadewidth > 2) { midpoint -= fadewidth; }

            switch (style)
            {
                case GlossStyle.Bottom:
                    g.FillRectangle(lowBrush, botBox);
                    break;
                case GlossStyle.Top:
                    g.FillRectangle(highBrush, topBox);
                    break;
                case GlossStyle.Both:
                    g.FillRectangle(highBrush, topBox);
                    g.FillRectangle(lowBrush, botBox);
                    //g.DrawRectangle(Pens.Red, topBox);
                    //g.DrawRectangle(Pens.Blue, botBox);
                    break;
            }
            //g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(64, 255, 0, 0))), topBox);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(32, 255, 0, 0)), topBox);
            //g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(64, 0, 0, 255))), botBox);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(32, 0, 0, 255)), botBox);
        }

        /// <summary>
        /// Resizes the this.
        /// </summary>
        /// <param name="box">The box.</param>
        protected override void ResizeThis(Rectangle box)
        {
            if (!this.box.Equals(box))
            {
                this.box = box;
                ResetBrushes(box);
            }
        }

        /// <summary>
        /// Resets the brushes.
        /// </summary>
        /// <param name="box">The box.</param>
        private void ResetBrushes(Rectangle box)
        {
            //int midpoint = (int)((float)box.Height / 2f);
            //int toppoint = midpoint - (fadewidth / 2);
            //if (toppoint < box.Y + 2) { toppoint = box.Y + 2; }
            //int botpoint = midpoint + (fadewidth / 2);
            //if (botpoint > box.Height - 2) { botpoint = box.Height - 2; }

            //Point top = new Point(box.X, box.Y);
            //Point topmid = new Point(box.X, box.Y + fadewidth + 1);
            //Point botmid = new Point(box.X, box.Height - fadewidth - 1);
            //Point bot = new Point(box.X, box.Bottom);

            Rectangle topBox = new Rectangle(box.X, box.Y, box.Width, fadewidth);
            Rectangle botBox = new Rectangle(box.X, box.Bottom - fadewidth, box.Width, fadewidth);
            Point top = new Point(box.X, topBox.Top);
            Point topmid = new Point(box.X, topBox.Bottom);
            Point botmid = new Point(box.X, botBox.Top - 1);
            Point bot = new Point(box.X, botBox.Bottom);

            Color high = topColor;
            Color low = botColor;
            switch (style)
            {
                case GlossStyle.Top:
                    highBrush = new LinearGradientBrush(top, topmid, high, low);
                    break;
                case GlossStyle.Bottom:
                    lowBrush = new LinearGradientBrush(botmid, bot, low, high);
                    break;
                case GlossStyle.Both:
                    highBrush = new LinearGradientBrush(top, topmid, high, low);
                    lowBrush = new LinearGradientBrush(botmid, bot, low, high);
                    break;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (highBrush != null) { highBrush.Dispose(); }
            if (lowBrush != null) { lowBrush.Dispose(); }
        }
    }
    #endregion

    #region StripedProgressPainter
    /// <summary>
    /// Class ZeroitUltimateStripedProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IAnimatedProgressPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateStripedProgressPainter), "Resources.StripedProgressPainter.ico")]
    public class ZeroitUltimateStripedProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IAnimatedProgressPainter, IDisposable
    {
        /// <summary>
        /// The color1
        /// </summary>
        private Color color1 = Color.FromArgb(110, 195, 248);
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2 = Color.FromArgb(056, 150, 230);
        /// <summary>
        /// The blend
        /// </summary>
        private Color blend = Color.FromArgb(097, 184, 244);
        /// <summary>
        /// The spacing
        /// </summary>
        private int spacing = 6;
        /// <summary>
        /// The marquee speed
        /// </summary>
        private int marqueeSpeed = 10;

        /// <summary>
        /// The marquee x
        /// </summary>
        private int marqueeX = 0;

        /// <summary>
        /// The is animated
        /// </summary>
        private bool isAnimated = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateStripedProgressPainter"/> class.
        /// </summary>
        public ZeroitUltimateStripedProgressPainter()
        {
        }

        /// <summary>
        /// Gets or sets the color of the base.
        /// </summary>
        /// <value>The color of the base.</value>
        public Color BaseColor
        {
            get { return color1; }
            set
            {
                color1 = value;
                blend = ColorRange.Morph(0.25f, color1, color2);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color of the stripe.
        /// </summary>
        /// <value>The color of the stripe.</value>
        public Color StripeColor
        {
            get { return color2; }
            set
            {
                color2 = value;
                blend = ColorRange.Morph(0.25f, color1, color2);
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the stripe spacing.
        /// </summary>
        /// <value>The stripe spacing.</value>
        public int StripeSpacing
        {
            get { return spacing; }
            set { spacing = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int AnimationSpeed
        {
            get { return marqueeSpeed; }
            set { marqueeSpeed = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitUltimateStripedProgressPainter"/> is animating.
        /// </summary>
        /// <value><c>true</c> if animating; otherwise, <c>false</c>.</value>
        public bool Animating
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }

        /// <summary>
        /// Animates the frame.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        /// <param name="marqueeX">The marquee x.</param>
        private void AnimateFrame(Rectangle box, Graphics g, ref int marqueeX)
        {
            if (box == null || g == null || box.Width <= 1) { return; }

            Pen penb = new Pen(new SolidBrush(blend));
            g.FillRectangle(new SolidBrush(color1), box);
            for (int i = box.Right + marqueeX; i > box.Left; i -= ((box.Height * 2) + StripeSpacing - 1))
            {
                Point theoreticalRightTop = new Point(i, box.Top);
                Point theoreticalRightBottom = new Point(i - box.Height, box.Bottom);
                Point theoreticalLeftTop = new Point(i - box.Height, box.Top);
                Point theoreticalLeftBottom = new Point(i - (box.Height * 2), box.Bottom);

                Point leftTop, leftBottom, rightTop, rightBottom;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    if (theoreticalLeftTop.X <= box.Left)
                    {
                        // left triangle
                        int diff = i - box.Height;
                        rightTop = new Point(i, box.Top);
                        rightBottom = new Point(box.Left, box.Bottom + diff);
                        leftTop = new Point(box.Left, box.Top);
                        leftBottom = leftTop;

                        if (rightBottom.Equals(rightTop)) { continue; }

                        gp.AddLine(rightTop, rightBottom);
                        gp.AddLine(rightBottom, leftTop);
                        gp.AddLine(leftTop, new Point(i, box.Top));
                    }
                    else if (theoreticalLeftBottom.X <= box.Left)
                    {
                        // left pentagon
                        int diff = i - (box.Height * 2);
                        rightTop = new Point(i, box.Top);
                        rightBottom = new Point(i - box.Height, box.Bottom);
                        leftTop = new Point(i - box.Height, box.Top);
                        leftBottom = new Point(box.Left, box.Bottom + diff);

                        gp.AddLine(rightTop, rightBottom);
                        gp.AddLine(rightBottom, new Point(box.Left, box.Bottom));
                        gp.AddLine(new Point(box.Left, box.Bottom), leftBottom);
                        gp.AddLine(leftBottom, leftTop);
                        gp.AddLine(leftTop, rightTop);
                    }
                    else if (theoreticalRightBottom.X >= box.Right)
                    {
                        // right triangle
                        int diff = marqueeX - box.Height;
                        leftTop = new Point(box.Right, box.Top + diff); //= something funky
                        leftBottom = theoreticalLeftBottom;
                        rightBottom = new Point(box.Right, box.Bottom);
                        rightTop = rightBottom;

                        if (leftBottom.Equals(leftTop)) { continue; }

                        gp.AddLine(leftTop, rightBottom);
                        gp.AddLine(rightBottom, leftBottom);
                        gp.AddLine(leftBottom, leftTop);
                    }
                    else if (theoreticalRightTop.X >= box.Right)
                    {
                        // right pentagon
                        int diff = i - box.Right;
                        Point topRight = new Point(box.Right, box.Top);
                        rightTop = new Point(box.Right, box.Top + diff);
                        rightBottom = new Point(i - box.Height, box.Bottom);
                        leftTop = new Point(i - box.Height, box.Top);
                        leftBottom = new Point(i - (box.Height * 2), box.Bottom);

                        gp.AddLine(leftTop, topRight);
                        gp.AddLine(topRight, rightTop);
                        gp.AddLine(rightTop, rightBottom);
                        gp.AddLine(rightBottom, leftBottom);
                        gp.AddLine(leftBottom, leftTop);
                    }
                    else
                    {
                        // mid-range rectangle
                        rightTop = new Point(i, box.Top);
                        rightBottom = new Point(i - box.Height, box.Bottom);
                        leftTop = new Point(i - box.Height, box.Top);
                        leftBottom = new Point(i - (box.Height * 2), box.Bottom);

                        gp.AddLine(rightTop, rightBottom);
                        gp.AddLine(rightBottom, leftBottom);
                        gp.AddLine(leftBottom, leftTop);
                        gp.AddLine(leftTop, rightTop);
                    }
                    g.FillPath(new SolidBrush(color2), gp);
                }

                if (!leftTop.Equals(leftBottom))
                {
                    g.DrawLine(penb, leftTop, leftBottom);
                }
                if (!rightTop.Equals(rightBottom))
                {
                    g.DrawLine(penb, rightTop, rightBottom);
                }
            }
            g.DrawLine(penb, new Point(box.Left, box.Bottom), new Point(box.Right, box.Bottom));

            if (++marqueeX > (box.Height * 2) + StripeSpacing)
            {
                marqueeX = 1;
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            if (box.Width <= 1)
            {
                return;
            }

            if (isAnimated)
            {
                AnimateFrame(box, g, ref marqueeX);
            }
            else
            {
                int x = 0;
                AnimateFrame(box, g, ref x);
            }

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
        }
    }
    #endregion

    #region StyledBorderPainter
    /// <summary>
    /// Class ZeroitUltimateStyledBorderPainter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressBorderPainter" />
    /// <seealso cref="System.IDisposable" />
	[ToolboxBitmapAttribute(typeof(ZeroitUltimateStyledBorderPainter), "Resources.StyledBorderPainter.ico")]
    public class ZeroitUltimateStyledBorderPainter : Component, IProgressBorderPainter, IDisposable
    {
        /// <summary>
        /// The border
        /// </summary>
        private Border3DStyle border;

        /// <summary>
        /// The on properties changed
        /// </summary>
        private EventHandler onPropertiesChanged;
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        public event EventHandler PropertiesChanged
        {
            add
            {
                if (onPropertiesChanged != null)
                {
                    foreach (Delegate d in onPropertiesChanged.GetInvocationList())
                    {
                        if (object.ReferenceEquals(d, value)) { return; }
                    }
                }
                onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
            }
            remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
        }

        /// <summary>
        /// Fires the change.
        /// </summary>
        private void FireChange()
        {
            if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltimateStyledBorderPainter"/> class.
        /// </summary>
        public ZeroitUltimateStyledBorderPainter()
        {
            border = Border3DStyle.Raised;
        }

        /// <summary>
        /// Gets or sets the border3 d.
        /// </summary>
        /// <value>The border3 d.</value>
        [Category("Appearance"), Description("Gets or sets the border style"), Browsable(true)]
        public Border3DStyle Border3D
        {
            get { return border; }
            set { border = value; FireChange(); }
        }

        /// <summary>
        /// Gets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Browsable(false)]
        public int BorderWidth
        {
            get { return 2; }
        }

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        public void PaintBorder(Rectangle box, Graphics g)
        {
            Rectangle brd = new Rectangle(box.X, box.Y, box.Width, box.Height + 1);
            ControlPaint.DrawBorder3D(g, brd, border);
        }

        /// <summary>
        /// Resizes the specified box.
        /// </summary>
        /// <param name="box">The box.</param>
        public void Resize(Rectangle box)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
    #endregion

    #region WaveProgressPainter
    /// <summary>
    /// Class ZeroitUltimateWaveProgressPainter.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitUltimateAbstractProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IProgressPainter" />
    /// <seealso cref="Zeroit.Framework.Progress.IAnimatedProgressPainter" />
    /// <seealso cref="System.IDisposable" />
    [ToolboxBitmapAttribute(typeof(ZeroitUltimateWaveProgressPainter), "Resources.WaveProgressPainter.ico")]
    public class ZeroitUltimateWaveProgressPainter : ZeroitUltimateAbstractProgressPainter, IProgressPainter, IAnimatedProgressPainter, IDisposable
    {
        /// <summary>
        /// The color1
        /// </summary>
        private Color color1 = Color.FromArgb(110, 195, 248);
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2 = Color.FromArgb(056, 150, 230);
        /// <summary>
        /// The marquee speed
        /// </summary>
        private int marqueeSpeed = 10;
        /// <summary>
        /// The marquee x
        /// </summary>
        private int marqueeX = 0;
        /// <summary>
        /// The animate x
        /// </summary>
        private int animateX = 0;
        /// <summary>
        /// The is animated
        /// </summary>
        private bool isAnimated = false;

        /// <summary>
        /// Gets or sets the color of the base.
        /// </summary>
        /// <value>The color of the base.</value>
        public Color BaseColor
        {
            get { return color1; }
            set
            {
                color1 = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the color of the wave.
        /// </summary>
        /// <value>The color of the wave.</value>
        public Color WaveColor
        {
            get { return color2; }
            set
            {
                color2 = value;
                FireChange();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int AnimationSpeed
        {
            get { return marqueeSpeed; }
            set { marqueeSpeed = value; FireChange(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitUltimateWaveProgressPainter"/> is animating.
        /// </summary>
        /// <value><c>true</c> if animating; otherwise, <c>false</c>.</value>
        public bool Animating
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }

        /// <summary>
        /// Animates the frame.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        /// <param name="marqueeX">The marquee x.</param>
        private void AnimateFrame(Rectangle box, Graphics g, ref int marqueeX)
        {
            if (box == null || g == null || box.Width <= 1) { return; }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.Clip = new Region(box);

            g.FillRectangle(new SolidBrush(color1), box);
            int h = box.Height;
            int hm = (int)((float)h / 2f);

            using (GraphicsPath gp = new GraphicsPath())
            {
                Point MidLeft = new Point(0, hm);
                Point MidRight = new Point(h * 2, hm);

                int currentX = box.Right + animateX; // Increment currentX to animate
                int left = currentX - (h * 2);
                if (left < box.Left) { left = box.Left; }
                while (currentX > box.Left)
                {
                    left = currentX - (h * 2);

                    MidLeft = new Point(left, hm);
                    MidRight = new Point(currentX, hm);

                    int crestX = currentX - h;
                    gp.AddBezier(MidRight, new Point(crestX, 0), new Point(crestX, h), MidLeft);
                    currentX -= h * 2;
                }
                gp.AddLine(MidLeft, new Point(box.Left, box.Bottom)); // left side
                gp.AddLine(new Point(box.Left, box.Bottom), new Point(box.Right, box.Bottom)); // bottom
                gp.AddLine(new Point(box.Right, box.Bottom), new Point(box.Right, hm)); // right side

                g.FillPath(new SolidBrush(color2), gp);
            }
            g.SmoothingMode = SmoothingMode.Default;

            if (isAnimated && ++animateX > (box.Height * 2))
            {
                animateX = 1;
            }
        }

        /// <summary>
        /// Paints the this progress.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="g">The g.</param>
        protected override void PaintThisProgress(Rectangle box, Graphics g)
        {
            if (box.Width <= 1)
            {
                return;
            }

            if (isAnimated)
            {
                AnimateFrame(box, g, ref marqueeX);
            }
            else
            {
                int x = 0;
                AnimateFrame(box, g, ref x);
            }

            if (gloss != null)
            {
                gloss.PaintGloss(box, g);
            }
        }

        /// <summary>
        /// Disposes the this.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void DisposeThis(bool disposing)
        {
        }
    }
    #endregion

    #endregion

}
