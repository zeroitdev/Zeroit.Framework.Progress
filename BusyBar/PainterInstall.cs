// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterInstall.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Imports

using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterInstall
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterPathGradient

    /// <summary>
    /// Class ZeroitBusyBarPainterInstall.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterInstall.bmp")]
    public class ZeroitBusyBarPainterInstall : ZeroitBusyBarPainterBase
    {
        /// <summary>
        /// Enum representing the Presets
        /// </summary>
        public enum Presets
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The install
            /// </summary>
            Install,
            /// <summary>
            /// The led
            /// </summary>
            LED,
        }

        /// <summary>
        /// Enum representing the Shapes
        /// </summary>
        public enum Shapes
        {
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            //			Diamond,
            /// <summary>
            /// The ellipse
            /// </summary>
            Ellipse,
        }

        /// <summary>
        /// The default block count
        /// </summary>
        private const int _DefaultBlockCount = 6;

        /// <summary>
        /// The default back block height
        /// </summary>
        private const int _DefaultBackBlockHeight = 8;
        /// <summary>
        /// The default back block width
        /// </summary>
        private const int _DefaultBackBlockWidth = 8;
        /// <summary>
        /// The default back color
        /// </summary>
        private static readonly Color _DefaultBackColor = Color.Green;
        /// <summary>
        /// The default back outline color
        /// </summary>
        private static readonly Color _DefaultBackOutlineColor = Color.Silver;
        /// <summary>
        /// The default back outline width
        /// </summary>
        private const int _DefaultBackOutlineWidth = 1;
        /// <summary>
        /// The default back shape
        /// </summary>
        private const Shapes _DefaultBackShape = Shapes.Rectangle;

        /// <summary>
        /// The default fore block height
        /// </summary>
        private const int _DefaultForeBlockHeight = 12;
        /// <summary>
        /// The default fore block width
        /// </summary>
        private const int _DefaultForeBlockWidth = 12;
        /// <summary>
        /// The default fore color
        /// </summary>
        private static readonly Color _DefaultForeColor = Color.Empty;
        /// <summary>
        /// The default fore outline color
        /// </summary>
        private static readonly Color _DefaultForeOutlineColor = Color.White;
        /// <summary>
        /// The default fore outline width
        /// </summary>
        private const int _DefaultForeOutlineWidth = 1;
        /// <summary>
        /// The default fore shape
        /// </summary>
        private const Shapes _DefaultForeShape = Shapes.Rectangle;


        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;

        /// <summary>
        /// The block count
        /// </summary>
        private int _BlockCount = _DefaultBlockCount;

        /// <summary>
        /// The back block height
        /// </summary>
        private int _BackBlockHeight = _DefaultBackBlockHeight;
        /// <summary>
        /// The back block width
        /// </summary>
        private int _BackBlockWidth = _DefaultBackBlockWidth;
        /// <summary>
        /// The back color
        /// </summary>
        private Color _BackColor = _DefaultBackColor;
        /// <summary>
        /// The back outline color
        /// </summary>
        private Color _BackOutlineColor = _DefaultBackOutlineColor;
        /// <summary>
        /// The back outline width
        /// </summary>
        private int _BackOutlineWidth = _DefaultBackOutlineWidth;
        /// <summary>
        /// The back shape
        /// </summary>
        private Shapes _BackShape = _DefaultBackShape;

        /// <summary>
        /// The fore block height
        /// </summary>
        private int _ForeBlockHeight = _DefaultForeBlockHeight;
        /// <summary>
        /// The fore block width
        /// </summary>
        private int _ForeBlockWidth = _DefaultForeBlockWidth;
        /// <summary>
        /// The fore color
        /// </summary>
        private Color _ForeColor = _DefaultForeColor;
        /// <summary>
        /// The fore outline color
        /// </summary>
        private Color _ForeOutlineColor = _DefaultForeOutlineColor;
        /// <summary>
        /// The fore outline width
        /// </summary>
        private int _ForeOutlineWidth = _DefaultForeOutlineWidth;
        /// <summary>
        /// The fore shape
        /// </summary>
        private Shapes _ForeShape = _DefaultForeShape;

        /// <summary>
        /// Gets or sets the preset.
        /// </summary>
        /// <value>The preset.</value>
        [Category("1.Presets")]
        [DefaultValue(Presets.None)]
        [Description("Preset settings")]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Presets Preset
        {
            get { return _Preset; }

            set
            {
                _Preset = value;

                SetFromPreset(true);

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the block count.
        /// </summary>
        /// <value>The block count.</value>
        [Category("2.Blocks")]
        [DefaultValue(_DefaultBlockCount)]
        [Description("The number of blocks")]
        public int BlockCount
        {
            get { return _BlockCount; }

            set
            {
                _BlockCount = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the back block.
        /// </summary>
        /// <value>The height of the back block.</value>
        [Category("3.BackBlocks")]
        [DefaultValue(_DefaultBackBlockHeight)]
        [Description("The height of the back blocks")]
        public int BackBlockHeight
        {
            get { return _BackBlockHeight; }

            set
            {
                _BackBlockHeight = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the back block.
        /// </summary>
        /// <value>The width of the back block.</value>
        [Category("3.BackBlocks")]
        [DefaultValue(_DefaultBackBlockWidth)]
        [Description("The width of the back blocks")]
        public int BackBlockWidth
        {
            get { return _BackBlockWidth; }

            set
            {
                _BackBlockWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("3.BackBlocks")]
        //		[ DefaultValue( _DefaultBackColor ) ]
        [Description("The color of the back blocks")]
        public Color BackColor
        {
            get { return _BackColor; }

            set
            {
                _BackColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the back outline.
        /// </summary>
        /// <value>The color of the back outline.</value>
        [Category("3.BackBlocks")]
        //		[ DefaultValue( _DefaultBackOutlineColor ) ]
        [Description("The color of the back outline")]
        public Color BackOutlineColor
        {
            get { return _BackOutlineColor; }

            set
            {
                _BackOutlineColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the back outline.
        /// </summary>
        /// <value>The width of the back outline.</value>
        [Category("3.BackBlocks")]
        [DefaultValue(_DefaultBackOutlineWidth)]
        [Description("The width of the back outline")]
        public int BackOutlineWidth
        {
            get { return _BackOutlineWidth; }

            set
            {
                _BackOutlineWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the back shape.
        /// </summary>
        /// <value>The back shape.</value>
        [Category("3.BackBlocks")]
        [DefaultValue(_DefaultBackShape)]
        [Description("The shape of the back blocks")]
        public Shapes BackShape
        {
            get { return _BackShape; }

            set
            {
                _BackShape = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the fore block.
        /// </summary>
        /// <value>The height of the fore block.</value>
        [Category("4.ForeBlocks")]
        [DefaultValue(_DefaultForeBlockHeight)]
        [Description("The height of the fore blocks")]
        public int ForeBlockHeight
        {
            get { return _ForeBlockHeight; }

            set
            {
                _ForeBlockHeight = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the fore block.
        /// </summary>
        /// <value>The width of the fore block.</value>
        [Category("4.ForeBlocks")]
        [DefaultValue(_DefaultForeBlockWidth)]
        [Description("The width of the fore blocks")]
        public int ForeBlockWidth
        {
            get { return _ForeBlockWidth; }

            set
            {
                _ForeBlockWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Category("4.ForeBlocks")]
        //		[ DefaultValue( _DefaultForeColor ) ]
        [Description("The color of the fore blocks")]
        public Color ForeColor
        {
            get { return _ForeColor; }

            set
            {
                _ForeColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore outline.
        /// </summary>
        /// <value>The color of the fore outline.</value>
        [Category("4.ForeBlocks")]
        //		[ DefaultValue( _DefaultForeOutlineColor ) ]
        [Description("The color of the fore outline")]
        public Color ForeOutlineColor
        {
            get { return _ForeOutlineColor; }

            set
            {
                _ForeOutlineColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the fore outline.
        /// </summary>
        /// <value>The width of the fore outline.</value>
        [Category("4.ForeBlocks")]
        [DefaultValue(_DefaultForeOutlineWidth)]
        [Description("The width of the fore outline")]
        public int ForeOutlineWidth
        {
            get { return _ForeOutlineWidth; }

            set
            {
                _ForeOutlineWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the fore shape.
        /// </summary>
        /// <value>The fore shape.</value>
        [Category("4.ForeBlocks")]
        [DefaultValue(_DefaultForeShape)]
        [Description("The shape of the fore blocks")]
        public Shapes ForeShape
        {
            get { return _ForeShape; }

            set
            {
                _ForeShape = value;
                if (Bar != null) Bar.Invalidate();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterInstall"/> class.
        /// </summary>
        public ZeroitBusyBarPainterInstall() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterInstall"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterInstall(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterInstall"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterInstall(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterInstall"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterInstall(ZeroitBusyBarPainterInstall o) : base(o)
        {
            //			OnBarSet();

            CopyThis(o);
        }

        /// <summary>
        /// Copies the specified o.
        /// </summary>
        /// <param name="o">The o.</param>
        public override void Copy(ZeroitBusyBarPainterBase o)
        {
            base.Copy(o);

            if (!(o is ZeroitBusyBarPainterInstall)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterInstall)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterInstall o)
        {
            _Preset = o._Preset;

            _BlockCount = o._BlockCount;

            _BackBlockHeight = o._BackBlockHeight;
            _BackBlockWidth = o._BackBlockWidth;
            _BackColor = o._BackColor;
            _BackOutlineColor = o._BackOutlineColor;
            _BackOutlineWidth = o._BackOutlineWidth;
            _BackShape = o._BackShape;

            _ForeBlockHeight = o._ForeBlockHeight;
            _ForeBlockWidth = o._ForeBlockWidth;
            _ForeColor = o._ForeColor;
            _ForeOutlineColor = o._ForeOutlineColor;
            _ForeOutlineWidth = o._ForeOutlineWidth;
            _ForeShape = o._ForeShape;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterInstall(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            if (_ForeColor == Color.Empty) _ForeColor = Bar.ForeColor;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        protected override void SetDefaults(bool setBarDefaults)
        {
            base.SetDefaults(setBarDefaults);

            _BlockCount = _DefaultBlockCount;

            _BackBlockHeight = _DefaultBackBlockHeight;
            _BackBlockWidth = _DefaultBackBlockWidth;
            _BackColor = _DefaultBackColor;
            _BackOutlineColor = _DefaultBackOutlineColor;
            _BackOutlineWidth = _DefaultBackOutlineWidth;
            _BackShape = _DefaultBackShape;


            _ForeBlockHeight = _DefaultForeBlockHeight;
            _ForeBlockWidth = _DefaultForeBlockWidth;
            _ForeColor = _DefaultForeColor;
            _ForeOutlineColor = _DefaultForeOutlineColor;
            _ForeOutlineWidth = _DefaultForeOutlineWidth;
            _ForeShape = _DefaultForeShape;

            if (Bar != null)
            {
                _ForeColor = Bar.ForeColor;
            }
        }

        /// <summary>
        /// Sets from preset.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        private void SetFromPreset(bool setBarDefaults)
        {
            switch (_Preset)
            {
                case Presets.None:

                    SetDefaults(setBarDefaults);

                    break;

                case Presets.Install:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.BorderStyle = BorderStyle.None;
                        Bar.Margin = 2;

                        Bar.Maximum = 500;
                    }

                    _BlockCount = 5;

                    _ForeColor = Color.Lime;

                    break;

                case Presets.LED:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = SystemColors.Control;

                        Bar.BorderStyle = BorderStyle.None;

                        //					Bar.Maximum = 300;

                        Bar.Bounce = true;
                        Bar.Pin = ZeroitBusyBar.Pins.Start;
                    }

                    _BackBlockHeight = 12;
                    _BackBlockWidth = 16;
                    _BackColor = Color.DarkBlue;
                    _BackOutlineColor = Color.Gold;
                    _BackShape = Shapes.Ellipse;

                    _ForeBlockHeight = 8;
                    _ForeBlockWidth = 8;
                    _ForeColor = Color.Cyan;
                    _ForeOutlineWidth = 0;
                    _ForeShape = Shapes.Ellipse;

                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
        }

        /// <summary>
        /// Paints the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rClient">The r client.</param>
        public override void Paint(Graphics g, Region rClient)
        {
            base.Paint(g, rClient);

            if (!Bar.DrawBar) return;

            RectangleF bounds = rClient.GetBounds(g);
            float ratio = CalculateRatio();

            if (!Bar.Vertical)
            {
                float xPeriod = bounds.Width / BlockCount;
                float xOffset = bounds.Width * ratio;
                float xValue = bounds.Left + xOffset;
                float yMiddle = bounds.Top + (bounds.Height / 2);

                RectangleF r2 = bounds;
                r2.Inflate(xPeriod, 0);

                ZeroitBusyBarBlockLines blocks = new ZeroitBusyBarBlockLines();

                blocks.BlockWidth = xPeriod / 2f;
                blocks.BlockLineWidth = xPeriod / 2f;
                blocks.BlockScroll = false;
                blocks.Bounds = bounds;
                blocks.R1 = RectangleF.Empty;
                blocks.R2 = r2;
                blocks.R3 = RectangleF.Empty;
                blocks.XValue = 0;

                ArrayList lines = blocks.HorizontalLines;

                // back
                float xBackSpace = xPeriod - BackBlockWidth;

                RectangleF[] rectsBack = new RectangleF[lines.Count];

                int iRectBack = 0;
                foreach (float line in lines)
                {
                    rectsBack[iRectBack++] = new RectangleF(
                        line + (xBackSpace / 2f),
                        bounds.Top + ((bounds.Height - BackBlockHeight) / 2f),
                        BackBlockWidth,
                        BackBlockHeight);
                }

                if (BackOutlineWidth > 0)
                {
                    using (Brush brushBackOutline = new SolidBrush(BackOutlineColor))
                        if (_BackShape == Shapes.Rectangle)
                            g.FillRectangles(brushBackOutline, rectsBack);
                        else if (_BackShape == Shapes.Ellipse)
                            foreach (RectangleF rectBack in rectsBack)
                                g.FillEllipse(brushBackOutline, rectBack);
                        else Debug.Assert(false);

                    for (iRectBack = 0; iRectBack < rectsBack.Length; iRectBack++)
                        rectsBack[iRectBack].Inflate(-BackOutlineWidth, -BackOutlineWidth);
                }

                using (Brush brushBack = new SolidBrush(BackColor))
                    if (_BackShape == Shapes.Rectangle)
                        g.FillRectangles(brushBack, rectsBack);
                    else if (_BackShape == Shapes.Ellipse)
                        foreach (RectangleF rectBack in rectsBack)
                            g.FillEllipse(brushBack, rectBack);
                    else Debug.Assert(false);

                // fore
                float xForeSpace = xPeriod - ForeBlockWidth;

                RectangleF[] rectsFore = new RectangleF[lines.Count];

                int iRectFore = 0;
                foreach (float line in lines)
                {
                    rectsFore[iRectFore++] = new RectangleF(
                        line + (xForeSpace / 2f),
                        bounds.Top + ((bounds.Height - ForeBlockHeight) / 2f),
                        ForeBlockWidth,
                        ForeBlockHeight);
                }

                foreach (RectangleF rectFore in rectsFore)
                {
                    RectangleF rectBig = rectFore;
                    rectBig.Inflate(xForeSpace / 2f, 0);

                    if (rectBig.Contains(xValue, yMiddle))
                    {
                        float ratioFore = (xValue - rectBig.Left) / rectBig.Width;

                        int alpha = 255;

                        switch (Bar.Pin)
                        {
                            case ZeroitBusyBar.Pins.None:
                                if (ratioFore < 0.5) alpha = (int)(ratioFore * 255 * 2);
                                if (ratioFore > 0.5) alpha = (int)((1f - ratioFore) * 255 * 2);
                                break;

                            case ZeroitBusyBar.Pins.Start:
                                alpha = (int)(ratioFore * 255);
                                break;

                            case ZeroitBusyBar.Pins.End:
                                alpha = (int)((1f - ratioFore) * 255);
                                break;

                            default: Debug.Assert(false); break;
                        }

                        if (ForeOutlineWidth > 0)
                        {
                            using (Brush brushForeOutline = new SolidBrush(Color.FromArgb(alpha, ForeOutlineColor)))
                                if (_ForeShape == Shapes.Rectangle)
                                    g.FillRectangle(brushForeOutline, rectFore);
                                else if (_ForeShape == Shapes.Ellipse)
                                    g.FillEllipse(brushForeOutline, rectFore);
                                else Debug.Assert(false);

                            rectFore.Inflate(-ForeOutlineWidth, -ForeOutlineWidth);
                        }

                        using (Brush brushFore = new SolidBrush(Color.FromArgb(alpha, ForeColor)))
                            if (_ForeShape == Shapes.Rectangle)
                                g.FillRectangle(brushFore, rectFore);
                            else if (_ForeShape == Shapes.Ellipse)
                                g.FillEllipse(brushFore, rectFore);
                            else Debug.Assert(false);
                    }
                    else
                    {
                        if (
                            (xValue > rectFore.Right && Bar.Pin == ZeroitBusyBar.Pins.Start) ||
                            (xValue < rectFore.Left && Bar.Pin == ZeroitBusyBar.Pins.End))
                        {
                            if (ForeOutlineWidth > 0)
                            {
                                using (Brush brushForeOutline = new SolidBrush(ForeOutlineColor))
                                    if (_ForeShape == Shapes.Rectangle)
                                        g.FillRectangle(brushForeOutline, rectFore);
                                    else if (_ForeShape == Shapes.Ellipse)
                                        g.FillEllipse(brushForeOutline, rectFore);
                                    else Debug.Assert(false);

                                rectFore.Inflate(-ForeOutlineWidth, -ForeOutlineWidth);
                            }

                            using (Brush brushFore = new SolidBrush(ForeColor))
                                if (_ForeShape == Shapes.Rectangle)
                                    g.FillRectangle(brushFore, rectFore);
                                else if (_ForeShape == Shapes.Ellipse)
                                    g.FillEllipse(brushFore, rectFore);
                                else Debug.Assert(false);
                        }
                    }
                }
            }
            else // Vertical
            {
                float yPeriod = bounds.Height / BlockCount;
                float yOffset = bounds.Height * ratio;
                float yValue = bounds.Top + yOffset;
                float xMiddle = bounds.Left + (bounds.Width / 2f);

                RectangleF r2 = bounds;
                r2.Inflate(0, yPeriod);

                ZeroitBusyBarBlockLines blocks = new ZeroitBusyBarBlockLines();

                blocks.BlockWidth = yPeriod / 2f;
                blocks.BlockLineWidth = yPeriod / 2f;
                blocks.BlockScroll = false;
                blocks.Bounds = bounds;
                blocks.R1 = RectangleF.Empty;
                blocks.R2 = r2;
                blocks.R3 = RectangleF.Empty;
                blocks.XValue = 0;

                ArrayList lines = blocks.VerticalLines;

                // back
                float yBackSpace = yPeriod - BackBlockHeight;

                RectangleF[] rectsBack = new RectangleF[lines.Count];

                int iRectBack = 0;
                foreach (float line in lines)
                {
                    rectsBack[iRectBack++] = new RectangleF(
                        bounds.Left + ((bounds.Width - BackBlockWidth) / 2f),
                        line + (yBackSpace / 2f),
                        BackBlockWidth,
                        BackBlockHeight);
                }

                if (BackOutlineWidth > 0)
                {
                    using (Brush brushBackOutline = new SolidBrush(BackOutlineColor))
                        if (_BackShape == Shapes.Rectangle)
                            g.FillRectangles(brushBackOutline, rectsBack);
                        else if (_BackShape == Shapes.Ellipse)
                            foreach (RectangleF rectBack in rectsBack)
                                g.FillEllipse(brushBackOutline, rectBack);
                        else Debug.Assert(false);

                    for (iRectBack = 0; iRectBack < rectsBack.Length; iRectBack++)
                        rectsBack[iRectBack].Inflate(-BackOutlineWidth, -BackOutlineWidth);
                }

                using (Brush brushBack = new SolidBrush(BackColor))
                    if (_BackShape == Shapes.Rectangle)
                        g.FillRectangles(brushBack, rectsBack);
                    else if (_BackShape == Shapes.Ellipse)
                        foreach (RectangleF rectBack in rectsBack)
                            g.FillEllipse(brushBack, rectBack);
                    else Debug.Assert(false);

                // fore
                float yForeSpace = yPeriod - ForeBlockHeight;

                RectangleF[] rectsFore = new RectangleF[lines.Count];

                int iRectFore = 0;
                foreach (float line in lines)
                {
                    rectsFore[iRectFore++] = new RectangleF(
                        bounds.Left + ((bounds.Width - ForeBlockWidth) / 2f),
                        line + (yForeSpace / 2f),
                        ForeBlockWidth,
                        ForeBlockHeight);
                }

                foreach (RectangleF rectFore in rectsFore)
                {
                    RectangleF rectBig = rectFore;
                    rectBig.Inflate(0, yForeSpace / 2f);

                    if (rectBig.Contains(xMiddle, yValue))
                    {
                        float ratioFore = (yValue - rectBig.Top) / rectBig.Height;

                        int alpha = 255;

                        switch (Bar.Pin)
                        {
                            case ZeroitBusyBar.Pins.None:
                                if (ratioFore < 0.5) alpha = (int)(ratioFore * 255 * 2);
                                if (ratioFore > 0.5) alpha = (int)((1f - ratioFore) * 255 * 2);
                                break;

                            case ZeroitBusyBar.Pins.Start:
                                alpha = (int)(ratioFore * 255);
                                break;

                            case ZeroitBusyBar.Pins.End:
                                alpha = (int)((1f - ratioFore) * 255);
                                break;

                            default: Debug.Assert(false); break;
                        }

                        if (ForeOutlineWidth > 0)
                        {
                            using (Brush brushForeOutline = new SolidBrush(Color.FromArgb(alpha, ForeOutlineColor)))
                                if (_ForeShape == Shapes.Rectangle)
                                    g.FillRectangle(brushForeOutline, rectFore);
                                else if (_ForeShape == Shapes.Ellipse)
                                    g.FillEllipse(brushForeOutline, rectFore);
                                else Debug.Assert(false);

                            rectFore.Inflate(-ForeOutlineWidth, -ForeOutlineWidth);
                        }

                        using (Brush brushFore = new SolidBrush(Color.FromArgb(alpha, ForeColor)))
                            if (_ForeShape == Shapes.Rectangle)
                                g.FillRectangle(brushFore, rectFore);
                            else if (_ForeShape == Shapes.Ellipse)
                                g.FillEllipse(brushFore, rectFore);
                            else Debug.Assert(false);
                    }
                    else
                    {
                        if (
                            (yValue > rectFore.Bottom && Bar.Pin == ZeroitBusyBar.Pins.Start) ||
                            (yValue < rectFore.Top && Bar.Pin == ZeroitBusyBar.Pins.End))
                        {
                            if (ForeOutlineWidth > 0)
                            {
                                using (Brush brushForeOutline = new SolidBrush(ForeOutlineColor))
                                    if (_ForeShape == Shapes.Rectangle)
                                        g.FillRectangle(brushForeOutline, rectFore);
                                    else if (_ForeShape == Shapes.Ellipse)
                                        g.FillEllipse(brushForeOutline, rectFore);
                                    else Debug.Assert(false);

                                rectFore.Inflate(-ForeOutlineWidth, -ForeOutlineWidth);
                            }

                            using (Brush brushFore = new SolidBrush(ForeColor))
                                if (_ForeShape == Shapes.Rectangle)
                                    g.FillRectangle(brushFore, rectFore);
                                else if (_ForeShape == Shapes.Ellipse)
                                    g.FillEllipse(brushFore, rectFore);
                                else Debug.Assert(false);
                        }
                    }
                }
            }
        }
    }
    #endregion

}
