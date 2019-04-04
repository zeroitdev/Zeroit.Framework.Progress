#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using Microsoft.Win32;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml;
//using System.Windows.Forms.VisualStyles;

using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region RoundRect

    // [CREDIT][DO NOT REMOVE]
    //
    // This module was written by Aeonhack
    //
    // [CREDIT][DO NOT REMOVE]

    static class RoundRectangle
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath GP = new GraphicsPath();
            int EndArcWidth = Curve * 2;
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
            GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90);
            GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90);
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90);
            GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return GP;
        }

        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath GP = new GraphicsPath();
            int EndArcWidth = Curve * 2;
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -180, 90);
            GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Y, EndArcWidth, EndArcWidth), -90, 90);
            GP.AddArc(new Rectangle(Rectangle.Width - EndArcWidth + Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 0, 90);
            GP.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y, EndArcWidth, EndArcWidth), 90, 90);
            GP.AddLine(new Point(Rectangle.X, Rectangle.Height - EndArcWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return GP;
        }
    }

    #endregion
    #region  Control Renderer
    #region  Color Table

    public abstract class xColorTable
    {
        public abstract Color TextColor { get; }
        public abstract Color Background { get; }
        public abstract Color SelectionBorder { get; }
        public abstract Color SelectionTopGradient { get; }
        public abstract Color SelectionMidGradient { get; }
        public abstract Color SelectionBottomGradient { get; }
        public abstract Color PressedBackground { get; }
        public abstract Color CheckedBackground { get; }
        public abstract Color CheckedSelectedBackground { get; }
        public abstract Color DropdownBorder { get; }
        public abstract Color Arrow { get; }
        public abstract Color OverflowBackground { get; }
    }

    public abstract class ColorTable
    {
        public abstract xColorTable CommonColorTable { get; }
        public abstract Color BackgroundTopGradient { get; }
        public abstract Color BackgroundBottomGradient { get; }
        public abstract Color DroppedDownItemBackground { get; }
        public abstract Color DropdownTopGradient { get; }
        public abstract Color DropdownBottomGradient { get; }
        public abstract Color Separator { get; }
        public abstract Color ImageMargin { get; }
    }

    public class MSColorTable : ColorTable
    {

        private xColorTable _CommonColorTable;

        public MSColorTable()
        {
            _CommonColorTable = new DefaultCColorTable();
        }

        public override xColorTable CommonColorTable
        {
            get
            {
                return _CommonColorTable;
            }
        }

        public override System.Drawing.Color BackgroundTopGradient
        {
            get
            {
                return Color.FromArgb(246, 246, 246);
            }
        }

        public override System.Drawing.Color BackgroundBottomGradient
        {
            get
            {
                return Color.FromArgb(226, 226, 226);
            }
        }

        public override System.Drawing.Color DropdownTopGradient
        {
            get
            {
                return Color.FromArgb(246, 246, 246);
            }
        }

        public override System.Drawing.Color DropdownBottomGradient
        {
            get
            {
                return Color.FromArgb(246, 246, 246);
            }
        }

        public override System.Drawing.Color DroppedDownItemBackground
        {
            get
            {
                return Color.FromArgb(240, 240, 240);
            }
        }

        public override System.Drawing.Color Separator
        {
            get
            {
                return Color.FromArgb(190, 195, 203);
            }
        }

        public override System.Drawing.Color ImageMargin
        {
            get
            {
                return Color.FromArgb(240, 240, 240);
            }
        }
    }

    public class DefaultCColorTable : xColorTable
    {

        public override System.Drawing.Color CheckedBackground
        {
            get
            {
                return Color.FromArgb(230, 230, 230);
            }
        }

        public override System.Drawing.Color CheckedSelectedBackground
        {
            get
            {
                return Color.FromArgb(230, 230, 230);
            }
        }

        public override System.Drawing.Color SelectionBorder
        {
            get
            {
                return Color.FromArgb(180, 180, 180);
            }
        }

        public override System.Drawing.Color SelectionTopGradient
        {
            get
            {
                return Color.FromArgb(240, 240, 240);
            }
        }

        public override System.Drawing.Color SelectionMidGradient
        {
            get
            {
                return Color.FromArgb(235, 235, 235);
            }
        }

        public override System.Drawing.Color SelectionBottomGradient
        {
            get
            {
                return Color.FromArgb(230, 230, 230);
            }
        }

        public override System.Drawing.Color PressedBackground
        {
            get
            {
                return Color.FromArgb(232, 232, 232);
            }
        }

        public override System.Drawing.Color TextColor
        {
            get
            {
                return Color.FromArgb(80, 80, 80);
            }
        }

        public override System.Drawing.Color Background
        {
            get
            {
                return Color.FromArgb(188, 199, 216);
            }
        }

        public override System.Drawing.Color DropdownBorder
        {
            get
            {
                return Color.LightGray;
            }
        }

        public override System.Drawing.Color Arrow
        {
            get
            {
                return Color.Black;
            }
        }

        public override System.Drawing.Color OverflowBackground
        {
            get
            {
                return Color.FromArgb(213, 220, 232);
            }
        }
    }

    #endregion
    #region  Renderer

    public class ControlRenderer : ToolStripProfessionalRenderer
    {

        public ControlRenderer()
            : this(new MSColorTable())
        {
        }

        public ControlRenderer(ColorTable ColorTable)
        {
            this.ColorTable = ColorTable;
        }

        private ColorTable _ColorTable;
        public new ColorTable ColorTable
        {
            get
            {
                if (_ColorTable == null)
                {
                    _ColorTable = new MSColorTable();
                }
                return _ColorTable;
            }
            set
            {
                _ColorTable = value;
            }
        }

        protected override void OnRenderToolStripBackground(System.Windows.Forms.ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);

            // Menu strip bar gradient
            using (LinearGradientBrush LGB = new LinearGradientBrush(e.AffectedBounds, this.ColorTable.BackgroundTopGradient, this.ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, e.AffectedBounds);
            }

        }

        protected override void OnRenderToolStripBorder(System.Windows.Forms.ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.Parent == null)
            {
                // Draw border around the menu drop-down
                Rectangle Rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
                {
                    e.Graphics.DrawRectangle(P1, Rect);
                }


                // Fill the gap between menu drop-down and owner item
                using (SolidBrush B1 = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
                {
                    e.Graphics.FillRectangle(B1, e.ConnectedArea);
                }

            }
        }

        protected override void OnRenderMenuItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                if (e.Item.Selected)
                {
                    if (!e.Item.IsOnDropDown)
                    {
                        Rectangle SelRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
                        RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, SelRect);
                    }
                    else
                    {
                        Rectangle SelRect = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
                        RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, SelRect);
                    }
                }

                if (((ToolStripMenuItem)e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
                {
                    Rectangle BorderRect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height);
                    // Fill the background
                    Rectangle BackgroundRect = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2);
                    using (SolidBrush B1 = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
                    {
                        e.Graphics.FillRectangle(B1, BackgroundRect);
                    }


                    // Draw border
                    using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
                    {
                        RectDrawing.DrawRoundedRectangle(e.Graphics, P1, System.Convert.ToSingle(BorderRect.X), System.Convert.ToSingle(BorderRect.Y), System.Convert.ToSingle(BorderRect.Width), System.Convert.ToSingle(BorderRect.Height), 2);
                    }

                }
                e.Item.ForeColor = this.ColorTable.CommonColorTable.TextColor;
            }
        }

        protected override void OnRenderItemText(System.Windows.Forms.ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = this.ColorTable.CommonColorTable.TextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderItemCheck(System.Windows.Forms.ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);

            Rectangle rect = new Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3);
            Color c = default(Color);

            if (e.Item.Selected)
            {
                c = this.ColorTable.CommonColorTable.CheckedSelectedBackground;
            }
            else
            {
                c = this.ColorTable.CommonColorTable.CheckedBackground;
            }

            using (SolidBrush b = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(b, rect);
            }


            using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
            {
                e.Graphics.DrawRectangle(p, rect);
            }


            e.Graphics.DrawString("ü", new Font("Wingdings", 13, FontStyle.Regular), Brushes.Black, new Point(4, 2));
        }

        protected override void OnRenderSeparator(System.Windows.Forms.ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            int PT1 = 28;
            int PT2 = System.Convert.ToInt32(e.Item.Width);
            int Y = 3;
            using (Pen P1 = new Pen(this.ColorTable.Separator))
            {
                e.Graphics.DrawLine(P1, PT1, Y, PT2, Y);
            }

        }

        protected override void OnRenderImageMargin(System.Windows.Forms.ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            Rectangle BackgroundRect = new Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1);
            using (LinearGradientBrush LGB = new LinearGradientBrush(BackgroundRect,
                    this.ColorTable.DropdownTopGradient,
                    this.ColorTable.DropdownBottomGradient,
                    LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(LGB, BackgroundRect);
            }


            using (SolidBrush B1 = new SolidBrush(this.ColorTable.ImageMargin))
            {
                e.Graphics.FillRectangle(B1, e.AffectedBounds);
            }

        }

        protected override void OnRenderButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            bool @checked = System.Convert.ToBoolean(((ToolStripButton)e.Item).Checked);
            bool drawBorder = false;

            if (@checked)
            {
                drawBorder = true;

                if (e.Item.Selected && !e.Item.Pressed)
                {
                    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.CheckedSelectedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }
                else
                {
                    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.CheckedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }

            }
            else
            {

                if (e.Item.Pressed)
                {
                    drawBorder = true;
                    using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                }
                else if (e.Item.Selected)
                {
                    drawBorder = true;
                    RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
                }

            }

            if (drawBorder)
            {
                using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }

            }
        }

        protected override void OnRenderDropDownButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
            bool drawBorder = false;

            if (e.Item.Pressed)
            {
                drawBorder = true;
                using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }
            else if (e.Item.Selected)
            {
                drawBorder = true;
                RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
            }

            if (drawBorder)
            {
                using (Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
                {
                    e.Graphics.DrawRectangle(p, rect);
                }

            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderSplitButtonBackground(e);
            bool drawBorder = false;
            bool drawSeparator = true;
            ToolStripSplitButton item = (ToolStripSplitButton)e.Item;
            checked
            {
                Rectangle btnRect = new Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1);
                Rectangle borderRect = new Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1);
                bool flag = item.DropDownButtonPressed;
                if (flag)
                {
                    drawBorder = true;
                    drawSeparator = false;
                    SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b, borderRect);
                    }
                    finally
                    {
                        flag = (b != null);
                        if (flag)
                        {
                            ((IDisposable)b).Dispose();
                        }
                    }
                }
                else
                {
                    flag = item.DropDownButtonSelected;
                    if (flag)
                    {
                        drawBorder = true;
                        RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, borderRect);
                    }
                }
                flag = item.ButtonPressed;
                if (flag)
                {
                    SolidBrush b2 = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground);
                    try
                    {
                        e.Graphics.FillRectangle(b2, btnRect);
                    }
                    finally
                    {
                        flag = (b2 != null);
                        if (flag)
                        {
                            ((IDisposable)b2).Dispose();
                        }
                    }
                }
                flag = drawBorder;
                if (flag)
                {
                    Pen p = new Pen(this.ColorTable.CommonColorTable.SelectionBorder);
                    try
                    {
                        e.Graphics.DrawRectangle(p, borderRect);
                        flag = drawSeparator;
                        if (flag)
                        {
                            e.Graphics.DrawRectangle(p, btnRect);
                        }
                    }
                    finally
                    {
                        flag = (p != null);
                        if (flag)
                        {
                            ((IDisposable)p).Dispose();
                        }
                    }
                    this.DrawCustomArrow(e.Graphics, item);
                }
            }
        }


        private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
        {
            int dropWidth = System.Convert.ToInt32(item.DropDownButtonBounds.Width - 1);
            int dropHeight = System.Convert.ToInt32(item.DropDownButtonBounds.Height - 1);
            float triangleWidth = dropWidth / 2.0F + 1;
            float triangleLeft = System.Convert.ToSingle(item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F);
            float triangleHeight = triangleWidth / 2.0F;
            float triangleTop = System.Convert.ToSingle(item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1);
            RectangleF arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);

            this.DrawCustomArrow(g, item, Rectangle.Round(arrowRect));
        }

        private void DrawCustomArrow(Graphics g, ToolStripItem item, Rectangle rect)
        {
            ToolStripArrowRenderEventArgs arrowEventArgs = new ToolStripArrowRenderEventArgs(g, item, rect, this.ColorTable.CommonColorTable.Arrow, ArrowDirection.Down);
            base.OnRenderArrow(arrowEventArgs);
        }

        protected override void OnRenderOverflowButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            Rectangle rect = default(Rectangle);
            Rectangle rectEnd = default(Rectangle);
            rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2);
            rectEnd = new Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height);

            if (e.Item.Pressed)
            {
                using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }
            else if (e.Item.Selected)
            {
                RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
            }
            else
            {
                using (SolidBrush b = new SolidBrush(this.ColorTable.CommonColorTable.OverflowBackground))
                {
                    e.Graphics.FillRectangle(b, rect);
                }

            }

            using (Pen P1 = new Pen(this.ColorTable.CommonColorTable.Background))
            {
                RectDrawing.DrawRoundedRectangle(e.Graphics, P1, System.Convert.ToSingle(rectEnd.X), System.Convert.ToSingle(rectEnd.Y), System.Convert.ToSingle(rectEnd.Width), System.Convert.ToSingle(rectEnd.Height), 3);
            }


            // Icon
            int w = System.Convert.ToInt32(rect.Width - 1);
            int h = System.Convert.ToInt32(rect.Height - 1);
            float triangleWidth = w / 2.0F + 1;
            float triangleLeft = System.Convert.ToSingle(rect.Left + (w - triangleWidth) / 2.0F + 3);
            float triangleHeight = triangleWidth / 2.0F;
            float triangleTop = System.Convert.ToSingle(rect.Top + (h - triangleHeight) / 2.0F + 7);
            RectangleF arrowRect = new RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight);
            this.DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect));

            using (Pen p = new Pen(this.ColorTable.CommonColorTable.Arrow))
            {
                e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2, triangleTop - 2);
            }

        }
    }

    #endregion
    #region  Drawing

    public class RectDrawing
    {

        public static void DrawSelection(Graphics G, xColorTable ColorTable, Rectangle Rect)
        {
            Rectangle TopRect = default(Rectangle);
            Rectangle BottomRect = default(Rectangle);
            Rectangle FillRect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

            TopRect = FillRect;
            TopRect.Height -= System.Convert.ToInt32(TopRect.Height / 2);
            BottomRect = new Rectangle(TopRect.X, TopRect.Bottom, TopRect.Width, FillRect.Height - TopRect.Height);

            // Top gradient
            using (LinearGradientBrush LGB = new LinearGradientBrush(TopRect, ColorTable.SelectionTopGradient, ColorTable.SelectionMidGradient, LinearGradientMode.Vertical))
            {
                G.FillRectangle(LGB, TopRect);
            }


            // Bottom
            using (SolidBrush B1 = new SolidBrush(ColorTable.SelectionBottomGradient))
            {
                G.FillRectangle(B1, BottomRect);
            }


            // Border
            using (Pen P1 = new Pen(ColorTable.SelectionBorder))
            {
                RectDrawing.DrawRoundedRectangle(G, P1, System.Convert.ToSingle(Rect.X), System.Convert.ToSingle(Rect.Y), System.Convert.ToSingle(Rect.Width), System.Convert.ToSingle(Rect.Height), 2);
            }

        }

        public static void DrawRoundedRectangle(Graphics G, Pen P, float X, float Y, float W, float H, float Rad)
        {

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddLine(X + Rad, Y, X + W - (Rad * 2), Y);
                gp.AddArc(X + W - (Rad * 2), Y, Rad * 2, Rad * 2, 270, 90);
                gp.AddLine(X + W, Y + Rad, X + W, Y + H - (Rad * 2));
                gp.AddArc(X + W - (Rad * 2), Y + H - (Rad * 2), Rad * 2, Rad * 2, 0, 90);
                gp.AddLine(X + W - (Rad * 2), Y + H, X + Rad, Y + H);
                gp.AddArc(X, Y + H - (Rad * 2), Rad * 2, Rad * 2, 90, 90);
                gp.AddLine(X, Y + H - (Rad * 2), X, Y + Rad);
                gp.AddArc(X, Y, Rad * 2, Rad * 2, 180, 90);
                gp.CloseFigure();

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.DrawPath(P, gp);
                G.SmoothingMode = SmoothingMode.Default;
            }

        }
    }

    #endregion

    #endregion
    #region ThemeContainer154 for ZeroitKeyBoard
    public abstract class ThemeContainer154 : ContainerControl
    {

        #region " Initialization "

        protected Graphics G;

        protected Bitmap B;
        public ThemeContainer154()
        {
            SetStyle((ControlStyles)139270, true);

            _ImageSize = Size.Empty;
            Font = new Font("Verdana", 8);

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            DrawRadialPath = new GraphicsPath();

            InvalidateCustimization();
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            if (DoneCreation)
                InitializeMessages();

            InvalidateCustimization();
            ColorHook();

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;
            if (!_ControlMode)
                base.Dock = DockStyle.Fill;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        private bool DoneCreation;
        protected override sealed void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (Parent == null)
                return;
            _IsParentForm = Parent is Form;

            if (!_ControlMode)
            {
                InitializeMessages();

                if (_IsParentForm)
                {
                    ParentForm.FormBorderStyle = _BorderStyle;
                    ParentForm.TransparencyKey = _TransparencyKey;

                    if (!DesignMode)
                    {
                        ParentForm.Shown += FormShown;
                    }
                }

                Parent.BackColor = BackColor;
            }

            OnCreation();
            DoneCreation = true;
            InvalidateTimer();
        }

        #endregion

        private void DoAnimation(bool i)
        {
            OnAnimation();
            if (i)
                Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (_Transparent && _ControlMode)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
            else
            {
                G = e.Graphics;
                PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
            base.OnHandleDestroyed(e);
        }

        private bool HasShown;
        private void FormShown(object sender, EventArgs e)
        {
            if (_ControlMode || HasShown)
                return;

            if (_StartPosition == FormStartPosition.CenterParent || _StartPosition == FormStartPosition.CenterScreen)
            {
                Rectangle SB = Screen.PrimaryScreen.Bounds;
                Rectangle CB = ParentForm.Bounds;
                ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
            }

            HasShown = true;
        }


        #region " Size Handling "

        private Rectangle Frame;
        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Movable && !_ControlMode)
            {
                Frame = new Rectangle(7, 7, Width - 14, _Header - 7);
            }

            InvalidateBitmap();
            Invalidate();

            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
            {
                if (_Sizable && !_ControlMode)
                    InvalidateMouse();
            }

            base.OnMouseMove(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetState(MouseState.None);

            if (GetChildAtPoint(PointToClient(MousePosition)) != null)
            {
                if (_Sizable && !_ControlMode)
                {
                    Cursor = Cursors.Default;
                    Previous = 0;
                }
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SetState(MouseState.Down);

            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
            {
                if (_Movable && Frame.Contains(e.Location))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[0]);
                }
                else if (_Sizable && !(Previous == 0))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[Previous]);
                }
            }

            base.OnMouseDown(e);
        }

        private bool WM_LMBUTTONDOWN;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WM_LMBUTTONDOWN && m.Msg == 513)
            {
                WM_LMBUTTONDOWN = false;

                SetState(MouseState.Over);
                if (!_SmartBounds)
                    return;

                if (IsParentMdi)
                {
                    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
                }
                else
                {
                    CorrectBounds(Screen.FromControl(Parent).WorkingArea);
                }
            }
        }

        private Point GetIndexPoint;
        private bool B1;
        private bool B2;
        private bool B3;
        private bool B4;
        private int GetIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1 = GetIndexPoint.X < 7;
            B2 = GetIndexPoint.X > Width - 7;
            B3 = GetIndexPoint.Y < 7;
            B4 = GetIndexPoint.Y > Height - 7;

            if (B1 && B3)
                return 4;
            if (B1 && B4)
                return 7;
            if (B2 && B3)
                return 5;
            if (B2 && B4)
                return 8;
            if (B1)
                return 1;
            if (B2)
                return 2;
            if (B3)
                return 3;
            if (B4)
                return 6;
            return 0;
        }

        private int Current;
        private int Previous;
        private void InvalidateMouse()
        {
            Current = GetIndex();
            if (Current == Previous)
                return;

            Previous = Current;
            switch (Previous)
            {
                case 0:
                    Cursor = Cursors.Default;
                    break;
                case 1:
                case 2:
                    Cursor = Cursors.SizeWE;
                    break;
                case 3:
                case 6:
                    Cursor = Cursors.SizeNS;
                    break;
                case 4:
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 5:
                case 7:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        private Message[] Messages = new Message[9];
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (Parent.Width > bounds.Width)
                Parent.Width = bounds.Width;
            if (Parent.Height > bounds.Height)
                Parent.Height = bounds.Height;

            int X = Parent.Location.X;
            int Y = Parent.Location.Y;

            if (X < bounds.X)
                X = bounds.X;
            if (Y < bounds.Y)
                Y = bounds.Y;

            int Width = bounds.X + bounds.Width;
            int Height = bounds.Y + bounds.Height;

            if (X + Parent.Width > Width)
                X = Width - Parent.Width;
            if (Y + Parent.Height > Height)
                Y = Height - Parent.Height;

            Parent.Location = new Point(X, Y);
        }

        #endregion


        #region " Base Properties "

        public override DockStyle Dock
        {
            get { return base.Dock; }
            set
            {
                if (!_ControlMode)
                    return;
                base.Dock = value;
            }
        }

        private bool _BackColor;
        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (value == base.BackColor)
                    return;

                if (!IsHandleCreated && _ControlMode && value == Color.Transparent)
                {
                    _BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (Parent != null)
                {
                    if (!_ControlMode)
                        Parent.BackColor = value;
                    ColorHook();
                }
            }
        }

        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set
            {
                base.MinimumSize = value;
                if (Parent != null)
                    Parent.MinimumSize = value;
            }
        }

        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = value;
                if (Parent != null)
                    Parent.MaximumSize = value;
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        #endregion

        #region " Public Properties "

        private bool _SmartBounds = true;
        public bool SmartBounds
        {
            get { return _SmartBounds; }
            set { _SmartBounds = value; }
        }

        private bool _Movable = true;
        public bool Movable
        {
            get { return _Movable; }
            set { _Movable = value; }
        }

        private bool _Sizable = true;
        public bool Sizable
        {
            get { return _Sizable; }
            set { _Sizable = value; }
        }

        private Color _TransparencyKey;
        public Color TransparencyKey
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.TransparencyKey;
                else
                    return _TransparencyKey;
            }
            set
            {
                if (value == _TransparencyKey)
                    return;
                _TransparencyKey = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.TransparencyKey = value;
                    ColorHook();
                }
            }
        }

        private FormBorderStyle _BorderStyle;
        public FormBorderStyle BorderStyle
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.FormBorderStyle;
                else
                    return _BorderStyle;
            }
            set
            {
                _BorderStyle = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.FormBorderStyle = value;

                    if (!(value == FormBorderStyle.None))
                    {
                        Movable = false;
                        Sizable = false;
                    }
                }
            }
        }

        private FormStartPosition _StartPosition;
        public FormStartPosition StartPosition
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.StartPosition;
                else
                    return _StartPosition;
            }
            set
            {
                _StartPosition = value;

                if (_IsParentForm && !_ControlMode)
                {
                    ParentForm.StartPosition = value;
                }
            }
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                    _ImageSize = Size.Empty;
                else
                    _ImageSize = value.Size;

                _Image = value;
                Invalidate();
            }
        }

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        private bool _Transparent;
        public bool Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (!(IsHandleCreated || _ControlMode))
                    return;

                if (!value && !(BackColor.A == 255))
                {
                    throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                }

                SetStyle(ControlStyles.Opaque, !value);
                SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                InvalidateBitmap();
                Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private Size _ImageSize;
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        private bool _IsParentForm;
        protected bool IsParentForm
        {
            get { return _IsParentForm; }
        }

        protected bool IsParentMdi
        {
            get
            {
                if (Parent == null)
                    return false;
                return Parent.Parent != null;
            }
        }

        private int _LockWidth;
        protected int LockWidth
        {
            get { return _LockWidth; }
            set
            {
                _LockWidth = value;
                if (!(LockWidth == 0) && IsHandleCreated)
                    Width = LockWidth;
            }
        }

        private int _LockHeight;
        protected int LockHeight
        {
            get { return _LockHeight; }
            set
            {
                _LockHeight = value;
                if (!(LockHeight == 0) && IsHandleCreated)
                    Height = LockHeight;
            }
        }

        private int _Header = 24;
        protected int Header
        {
            get { return _Header; }
            set
            {
                _Header = value;

                if (!_ControlMode)
                {
                    Frame = new Rectangle(7, 7, Width - 14, value - 7);
                    Invalidate();
                }
            }
        }

        private bool _ControlMode;
        protected bool ControlMode
        {
            get { return _ControlMode; }
            set
            {
                _ControlMode = value;

                Transparent = _Transparent;
                if (_Transparent && _BackColor)
                    BackColor = Color.Transparent;

                InvalidateBitmap();
                Invalidate();
            }
        }

        private bool _IsAnimated;
        protected bool IsAnimated
        {
            get { return _IsAnimated; }
            set
            {
                _IsAnimated = value;
                InvalidateTimer();
            }
        }

        #endregion


        #region " Property Helpers "

        protected Pen GetPen(string name)
        {
            return new Pen(Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(Items[name], width);
        }

        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(Items[name]);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (Items.ContainsKey(name))
                Items[name] = value;
            else
                Items.Add(name, value);
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            SetColor(name, Color.FromArgb(a, value));
        }

        private void InvalidateBitmap()
        {
            if (_Transparent && _ControlMode)
            {
                if (Width == 0 || Height == 0)
                    return;
                B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
                G = Graphics.FromImage(B);
            }
            else
            {
                G = null;
                B = null;
            }
        }

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (DesignMode || !DoneCreation)
                return;

            if (_IsAnimated)
            {
                ThemeShare.AddAnimationCallback(DoAnimation);
            }
            else
            {
                ThemeShare.RemoveAnimationCallback(DoAnimation);
            }
        }

        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        protected virtual void OnCreation()
        {
        }

        protected virtual void OnAnimation()
        {
        }

        #endregion


        #region " Offset "

        private Rectangle OffsetReturnRectangle;
        protected Rectangle Offset(Rectangle r, int amount)
        {
            OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return OffsetReturnRectangle;
        }

        private Size OffsetReturnSize;
        protected Size Offset(Size s, int amount)
        {
            OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return OffsetReturnSize;
        }

        private Point OffsetReturnPoint;
        protected Point Offset(Point p, int amount)
        {
            OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return OffsetReturnPoint;
        }

        #endregion

        #region " Center "


        private Point CenterReturn;
        protected Point Center(Rectangle p, Rectangle c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return CenterReturn;
        }

        protected Point Center(Rectangle child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return Center(Width, Height, childWidth, childHeight);
        }

        protected Point Center(Size p, Size c)
        {
            return Center(p.Width, p.Height, c.Width, c.Height);
        }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;
        protected Size Measure()
        {
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
            }
        }
        protected Size Measure(string text)
        {
            lock (MeasureGraphics)
            {
                return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
            }
        }

        #endregion


        #region " DrawPixel "


        private SolidBrush DrawPixelBrush;
        protected void DrawPixel(Color c1, int x, int y)
        {
            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
            }
            else
            {
                DrawPixelBrush = new SolidBrush(c1);
                G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1, int offset)
        {
            DrawCorners(c1, 0, 0, Width, Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;

            DrawTextSize = Measure(text);
            DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, Header / 2 - DrawTextSize.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, p1);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = new Point(Width / 2 - image.Width / 2, Header / 2 - image.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }


        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;

        private Rectangle DrawRadialRectangle;
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            DrawRadialPath.Reset();
            DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
            DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            DrawRadialBrush1.InterpolationColors = blend;

            if (G.SmoothingMode == SmoothingMode.AntiAlias)
            {
                G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            }
            else
            {
                G.FillEllipse(DrawRadialBrush1, r);
            }
        }


        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawGradientRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            G.FillEllipse(DrawGradientBrush, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

    }

    public abstract class ThemeControl154 : Control
    {


        #region " Initialization "

        protected Graphics G;

        protected Bitmap B;
        public ThemeControl154()
        {
            SetStyle((ControlStyles)139270, true);

            _ImageSize = Size.Empty;
            Font = new Font("Verdana", 8);

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            DrawRadialPath = new GraphicsPath();

            InvalidateCustimization();
            //Remove?
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            InvalidateCustimization();
            ColorHook();

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;

            Transparent = _Transparent;
            if (_Transparent && _BackColor)
                BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        private bool DoneCreation;
        protected override sealed void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                OnCreation();
                DoneCreation = true;
                InvalidateTimer();
            }

            base.OnParentChanged(e);
        }

        #endregion

        private void DoAnimation(bool i)
        {
            OnAnimation();
            if (i)
                Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (_Transparent)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
            else
            {
                G = e.Graphics;
                PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(DoAnimation);
            base.OnHandleDestroyed(e);
        }

        #region " Size Handling "

        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Transparent)
            {
                InvalidateBitmap();
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        private bool InPosition;
        protected override void OnMouseEnter(EventArgs e)
        {
            InPosition = true;
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (InPosition)
                SetState(MouseState.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SetState(MouseState.Down);
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            InPosition = false;
            SetState(MouseState.None);
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        #endregion


        #region " Base Properties "

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        private bool _BackColor;
        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (!IsHandleCreated && value == Color.Transparent)
                {
                    _BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (Parent != null)
                    ColorHook();
            }
        }

        #endregion

        #region " Public Properties "

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        private bool _Transparent;
        public bool Transparent
        {
            get { return _Transparent; }
            set
            {
                _Transparent = value;
                if (!IsHandleCreated)
                    return;

                if (!value && !(BackColor.A == 255))
                {
                    throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                }

                SetStyle(ControlStyles.Opaque, !value);
                SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                if (value)
                    InvalidateBitmap();
                else
                    B = null;
                Invalidate();
            }
        }

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private Size _ImageSize;
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        private int _LockWidth;
        protected int LockWidth
        {
            get { return _LockWidth; }
            set
            {
                _LockWidth = value;
                if (!(LockWidth == 0) && IsHandleCreated)
                    Width = LockWidth;
            }
        }

        private int _LockHeight;
        protected int LockHeight
        {
            get { return _LockHeight; }
            set
            {
                _LockHeight = value;
                if (!(LockHeight == 0) && IsHandleCreated)
                    Height = LockHeight;
            }
        }

        private bool _IsAnimated;
        protected bool IsAnimated
        {
            get { return _IsAnimated; }
            set
            {
                _IsAnimated = value;
                InvalidateTimer();
            }
        }

        #endregion


        #region " Property Helpers "

        protected Pen GetPen(string name)
        {
            return new Pen(Items[name]);
        }
        protected Pen GetPen(string name, float width)
        {
            return new Pen(Items[name], width);
        }

        protected SolidBrush GetBrush(string name)
        {
            return new SolidBrush(Items[name]);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (Items.ContainsKey(name))
                Items[name] = value;
            else
                Items.Add(name, value);
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }
        protected void SetColor(string name, byte a, Color value)
        {
            SetColor(name, Color.FromArgb(a, value));
        }

        private void InvalidateBitmap()
        {
            if (Width == 0 || Height == 0)
                return;
            B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            G = Graphics.FromImage(B);
        }

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (DesignMode || !DoneCreation)
                return;

            if (_IsAnimated)
            {
                ThemeShare.AddAnimationCallback(DoAnimation);
            }
            else
            {
                ThemeShare.RemoveAnimationCallback(DoAnimation);
            }
        }
        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        protected virtual void OnCreation()
        {
        }

        protected virtual void OnAnimation()
        {
        }

        #endregion


        #region " Offset "

        private Rectangle OffsetReturnRectangle;
        protected Rectangle Offset(Rectangle r, int amount)
        {
            OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return OffsetReturnRectangle;
        }

        private Size OffsetReturnSize;
        protected Size Offset(Size s, int amount)
        {
            OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return OffsetReturnSize;
        }

        private Point OffsetReturnPoint;
        protected Point Offset(Point p, int amount)
        {
            OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return OffsetReturnPoint;
        }

        #endregion

        #region " Center "


        private Point CenterReturn;
        protected Point Center(Rectangle p, Rectangle c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle p, Size c)
        {
            CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return CenterReturn;
        }

        protected Point Center(Rectangle child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(Size child)
        {
            return Center(Width, Height, child.Width, child.Height);
        }
        protected Point Center(int childWidth, int childHeight)
        {
            return Center(Width, Height, childWidth, childHeight);
        }

        protected Point Center(Size p, Size c)
        {
            return Center(p.Width, p.Height, c.Width, c.Height);
        }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;
        //TODO: Potential issues during multi-threading.
        private Graphics MeasureGraphics;

        protected Size Measure()
        {
            return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
        }
        protected Size Measure(string text)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }

        #endregion


        #region " DrawPixel "


        private SolidBrush DrawPixelBrush;
        protected void DrawPixel(Color c1, int x, int y)
        {
            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
            }
            else
            {
                DrawPixelBrush = new SolidBrush(c1);
                G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1, int offset)
        {
            DrawCorners(c1, 0, 0, Width, Height, offset);
        }
        protected void DrawCorners(Color c1, Rectangle r1, int offset)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
        {
            DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;

            DrawTextSize = Measure(text);
            DrawTextPoint = Center(DrawTextSize);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, p1);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            if (Text.Length == 0)
                return;
            G.DrawString(Text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = Center(image.Size);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle);
        }
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }


        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private GraphicsPath DrawRadialPath;
        private PathGradientBrush DrawRadialBrush1;
        private LinearGradientBrush DrawRadialBrush2;

        private Rectangle DrawRadialRectangle;
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(blend, DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r)
        {
            DrawRadial(blend, r, r.Width / 2, r.Height / 2);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
        {
            DrawRadial(blend, r, center.X, center.Y);
        }
        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            DrawRadialPath.Reset();
            DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
            DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            DrawRadialBrush1.InterpolationColors = blend;

            if (G.SmoothingMode == SmoothingMode.AntiAlias)
            {
                G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            }
            else
            {
                G.FillEllipse(DrawRadialBrush1, r);
            }
        }


        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawRadialRectangle);
        }
        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawRadialRectangle = new Rectangle(x, y, width, height);
            DrawRadial(c1, c2, DrawRadialRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillEllipse(DrawRadialBrush2, r);
        }
        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            G.FillEllipse(DrawRadialBrush2, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion

    }

    public static class ThemeShare
    {

        #region " Animation "

        private static int Frames;
        private static bool Invalidate;

        private static PrecisionTimer ThemeTimer = new PrecisionTimer();
        //1000 / 50 = 20 FPS
        private const int FPS = 50;

        private const int Rate = 10;
        public delegate void AnimationDelegate(bool invalidate);


        private static List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();
        private static void HandleCallbacks(IntPtr state, bool reserve)
        {
            Invalidate = (Frames >= FPS);
            if (Invalidate)
                Frames = 0;

            lock (Callbacks)
            {
                for (int I = 0; I <= Callbacks.Count - 1; I++)
                {
                    Callbacks[I].Invoke(Invalidate);
                }
            }

            Frames += Rate;
        }

        private static void InvalidateThemeTimer()
        {
            if (Callbacks.Count == 0)
            {
                ThemeTimer.Delete();
            }
            else
            {
                ThemeTimer.Create(0, Rate, HandleCallbacks);
            }
        }

        public static void AddAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (Callbacks.Contains(callback))
                    return;

                Callbacks.Add(callback);
                InvalidateThemeTimer();
            }
        }

        public static void RemoveAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (!Callbacks.Contains(callback))
                    return;

                Callbacks.Remove(callback);
                InvalidateThemeTimer();
            }
        }

        #endregion

    }

    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    public struct Bloom
    {

        public string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private Color _Value;
        public Color Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string ValueHex
        {
            get { return string.Concat("#", _Value.R.ToString("X2", null), _Value.G.ToString("X2", null), _Value.B.ToString("X2", null)); }
            set
            {
                try
                {
                    _Value = ColorTranslator.FromHtml(value);
                }
                catch
                {
                    return;
                }
            }
        }


        public Bloom(string name, Color value)
        {
            _Name = name;
            _Value = value;
        }
    }

    //------------------
    //Creator: aeonhack
    //Site: elitevs.net
    //Created: 11/30/2011
    //Changed: 11/30/2011
    //Version: 1.0.0
    //------------------
    class PrecisionTimer : IDisposable
    {

        private bool _Enabled;
        public bool Enabled
        {
            get { return _Enabled; }
        }

        private IntPtr Handle;

        private TimerDelegate TimerCallback;
        [DllImport("kernel32.dll", EntryPoint = "CreateTimerQueueTimer")]
        private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

        [DllImport("kernel32.dll", EntryPoint = "DeleteTimerQueueTimer")]
        private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

        public delegate void TimerDelegate(IntPtr r1, bool r2);

        public void Create(uint dueTime, uint period, TimerDelegate callback)
        {
            if (_Enabled)
                return;

            TimerCallback = callback;
            bool Success = CreateTimerQueueTimer(ref Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0);

            if (!Success)
                ThrowNewException("CreateTimerQueueTimer");
            _Enabled = Success;
        }

        public void Delete()
        {
            if (!_Enabled)
                return;
            bool Success = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero);

            if (!Success && !(Marshal.GetLastWin32Error() == 997))
            {
                ThrowNewException("DeleteTimerQueueTimer");
            }

            _Enabled = !Success;
        }

        private void ThrowNewException(string name)
        {
            throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
        }

        public void Dispose()
        {
            Delete();
        }
    }

    #endregion
    #region Helpers for ZeroitButtonAwesome, ZeroitDropDownCombo, ZeroitGroupBox
    static class Draw
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        //Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        //    Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        //    Dim P As GraphicsPath = New GraphicsPath()
        //    Dim ArcRectangleWidth As Integer = Curve * 2
        //    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        //    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        //    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        //    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        //    P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        //    Return P
        //End Function
    }
    public abstract class ThemeControl : Control
    {

        #region " Initialization "

        protected Graphics G;
        protected Bitmap B;
        public ThemeControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region " Mouse Handling "

        protected enum State : byte
        {
            MouseNone = 0,
            MouseOver = 1,
            MouseDown = 2
        }

        protected State MouseState;
        protected override void OnMouseLeave(EventArgs e)
        {
            ChangeMouseState(State.MouseNone);
            base.OnMouseLeave(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ChangeMouseState(State.MouseDown);
            base.OnMouseDown(e);
        }

        private void ChangeMouseState(State e)
        {
            MouseState = e;
            Invalidate();
        }

        #endregion

        #region " Convienence "

        public abstract void PaintHook();
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!(Width == 0) && !(Height == 0))
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                    return 0;
                return _Image.Width;
            }
        }
        public int ImageTop
        {
            get
            {
                if (_Image == null)
                    return 0;
                return Height / 2 - _Image.Height / 2;
            }
        }

        private Size _Size;
        private Rectangle _Rectangle;
        private LinearGradientBrush _Gradient;

        private SolidBrush _Brush;
        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
                return;

            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
                return;
            _Size = G.MeasureString(Text, Font).ToSize();
            _Brush = new SolidBrush(c);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(Text, Font, _Brush, x, Height / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, Height / 2 - _Size.Height / 2 + y);
                    break;
            }
        }

        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
                return;
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, Height / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, Height / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, Width / 2 - _Image.Width / 2, Height / 2 - _Image.Height / 2);
                    break;
            }
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }

    public abstract class Theme : ContainerControl
    {

        #region " Initialization "

        protected Graphics G;
        public Theme()
        {
            SetStyle((ControlStyles)139270, true);
        }

        private bool ParentIsForm;
        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            ParentIsForm = Parent is Form;
            if (ParentIsForm)
            {
                if (!(_TransparencyKey == Color.Empty))
                    ParentForm.TransparencyKey = _TransparencyKey;
                ParentForm.FormBorderStyle = FormBorderStyle.None;
            }
            base.OnHandleCreated(e);
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region " Sizing and Movement "

        private bool _Resizable = true;
        public bool Resizable
        {
            get { return _Resizable; }
            set { _Resizable = value; }
        }

        private int _MoveHeight = 24;
        public int MoveHeight
        {
            get { return _MoveHeight; }
            set
            {
                _MoveHeight = value;
                Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            }
        }

        private IntPtr Flag;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left))
                return;
            if (ParentIsForm)
                if (ParentForm.WindowState == FormWindowState.Maximized)
                    return;

            if (Header.Contains(e.Location))
            {
                Flag = new IntPtr(2);
            }
            else if (Current.Position == 0 | !_Resizable)
            {
                return;
            }
            else
            {
                Flag = new IntPtr(Current.Position);
            }

            Capture = false;
            //DefWndProc(Message.Create(Parent.Handle, 161, Flag, null));

            base.OnMouseDown(e);
        }

        private struct Pointer
        {
            public readonly Cursor Cursor;
            public readonly byte Position;
            public Pointer(Cursor c, byte p)
            {
                Cursor = c;
                Position = p;
            }
        }

        private bool F1;
        private bool F2;
        private bool F3;
        private bool F4;
        private Point PTC;
        private Pointer GetPointer()
        {
            PTC = PointToClient(MousePosition);
            F1 = PTC.X < 7;
            F2 = PTC.X > Width - 7;
            F3 = PTC.Y < 7;
            F4 = PTC.Y > Height - 7;

            if (F1 & F3)
                return new Pointer(Cursors.SizeNWSE, 13);
            if (F1 & F4)
                return new Pointer(Cursors.SizeNESW, 16);
            if (F2 & F3)
                return new Pointer(Cursors.SizeNESW, 14);
            if (F2 & F4)
                return new Pointer(Cursors.SizeNWSE, 17);
            if (F1)
                return new Pointer(Cursors.SizeWE, 10);
            if (F2)
                return new Pointer(Cursors.SizeWE, 11);
            if (F3)
                return new Pointer(Cursors.SizeNS, 12);
            if (F4)
                return new Pointer(Cursors.SizeNS, 15);
            return new Pointer(Cursors.Default, 0);
        }

        private Pointer Current;
        private Pointer Pending;
        private void SetCurrent()
        {
            Pending = GetPointer();
            if (Current.Position == Pending.Position)
                return;
            Current = GetPointer();
            Cursor = Current.Cursor;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_Resizable)
                SetCurrent();
            base.OnMouseMove(e);
        }

        protected Rectangle Header;
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            Invalidate();
            base.OnSizeChanged(e);
        }

        #endregion

        #region " Convienence "

        public abstract void PaintHook();
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            G = e.Graphics;
            PaintHook();
        }

        private Color _TransparencyKey;
        public Color TransparencyKey
        {
            get { return _TransparencyKey; }
            set
            {
                _TransparencyKey = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                    return 0;
                return _Image.Width;
            }
        }

        private Size _Size;
        private Rectangle _Rectangle;
        private LinearGradientBrush _Gradient;

        private SolidBrush _Brush;
        protected void DrawCorners(Color c, Rectangle rect)
        {
            _Brush = new SolidBrush(c);
            G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
                return;
            _Size = G.MeasureString(Text, Font).ToSize();
            _Brush = new SolidBrush(c);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(Text, Font, _Brush, x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
            }
        }

        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
                return;
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, Width / 2 - _Image.Width / 2, _MoveHeight / 2 - _Image.Height / 2);
                    break;
            }
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }

        #endregion

    }

    abstract class ThemeContainerControl : ContainerControl
    {

        #region " Initialization "

        protected Graphics G;
        protected Bitmap B;
        public ThemeContainerControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion
        #region " Convienence "

        public abstract void PaintHook();
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!(Width == 0) && !(Height == 0))
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Rectangle _Rectangle;

        private LinearGradientBrush _Gradient;
        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
                return;
            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }
    #endregion
    #region Helper Class For ZeroitButtonAlert
    public static class Helpers
    {


        public static Rectangle FullRectangle(Size S, bool Subtract)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
            }
            else
            {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        public static Color GreyColor(uint G)
        {
            return Color.FromArgb((int)G, (int)G, (int)G);
        }

        public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point(R.Width / 2 - (int)(TS.Width / 2), R.Height / 2 - (int)(TS.Height / 2)));
            }
        }


        public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
                G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
            }

        }


        public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            }

        }

        public enum Direction : byte
        {
            Up = 0,
            Down = 1,
            Left = 2,
            Right = 3
        }

        public static void DrawTriangle(Graphics G, Rectangle Rect, Direction D, Color C)
        {
            int halfWidth = Rect.Width / 2;
            int halfHeight = Rect.Height / 2;
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;

            switch (D)
            {
                case Direction.Up:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Top);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Down:
                    p0 = new Point(Rect.Left + halfWidth, Rect.Bottom);
                    p1 = new Point(Rect.Left, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Top);

                    break;
                case Direction.Left:
                    p0 = new Point(Rect.Left, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Right, Rect.Top);
                    p2 = new Point(Rect.Right, Rect.Bottom);

                    break;
                case Direction.Right:
                    p0 = new Point(Rect.Right, Rect.Top + halfHeight);
                    p1 = new Point(Rect.Left, Rect.Bottom);
                    p2 = new Point(Rect.Left, Rect.Top);

                    break;
            }

            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPolygon(B, new Point[] {
                p0,
                p1,
                p2
            });
            }

        }

    }

    #endregion

    #region Circular ProgressBar Default

    public class ZeroitProgressBarCircularDefault : Control
    {

        #region Enums

        public enum _ProgressShape
        {
            Round,
            Flat
        }

        #endregion
        #region Variables

        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private _ProgressShape ProgressShapeVal;

        #endregion
        #region Custom Properties

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
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

        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public _ProgressShape ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        #endregion
        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        public ZeroitProgressBarCircularDefault()
        {
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            DoubleBuffered = true;
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(this.BackColor);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, 10f))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case _ProgressShape.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case _ProgressShape.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }
                            graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0x34, 0x34, 0x34), Color.FromArgb(0x34, 0x34, 0x34), LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                    }
                    SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, Brushes.White, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }
    }

    #endregion
    #region Circular ProgressBar

    public class ZeroitProgressBarCircular : Control
    {

        #region Enums

        public enum _ProgressShape
        {
            AnchorMask,
            ArrowAnchor,
            Custom,
            DiamondAnchor,
            Flat,
            NoAnchor,
            Round,
            RoundAnchor,
            Square,
            SquareAnchor,
            Triangle
        }

        #endregion
        #region Variables

        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private Color _FillEllipse1 = Color.Black;
        private Color _FillEllipse2 = Color.Gray;
        private Color _TextColor = Color.White;
        private Color _ProgressColorInnerBorder = Color.Transparent;
        private _ProgressShape ProgressShapeVal;
        private LineCap _Start = LineCap.Flat;
        private LineCap _End = LineCap.Flat;
        private Double _ProgressWidth = 5f;
        private float _PenWidth = 1f;
        private SmoothingMode _Smoothing = SmoothingMode.HighQuality;
        private float _ProgressWidthToFloat;
        private bool _showText = true;

        #endregion
        #region Custom Properties

        public Boolean Percentage_Text
        {
            get { return this._showText; }
            set
            {
                this._showText = value;
                this.Invalidate();
            }
        }
        public float PenWidth
        {
            get { return this._PenWidth; }
            set
            {
                this._PenWidth = value;
                this.Invalidate();
            }
        }

        public SmoothingMode Smoothing
        {
            get { return this._Smoothing; }
            set
            {
                this._Smoothing = value;
                this.Invalidate();
            }
        }
        public Color Color5_ProgressInnerBorder
        {
            get { return this._ProgressColorInnerBorder; }
            set
            {
                this._ProgressColorInnerBorder = value;
                this.Invalidate();
            }
        }
        public Color Color6_TextColor
        {
            get { return this._TextColor; }
            set
            {
                this._TextColor = value;
                this.Invalidate();
            }
        }
        public LineCap ProgressWidthStartCap
        {
            get { return this._Start; }
            set
            {
                if (_Start == null)
                {
                    _Start = LineCap.Flat;
                }
                this._Start = value;
                this.Invalidate();
            }
        }

        public LineCap ProgressWidthEndCap
        {
            get { return this._End; }
            set
            {
                if (_End == null)
                {
                    _End = LineCap.Flat;
                }
                this._End = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This changes the angle of gradient button
        /// </summary>
        [Description("This changes the angle of gradient button"),
        Category("Appearance"),
        Browsable(true)]
        public Double ProgressWidth
        {
            get { return this._ProgressWidth; }
            set
            {
                if (_ProgressWidth == null)
                {
                    this._ProgressWidth = 5f;
                }

                this._ProgressWidth = value;
                _ProgressWidthToFloat = DoubleToFloat(_ProgressWidth);

                this.Invalidate();
            }
        }
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
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

        public Color Color1_Progress
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color Color2_Progress
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public Color Color3_FillEllipse
        {
            get { return _FillEllipse1; }
            set
            {
                _FillEllipse1 = value;
                Invalidate();
            }
        }

        public Color Color4_FillEllipse
        {
            get { return _FillEllipse2; }
            set
            {
                _FillEllipse2 = value;
                Invalidate();
            }
        }

        //public _ProgressShape ProgressShape
        //{
        //    get { return ProgressShapeVal; }
        //    set
        //    {
        //        ProgressShapeVal = value;
        //        Invalidate();
        //    }
        //}


        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        #endregion
        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion
        private bool transparency = false;

        public Boolean Transparent
        {
            get { return transparency; }
            set
            {
                transparency = value;
                this.Invalidate();
            }
        }
        public ZeroitProgressBarCircular()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            //SetStyle(ControlStyles.SupportsTransparentBackColor, transparency);

            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            //MinimumSize = new Size(10, 100);
            DoubleBuffered = true;
            _Smoothing = SmoothingMode.HighQuality;


        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.Clear(Color.Transparent);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, _ProgressWidthToFloat))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case _ProgressShape.AnchorMask:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.ArrowAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.Custom:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.DiamondAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.Flat:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.NoAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.Round:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.RoundAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.Square:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.SquareAnchor:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                case _ProgressShape.Triangle:
                                    pen.StartCap = _Start;
                                    pen.EndCap = _End;
                                    break;

                                default:
                                    break;
                            }
                            
                            graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }
                    //using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0x34, 0x34, 0x34), Color.FromArgb(0x34, 0x34, 0x34), LinearGradientMode.Vertical))
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, _FillEllipse1, _FillEllipse2, LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                        Pen BorderColor = new Pen(_ProgressColorInnerBorder, _PenWidth);
                        graphics.DrawArc(BorderColor, new Rectangle(0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1), 0f, 360f);

                    }
                    SolidBrush TexTColor = new SolidBrush(_TextColor);
                    SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, TexTColor, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }
    }

    #endregion

    #region Progress Indicator

    public class ZeroitProgressIndicator : Control
    {

        #region Variables

        private readonly SolidBrush BaseColor = new SolidBrush(Color.DarkGray);
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.DimGray);

        private readonly System.Windows.Forms.Timer AnimationSpeed = new System.Windows.Forms.Timer();
        private PointF[] FloatPoint;
        private BufferedGraphics BuffGraphics;
        private int IndicatorIndex;
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        #endregion
        #region Custom Properties

        public Color P_BaseColor
        {
            get { return BaseColor.Color; }
            set { BaseColor.Color = value; }
        }

        public Color P_AnimationColor
        {
            get { return AnimationColor.Color; }
            set { AnimationColor.Color = value; }
        }

        public int P_AnimationSpeed
        {
            get { return AnimationSpeed.Interval; }
            set { AnimationSpeed.Interval = value; }
        }

        #endregion
        #region EventArgs

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeed.Enabled = this.Enabled;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeed.Tick += AnimationSpeed_Tick;
            AnimationSpeed.Start();
        }

        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (IndicatorIndex.Equals(0))
            {
                IndicatorIndex = FloatPoint.Length - 1;
            }
            else
            {
                IndicatorIndex -= 1;
            }
            this.Invalidate(false);
        }

        #endregion

        public ZeroitProgressIndicator()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(80, 80);
            SetPoints();
            AnimationSpeed.Interval = 100;
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        private void SetPoints()
        {
            Stack<PointF> stack = new Stack<PointF>();
            PointF startingFloatPoint = new PointF(((float)this.Width) / 2f, ((float)this.Height) / 2f);
            for (float i = 0f; i < 360f; i += 45f)
            {
                this.SetValue(startingFloatPoint, (int)Math.Round((double)((((double)this.Width) / 2.0) - 15.0)), (double)i);
                PointF endPoint = this.EndPoint;
                endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
                stack.Push(endPoint);
            }
            this.FloatPoint = stack.ToArray();
        }

        private void UpdateGraphics()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                Size size2 = new Size(this.Width + 1, this.Height + 1);
                this.GraphicsContext.MaximumBuffer = size2;
                this.BuffGraphics = this.GraphicsContext.Allocate(this.CreateGraphics(), this.ClientRectangle);
                this.BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BuffGraphics.Graphics.Clear(this.BackColor);
            int num2 = this.FloatPoint.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.IndicatorIndex == i)
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
                }
                else
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
                }
            }
            this.BuffGraphics.Render(e.Graphics);
        }


        private double Rise;
        private double Run;
        private PointF _StartingFloatPoint;

        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            double CircleRadian = Math.PI * Angle / 180.0;

            _StartingFloatPoint = StartingFloatPoint;
            Rise = AssignValues(ref Run, Length);
            Rise = Math.Sin(CircleRadian) * Rise;
            Run = Math.Cos(CircleRadian) * Run;
        }

        private PointF EndPoint
        {
            get
            {
                float LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
                float LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

                return new PointF(LocationY, LocationX);
            }
        }
    }

    #endregion
    #region Spinner Circle

    #region Loading Circle
    public partial class ZeroitProgressIndicatorSpinner : Control
    {
        // Constants =========================================================
        private static double NumberOfDegreesInCircle = 360;
        private double NumberOfDegreesInHalfCircle = NumberOfDegreesInCircle / 2;
        private int DefaultInnerCircleRadius = 8;
        private int DefaultOuterCircleRadius = 10;
        private int DefaultNumberOfSpoke = 10;
        private int DefaultSpokeThickness = 4;
        private Color DefaultColor = Color.DarkGray;

        private int MacOSXInnerCircleRadius = 5;
        private int MacOSXOuterCircleRadius = 11;
        private int MacOSXNumberOfSpoke = 12;
        private int MacOSXSpokeThickness = 2;

        private int FireFoxInnerCircleRadius = 6;
        private int FireFoxOuterCircleRadius = 7;
        private int FireFoxNumberOfSpoke = 9;
        private int FireFoxSpokeThickness = 4;

        private int IE7InnerCircleRadius = 8;
        private int IE7OuterCircleRadius = 9;
        private int IE7NumberOfSpoke = 24;
        private int IE7SpokeThickness = 4;

        private int ZeroitInnerCircleRadius = 98;
        private int ZeroitOuterCircleRadius = 100;
        private int ZeroitNumberOfSpoke = 250;
        private int ZeroitSpokeThickness = 4;

        // Enumeration =======================================================
        public enum StylePresets
        {
            MacOSX,
            Firefox,
            IE7,
            Zeroit,
            Custom
        }

        // Attributes ========================================================
        private System.Windows.Forms.Timer m_Timer;
        private bool m_IsTimerActive;
        private int m_NumberOfSpoke;
        private int m_SpokeThickness;
        private int m_ProgressValue;
        private int m_OuterCircleRadius;
        private int m_InnerCircleRadius;
        private PointF m_CenterPoint;
        private Color m_Color;
        private Color[] m_Colors;
        private double[] m_Angles;
        private StylePresets m_StylePreset;
        private int _Timer_Interval = 1000;

        // Properties ========================================================
        /// <summary>
        /// Gets or sets the lightest color of the circle.
        /// </summary>
        /// <value>The lightest color of the circle.</value>
        [TypeConverter("System.Drawing.ColorConverter"),
         Category("LoadingCircle"),
         Description("Sets the color of spoke.")]
        public Color Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;

                GenerateColorsPallet();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer circle radius.
        /// </summary>
        /// <value>The outer circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of outer circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int OuterCircleRadius
        {
            get
            {
                if (m_OuterCircleRadius == 0)
                    m_OuterCircleRadius = DefaultOuterCircleRadius;

                return m_OuterCircleRadius;
            }
            set
            {
                m_OuterCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle radius.
        /// </summary>
        /// <value>The inner circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of inner circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int InnerCircleRadius
        {
            get
            {
                if (m_InnerCircleRadius == 0)
                    m_InnerCircleRadius = DefaultInnerCircleRadius;

                return m_InnerCircleRadius;
            }
            set
            {
                m_InnerCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of spoke.
        /// </summary>
        /// <value>The number of spoke.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int NumberSpoke
        {
            get
            {
                if (m_NumberOfSpoke == 0)
                    m_NumberOfSpoke = DefaultNumberOfSpoke;

                return m_NumberOfSpoke;
            }
            set
            {
                if (m_NumberOfSpoke != value && m_NumberOfSpoke > 0)
                {
                    m_NumberOfSpoke = value;
                    GenerateColorsPallet();
                    GetSpokesAngles();

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:LoadingCircle"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public bool Active
        {
            get
            {
                return m_IsTimerActive;
            }
            set
            {
                m_IsTimerActive = value;
                ActiveTimer();
            }
        }

        /// <summary>
        /// Gets or sets the spoke thickness.
        /// </summary>
        /// <value>The spoke thickness.</value>
        [System.ComponentModel.Description("Gets or sets the thickness of a spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int SpokeThickness
        {
            get
            {
                if (m_SpokeThickness <= 0)
                    m_SpokeThickness = DefaultSpokeThickness;

                return m_SpokeThickness;
            }
            set
            {
                m_SpokeThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation speed.
        /// </summary>
        /// <value>The rotation speed.</value>
        [System.ComponentModel.Description("Gets or sets the rotation speed. Higher the slower."),
        System.ComponentModel.Category("LoadingCircle")]
        public int RotationSpeed
        {
            get
            {
                return m_Timer.Interval;
            }
            set
            {
                if (value > 0)
                    m_Timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets or sets the Timer Interval.
        /// </summary>
        /// <value>The rotation speed.</value>
        [System.ComponentModel.Description("Gets or sets the Time Interval. Higher the slower."),
        System.ComponentModel.Category("LoadingCircle")]
        public int Timer_Interval
        {
            get
            {
                return _Timer_Interval;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Value should be more than 0");

                else
                    _Timer_Interval = value;
            }
        }

        /// <summary>
        /// Quickly sets the style to one of these presets, or a custom style if desired
        /// </summary>
        /// <value>The style preset.</value>
        [Category("LoadingCircle"),
         Description("Quickly sets the style to one of these presets, or a custom style if desired"),
         DefaultValue(typeof(StylePresets), "Custom")]
        public StylePresets StylePreset
        {
            get { return m_StylePreset; }
            set
            {
                m_StylePreset = value;

                switch (m_StylePreset)
                {
                    case StylePresets.MacOSX:
                        SetCircleAppearance(MacOSXNumberOfSpoke,
                            MacOSXSpokeThickness, MacOSXInnerCircleRadius,
                            MacOSXOuterCircleRadius);
                        break;
                    case StylePresets.Firefox:
                        SetCircleAppearance(FireFoxNumberOfSpoke,
                            FireFoxSpokeThickness, FireFoxInnerCircleRadius,
                            FireFoxOuterCircleRadius);
                        break;
                    case StylePresets.IE7:
                        SetCircleAppearance(IE7NumberOfSpoke,
                            IE7SpokeThickness, IE7InnerCircleRadius,
                            IE7OuterCircleRadius);
                        break;
                    case StylePresets.Zeroit:
                        SetCircleAppearance(ZeroitNumberOfSpoke,
                            ZeroitSpokeThickness, ZeroitInnerCircleRadius,
                            ZeroitOuterCircleRadius);
                        RotationSpeed = 10;
                        break;
                    case StylePresets.Custom:
                        SetCircleAppearance(DefaultNumberOfSpoke,
                            DefaultSpokeThickness,
                            DefaultInnerCircleRadius,
                            DefaultOuterCircleRadius);
                        break;
                }
            }
        }

        // Construtor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoadingCircle"/> class.
        /// </summary>
        public ZeroitProgressIndicatorSpinner()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            m_Color = DefaultColor;

            GenerateColorsPallet();
            GetSpokesAngles();
            GetControlCenterPoint();

            m_Timer = new System.Windows.Forms.Timer();
            m_Timer.Interval = _Timer_Interval;
            m_Timer.Tick += new EventHandler(aTimer_Tick);
            ActiveTimer();

            this.Resize += new EventHandler(LoadingCircle_Resize);
        }

        // Events ============================================================
        /// <summary>
        /// Handles the Resize event of the LoadingCircle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void LoadingCircle_Resize(object sender, EventArgs e)
        {
            GetControlCenterPoint();
        }

        /// <summary>
        /// Handles the Tick event of the aTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void aTimer_Tick(object sender, EventArgs e)
        {
            m_ProgressValue = ++m_ProgressValue % m_NumberOfSpoke;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_NumberOfSpoke > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                int intPosition = m_ProgressValue;
                for (int intCounter = 0; intCounter < m_NumberOfSpoke; intCounter++)
                {
                    intPosition = intPosition % m_NumberOfSpoke;
                    DrawLine(e.Graphics,
                             GetCoordinate(m_CenterPoint, m_InnerCircleRadius, m_Angles[intPosition]),
                             GetCoordinate(m_CenterPoint, m_OuterCircleRadius, m_Angles[intPosition]),
                             m_Colors[intCounter], m_SpokeThickness);
                    intPosition++;
                }
            }

            base.OnPaint(e);
        }

        // Overridden Methods ================================================
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            proposedSize.Width =
                (m_OuterCircleRadius + m_SpokeThickness) * 2;

            return proposedSize;
        }

        // Methods ===========================================================
        /// <summary>
        /// Darkens a specified color.
        /// </summary>
        /// <param name="_objColor">Color to darken.</param>
        /// <param name="_intPercent">The percent of darken.</param>
        /// <returns>The new color generated.</returns>
        private Color Darken(Color _objColor, int _intPercent)
        {
            int intRed = _objColor.R;
            int intGreen = _objColor.G;
            int intBlue = _objColor.B;
            return Color.FromArgb(_intPercent, Math.Min(intRed, byte.MaxValue), Math.Min(intGreen, byte.MaxValue), Math.Min(intBlue, byte.MaxValue));
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        private void GenerateColorsPallet()
        {
            m_Colors = GenerateColorsPallet(m_Color, Active, m_NumberOfSpoke);
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        /// <param name="_objColor">Color of the lightest spoke.</param>
        /// <param name="_blnShadeColor">if set to <c>true</c> the color will be shaded on X spoke.</param>
        /// <returns>An array of color used to draw the circle.</returns>
        private Color[] GenerateColorsPallet(Color _objColor, bool _blnShadeColor, int _intNbSpoke)
        {
            Color[] objColors = new Color[NumberSpoke];

            // Value is used to simulate a gradient feel... For each spoke, the 
            // color will be darken by value in intIncrement.
            byte bytIncrement = (byte)(byte.MaxValue / NumberSpoke);

            //Reset variable in case of multiple passes
            byte PERCENTAGE_OF_DARKEN = 0;

            for (int intCursor = 0; intCursor < NumberSpoke; intCursor++)
            {
                if (_blnShadeColor)
                {
                    if (intCursor == 0 || intCursor < NumberSpoke - _intNbSpoke)
                        objColors[intCursor] = _objColor;
                    else
                    {
                        // Increment alpha channel color
                        PERCENTAGE_OF_DARKEN += bytIncrement;

                        // Ensure that we don't exceed the maximum alpha
                        // channel value (255)
                        if (PERCENTAGE_OF_DARKEN > byte.MaxValue)
                            PERCENTAGE_OF_DARKEN = byte.MaxValue;

                        // Determine the spoke forecolor
                        objColors[intCursor] = Darken(_objColor, PERCENTAGE_OF_DARKEN);
                    }
                }
                else
                    objColors[intCursor] = _objColor;
            }

            return objColors;
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        private void GetControlCenterPoint()
        {
            m_CenterPoint = GetControlCenterPoint(this);
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        /// <returns>PointF object</returns>
        private PointF GetControlCenterPoint(Control _objControl)
        {
            return new PointF(_objControl.Width / 2, _objControl.Height / 2 - 1);
        }

        /// <summary>
        /// Draws the line with GDI+.
        /// </summary>
        /// <param name="_objGraphics">The Graphics object.</param>
        /// <param name="_objPointOne">The point one.</param>
        /// <param name="_objPointTwo">The point two.</param>
        /// <param name="_objColor">Color of the spoke.</param>
        /// <param name="_intLineThickness">The thickness of spoke.</param>
        private void DrawLine(Graphics _objGraphics, PointF _objPointOne, PointF _objPointTwo,
                              Color _objColor, int _intLineThickness)
        {
            using (Pen objPen = new Pen(new SolidBrush(_objColor), _intLineThickness))
            {
                objPen.StartCap = LineCap.Round;
                objPen.EndCap = LineCap.Round;
                _objGraphics.DrawLine(objPen, _objPointOne, _objPointTwo);
            }
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        /// <param name="_objCircleCenter">The Circle center.</param>
        /// <param name="_intRadius">The radius.</param>
        /// <param name="_dblAngle">The angle.</param>
        /// <returns></returns>
        private PointF GetCoordinate(PointF _objCircleCenter, int _intRadius, double _dblAngle)
        {
            double dblAngle = Math.PI * _dblAngle / NumberOfDegreesInHalfCircle;

            return new PointF(_objCircleCenter.X + _intRadius * (float)Math.Cos(dblAngle),
                              _objCircleCenter.Y + _intRadius * (float)Math.Sin(dblAngle));
        }

        /// <summary>
        /// Gets the spokes angles.
        /// </summary>
        private void GetSpokesAngles()
        {
            m_Angles = GetSpokesAngles(NumberSpoke);
        }

        /// <summary>
        /// Gets the spoke angles.
        /// </summary>
        /// <param name="_shtNumberSpoke">The number spoke.</param>
        /// <returns>An array of angle.</returns>
        private double[] GetSpokesAngles(int _intNumberSpoke)
        {
            double[] Angles = new double[_intNumberSpoke];
            double dblAngle = (double)NumberOfDegreesInCircle / _intNumberSpoke;

            for (int shtCounter = 0; shtCounter < _intNumberSpoke; shtCounter++)
                Angles[shtCounter] = (shtCounter == 0 ? dblAngle : Angles[shtCounter - 1] + dblAngle);

            return Angles;
        }

        /// <summary>
        /// Actives the timer.
        /// </summary>
        private void ActiveTimer()
        {
            if (m_IsTimerActive)
                m_Timer.Start();
            else
            {
                m_Timer.Stop();
                m_ProgressValue = 0;
            }

            GenerateColorsPallet();
            Invalidate();
        }

        /// <summary>
        /// Sets the circle appearance.
        /// </summary>
        /// <param name="numberSpoke">The number spoke.</param>
        /// <param name="spokeThickness">The spoke thickness.</param>
        /// <param name="innerCircleRadius">The inner circle radius.</param>
        /// <param name="outerCircleRadius">The outer circle radius.</param>
        public void SetCircleAppearance(int numberSpoke, int spokeThickness,
            int innerCircleRadius, int outerCircleRadius)
        {
            NumberSpoke = numberSpoke;
            SpokeThickness = spokeThickness;
            InnerCircleRadius = innerCircleRadius;
            OuterCircleRadius = outerCircleRadius;

            Invalidate();
        }
    }

    #endregion
    #region LoadingCircle.Designer.cs

    //partial class LoadingCircle
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}

    #endregion
    #region LoadingCircleToolStripMenuItem

    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class LoadingCircleToolStripMenuItem : ToolStripControlHost
    {
        // Constants =========================================================

        // Attributes ========================================================

        // Properties ========================================================
        /// <summary>
        /// Gets the loading circle control.
        /// </summary>
        /// <value>The loading circle control.</value>
        [RefreshProperties(RefreshProperties.All),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZeroitProgressIndicatorSpinner LoadingCircleControl
        {
            get { return Control as ZeroitProgressIndicatorSpinner; }
        }

        // Constructor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingCircleToolStripMenuItem"/> class.
        /// </summary>
        public LoadingCircleToolStripMenuItem()
            : base(new ZeroitProgressIndicatorSpinner())
        {
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override Size GetPreferredSize(Size constrainingSize)
        {
            //return base.GetPreferredSize(constrainingSize);
            return this.LoadingCircleControl.GetPreferredSize(constrainingSize);
        }

        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            //Add your code here to subsribe to Control Events
        }

        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            //Add your code here to unsubscribe from control events.
        }
    }

    #endregion
    #endregion 
    #region ZeroitProgressIndicatorUnique

    #region ProgressIndicator
    /// <summary>
    /// Firefox like circular progress indicator.
    /// </summary>
    public partial class ZeroitProgressBarUnique : Control
    {
        #region Constructor

        /// <summary>
        /// Default constructor for the ProgressIndicator.
        /// </summary>
        public ZeroitProgressBarUnique()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (AutoStart)
                timerAnimation.Start();
        }

        #endregion

        #region Private Fields

        private int _value = 1;

        private int _interval = 100;

        private Color _circleColor = Color.FromArgb(20, 20, 20);

        private bool _autoStart;

        private bool _stopped = true;

        private float _circleSize = 1.0F;

        private int _numberOfCircles = 8;

        private int _numberOfVisibleCircles = 8;

        private RotationType _rotation = RotationType.Clockwise;

        private float _percentage;

        private bool _showPercentage;

        private bool _showText;

        private TextDisplayModes _textDisplay = TextDisplayModes.None;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the base color for the circles.
        /// </summary>
        [DefaultValue(typeof(Color), "20, 20, 20")]
        [Description("Gets or sets the base color for the circles.")]
        [Category("Appearance")]
        public Color CircleColor
        {
            get { return _circleColor; }
            set
            {
                _circleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the animation should start automatically.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the animation should start automatically.")]
        [Category("Behavior")]
        public bool AutoStart
        {
            get { return _autoStart; }
            set
            {
                _autoStart = value;

                if (_autoStart && !DesignMode)
                    Start();
                else
                    Stop();
            }
        }

        /// <summary>
        /// Gets or sets the scale for the circles raging from 0.1 to 1.0.
        /// </summary>
        [DefaultValue(1.0F)]
        [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0.")]
        [Category("Appearance")]
        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                if (value <= 0.0F)
                    _circleSize = 0.1F;
                else
                    _circleSize = value > 1.0F ? 1.0F : value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        [DefaultValue(75)]
        [Description("Gets or sets the animation speed.")]
        [Category("Behavior")]
        public int AnimationSpeed
        {
            get { return (-_interval + 400) / 4; }
            set
            {
                checked
                {
                    int interval = 400 - (value * 4);

                    if (interval < 10)
                        _interval = 10;
                    else
                        _interval = interval > 400 ? 400 : interval;

                    timerAnimation.Interval = _interval;
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("Gets or sets the number of circles used in the animation.")]
        [Category("Behavior")]
        public int NumberOfCircles
        {
            get { return _numberOfCircles; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");

                _numberOfCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("Gets or sets the number of circles used in the animation.")]
        [Category("Behavior")]
        public int NumberOfVisibleCircles
        {
            get { return _numberOfVisibleCircles; }
            set
            {
                if (value <= 0 || value > _numberOfCircles)
                    throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer and less than or equal to the number of circles.");

                _numberOfVisibleCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.
        /// </summary>
        [DefaultValue(RotationType.Clockwise)]
        [Description("Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.")]
        [Category("Behavior")]
        public RotationType Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// Gets or sets the percentage to show on the control.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
        [DefaultValue(0)]
        [Description("Gets or sets the percentage to show on the control.")]
        [Category("Appearance")]
        public float Percentage
        {
            get { return _percentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

                _percentage = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the percentage value should be shown.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the percentage value should be shown.")]
        [Category("Behavior")]
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;

                _textDisplay = _showPercentage
                                   ? _textDisplay | TextDisplayModes.Percentage
                                   : _textDisplay & ~TextDisplayModes.Percentage;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the control text should be shown.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the control text should be shown.")]
        [Category("Behavior")]
        public bool ShowText
        {
            get { return _showText; }
            set
            {
                _showText = value;

                _textDisplay = _showText
                                   ? _textDisplay | TextDisplayModes.Text
                                   : _textDisplay & ~TextDisplayModes.Text;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the property that will be shown in the control.
        /// </summary>
        [DefaultValue(TextDisplayModes.None)]
        [Description("Gets or sets the property that will be shown in the control.")]
        [Category("Appearance")]
        public TextDisplayModes TextDisplay
        {
            get { return _textDisplay; }
            set
            {
                _textDisplay = value;

                _showText = (_textDisplay & TextDisplayModes.Text) == TextDisplayModes.Text;
                _showPercentage = (_textDisplay & TextDisplayModes.Percentage) == TextDisplayModes.Percentage;
                Invalidate();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start()
        {
            timerAnimation.Interval = _interval;
            _stopped = false;
            timerAnimation.Start();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            timerAnimation.Stop();
            _value = 1;
            _stopped = true;
            Invalidate();
        }

        #endregion

        #region Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            float angle = 360.0F / _numberOfCircles;

            GraphicsState oldState = e.Graphics.Save();

            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(angle * _value * (int)_rotation);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 1; i <= _numberOfCircles; i++)
            {
                int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
                int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

                Color drawColor = Color.FromArgb(alpha, _circleColor);

                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 4.5F / _circleSize;
                    float size = Width / sizeRate;

                    float diff = (Width / 4.5F) - size;

                    float x = (Width / 9.0F) + diff;
                    float y = (Height / 9.0F) + diff;
                    e.Graphics.FillEllipse(brush, x, y, size, size);
                    e.Graphics.RotateTransform(angle * (int)_rotation);
                }
            }

            e.Graphics.Restore(oldState);

            string percent = GetDrawText();

            if (!string.IsNullOrEmpty(percent))
            {
                SizeF textSize = e.Graphics.MeasureString(percent, Font);
                float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
                float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);


                using (SolidBrush textBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
                }
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            SetNewSize();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetNewSize();
            base.OnSizeChanged(e);
        }

        #endregion

        #region Private Methods

        private string GetDrawText()
        {
            string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

            if (_showText && _showPercentage)
                return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

            if (_showText)
                return Text;

            if (_showPercentage)
                return percent;

            return string.Empty;
        }

        private void SetNewSize()
        {
            int size = Math.Max(Width, Height);
            Size = new Size(size, size);
        }

        private void IncreaseValue()
        {
            if (_value + 1 <= _numberOfCircles)
                _value++;
            else
                _value = 1;
        }

        #endregion

        #region Timer

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                IncreaseValue();
                Invalidate();
            }
        }

        #endregion
    }

    #endregion
    #region RotationType
    /// <summary>
    /// An enum used to indicate the rotational direction of the control.
    /// </summary>
    public enum RotationType
    {
        /// <summary>
        /// Indicates that the rotation should move clockwise.
        /// </summary>
        Clockwise = 1,
        /// <summary>
        /// Indicates that the rotation should move counter-clockwise.
        /// </summary>
        CounterClockwise = -1,
    }
    #endregion
    #region TextDisplayModes
    /// <summary>
    /// This enum is used to choose what text should be shown in the control.
    /// </summary>
    [Flags]
    public enum TextDisplayModes
    {
        /// <summary>
        /// No text will be shown by the control.
        /// </summary>
        None = 0,

        /// <summary>
        /// The control will show the value of the Percentage property.
        /// </summary>
        Percentage = 1,

        /// <summary>
        /// The control will show the value of the Text property.
        /// </summary>
        Text = 2,

        /// <summary>
        /// The control will show the values of the Text and Percentage properties.
        /// </summary>
        Both = Percentage | Text
    }
    #endregion
    #region ProgressIndicator.designer.cs
    partial class ZeroitProgressBarUnique
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // ProgressIndicator
            // 
            this.Size = new System.Drawing.Size(90, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerAnimation;
    }

    #endregion

    #endregion

    #region ZeroitProgressBarUnique

    //#region ProgressIndicator
    ///// <summary>
    ///// Firefox like circular progress indicator.
    ///// </summary>
    //public class ZeroitProgressBarUnique : Control
    //{
    //    #region Constructor

    //    /// <summary>
    //    /// Default constructor for the ProgressIndicator.
    //    /// </summary>
    //    public ZeroitProgressBarUnique()
    //    {
    //        //InitializeComponent1();
    //        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    //        SetStyle(ControlStyles.ResizeRedraw, true);
    //        SetStyle(ControlStyles.SupportsTransparentBackColor, true);

    //        if (AutoStart)
    //            timerAnimation1.Start();
    //    }

    //    #endregion

    //    #region Private Fields

    //    private int _value = 1;

    //    private int _interval = 100;

    //    private Color _circleColor = Color.FromArgb(20, 20, 20);

    //    private System.Windows.Forms.Timer timerAnimation1 = new System.Windows.Forms.Timer();

    //    private bool _autoStart;

    //    private bool _stopped = true;

    //    private float _circleSize = 0.2F;

    //    private int _numberOfCircles = 500;

    //    private int _numberOfVisibleCircles = 100;

    //    private RotationType1 _rotation = RotationType1.Clockwise;

    //    private float _percentage;

    //    private bool _showPercentage;

    //    private bool _showText;

    //    private TextDisplayModes _textDisplay = TextDisplayModes.None;

    //    #endregion

    //    #region Public Properties

    //    /// <summary>
    //    /// Gets or sets the base color for the circles.
    //    /// </summary>
    //    [DefaultValue(typeof(Color), "20, 20, 20")]
    //    [Description("Gets or sets the base color for the circles.")]
    //    [Category("Appearance")]
    //    public Color CircleColor
    //    {
    //        get { return _circleColor; }
    //        set
    //        {
    //            _circleColor = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the animation should start automatically.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the animation should start automatically.")]
    //    [Category("Behavior")]
    //    public bool AutoStart
    //    {
    //        get { return _autoStart; }
    //        set
    //        {
    //            _autoStart = value;

    //            if (_autoStart && !DesignMode)
    //                Start();
    //            else
    //                Stop();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the scale for the circles raging from 0.1 to 1.0.
    //    /// </summary>
    //    [DefaultValue(1.0F)]
    //    [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0.")]
    //    [Category("Appearance")]
    //    public float CircleSize
    //    {
    //        get { return _circleSize; }
    //        set
    //        {
    //            if (value <= 0.0F)
    //                _circleSize = 0.1F;
    //            else
    //                _circleSize = value > 1.0F ? 1.0F : value;

    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the animation speed.
    //    /// </summary>
    //    [DefaultValue(100)]
    //    [Description("Gets or sets the animation speed.")]
    //    [Category("Behavior")]
    //    public int AnimationSpeed
    //    {
    //        get { return (-_interval + 400) / 4; }
    //        set
    //        {
    //            checked
    //            {
    //                int interval = 400 - (value * 4);

    //                if (interval < 10)
    //                    _interval = 10;
    //                else
    //                    _interval = interval > 400 ? 400 : interval;

    //                timerAnimation1.Interval = _interval;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the number of circles used in the animation.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
    //    [DefaultValue(8)]
    //    [Description("Gets or sets the number of circles used in the animation.")]
    //    [Category("Behavior")]
    //    public int NumberOfCircles
    //    {
    //        get { return _numberOfCircles; }
    //        set
    //        {
    //            if (value <= 0)
    //                throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");

    //            _numberOfCircles = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the number of circles used in the animation.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
    //    [DefaultValue(8)]
    //    [Description("Gets or sets the number of circles used in the animation.")]
    //    [Category("Behavior")]
    //    public int NumberOfVisibleCircles
    //    {
    //        get { return _numberOfVisibleCircles; }
    //        set
    //        {
    //            if (value <= 0 || value > _numberOfCircles)
    //                throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer and less than or equal to the number of circles.");

    //            _numberOfVisibleCircles = value;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.
    //    /// </summary>
    //    [DefaultValue(RotationType1.Clockwise)]
    //    [Description("Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.")]
    //    [Category("Behavior")]
    //    public RotationType1 Rotation
    //    {
    //        get { return _rotation; }
    //        set { _rotation = value; }
    //    }

    //    /// <summary>
    //    /// Gets or sets the percentage to show on the control.
    //    /// </summary>
    //    /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
    //    [DefaultValue(0)]
    //    [Description("Gets or sets the percentage to show on the control.")]
    //    [Category("Appearance")]
    //    public float Percentage
    //    {
    //        get { return _percentage; }
    //        set
    //        {
    //            if (value < 0 || value > 100)
    //                throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

    //            _percentage = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the percentage value should be shown.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the percentage value should be shown.")]
    //    [Category("Behavior")]
    //    public bool ShowPercentage
    //    {
    //        get { return _showPercentage; }
    //        set
    //        {
    //            _showPercentage = value;

    //            _textDisplay = _showPercentage
    //                               ? _textDisplay | TextDisplayModes.Percentage
    //                               : _textDisplay & ~TextDisplayModes.Percentage;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating if the control text should be shown.
    //    /// </summary>
    //    [DefaultValue(false)]
    //    [Description("Gets or sets a value indicating if the control text should be shown.")]
    //    [Category("Behavior")]
    //    public bool ShowText
    //    {
    //        get { return _showText; }
    //        set
    //        {
    //            _showText = value;

    //            _textDisplay = _showText
    //                               ? _textDisplay | TextDisplayModes.Text
    //                               : _textDisplay & ~TextDisplayModes.Text;
    //            Invalidate();
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the property that will be shown in the control.
    //    /// </summary>
    //    [DefaultValue(TextDisplayModes.None)]
    //    [Description("Gets or sets the property that will be shown in the control.")]
    //    [Category("Appearance")]
    //    public TextDisplayModes TextDisplay
    //    {
    //        get { return _textDisplay; }
    //        set
    //        {
    //            _textDisplay = value;

    //            _showText = (_textDisplay & TextDisplayModes.Text) == TextDisplayModes.Text;
    //            _showPercentage = (_textDisplay & TextDisplayModes.Percentage) == TextDisplayModes.Percentage;
    //            Invalidate();
    //        }
    //    }

    //    #endregion

    //    #region Public Methods

    //    /// <summary>
    //    /// Starts the animation.
    //    /// </summary>
    //    public void Start()
    //    {
    //        timerAnimation1.Interval = _interval;
    //        _stopped = false;
    //        timerAnimation1.Start();
    //    }

    //    /// <summary>
    //    /// Stops the animation.
    //    /// </summary>
    //    public void Stop()
    //    {
    //        timerAnimation1.Stop();
    //        _value = 1;
    //        _stopped = true;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region Overrides

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        float angle = 360.0F / _numberOfCircles;

    //        GraphicsState oldState = e.Graphics.Save();

    //        e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
    //        e.Graphics.RotateTransform(angle * _value * (int)_rotation);
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        for (int i = 1; i <= _numberOfCircles; i++)
    //        {
    //            int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
    //            int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

    //            Color drawColor = Color.FromArgb(alpha, _circleColor);

    //            using (SolidBrush brush = new SolidBrush(drawColor))
    //            {
    //                float sizeRate = 4.5F / _circleSize;
    //                float size = Width / sizeRate;

    //                float diff = (Width / 4.5F) - size;

    //                float x = (Width / 9.0F) + diff;
    //                float y = (Height / 9.0F) + diff;
    //                e.Graphics.FillEllipse(brush, x, y, size, size);
    //                e.Graphics.RotateTransform(angle * (int)_rotation);
    //            }
    //        }

    //        e.Graphics.Restore(oldState);

    //        string percent = GetDrawText();

    //        if (!string.IsNullOrEmpty(percent))
    //        {
    //            SizeF textSize = e.Graphics.MeasureString(percent, Font);
    //            float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
    //            float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
    //            StringFormat format = new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            };

    //            RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);


    //            using (SolidBrush textBrush = new SolidBrush(ForeColor))
    //            {
    //                e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
    //            }
    //        }

    //        base.OnPaint(e);
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        SetNewSize();
    //        base.OnResize(e);
    //    }

    //    protected override void OnSizeChanged(EventArgs e)
    //    {
    //        SetNewSize();
    //        base.OnSizeChanged(e);
    //    }

    //    #endregion

    //    #region Private Methods

    //    private string GetDrawText()
    //    {
    //        string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

    //        if (_showText && _showPercentage)
    //            return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

    //        if (_showText)
    //            return Text;

    //        if (_showPercentage)
    //            return percent;

    //        return string.Empty;
    //    }

    //    private void SetNewSize()
    //    {
    //        int size = Math.Max(Width, Height);
    //        Size = new Size(size, size);
    //    }

    //    private void IncreaseValue()
    //    {
    //        if (_value + 1 <= _numberOfCircles)
    //            _value++;
    //        else
    //            _value = 1;
    //    }

    //    #endregion

    //    #region Timer

    //    //private void timerAnimation1_Tick(object sender, EventArgs e)
    //    //{
    //    //    if (!DesignMode)
    //    //    {
    //    //        IncreaseValue();
    //    //        Invalidate();
    //    //    }
    //    //}

    //    #endregion
    //}

    //#endregion
    //#region RotationType
    ///// <summary>
    ///// An enum used to indicate the rotational direction of the control.
    ///// </summary>
    //public enum RotationType1
    //{
    //    /// <summary>
    //    /// Indicates that the rotation should move clockwise.
    //    /// </summary>
    //    Clockwise = 1,
    //    /// <summary>
    //    /// Indicates that the rotation should move counter-clockwise.
    //    /// </summary>
    //    CounterClockwise = -1,
    //}
    //#endregion
    //#region TextDisplayModes
    ///// <summary>
    ///// This enum is used to choose what text should be shown in the control.
    ///// </summary>
    //[Flags]
    //public enum TextDisplayMode1
    //{
    //    /// <summary>
    //    /// No text will be shown by the control.
    //    /// </summary>
    //    None = 0,

    //    /// <summary>
    //    /// The control will show the value of the Percentage property.
    //    /// </summary>
    //    Percentage = 1,

    //    /// <summary>
    //    /// The control will show the value of the Text property.
    //    /// </summary>
    //    Text = 2,

    //    /// <summary>
    //    /// The control will show the values of the Text and Percentage properties.
    //    /// </summary>
    //    Both = Percentage | Text
    //}
    //#endregion
    //#region ProgressIndicator.designer.cs
    //partial class ZeroitProgressIndicatorUnique
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private static System.ComponentModel.IContainer components1 = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    //protected override void Dispose(bool disposing)
    //    //{
    //    //    if (disposing && (components1 != null))
    //    //    {
    //    //        components1.Dispose();
    //    //    }
    //    //    base.Dispose(disposing);
    //    //}

    //    #region Component Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify 
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    public void InitializeComponent1()
    //    {
    //        components1 = new System.ComponentModel.Container();
    //        timerAnimation1 = new System.Windows.Forms.Timer(components1);
    //        this.SuspendLayout();
    //        // 
    //        // timerAnimation
    //        // 
    //        timerAnimation1.Tick += new System.EventHandler(timerAnimation1_Tick);
    //        // 
    //        // ProgressIndicator
    //        // 
    //        Size = new System.Drawing.Size(90, 90);
    //        ResumeLayout(false);

    //    }

    //    //private static void timerAnimation1_Tick(object sender, EventArgs e)
    //    //{

    //    //    for (int x = 0; x >= 1; x++)
    //    //    {
    //    //        timerAnimation1.Start();
    //    //    }
    //    //}

    //    private void timerAnimation1_Tick(object sender, EventArgs e)
    //    {
    //        if (!DesignMode)
    //        {
    //            IncreaseValue();
    //            Invalidate();
    //        }
    //    }

    //    #endregion

    //    private static System.Windows.Forms.Timer timerAnimation1;
    //}

    //#endregion

    #endregion

    #region  ZeroitProgressBarRect

    public class ZeroitProgressBarRect : Control
    {

        #region  RoundRect

        private GraphicsPath CreateRoundPath;

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion
        #region  Custom Properties

        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        private int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;

                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                if (value > _Value)
                {
                    _Value = value;
                }

                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        private Color _ValueColour = Color.FromArgb(42, 119, 220);
        [Category("Colours")]
        public Color ValueColour
        {
            get
            {
                return _ValueColour;
            }
            set
            {
                _ValueColour = value;
                Invalidate();
            }
        }

        #endregion

        private double Percent;

        public ZeroitProgressBarRect()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(100, 10);
        }

        public void Increment(int value)
        {
            this._Value += value;
            Invalidate();
        }

        public void Deincrement(int value)
        {
            this._Value -= value;
            Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            this.Percent = (double)this._Value / (double)this._Maximum * 100;

            int Slope = 8;
            Rectangle MyRect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath BorderPath = CreateRound(MyRect, Slope);
            G.FillPath(new SolidBrush(Color.FromArgb(51, 52, 55)), BorderPath);

            ColorBlend ProgressBlend = new ColorBlend(3);
            ProgressBlend.Colors[0] = _ValueColour;
            ProgressBlend.Colors[1] = _ValueColour;
            ProgressBlend.Colors[2] = _ValueColour;
            ProgressBlend.Positions = new Single[] { 0, 0.5F, 1 };
            LinearGradientBrush LGB = new LinearGradientBrush(MyRect, Color.Black, Color.Black, 90.0F);
            LGB.InterpolationColors = ProgressBlend;

            Rectangle ProgressRect = new Rectangle(1, 1, (int)Math.Round(((double)this.Width / (double)this._Maximum * (double)this._Value - 3.0)), this.Height - 3);
            GraphicsPath ProgressPath = CreateRound(ProgressRect, Slope);

            if (Percent >= 1)
            {
                G.FillPath(LGB, ProgressPath);
            }

            try
            {
                G.DrawPath(new Pen(Color.FromArgb(51, 52, 55)), BorderPath);
            }
            catch (Exception)
            {
            }
        }
    }

    #endregion


    #region ZeroitProgressBarAlter
    public class ZeroitProgressBarAlter : ThemeControl154
    {
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value >= Minimum & value <= _Max)
                    _Value = value;
                Invalidate();
            }
        }

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Invalidate();
            }
        }


        private int _Max = 100;
        public int Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                    _Max = value;
                Invalidate();
            }
        }

        private int _Min = 0;
        public int Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                    _Min = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        private bool _ShowValue = false;
        [Description("Indicates if the value of the progress bar will be shown in the middle of it.")]
        public bool ShowValue
        {
            get { return _ShowValue; }
            set
            {
                _ShowValue = value;
                Invalidate();
            }
        }

        Brush BT;
        Pen IB, PB;
        Color BG, IC;

        public ZeroitProgressBarAlter()
        {
            Transparent = true;
            Value = 50;
            ShowValue = true;
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Inside", Color.FromArgb(200, 200, 200));
            SetColor("Border", Color.FromArgb(150, 150, 150));
            SetColor("BG", Color.FromArgb(210, 210, 210));
            SetColor("IC", Color.FromArgb(215, 215, 215));
            MinimumSize = new Size(40, 14);
            Size = new Size(175, 30);
        }

        protected override void ColorHook()
        {
            BT = GetBrush("Text");
            IB = GetPen("Inside");
            PB = GetPen("Border");
            BG = GetColor("BG");
            IC = GetColor("IC");
        }

        protected override void PaintHook()
        {
            switch (_Orientation)
            {
                case System.Windows.Forms.Orientation.Horizontal:

                    int area = Convert.ToInt32((_Value * (Width - 6)) / _Max);
                    G.Clear(BG);
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90F);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 3);
                    }
                    else if (_Value == _Min)
                    { }
                    else
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, area, Height - 4));
                        G.DrawRectangle(PB, new Rectangle(3, 3, area - 1, Height - 7));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }

                    break;

                case System.Windows.Forms.Orientation.Vertical:

                    int area2 = Convert.ToInt32((_Value * (Height - 6)) / _Max);

                    G.Clear(BG);
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90F);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 3);
                    }
                    else if (_Value == _Min)
                    { }
                    else
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, area2));
                        G.DrawRectangle(PB, new Rectangle(3, 3, Width - 7, area2));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }


                    break;
            }

            DrawBorders(IB);
            DrawBorders(PB, 1);
        }
    }
    #endregion
    #region Helper Class for ProgressBarTransparent
    public static class Helper
    {
        public struct Fonts
        {
            public static Font Primary = new Font("Segoe UI", 9);
            public static Font PrimaryBold = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        public struct Colors
        {
            public static Color Foreground = Color.White;
            public static Color Background = Color.FromArgb(48, 57, 65);
        }


        public enum MouseState : byte
        {
            None = 0,
            Hover = 1,
            Down = 2
        }

        public enum Direction : byte
        {
            Up = 0,
            Down = 1,
            Left = 3,
            Right = 4
        }

        public static void RoundRect(Graphics g, Int32 x, Int32 y, Int32 Width, Int32 Height, Int32 Curve, Color c)
        {
            if (Curve <= 0) throw new ArgumentException("Curve must be Greater than 0.", "Curve");

            var p = new Pen(c);

            var BaseRect = new RectangleF(x, y, Width, Height);
            var ArcRect = new RectangleF(BaseRect.Location, new SizeF(Curve, Curve));

            g.DrawArc(p, ArcRect, 180, 90);
            g.DrawLine(p, x + (Curve / 2), y, y + Width - (Curve / 2), y);

            ArcRect.X = BaseRect.Right - Curve;
            g.DrawArc(p, ArcRect, 270, 90);
            g.DrawLine(p, x + Width, y + (Curve / 2), x + Width, y + Height - (Curve / 2));

            ArcRect.Y = BaseRect.Bottom - Curve;
            g.DrawArc(p, ArcRect, 0, 90);
            g.DrawLine(p, x + (Curve / 2), y + Height, x + Width - (Curve / 2), y + Height);

            ArcRect.X = BaseRect.Left;
            g.DrawArc(p, ArcRect, 90, 30);
            g.DrawLine(p, x, y + (Curve / 2), x, y + Height - (Curve / 2));

            p.Dispose();
        }

        public static void DrawTriangle(Graphics g, Rectangle r, Direction d, Color c)
        {
            var w = r.Width / 2;
            var y = r.Height / 2;

            Point p0 = Point.Empty, p1 = Point.Empty, p2 = Point.Empty;

            switch (d)
            {
                case Direction.Up:
                    p0 = new Point(r.Left + w, r.Top);
                    p1 = new Point(r.Left, r.Bottom);
                    p2 = new Point(r.Right, r.Bottom);
                    break;

                case Direction.Down:
                    p0 = new Point(r.Left + w, r.Bottom);
                    p1 = new Point(r.Left, r.Top);
                    p2 = new Point(r.Right, r.Top);
                    break;

                case Direction.Left:
                    p0 = new Point(r.Left, r.Top + y);
                    p1 = new Point(r.Right, r.Top);
                    p2 = new Point(r.Right, r.Bottom);
                    break;

                case Direction.Right:
                    p0 = new Point(r.Right, r.Top + y);
                    p1 = new Point(r.Left, r.Bottom);
                    p2 = new Point(r.Left, r.Top);
                    break;
            }

            var s = new SolidBrush(c);
            g.FillPolygon(s, new[] { p0, p1, p2 });

            MultiDispose(s);
        }

        public static void CenterString(Graphics g, String Text, Font Font, Color c, Rectangle rect, Boolean Shadow = false, Int32 yOffset = 1)
        {
            CenterString(g, Text, Font, new SolidBrush(c), rect, Shadow, yOffset);
        }

        public static void CenterString(Graphics g, String Text, Font Font, Brush b, Rectangle rect, Boolean Shadow = false, Int32 yOffset = 1)
        {
            var TextSize = g.MeasureString(Text, Font);
            var x = rect.X + (rect.Width / 2) - (TextSize.Width / 2);
            var y = rect.Y + (rect.Height / 2) - (TextSize.Height / 2) + yOffset;

            if (Shadow)
                g.DrawString(Text, Font, Brushes.Black, x + 1, y + 1);
            g.DrawString(Text, Font, b, x, y);

            b.Dispose();
        }

        public static Single ValueToPercentage(Int32 Value, Int32 Maximum, Int32 Minimum)
        {
            return (Single)(Value - Minimum) / (Maximum - Minimum);
        }

        public static void MultiDispose(params IDisposable[] Disposables)
        {
            foreach (var Disposable in Disposables)
            {

                Disposable.Dispose();


            }
        }
    }

    #endregion
    #region ProgressBarTransparent
    public class ZeroitProgressBarTransparent : Control
    {
        private Int32 _Maximum = 100;
        private Int32 _Minimum, _Value = 0;
        private Boolean _ShowText = true;
        private Color _ProgressBackground;
        private Color _ProgressColor1;
        private Color _ProgressColor2;

        public Int32 Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > Int32.MaxValue)
                    throw new OverflowException();
                if (value < _Minimum)
                    _Minimum = value - 1;
                if (_Value > _Maximum)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }

        public Int32 Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 0.");
                if (value < _Minimum)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value + 1;
                _Minimum = value;
                Invalidate();
            }
        }

        public Int32 Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    _Value = _Maximum;
                else if (value < _Minimum)
                    _Value = _Minimum;
                else _Value = value;
                Invalidate();
            }
        }

        public Boolean ShowText
        {
            get { return _ShowText; }
            set { _ShowText = value; Invalidate(); }
        }

        public Color ProgressBackground
        {
            get
            {
                return this._ProgressBackground;
            }

            set
            {
                this._ProgressBackground = value;
                Invalidate();
            }

        }

        public Color ProgressColor1
        {
            get
            {
                return this._ProgressColor1;
            }

            set
            {
                this._ProgressColor1 = value;
                Invalidate();
            }

        }

        public Color ProgressColor2
        {
            get
            {
                return this._ProgressColor2;
            }

            set
            {
                this._ProgressColor2 = value;
                Invalidate();
            }

        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }
        }

        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; Invalidate(); }
        }

        public ZeroitProgressBarTransparent()
        {
            DoubleBuffered = true;
            Font = Helper.Fonts.Primary;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var l = new LinearGradientBrush(new Point(0, 0), new Point(Width + Value + 50, Height), _ProgressColor1, _ProgressColor2);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(_ProgressBackground);

            g.FillRectangle(l, new Rectangle(0, 0, (int)(Helper.ValueToPercentage(Value, Maximum, Minimum) * Width), Height));

            Helper.RoundRect(g, 0, 0, Width - 1, Height - 1, 1, BackColor);

            if (ShowText)
                Helper.CenterString(g, Text, Font, Helper.Colors.Foreground, new Rectangle(0, 0, Width, Height));

            Helper.MultiDispose(l);

        }

    }
    #endregion

    #region ZeroitProgressBarPerplex

    public class ZeroitProgressBarPerplex : Control
    {
        private int _Maximum = 100;

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value = 0;
        public int Value
        {
            get
            {
                if (_Value == 0)
                    return 0;
                else return _Value;
            }
            set
            {
                _Value = value;
                if (_Value > _Maximum)
                    _Value = _Maximum;
                Invalidate();
            }
        }
        private bool _ShowPercentage = false;
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        public ZeroitProgressBarPerplex()
            : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;

            double val = (double)_Value / _Maximum;
            int intValue = Convert.ToInt32(val * Width);
            G.Clear(BackColor);
            Color C1 = Color.FromArgb(174, 195, 30);
            Color C2 = Color.FromArgb(141, 153, 16);
            Rectangle R1 = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle R2 = new Rectangle(0, 0, intValue - 1, Height - 1);
            Rectangle R3 = new Rectangle(0, 0, intValue - 1, Height - 2);
            GraphicsPath GP1 = Draw.RoundRect(R1, 1);
            GraphicsPath GP2 = Draw.RoundRect(R2, 2);
            GraphicsPath GP3 = Draw.RoundRect(R3, 1);
            LinearGradientBrush gB = new LinearGradientBrush(R1, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 30, 30), 90);
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 1, Height - 2), C1, C2, 90);
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(50, C1), Color.FromArgb(25, C2));
            Pen P1 = new Pen(Color.Black);

            G.FillPath(gB, GP1);
            G.FillPath(g1, GP3);
            G.FillPath(h1, GP3);
            G.DrawPath(P1, GP1);
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), GP2);
            G.DrawPath(P1, GP2);

            if (_ShowPercentage)
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), Font, Brushes.White, R1, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion

    #region ZeroitProgressBarClear

    public class ZeroitProgressBarClear : ThemeControl154
    {

        Color G1;
        Color G2;
        Color Glow;
        Color Edge;

        int GlowPosition;
        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        public bool Animated
        {
            get { return IsAnimated; }
            set
            {
                IsAnimated = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public ZeroitProgressBarClear()
        {
            SetColor("Gradient 1", 230, 230, 230);
            SetColor("Gradient 2", 210, 210, 210);
            SetColor("Glow", 230, 230, 230);
            SetColor("Edge", 170, 170, 170);
            IsAnimated = true;

        }

        protected override void ColorHook()
        {
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edge");
        }

        protected override void OnAnimation()
        {
            if (GlowPosition == 0)
            {
                GlowPosition = 7;
            }
            else
            {
                GlowPosition -= 1;
            }
        }

        protected override void PaintHook()
        {
            G.Clear(G1);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), G1, G2, 90f);
            G.FillRectangle(LGB, new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, Height - 2)));
            G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, (Height / 2) - 3)));

            G.RenderingOrigin = new Point(GlowPosition, 0);
            HatchBrush HB = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(HB, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));

            G.DrawLine(new Pen(Edge), new Point((Width / Maximum) * Value - 1, 1), new Point((Width / Maximum) * Value - 1, Height - 1));
            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
        }

    }
    #endregion

    #region ZeroitProgressIndicatorUnique

    #region ProgressIndicator
    /// <summary>
    /// Firefox like circular progress indicator.
    /// </summary>
    public partial class ZeroitProgressBarPerfect : Control
    {
        #region Constructor

        /// <summary>
        /// Default constructor for the ProgressIndicator.
        /// </summary>
        public ZeroitProgressBarPerfect()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (AutoStart)
                timerAnimation.Start();
        }

        #endregion

        #region Private Fields

        private int _value = 1;

        private int _interval = 100;

        private Color _circleColor = Color.FromArgb(20, 20, 20);

        private bool _autoStart;

        private bool _stopped = true;

        private float _circleSize = 0.2F;

        private int _numberOfCircles = 180;

        private int _numberOfVisibleCircles = 30;

        private RotationType1 _rotation = RotationType1.Clockwise;

        private float _percentage;

        private bool _showPercentage;

        private bool _showText;

        private TextDisplayModes1 _textDisplay = TextDisplayModes1.None;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the base color for the circles.
        /// </summary>
        [DefaultValue(typeof(Color), "20, 20, 20")]
        [Description("Gets or sets the base color for the circles.")]
        [Category("Appearance")]
        public Color CircleColor
        {
            get { return _circleColor; }
            set
            {
                _circleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the animation should start automatically.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the animation should start automatically.")]
        [Category("Behavior")]
        public bool AutoStart
        {
            get { return _autoStart; }
            set
            {
                _autoStart = value;

                if (_autoStart && !DesignMode)
                    Start();
                else
                    Stop();
            }
        }

        /// <summary>
        /// Gets or sets the scale for the circles raging from 0.1 to 1.0.
        /// </summary>
        [DefaultValue(1.0F)]
        [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0.")]
        [Category("Appearance")]
        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                if (value <= 0.0F)
                    _circleSize = 0.1F;
                else
                    _circleSize = value > 1.0F ? 1.0F : value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        [DefaultValue(75)]
        [Description("Gets or sets the animation speed.")]
        [Category("Behavior")]
        public int AnimationSpeed
        {
            get { return (-_interval + 400) / 4; }
            set
            {
                checked
                {
                    int interval = 400 - (value * 4);

                    if (interval < 10)
                        _interval = 10;
                    else
                        _interval = interval > 400 ? 400 : interval;

                    timerAnimation.Interval = _interval;
                }
            }
        }

        //---------------------------------------------------Number Of Circles-------------------------------------//
        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>


        //[DefaultValue(8)]
        //[Description("Gets or sets the number of circles used in the animation.")]
        //[Category("Behavior")]
        //public int NumberOfCircles
        //{
        //    get { return _numberOfCircles; }
        //    set
        //    {
        //        if (value <= 0)
        //            throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");
        //        else
        //            _numberOfCircles = value > 500 ? 500 : value;

        //        _numberOfCircles = value;
        //        Invalidate();
        //    }
        //}


        //---------------------------------------------------Number Of Circles-------------------------------------//

        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("Gets or sets the number of circles used in the animation.")]
        [Category("Behavior")]
        public int NumberOfVisibleCircles
        {
            get { return _numberOfVisibleCircles; }
            set
            {
                if (value <= 0 || value > _numberOfCircles)
                    throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer and less than or equal to the number of circles.");

                _numberOfVisibleCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.
        /// </summary>
        [DefaultValue(RotationType1.Clockwise)]
        [Description("Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.")]
        [Category("Behavior")]
        public RotationType1 Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// Gets or sets the percentage to show on the control.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
        [DefaultValue(0)]
        [Description("Gets or sets the percentage to show on the control.")]
        [Category("Appearance")]
        public float Percentage
        {
            get { return _percentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

                _percentage = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the percentage value should be shown.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the percentage value should be shown.")]
        [Category("Behavior")]
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;

                _textDisplay = _showPercentage
                                   ? _textDisplay | TextDisplayModes1.Percentage
                                   : _textDisplay & ~TextDisplayModes1.Percentage;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the control text should be shown.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the control text should be shown.")]
        [Category("Behavior")]
        public bool ShowText
        {
            get { return _showText; }
            set
            {
                _showText = value;

                _textDisplay = _showText
                                   ? _textDisplay | TextDisplayModes1.Text
                                   : _textDisplay & ~TextDisplayModes1.Text;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the property that will be shown in the control.
        /// </summary>
        [DefaultValue(TextDisplayModes1.None)]
        [Description("Gets or sets the property that will be shown in the control.")]
        [Category("Appearance")]
        public TextDisplayModes1 TextDisplay
        {
            get { return _textDisplay; }
            set
            {
                _textDisplay = value;

                _showText = (_textDisplay & TextDisplayModes1.Text) == TextDisplayModes1.Text;
                _showPercentage = (_textDisplay & TextDisplayModes1.Percentage) == TextDisplayModes1.Percentage;
                Invalidate();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start()
        {
            timerAnimation.Interval = _interval;
            _stopped = false;
            timerAnimation.Start();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            timerAnimation.Stop();
            _value = 1;
            _stopped = true;
            Invalidate();
        }

        #endregion

        #region Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            float angle = 360.0F / _numberOfCircles;

            GraphicsState oldState = e.Graphics.Save();

            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(angle * _value * (int)_rotation);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 1; i <= _numberOfCircles; i++)
            {
                int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
                int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

                Color drawColor = Color.FromArgb(alpha, _circleColor);



                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 4.5F / _circleSize;
                    float size = Width / sizeRate;

                    float diff = (Width / 4.5F) - size;

                    float x = (Width / 9.0F) + diff;
                    float y = (Height / 9.0F) + diff;
                    e.Graphics.FillEllipse(brush, x, y, size, size);
                    e.Graphics.RotateTransform(angle * (int)_rotation);
                }
            }

            e.Graphics.Restore(oldState);

            string percent = GetDrawText();

            if (!string.IsNullOrEmpty(percent))
            {
                SizeF textSize = e.Graphics.MeasureString(percent, Font);
                float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
                float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);


                using (SolidBrush textBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
                }
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            SetNewSize();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetNewSize();
            base.OnSizeChanged(e);
        }

        #endregion

        #region Private Methods

        private string GetDrawText()
        {
            string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

            if (_showText && _showPercentage)
                return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

            if (_showText)
                return Text;

            if (_showPercentage)
                return percent;

            return string.Empty;
        }

        private void SetNewSize()
        {
            int size = Math.Max(Width, Height);
            Size = new Size(size, size);
        }

        private void IncreaseValue()
        {
            if (_value + 1 <= _numberOfCircles)
                _value++;
            else
                _value = 1;
        }

        #endregion

        #region Timer

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                IncreaseValue();
                Invalidate();
            }
        }

        #endregion
    }

    #endregion
    #region RotationType1
    /// <summary>
    /// An enum used to indicate the rotational direction of the control.
    /// </summary>
    public enum RotationType1
    {
        /// <summary>
        /// Indicates that the rotation should move clockwise.
        /// </summary>
        Clockwise = 1,
        /// <summary>
        /// Indicates that the rotation should move counter-clockwise.
        /// </summary>
        CounterClockwise = -1,
    }
    #endregion
    #region TextDisplayModes1
    /// <summary>
    /// This enum is used to choose what text should be shown in the control.
    /// </summary>
    [Flags]
    public enum TextDisplayModes1
    {
        /// <summary>
        /// No text will be shown by the control.
        /// </summary>
        None = 0,

        /// <summary>
        /// The control will show the value of the Percentage property.
        /// </summary>
        Percentage = 1,

        /// <summary>
        /// The control will show the value of the Text property.
        /// </summary>
        Text = 2,

        /// <summary>
        /// The control will show the values of the Text and Percentage properties.
        /// </summary>
        Both = Percentage | Text
    }
    #endregion
    #region ProgressIndicator.designer.cs
    partial class ZeroitProgressBarPerfect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // ProgressIndicator
            // 
            this.Size = new System.Drawing.Size(90, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerAnimation;
    }

    #endregion

    #endregion


    #region Winform Animation

    #region AnimationFunction
    /// <summary>
    ///     The functions gallery for animation
    /// </summary>
    public static class AnimationFunctions
    {
        /// <summary>
        ///     The base delegate for defining new animation functions.
        /// </summary>
        /// <param name="time">
        ///     The time of the animation.
        /// </param>
        /// <param name="beginningValue">
        ///     The starting value.
        /// </param>
        /// <param name="changeInValue">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="duration">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public delegate float Function(float time, float beginningValue, float changeInValue, float duration);

        /// <summary>
        ///     Returns a function delegate based on the the passed known animation function
        /// </summary>
        /// <param name="knownFunction">The animation function</param>
        /// <returns>Animation fucntion delegate</returns>
        public static Function FromKnown(KnownAnimationFunctions knownFunction)
        {
            switch (knownFunction)
            {
                case KnownAnimationFunctions.CubicEaseIn:
                    return CubicEaseIn;
                case KnownAnimationFunctions.CubicEaseInOut:
                    return CubicEaseInOut;
                case KnownAnimationFunctions.CubicEaseOut:
                    return CubicEaseOut;
                case KnownAnimationFunctions.Liner:
                    return Liner;
                case KnownAnimationFunctions.CircularEaseInOut:
                    return CircularEaseInOut;
                case KnownAnimationFunctions.CircularEaseIn:
                    return CircularEaseIn;
                case KnownAnimationFunctions.CircularEaseOut:
                    return CircularEaseOut;
                case KnownAnimationFunctions.QuadraticEaseIn:
                    return QuadraticEaseIn;
                case KnownAnimationFunctions.QuadraticEaseOut:
                    return QuadraticEaseOut;
                case KnownAnimationFunctions.QuadraticEaseInOut:
                    return QuadraticEaseInOut;
                case KnownAnimationFunctions.QuarticEaseIn:
                    return QuarticEaseIn;
                case KnownAnimationFunctions.QuarticEaseOut:
                    return QuarticEaseOut;
                case KnownAnimationFunctions.QuarticEaseInOut:
                    return QuarticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseInOut:
                    return QuinticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseIn:
                    return QuinticEaseIn;
                case KnownAnimationFunctions.QuinticEaseOut:
                    return QuinticEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseIn:
                    return SinusoidalEaseIn;
                case KnownAnimationFunctions.SinusoidalEaseOut:
                    return SinusoidalEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseInOut:
                    return SinusoidalEaseInOut;
                case KnownAnimationFunctions.ExponentialEaseIn:
                    return ExponentialEaseIn;
                case KnownAnimationFunctions.ExponentialEaseOut:
                    return ExponentialEaseOut;
                case KnownAnimationFunctions.ExponentialEaseInOut:
                    return ExponentialEaseInOut;
                default:
                    throw new ArgumentOutOfRangeException("The passed animation function is unknown.");
            }
        }


        /// <summary>
        ///     The cubic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t + b;
        }

        /// <summary>
        ///     The cubic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return c / 2 * t * t * t + b;

            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        /// <summary>
        ///     The cubic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CubicEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        /// <summary>
        ///     The liner animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float Liner(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        /// <summary>
        ///     The circular ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            t -= 2;
            return (float)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }


        /// <summary>
        ///     The circular ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }


        /// <summary>
        ///     The circular ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float CircularEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * Math.Sqrt(1 - t * t) + b);
        }


        /// <summary>
        ///     The quadratic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t + b;
        }


        /// <summary>
        ///     The quadratic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }


        /// <summary>
        ///     The quadratic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuadraticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        /// <summary>
        ///     The quartic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        /// <summary>
        ///     The quartic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        /// <summary>
        ///     The quartic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuarticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;
        }

        /// <summary>
        ///     The quintic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;
        }

        /// <summary>
        ///     The quintic ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        /// <summary>
        ///     The quintic ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float QuinticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;
        }

        /// <summary>
        ///     The sinusoidal ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseIn(float t, float b, float c, float d)
        {
            return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        /// <summary>
        ///     The sinusoidal ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseOut(float t, float b, float c, float d)
        {
            return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        /// <summary>
        ///     The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float SinusoidalEaseInOut(float t, float b, float c, float d)
        {
            return (float)(-c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b);
        }

        /// <summary>
        ///     The exponential ease-in animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseIn(float t, float b, float c, float d)
        {
            return (float)(c * Math.Pow(2, 10 * (t / d - 1)) + b);
        }

        /// <summary>
        ///     The exponential ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseOut(float t, float b, float c, float d)
        {
            return (float)(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
        }


        /// <summary>
        ///     The exponential ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">
        ///     The time of the animation.
        /// </param>
        /// <param name="b">
        ///     The starting value.
        /// </param>
        /// <param name="c">
        ///     The different between starting and ending value.
        /// </param>
        /// <param name="d">
        ///     The duration of the animations.
        /// </param>
        /// <returns>
        ///     The calculated current value of the animation
        /// </returns>
        public static float ExponentialEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
                return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
            t--;
            return (float)(c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
        }
    }

    #endregion
    #region Animator
    /// <summary>
    ///     The one dimensional animator class, useful for animating raw values
    /// </summary>
    public class Animator : IAnimator
    {
        /// <summary>
        ///     The known one dimensional properties of WinForm controls
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            ///     The property named 'Value' of the object
            /// </summary>
            Value,

            /// <summary>
            ///     The property named 'Text' of the object
            /// </summary>
            Text,

            /// <summary>
            ///     The property named 'Caption' of the object
            /// </summary>
            Caption,

            /// <summary>
            ///     The property named 'BackColor' of the object
            /// </summary>
            BackColor,

            /// <summary>
            ///     The property named 'ForeColor' of the object
            /// </summary>
            ForeColor,

            /// <summary>
            ///     The property named 'Opacity' of the object
            /// </summary>
            Opacity
        }

        private readonly List<Path> _paths = new List<Path>();

        private readonly List<Path> _tempPaths = new List<Path>();

        private readonly Timer _timer;

        private bool _tempReverseRepeat;

        /// <summary>
        ///     The callback to get invoked at the end of the animation
        /// </summary>
        protected SafeInvoker EndCallback;

        /// <summary>
        ///     The callback to get invoked at each frame
        /// </summary>
        protected SafeInvoker<float> FrameCallback;

        /// <summary>
        ///     The target object to change the property of
        /// </summary>
        protected object TargetObject;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        public Animator()
            : this(new Path[] { })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator(FPSLimiterKnownValues fpsLimiter)
            : this(new Path[] { }, fpsLimiter)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        public Animator(Path path)
            : this(new[] { path })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator(Path path, FPSLimiterKnownValues fpsLimiter)
            : this(new[] { path }, fpsLimiter)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        public Animator(Path[] paths)
            : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator(Path[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            CurrentStatus = AnimatorStatus.Stopped;
            _timer = new Timer(Elapsed, fpsLimiter);
            Paths = paths;
        }

        /// <summary>
        ///     Gets or sets an array containing the list of paths of the animation
        /// </summary>
        /// <exception cref="InvalidOperationException">Animation is running</exception>
        public Path[] Paths
        {
            get { return _paths.ToArray(); }
            set
            {
                if (CurrentStatus == AnimatorStatus.Stopped)
                {
                    _paths.Clear();
                    _paths.AddRange(value);
                }
                else
                {
                    throw new InvalidOperationException("Animation is running.");
                }
            }
        }

        /// <summary>
        ///     Gets the currently active path.
        /// </summary>
        public Path ActivePath { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        public virtual bool Repeat { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        public virtual bool ReverseRepeat { get; set; }

        /// <summary>
        ///     Gets the current status of the animation
        /// </summary>
        public virtual AnimatorStatus CurrentStatus { get; private set; }

        /// <summary>
        ///     Pause the animation
        /// </summary>
        public virtual void Pause()
        {
            if (CurrentStatus != AnimatorStatus.OnHold && CurrentStatus != AnimatorStatus.Playing)
                return;
            _timer.Stop();
            CurrentStatus = AnimatorStatus.Paused;
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        public virtual void Play(object targetObject, string propertyName)
        {
            Play(targetObject, propertyName, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public virtual void Play(object targetObject, string propertyName, SafeInvoker endCallback)
        {
            TargetObject = targetObject;
            var prop = TargetObject.GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.SetProperty);
            if (prop == null) return;
            Play(
                new SafeInvoker<float>(
                    value => prop.SetValue(TargetObject, Convert.ChangeType(value, prop.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter)
        {
            Play(targetObject, propertySetter, null);
        }


        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback)
        {
            if (propertySetter == null)
                return;
            TargetObject = targetObject;

            var property =
                ((propertySetter.Body as MemberExpression) ??
                 (((UnaryExpression)propertySetter.Body).Operand as MemberExpression)).Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException();
            }

            Play(
                new SafeInvoker<float>(
                    value => property.SetValue(TargetObject, Convert.ChangeType(value, property.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Resume the animation from where it paused
        /// </summary>
        public virtual void Resume()
        {
            if (CurrentStatus == AnimatorStatus.Paused)
            {
                _timer.Resume();
            }
        }

        /// <summary>
        ///     Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        public virtual void Stop()
        {
            _timer.Stop();
            lock (_tempPaths)
            {
                _tempPaths.Clear();
            }
            ActivePath = null;
            CurrentStatus = AnimatorStatus.Stopped;
            _tempReverseRepeat = false;
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        public virtual void Play(object targetObject, KnownProperties property)
        {
            Play(targetObject, property, null);
        }


        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public virtual void Play(object targetObject, KnownProperties property, SafeInvoker endCallback)
        {
            Play(targetObject, property.ToString(), endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        public virtual void Play(SafeInvoker<float> frameCallback)
        {
            Play(frameCallback, (SafeInvoker<float>)null);
        }


        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public virtual void Play(SafeInvoker<float> frameCallback, SafeInvoker endCallback)
        {
            Stop();
            FrameCallback = frameCallback;
            EndCallback = endCallback;
            _timer.ResetClock();
            lock (_tempPaths)
            {
                _tempPaths.AddRange(_paths);
            }
            _timer.Start();
        }

        private void Elapsed(ulong millSinceBeginning = 0)
        {
            while (true)
            {
                lock (_tempPaths)
                {
                    if (_tempPaths != null && ActivePath == null && _tempPaths.Count > 0)
                    {
                        while (ActivePath == null)
                        {
                            if (_tempReverseRepeat)
                            {
                                ActivePath = _tempPaths.LastOrDefault();
                                _tempPaths.RemoveAt(_tempPaths.Count - 1);
                            }
                            else
                            {
                                ActivePath = _tempPaths.FirstOrDefault();
                                _tempPaths.RemoveAt(0);
                            }
                            _timer.ResetClock();
                            millSinceBeginning = 0;
                        }
                    }
                    var ended = ActivePath == null;
                    if (ActivePath != null)
                    {
                        if (!_tempReverseRepeat && millSinceBeginning < ActivePath.Delay)
                        {
                            CurrentStatus = AnimatorStatus.OnHold;
                            return;
                        }
                        if (millSinceBeginning - (!_tempReverseRepeat ? ActivePath.Delay : 0) <= ActivePath.Duration)
                        {
                            if (CurrentStatus != AnimatorStatus.Playing)
                            {
                                CurrentStatus = AnimatorStatus.Playing;
                            }
                            var value = ActivePath.Function(_tempReverseRepeat ? ActivePath.Duration - millSinceBeginning : millSinceBeginning - ActivePath.Delay, ActivePath.Start, ActivePath.Change, ActivePath.Duration);
                            FrameCallback.Invoke(value);
                            return;
                        }
                        if (CurrentStatus == AnimatorStatus.Playing)
                        {
                            if (_tempPaths.Count == 0)
                            {
                                // For the last path, we make sure that control is in end point
                                FrameCallback.Invoke(_tempReverseRepeat ? ActivePath.Start : ActivePath.End);
                                ended = true;
                            }
                            else
                            {
                                if ((_tempReverseRepeat && ActivePath.Delay > 0) || !_tempReverseRepeat && _tempPaths.FirstOrDefault().Delay > 0)
                                {
                                    // Or if the next path or this one in revese order has a delay
                                    FrameCallback.Invoke(_tempReverseRepeat ? ActivePath.Start : ActivePath.End);
                                }
                            }
                        }
                        if (_tempReverseRepeat && (millSinceBeginning - ActivePath.Duration) < ActivePath.Delay)
                        {
                            CurrentStatus = AnimatorStatus.OnHold;
                            return;
                        }
                        ActivePath = null;
                    }
                    if (!ended)
                    {
                        return;
                    }
                }
                if (Repeat)
                {
                    lock (_tempPaths)
                    {
                        _tempPaths.AddRange(_paths);
                        _tempReverseRepeat = ReverseRepeat && !_tempReverseRepeat;
                    }
                    millSinceBeginning = 0;
                    continue;
                }
                Stop();
                EndCallback.Invoke();
                break;
            }
        }
    }
    #endregion
    #region Animator2D
    /// <summary>
    ///     The two dimensional animator class, useful for animating values
    ///     created from two underlying values
    /// </summary>
    public class Animator2D : IAnimator
    {
        /// <summary>
        ///     The known two dimensional properties of WinForm controls
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            ///     The property named 'Size' of the object
            /// </summary>
            Size,

            /// <summary>
            ///     The property named 'Location' of the object
            /// </summary>
            Location
        }

        private readonly List<Path2D> _paths = new List<Path2D>();


        /// <summary>
        ///     The callback to get invoked at the end of the animation
        /// </summary>
        protected SafeInvoker EndCallback;

        /// <summary>
        ///     The callback to get invoked at each frame
        /// </summary>
        protected SafeInvoker<Float2D> FrameCallback;

        /// <summary>
        ///     A boolean value indicating if the EndInvoker already invoked
        /// </summary>
        protected bool IsEnded;

        /// <summary>
        ///     The target object to change the property of
        /// </summary>
        protected object TargetObject;

        /// <summary>
        ///     The latest horizontal value
        /// </summary>
        protected float? XValue;

        /// <summary>
        ///     The latest vertical value
        /// </summary>
        protected float? YValue;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        public Animator2D()
            : this(new Path2D[] { })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator2D(FPSLimiterKnownValues fpsLimiter)
            : this(new Path2D[] { }, fpsLimiter)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        public Animator2D(Path2D path)
            : this(new[] { path })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator2D(Path2D path, FPSLimiterKnownValues fpsLimiter)
            : this(new[] { path }, fpsLimiter)
        {
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        public Animator2D(Path2D[] paths)
            : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator2D(Path2D[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            HorizontalAnimator = new Animator(fpsLimiter);
            VerticalAnimator = new Animator(fpsLimiter);
            Paths = paths;
        }

        /// <summary>
        ///     Gets the currently active path.
        /// </summary>
        Path2D ActivePath = new Path2D(HorizontalAnimator.ActivePath, VerticalAnimator.ActivePath);

        /// <summary>
        ///     Gets the horizontal animator.
        /// </summary>
        public static Animator HorizontalAnimator { get; set; }

        /// <summary>
        ///     Gets the vertical animator.
        /// </summary>
        public static Animator VerticalAnimator { get; protected set; }

        /// <summary>
        ///     Gets or sets an array containing the list of paths of the animation
        /// </summary>
        /// <exception cref="InvalidOperationException">Animation is running</exception>
        public Path2D[] Paths
        {
            get { return _paths.ToArray(); }
            set
            {
                if (CurrentStatus == AnimatorStatus.Stopped)
                {
                    _paths.Clear();
                    _paths.AddRange(value);
                    var pathsH = new List<Path>();
                    var pathsV = new List<Path>();
                    foreach (var p in value)
                    {
                        pathsH.Add(p.HorizontalPath);
                        pathsV.Add(p.VerticalPath);
                    }
                    HorizontalAnimator.Paths = pathsH.ToArray();
                    VerticalAnimator.Paths = pathsV.ToArray();
                }
                else
                {
                    throw new InvalidOperationException("Animation is running.");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        public virtual bool Repeat
        {
            get { return HorizontalAnimator.Repeat && VerticalAnimator.Repeat; }

            set { HorizontalAnimator.Repeat = VerticalAnimator.Repeat = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        public virtual bool ReverseRepeat
        {
            get { return HorizontalAnimator.ReverseRepeat && VerticalAnimator.ReverseRepeat; }

            set { HorizontalAnimator.ReverseRepeat = VerticalAnimator.ReverseRepeat = value; }
        }

        /// <summary>
        ///     Gets the current status of the animation
        /// </summary>
        public virtual AnimatorStatus CurrentStatus
        {
            get
            {
                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Stopped
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Stopped)
                {
                    return AnimatorStatus.Stopped;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Paused)
                {
                    return AnimatorStatus.Paused;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.OnHold)
                {
                    return AnimatorStatus.OnHold;
                }

                return AnimatorStatus.Playing;
            }
        }

        /// <summary>
        ///     Pause the animation
        /// </summary>
        public virtual void Pause()
        {
            if (CurrentStatus == AnimatorStatus.OnHold || CurrentStatus == AnimatorStatus.Playing)
            {
                HorizontalAnimator.Pause();
                VerticalAnimator.Pause();
            }
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        public virtual void Play(object targetObject, string propertyName)
        {
            Play(targetObject, propertyName, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public virtual void Play(object targetObject, string propertyName, SafeInvoker endCallback)
        {
            TargetObject = targetObject;
            var prop = TargetObject.GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.SetProperty);
            if (prop == null) return;

            Play(
                new SafeInvoker<Float2D>(
                    value =>
                        prop.SetValue(TargetObject, Convert.ChangeType(value, prop.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter)
        {
            Play(targetObject, propertySetter, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback)
        {
            if (propertySetter == null)
                return;
            TargetObject = targetObject;

            var property =
                ((propertySetter.Body as MemberExpression) ??
                 (((UnaryExpression)propertySetter.Body).Operand as MemberExpression)).Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException();
            }

            Play(
                new SafeInvoker<Float2D>(
                    value =>
                        property.SetValue(TargetObject, Convert.ChangeType(value, property.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Resume the animation from where it paused
        /// </summary>
        public virtual void Resume()
        {
            if (CurrentStatus == AnimatorStatus.Paused)
            {
                HorizontalAnimator.Resume();
                VerticalAnimator.Resume();
            }
        }

        /// <summary>
        ///     Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        public virtual void Stop()
        {
            HorizontalAnimator.Stop();
            VerticalAnimator.Stop();
            XValue = YValue = null;
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        public void Play(object targetObject, KnownProperties property)
        {
            Play(targetObject, property, null);
        }


        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public void Play(object targetObject, KnownProperties property, SafeInvoker endCallback)
        {
            Play(targetObject, property.ToString(), endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        public void Play(SafeInvoker<Float2D> frameCallback)
        {
            Play(frameCallback, (SafeInvoker)null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public void Play(SafeInvoker<Float2D> frameCallback, SafeInvoker endCallback)
        {
            Stop();
            FrameCallback = frameCallback;
            EndCallback = endCallback;
            HorizontalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        XValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
            VerticalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        YValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
        }

        private void InvokeFinisher()
        {
            if (EndCallback != null && !IsEnded)
            {
                lock (EndCallback)
                {
                    if (CurrentStatus == AnimatorStatus.Stopped)
                    {
                        IsEnded = true;
                        EndCallback.Invoke();
                    }
                }
            }
        }

        private void InvokeSetter()
        {
            if (XValue != null && YValue != null)
            {
                FrameCallback.Invoke(new Float2D(XValue.Value, YValue.Value));
            }
        }
    }
    #endregion
    #region Animator3D
    /// <summary>
    ///     The three dimensional animator class, useful for animating values
    ///     created from three underlying values
    /// </summary>
    public class Animator3D : IAnimator
    {
        /// <summary>
        ///     The known three dimensional properties of WinForm controls
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            ///     The property named 'BackColor' of the object
            /// </summary>
            BackColor,

            /// <summary>
            ///     The property named 'ForeColor' of the object
            /// </summary>
            ForeColor
        }

        private readonly List<Path3D> _paths = new List<Path3D>();

        /// <summary>
        ///     The callback to get invoked at the end of the animation
        /// </summary>
        protected SafeInvoker EndCallback;

        /// <summary>
        ///     The callback to get invoked at each frame
        /// </summary>
        protected SafeInvoker<Float3D> FrameCallback;

        /// <summary>
        ///     A boolean value indicating if the EndInvoker already invoked
        /// </summary>
        protected bool IsEnded;

        /// <summary>
        ///     The target object to change the property of
        /// </summary>
        protected object TargetObject;

        /// <summary>
        ///     The latest horizontal value
        /// </summary>
        protected float? XValue;

        /// <summary>
        ///     The latest vertical value
        /// </summary>
        protected float? YValue;

        /// <summary>
        ///     The latest depth value
        /// </summary>
        protected float? ZValue;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        public Animator3D()
            : this(new Path3D[] { })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator3D(FPSLimiterKnownValues fpsLimiter)
            : this(new Path3D[] { }, fpsLimiter)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        public Animator3D(Path3D path)
            : this(new[] { path })
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="path">
        ///     The path of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator3D(Path3D path, FPSLimiterKnownValues fpsLimiter)
            : this(new[] { path }, fpsLimiter)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        public Animator3D(Path3D[] paths)
            : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="paths">
        ///     An array containing the list of paths of the animation
        /// </param>
        /// <param name="fpsLimiter">
        ///     Limits the maximum frames per seconds
        /// </param>
        public Animator3D(Path3D[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            HorizontalAnimator = new Animator(fpsLimiter);
            VerticalAnimator = new Animator(fpsLimiter);
            DepthAnimator = new Animator(fpsLimiter);
            Paths = paths;
        }

        /// <summary>
        ///     Gets the currently active path.
        /// </summary>
        public Path3D ActivePath = new Path3D(
            HorizontalAnimator.ActivePath,
            VerticalAnimator.ActivePath,
            DepthAnimator.ActivePath);

        /// <summary>
        ///     Gets the horizontal animator.
        /// </summary>
        public static Animator HorizontalAnimator { get; set; }

        /// <summary>
        ///     Gets the vertical animator.
        /// </summary>
        public static Animator VerticalAnimator { get; set; }

        /// <summary>
        ///     Gets the depth animator.
        /// </summary>
        public static Animator DepthAnimator { get; set; }


        /// <summary>
        ///     Gets or sets an array containing the list of paths of the animation
        /// </summary>
        /// <exception cref="InvalidOperationException">Animation is running</exception>
        public Path3D[] Paths
        {
            get { return _paths.ToArray(); }
            set
            {
                if (CurrentStatus == AnimatorStatus.Stopped)
                {
                    _paths.Clear();
                    _paths.AddRange(value);
                    var pathsX = new List<Path>();
                    var pathsY = new List<Path>();
                    var pathsZ = new List<Path>();
                    foreach (var p in value)
                    {
                        pathsX.Add(p.HorizontalPath);
                        pathsY.Add(p.VerticalPath);
                        pathsZ.Add(p.DepthPath);
                    }

                    HorizontalAnimator.Paths = pathsX.ToArray();
                    VerticalAnimator.Paths = pathsY.ToArray();
                    DepthAnimator.Paths = pathsZ.ToArray();
                }
                else
                {
                    throw new NotSupportedException("Animation is running.");
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        public virtual bool Repeat
        {
            get { return HorizontalAnimator.Repeat && VerticalAnimator.Repeat && DepthAnimator.Repeat; }

            set { HorizontalAnimator.Repeat = VerticalAnimator.Repeat = DepthAnimator.Repeat = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        public virtual bool ReverseRepeat
        {
            get
            {
                return HorizontalAnimator.ReverseRepeat && VerticalAnimator.ReverseRepeat
                       && DepthAnimator.ReverseRepeat;
            }

            set
            {
                HorizontalAnimator.ReverseRepeat =
                    VerticalAnimator.ReverseRepeat = DepthAnimator.ReverseRepeat = value;
            }
        }

        /// <summary>
        ///     Gets the current status of the animation
        /// </summary>
        public virtual AnimatorStatus CurrentStatus
        {
            get
            {
                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Stopped
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Stopped
                    && DepthAnimator.CurrentStatus == AnimatorStatus.Stopped)
                {
                    return AnimatorStatus.Stopped;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && DepthAnimator.CurrentStatus == AnimatorStatus.Paused)
                {
                    return AnimatorStatus.Paused;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && DepthAnimator.CurrentStatus == AnimatorStatus.OnHold)
                {
                    return AnimatorStatus.OnHold;
                }

                return AnimatorStatus.Playing;
            }
        }

        /// <summary>
        ///     Pause the animation
        /// </summary>
        public virtual void Pause()
        {
            if (CurrentStatus == AnimatorStatus.OnHold || CurrentStatus == AnimatorStatus.Playing)
            {
                HorizontalAnimator.Pause();
                VerticalAnimator.Pause();
                DepthAnimator.Pause();
            }
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        public virtual void Play(object targetObject, string propertyName)
        {
            Play(targetObject, propertyName, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public virtual void Play(object targetObject, string propertyName, SafeInvoker endCallback)
        {
            TargetObject = targetObject;
            var prop = TargetObject.GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.SetProperty);
            if (prop == null) return;

            Play(
                new SafeInvoker<Float3D>(
                    value =>
                        prop.SetValue(TargetObject, Convert.ChangeType(value, prop.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter)
        {
            Play(targetObject, propertySetter, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback)
        {
            if (propertySetter == null)
                return;
            TargetObject = targetObject;

            var property =
                ((propertySetter.Body as MemberExpression) ??
                 (((UnaryExpression)propertySetter.Body).Operand as MemberExpression)).Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException();
            }

            Play(
                new SafeInvoker<Float3D>(
                    value =>
                        property.SetValue(TargetObject, Convert.ChangeType(value, property.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        ///     Resume the animation from where it paused
        /// </summary>
        public virtual void Resume()
        {
            if (CurrentStatus == AnimatorStatus.Paused)
            {
                HorizontalAnimator.Resume();
                VerticalAnimator.Resume();
                DepthAnimator.Resume();
            }
        }

        /// <summary>
        ///     Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        public virtual void Stop()
        {
            HorizontalAnimator.Stop();
            VerticalAnimator.Stop();
            DepthAnimator.Stop();
            XValue = YValue = ZValue = null;
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        public void Play(object targetObject, KnownProperties property)
        {
            Play(targetObject, property, null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="property">
        ///     The property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public void Play(object targetObject, KnownProperties property, SafeInvoker endCallback)
        {
            Play(targetObject, property.ToString(), endCallback);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        public void Play(SafeInvoker<Float3D> frameCallback)
        {
            Play(frameCallback, (SafeInvoker)null);
        }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">
        ///     The callback to get invoked at each frame
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        public void Play(SafeInvoker<Float3D> frameCallback, SafeInvoker endCallback)
        {
            Stop();
            FrameCallback = frameCallback;
            EndCallback = endCallback;
            IsEnded = false;
            HorizontalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        XValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
            VerticalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        YValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
            DepthAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        ZValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
        }

        private void InvokeFinisher()
        {
            if (EndCallback != null && !IsEnded)
            {
                lock (EndCallback)
                {
                    if (CurrentStatus == AnimatorStatus.Stopped)
                    {
                        IsEnded = true;
                        EndCallback.Invoke();
                    }
                }
            }
        }

        private void InvokeSetter()
        {
            if (XValue != null && YValue != null && ZValue != null)
            {
                FrameCallback.Invoke(new Float3D(XValue.Value, YValue.Value, ZValue.Value));
            }
        }
    }
    #endregion
    #region AnimatorStatus
    /// <summary>
    ///     The possible statuses for an animator instance
    /// </summary>
    public enum AnimatorStatus
    {
        /// <summary>
        ///     Animation is stopped
        /// </summary>
        Stopped,

        /// <summary>
        ///     Animation is now playing
        /// </summary>
        Playing,

        /// <summary>
        ///     Animation is now on hold for path delay, consider this value as playing
        /// </summary>
        OnHold,

        /// <summary>
        ///     Animation is paused
        /// </summary>
        Paused
    }
    #endregion
    #region Float2D
    /// <summary>
    ///     The Float2D class contains two <see langword="float" /> values and
    ///     represents a point in a 2D plane
    /// </summary>
    public class Float2D : IConvertible, IEquatable<Float2D>, IEquatable<Point>, IEquatable<PointF>, IEquatable<Size>,
        IEquatable<SizeF>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Float2D" /> class.
        /// </summary>
        /// <param name="x">
        ///     The horizontal value
        /// </param>
        /// <param name="y">
        ///     The vertical value
        /// </param>
        public Float2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Float2D" /> class.
        /// </summary>
        public Float2D()
            : this(default(float), default(float))
        {
        }

        /// <summary>
        ///     Gets the horizontal value of the point
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets the vertical value of the point
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     Returns the <see cref="T:System.TypeCode" /> for this instance.
        /// </summary>
        /// <returns>
        ///     The enumerated constant that is the <see cref="T:System.TypeCode" /> of the class or value type that implements
        ///     this interface.
        /// </returns>
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting
        ///     information.
        /// </summary>
        /// <returns>
        ///     A Boolean value equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 8-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent Unicode character using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     A Unicode character equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.DateTime" /> using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.DateTime" /> instance equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.Decimal" /> number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Decimal" /> number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent double-precision floating-point number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A double-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 16-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 32-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 64-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 8-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent single-precision floating-point number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A single-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 16-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 32-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 64-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.String" /> using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> instance equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        /// <summary>
        ///     Converts the value of this instance to an <see cref="T:System.Object" /> of the specified
        ///     <see cref="T:System.Type" /> that has an equivalent value, using the specified culture-specific formatting
        ///     information.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Object" /> instance of type <paramref name="conversionType" /> whose value is equivalent to
        ///     the value of this instance.
        /// </returns>
        /// <param name="conversionType">The <see cref="T:System.Type" /> to which the value of this instance is converted. </param>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(Point))
            {
                return (Point)this;
            }
            if (conversionType == typeof(Size))
            {
                return (Size)this;
            }
            if (conversionType == typeof(PointF))
            {
                return (PointF)this;
            }
            if (conversionType == typeof(SizeF))
            {
                return (SizeF)this;
            }
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Float2D other)
        {
            return this == other;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to a <see cref="Point" /> object.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Point other)
        {
            return this == other;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to a <see cref="PointF" /> object.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(PointF other)
        {
            return this == other;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to a <see cref="Size" /> object.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Size other)
        {
            return this == other;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to a <see cref="SizeF" /> object.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(SizeF other)
        {
            return this == other;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="T:System.Object" /> is equal to the current
        ///     <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />;
        ///     otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var conversionType = obj.GetType();
            if (conversionType == typeof(Point))
            {
                return this == (Point)obj;
            }
            if (conversionType == typeof(PointF))
            {
                return this == (PointF)obj;
            }
            if (conversionType == typeof(Size))
            {
                return this == (Size)obj;
            }
            if (conversionType == typeof(SizeF))
            {
                return this == (SizeF)obj;
            }
            return obj.GetType() == GetType() && Equals((Float2D)obj);
        }

        /// <summary>
        ///     Serves as a hash function for a particular type. This code will change of the values of the X and Y changes. Make
        ///     sure to not change the values while stored in a hash dependent data structure.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="Float2D" />.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
                // ReSharper restore NonReadonlyMemberInGetHashCode
            }
        }

        /// <summary>
        ///     Compares two <see cref="Float2D" /> objects for equality
        /// </summary>
        /// <param name="left">Left <see cref="Float2D" /> object</param>
        /// <param name="right">Right <see cref="Float2D" /> object</param>
        /// <returns>true if both objects are equal, otherwise false</returns>
        public static bool operator ==(Float2D left, Float2D right)
        {
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return ReferenceEquals(left, null) && ReferenceEquals(right, null);
            }
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return ReferenceEquals(left, right) || ((double)(left.X) == right.X && (double)(left.Y) == right.Y);
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        /// <summary>
        ///     Compares two <see cref="Float2D" /> objects for in-equality
        /// </summary>
        /// <param name="left">Left <see cref="Float2D" /> object</param>
        /// <param name="right">Right <see cref="Float2D" /> object</param>
        /// <returns>false if both objects are equal, otherwise true</returns>
        public static bool operator !=(Float2D left, Float2D right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Represents the values as an instance of the <see cref="Size" /> class
        /// </summary>
        /// <param name="float2D">
        ///     The <see cref="Float2D" /> class to convert
        /// </param>
        /// <returns>
        ///     A new instance of the <see cref="Size" /> class representing the values in the <see cref="Float2D" /> instance
        /// </returns>
        public static implicit operator Size(Float2D float2D)
        {
            return new Size((int)float2D.X, (int)float2D.Y);
        }

        /// <summary>
        ///     Represents the values as an instance of the <see cref="Point" /> class
        /// </summary>
        /// <param name="float2D">
        ///     The <see cref="Float2D" /> class to convert
        /// </param>
        /// <returns>
        ///     A new instance of the <see cref="Point" /> class representing the values in the <see cref="Float2D" /> instance
        /// </returns>
        public static implicit operator Point(Float2D float2D)
        {
            return new Point((int)float2D.X, (int)float2D.Y);
        }


        /// <summary>
        ///     Represents the values as an instance of the <see cref="SizeF" /> class
        /// </summary>
        /// <param name="float2D">
        ///     The <see cref="Float2D" /> class to convert
        /// </param>
        /// <returns>
        ///     A new instance of the <see cref="SizeF" /> class representing the values in the <see cref="Float2D" /> instance
        /// </returns>
        public static implicit operator SizeF(Float2D float2D)
        {
            return new SizeF(float2D.X, float2D.Y);
        }

        /// <summary>
        ///     Represents the values as an instance of the <see cref="PointF" /> class
        /// </summary>
        /// <param name="float2D">
        ///     The <see cref="Float2D" /> class to convert
        /// </param>
        /// <returns>
        ///     A new instance of the <see cref="PointF" /> class representing the values in the <see cref="Float2D" /> instance
        /// </returns>
        public static implicit operator PointF(Float2D float2D)
        {
            return new PointF(float2D.X, float2D.Y);
        }

        /// <summary>
        ///     Returns a string that represents the current <see cref="Float2D" />.
        /// </summary>
        /// <returns>
        ///     A string that represents the current <see cref="Float2D" />.
        /// </returns>
        public override string ToString()
        {
            return "(" + X.ToString("0.00") + "," + Y.ToString("0.00") + ")";
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from a <see cref="Point" /> instance
        /// </summary>
        /// <param name="point">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D FromPoint(Point point)
        {
            return new Float2D(point.X, point.Y);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from a <see cref="PointF" /> instance
        /// </summary>
        /// <param name="point">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D FromPoint(PointF point)
        {
            return new Float2D(point.X, point.Y);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from a <see cref="Size" /> instance
        /// </summary>
        /// <param name="size">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D FromSize(Size size)
        {
            return new Float2D(size.Width, size.Height);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from a <see cref="SizeF" /> instance
        /// </summary>
        /// <param name="size">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D FromSize(SizeF size)
        {
            return new Float2D(size.Width, size.Height);
        }
    }
    #endregion
    #region Float3D
    /// <summary>
    ///     The Float3D class contains two <see langword="float" /> values and
    ///     represents a point in a 3D plane
    /// </summary>
    public class Float3D : IConvertible, IEquatable<Float3D>, IEquatable<Color>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Float3D" /> class.
        /// </summary>
        /// <param name="x">
        ///     The horizontal value
        /// </param>
        /// <param name="y">
        ///     The vertical value
        /// </param>
        /// <param name="z">
        ///     The depth value
        /// </param>
        public Float3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Float3D" /> class.
        /// </summary>
        public Float3D()
            : this(default(float), default(float), default(float))
        {
        }

        /// <summary>
        ///     Gets the horizontal value of the point
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets the vertical value of the point
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     Gets the depth value of the point
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        ///     Returns the <see cref="T:System.TypeCode" /> for this instance.
        /// </summary>
        /// <returns>
        ///     The enumerated constant that is the <see cref="T:System.TypeCode" /> of the class or value type that implements
        ///     this interface.
        /// </returns>
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting
        ///     information.
        /// </summary>
        /// <returns>
        ///     A Boolean value equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 8-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent Unicode character using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     A Unicode character equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.DateTime" /> using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.DateTime" /> instance equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.Decimal" /> number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Decimal" /> number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent double-precision floating-point number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A double-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 16-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 32-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 64-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 8-bit signed integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent single-precision floating-point number using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A single-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 16-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 32-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }


        /// <summary>
        ///     Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <returns>
        ///     An 64-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        /// <exception cref="InvalidCastException">This method is not supported</exception>
        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Converts the value of this instance to an equivalent <see cref="T:System.String" /> using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> instance equivalent to the value of this instance.
        /// </returns>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        /// <summary>
        ///     Converts the value of this instance to an <see cref="T:System.Object" /> of the specified
        ///     <see cref="T:System.Type" /> that has an equivalent value, using the specified culture-specific formatting
        ///     information.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Object" /> instance of type <paramref name="conversionType" /> whose value is equivalent to
        ///     the value of this instance.
        /// </returns>
        /// <param name="conversionType">The <see cref="T:System.Type" /> to which the value of this instance is converted. </param>
        /// <param name="provider">
        ///     An <see cref="T:System.IFormatProvider" /> interface implementation that supplies
        ///     culture-specific formatting information.
        /// </param>
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(Color))
            {
                return (Color)this;
            }
            throw new InvalidCastException();
        }

        /// <summary>
        ///     Indicates whether the current object is equal to a <see cref="Color" /> object.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Color other)
        {
            return this == other;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Float3D other)
        {
            return this == other;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="T:System.Object" /> is equal to the current
        ///     <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />;
        ///     otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var conversionType = obj.GetType();
            if (conversionType == typeof(Color))
            {
                return this == (Color)obj;
            }
            return obj.GetType() == GetType() && Equals((Float3D)obj);
        }

        /// <summary>
        ///     Serves as a hash function for a particular type. This code will change of the values of the X and Y changes. Make
        ///     sure to not change the values while stored in a hash dependent data structure.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="Float3D" />.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
                // ReSharper restore NonReadonlyMemberInGetHashCode
            }
        }


        /// <summary>
        ///     Compares two <see cref="Float3D" /> objects for equality
        /// </summary>
        /// <param name="left">Left <see cref="Float3D" /> object</param>
        /// <param name="right">Right <see cref="Float3D" /> object</param>
        /// <returns>true if both objects are equal, otherwise false</returns>
        public static bool operator ==(Float3D left, Float3D right)
        {
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return ReferenceEquals(left, null) && ReferenceEquals(right, null);
            }
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return ReferenceEquals(left, right) ||
                   ((double)(left.X) == right.X && (double)(left.Y) == right.Y && (double)(left.Z) == right.Z);
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        /// <summary>
        ///     Compares two <see cref="Float3D" /> objects for in-equality
        /// </summary>
        /// <param name="left">Left <see cref="Float3D" /> object</param>
        /// <param name="right">Right <see cref="Float3D" /> object</param>
        /// <returns>false if both objects are equal, otherwise true</returns>
        public static bool operator !=(Float3D left, Float3D right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Represents the values as an instance of the <see cref="Color" /> class
        /// </summary>
        /// <param name="float3D">
        ///     The <see cref="Float3D" /> class to convert
        /// </param>
        /// <returns>
        ///     A new instance of the <see cref="Color" /> class representing the values in the <see cref="Float3D" /> instance
        /// </returns>
        public static implicit operator Color(Float3D float3D)
        {
            return Color.FromArgb((int)float3D.X, (int)float3D.Y, (int)float3D.Z);
        }

        /// <summary>
        ///     Returns a string that represents the current <see cref="Float3D" />.
        /// </summary>
        /// <returns>
        ///     A string that represents the current <see cref="Float3D" />.
        /// </returns>
        public override string ToString()
        {
            return "(" + X.ToString("0.00") + "," + Y.ToString("0.00") + "," + Z.ToString("0.00") + ")";
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float3D" /> class from a <see cref="Color" /> instance
        /// </summary>
        /// <param name="color">The object to create the <see cref="Float3D" /> instance from</param>
        /// <returns>The newly created <see cref="Float3D" /> instance</returns>
        public static Float3D FromColor(Color color)
        {
            return new Float3D(color.R, color.G, color.B);
        }
    }
    #endregion
    #region FloatExtensions
    /// <summary>
    ///     Contains public extension methods about Float2D and Fload3D classes
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from this instance
        /// </summary>
        /// <param name="point">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D ToFloat2D(this Point point)
        {
            return Float2D.FromPoint(point);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from this instance
        /// </summary>
        /// <param name="point">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D ToFloat2D(this PointF point)
        {
            return Float2D.FromPoint(point);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from this instance
        /// </summary>
        /// <param name="size">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D ToFloat2D(this Size size)
        {
            return Float2D.FromSize(size);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float2D" /> class from this instance
        /// </summary>
        /// <param name="size">The object to create the <see cref="Float2D" /> instance from</param>
        /// <returns>The newly created <see cref="Float2D" /> instance</returns>
        public static Float2D ToFloat2D(this SizeF size)
        {
            return Float2D.FromSize(size);
        }

        /// <summary>
        ///     Creates and returns a new instance of the <see cref="Float3D" /> class from this instance
        /// </summary>
        /// <param name="color">The object to create the <see cref="Float3D" /> instance from</param>
        /// <returns>The newly created <see cref="Float3D" /> instance</returns>
        public static Float3D ToFloat3D(this Color color)
        {
            return Float3D.FromColor(color);
        }
    }
    #endregion
    #region FPSLimiterKnownValues
    /// <summary>
    ///     FPS limiter known values
    /// </summary>
    public enum FPSLimiterKnownValues
    {
        /// <summary>
        ///     Limits maximum frames per second to 10fps
        /// </summary>
        LimitTen = 10,

        /// <summary>
        ///     Limits maximum frames per second to 20fps
        /// </summary>
        LimitTwenty = 20,

        /// <summary>
        ///     Limits maximum frames per second to 30fps
        /// </summary>
        LimitThirty = 30,

        /// <summary>
        ///     Limits maximum frames per second to 60fps
        /// </summary>
        LimitSixty = 60,

        /// <summary>
        ///     Limits maximum frames per second to 100fps
        /// </summary>
        LimitOneHundred = 100,

        /// <summary>
        ///     Limits maximum frames per second to 200fps
        /// </summary>
        LimitTwoHundred = 200,

        /// <summary>
        ///     Adds no limit to the number of frames per second
        /// </summary>
        NoFPSLimit = -1
    }
    #endregion
    #region IAnimator
    /// <summary>
    ///     The base interface for any Animator class, custom or build-in
    /// </summary>
    public interface IAnimator
    {
        /// <summary>
        ///     Gets the current status of the animation
        /// </summary>
        AnimatorStatus CurrentStatus { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        bool Repeat { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        bool ReverseRepeat { get; set; }

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        void Play(object targetObject, string propertyName);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertyName">
        ///     The name of the property to change
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        void Play(object targetObject, string propertyName, SafeInvoker endCallback);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter);

        /// <summary>
        ///     Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">
        ///     The target object to change the property
        /// </param>
        /// <param name="propertySetter">
        ///     The expression that represents the property of the target object
        /// </param>
        /// <param name="endCallback">
        ///     The callback to get invoked at the end of the animation
        /// </param>
        /// <typeparam name="T">
        ///     Any object containing a property
        /// </typeparam>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback);

        /// <summary>
        ///     Resume the animation from where it paused
        /// </summary>
        void Resume();

        /// <summary>
        ///     Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        void Stop();

        /// <summary>
        ///     Pause the animation
        /// </summary>
        void Pause();
    }
    #endregion
    #region KnownAnimationFunctions
    /// <summary>
    ///     Contains a list of all known animation functions
    /// </summary>
    public enum KnownAnimationFunctions
    {
        /// <summary>
        ///     No known animation function
        /// </summary>
        None,

        /// <summary>
        ///     The cubic ease-in animation function.
        /// </summary>
        CubicEaseIn,

        /// <summary>
        ///     The cubic ease-in and ease-out animation function.
        /// </summary>
        CubicEaseInOut,

        /// <summary>
        ///     The cubic ease-out animation function.
        /// </summary>
        CubicEaseOut,

        /// <summary>
        ///     The liner animation function.
        /// </summary>
        Liner,

        /// <summary>
        ///     The circular ease-in and ease-out animation function.
        /// </summary>
        CircularEaseInOut,

        /// <summary>
        ///     The circular ease-in animation function.
        /// </summary>
        CircularEaseIn,

        /// <summary>
        ///     The circular ease-out animation function.
        /// </summary>
        CircularEaseOut,

        /// <summary>
        ///     The quadratic ease-in animation function.
        /// </summary>
        QuadraticEaseIn,

        /// <summary>
        ///     The quadratic ease-out animation function.
        /// </summary>
        QuadraticEaseOut,

        /// <summary>
        ///     The quadratic ease-in and ease-out animation function.
        /// </summary>
        QuadraticEaseInOut,

        /// <summary>
        ///     The quartic ease-in animation function.
        /// </summary>
        QuarticEaseIn,

        /// <summary>
        ///     The quartic ease-out animation function.
        /// </summary>
        QuarticEaseOut,

        /// <summary>
        ///     The quartic ease-in and ease-out animation function.
        /// </summary>
        QuarticEaseInOut,

        /// <summary>
        ///     The quintic ease-in and ease-out animation function.
        /// </summary>
        QuinticEaseInOut,

        /// <summary>
        ///     The quintic ease-in animation function.
        /// </summary>
        QuinticEaseIn,

        /// <summary>
        ///     The quintic ease-out animation function.
        /// </summary>
        QuinticEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in animation function.
        /// </summary>
        SinusoidalEaseIn,

        /// <summary>
        ///     The sinusoidal ease-out animation function.
        /// </summary>
        SinusoidalEaseOut,

        /// <summary>
        ///     The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        SinusoidalEaseInOut,

        /// <summary>
        ///     The exponential ease-in animation function.
        /// </summary>
        ExponentialEaseIn,

        /// <summary>
        ///     The exponential ease-out animation function.
        /// </summary>
        ExponentialEaseOut,

        /// <summary>
        ///     The exponential ease-in and ease-out animation function.
        /// </summary>
        ExponentialEaseInOut
    }
    #endregion
    #region Path
    /// <summary>
    ///     The Path class is a representation of a line in a 1D plane and the
    ///     speed in which the animator plays it
    /// </summary>
    public class Path
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        public Path()
            : this(default(float), default(float), default(ulong), 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path(float start, float end, ulong duration)
            : this(start, end, duration, 0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path(float start, float end, ulong duration, AnimationFunctions.Function function)
            : this(start, end, duration, 0, function)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path(float start, float end, ulong duration, ulong delay)
            : this(start, end, duration, delay, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting value
        /// </param>
        /// <param name="end">
        ///     The ending value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path(float start, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            Start = start;
            End = end;
            Function = function ?? AnimationFunctions.Liner;
            Duration = duration;
            Delay = delay;
        }

        /// <summary>
        ///     Gets the difference of starting and ending values
        /// </summary>
        public float Change = end - start;

        /// <summary>
        ///     Gets or sets the starting delay
        /// </summary>
        public ulong Delay { get; set; }

        /// <summary>
        ///     Gets or sets the duration in milliseconds
        /// </summary>
        public ulong Duration { get; set; }

        /// <summary>
        ///     Gets or sets the ending value
        /// </summary>

        public static float end;
        public float End
        {
            get { return end; }
            set
            {
                end = value;
            }
        }

        /// <summary>
        ///     Gets or sets the animation function
        /// </summary>
        public AnimationFunctions.Function Function { get; set; }

        /// <summary>
        ///     Gets or sets the starting value
        /// </summary>

        public static float start;
        public float Start
        {
            get { return start; }
            set
            {
                start = value;
            }
        }

        /// <summary>
        ///     Creates and returns a new <see cref="Path" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="Path" /> which is the reverse of the current <see cref="Path" />
        /// </returns>
        public Path Reverse()
        {
            return new Path(End, Start, Duration, Delay, Function);
        }
    }
    #endregion
    #region Path2D
    /// <summary>
    ///     The Path2D class is a representation of a line in a 2D plane and the
    ///     speed in which the animator plays it
    /// </summary>
    public class Path2D
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(
            float startX,
            float endX,
            float startY,
            float endY,
            ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
            : this(new Path(startX, endX, duration, delay, function), new Path(startY, endY, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(
            float startX,
            float endX,
            float startY,
            float endY,
            ulong duration,
            ulong delay)
            : this(new Path(startX, endX, duration, delay), new Path(startY, endY, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(
            float startX,
            float endX,
            float startY,
            float endY,
            ulong duration,
            AnimationFunctions.Function function)
            : this(new Path(startX, endX, duration, function), new Path(startY, endY, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(
            float startX,
            float endX,
            float startY,
            float endY,
            ulong duration)
            : this(new Path(startX, endX, duration), new Path(startY, endY, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point or location
        /// </param>
        /// <param name="end">
        ///     The ending point or location
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(Float2D start, Float2D end, ulong duration, ulong delay, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, delay, function),
                new Path(start.Y, end.Y, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point or location
        /// </param>
        /// <param name="end">
        ///     The ending point or location
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(Float2D start, Float2D end, ulong duration, ulong delay)
            : this(
                new Path(start.X, end.X, duration, delay),
                new Path(start.Y, end.Y, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point or location
        /// </param>
        /// <param name="end">
        ///     The ending point or location
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(Float2D start, Float2D end, ulong duration, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, function),
                new Path(start.Y, end.Y, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point or location
        /// </param>
        /// <param name="end">
        ///     The ending point or location
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path2D(Float2D start, Float2D end, ulong duration)
            : this(
                new Path(start.X, end.X, duration),
                new Path(start.Y, end.Y, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path2D" /> class.
        /// </summary>
        /// <param name="x">
        ///     The horizontal path.
        /// </param>
        /// <param name="y">
        ///     The vertical path.
        /// </param>
        public Path2D(Path x, Path y)
        {
            HorizontalPath = x;
            VerticalPath = y;
        }

        /// <summary>
        ///     Gets the horizontal path
        /// </summary>

        public static Path _horizontalPath;
        public Path HorizontalPath
        {
            get { return _horizontalPath; }
            set
            {
                _horizontalPath = value;
            }
        }

        /// <summary>
        ///     Gets the vertical path
        /// </summary>

        public static Path _verticalPath;
        public Path VerticalPath
        {
            get { return _verticalPath; }
            set
            {
                _verticalPath = value;
            }
        }

        /// <summary>
        ///     Gets the starting point of the path
        /// </summary>
        public Float2D Start = new Float2D(_horizontalPath.Start, _verticalPath.Start);


        /// <summary>
        ///     Gets the ending point of the path
        /// </summary>
        public Float2D End = new Float2D(_horizontalPath.End, _verticalPath.End);

        /// <summary>
        ///     Creates and returns a new <see cref="Path2D" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="Path2D" /> which is the reverse of the current <see cref="Path2D" />
        /// </returns>
        public Path2D Reverse()
        {
            return new Path2D(HorizontalPath.Reverse(), VerticalPath.Reverse());
        }
    }
    #endregion
    #region Path2DExtensions
    /// <summary>
    ///     Contains public extensions methods about Path2D class
    /// </summary>
    public static class Path2DExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, Float2D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, end, duration, delay, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration)
        {
            return paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, float endX, float endY, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path2D(paths.Last().End, new Float2D(endX, endY), duration, delay, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, Float2D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path2D[] ContinueTo(this Path2D path, float endX, float endY, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, duration, delay, function);
        }

        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ContinueTo(this Path2D[] paths, params Path2D[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ContinueTo(this Path2D path, params Path2D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path2D[] ToArray(this Path2D path)
        {
            return new[] { path };
        }
    }
    #endregion
    #region Path3D
    /// <summary>
    ///     The Path3D class is a representation of a line in a 3D plane and the
    ///     speed in which the animator plays it
    /// </summary>
    public class Path3D
    {
        public Path3D()
        {

        }
        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
            : this(
                new Path(startX, endX, duration, delay, function),
                new Path(startY, endY, duration, delay, function),
                new Path(startZ, endZ, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay)
            : this(
                new Path(startX, endX, duration, delay),
                new Path(startY, endY, duration, delay),
                new Path(startZ, endZ, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            AnimationFunctions.Function function)
            : this(
                new Path(startX, endX, duration, function),
                new Path(startY, endY, duration, function),
                new Path(startZ, endZ, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">
        ///     The starting horizontal value
        /// </param>
        /// <param name="endX">
        ///     The ending horizontal value
        /// </param>
        /// <param name="startY">
        ///     The starting vertical value
        /// </param>
        /// <param name="endY">
        ///     The ending vertical value
        /// </param>
        /// <param name="startZ">
        ///     The starting depth value
        /// </param>
        /// <param name="endZ">
        ///     The ending depth value
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration)
            : this(new Path(startX, endX, duration), new Path(startY, endY, duration), new Path(startZ, endZ, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, delay, function),
                new Path(start.Y, end.Y, duration, delay, function),
                new Path(start.Z, end.Z, duration, delay, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="delay">
        ///     The time in miliseconds that the animator must wait before playing this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay)
            : this(
                new Path(start.X, end.X, duration, delay),
                new Path(start.Y, end.Y, duration, delay),
                new Path(start.Z, end.Z, duration, delay))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <param name="function">
        ///     The animation function
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(Float3D start, Float3D end, ulong duration, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, function),
                new Path(start.Y, end.Y, duration, function),
                new Path(start.Z, end.Z, duration, function))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">
        ///     The starting point in a 3D plane
        /// </param>
        /// <param name="end">
        ///     The ending point in a 3D plane
        /// </param>
        /// <param name="duration">
        ///     The time in miliseconds that the animator must play this path
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Duration is less than zero
        /// </exception>
        public Path3D(Float3D start, Float3D end, ulong duration)
            : this(
                new Path(start.X, end.X, duration),
                new Path(start.Y, end.Y, duration),
                new Path(start.Z, end.Z, duration))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="x">
        ///     The horizontal path.
        /// </param>
        /// <param name="y">
        ///     The vertical path.
        /// </param>
        /// <param name="z">
        ///     The depth path.
        /// </param>
        public Path3D(Path x, Path y, Path z)
        {
            HorizontalPath = x;
            VerticalPath = y;
            DepthPath = z;
        }

        /// <summary>
        ///     Gets the horizontal path
        /// </summary>

        public static Path _horizontalPath;
        public Path HorizontalPath
        {
            get { return _horizontalPath; }
            set
            {
                _horizontalPath = value;
            }
        }

        /// <summary>
        ///     Gets the vertical path
        /// </summary>

        public static Path _verticalPath;
        public Path VerticalPath
        {
            get { return _verticalPath; }
            set
            {
                _verticalPath = value;
            }
        }

        public static Path _depthPath;
        /// <summary>
        ///     Gets the depth path
        /// </summary>
        public Path DepthPath
        {
            get { return _depthPath; }
            set
            {
                _depthPath = value;
            }
        }


        /// <summary>
        ///     Gets the starting point of the path
        /// </summary>
        public Float3D Start = new Float3D(_horizontalPath.Start, _verticalPath.Start, _depthPath.Start);



        /// <summary>
        ///     Gets the ending point of the path
        /// </summary>
        public Float3D End = new Float3D(_horizontalPath.End, _verticalPath.End, _depthPath.End);

        /// <summary>
        ///     Creates and returns a new <see cref="Path3D" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>
        ///     A new <see cref="Path" /> which is the reverse of the current <see cref="Path3D" />
        /// </returns>
        public Path3D Reverse()
        {
            return new Path3D(HorizontalPath.Reverse(), VerticalPath.Reverse(), DepthPath.Reverse());
        }
    }
    #endregion
    #region Path3DExtensions
    /// <summary>
    ///     Contains public extensions methods about Path3D class
    /// </summary>
    public static class Path3DExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, Float3D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, end, duration, delay, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration)
        {
            return paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, function) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            ulong delay)
        {
            return
                paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, delay) })
                    .ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, float endX, float endY, float endZ, ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
        {
            return
                paths.Concat(new[] { new Path3D(paths.Last().End, new Float3D(endX, endY, endZ), duration, delay, function) })
                    .ToArray();
        }


        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, Float3D end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            ulong delay)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="endX">Horizontal value of the next point to follow</param>
        /// <param name="endY">Vertical value of the next point to follow</param>
        /// <param name="endZ">Depth value of the next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path3D[] ContinueTo(this Path3D path, float endX, float endY, float endZ, ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(endX, endY, endZ, duration, delay, function);
        }


        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ContinueTo(this Path3D[] paths, params Path3D[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ContinueTo(this Path3D path, params Path3D[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path3D[] ToArray(this Path3D path)
        {
            return new[] { path };
        }
    }
    #endregion
    #region PathExtensions
    /// <summary>
    ///     Contains public extensions methods about Path class
    /// </summary>
    public static class PathExtensions
    {
        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration)
        {
            return paths.Concat(new[] { new Path(paths.Last().End, end, duration) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path(paths.Last().End, end, duration, function) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration, ulong delay)
        {
            return paths.Concat(new[] { new Path(paths.Last().End, end, duration, delay) }).ToArray();
        }

        /// <summary>
        ///     Continue the last paths with a new one
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path[] paths, float end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return paths.Concat(new[] { new Path(paths.Last().End, end, duration, delay, function) }).ToArray();
        }


        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path path, float end, ulong duration)
        {
            return path.ToArray().ContinueTo(end, duration);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path path, float end, ulong duration, AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, function);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path path, float end, ulong duration, ulong delay)
        {
            return path.ToArray().ContinueTo(end, duration, delay);
        }

        /// <summary>
        ///     Continue the path with a new one
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="end">Next point to follow</param>
        /// <param name="duration">Duration of the animation</param>
        /// <param name="delay">Starting delay</param>
        /// <param name="function">Animation controller function</param>
        /// <returns>An array of paths including the newly created one</returns>
        public static Path[] ContinueTo(this Path path, float end, ulong duration, ulong delay,
            AnimationFunctions.Function function)
        {
            return path.ToArray().ContinueTo(end, duration, delay, function);
        }


        /// <summary>
        ///     Continue the path array with a new ones
        /// </summary>
        /// <param name="paths">Array of paths</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path[] ContinueTo(this Path[] paths, params Path[] newPaths)
        {
            return paths.Concat(newPaths).ToArray();
        }

        /// <summary>
        ///     Continue the path with a new ones
        /// </summary>
        /// <param name="path">The path to continue</param>
        /// <param name="newPaths">An array of new paths to adds</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path[] ContinueTo(this Path path, params Path[] newPaths)
        {
            return path.ToArray().ContinueTo(newPaths);
        }

        /// <summary>
        ///     Contains a single path in an array
        /// </summary>
        /// <param name="path">The path to add to the array</param>
        /// <returns>An array of paths including the new ones</returns>
        public static Path[] ToArray(this Path path)
        {
            return new[] { path };
        }
    }
    #endregion
    #region SafeInvoker
    /// <summary>
    ///     The safe invoker class is a delegate reference holder that always
    ///     execute them in the correct thread based on the passed control.
    /// </summary>
    public class SafeInvoker
    {
        private MethodInfo _invokeMethod;

        private PropertyInfo _invokeRequiredProperty;
        private object _targetControl;

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        /// <param name="targetControl">
        ///     The control to be used to invoke the callback in UI thread
        /// </param>
        public SafeInvoker(Action action, object targetControl)
            : this((Delegate)action, targetControl)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        /// <param name="targetControl">
        ///     The control to be used to invoke the callback in UI thread
        /// </param>
        protected SafeInvoker(Delegate action, object targetControl)
        {
            UnderlyingDelegate = action;
            if (targetControl != null)
            {
                TargetControl = targetControl;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        public SafeInvoker(Action action)
            : this(action, null)
        {
        }

        /// <summary>
        ///     Gets or sets the reference to the control thats going to be used to invoke the callback in UI thread
        /// </summary>
        protected object TargetControl
        {
            get { return _targetControl; }
            set
            {
                _invokeRequiredProperty = value.GetType()
                    .GetProperty("InvokeRequired", BindingFlags.Instance | BindingFlags.Public);
                _invokeMethod = value.GetType()
                    .GetMethod(
                        "Invoke",
                        BindingFlags.Instance | BindingFlags.Public,
                        Type.DefaultBinder,
                        new[] { typeof(Delegate) },
                        null);
                if (_invokeRequiredProperty != null && _invokeMethod != null)
                {
                    _targetControl = value;
                }
            }
        }


        /// <summary>
        ///     Gets the reference to the callback to be invoked
        /// </summary>
        protected Delegate UnderlyingDelegate { get; set; }

        /// <summary>
        ///     Invoke the contained callback
        /// </summary>
        public virtual void Invoke()
        {
            Invoke(null);
        }

        /// <summary>
        ///     Invoke the referenced callback
        /// </summary>
        /// <param name="value">The argument to send to the callback</param>
        protected void Invoke(object value)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(
                    state =>
                    {
                        if (TargetControl != null && (bool)_invokeRequiredProperty.GetValue(TargetControl, null))
                        {
                            _invokeMethod.Invoke(
                                TargetControl,
                                new object[]
                                {
                                    new Action(
                                        () => UnderlyingDelegate.DynamicInvoke(value != null ? new[] {value} : null))
                                });
                            return;
                        }
                        UnderlyingDelegate.DynamicInvoke(value != null ? new[] { value } : null);
                    });
            }
            catch
            {
                // ignored
            }
        }
    }
    #endregion
    #region SafeInvoker<T>
    /// <summary>
    ///     The safe invoker class is a delegate reference holder that always
    ///     execute them in the correct thread based on the passed control.
    /// </summary>
    public class SafeInvoker<T> : SafeInvoker
    {
        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        /// <param name="targetControl">
        ///     The control to be used to invoke the callback in UI thread
        /// </param>
        public SafeInvoker(Action<T> action, object targetControl)
            : base(action, targetControl)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">
        ///     The callback to be invoked
        /// </param>
        public SafeInvoker(Action<T> action)
            : this(action, null)
        {
        }

        /// <summary>
        ///     Invoke the contained callback with the specified value as the parameter
        /// </summary>
        /// <param name="value"></param>
        public void Invoke(T value)
        {
            Invoke((object)value);
        }
    }
    #endregion
    #region Timer
    /// <summary>
    ///     The timer class, will execute your code in specific time frames
    /// </summary>
    public class Timer
    {
        private static Thread _timerThread;

        private static readonly object LockHandle = new object();

        private static readonly long StartTimeAsMs = DateTime.Now.Ticks;

        private static readonly List<Timer> Subscribers = new List<Timer>();

        private readonly Action<ulong> _callback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Timer" /> class.
        /// </summary>
        /// <param name="callback">
        ///     The callback to be executed at each tick
        /// </param>
        /// <param name="fpsKnownLimit">
        ///     The max ticks per second
        /// </param>
        public Timer(Action<ulong> callback, FPSLimiterKnownValues fpsKnownLimit = FPSLimiterKnownValues.LimitThirty)
            : this(callback, (int)fpsKnownLimit)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Timer" /> class.
        /// </summary>
        /// <param name="callback">
        ///     The callback to be executed at each tick
        /// </param>
        /// <param name="fpsLimit">
        ///     The max ticks per second
        /// </param>
        public Timer(Action<ulong> callback, int fpsLimit)
        {
            if (callback == null)
            {
                throw new ArgumentNullException();
            }

            _callback = callback;
            FrameLimiter = fpsLimit;
            lock (LockHandle)
            {
                if (_timerThread == null)
                {
                    (_timerThread = new Thread(ThreadCycle) { IsBackground = true }).Start();
                }
            }
        }

        /// <summary>
        ///     Gets the time of the last frame/tick related to the global-timer start reference
        /// </summary>
        public long LastTick { get; private set; }

        /// <summary>
        ///     Gets or sets the maximum frames/ticks per second
        /// </summary>
        public int FrameLimiter { get; set; }

        /// <summary>
        ///     Gets the time of the first frame/tick related to the global-timer start reference
        /// </summary>
        public long FirstTick { get; private set; }


        private void Tick()
        {
            if ((1000 / FrameLimiter) < (GetTimeDifferenceAsMs() - LastTick))
            {
                LastTick = GetTimeDifferenceAsMs();
                _callback((ulong)(LastTick - FirstTick));
            }
        }

        private static long GetTimeDifferenceAsMs()
        {
            return (DateTime.Now.Ticks - StartTimeAsMs) / 10000;
        }

        private static void ThreadCycle()
        {
            while (true)
            {
                try
                {
                    bool hibernate;
                    lock (Subscribers)
                    {
                        hibernate = Subscribers.Count == 0;
                        if (!hibernate)
                        {
                            foreach (var t in Subscribers.ToList())
                            {
                                t.Tick();
                            }
                        }
                    }

                    Thread.Sleep(hibernate ? 50 : 1);
                }
                catch
                {
                    // ignored
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        ///     The method to reset the time of the starting frame/tick
        /// </summary>
        public void ResetClock()
        {
            FirstTick = GetTimeDifferenceAsMs();
        }

        /// <summary>
        ///     The method to resume the timer after stopping it
        /// </summary>
        public void Resume()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick += GetTimeDifferenceAsMs() - LastTick;
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        ///     The method to start the timer from the beginning
        /// </summary>
        public void Start()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    FirstTick = GetTimeDifferenceAsMs();
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        ///     The method to stop the timer from generating any new ticks/frames
        /// </summary>
        public void Stop()
        {
            lock (Subscribers)
                if (Subscribers.Contains(this))
                {
                    Subscribers.Remove(this);
                }
        }
    }
    #endregion
    #region Key

    #endregion
    #region Key

    #endregion
    #region Key

    #endregion
    #region Key

    #endregion
    #region Key

    #endregion

    #endregion
    #region Falahati Circular ProgressBar

    /// <summary>
    ///     The circular progress bar windows form control
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ZeroitProgressBarAwesome), "CircularProgressBar.bmp")]
    [DefaultBindingProperty("Value")]
    public class ZeroitProgressBarAwesome : ProgressBar
    {

        #region Zeroit Additions
            private int outerMargin = -25;
            private int outerWidth = 26;
            private Color outerColor = Color.Gray;

            private int progressWidth = 25;
            private Color progressColor = Color.FromArgb(156, 39, 176);

            private int innerMargin = 2;
            private int innerWidth = -1;
            private Color innerColor = Color.FromArgb(224, 224, 224);

        #endregion
        private readonly Animator _animator;
        private int? _animatedStartAngle;

        private float? _animatedValue;

        private AnimationFunctions.Function _animationFunction;

        private Brush _backBrush;

        private KnownAnimationFunctions _knownAnimationFunction;

        private ProgressBarStyle? _lastStyle;

        private int _lastValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircularProgressBar" /> class.
        /// </summary>
        public ZeroitProgressBarAwesome()
        {
            SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            _animator = DesignMode ? null : new Animator();
            AnimationFunction = KnownAnimationFunctions.Liner;
            AnimationSpeed = 500;
            MarqueeAnimationSpeed = 2000;
            StartAngle = 270;

            _lastValue = Value;

            // Child class should be responsible for handling this values at the constructor
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(64, 64, 64);
            DoubleBuffered = true;
            Font = new Font(Font.FontFamily, 20, FontStyle.Bold);
            SecondaryFont = new Font(Font.FontFamily, (float)(Font.Size * .7), FontStyle.Regular);
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            //OuterMargin = -25;
            //OuterWidth = 26;
            //OuterColor = Color.Gray;

            //ProgressWidth = 25;
            //ProgressColor = Color.FromArgb(156, 39, 176);

            //InnerMargin = 2;
            //InnerWidth = -1;
            //InnerColor = Color.FromArgb(224, 224, 224);

            TextMargin = new Padding(8, 8, 0, 0);
            Value = 0;

            SuperscriptMargin = new Padding(10, 35, 0, 0);
            SuperscriptColor = Color.FromArgb(166, 166, 166);
            SuperscriptText = "°C";

            SubscriptMargin = new Padding(10, -35, 0, 0);
            SubscriptColor = Color.FromArgb(166, 166, 166);
            SubscriptText = ".23";

            Size = new Size(200, 200);
        }

        /// <summary>
        ///     Gets or sets the font of text in the <see cref="CircularProgressBar" />.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Drawing.Font" /> of the text. The default is the font set by the container.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Gets or sets the text in the <see cref="CircularProgressBar" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        ///     Sets a known animation function.
        /// </summary>
        [Category("Behavior")]
        public KnownAnimationFunctions AnimationFunction
        {
            get { return _knownAnimationFunction; }
            set
            {
                _animationFunction = AnimationFunctions.FromKnown(value);
                _knownAnimationFunction = value;
            }
        }

        /// <summary>
        ///     Sets a custom animation function.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public AnimationFunctions.Function CustomAnimationFunction
        {
            private get { return _animationFunction; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _knownAnimationFunction = KnownAnimationFunctions.None;
                _animationFunction = value;
            }
        }

        /// <summary>
        ///     Gets or sets the animation speed in milliseconds.
        /// </summary>
        [Category("Behavior")]
        public int AnimationSpeed { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding TextMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SuperscriptMargin { get; set; }


        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SubscriptMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color InnerColor
        {
            get { return innerColor; }
            set
            {
                innerColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerMargin
        {
            get { return innerMargin; }
            set
            {
                innerMargin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerWidth
        {
            get { return innerWidth; }
            set
            {
                innerWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color OuterColor
        {
            get { return outerColor; }
            set
            {
                outerColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterMargin
        {
            get { return outerMargin; }
            set
            {
                outerMargin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterWidth
        {
            get { return outerWidth; }
            set
            {
                outerWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color ProgressColor { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int StartAngle { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int ProgressWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SubscriptText { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SubscriptColor { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Font SecondaryFont { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SuperscriptText { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SuperscriptColor { get; set; }

        /// <inheritdoc />
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Invalidate();
        }

        /// <inheritdoc />
        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
            Invalidate();
        }

        /// <inheritdoc />
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidated -= ParentOnInvalidated;
                Parent.Resize -= ParentOnResize;
            }
            base.OnParentChanged(e);
            if (Parent != null)
            {
                Parent.Invalidated += ParentOnInvalidated;
                Parent.Resize += ParentOnResize;
            }
        }

        /// <summary>
        ///     Occurs when parent's display requires redrawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="invalidateEventArgs"></param>
        protected virtual void ParentOnInvalidated(object sender, InvalidateEventArgs invalidateEventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Occurs when the parent resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected virtual void ParentOnResize(object sender, EventArgs eventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Update or create the brush used for drawing the background
        /// </summary>
        protected virtual void RecreateBackgroundBrush()
        {
            lock (this)
            {
                _backBrush?.Dispose();
                _backBrush = new SolidBrush(BackColor);
                if (BackColor.A == 255)
                    return;
                if (Parent != null)
                    using (var parentImage = new Bitmap(Parent.Width, Parent.Height))
                    {
                        using (var parentGraphic = Graphics.FromImage(parentImage))
                        {
                            var pe = new PaintEventArgs(parentGraphic, new Rectangle(new Point(0, 0), parentImage.Size));
                            InvokePaintBackground(Parent, pe);
                            InvokePaint(Parent, pe);

                            if (BackColor.A > 0) // Translucent
                                parentGraphic.FillRectangle(_backBrush, Bounds);
                        }
                        _backBrush = new TextureBrush(parentImage);
                        ((TextureBrush)_backBrush).TranslateTransform(-Bounds.X, -Bounds.Y);
                    }
                else
                    _backBrush = new SolidBrush(Color.FromArgb(255, BackColor));
            }
        }

        /// <inheritdoc />
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }

        /// <inheritdoc />
        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (Style == ProgressBarStyle.Marquee)
                        InitializeMarquee(_lastStyle != Style);
                    else
                        InitializeContinues(_lastStyle != Style);
                    _lastStyle = Style;
                }
                if (_backBrush == null)
                    RecreateBackgroundBrush();
                StartPaint(e.Graphics);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        ///     Initialize the animation for the continues styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeContinues(bool firstTime)
        {
            if ((_lastValue == Value) && !firstTime)
                return;

            _lastValue = Value;

            _animator.Stop();
            _animator.Paths =
                new Path(_animatedValue ?? Value, Value, (ulong)AnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = false;
            _animatedStartAngle = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedValue = v;
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     Initialize the animation for the marquee styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeMarquee(bool firstTime)
        {
            if (!firstTime &&
                ((_animator.ActivePath == null) ||
                 ((_animator.ActivePath.Duration == (ulong)MarqueeAnimationSpeed) &&
                  (_animator.ActivePath.Function == CustomAnimationFunction))))
                return;

            _animator.Stop();
            _animator.Paths = new Path(0, 359, (ulong)MarqueeAnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = true;
            _animatedValue = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedStartAngle = (int)(v % 360);
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     The function responsible for painting the control
        /// </summary>
        /// <param name="g">The <see cref="Graphics" /> object to draw into</param>
        protected virtual void StartPaint(Graphics g)
        {
            try
            {
                lock (this)
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    var point = AddPoint(Point.Empty, 2);
                    var size = AddSize(Size, -2 * 2);
                    if (OuterWidth + OuterMargin < 0)
                    {
                        var offset = Math.Abs(OuterWidth + OuterMargin);
                        point = AddPoint(Point.Empty, offset);
                        size = AddSize(Size, -2 * offset);
                    }

                    if ((OuterColor != Color.Empty) && (OuterColor != Color.Transparent) && (OuterWidth != 0))
                    {
                        g.FillEllipse(new SolidBrush(OuterColor), new RectangleF(point, size));
                        if (OuterWidth >= 0)
                        {
                            point = AddPoint(point, OuterWidth);
                            size = AddSize(size, -2 * OuterWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    point = AddPoint(point, OuterMargin);
                    size = AddSize(size, -2 * OuterMargin);

                    g.FillPie(
                        new SolidBrush(ProgressColor),
                        ToRectangle(new RectangleF(point, size)),
                        _animatedStartAngle ?? StartAngle,
                        (_animatedValue ?? Value) / (Maximum - Minimum) * 360);
                    if (ProgressWidth >= 0)
                    {
                        point = AddPoint(point, ProgressWidth);
                        size = AddSize(size, -2 * ProgressWidth);
                        g.FillEllipse(_backBrush, new RectangleF(point, size));
                    }

                    point = AddPoint(point, InnerMargin);
                    size = AddSize(size, -2 * InnerMargin);

                    if ((InnerColor != Color.Empty) && (InnerColor != Color.Transparent) && (InnerWidth != 0))
                    {
                        g.FillEllipse(new SolidBrush(InnerColor), new RectangleF(point, size));
                        if (InnerWidth >= 0)
                        {
                            point = AddPoint(point, InnerWidth);
                            size = AddSize(size, -2 * InnerWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    if (Text == string.Empty)
                        return;

                    point.X += TextMargin.Left;
                    point.Y += TextMargin.Top;
                    size.Width -= TextMargin.Right;
                    size.Height -= TextMargin.Bottom;
                    var stringFormat =
                        new StringFormat(RightToLeft == RightToLeft.Yes ? StringFormatFlags.DirectionRightToLeft : 0)
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Near
                        };
                    var textSize = g.MeasureString(Text, Font);
                    var textPoint = new PointF(
                        point.X + (size.Width - textSize.Width) / 2,
                        point.Y + (size.Height - textSize.Height) / 2);
                    if ((SubscriptText != string.Empty) || (SuperscriptText != string.Empty))
                    {
                        float maxSWidth = 0;
                        var supSize = SizeF.Empty;
                        var subSize = SizeF.Empty;
                        if (SuperscriptText != string.Empty)
                        {
                            supSize = g.MeasureString(SuperscriptText, SecondaryFont);
                            maxSWidth = Math.Max(supSize.Width, maxSWidth);
                            supSize.Width -= SuperscriptMargin.Right;
                            supSize.Height -= SuperscriptMargin.Bottom;
                        }

                        if (SubscriptText != string.Empty)
                        {
                            subSize = g.MeasureString(SubscriptText, SecondaryFont);
                            maxSWidth = Math.Max(subSize.Width, maxSWidth);
                            subSize.Width -= SubscriptMargin.Right;
                            subSize.Height -= SubscriptMargin.Bottom;
                        }

                        textPoint.X -= maxSWidth / 4;
                        if (SuperscriptText != string.Empty)
                        {
                            var supPoint = new PointF(
                                textPoint.X + textSize.Width - supSize.Width / 2,
                                textPoint.Y - supSize.Height * 0.85f);
                            supPoint.X += SuperscriptMargin.Left;
                            supPoint.Y += SuperscriptMargin.Top;
                            g.DrawString(
                                SuperscriptText,
                                SecondaryFont,
                                new SolidBrush(SuperscriptColor),
                                new RectangleF(supPoint, supSize),
                                stringFormat);
                        }

                        if (SubscriptText != string.Empty)
                        {
                            var subPoint = new PointF(
                                textPoint.X + textSize.Width - subSize.Width / 2,
                                textPoint.Y + textSize.Height * 0.85f);
                            subPoint.X += SubscriptMargin.Left;
                            subPoint.Y += SubscriptMargin.Top;
                            g.DrawString(
                                SubscriptText,
                                SecondaryFont,
                                new SolidBrush(SubscriptColor),
                                new RectangleF(subPoint, subSize),
                                stringFormat);
                        }
                    }

                    g.DrawString(
                        Text,
                        Font,
                        new SolidBrush(ForeColor),
                        new RectangleF(textPoint, textSize),
                        stringFormat);
                }
            }
            catch
            {
                // ignored
            }
        }

        private static PointF AddPoint(PointF p, int v)
        {
            p.X += v;
            p.Y += v;
            return p;
        }

        private static SizeF AddSize(SizeF s, int v)
        {
            s.Height += v;
            s.Width += v;
            return s;
        }

        private static Rectangle ToRectangle(RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }
    #endregion


}
