// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Sampana.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Sampana

    #region Control
    /// <summary>
    /// Class ZeroitSampana.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public class ZeroitSampana : Panel
    {
        #region Timer Utility

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
            if (this.FillDegree + 1 > 100)
                this.FillDegree = 0;
            else
                this.FillDegree++;
        }

        #endregion


        #endregion

        /// <summary>
        /// Gets or sets the rounded corner angle.
        /// </summary>
        /// <value>The rounded corner angle.</value>
        public int RoundedCornerAngle { get; set; }
        /// <summary>
        /// Gets or sets the size of the left bar.
        /// </summary>
        /// <value>The size of the left bar.</value>
        public int LeftBarSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the right bar.
        /// </summary>
        /// <value>The size of the right bar.</value>
        public int RightBarSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the status bar.
        /// </summary>
        /// <value>The size of the status bar.</value>
        public int StatusBarSize { get; set; }
        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        public Padding Padding { get; set; }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        public Font Font { get; set; }
        /// <summary>
        /// Gets or sets the main text.
        /// </summary>
        /// <value>The main text.</value>
        public string MainText { get; set; }
        /// <summary>
        /// Gets or sets the left text.
        /// </summary>
        /// <value>The left text.</value>
        public string LeftText { get; set; }
        /// <summary>
        /// Gets or sets the right text.
        /// </summary>
        /// <value>The right text.</value>
        public string RightText { get; set; }
        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        /// <value>The status text.</value>
        public string StatusText { get; set; }

        /// <summary>
        /// The status color1
        /// </summary>
        private Color StatusColor1;
        /// <summary>
        /// The status color2
        /// </summary>
        private Color StatusColor2;
        /// <summary>
        /// The status bar color index
        /// </summary>
        private int _StatusBarColorIndex;
        /// <summary>
        /// ColorIndex. [0 - Raw active] [1 - Raw inactive] [2 - Dry active] [3 - Dry inactive].
        /// </summary>
        /// <value>The color of the status bar.</value>
        public int StatusBarColor
        {
            get { return _StatusBarColorIndex; }
            set
            {
                switch (value)
                {
                    case 0:
                        // Raw active
                        StatusColor1 = Color.OliveDrab;
                        StatusColor2 = Color.DarkOliveGreen;
                        break;
                    case 1:
                        // Raw inactive
                        StatusColor1 = Color.OliveDrab;
                        StatusColor2 = Color.Gray;
                        break;
                    case 2:
                        // Dry active
                        StatusColor1 = Color.Goldenrod;
                        StatusColor2 = Color.DarkGoldenrod;
                        break;
                    case 3:
                        // Dry inactive
                        StatusColor1 = Color.Goldenrod;
                        StatusColor2 = Color.Gray;
                        break;
                    default:
                        StatusColor1 = Color.DimGray;
                        StatusColor2 = Color.DimGray;
                        break;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// The first color
        /// </summary>
        private Color FirstColor;
        /// <summary>
        /// The second color
        /// </summary>
        private Color SecondColor;
        /// <summary>
        /// The fill degree
        /// </summary>
        private int _FillDegree = 50;
        /// <summary>
        /// Gets or sets the fill degree.
        /// </summary>
        /// <value>The fill degree.</value>
        public int FillDegree
        {
            get { return _FillDegree; }
            set
            {
                if (value >= 100)
                {
                    FirstColor = Color.Red;
                    SecondColor = Color.DarkRed;
                }
                else if (value > 90)
                {
                    FirstColor = Color.Orange;
                    SecondColor = Color.DarkOrange;
                }
                else if (value > 80)
                {
                    FirstColor = Color.Gold;
                    SecondColor = Color.DarkGoldenrod;
                }
                else
                {
                    FirstColor = Color.Green;
                    SecondColor = Color.DarkGreen;
                }
                _FillDegree = value;

                Invalidate();
            }
        }

        //Check radius for begin drag n drop
        /// <summary>
        /// Gets or sets a value indicating whether [allow drag].
        /// </summary>
        /// <value><c>true</c> if [allow drag]; otherwise, <c>false</c>.</value>
        public bool AllowDrag { get; set; }
        /// <summary>
        /// The is dragging
        /// </summary>
        private bool _isDragging = false;
        /// <summary>
        /// The d dradius
        /// </summary>
        private int _DDradius = 40;
        /// <summary>
        /// The m x
        /// </summary>
        private int _mX = 0;
        /// <summary>
        /// The m y
        /// </summary>
        private int _mY = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSampana"/> class.
        /// </summary>
        public ZeroitSampana()
        {


            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            Font = new Font("Arial", 10);
            FillDegree = 50;
            RoundedCornerAngle = 10;
            Margin = new Padding(0);
            LeftText = "LT";
            StatusText = "Not set";
            MainText = "MainText";
            RightText = "RT";
            LeftBarSize = 30;
            StatusBarSize = 60;
            RightBarSize = 30;
            StatusBarColor = 99;
            AllowDrag = true;

            #region Timer Utility

            //if (DesignMode)
            //{
            //    timer.Tick += Timer_Tick;
            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}

            //if (!DesignMode)
            //{
            //    timer.Tick += Timer_Tick;

            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}

            #endregion
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = Color.SandyBrown;
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.BackColor = Color.Transparent;
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
            _mX = e.X;
            _mY = e.Y;
            this._isDragging = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isDragging)
            {
                // This is a check to see if the mouse is moving while pressed.
                // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
                if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
                {
                    int num1 = _mX - e.X;
                    int num2 = _mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > _DDradius)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        _isDragging = true;
                        return;
                    }
                }
                base.OnMouseMove(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            paintThis(e.Graphics);
        }

        /// <summary>
        /// Paints the this.
        /// </summary>
        /// <param name="_graphics">The graphics.</param>
        public void paintThis(Graphics _graphics)
        {
            // Textformat
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;

            // Misc
            _graphics = this.CreateGraphics();
            System.Drawing.Drawing2D.LinearGradientBrush _LeftAndRightBrush = new LinearGradientBrush(GetMainArea(), Color.DimGray, Color.Black, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _StatusBrush = new LinearGradientBrush(GetMainArea(), StatusColor1, StatusColor2, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _MainBrush = new LinearGradientBrush(GetMainArea(), FirstColor, SecondColor, LinearGradientMode.Vertical);

            // Draw left
            if (LeftBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_LeftAndRightBrush, this.GetLeftArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TopLeft | RectangleEdgeFilter.BottomLeft);
                _graphics.DrawString(this.LeftText, this.Font, Brushes.White, this.GetLeftArea(), f);
            }

            // Draw status
            if (StatusBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_StatusBrush, this.GetStatusArea(), this.RoundedCornerAngle, RectangleEdgeFilter.None);
                _graphics.DrawString(this.StatusText, this.Font, Brushes.White, this.GetStatusArea(), f);
            }

            // Draw main background
            _graphics.FillRoundedRectangle(Brushes.DimGray, GetMainAreaBackground(), this.RoundedCornerAngle, RectangleEdgeFilter.None);

            // Draw main
            _graphics.FillRoundedRectangle(_MainBrush, this.GetMainArea(), this.RoundedCornerAngle, RectangleEdgeFilter.None);
            _graphics.DrawString(this.MainText, this.Font, Brushes.White, this.GetMainAreaBackground(), f);

            // Draw right
            if (RightBarSize > 0)
            {
                _graphics.FillRoundedRectangle(_LeftAndRightBrush, this.GetRightArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TopRight | RectangleEdgeFilter.BottomRight);
                _graphics.DrawString(this.RightText, this.Font, Brushes.White, this.GetRightArea(), f);
            }

            // Clean up
            _LeftAndRightBrush.Dispose();
            _MainBrush.Dispose();
            _StatusBrush.Dispose();
        }

        /// <summary>
        /// Gets the left area.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetLeftArea()
        {
            return new Rectangle(
                Padding.Left,
                Padding.Top,
                LeftBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        /// <summary>
        /// Gets the status area.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetStatusArea()
        {
            return new Rectangle(
                Padding.Left + LeftBarSize,
                Padding.Top,
                StatusBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        /// <summary>
        /// Gets the main area.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetMainArea()
        {
            return new Rectangle(
                Padding.Left + LeftBarSize + StatusBarSize,
                Padding.Top,
                Convert.ToInt32(((this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right)) * FillDegree) / 100),
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        /// <summary>
        /// Gets the main area background.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetMainAreaBackground()
        {
            return new Rectangle(
                   Padding.Left + LeftBarSize + StatusBarSize,
                   Padding.Top,
                   this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right),
                   this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }

        /// <summary>
        /// Gets the right area.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetRightArea()
        {
            return new Rectangle(
                this.ClientRectangle.Width - (RightBarSize + Padding.Right),
                Padding.Top,
                RightBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        }
    }
    #endregion

    #region Graphic Extension
    /// <summary>
    /// Class GraphicsExtension.
    /// </summary>
    static class GraphicsExtension
    {
        /// <summary>
        /// Generates the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath GenerateRoundedRectangle(
                this Graphics graphics,
                RectangleF rectangle,
                float radius,
                RectangleEdgeFilter filter)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F || filter == RectangleEdgeFilter.None)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (System.Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                if ((RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilter.TopLeft)
                    path.AddArc(arc, 180, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                }
                arc.X = rectangle.Right - diameter;
                if ((RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilter.TopRight)
                    path.AddArc(arc, 270, 90);
                else
                {
                    path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
                }
                arc.Y = rectangle.Bottom - diameter;
                if ((RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilter.BottomRight)
                    path.AddArc(arc, 0, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
                }
                arc.X = rectangle.Left;
                if ((RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilter.BottomLeft)
                    path.AddArc(arc, 90, 90);
                else
                {
                    path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                    path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                }
                path.CloseFigure();
            }
            return path;
        }
        /// <summary>
        /// Generates the capsule.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath GenerateCapsule(
                this Graphics graphics,
                RectangleF rectangle)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (rectangle.Width > rectangle.Height)
                {
                    diameter = rectangle.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = rectangle.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (rectangle.Width < rectangle.Height)
                {
                    diameter = rectangle.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(rectangle.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = rectangle.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(rectangle);
            }
            catch { path.AddEllipse(rectangle); }
            finally { path.CloseFigure(); }
            return path;
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
                this Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
                this Graphics graphics,
                Pen pen,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            graphics.DrawRoundedRectangle(
                    pen,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
                this Graphics graphics,
                Pen pen,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            graphics.DrawRoundedRectangle(
                    pen,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            Rectangle rectangle,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }
        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            RectangleF rectangle,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
                this Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius,
                RectangleEdgeFilter filter)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius, filter);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
                this Graphics graphics,
                Brush brush,
                float x,
                float y,
                float width,
                float height,
                float radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    x,
                    y,
                    width,
                    height,
                    radius,
                    RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
                this Graphics graphics,
                Brush brush,
                int x,
                int y,
                int width,
                int height,
                int radius)
        {
            graphics.FillRoundedRectangle(
                    brush,
                    Convert.ToSingle(x),
                    Convert.ToSingle(y),
                    Convert.ToSingle(width),
                    Convert.ToSingle(height),
                    Convert.ToSingle(radius));
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            Rectangle rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="filter">The filter.</param>
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius,
            RectangleEdgeFilter filter)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                filter);
        }
        /// <summary>
        /// Fills the rounded rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            RectangleF rectangle,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height,
                radius,
                RectangleEdgeFilter.All);
        }
        /// <summary>
        /// Gets the font metrics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns>FontMetrics.</returns>
        public static FontMetrics GetFontMetrics(
            this Graphics graphics,
            Font font)
        {
            return FontMetricsImpl.GetFontMetrics(graphics, font);
        }
        /// <summary>
        /// Class FontMetricsImpl.
        /// </summary>
        /// <seealso cref="Zeroit.Framework.Progress.FontMetrics" />
        private class FontMetricsImpl : FontMetrics
        {
            /// <summary>
            /// Struct TEXTMETRIC
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct TEXTMETRIC
            {
                /// <summary>
                /// The tm height
                /// </summary>
                public int tmHeight;
                /// <summary>
                /// The tm ascent
                /// </summary>
                public int tmAscent;
                /// <summary>
                /// The tm descent
                /// </summary>
                public int tmDescent;
                /// <summary>
                /// The tm internal leading
                /// </summary>
                public int tmInternalLeading;
                /// <summary>
                /// The tm external leading
                /// </summary>
                public int tmExternalLeading;
                /// <summary>
                /// The tm ave character width
                /// </summary>
                public int tmAveCharWidth;
                /// <summary>
                /// The tm maximum character width
                /// </summary>
                public int tmMaxCharWidth;
                /// <summary>
                /// The tm weight
                /// </summary>
                public int tmWeight;
                /// <summary>
                /// The tm overhang
                /// </summary>
                public int tmOverhang;
                /// <summary>
                /// The tm digitized aspect x
                /// </summary>
                public int tmDigitizedAspectX;
                /// <summary>
                /// The tm digitized aspect y
                /// </summary>
                public int tmDigitizedAspectY;
                /// <summary>
                /// The tm first character
                /// </summary>
                public char tmFirstChar;
                /// <summary>
                /// The tm last character
                /// </summary>
                public char tmLastChar;
                /// <summary>
                /// The tm default character
                /// </summary>
                public char tmDefaultChar;
                /// <summary>
                /// The tm break character
                /// </summary>
                public char tmBreakChar;
                /// <summary>
                /// The tm italic
                /// </summary>
                public byte tmItalic;
                /// <summary>
                /// The tm underlined
                /// </summary>
                public byte tmUnderlined;
                /// <summary>
                /// The tm struck out
                /// </summary>
                public byte tmStruckOut;
                /// <summary>
                /// The tm pitch and family
                /// </summary>
                public byte tmPitchAndFamily;
                /// <summary>
                /// The tm character set
                /// </summary>
                public byte tmCharSet;
            }
            /// <summary>
            /// Selects the object.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="hgdiobj">The hgdiobj.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
            /// <summary>
            /// Gets the text metrics.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="lptm">The LPTM.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);
            /// <summary>
            /// Deletes the object.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern bool DeleteObject(IntPtr hdc);
            /// <summary>
            /// Generates the text metrics.
            /// </summary>
            /// <param name="graphics">The graphics.</param>
            /// <param name="font">The font.</param>
            /// <returns>TEXTMETRIC.</returns>
            private TEXTMETRIC GenerateTextMetrics(
                Graphics graphics,
                Font font)
            {
                IntPtr hDC = IntPtr.Zero;
                TEXTMETRIC textMetric;
                IntPtr hFont = IntPtr.Zero;
                try
                {
                    hDC = graphics.GetHdc();
                    hFont = font.ToHfont();
                    IntPtr hFontDefault = SelectObject(hDC, hFont);
                    bool result = GetTextMetrics(hDC, out textMetric);
                    SelectObject(hDC, hFontDefault);
                }
                finally
                {
                    if (hFont != IntPtr.Zero) DeleteObject(hFont);
                    if (hDC != IntPtr.Zero) graphics.ReleaseHdc(hDC);
                }
                return textMetric;
            }
            /// <summary>
            /// The metrics
            /// </summary>
            private TEXTMETRIC metrics;
            /// <summary>
            /// Gets the height.
            /// </summary>
            /// <value>The height.</value>
            public override int Height { get { return this.metrics.tmHeight; } }
            /// <summary>
            /// Gets the ascent.
            /// </summary>
            /// <value>The ascent.</value>
            public override int Ascent { get { return this.metrics.tmAscent; } }
            /// <summary>
            /// Gets the descent.
            /// </summary>
            /// <value>The descent.</value>
            public override int Descent { get { return this.metrics.tmDescent; } }
            /// <summary>
            /// Gets the internal leading.
            /// </summary>
            /// <value>The internal leading.</value>
            public override int InternalLeading { get { return this.metrics.tmInternalLeading; } }
            /// <summary>
            /// Gets the external leading.
            /// </summary>
            /// <value>The external leading.</value>
            public override int ExternalLeading { get { return this.metrics.tmExternalLeading; } }
            /// <summary>
            /// Gets the average width of the character.
            /// </summary>
            /// <value>The average width of the character.</value>
            public override int AverageCharacterWidth { get { return this.metrics.tmAveCharWidth; } }
            /// <summary>
            /// Gets the maximum width of the character.
            /// </summary>
            /// <value>The maximum width of the character.</value>
            public override int MaximumCharacterWidth { get { return this.metrics.tmMaxCharWidth; } }
            /// <summary>
            /// Gets the weight.
            /// </summary>
            /// <value>The weight.</value>
            public override int Weight { get { return this.metrics.tmWeight; } }
            /// <summary>
            /// Gets the overhang.
            /// </summary>
            /// <value>The overhang.</value>
            public override int Overhang { get { return this.metrics.tmOverhang; } }
            /// <summary>
            /// Gets the digitized aspect x.
            /// </summary>
            /// <value>The digitized aspect x.</value>
            public override int DigitizedAspectX { get { return this.metrics.tmDigitizedAspectX; } }
            /// <summary>
            /// Gets the digitized aspect y.
            /// </summary>
            /// <value>The digitized aspect y.</value>
            public override int DigitizedAspectY { get { return this.metrics.tmDigitizedAspectY; } }
            /// <summary>
            /// Initializes a new instance of the <see cref="FontMetricsImpl"/> class.
            /// </summary>
            /// <param name="graphics">The graphics.</param>
            /// <param name="font">The font.</param>
            private FontMetricsImpl(Graphics graphics, Font font)
            {
                this.metrics = this.GenerateTextMetrics(graphics, font);
            }
            /// <summary>
            /// Gets the font metrics.
            /// </summary>
            /// <param name="graphics">The graphics.</param>
            /// <param name="font">The font.</param>
            /// <returns>FontMetrics.</returns>
            public static FontMetrics GetFontMetrics(
                Graphics graphics,
                Font font)
            {
                return new FontMetricsImpl(graphics, font);
            }
        }
    }
    /// <summary>
    /// Enum RectangleEdgeFilter
    /// </summary>
    public enum RectangleEdgeFilter
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// The top right
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// The bottom left
        /// </summary>
        BottomLeft = 4,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight = 8,
        /// <summary>
        /// All
        /// </summary>
        All = TopLeft | TopRight | BottomLeft | BottomRight

    }
    /// <summary>
    /// Class FontMetrics.
    /// </summary>
    public abstract class FontMetrics
    {
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public virtual int Height { get { return 0; } }
        /// <summary>
        /// Gets the ascent.
        /// </summary>
        /// <value>The ascent.</value>
        public virtual int Ascent { get { return 0; } }
        /// <summary>
        /// Gets the descent.
        /// </summary>
        /// <value>The descent.</value>
        public virtual int Descent { get { return 0; } }
        /// <summary>
        /// Gets the internal leading.
        /// </summary>
        /// <value>The internal leading.</value>
        public virtual int InternalLeading { get { return 0; } }
        /// <summary>
        /// Gets the external leading.
        /// </summary>
        /// <value>The external leading.</value>
        public virtual int ExternalLeading { get { return 0; } }
        /// <summary>
        /// Gets the average width of the character.
        /// </summary>
        /// <value>The average width of the character.</value>
        public virtual int AverageCharacterWidth { get { return 0; } }
        /// <summary>
        /// Gets the maximum width of the character.
        /// </summary>
        /// <value>The maximum width of the character.</value>
        public virtual int MaximumCharacterWidth { get { return 0; } }
        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public virtual int Weight { get { return 0; } }
        /// <summary>
        /// Gets the overhang.
        /// </summary>
        /// <value>The overhang.</value>
        public virtual int Overhang { get { return 0; } }
        /// <summary>
        /// Gets the digitized aspect x.
        /// </summary>
        /// <value>The digitized aspect x.</value>
        public virtual int DigitizedAspectX { get { return 0; } }
        /// <summary>
        /// Gets the digitized aspect y.
        /// </summary>
        /// <value>The digitized aspect y.</value>
        public virtual int DigitizedAspectY { get { return 0; } }
    }
    #endregion

    #endregion
}
