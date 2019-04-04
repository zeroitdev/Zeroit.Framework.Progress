// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterPathGradient.cs" company="Zeroit Dev Technologies">
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

using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterPathGradient
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterPathGradient

    /// <summary>
    /// Class ZeroitBusyBarPainterPathGradient.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBlockBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterPathGradient.bmp")]
    public class ZeroitBusyBarPainterPathGradient : ZeroitBusyBarPainterBlockBase
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
            /// The kitt
            /// </summary>
            Kitt,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The startup
            /// </summary>
            Startup,
            /// <summary>
            /// The noise
            /// </summary>
            Noise,
            /// <summary>
            /// The startup2003
            /// </summary>
            Startup2003,
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
            /// <summary>
            /// The diamond
            /// </summary>
            Diamond,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
        }

        /// <summary>
        /// The default shape
        /// </summary>
        private const Shapes _DefaultShape = Shapes.Rectangle;

        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;
        /// <summary>
        /// The shape
        /// </summary>
        private Shapes _Shape = _DefaultShape;

        /// <summary>
        /// The color centre
        /// </summary>
        private Color _ColorCentre = Color.Empty;
        /// <summary>
        /// The color corner
        /// </summary>
        private Color _ColorCorner = Color.Empty;
        /// <summary>
        /// The color vertical
        /// </summary>
        private Color _ColorVertical = Color.Empty;
        /// <summary>
        /// The color horizontal
        /// </summary>
        private Color _ColorHorizontal = Color.Empty;

        /// <summary>
        /// The wrap
        /// </summary>
        private bool _Wrap = false;

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
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        [Category("2.Shapes")]
        [DefaultValue(_DefaultShape)]
        [Description("The shape to draw")]
        public Shapes Shape
        {
            get { return _Shape; }

            set
            {
                _Shape = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color centre.
        /// </summary>
        /// <value>The color centre.</value>
        [Category("3.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color at the centre")]
        public Color ColorCentre
        {
            get { return _ColorCentre; }

            set
            {
                _ColorCentre = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color corner.
        /// </summary>
        /// <value>The color corner.</value>
        [Category("3.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color at the corners")]
        public Color ColorCorner
        {
            get { return _ColorCorner; }

            set
            {
                _ColorCorner = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color vertical.
        /// </summary>
        /// <value>The color vertical.</value>
        [Category("3.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color at the top and bottom")]
        public Color ColorVertical
        {
            get { return _ColorVertical; }

            set
            {
                _ColorVertical = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color horizontal.
        /// </summary>
        /// <value>The color horizontal.</value>
        [Category("3.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color at the left and right")]
        public Color ColorHorizontal
        {
            get { return _ColorHorizontal; }

            set
            {
                _ColorHorizontal = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterPathGradient"/> class.
        /// </summary>
        public ZeroitBusyBarPainterPathGradient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterPathGradient"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterPathGradient(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterPathGradient"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterPathGradient(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterPathGradient"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterPathGradient(ZeroitBusyBarPainterPathGradient o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterPathGradient)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterPathGradient)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterPathGradient o)
        {
            _Preset = o._Preset;

            _Shape = o._Shape;

            _ColorCentre = o._ColorCentre;
            _ColorCorner = o._ColorCorner;
            _ColorVertical = o._ColorVertical;
            _ColorHorizontal = o._ColorHorizontal;

            //			_Wrap             = o._Wrap            ;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterPathGradient(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            if (_ColorCentre == Color.Empty) _ColorCentre = Bar.ForeColor;
            if (_ColorCorner == Color.Empty) _ColorCorner = Bar.BackColor;
            if (_ColorHorizontal == Color.Empty) _ColorHorizontal = Bar.BackColor;
            if (_ColorVertical == Color.Empty) _ColorVertical = Bar.BackColor;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            _Wrap = Bar.WrapInitial;
        }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        protected override void SetDefaults(bool setBarDefaults)
        {
            base.SetDefaults(setBarDefaults);

            _Shape = _DefaultShape;

            _ColorCentre = Color.Empty;
            _ColorCorner = Color.Empty;
            _ColorHorizontal = Color.Empty;
            _ColorVertical = Color.Empty;

            if (Bar != null)
            {
                _ColorCentre = Bar.ForeColor;
                _ColorCorner = Bar.BackColor;
                _ColorHorizontal = Bar.BackColor;
                _ColorVertical = Bar.BackColor;
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

                case Presets.Kitt:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.Bounce = true;
                        Bar.Wrap = false;
                    }

                    BlockPercent = 100;
                    BlockSmooth = true;
                    BlockScroll = false;
                    BlockLineColor = Color.Black;
                    BlockLineWidth = 2;

                    _Shape = Shapes.Diamond;

                    _ColorCentre = Color.Red;
                    _ColorCorner = Color.Black;
                    _ColorHorizontal = Color.Black;
                    _ColorVertical = Color.Black;

                    break;

                case Presets.Circle:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.Bounce = true;
                        Bar.Wrap = false;
                    }

                    BlockPercent = 25;
                    BlockSmooth = true;
                    BlockLineWidth = 0;

                    _Shape = Shapes.Circle;

                    _ColorCentre = Color.Yellow;
                    _ColorCorner = Color.Black;

                    break;

                case Presets.Startup:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        //					Bar.BackColor = Color.White;
                    }

                    BlockPercent = 100;
                    BlockSmooth = true;
                    BlockLineWidth = 0;

                    _Shape = Shapes.Rectangle;

                    _ColorCentre = Color.RoyalBlue;
                    _ColorCorner = Color.White;
                    _ColorHorizontal = Color.White;
                    _ColorVertical = Color.RoyalBlue;

                    break;

                case Presets.Noise:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.Value = 5;
                        Bar.Maximum = 10;
                    }

                    BlockPercent = 80;
                    BlockSmooth = true;
                    BlockLineWidth = 0;

                    _Shape = Shapes.Rectangle;

                    _ColorCentre = Color.Silver;
                    _ColorVertical = _ColorCentre;

                    break;

                case Presets.Startup2003:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Orange;

                        Bar.BorderStyle = BorderStyle.None;
                        Bar.Margin = 0;
                    }

                    BlockPercent = 90;
                    BlockSmooth = true;
                    BlockLineWidth = 0;

                    _Shape = Shapes.Rectangle;

                    _ColorCentre = Color.Lime;
                    _ColorCorner = Color.Orange;
                    _ColorHorizontal = Color.Orange;
                    _ColorVertical = Color.Lime;

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
        /// <param name="r">The r.</param>
        public override void Paint(Graphics g, Region r)
        {
            base.Paint(g, r);

            if (!Bar.DrawBar) return;

            RectangleF bounds = r.GetBounds(g);
            float ratio = CalculateRatio();

            if (!Bar.Vertical)
            {
                float xOffset = bounds.Width * ratio;

                if (!BlockSmooth && Bar.Pin != ZeroitBusyBar.Pins.None)
                {
                    int xPeriod = BlockWidth + BlockLineWidth;
                    int xIntPeriods = (int)System.Math.Floor(bounds.Width / xPeriod);

                    float xWholeWidth = (1 + xIntPeriods) * xPeriod;
                    float xFudge = xWholeWidth / bounds.Width;

                    xOffset *= xFudge;
                }

                float xValue = bounds.Left + xOffset;
                float b = bounds.Width * BlockPercent / 100f;
                float xLeft = xValue - (b / 2);
                float xRight = xValue + (b / 2);
                float yMiddle = bounds.Top + (bounds.Height / 2);

                RectangleF r2 = RectangleF.Empty;
                RectangleF r1 = RectangleF.Empty;
                RectangleF r3 = RectangleF.Empty;

                switch (Bar.Pin)
                {
                    case ZeroitBusyBar.Pins.None:
                        {
                            r2 = new RectangleF(xLeft, bounds.Top, b, bounds.Height);
                            r1 = r2; r1.Offset(-bounds.Width, 0);
                            r3 = r2; r3.Offset(+bounds.Width, 0);
                            break;
                        }

                    case ZeroitBusyBar.Pins.Start:
                        {
                            r2 = new RectangleF(
                                bounds.Left,
                                bounds.Top,
                                xOffset,
                                bounds.Height);

                            break;
                        }

                    case ZeroitBusyBar.Pins.End:
                        {
                            r2 = new RectangleF(
                                xValue,
                                bounds.Top,
                                bounds.Width - xOffset,
                                bounds.Height);

                            break;
                        }

                    default:
                        Debug.Assert(false);
                        return;
                }

                if (r2.Width <= 0 || r2.Height <= 0) return;

                if (r2.Left > bounds.Left) _Wrap = Bar.Wrap;

                ZeroitBusyBarBlockLines blocks = new ZeroitBusyBarBlockLines();

                blocks.BlockWidth = BlockWidth;
                blocks.BlockLineWidth = BlockLineWidth;
                blocks.BlockScroll = BlockScroll;
                blocks.Bounds = bounds;
                blocks.R1 = r1;
                blocks.R2 = r2;
                blocks.R3 = r3;
                blocks.XValue = xValue;

                ArrayList lines = blocks.HorizontalLines;

                if (!BlockSmooth)
                {
                    r1.X = blocks.R1Left;
                    r2.X = blocks.R2Left;
                    r3.X = blocks.R3Left;

                    r1.Width = blocks.R1Right - r1.Left;
                    r2.Width = blocks.R2Right - r2.Left;
                    r3.Width = blocks.R3Right - r3.Left;

                    if (Bar.Pin == ZeroitBusyBar.Pins.Start && lines.Count > 0)
                    {
                        r2.X -= BlockWidth + BlockLineWidth;
                        r2.Width += BlockWidth + BlockLineWidth;
                    }

                    if (Bar.Pin == ZeroitBusyBar.Pins.End && lines.Count > 0)
                        r2.Width += BlockWidth + BlockLineWidth;
                }

                GraphicsPath path = null;
                Color[] colours = null;

                switch (_Shape)
                {
                    case Shapes.Rectangle:
                        {
                            PointF[] points = null;

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                points = new PointF[]
                                {
                            new PointF( xLeft, bounds.Top ),
                            new PointF( xValue, bounds.Top ),
                            new PointF( xRight, bounds.Top ),
                            new PointF( xRight, yMiddle ),
                            new PointF( xRight, bounds.Bottom ),
                            new PointF( xValue, bounds.Bottom ),
                            new PointF( xLeft, bounds.Bottom ),
                            new PointF( xLeft, yMiddle ),
                                };
                            }
                            else
                            {
                                if (r2.Width < 1) return;

                                float xMiddle = (r2.Left + r2.Right) / 2;

                                points = new PointF[]
                                {
                            new PointF( r2.Left, bounds.Top ),
                            new PointF( xMiddle, bounds.Top ),
                            new PointF( r2.Right, bounds.Top ),
                            new PointF( r2.Right, yMiddle ),
                            new PointF( r2.Right, bounds.Bottom ),
                            new PointF( xMiddle, bounds.Bottom ),
                            new PointF( r2.Left, bounds.Bottom ),
                            new PointF( r2.Left, yMiddle ),
                                };
                            }

                            path = new GraphicsPath();
                            path.AddLines(points);
                            path.CloseFigure();

                            colours = new Color[]
                            {
                        _ColorCorner,
                        _ColorVertical,
                        _ColorCorner,
                        _ColorHorizontal,
                        _ColorCorner,
                        _ColorVertical,
                        _ColorCorner,
                        _ColorHorizontal
                            };

                            break;
                        }

                    case Shapes.Diamond:
                        {
                            PointF[] points = null;

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                points = new PointF[]
                                {
                            new PointF( xValue, bounds.Top ),
                            new PointF( xRight, yMiddle ),
                            new PointF( xValue, bounds.Bottom ),
                            new PointF( xLeft, yMiddle ),
                                };
                            }
                            else
                            {
                                if (r2.Width < 1) return;

                                float xMiddle = (r2.Left + r2.Right) / 2;

                                points = new PointF[]
                                {
                            new PointF( xMiddle, bounds.Top ),
                            new PointF( r2.Right, yMiddle ),
                            new PointF( xMiddle, bounds.Bottom ),
                            new PointF( r2.Left, yMiddle ),
                                };
                            }
                            path = new GraphicsPath();
                            path.AddLines(points);
                            path.CloseFigure();

                            colours = new Color[]
                            {
                        _ColorVertical,
                        _ColorHorizontal,
                        _ColorVertical,
                        _ColorHorizontal
                            };

                            break;
                        }

                    case Shapes.Circle:
                        {
                            path = new GraphicsPath();

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                path.AddEllipse(xLeft, bounds.Top, b, bounds.Height);
                            }
                            else
                            {
                                if (r2.Width < 1) return;

                                path.AddEllipse(r2.Left, bounds.Top, r2.Width, bounds.Height);
                            }

                            colours = new Color[]
                            {
                        _ColorCorner,
                            };

                            break;
                        }

                    default:
                        Debug.Assert(false);
                        return;
                }

                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = _ColorCentre;
                    brush.SurroundColors = colours;

                    bool bOther = _Wrap && (Bar.Pin == ZeroitBusyBar.Pins.None);

                    if (bOther)
                    {
                        brush.TranslateTransform(-bounds.Width, 0);
                        g.FillRectangle(brush, r1);
                        brush.ResetTransform();
                    }

                    g.FillRectangle(brush, r2);

                    if (bOther)
                    {
                        brush.TranslateTransform(+bounds.Width, 0);
                        g.FillRectangle(brush, r3);
                        brush.ResetTransform();
                    }
                }

                if (BlockLineWidth > 0)
                    using (Pen pen2 = new Pen(BlockLineColor, BlockLineWidth))
                    {
                        foreach (float xLine in lines)
                            g.DrawLine(pen2, xLine, bounds.Top, xLine, bounds.Bottom);
                    }
            }
            // Vertical
            else
            {
                float yOffset = bounds.Height * ratio;

                if (!BlockSmooth && Bar.Pin != ZeroitBusyBar.Pins.None)
                {
                    int yPeriod = BlockWidth + BlockLineWidth;
                    int yIntPeriods = (int)System.Math.Floor(bounds.Height / yPeriod);

                    float yWholeWidth = (1 + yIntPeriods) * yPeriod;
                    float yFudge = yWholeWidth / bounds.Height;

                    yOffset *= yFudge;
                }

                float yValue = bounds.Top + yOffset;
                float b = bounds.Height * BlockPercent / 100f;
                float yTop = yValue - (b / 2);
                float yBottom = yValue + (b / 2);
                float xMiddle = bounds.Left + (bounds.Width / 2);

                RectangleF r2 = RectangleF.Empty;
                RectangleF r1 = RectangleF.Empty;
                RectangleF r3 = RectangleF.Empty;

                switch (Bar.Pin)
                {
                    case ZeroitBusyBar.Pins.None:
                        {
                            r2 = new RectangleF(bounds.Left, yTop, bounds.Width, b);
                            r1 = r2; r1.Offset(0, -bounds.Height);
                            r3 = r2; r3.Offset(0, +bounds.Height);
                            break;
                        }

                    case ZeroitBusyBar.Pins.Start:
                        {
                            r2 = new RectangleF(
                                bounds.Left,
                                bounds.Top,
                                bounds.Width,
                                yOffset);

                            break;
                        }

                    case ZeroitBusyBar.Pins.End:
                        {
                            r2 = new RectangleF(
                                bounds.Left,
                                yValue,
                                bounds.Width,
                                bounds.Height - yOffset);

                            break;
                        }

                    default:
                        Debug.Assert(false);
                        return;
                }

                if (r2.Width <= 0 || r2.Height <= 0) return;

                if (r2.Top > bounds.Top) _Wrap = Bar.Wrap;

                ZeroitBusyBarBlockLines blocks = new ZeroitBusyBarBlockLines();

                blocks.BlockWidth = BlockWidth;
                blocks.BlockLineWidth = BlockLineWidth;
                blocks.BlockScroll = BlockScroll;
                blocks.Bounds = bounds;
                blocks.R1 = r1;
                blocks.R2 = r2;
                blocks.R3 = r3;
                blocks.YValue = yValue;

                ArrayList lines = blocks.VerticalLines;

                if (!BlockSmooth)
                {
                    r1.Y = blocks.R1Top;
                    r2.Y = blocks.R2Top;
                    r3.Y = blocks.R3Top;

                    r1.Height = blocks.R1Bottom - r1.Top;
                    r2.Height = blocks.R2Bottom - r2.Top;
                    r3.Height = blocks.R3Bottom - r3.Top;

                    if (Bar.Pin == ZeroitBusyBar.Pins.Start && lines.Count > 0)
                    {
                        r2.Y -= BlockWidth + BlockLineWidth;
                        r2.Height += BlockWidth + BlockLineWidth;
                    }

                    if (Bar.Pin == ZeroitBusyBar.Pins.End && lines.Count > 0)
                        r2.Height += BlockWidth + BlockLineWidth;
                }

                GraphicsPath path = null;
                Color[] colours = null;

                switch (_Shape)
                {
                    case Shapes.Rectangle:
                        {
                            PointF[] points = null;

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                points = new PointF[]
                                {
                            new PointF( bounds.Left, yTop ),
                            new PointF( xMiddle, yTop ),
                            new PointF( bounds.Right, yTop ),
                            new PointF( bounds.Right, yValue ),
                            new PointF( bounds.Right, yBottom ),
                            new PointF( xMiddle, yBottom ),
                            new PointF( bounds.Left, yBottom ),
                            new PointF( bounds.Left, yValue ),
                                };
                            }
                            else
                            {
                                if (r2.Height < 1) return;

                                float yMiddle = (r2.Top + r2.Bottom) / 2;

                                points = new PointF[]
                                {
                            new PointF( bounds.Left, r2.Top ),
                            new PointF( xMiddle, r2.Top ),
                            new PointF( bounds.Right, r2.Top ),
                            new PointF( bounds.Right, yMiddle ),
                            new PointF( bounds.Right, r2.Bottom ),
                            new PointF( xMiddle, r2.Bottom ),
                            new PointF( bounds.Left, r2.Bottom ),
                            new PointF( bounds.Left, yMiddle ),
                                };
                            }

                            path = new GraphicsPath();
                            path.AddLines(points);
                            path.CloseFigure();

                            colours = new Color[]
                            {
                        _ColorCorner,
                        _ColorVertical,
                        _ColorCorner,
                        _ColorHorizontal,
                        _ColorCorner,
                        _ColorVertical,
                        _ColorCorner,
                        _ColorHorizontal
                            };

                            break;
                        }

                    case Shapes.Diamond:
                        {
                            PointF[] points = null;

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                points = new PointF[]
                                {
                            new PointF( xMiddle, yTop ),
                            new PointF( bounds.Right, yValue ),
                            new PointF( xMiddle, yBottom ),
                            new PointF( bounds.Left, yValue ),
                                };
                            }
                            else
                            {
                                if (r2.Height < 1) return;

                                float yMiddle = (r2.Top + r2.Bottom) / 2;

                                points = new PointF[]
                                {
                            new PointF( xMiddle, r2.Top ),
                            new PointF( bounds.Right, yMiddle ),
                            new PointF( xMiddle, r2.Bottom ),
                            new PointF( bounds.Left, yMiddle ),
                                };
                            }

                            path = new GraphicsPath();
                            path.AddLines(points);
                            path.CloseFigure();

                            colours = new Color[]
                            {
                        _ColorVertical,
                        _ColorHorizontal,
                        _ColorVertical,
                        _ColorHorizontal
                            };

                            break;
                        }

                    case Shapes.Circle:
                        {
                            path = new GraphicsPath();

                            if (Bar.Pin == ZeroitBusyBar.Pins.None)
                            {
                                path.AddEllipse(bounds.Left, yTop, bounds.Width, b);
                            }
                            else
                            {
                                if (r2.Height < 1) return;

                                path.AddEllipse(bounds.Left, r2.Top, bounds.Width, r2.Height);
                            }

                            colours = new Color[]
                            {
                        _ColorCorner,
                            };

                            break;
                        }

                    default:
                        Debug.Assert(false);
                        return;
                }

                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = _ColorCentre;
                    brush.SurroundColors = colours;

                    bool bOther = _Wrap && (Bar.Pin == ZeroitBusyBar.Pins.None);

                    if (bOther)
                    {
                        brush.TranslateTransform(0, -bounds.Height);
                        g.FillRectangle(brush, r1);
                        brush.ResetTransform();
                    }

                    g.FillRectangle(brush, r2);

                    if (bOther)
                    {
                        brush.TranslateTransform(0, +bounds.Height);
                        g.FillRectangle(brush, r3);
                        brush.ResetTransform();
                    }
                }

                if (BlockLineWidth > 0)
                    using (Pen pen2 = new Pen(BlockLineColor, BlockLineWidth))
                    {
                        foreach (float yLine in lines)
                            g.DrawLine(pen2, bounds.Left, yLine, bounds.Right, yLine);
                    }
            }

        }

    }

    #endregion

}
