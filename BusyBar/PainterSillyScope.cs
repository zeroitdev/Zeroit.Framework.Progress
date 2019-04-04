// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterSillyScope.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterSillyscope
    //-----------------------------------------------------------------------------
    //  ZeroitBusyBarPainterSillyscope

    /// <summary>
    /// Class ZeroitBusyBarPainterSillyscope.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterSillyscope.bmp")]
    public class ZeroitBusyBarPainterSillyscope : ZeroitBusyBarPainterBase
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
            /// The triangle
            /// </summary>
            Triangle,
            /// <summary>
            /// The square
            /// </summary>
            Square,
            /// <summary>
            /// The saw
            /// </summary>
            Saw,
            /// <summary>
            /// The sine
            /// </summary>
            Sine,
            /// <summary>
            /// The bezier
            /// </summary>
            Bezier,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
            /// <summary>
            /// The heartbeat
            /// </summary>
            Heartbeat,
        }

        /// <summary>
        /// Enum representing the Shapes
        /// </summary>
        public enum Shapes
        {
            /// <summary>
            /// The line
            /// </summary>
            Line,
            /// <summary>
            /// The curve
            /// </summary>
            Curve,
            /// <summary>
            /// The bezier
            /// </summary>
            Bezier,
        }


        /// <summary>
        /// The default draw grid
        /// </summary>
        private const bool _DefaultDrawGrid = true;
        /// <summary>
        /// The default grid line color
        /// </summary>
        private static readonly Color _DefaultGridLineColor = Color.Silver;
        /// <summary>
        /// The default grid line width
        /// </summary>
        private const int _DefaultGridLineWidth = 1;
        /// <summary>
        /// The default grid space x
        /// </summary>
        private const float _DefaultGridSpaceX = 20;
        /// <summary>
        /// The default grid space y
        /// </summary>
        private const float _DefaultGridSpaceY = 20;

        /// <summary>
        /// The default line color
        /// </summary>
        private static readonly Color _DefaultLineColor = Color.Empty;
        /// <summary>
        /// The default line width
        /// </summary>
        private const int _DefaultLineWidth = 2;

        /// <summary>
        /// The default shape
        /// </summary>
        private const Shapes _DefaultShape = Shapes.Line;

        // Must be 2D
        /// <summary>
        /// The default points line
        /// </summary>
        private static readonly PointF[] _DefaultPointsLine = new PointF[]
            {
                new PointF( 0, 1 ),
                new PointF( 1, 0 ),
                new PointF( 3, 2 ),
                new PointF( 4, 1 ),
            };

        // Must have >= 4 points
        /// <summary>
        /// The default points curve
        /// </summary>
        private static readonly PointF[] _DefaultPointsCurve = new PointF[]
            {
                new PointF( 0, 1 ),
                new PointF( 1, 0 ),
                new PointF( 2, 1 ),
                new PointF( 3, 2 ),
                new PointF( 4, 1 ),
                new PointF( 5, 0 ),
                new PointF( 6, 1 ),
        };

        // Must have ( 1 + 3n ) points for Beziers
        /// <summary>
        /// The default points bezier
        /// </summary>
        private static readonly PointF[] _DefaultPointsBezier = new PointF[]
            {
                new PointF( 0, 1 ),
                new PointF( 0, 0 ),
                new PointF( 9, 2 ),
                new PointF( 9, 1 ),
            };

        /// <summary>
        /// The default tension
        /// </summary>
        private const int _DefaultTension = 50;

        /// <summary>
        /// The default horizontal scale
        /// </summary>
        private const int _DefaultHorizontalScale = 25;
        /// <summary>
        /// The default vertical scale
        /// </summary>
        private const int _DefaultVerticalScale = 75;
        /// <summary>
        /// The default window draw
        /// </summary>
        private const bool _DefaultWindowDraw = false;
        /// <summary>
        /// The default window scale
        /// </summary>
        private const float _DefaultWindowScale = 50;



        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;

        /// <summary>
        /// The draw grid
        /// </summary>
        private bool _DrawGrid = _DefaultDrawGrid;
        /// <summary>
        /// The grid line color
        /// </summary>
        private Color _GridLineColor = _DefaultGridLineColor;
        /// <summary>
        /// The grid line width
        /// </summary>
        private int _GridLineWidth = _DefaultGridLineWidth;
        /// <summary>
        /// The grid space x
        /// </summary>
        private float _GridSpaceX = _DefaultGridSpaceX;
        /// <summary>
        /// The grid space y
        /// </summary>
        private float _GridSpaceY = _DefaultGridSpaceY;

        /// <summary>
        /// The line color
        /// </summary>
        private Color _LineColor = _DefaultLineColor;
        /// <summary>
        /// The line width
        /// </summary>
        private int _LineWidth = _DefaultLineWidth;

        /// <summary>
        /// The points
        /// </summary>
        private PointF[] _Points = _DefaultPointsLine;
        /// <summary>
        /// The shape
        /// </summary>
        private Shapes _Shape = _DefaultShape;
        /// <summary>
        /// The tension
        /// </summary>
        private int _Tension = _DefaultTension;

        /// <summary>
        /// The horizontal scale
        /// </summary>
        private int _HorizontalScale = _DefaultHorizontalScale;
        /// <summary>
        /// The vertical scale
        /// </summary>
        private int _VerticalScale = _DefaultVerticalScale;
        /// <summary>
        /// The window draw
        /// </summary>
        private bool _WindowDraw = _DefaultWindowDraw;
        /// <summary>
        /// The window scale
        /// </summary>
        private float _WindowScale = _DefaultWindowScale;

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
        /// Gets or sets a value indicating whether [draw grid].
        /// </summary>
        /// <value><c>true</c> if [draw grid]; otherwise, <c>false</c>.</value>
        [Category("5.Grid")]
        [DefaultValue(_DefaultDrawGrid)]
        [Description("Whether to draw a grid")]
        public bool DrawGrid
        {
            get { return _DrawGrid; }

            set
            {
                _DrawGrid = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the grid line.
        /// </summary>
        /// <value>The color of the grid line.</value>
        [Category("5.Grid")]
        //		[ DefaultValue( _DefaultLineColor ) ]
        [Description("The Color used to draw the grid")]
        public Color GridLineColor
        {
            get { return _GridLineColor; }

            set
            {
                _GridLineColor = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the grid line.
        /// </summary>
        /// <value>The width of the grid line.</value>
        [Category("5.Grid")]
        [DefaultValue(_DefaultGridLineWidth)]
        [Description("The width of the grid lines")]
        public int GridLineWidth
        {
            get { return _GridLineWidth; }

            set
            {
                _GridLineWidth = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the grid space x.
        /// </summary>
        /// <value>The grid space x.</value>
        [Category("5.Grid")]
        [DefaultValue(_DefaultGridSpaceX)]
        [Description("The horizontal space between the grid lines")]
        public float GridSpaceX
        {
            get { return _GridSpaceX; }

            set
            {
                _GridSpaceX = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the grid space y.
        /// </summary>
        /// <value>The grid space y.</value>
        [Category("5.Grid")]
        [DefaultValue(_DefaultGridSpaceX)]
        [Description("The vertical space between the grid lines")]
        public float GridSpaceY
        {
            get { return _GridSpaceY; }

            set
            {
                _GridSpaceY = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("2.Line")]
        //		[ DefaultValue( _DefaultLineColor ) ]
        [Description("The Color used to draw the line")]
        public Color LineColor
        {
            get { return _LineColor; }

            set
            {
                _LineColor = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Category("2.Line")]
        [DefaultValue(_DefaultLineWidth)]
        [Description("The width of the line")]
        public int LineWidth
        {
            get { return _LineWidth; }

            set
            {
                _LineWidth = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        /// <exception cref="ArgumentException">Points must describe a 2D shape</exception>
        [Category("3.Shape")]
        //		[ DefaultValue( _DefaultShape ) ]
        [Description("The array of points defining the line")]
        public PointF[] Points
        {
            get { return _Points; }

            set
            {
                // Checks for valid points
                GraphicsPath path = GetPath(_Shape, value);

                RectangleF r = path.GetBounds();

                if (r.Width <= 0 || r.Height <= 0)
                    throw new ArgumentException("Points must describe a 2D shape");

                _Points = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        [Category("3.Shape")]
        [DefaultValue(_DefaultShape)]
        [Description("The shape of the line")]
        public Shapes Shape
        {
            get { return _Shape; }

            set
            {
                switch (value)
                {
                    case Shapes.Line:

                        if (_Points.Length < 2)
                            _Points = _DefaultPointsLine;

                        break;

                    case Shapes.Curve:

                        if (_Points.Length < 4)
                            _Points = _DefaultPointsCurve;

                        break;

                    case Shapes.Bezier:

                        if (_Points.Length < 4 || _Points.Length % 3 != 1)
                            _Points = _DefaultPointsBezier;

                        break;

                    default:
                        Debug.Assert(false);
                        return;
                }

                // Checks for valid points
                GraphicsPath path = GetPath(value, _Points);

                _Shape = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the tension.
        /// </summary>
        /// <value>The tension.</value>
        /// <exception cref="ArgumentException">Tension must be between 0 and 100</exception>
        [Category("3.Shape")]
        [DefaultValue(_DefaultTension)]
        [Description("The tension of the line. Only used for curve shape")]
        public int Tension
        {
            get { return _Tension; }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(
                        "Tension must be between 0 and 100");

                _Tension = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the horizontal scale.
        /// </summary>
        /// <value>The horizontal scale.</value>
        [Category("4.Scale")]
        [DefaultValue(_DefaultHorizontalScale)]
        [Description("The horizontal scale of the line as a percentage of the control width")]
        public int HorizontalScale
        {
            get { return _HorizontalScale; }

            set
            {
                _HorizontalScale = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the vertical scale.
        /// </summary>
        /// <value>The vertical scale.</value>
        [Category("4.Scale")]
        [DefaultValue(_DefaultVerticalScale)]
        [Description("The vertical scale of the line as a percentage of the control height")]
        public int VerticalScale
        {
            get { return _VerticalScale; }

            set
            {
                _VerticalScale = value;

                if (Bar != null) Bar.Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [window draw].
        /// </summary>
        /// <value><c>true</c> if [window draw]; otherwise, <c>false</c>.</value>
        [Category("4.Scale")]
        [DefaultValue(_DefaultWindowDraw)]
        [Description("Whether to draw in a window")]
        public bool WindowDraw
        {
            get { return _WindowDraw; }

            set
            {
                _WindowDraw = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the window scale.
        /// </summary>
        /// <value>The window scale.</value>
        [Category("4.Scale")]
        [DefaultValue(_DefaultWindowScale)]
        [Description("The scale of the window as a percentage of the line extent")]
        public float WindowScale
        {
            get { return _WindowScale; }

            set
            {
                _WindowScale = value;

                if (Bar != null) Bar.Invalidate();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterSillyscope"/> class.
        /// </summary>
        public ZeroitBusyBarPainterSillyscope() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterSillyscope"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterSillyscope(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterSillyscope"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterSillyscope(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterSillyscope"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterSillyscope(ZeroitBusyBarPainterSillyscope o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterSillyscope)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterSillyscope)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterSillyscope o)
        {
            _Preset = o._Preset;

            _DrawGrid = o._DrawGrid;
            _GridLineColor = o._GridLineColor;
            _GridLineWidth = o._GridLineWidth;
            _GridSpaceX = o._GridSpaceX;
            _GridSpaceY = o._GridSpaceY;

            _LineColor = o._LineColor;
            _LineWidth = o._LineWidth;

            _Points = o._Points;
            _Shape = o._Shape;
            _Tension = o._Tension;

            _HorizontalScale = o._HorizontalScale;
            _VerticalScale = o._VerticalScale;
            _WindowDraw = o._WindowDraw;
            _WindowScale = o._WindowScale;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterSillyscope(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            if (_LineColor == Color.Empty) _LineColor = Bar.ForeColor;
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

            _DrawGrid = _DefaultDrawGrid;
            _GridLineColor = _DefaultGridLineColor;
            _GridLineWidth = _DefaultGridLineWidth;
            _GridSpaceX = _DefaultGridSpaceX;
            _GridSpaceY = _DefaultGridSpaceY;

            _LineColor = _DefaultLineColor;
            _LineWidth = _DefaultLineWidth;

            _Points = _DefaultPointsLine;
            _Shape = _DefaultShape;
            _Tension = _DefaultTension;

            _HorizontalScale = _DefaultHorizontalScale;
            _VerticalScale = _DefaultVerticalScale;
            _WindowDraw = _DefaultWindowDraw;
            _WindowScale = _DefaultWindowScale;

            if (Bar != null)
            {
                _LineColor = Bar.ForeColor;
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

                case Presets.Triangle:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.CornerRadius = 50;
                    }

                    _GridLineColor = Color.Goldenrod;

                    _LineColor = Color.Lime;

                    _Points = _DefaultPointsLine;

                    _HorizontalScale = 50;

                    break;

                case Presets.Square:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.CornerRadius = 50;
                    }

                    _GridLineColor = Color.Goldenrod;

                    _LineColor = Color.Lime;

                    _Points = new PointF[]
                        {
                        new PointF(  0 , 0 ),
                        new PointF(  1 , 0 ),
                        new PointF(  1 , 1 ),
                        new PointF(  2 , 1 ),
                        new PointF(  2 , 0 ),
                        };

                    _HorizontalScale = 50;

                    break;

                case Presets.Saw:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.CornerRadius = 50;
                    }

                    _GridLineColor = Color.Goldenrod;

                    _LineColor = Color.Lime;

                    _Points = new PointF[]
                        {
                        new PointF(  0 , 1 ),
                        new PointF(  3 , 0 ),
                        new PointF(  3 , 1 ),
                        };

                    _HorizontalScale = 50;

                    break;

                case Presets.Sine:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.CornerRadius = 50;
                    }

                    _GridLineColor = Color.Goldenrod;

                    _LineColor = Color.Lime;

                    _Points = new PointF[]
                        {
                        new PointF( -1 ,  0.7f ),
                        new PointF(  0 ,  0.0f ),
                        new PointF(  1 , -0.7f ),
                        new PointF(  2 , -1.0f ),
                        new PointF(  3 , -0.7f ),
                        new PointF(  4 ,  0.0f ),
                        new PointF(  5 ,  0.7f ),
                        new PointF(  6 ,  1.0f ),
                        new PointF(  7 ,  0.7f ),
                        new PointF(  8 ,  0.0f ),
                        new PointF(  9 , -0.7f ),
                        };

                    _Shape = Shapes.Curve;

                    _HorizontalScale = 50;

                    break;

                case Presets.Bezier:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.CornerRadius = 50;
                    }

                    _GridLineColor = Color.Goldenrod;

                    _LineColor = Color.Lime;

                    _Points = _DefaultPointsBezier;
                    _Shape = Shapes.Bezier;

                    _HorizontalScale = 50;
                    _VerticalScale = 200;

                    break;

                case Presets.Circle:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.Bounce = true;
                        Bar.Pin = ZeroitBusyBar.Pins.Start;
                    }

                    _LineColor = Color.Lime;

                    _Points = new PointF[]
                        {
                        new PointF( -1 ,  0 ),
                        new PointF(  0 , -1 ),
                        new PointF(  1 ,  0 ),
                        new PointF(  0 ,  1 ),
                        new PointF( -1 ,  0 ),
                        new PointF(  0 , -1 ),
                        new PointF(  1 ,  0 ),
                        };

                    _Shape = Shapes.Curve;
                    _Tension = 80;

                    //				_HorizontalScale = 50;
                    _VerticalScale = 50;
                    _WindowDraw = true;

                    break;

                case Presets.Heartbeat:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;

                        Bar.Maximum = 200;
                        Bar.Pin = ZeroitBusyBar.Pins.Start;
                    }

                    _GridSpaceX = 25;
                    _GridSpaceY = 16;

                    _LineColor = Color.Lime;

                    _Points = new PointF[]
                        {
                        new PointF( -1 ,  0 ),
                        new PointF(  0 ,  0 ),
                        new PointF(  5 ,  0 ),
                        new PointF(  8 , -3 ),
                        new PointF( 11 ,  1 ),
                        new PointF( 14 ,  0 ),
                        new PointF( 19 ,  0 ),
                        new PointF( 20 ,  0 ),
                        };

                    _Shape = Shapes.Curve;

                    //				_HorizontalScale = 50;
                    _WindowDraw = true;

                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
        }

        /// <summary>
        /// Gets the graphics path.
        /// </summary>
        /// <value>The graphics path.</value>
        private GraphicsPath GraphicsPath
        {
            get
            {
                return GetPath(_Shape, _Points);
            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="points">The points.</param>
        /// <returns>GraphicsPath.</returns>
        /// <exception cref="ArgumentException">For Beziers, the points array must include the starting point, and three extra points for each segment</exception>
        private GraphicsPath GetPath(Shapes shape, PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();

            switch (shape)
            {
                case Shapes.Line:
                    path.AddLines(points);
                    break;

                case Shapes.Curve:
                    path.AddCurve(points, 1, points.Length - 3, _Tension / 100f);
                    break;

                case Shapes.Bezier:

                    if (points.Length < 4 || points.Length % 3 != 1)
                        throw new ArgumentException("For Beziers, the points array must include the starting point, and three extra points for each segment");

                    path.AddBeziers(points);

                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return path;
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

            if (_Points.Length <= 0) return;

            //			g.ResetClip();

            // Grid
            if (_DrawGrid)
                ZeroitBusyBarGrid.Draw(
                    g,
                    _GridLineColor,
                    _GridLineWidth,
                    _GridSpaceX,
                    _GridSpaceY);

            // Init
            RectangleF bounds = r.GetBounds(g);
            float ratio = CalculateRatio();

            GraphicsPath path = GraphicsPath;

            // Rotate
            if (Bar.Vertical)
            {
                Matrix rotate = new Matrix();
                rotate.Rotate(90, MatrixOrder.Append);
                path.Transform(rotate);
            }

            // Client metrics
            RectangleF rectClient = r.GetBounds(g);
            SizeF sizeClient = rectClient.Size;
            float xClientMiddle = rectClient.Left + (sizeClient.Width / 2f);
            float yClientMiddle = rectClient.Top + (sizeClient.Height / 2f);

            // Path metrics
            RectangleF rectPath = path.GetBounds();
            SizeF sizePath = rectPath.Size;

            if (sizePath.Width <= 0 || sizePath.Height <= 0) return;

            // Normalise
            if (1 == 1)
            {
                float xScale = 0;
                float yScale = 0;

                if (!Bar.Vertical)
                {
                    xScale = sizeClient.Width / sizePath.Width * _HorizontalScale / 100f;
                    yScale = sizeClient.Height / sizePath.Height * _VerticalScale / 100f;
                }
                else
                {
                    xScale = sizeClient.Width / sizePath.Width * _VerticalScale / 100f;
                    yScale = sizeClient.Height / sizePath.Height * _HorizontalScale / 100f;
                }

                Matrix matrixNormalise = new Matrix();
                matrixNormalise.Translate(-rectPath.Left, -rectPath.Top, MatrixOrder.Append);
                matrixNormalise.Scale(xScale, yScale, MatrixOrder.Append);
                path.Transform(matrixNormalise);
            }

            // Normalised metrics
            RectangleF rectNormalisedPath = path.GetBounds();
            SizeF sizeNormalisedPath = rectNormalisedPath.Size;
            float xPeriod = sizeNormalisedPath.Width;
            float yPeriod = sizeNormalisedPath.Height;
            float xNormalisedPathMiddle = rectNormalisedPath.Left + (sizeNormalisedPath.Width / 2f);
            float yNormalisedPathMiddle = rectNormalisedPath.Top + (sizeNormalisedPath.Height / 2f);

            if (!Bar.Vertical)
            {
                // Translate to ClientRectangle
                if (1 == 1)
                {
                    float xClientOffset = rectClient.Left;
                    float yClientOffset = yClientMiddle - yNormalisedPathMiddle;

                    Matrix moveClient = new Matrix();
                    moveClient.Translate(xClientOffset, yClientOffset, MatrixOrder.Append);
                    path.Transform(moveClient);
                }

                // Whole periods
                int xIntPeriods = (int)System.Math.Floor(bounds.Width / xPeriod);

                // Offset
                if (Bar.Pin == ZeroitBusyBar.Pins.None)
                {
                    float xWholeWidth = xIntPeriods * xPeriod;
                    float xFudge = xWholeWidth / bounds.Width;

                    float xOffset = (bounds.Width * ratio);
                    xOffset *= xFudge;
                    xOffset %= xPeriod;
                    xOffset -= xPeriod;

                    Matrix moveOffset = new Matrix();
                    moveOffset.Translate(xOffset, 0, MatrixOrder.Append);
                    path.Transform(moveOffset);
                }

                // Clip
                Region regionWindow = null;

                if (!_WindowDraw)
                {
                    switch (Bar.Pin)
                    {
                        case ZeroitBusyBar.Pins.None:
                            break;

                        case ZeroitBusyBar.Pins.Start:
                            {
                                float xOffset = (bounds.Width * ratio);

                                RectangleF rectWindow = new RectangleF(
                                    bounds.Left,
                                    bounds.Top,
                                    xOffset,
                                    bounds.Height);

                                regionWindow = new Region(rectWindow);

                                break;
                            }

                        case ZeroitBusyBar.Pins.End:
                            {
                                float xOffset = (bounds.Width * ratio);

                                RectangleF rectWindow = new RectangleF(
                                    bounds.Left + xOffset,
                                    bounds.Top,
                                    bounds.Width - xOffset,
                                    bounds.Height);

                                regionWindow = new Region(rectWindow);

                                break;
                            }

                        default:
                            Debug.Assert(false);
                            return;
                    }
                }
                // _WindowDraw
                else
                {
                    float xOffset = (bounds.Width * ratio);
                    float xWindowWidth = xPeriod * _WindowScale / 100f;
                    float xHalfWindowWidth = xWindowWidth / 2f;

                    RectangleF rectWindow = new RectangleF(
                        xOffset - xHalfWindowWidth,
                        bounds.Top,
                        xWindowWidth,
                        bounds.Height);

                    regionWindow = new Region(rectWindow);
                }

                if (regionWindow != null)
                {
                    Region regionWindowClient = (Region)g.Clip.Clone();
                    regionWindowClient.Intersect(regionWindow);
                    g.Clip = regionWindowClient;
                }

                // Paint
                Matrix movePeriod = new Matrix();
                movePeriod.Translate(xPeriod, 0, MatrixOrder.Append);

                using (Pen pen = new Pen(_LineColor, _LineWidth))
                {
                    for (int i = -1; i < xIntPeriods + 1; i++)
                    {
                        g.DrawPath(pen, path);
                        path.Transform(movePeriod);
                    }
                }
            }
            // Vertical
            else
            {
                // Translate to ClientRectangle
                if (1 == 1)
                {
                    float xClientOffset = xClientMiddle - xNormalisedPathMiddle;
                    float yClientOffset = rectClient.Top;

                    Matrix moveClient = new Matrix();
                    moveClient.Translate(xClientOffset, yClientOffset, MatrixOrder.Append);
                    path.Transform(moveClient);
                }

                // Whole periods
                int yIntPeriods = (int)System.Math.Floor(bounds.Height / yPeriod);

                // Offset
                if (Bar.Pin == ZeroitBusyBar.Pins.None)
                {
                    float yWholeWidth = yIntPeriods * yPeriod;
                    float yFudge = yWholeWidth / bounds.Height;

                    float yOffset = (bounds.Height * ratio);
                    yOffset *= yFudge;
                    yOffset %= yPeriod;
                    yOffset -= yPeriod;

                    Matrix moveOffset = new Matrix();
                    moveOffset.Translate(0, yOffset, MatrixOrder.Append);
                    path.Transform(moveOffset);
                }

                // Clip
                Region regionWindow = null;

                if (!_WindowDraw)
                {
                    switch (Bar.Pin)
                    {
                        case ZeroitBusyBar.Pins.None:
                            break;

                        case ZeroitBusyBar.Pins.Start:
                            {
                                float yOffset = (bounds.Height * ratio);

                                RectangleF rectWindow = new RectangleF(
                                    bounds.Left,
                                    bounds.Top,
                                    bounds.Width,
                                    yOffset);

                                regionWindow = new Region(rectWindow);

                                break;
                            }

                        case ZeroitBusyBar.Pins.End:
                            {
                                float yOffset = (bounds.Height * ratio);

                                RectangleF rectWindow = new RectangleF(
                                    bounds.Left,
                                    bounds.Top + yOffset,
                                    bounds.Width,
                                    bounds.Height - yOffset);

                                regionWindow = new Region(rectWindow);

                                break;
                            }

                        default:
                            Debug.Assert(false);
                            return;
                    }
                }
                // _WindowDraw
                else
                {
                    float yOffset = (bounds.Height * ratio);
                    float yWindowWidth = yPeriod * _WindowScale / 100f;
                    float yHalfWindowWidth = yWindowWidth / 2f;

                    RectangleF rectWindow = new RectangleF(
                        bounds.Left,
                        yOffset - yHalfWindowWidth,
                        bounds.Width,
                        yWindowWidth);

                    regionWindow = new Region(rectWindow);
                }

                if (regionWindow != null)
                {
                    Region regionWindowClient = g.Clip;
                    regionWindowClient.Intersect(regionWindow);
                    g.Clip = regionWindowClient;
                }

                // Paint
                Matrix movePeriod = new Matrix();
                movePeriod.Translate(0, yPeriod, MatrixOrder.Append);

                using (Pen pen = new Pen(_LineColor, _LineWidth))
                {
                    for (int i = -1; i < yIntPeriods + 1; i++)
                    {
                        g.DrawPath(pen, path);
                        path.Transform(movePeriod);
                    }
                }
            }
        }
    }
    #endregion

}
