// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-26-2018
// ***********************************************************************
// <copyright file="ZeroitProgBarPlus.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class ZeroitProgBarPlus.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ZeroitProgBarPlus), "ProgBar.ZeroitProgBarPlus.bmp")]
    [Designer(typeof(ProgBarControlDesigner))]
    [DebuggerStepThrough]
    public partial class ZeroitProgBarPlus : UserControl
    {
        /// <summary>
        /// The cylon direction
        /// </summary>
        private float CylonDirection = 1F;
        /// <summary>
        /// The cylon g delta
        /// </summary>
        private float CylonGDelta = 0.001F;
        /// <summary>
        /// The cylon g position
        /// </summary>
        private float CylonGPosition = 0.5F;
        /// <summary>
        /// The cylon position
        /// </summary>
        private float CylonPosition;

        /// <summary>
        /// Struct ProgBarPath
        /// </summary>
        public struct ProgBarPath
        {
            /// <summary>
            /// The rect
            /// </summary>
            public Rectangle Rect;
            /// <summary>
            /// The path
            /// </summary>
            public GraphicsPath Path;
        }

        #region Initialize

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgBarPlus"/> class.
        /// </summary>
        public ZeroitProgBarPlus()
        {
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        }

        //Control overrides dispose to clean up the component list.
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Control Designer
        /// <summary>
        /// The components
        /// </summary>
        private IContainer components;

        // NOTE: The following procedure is required by the Component Designer
        // It can be modified using the Component Designer.  Do not modify it
        // using the code editor.
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            TimerCylon = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            //
            //ZeroitProgBarPlus
            //
            BackColor = SystemColors.Control;
            Name = "ZeroitProgBarPlus";
            Size = new Size(200, 20);
            ResumeLayout(false);

            //INSTANT C# NOTE: Converted design-time event handler wireups:
            TimerCylon.Tick += TimerCylon_Tick;
        }

        #endregion

        #region Property Enumeration

        /// <summary>
        /// Enum eShape
        /// </summary>
        public enum eShape
        {
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// The ellipse
            /// </summary>
            Ellipse,
            /// <summary>
            /// The triangle left
            /// </summary>
            TriangleLeft,
            /// <summary>
            /// The triangle right
            /// </summary>
            TriangleRight,
            /// <summary>
            /// The triangle up
            /// </summary>
            TriangleUp,
            /// <summary>
            /// The triangle down
            /// </summary>
            TriangleDown,
            /// <summary>
            /// The text
            /// </summary>
            Text
        }

        /// <summary>
        /// Enum eBarStyle
        /// </summary>
        public enum eBarStyle
        {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The gradient linear
            /// </summary>
            GradientLinear,
            /// <summary>
            /// The gradient path
            /// </summary>
            GradientPath,
            /// <summary>
            /// The texture
            /// </summary>
            Texture,
            /// <summary>
            /// The hatch
            /// </summary>
            Hatch
        }

        /// <summary>
        /// Enum eOrientation
        /// </summary>
        public enum eOrientation
        {
            /// <summary>
            /// The horizontal
            /// </summary>
            Horizontal,
            /// <summary>
            /// The vertical
            /// </summary>
            Vertical
        }

        /// <summary>
        /// Enum eTextPlacement
        /// </summary>
        public enum eTextPlacement
        {
            /// <summary>
            /// The over bar
            /// </summary>
            OverBar,
            /// <summary>
            /// The on bar
            /// </summary>
            OnBar
        }

        /// <summary>
        /// Enum eCornersApply
        /// </summary>
        public enum eCornersApply
        {
            /// <summary>
            /// The both
            /// </summary>
            Both,
            /// <summary>
            /// The border
            /// </summary>
            Border,
            /// <summary>
            /// The bar
            /// </summary>
            Bar
        }

        /// <summary>
        /// Enum eRotateText
        /// </summary>
        public enum eRotateText
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The left
            /// </summary>
            Left,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// Enum eFillDirection
        /// </summary>
        public enum eFillDirection
        {
            /// <summary>
            /// Up right
            /// </summary>
            Up_Right,
            /// <summary>
            /// Down left
            /// </summary>
            Down_Left
        }

        /// <summary>
        /// Enum eTextShow
        /// </summary>
        public enum eTextShow
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The value
            /// </summary>
            Value,
            /// <summary>
            /// The value of maximum
            /// </summary>
            ValueOfMax,
            /// <summary>
            /// The percent
            /// </summary>
            Percent,
            /// <summary>
            /// The format string
            /// </summary>
            FormatString
        }

        /// <summary>
        /// Enum eBarType
        /// </summary>
        public enum eBarType
        {
            /// <summary>
            /// The bar
            /// </summary>
            Bar,
            /// <summary>
            /// The cylon bar
            /// </summary>
            CylonBar,
            /// <summary>
            /// The cylon glider
            /// </summary>
            CylonGlider
        }

        /// <summary>
        /// Enum eBarLength
        /// </summary>
        public enum eBarLength
        {
            /// <summary>
            /// The full
            /// </summary>
            Full,
            /// <summary>
            /// The fixed
            /// </summary>
            Fixed
        }

        /// <summary>
        /// Enum ePart
        /// </summary>
        public enum ePart
        {
            /// <summary>
            /// The back
            /// </summary>
            Back,
            /// <summary>
            /// The bar
            /// </summary>
            Bar,
            /// <summary>
            /// The border
            /// </summary>
            Border
        }

        #endregion //Property Enumeration

        #region Properties


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                if (value == SmoothingMode.Invalid)
                {
                    value = SmoothingMode.HighQuality;
                    Invalidate();
                }
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

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

        #region Corners Expandable Property

        //Corners Property is defined in the Corners Converter Class
        //to use the ExpandableObjectConverter to simulate the BarPadding Property

        /// <summary>
        /// The corners
        /// </summary>
        private CornersProperty _Corners = new CornersProperty();

        /// <summary>
        /// Gets or sets the corners.
        /// </summary>
        /// <value>The corners.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Corner Radii")]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CornersProperty Corners
        {
            get { return _Corners; }
            set
            {
                _Corners = value;
                Refresh();
            }
        }

        #endregion //Corners Expandable Property

        #region Appearance Properties

        #region Color and Fill

        /// <summary>
        /// The bar back color
        /// </summary>
        private Color _BarBackColor = Color.White;

        /// <summary>
        /// Gets or sets the color of the bar back.
        /// </summary>
        /// <value>The color of the bar back.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Color behind the Bar")]
        [DefaultValue(typeof(Color), "White")]
        public Color BarBackColor
        {
            get { return _BarBackColor; }
            set
            {
                _BarBackColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar color solid
        /// </summary>
        private Color _BarColorSolid = Color.Blue;

        /// <summary>
        /// Gets or sets the bar color solid.
        /// </summary>
        /// <value>The bar color solid.</value>
        [Description("The Solid Color to fill the Bar")]
        [Category("Appearance ProgBar")]
        public Color BarColorSolid
        {
            get { return _BarColorSolid; }
            set
            {
                _BarColorSolid = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar color solid b
        /// </summary>
        private Color _BarColorSolidB = Color.White;

        /// <summary>
        /// Gets or sets the bar color solid b.
        /// </summary>
        /// <value>The bar color solid b.</value>
        [Description("The Secondary Color for Hatch Style")]
        [Category("Appearance ProgBar")]
        public Color BarColorSolidB
        {
            get { return _BarColorSolidB; }
            set
            {
                _BarColorSolidB = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar color blend
        /// </summary>
        private cBlendItems _BarColorBlend = new cBlendItems(new[] {Color.Navy, Color.Blue}, new[] {0F, 1F});

        /// <summary>
        /// Gets or sets the bar color blend.
        /// </summary>
        /// <value>The bar color blend.</value>
        [Description("The ColorBlend to fill the shape")]
        [Category("Appearance ProgBar")]
        [Editor(typeof(BlendTypeEditor), typeof(UITypeEditor))]
        public cBlendItems BarColorBlend
        {
            get { return _BarColorBlend; }
            set
            {
                _BarColorBlend = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar style fill
        /// </summary>
        private eBarStyle _BarStyleFill = eBarStyle.Solid;

        /// <summary>
        /// Gets or sets the bar style fill.
        /// </summary>
        /// <value>The bar style fill.</value>
        [Description("The Fill Type to apply to the Shape")]
        [Category("Appearance ProgBar")]
        public eBarStyle BarStyleFill
        {
            get { return _BarStyleFill; }
            set
            {
                _BarStyleFill = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar style linear
        /// </summary>
        private LinearGradientMode _BarStyleLinear = LinearGradientMode.Horizontal;

        /// <summary>
        /// Gets or sets the bar style linear.
        /// </summary>
        /// <value>The bar style linear.</value>
        [Description("The Linear Blend type")]
        [Category("Appearance ProgBar")]
        public LinearGradientMode BarStyleLinear
        {
            get { return _BarStyleLinear; }
            set
            {
                _BarStyleLinear = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The focal points
        /// </summary>
        private cFocalPoints _FocalPoints = new cFocalPoints(0.5F, 0.5F, 0F, 0F);

        /// <summary>
        /// Gets or sets the focal points.
        /// </summary>
        /// <value>The focal points.</value>
        [Editor(typeof(FocalTypeEditor), typeof(UITypeEditor))]
        [Description("The CenterPoint and FocusScales for the ColorBlend")]
        [Category("Appearance ProgBar")]
        public cFocalPoints FocalPoints
        {
            get { return _FocalPoints; }
            set
            {
                _FocalPoints = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar style hatch
        /// </summary>
        private HatchStyle _BarStyleHatch = HatchStyle.SmallCheckerBoard;

        /// <summary>
        /// Gets or sets the bar style hatch.
        /// </summary>
        /// <value>The bar style hatch.</value>
        [Editor(typeof(HatchStyleEditor), typeof(UITypeEditor))]
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Hatch Style when the BarStyleFill is set to Hatch")]
        [DefaultValue(HatchStyle.SmallCheckerBoard)]
        public HatchStyle BarStyleHatch
        {
            get { return _BarStyleHatch; }
            set
            {
                _BarStyleHatch = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar style texture
        /// </summary>
        private Image _BarStyleTexture;

        /// <summary>
        /// Gets or sets the bar style texture.
        /// </summary>
        /// <value>The bar style texture.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Wrap Style for the Texture Image")]
        public Image BarStyleTexture
        {
            get { return _BarStyleTexture; }
            set
            {
                _BarStyleTexture = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar style wrap mode
        /// </summary>
        private WrapMode _BarStyleWrapMode = WrapMode.Clamp;

        /// <summary>
        /// Gets or sets the bar style wrap mode.
        /// </summary>
        /// <value>The bar style wrap mode.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Wrapmode of the Image")]
        [DefaultValue(WrapMode.Clamp)]
        public WrapMode BarStyleWrapMode
        {
            get { return _BarStyleWrapMode; }
            set
            {
                _BarStyleWrapMode = value;
                Invalidate();
            }
        }

        #endregion //Color and Fill

        #region Text

        /// <summary>
        /// The shadow
        /// </summary>
        private bool _Shadow;

        /// <summary>
        /// Gets or sets a value indicating whether [text shadow].
        /// </summary>
        /// <value><c>true</c> if [text shadow]; otherwise, <c>false</c>.</value>
        [Category("Appearance ProgBar")]
        [Description("Add Shadow to text")]
        [DefaultValue(false)]
        public bool TextShadow
        {
            get { return _Shadow; }
            set
            {
                _Shadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shadow color
        /// </summary>
        private Color _ShadowColor = Color.White;

        /// <summary>
        /// Gets or sets the color of the text shadow.
        /// </summary>
        /// <value>The color of the text shadow.</value>
        [Category("Appearance ProgBar")]
        [Description("Define the Color of the Shadow text")]
        [DefaultValue(typeof(Color), "White")]
        public Color TextShadowColor
        {
            get { return _ShadowColor; }
            set
            {
                _ShadowColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The text show
        /// </summary>
        private eTextShow _TextShow = eTextShow.None;

        /// <summary>
        /// Gets or sets the text show.
        /// </summary>
        /// <value>The text show.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set how the Text and/or Percent is displayed")]
        [DefaultValue(eTextShow.None)]
        public eTextShow TextShow
        {
            get { return _TextShow; }
            set
            {
                _TextShow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text format
        /// </summary>
        private string _TextFormat = "Process {1}% Done";

        /// <summary>
        /// Gets or sets the text format.
        /// </summary>
        /// <value>The text format.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Format String to display Percent and or Text variables." + "\r" + "FormatString:" +
                     "\r" + "Enter {0} where you want the Value to appear." + "\r" +
                     "Enter {1} where you want the Percent to appear." + "\r" +
                     "Enter {2} where you want the Max to appear.")]
        [DefaultValue("Process {0}% Done")]
        public string TextFormat
        {
            get { return _TextFormat; }
            set
            {
                _TextFormat = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text placement
        /// </summary>
        private eTextPlacement _TextPlacement = eTextPlacement.OverBar;

        /// <summary>
        /// Gets or sets the text placement.
        /// </summary>
        /// <value>The text placement.</value>
        [Category("Appearance ProgBar")]
        [Description("Where to put text. Static Over Bar or moving on the bar")]
        [DefaultValue(eTextPlacement.OverBar)]
        public eTextPlacement TextPlacement
        {
            get { return _TextPlacement; }
            set
            {
                _TextPlacement = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Horizontal Alignment of the text")]
        [DefaultValue(StringAlignment.Center)]
        public StringAlignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text alignment vert
        /// </summary>
        private StringAlignment _TextAlignmentVert = StringAlignment.Center;

        /// <summary>
        /// Gets or sets the text alignment vert.
        /// </summary>
        /// <value>The text alignment vert.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Vertical Alignment of he text")]
        [DefaultValue(StringAlignment.Center)]
        public StringAlignment TextAlignmentVert
        {
            get { return _TextAlignmentVert; }
            set
            {
                _TextAlignmentVert = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The rotate text
        /// </summary>
        private eRotateText _RotateText = eRotateText.None;

        /// <summary>
        /// Gets or sets the text rotate.
        /// </summary>
        /// <value>The text rotate.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the rotation of the text")]
        [DefaultValue(eRotateText.None)]
        public eRotateText TextRotate
        {
            get { return _RotateText; }
            set
            {
                _RotateText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text wrap
        /// </summary>
        private bool _TextWrap = true;

        /// <summary>
        /// Gets or sets a value indicating whether [text wrap].
        /// </summary>
        /// <value><c>true</c> if [text wrap]; otherwise, <c>false</c>.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set if the text will wrap")]
        [DefaultValue(true)]
        public bool TextWrap
        {
            get { return _TextWrap; }
            set
            {
                _TextWrap = value;
                Invalidate();
            }
        }

        #endregion //Text

        #region Border

        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor = Color.Black;

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Border Color")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The border width
        /// </summary>
        private short _BorderWidth = 1;

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Width of the Border around control")]
        [DefaultValue(1)]
        public short BorderWidth
        {
            get { return _BorderWidth; }
            set
            {
                _BorderWidth = value;
                Invalidate();
            }
        }

        #endregion //Border

        #region Shape

        /// <summary>
        /// The corners apply
        /// </summary>
        private eCornersApply _CornersApply = eCornersApply.Both;

        /// <summary>
        /// Gets or sets the corners apply.
        /// </summary>
        /// <value>The corners apply.</value>
        [Category("Appearance ProgBar")]
        [Description("Apply corners to Bar and/or Border")]
        [DefaultValue(eCornersApply.Both)]
        public eCornersApply CornersApply
        {
            get { return _CornersApply; }
            set
            {
                _CornersApply = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shape
        /// </summary>
        private eShape _Shape = eShape.Rectangle;

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Shape of the Control")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(eShape.Rectangle)]
        public eShape Shape
        {
            get { return _Shape; }
            set
            {
                _Shape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shape text font
        /// </summary>
        private Font _ShapeTextFont = new Font("Arial Black", 30);

        /// <summary>
        /// Gets or sets the shape text font.
        /// </summary>
        /// <value>The shape text font.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Font of the Text Shape")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(typeof(Font), "Arial Black")]
        public Font ShapeTextFont
        {
            get { return _ShapeTextFont; }
            set
            {
                _ShapeTextFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shape text
        /// </summary>
        private string _ShapeText = "ZeroitProgBarPlus";

        /// <summary>
        /// Gets or sets the shape text.
        /// </summary>
        /// <value>The shape text.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the Font of the Text Shape")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue("ZeroitProgBarPlus")]
        public string ShapeText
        {
            get { return _ShapeText; }
            set
            {
                _ShapeText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shape text rotate
        /// </summary>
        private eRotateText _ShapeTextRotate = eRotateText.None;

        /// <summary>
        /// Gets or sets the shape text rotate.
        /// </summary>
        /// <value>The shape text rotate.</value>
        [Category("Appearance ProgBar")]
        [Description("Get or Set the rotation of the text shape")]
        [DefaultValue(eRotateText.None)]
        public eRotateText ShapeTextRotate
        {
            get { return _ShapeTextRotate; }
            set
            {
                _ShapeTextRotate = value;
                Invalidate();
            }
        }

        #endregion //Shape

        #endregion //Appearance Properties

        #region Behavior Properties

        /// <summary>
        /// The show design border
        /// </summary>
        private bool _ShowDesignBorder = true;

        /// <summary>
        /// Gets or sets a value indicating whether [show design border].
        /// </summary>
        /// <value><c>true</c> if [show design border]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Show Dashed Border around control at design time")]
        [DefaultValue(true)]
        public bool ShowDesignBorder
        {
            get { return _ShowDesignBorder; }
            set
            {
                _ShowDesignBorder = value;
                Invalidate();
            }
        }

        #endregion //Behavior Properties

        #region Bar Cylon

        /// <summary>
        /// The cylon run
        /// </summary>
        private bool _CylonRun;

        /// <summary>
        /// Gets or sets a value indicating whether [cylon run].
        /// </summary>
        /// <value><c>true</c> if [cylon run]; otherwise, <c>false</c>.</value>
        [Category("Bar Cylon")]
        [Description("Start and Stop the Timer in Cylon Mode")]
        [DefaultValue(false)]
        public bool CylonRun
        {
            get { return _CylonRun; }
            set
            {
                if (BarType != eBarType.Bar)
                {
                    _CylonRun = value;
                    TimerCylon.Enabled = value;
                }
                else
                {
                    _CylonRun = false;
                    TimerCylon.Enabled = false;
                }
            }
        }

        /// <summary>
        /// The cylon interval
        /// </summary>
        private short _CylonInterval = 1;

        /// <summary>
        /// Gets or sets the cylon interval.
        /// </summary>
        /// <value>The cylon interval.</value>
        [Category("Bar Cylon")]
        [Description("Get or Set the Timer CylonInterval in Cylon Mode")]
        [DefaultValue(1)]
        public short CylonInterval
        {
            get { return _CylonInterval; }
            set
            {
                _CylonInterval = value;
                TimerCylon.Interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The cylon move
        /// </summary>
        private float _CylonMove = 5F;

        /// <summary>
        /// Gets or sets the cylon move.
        /// </summary>
        /// <value>The cylon move.</value>
        [Category("Bar Cylon")]
        [Description("Get or Set the Speed the bar moves back and forth")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(5)]
        public float CylonMove
        {
            get { return _CylonMove; }
            set
            {
                _CylonMove = value;
                Invalidate();
            }
        }

        #endregion //Bar Cylon

        #region Bar Properties

        /// <summary>
        /// The bar type
        /// </summary>
        private eBarType _BarType = eBarType.Bar;

        /// <summary>
        /// Gets or sets the type of the bar.
        /// </summary>
        /// <value>The type of the bar.</value>
        [Category("Bar")]
        [Description("Get or Set the Minimum Value")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(eBarType.Bar)]
        public eBarType BarType
        {
            get { return _BarType; }
            set
            {
                _BarType = value;
                if (value == eBarType.Bar) CylonRun = false;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar length
        /// </summary>
        private eBarLength _BarLength = eBarLength.Full;

        /// <summary>
        /// Gets or sets the length of the bar.
        /// </summary>
        /// <value>The length of the bar.</value>
        [Category("Bar")]
        [Description("Get or Set if the Progress Bar Expands with the Value")]
        [DefaultValue(eBarLength.Full)]
        public eBarLength BarLength
        {
            get { return _BarLength; }
            set
            {
                _BarLength = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar length value
        /// </summary>
        private short _BarLengthValue = 25;

        /// <summary>
        /// Gets or sets the bar length value.
        /// </summary>
        /// <value>The bar length value.</value>
        [Category("Bar")]
        [Description("Get or Set Length of the bar in Fixed BarLength mode or Cylon Mode")]
        [DefaultValue(25)]
        public short BarLengthValue
        {
            get { return _BarLengthValue; }
            set
            {
                _BarLengthValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The fill direction
        /// </summary>
        private eFillDirection _FillDirection = eFillDirection.Up_Right;

        /// <summary>
        /// Gets or sets the fill direction.
        /// </summary>
        /// <value>The fill direction.</value>
        [Category("Bar")]
        [Description("Get or Set the direction the Progress Bar will fill")]
        [DefaultValue(eFillDirection.Up_Right)]
        public eFillDirection FillDirection
        {
            get { return _FillDirection; }
            set
            {
                _FillDirection = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The orientation
        /// </summary>
        private eOrientation _Orientation = eOrientation.Horizontal;

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Bar")]
        [Description("Get or Set the Progress Bar's Orientation")]
        [DefaultValue(eOrientation.Horizontal)]
        public eOrientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bar padding
        /// </summary>
        private Padding _BarPadding;

        /// <summary>
        /// Gets or sets the bar padding.
        /// </summary>
        /// <value>The bar padding.</value>
        [Description("The Solid Color to fill the Bar")]
        [Category("Bar")]
        public Padding BarPadding
        {
            get { return _BarPadding; }
            set
            {
                _BarPadding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Min;

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [Category("Bar")]
        [Description("Get or Set the Minimum Value")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(0)]
        public int Min
        {
            get { return _Min; }
            set
            {
                _Min = value;
                if (value < value) value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Max = 100;

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [Category("Bar")]
        [Description("Get or Set the Maximum Value")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(100)]
        public int Max
        {
            get { return _Max; }
            set
            {
                _Max = value;
                if (value > value) value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 50;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Category("Bar")]
        [Description("Get or Set the Bar's Value")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(50)]
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > Max) value = Max;
                if (value < Min) value = Min;
                _Value = value;
                Refresh();
            }
        }

        /// <summary>
        /// Increments the specified inc.
        /// </summary>
        /// <param name="Inc">The inc.</param>
        public void Increment(int Inc = 1)
        {
            if (Value < Max) Value += Inc;
        }

        /// <summary>
        /// Decrements the specified inc.
        /// </summary>
        /// <param name="Inc">The inc.</param>
        public void Decrement(int Inc = 1)
        {
            if (Value > Min) Value -= Inc;
        }

        /// <summary>
        /// Resets the bar.
        /// </summary>
        /// <param name="ToMinimumValue">if set to <c>true</c> [to minimum value].</param>
        public void ResetBar(bool ToMinimumValue = true)
        {
            if (ToMinimumValue)
                Value = Min;
            else
                Value = Max;
        }

        /// <summary>
        /// Gets the value percent.
        /// </summary>
        /// <value>The value percent.</value>
        [Category("Bar")]
        [Description("Percent to of value")]
        public int ValuePercent => Convert.ToInt32((Value - Min) / (double) (Max - Min) * 100);

        #endregion //Bar Properties

        #region Hidden Properties

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
//INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
                return new Color();
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the border style of the user control.
        /// </summary>
        /// <value>The border style.</value>
        [Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get
            {
//INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
                return 0;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if [allow drop]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
//INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
                return false;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets how the control performs validation when the user changes focus to another control.
        /// </summary>
        /// <value>The automatic validate.</value>
        [Browsable(false)]
        public override AutoValidate AutoValidate
        {
            get
            {
//INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
                return 0;
            }
            set { }
        }

        #endregion

        #region ToString

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            switch (TextShow)
            {
                case eTextShow.None:
                    return "";
                case eTextShow.Value:
                    return Value.ToString();
                case eTextShow.ValueOfMax:
                    return string.Format("{0} of {1}", Value, Max);
                case eTextShow.Percent:
                    return ValuePercent + "%";
                case eTextShow.FormatString:
                    return string.Format(TextFormat, Value, ValuePercent, Max);
                default:
                    return "";
            }
        }

        #endregion

        #endregion //Properties

        #region Paint Events

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (BackgroundImage == null) pevent.Graphics.Clear(BarBackColor);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = Smoothing;
            e.Graphics.TextRenderingHint = TextRendering;
            var MyPath = new ProgBarPath();
            MyPath = GetPath(DisplayRectangle, ePart.Border);

            //Call the appropriate Paint Method to draw the bar
            switch (BarType)
            {
                case eBarType.Bar:
                    if (Value > 0) PaintBar(e);

                    break;
                case eBarType.CylonBar:
                    PaintCylonBar(e);

                    break;
                case eBarType.CylonGlider:
                    PaintCylonGlider(e);

                    break;
            }

            //Create the Border Graphicspath and Draw it
            if (_BorderWidth > 0)
            {
                using (var MyPen = new Pen(BorderColor, BorderWidth))
                {
                    MyPen.Alignment = PenAlignment.Inset;
                    if (Shape == eShape.Text)
                    {
                        if (ShapeTextRotate != eRotateText.None)
                            using (var mtrx = new Matrix())
                            {
                                mtrx.Rotate(GetRotateAngle(ShapeTextRotate));
                                MyPath.Path.Transform(mtrx);
                            }

                        e.Graphics.Transform = TextMatrix(MyPath);
                    }

                    e.Graphics.DrawPath(MyPen, MyPath.Path);
                    e.Graphics.ResetTransform();
                }

                MyPath = GetPath(DisplayRectangle, ePart.Back);
            }

            //Make a Region from the Graphicspath to clip the shape
            Region = null;

            Region mRegion = null;
            if (Shape == eShape.Text)
            {
                if (ShapeTextRotate != eRotateText.None)
                    using (var mtrx = new Matrix())
                    {
                        mtrx.Rotate(GetRotateAngle(ShapeTextRotate));
                        MyPath.Path.Transform(mtrx);
                    }

                mRegion = new Region(MyPath.Path);
                mRegion.Transform(TextMatrix(MyPath));
            }
            else
            {
                mRegion = new Region(MyPath.Path);
            }

            Region = mRegion;
            //mRegion.Dispose() ' Do not dispose causes errors when loading a form.ShowDialog more than once 

            //Add the Text
            var rect = DisplayRectangle;
            rect.X += 5;
            rect.Y += 1;
            rect.Width -= 10;
            if (TextShow != eTextShow.None && TextPlacement == eTextPlacement.OverBar) PutText(e, rect);
        }

        /// <summary>
        /// Paints the bar.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintBar(PaintEventArgs e)
        {
            var OrientationWidth = 0;
            var EndPosition = 0;
            var StartPosition = 0;
            var LengthOfBar = 0;
            var rect = new Rectangle();
            e.Graphics.SmoothingMode = Smoothing;

            if (Orientation == eOrientation.Horizontal)
                OrientationWidth = Size.Width - BarPadding.Horizontal - 2 * BorderWidth;
            else
                OrientationWidth = Size.Height - BarPadding.Vertical - 2 * BorderWidth;

            if (BarLength == eBarLength.Full)
            {
                LengthOfBar = Convert.ToInt32(OrientationWidth * ((Value - Min) / (double) (Max - Min))) - 1;
                StartPosition = 0;
            }
            else
            {
                EndPosition = Convert.ToInt32(OrientationWidth * ((Value - Min) / (double) (Max - Min)));
                LengthOfBar = BarLengthValue;
                StartPosition = EndPosition - BarLengthValue;
                if (StartPosition < BorderWidth) StartPosition = 1;
            }

            if (Orientation == eOrientation.Horizontal)
            {
                if (FillDirection == eFillDirection.Down_Left)
                    rect = new Rectangle(
                        OrientationWidth - StartPosition - LengthOfBar + BarPadding.Left + BorderWidth - 1,
                        BarPadding.Top + BorderWidth, LengthOfBar, Height - BarPadding.Vertical - 2 * BorderWidth - 1);
                else
                    rect = new Rectangle(StartPosition + BarPadding.Left + BorderWidth, BarPadding.Top + BorderWidth,
                        LengthOfBar, Height - BarPadding.Vertical - 2 * BorderWidth - 1);
            }
            else
            {
                if (FillDirection == eFillDirection.Down_Left)
                    rect = new Rectangle(BarPadding.Top + BorderWidth, StartPosition + BarPadding.Left + BorderWidth,
                        Width - BarPadding.Horizontal - 2 * BorderWidth - 1, LengthOfBar);
                else
                    rect = new Rectangle(BarPadding.Top + BorderWidth,
                        OrientationWidth - StartPosition - LengthOfBar + BarPadding.Left + BorderWidth - 1,
                        Width - BarPadding.Horizontal - 2 * BorderWidth - 1, LengthOfBar);
            }

            e.Graphics.FillPath(GetBrush(ref rect), GetPath(rect, ePart.Bar).Path);

            rect.X += 5;
            rect.Y += 1;
            rect.Width -= 10;
            if (TextShow != eTextShow.None && TextPlacement == eTextPlacement.OnBar) PutText(e, rect);
        }

        /// <summary>
        /// Paints the cylon bar.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintCylonBar(PaintEventArgs e)
        {
            var rect = new Rectangle();
            e.Graphics.SmoothingMode = Smoothing;

            if (Orientation == eOrientation.Horizontal)
                rect = new Rectangle(Convert.ToInt32(CylonPosition + BarPadding.Left), 0 + BarPadding.Top,
                    BarLengthValue - 1, Height - 1 - BarPadding.Vertical);
            else
                rect = new Rectangle(0 + BarPadding.Left, Convert.ToInt32(CylonPosition + BarPadding.Top),
                    Width - 1 - BarPadding.Horizontal, BarLengthValue - 1);

            e.Graphics.FillPath(GetBrush(ref rect), GetPath(rect, ePart.Bar).Path);
        }

        /// <summary>
        /// Paints the cylon glider.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintCylonGlider(PaintEventArgs e)
        {
            var rect = new Rectangle(BarPadding.Left, BarPadding.Top, Width - BarPadding.Horizontal,
                Height - BarPadding.Vertical);
            e.Graphics.SmoothingMode = Smoothing;

            LinearGradientBrush br = null;
            rect.Inflate(1, 1);
            if (Orientation == eOrientation.Horizontal)
                br = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.Right, rect.Y), Color.White,
                    Color.White);
            else
                br = new LinearGradientBrush(new Point(rect.X, rect.Bottom), new Point(rect.X, rect.Top + 1),
                    Color.White, Color.White);

            var blend = new ColorBlend();
            blend.Colors = BarColorBlend.iColor;
            blend.Positions = BarColorBlend.iPoint;
            if (blend.Positions.Length > 2)
                blend.Colors = new[]
                {
                    BarColorBlend.iColor[0], BarColorBlend.iColor[0], BarColorBlend.iColor[1], BarColorBlend.iColor[2],
                    BarColorBlend.iColor[2]
                };
            else
                blend.Colors = new[] {BarColorSolid, BarColorSolid, BarColorSolidB, BarColorSolid, BarColorSolid};
            blend.Positions = new[]
            {
                0F, Convert.ToSingle(CylonGPosition - 0.3), CylonGPosition, Convert.ToSingle(CylonGPosition + 0.3), 1F
            };
            br.InterpolationColors = blend;

            e.Graphics.FillPath(br, GetPath(rect, ePart.Bar).Path);
        }

        #endregion //Paint Events

        #region Paint Helpers

        /// <summary>
        /// Texts the matrix.
        /// </summary>
        /// <param name="mp">The mp.</param>
        /// <returns>Matrix.</returns>
        public static Matrix TextMatrix(ProgBarPath mp)
        {
            //Scale the Path to fit the Rectangle
            var text_rectf = mp.Path.GetBounds();
            PointF[] target_pts =
            {
                new PointF(mp.Rect.Left, mp.Rect.Top),
                new PointF(mp.Rect.Right, mp.Rect.Top),
                new PointF(mp.Rect.Left, mp.Rect.Bottom)
            };

            return new Matrix(text_rectf, target_pts);
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <param name="PathRect">The path rect.</param>
        /// <param name="Part">The part.</param>
        /// <param name="ShowDotBorder">The show dot border.</param>
        /// <returns>ProgBarPath.</returns>
        public ProgBarPath GetPath(Rectangle PathRect, ePart Part, short ShowDotBorder = 0)
        {
            var pPath = new ProgBarPath();
            pPath.Path = new GraphicsPath();
            switch (Shape)
            {
                case eShape.Rectangle:
                {
                    if (Part == ePart.Border)
                        pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width - 1 - ShowDotBorder,
                            PathRect.Height - 1 - ShowDotBorder);
                    else
                        pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height);

                    var barCorners = new CornersProperty(
                        (short) (Corners.LowerLeft - BorderWidth),
                        (short) (Corners.LowerRight - BorderWidth),
                        (short) (Corners.UpperLeft - BorderWidth),
                        (short) (Corners.UpperRight - BorderWidth));

                    switch (CornersApply)
                    {
                        case eCornersApply.Border:
                            switch (Part)
                            {
                                case ePart.Back:
                                case ePart.Border:
                                    pPath.Path = GetRoundedRectPath(pPath.Rect, Corners);
                                    break;
                                case ePart.Bar:
                                    pPath.Path.AddRectangle(pPath.Rect);
                                    break;
                            }

                            break;
                        case eCornersApply.Bar:
                            switch (Part)
                            {
                                case ePart.Back:
                                case ePart.Border:
                                    pPath.Path.AddRectangle(pPath.Rect);
                                    break;
                                case ePart.Bar:
                                    pPath.Path = GetRoundedRectPath(pPath.Rect, barCorners);
                                    break;
                            }

                            break;
                        case eCornersApply.Both:
                            switch (Part)
                            {
                                case ePart.Back:
                                case ePart.Border:
                                    pPath.Path = GetRoundedRectPath(pPath.Rect, Corners);
                                    break;
                                case ePart.Bar:
                                    pPath.Path = GetRoundedRectPath(pPath.Rect, barCorners);
                                    break;
                            }

                            break;
                    }


                    break;
                }
                case eShape.Ellipse:
                {
                    switch (Part)
                    {
                        case ePart.Border:
                            pPath.Rect = new Rectangle(1 + ShowDotBorder, 1 + ShowDotBorder,
                                PathRect.Width - 2 - ShowDotBorder, PathRect.Height - 3 - ShowDotBorder);
                            pPath.Path.AddEllipse(pPath.Rect);
                            break;
                        case ePart.Back:
                            pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height - 1);
                            pPath.Path.AddEllipse(pPath.Rect);
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(pPath.Rect);

                            break;
                    }


                    break;
                }
                case eShape.TriangleLeft:
                {
                    pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height);
                    Point[] triPts = null;
                    switch (Part)
                    {
                        case ePart.Border:
                            triPts = new[]
                            {
                                new Point(pPath.Rect.Left + ShowDotBorder, Convert.ToInt32(pPath.Rect.Height / 2.0)),
                                new Point(pPath.Rect.Right - 1 - ShowDotBorder, 1 + ShowDotBorder),
                                new Point(pPath.Rect.Right - 1 - ShowDotBorder, pPath.Rect.Bottom - 1 - ShowDotBorder)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Back:
                            triPts = new[]
                            {
                                new Point(pPath.Rect.Left, Convert.ToInt32(pPath.Rect.Height / 2.0)),
                                new Point(Convert.ToInt32(pPath.Rect.Right), 0),
                                new Point(Convert.ToInt32(pPath.Rect.Right), pPath.Rect.Bottom)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(pPath.Rect);
                            break;
                    }

                    break;
                }
                case eShape.TriangleRight:
                {
                    pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height);
                    Point[] triPts = null;

                    switch (Part)
                    {
                        case ePart.Border:
                            triPts = new[]
                            {
                                new Point(0, 1 + ShowDotBorder),
                                new Point(0, pPath.Rect.Bottom - 1 - ShowDotBorder),
                                new Point(pPath.Rect.Right - ShowDotBorder, Convert.ToInt32(pPath.Rect.Height / 2.0))
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Back:
                            triPts = new[]
                            {
                                new Point(0, 0),
                                new Point(0, pPath.Rect.Bottom),
                                new Point(pPath.Rect.Right, Convert.ToInt32(pPath.Rect.Height / 2.0))
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(pPath.Rect);
                            break;
                    }

                    break;
                }
                case eShape.TriangleUp:
                {
                    pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height);
                    Point[] triPts = null;

                    switch (Part)
                    {
                        case ePart.Border:
                            triPts = new[]
                            {
                                new Point(Convert.ToInt32(pPath.Rect.Width / 2.0), pPath.Rect.Top + ShowDotBorder),
                                new Point(pPath.Rect.Left + 2 + ShowDotBorder, pPath.Rect.Bottom - 1 - ShowDotBorder),
                                new Point(pPath.Rect.Right - 2 - ShowDotBorder, pPath.Rect.Bottom - 1 - ShowDotBorder)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Back:
                            triPts = new[]
                            {
                                new Point(Convert.ToInt32(pPath.Rect.Width / 2.0),
                                    Convert.ToInt32(pPath.Rect.Top / 2.0)),
                                new Point(pPath.Rect.Left, pPath.Rect.Bottom),
                                new Point(pPath.Rect.Right, pPath.Rect.Bottom)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(pPath.Rect);
                            break;
                    }

                    break;
                }
                case eShape.TriangleDown:
                {
                    pPath.Rect = new Rectangle(PathRect.X, PathRect.Y, PathRect.Width, PathRect.Height);
                    Point[] triPts = null;

                    switch (Part)
                    {
                        case ePart.Border:
                            triPts = new[]
                            {
                                new Point(Convert.ToInt32(pPath.Rect.Width / 2.0), pPath.Rect.Bottom - ShowDotBorder),
                                new Point(pPath.Rect.Left + 1 + ShowDotBorder, 0),
                                new Point(pPath.Rect.Right - 1 - ShowDotBorder, 0)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Back:
                            triPts = new[]
                            {
                                new Point(Convert.ToInt32(pPath.Rect.Width / 2.0), Convert.ToInt32(pPath.Rect.Bottom)),
                                new Point(pPath.Rect.Left, 0),
                                new Point(pPath.Rect.Right, 0)
                            };
                            pPath.Path.AddPolygon(triPts);
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(pPath.Rect);
                            break;
                    }

                    break;
                }
                case eShape.Text:
                {
                    switch (Part)
                    {
                        case ePart.Border:
                        case ePart.Back:
                            pPath.Rect = new Rectangle(1, 1, PathRect.Width - 2, PathRect.Height - 2);

                            // Make the StringFormat.
                            var sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;

                            // Add the text to the GraphicsPath.
                            pPath.Path.AddString(ShapeText, ShapeTextFont.FontFamily, Convert.ToInt32(FontStyle.Bold),
                                pPath.Rect.Height, new PointF(0F, 0F), sf);

                            sf.Dispose();
                            break;
                        case ePart.Bar:
                            pPath.Rect = PathRect;
                            pPath.Path.AddRectangle(PathRect);

                            break;
                    }

                    break;
                }
            }

            return pPath;
        }

        /// <summary>
        /// Puts the text.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="TextRect">The text rect.</param>
        public void PutText(PaintEventArgs e, Rectangle TextRect)
        {
            using (var sf = new StringFormat())
            {
                e.Graphics.SmoothingMode = Smoothing;
                e.Graphics.TextRenderingHint = TextRendering;
                sf.Alignment = TextAlignment;
                sf.LineAlignment = TextAlignmentVert;
                if (!TextWrap) sf.FormatFlags = StringFormatFlags.NoWrap;
                if (TextShadow)
                {
                    var ShadowRect = TextRect;
                    ShadowRect.Offset(1, 1);
                    if (TextRotate != eRotateText.None) ShadowRect = RotateRect(e, ShadowRect, TextRotate);
                    e.Graphics.DrawString(ToString(), Font, new SolidBrush(TextShadowColor), ShadowRect, sf);
                    e.Graphics.ResetTransform();
                }

                if (TextRotate != eRotateText.None) TextRect = RotateRect(e, TextRect, TextRotate);
                e.Graphics.DrawString(ToString(), Font, new SolidBrush(ForeColor), TextRect, sf);
            }

            e.Graphics.ResetTransform();
        }

        /// <summary>
        /// Rotates the rect.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="TabRect">The tab rect.</param>
        /// <param name="Rotate">The rotate.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle RotateRect(PaintEventArgs e, Rectangle TabRect, eRotateText Rotate)
        {
            var cp = new PointF(TabRect.Left + TabRect.Width / 2, TabRect.Top + TabRect.Height / 2);
            e.Graphics.TranslateTransform(cp.X, cp.Y);
            e.Graphics.RotateTransform(GetRotateAngle(Rotate));
            return new Rectangle(-(TabRect.Height / 2), -(TabRect.Width / 2), TabRect.Height, TabRect.Width);
        }

        /// <summary>
        /// Gets the rotate angle.
        /// </summary>
        /// <param name="Rotate">The rotate.</param>
        /// <returns>System.Int16.</returns>
        public short GetRotateAngle(eRotateText Rotate)
        {
            var RotateAngle = 0F;
            switch (Rotate)
            {
                case eRotateText.Left:
                    RotateAngle = 270F;
                    break;
                case eRotateText.Right:
                    RotateAngle = 90F;
                    break;
            }

            return Convert.ToInt16(RotateAngle);
        }

        /// <summary>
        /// Gets the brush.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Brush.</returns>
        private Brush GetBrush(ref Rectangle rect)
        {
            try
            {
                switch (BarStyleFill)
                {
                    case eBarStyle.Solid:
                    {
                        return new SolidBrush(BarColorSolid);
                    }
                    case eBarStyle.Hatch:
                    {
                        return new HatchBrush(BarStyleHatch, BarColorSolid, BarColorSolidB);
                    }
                    case eBarStyle.GradientLinear:
                    {
                        var lrect = rect;
                        lrect.Y -= 1;
                        lrect.Height += 1;
                        var br = new LinearGradientBrush(lrect, Color.White, Color.White, BarStyleLinear);
                        var cb = new ColorBlend();
                        cb.Colors = BarColorBlend.iColor;
                        cb.Positions = BarColorBlend.iPoint;
                        br.InterpolationColors = cb;
                        return br;
                    }
                    case eBarStyle.GradientPath:
                    {
                        var OffsetX = 0F;
                        var OffsetY = 0F;
                        var CylonOffsetX = 0F;
                        var CylonOffsetY = 0F;
                        if (BarType == eBarType.CylonBar)
                        {
                            if (Orientation == eOrientation.Horizontal)
                                CylonOffsetX = CylonPosition;
                            else
                                CylonOffsetY = CylonPosition;
                        }
                        else
                        {
                            if (Orientation == eOrientation.Horizontal)
                                OffsetX = rect.X;
                            else
                                OffsetY = rect.Y;
                        }

                        var lrect = rect;
                        lrect.Width += 1;
                        lrect.Height += 1;
                        var br = new PathGradientBrush(GetPath(lrect, ePart.Bar).Path);
                        var cb = new ColorBlend();
                        cb.Colors = BarColorBlend.iColor;
                        cb.Positions = BarColorBlend.iPoint;
                        br.FocusScales = FocalPoints.FocusScales;
                        br.CenterPoint = new PointF(
                            FocalPoints.CenterPoint.X * Convert.ToSingle(rect.Width) + OffsetX + BarPadding.Left +
                            BorderWidth + CylonOffsetX,
                            FocalPoints.CenterPoint.Y * Convert.ToSingle(rect.Height) + OffsetY + BarPadding.Top +
                            BorderWidth + CylonOffsetY);
                        br.InterpolationColors = cb;
                        return br;
                    }
                    case eBarStyle.Texture:
                    {
                        var br = new TextureBrush(BarStyleTexture);
                        br.WrapMode = BarStyleWrapMode;
                        return br;
                    }
                }
            }
            catch (Exception ex)
            {
                return new SolidBrush(BarColorSolid);
            }

            return new SolidBrush(BarColorSolid);
        }

        /// <summary>
        /// Gets the rounded rect path.
        /// </summary>
        /// <param name="BaseRect">The base rect.</param>
        /// <param name="rCorners">The r corners.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath GetRoundedRectPath(RectangleF BaseRect, CornersProperty rCorners)
        {
            var ArcRect = new RectangleF();
            var MyPath = new GraphicsPath();
            if (rCorners.All == -1)
            {
                // top left arc
                if (rCorners.UpperLeft == 0)
                {
                    MyPath.AddLine(BaseRect.X, BaseRect.Y, BaseRect.X, BaseRect.Y);
                }
                else
                {
                    ArcRect = new RectangleF(BaseRect.Location,
                        new SizeF(rCorners.UpperLeft * 2, rCorners.UpperLeft * 2));
                    MyPath.AddArc(ArcRect, 180F, 90F);
                }

                // top right arc
                if (rCorners.UpperRight == 0)
                {
                    MyPath.AddLine(BaseRect.X + rCorners.UpperLeft, BaseRect.Y, BaseRect.Right - rCorners.UpperRight,
                        BaseRect.Top);
                }
                else
                {
                    ArcRect = new RectangleF(BaseRect.Location,
                        new SizeF(rCorners.UpperRight * 2, rCorners.UpperRight * 2));
                    ArcRect.X = BaseRect.Right - rCorners.UpperRight * 2;
                    MyPath.AddArc(ArcRect, 270F, 90F);
                }

                // bottom right arc
                if (rCorners.LowerRight == 0)
                {
                    MyPath.AddLine(BaseRect.Right, BaseRect.Top + rCorners.UpperRight, BaseRect.Right,
                        BaseRect.Bottom - rCorners.LowerRight);
                }
                else
                {
                    ArcRect = new RectangleF(BaseRect.Location,
                        new SizeF(rCorners.LowerRight * 2, rCorners.LowerRight * 2));
                    ArcRect.Y = BaseRect.Bottom - rCorners.LowerRight * 2;
                    ArcRect.X = BaseRect.Right - rCorners.LowerRight * 2;
                    MyPath.AddArc(ArcRect, 0F, 90F);
                }

                // bottom left arc
                if (rCorners.LowerLeft == 0)
                {
                    MyPath.AddLine(BaseRect.Right - rCorners.LowerRight, BaseRect.Bottom,
                        BaseRect.X - rCorners.LowerLeft, BaseRect.Bottom);
                }
                else
                {
                    ArcRect = new RectangleF(BaseRect.Location,
                        new SizeF(rCorners.LowerLeft * 2, rCorners.LowerLeft * 2));
                    ArcRect.Y = BaseRect.Bottom - rCorners.LowerLeft * 2;
                    MyPath.AddArc(ArcRect, 90F, 90F);
                }

                MyPath.CloseFigure();
            }
            else
            {
                if (rCorners.All == 0)
                {
                    MyPath.AddRectangle(BaseRect);
                }
                else
                {
                    ArcRect = new RectangleF(BaseRect.Location, new SizeF(rCorners.All * 2, rCorners.All * 2));
                    // top left arc
                    MyPath.AddArc(ArcRect, 180F, 90F);

                    // top right arc
                    ArcRect.X = BaseRect.Right - rCorners.All * 2;
                    MyPath.AddArc(ArcRect, 270F, 90F);

                    // bottom right arc
                    ArcRect.Y = BaseRect.Bottom - rCorners.All * 2;
                    MyPath.AddArc(ArcRect, 0F, 90F);

                    // bottom left arc
                    ArcRect.X = BaseRect.Left;
                    MyPath.AddArc(ArcRect, 90F, 90F);
                }

                MyPath.CloseFigure();
            }

            return MyPath;
        }

        #endregion //Paint Helpers

        #region Cylon

        /// <summary>
        /// Handles the Tick event of the TimerCylon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerCylon_Tick(object sender, EventArgs e)
        {
            switch (BarType)
            {
                case eBarType.CylonBar:
                    if (Orientation == eOrientation.Horizontal)
                    {
                        if (CylonPosition + BarLengthValue >= Width) CylonDirection = -_CylonMove;
                        if (CylonPosition <= 0F) CylonDirection = _CylonMove;
                    }
                    else
                    {
                        if (CylonPosition + BarLengthValue >= Height) CylonDirection = -_CylonMove;
                        if (CylonPosition <= 0F) CylonDirection = _CylonMove;
                    }

                    CylonPosition += CylonDirection;

                    break;
                case eBarType.CylonGlider:
                    CylonGPosition += CylonGDelta * _CylonMove;
                    if (CylonGPosition > 1 || CylonGPosition < 0) CylonGDelta = -CylonGDelta;
                    break;
            }

            Refresh();
        }

        /// <summary>
        /// The timer cylon
        /// </summary>
        internal System.Windows.Forms.Timer TimerCylon;

        #endregion //Cylon
    }

    #region Dropdown Editors

    #region HatchStyleEditor

    /// <summary>
    /// Class HatchStyleEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class HatchStyleEditor : UITypeEditor
    {
        /// <summary>
        /// The smart context
        /// </summary>
        private ITypeDescriptorContext SmartContext; //SmartTag Workaround

        /// <summary>
        /// Gets a value indicating whether drop-down editors should be resizable by the user.
        /// </summary>
        /// <value><c>true</c> if this instance is drop down resizable; otherwise, <c>false</c>.</value>
        public override bool IsDropDownResizable => base.IsDropDownResizable;

        // Indicate that we display a dropdown.
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // Edit a line style
        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Get an IWindowsFormsEditorService object.
            var editor_service = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (editor_service == null) return base.EditValue(context, provider, value);

            // Pass the UI editor the current property value
            var Instance = new ZeroitProgBarPlus();
            if (context.Instance.GetType() == typeof(ZeroitProgBarPlus))
                Instance = (ZeroitProgBarPlus) context.Instance;
            else
                Instance = ((ProgBarPlusActionList) context.Instance).CurrProgBarPlus;

            // Convert the value into a BorderStyles value.
            var hatch_style = (HatchStyle) value;

            // Make the editing control.
            var editor_control = new HatchStyleListBox(hatch_style.ToString(), Instance.BarColorSolid,
                Instance.BarColorSolidB, editor_service);
            // Display the editing control.
            editor_service.DropDownControl(editor_control);

            // Save the new results.
            return (HatchStyle) Enum.Parse(typeof(HatchStyle), editor_control.Text, true);
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            SmartContext = context; //store reference for use in PaintValue
            return true;
        }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            var hatch = (HatchStyle) e.Value;
            // Pass the UI editor the current property value
            var Instance = new ZeroitProgBarPlus();
            //e.context only works properly in the Propertygrid.
            //When comming from the SmartTag e.context becomes null and 
            //will cause a fatal crash of the IDE.
            //So to get around the null value error I captured a reference to the context
            //in the SmartContext variable in the GetPaintValueSupported function 
            if (e.Context != null)
                Instance = (ZeroitProgBarPlus) e.Context.Instance;
            else
                Instance = ((ProgBarPlusActionList) SmartContext.Instance).CurrProgBarPlus;

            using (Brush br = new HatchBrush(hatch, Instance.BarColorSolid, Instance.BarColorSolidB))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }
    }

    #region HatchStyleListBox Custom Control

    /// <summary>
    /// Class HatchStyleListBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ListBox" />
    [ToolboxItem(false)]
    public class HatchStyleListBox : ListBox
    {
        //INSTANT C# NOTE: Converted event handler wireups:
        /// <summary>
        /// The events subscribed
        /// </summary>
        private bool EventsSubscribed;

        // The editor service displaying this control.
        /// <summary>
        /// The m editor service
        /// </summary>
        private readonly IWindowsFormsEditorService m_EditorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HatchStyleListBox"/> class.
        /// </summary>
        /// <param name="hatch_style">The hatch style.</param>
        /// <param name="ColorFore">The color fore.</param>
        /// <param name="ColorBack">The color back.</param>
        /// <param name="editor_service">The editor service.</param>
        public HatchStyleListBox(string hatch_style, Color ColorFore, Color ColorBack,
            IWindowsFormsEditorService editor_service)
        {
            m_EditorService = editor_service;
            // Make items for each LineStyles value.
            Items.Clear();
            var hatchNames = Enum.GetNames(typeof(HatchStyle));
            Array.Sort(hatchNames);
            foreach (var hs in hatchNames) Items.Add(hs);
            SelectedIndex = FindStringExact(hatch_style);
            ColorFore = ColorFore;
            ColorBack = ColorBack;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 21;
            Height = 200;
            Width = 200;
            SubscribeToEvents();
        }

        /// <summary>
        /// Gets or sets the color fore.
        /// </summary>
        /// <value>The color fore.</value>
        public Color ColorFore { get; set; }

        /// <summary>
        /// Gets or sets the color back.
        /// </summary>
        /// <value>The color back.</value>
        public Color ColorBack { get; set; }

        // When the user selects an item, close the dropdown.
        /// <summary>
        /// Handles the Click event of the HatchStyleListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HatchStyleListBox_Click(object sender, EventArgs e)
        {
            if (m_EditorService != null) m_EditorService.CloseDropDown();
        }

        // Draw a menu item.
        /// <summary>
        /// Handles the DrawItem event of the HatchStyleListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        private void HatchStyleListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index != -1 && Items.Count > 0)
            {
                var g = e.Graphics;
                var sample = e.Bounds;
                var sampletext = e.Bounds;

                sample.Width = 40;
                sample.Inflate(0, -3);
                sampletext.Width = sampletext.Width - sample.Width - 2;
                sampletext.X = sample.Right + 2;

                var displayText = Items[e.Index].ToString();
                var hs = (HatchStyle) Enum.Parse(typeof(HatchStyle), displayText, true);
                using (var hb = new HatchBrush(hs, ColorFore, ColorBack))
                {
                    using (var sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        if ((e.State & DrawItemState.Focus) == 0)
                        {
                            g.FillRectangle(new SolidBrush(SystemColors.Window), sampletext);
                            g.DrawString(displayText, Font, new SolidBrush(SystemColors.WindowText), sampletext, sf);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(SystemColors.Highlight), sampletext);
                            g.DrawString(displayText, Font, new SolidBrush(SystemColors.HighlightText), sampletext, sf);
                        }
                    }

                    g.FillRectangle(hb, sample);
                }

                g.DrawRectangle(new Pen(Color.Black, 1F), sample);
            }

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Subscribes to events.
        /// </summary>
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            EventsSubscribed = true;

            Click += HatchStyleListBox_Click;
            DrawItem += HatchStyleListBox_DrawItem;
        }
    }

    #endregion //HatchStyleListBox Custom Control

    #endregion //HatchStyleEditor

    #region BlendTypeEditor - UITypeEditor

    #region cBlendItems

    /// <summary>
    /// Class cBlendItems.
    /// </summary>
    public class cBlendItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cBlendItems"/> class.
        /// </summary>
        public cBlendItems()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cBlendItems"/> class.
        /// </summary>
        /// <param name="Color">The color.</param>
        /// <param name="Pt">The pt.</param>
        public cBlendItems(Color[] Color, float[] Pt)
        {
            iColor = Color;
            iPoint = Pt;
        }

        /// <summary>
        /// Gets or sets the color of the i.
        /// </summary>
        /// <value>The color of the i.</value>
        [Description("The Color for the Point")]
        [Category("Appearance")]
        public Color[] iColor { get; set; }

        /// <summary>
        /// Gets or sets the i point.
        /// </summary>
        /// <value>The i point.</value>
        [Description("The Color for the Point")]
        [Category("Appearance")]
        public float[] iPoint { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "BlendItems";
        }
    }

    #endregion //cBlendItems

    /// <summary>
    /// Class BlendTypeEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class BlendTypeEditor : UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null) return UITypeEditorEditStyle.DropDown;
            return base.GetEditStyle(context);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && provider != null)
            {
                // Access the property browser's UI display service, IWindowsFormsEditorService
                var editorService =
                    (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    // Create an instance of the UI editor, passing a reference to the editor service
                    var dropDownEditor = new DropdownColorBlender(editorService);

                    // Pass the UI editor the current property value
                    var Instance = new ZeroitProgBarPlus();
                    if (context.Instance.GetType() == typeof(ZeroitProgBarPlus))
                        Instance = (ZeroitProgBarPlus) context.Instance;
                    else
                        Instance = ((ProgBarPlusActionList) context.Instance).CurrProgBarPlus;


                    switch (Instance.Shape)
                    {
                        case ZeroitProgBarPlus.eShape.Ellipse:
                            dropDownEditor.BlendPathShape = DropdownColorBlender.eBlendPathShape.Ellipse;
                            break;
                        case ZeroitProgBarPlus.eShape.Rectangle:
                        case ZeroitProgBarPlus.eShape.Text:
                            dropDownEditor.BlendPathShape = DropdownColorBlender.eBlendPathShape.Rectangle;
                            break;
                        default:
                            dropDownEditor.BlendPathShape = DropdownColorBlender.eBlendPathShape.Triangle;
                            break;
                    }

                    if (Instance.BarStyleFill == ZeroitProgBarPlus.eBarStyle.GradientPath)
                    {
                        dropDownEditor.BlendGradientType = DropdownColorBlender.eBlendGradientType.Path;
                        dropDownEditor.FocalPoints =
                            new cFocalPoints(
                                new PointF(Instance.FocalPoints.CenterPoint.X, Instance.FocalPoints.CenterPoint.Y),
                                Instance.FocalPoints.FocusScales);
                    }
                    else
                    {
                        dropDownEditor.BlendGradientType = DropdownColorBlender.eBlendGradientType.Linear;
                        dropDownEditor.BlendGradientMode = Instance.BarStyleLinear;
                    }


                    dropDownEditor.LoadABlend(Instance.BarColorBlend);

                    // Display the UI editor
                    editorService.DropDownControl(dropDownEditor);

                    // Return the new property value from the editor
                    return new cBlendItems(dropDownEditor.BlendColors, dropDownEditor.BlendPositions);
                }
            }

            return base.EditValue(context, provider, value);
        }

        // Indicate that we draw values in the Properties window.
        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // Draw a BorderStyles value.
        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            // Erase the area.
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);

            // Draw the sample.
            var cblnd = (cBlendItems) e.Value;
            using (var br = new LinearGradientBrush(e.Bounds, Color.Black, Color.Black, LinearGradientMode.Horizontal))
            {
                var cb = new ColorBlend();
                cb.Colors = cblnd.iColor;
                cb.Positions = cblnd.iPoint;
                br.InterpolationColors = cb;
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }
    }

    #endregion //BlendTypeEditor - UITypeEditor

    #endregion //Dropdown Editors

    #region Modal Form Editors

    #region FocalTypeEditor

    #region cFocalPoints

    /// <summary>
    /// Class cFocalPoints.
    /// </summary>
    public class cFocalPoints
    {
        /// <summary>
        /// The center point
        /// </summary>
        private PointF _CenterPoint = new PointF(0.5F, 0.5F);

        /// <summary>
        /// The focus scales
        /// </summary>
        private PointF _FocusScales = new PointF(0F, 0F);

        /// <summary>
        /// Initializes a new instance of the <see cref="cFocalPoints"/> class.
        /// </summary>
        public cFocalPoints()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cFocalPoints"/> class.
        /// </summary>
        /// <param name="Cx">The cx.</param>
        /// <param name="Cy">The cy.</param>
        /// <param name="Fx">The fx.</param>
        /// <param name="Fy">The fy.</param>
        public cFocalPoints(float Cx, float Cy, float Fx, float Fy)
        {
            CenterPoint = new PointF(Cx, Cy);
            FocusScales = new PointF(Fx, Fy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="cFocalPoints"/> class.
        /// </summary>
        /// <param name="ptC">The pt c.</param>
        /// <param name="ptF">The pt f.</param>
        public cFocalPoints(PointF ptC, PointF ptF)
        {
            CenterPoint = ptC;
            FocusScales = ptF;
        }

        /// <summary>
        /// Gets or sets the center point.
        /// </summary>
        /// <value>The center point.</value>
        public PointF CenterPoint
        {
            get { return _CenterPoint; }
            set
            {
                if (value.X < 0) value.X = 0F;
                if (value.X > 1) value.X = 1F;
                if (value.Y < 0) value.Y = 0F;
                if (value.Y > 1) value.Y = 1F;
                _CenterPoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the focus scales.
        /// </summary>
        /// <value>The focus scales.</value>
        public PointF FocusScales
        {
            get { return _FocusScales; }
            set
            {
                if (value.X < 0) value.X = 0F;
                if (value.X > 1) value.X = 1F;
                if (value.Y < 0) value.Y = 0F;
                if (value.Y > 1) value.Y = 1F;
                _FocusScales = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("CP={0}, FP={1}", _CenterPoint, _FocusScales);
        }
    }

    #endregion //cFocalPoints

    /// <summary>
    /// Class FocalTypeEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class FocalTypeEditor : UITypeEditor
    {
        // Indicate that we display a modal dialog.
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        // Edit a Selected value.
        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Get the editor service.
            var editor_service = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (editor_service == null) return value;

            var Instance = new ZeroitProgBarPlus();
            if (context.Instance.GetType() == typeof(ZeroitProgBarPlus))
                Instance = (ZeroitProgBarPlus) context.Instance;
            else
                Instance = ((ProgBarPlusActionList) context.Instance).CurrProgBarPlus;

            var dlg = new dlgFocalPoints();

            // Prepare the editing dialog.
            var ratio = 0F;
            var BarWidth = 0;
            var BarHeight = 0;
            if (Instance.BarType == ZeroitProgBarPlus.eBarType.CylonBar)
            {
                if (Instance.Orientation == ZeroitProgBarPlus.eOrientation.Horizontal)
                {
                    BarWidth = Instance.BarLengthValue;
                    BarHeight = Instance.Height;
                }
                else
                {
                    BarWidth = Instance.Width;
                    BarHeight = Instance.BarLengthValue;
                }
            }
            else
            {
                BarWidth = Instance.Width;
                BarHeight = Instance.Height;
            }


            if (BarWidth > BarHeight)
            {
                dlg.TheShape.Height = Convert.ToInt32(dlg.TheShape.Width * (BarHeight / (double) BarWidth));
                dlg.TheShape.Top = Convert.ToInt32((dlg.panShapeHolder.Height - dlg.TheShape.Height) / 2.0);
                ratio = Convert.ToSingle(dlg.TheShape.Height / (double) BarHeight);
            }
            else
            {
                dlg.TheShape.Width = Convert.ToInt32(dlg.TheShape.Height * (BarWidth / (double) BarHeight));
                dlg.TheShape.Left = Convert.ToInt32((dlg.panShapeHolder.Width - dlg.TheShape.Width) / 2.0);
                ratio = Convert.ToSingle(dlg.TheShape.Width / (double) BarWidth);
            }

            dlg.TheShape.Shape = Instance.Shape;
            dlg.TheShape.BarStyleFill = Instance.BarStyleFill;
            dlg.TheShape.BarStyleLinear = Instance.BarStyleLinear;
            dlg.TheShape.BarColorSolid = Instance.BarColorSolid;
            dlg.TheShape.BorderWidth = Instance.BorderWidth;
            dlg.TheShape.BorderColor = Instance.BorderColor;
            dlg.TheShape.BorderStyle = Instance.BorderStyle;
            dlg.TheShape.BarColorBlend = Instance.BarColorBlend;
            dlg.TheShape.Corners = new CornersProperty(Convert.ToInt16(Instance.Corners.LowerLeft * ratio),
                Convert.ToInt16(Instance.Corners.LowerRight * ratio),
                Convert.ToInt16(Instance.Corners.UpperLeft * ratio),
                Convert.ToInt16(Instance.Corners.UpperRight * ratio));
            dlg.TheShape.FocalPoints =
                new cFocalPoints(Instance.FocalPoints.CenterPoint, Instance.FocalPoints.FocusScales);

            // Display the dialog.
            editor_service.ShowDialog(dlg);
            Instance.Refresh();
            // Return the new value.
            return dlg.TheShape.FocalPoints;
        }
    }

    #endregion //FocalTypeEditor

    #endregion //Modal Form Editors

    #region Expandable Border Corners Property Class

    /// <summary>
    /// Class CornersProperty.
    /// </summary>
    [TypeConverter(typeof(CornerConverter))]
    [Serializable]
    public class CornersProperty
    {
        /// <summary>
        /// All
        /// </summary>
        private short _All = -1;
        /// <summary>
        /// The lower left
        /// </summary>
        private short _LowerLeft;
        /// <summary>
        /// The lower right
        /// </summary>
        private short _LowerRight;
        /// <summary>
        /// The upper left
        /// </summary>
        private short _UpperLeft;
        /// <summary>
        /// The upper right
        /// </summary>
        private short _UpperRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="CornersProperty"/> class.
        /// </summary>
        /// <param name="LowerLeft">The lower left.</param>
        /// <param name="LowerRight">The lower right.</param>
        /// <param name="UpperLeft">The upper left.</param>
        /// <param name="UpperRight">The upper right.</param>
        public CornersProperty(short LowerLeft, short LowerRight, short UpperLeft, short UpperRight)
        {
            this.LowerLeft = LowerLeft;
            this.LowerRight = LowerRight;
            this.UpperLeft = UpperLeft;
            this.UpperRight = UpperRight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CornersProperty"/> class.
        /// </summary>
        /// <param name="All">All.</param>
        public CornersProperty(short All)
        {
            this.All = All;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CornersProperty"/> class.
        /// </summary>
        public CornersProperty()
        {
            LowerLeft = 0;
            LowerRight = 0;
            UpperLeft = 0;
            UpperRight = 0;
        }

        /// <summary>
        /// Gets or sets all.
        /// </summary>
        /// <value>All.</value>
        [Description("Set the Radius of the All four Corners the same")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
        public short All
        {
            get { return _All; }
            set
            {
                _All = value;
                if (value > -1)
                {
                    LowerLeft = value;
                    LowerRight = value;
                    UpperLeft = value;
                    UpperRight = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the upper left.
        /// </summary>
        /// <value>The upper left.</value>
        [Description("Set the Radius of the Upper Left Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public short UpperLeft
        {
            get { return _UpperLeft; }
            set
            {
                _UpperLeft = Convert.ToInt16(System.Math.Max(value, (short) 0));
                CheckForAll(_UpperLeft);
            }
        }

        /// <summary>
        /// Gets or sets the upper right.
        /// </summary>
        /// <value>The upper right.</value>
        [Description("Set the Radius of the Upper Right Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public short UpperRight
        {
            get { return _UpperRight; }
            set
            {
                _UpperRight = Convert.ToInt16(System.Math.Max(value, (short) 0));
                CheckForAll(_UpperRight);
            }
        }

        /// <summary>
        /// Gets or sets the lower left.
        /// </summary>
        /// <value>The lower left.</value>
        [Description("Set the Radius of the Lower Left Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public short LowerLeft
        {
            get { return _LowerLeft; }
            set
            {
                _LowerLeft = Convert.ToInt16(System.Math.Max(value, (short) 0));
                CheckForAll(_LowerLeft);
            }
        }

        /// <summary>
        /// Gets or sets the lower right.
        /// </summary>
        /// <value>The lower right.</value>
        [Description("Set the Radius of the Lower Right Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public short LowerRight
        {
            get { return _LowerRight; }
            set
            {
                _LowerRight = Convert.ToInt16(System.Math.Max(value, (short) 0));
                CheckForAll(_LowerRight);
            }
        }

        /// <summary>
        /// Checks for all.
        /// </summary>
        /// <param name="val">The value.</param>
        private void CheckForAll(short val)
        {
            if (val == LowerLeft && val == LowerRight && val == UpperLeft && val == UpperRight)
            {
                if (All != val) All = val;
            }
            else
            {
                if (All != -1) All = -1;
            }
        }
    } //Corners Properties

    #region CornerConverter

    /// <summary>
    /// Class CornerConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class CornerConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter" /> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary" /> of new property values.</param>
        /// <returns>An <see cref="T:System.Object" /> representing the given <see cref="T:System.Collections.IDictionary" />, or null if the object cannot be created. This method always returns null.</returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            var crn = new CornersProperty();
            var AL = Convert.ToInt16(propertyValues["All"]);
            var LL = Convert.ToInt16(propertyValues["LowerLeft"]);
            var LR = Convert.ToInt16(propertyValues["LowerRight"]);
            var UL = Convert.ToInt16(propertyValues["UpperLeft"]);
            var UR = Convert.ToInt16(propertyValues["UpperRight"]);


            var oAll = ((ZeroitProgBarPlus) context.Instance).Corners.All;

            if (oAll != AL && AL > -1)
            {
                crn.All = AL;
            }
            else
            {
                crn.LowerLeft = LL;
                crn.LowerRight = LR;
                crn.UpperLeft = UL;
                crn.UpperRight = UR;
            }

            return crn;
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
                try
                {
                    var s = Convert.ToString(value);
                    var cornerParts = new string[5];
                    cornerParts = s.Split(',');
                    if (!(cornerParts == null))
                    {
                        if (cornerParts[0] == null) cornerParts[0] = "0";
                        if (cornerParts[1] == null) cornerParts[1] = "0";
                        if (cornerParts[2] == null) cornerParts[2] = "0";
                        if (cornerParts[3] == null) cornerParts[3] = "0";
                        return new CornersProperty(Convert.ToInt16(cornerParts[0].Trim()),
                            Convert.ToInt16(cornerParts[1].Trim()), Convert.ToInt16(cornerParts[2].Trim()),
                            Convert.ToInt16(cornerParts[3].Trim()));
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(string.Format("Can not convert '{0}' to type Corners",
                        Convert.ToString(value)));
                }
            else
                return new CornersProperty();

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destinationType)
        {
            var _Corners = (CornersProperty) value;
            if (destinationType == typeof(string) && value is CornersProperty)
                return string.Format("{0}, {1}, {2}, {3}", _Corners.LowerLeft, _Corners.LowerRight, _Corners.UpperLeft,
                    _Corners.UpperRight);
            return base.ConvertTo(context, culture, value, destinationType);
        }
    } //CornerConverter Code

    #endregion //CornerConverter

    #endregion //Expandable Border Corners Property Class

    #region Control Designer

    //
    //You have to directly add the System.Design Reference to the Project
    //
    /// <summary>
    /// Class ProgBarControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class ProgBarControlDesigner : ControlDesigner
    {
        /// <summary>
        /// The lists
        /// </summary>
        private DesignerActionListCollection _Lists;
        /// <summary>
        /// The prog bar plus
        /// </summary>
        private ZeroitProgBarPlus _ProgBarPlus;

        #region ActionLists

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_Lists == null)
                {
                    _Lists = new DesignerActionListCollection();
                    _Lists.Add(new ProgBarPlusActionList(Component));
                }

                return _Lists;
            }
        }

        #endregion //ActionLists


        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate the designer with. This component must always be an instance of, or derive from, <see cref="T:System.Windows.Forms.Control" />.</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            _ProgBarPlus = (ZeroitProgBarPlus) component;
        }

        #region OnPaintAdornments

        /// <summary>
        /// Handles the <see cref="E:PaintAdornments" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            if (_ProgBarPlus.ShowDesignBorder)
            {
                var g = e.Graphics;
                using (var myPen = new Pen(Color.Gray, 1F))
                {
                    //Dim rect As New Rectangle(0, 0, _ProgBarPlus.Width - 1, CInt(_ProgBarPlus.Height - 1))
                    myPen.DashStyle = DashStyle.Dash;
                    if (_ProgBarPlus.CornersApply == ZeroitProgBarPlus.eCornersApply.Bar)
                    {
                        g.DrawRectangle(myPen, _ProgBarPlus.DisplayRectangle);
                    }
                    else
                    {
                        var MyPath = new ZeroitProgBarPlus.ProgBarPath();
                        MyPath = _ProgBarPlus.GetPath(_ProgBarPlus.DisplayRectangle, ZeroitProgBarPlus.ePart.Border, 1);
                        if (_ProgBarPlus.Shape == ZeroitProgBarPlus.eShape.Text)
                        {
                            if (_ProgBarPlus.ShapeTextRotate != ZeroitProgBarPlus.eRotateText.None)
                                using (var mtrx = new Matrix())
                                {
                                    mtrx.Rotate(_ProgBarPlus.GetRotateAngle(_ProgBarPlus.ShapeTextRotate));
                                    MyPath.Path.Transform(mtrx);
                                }

                            g.Transform = ZeroitProgBarPlus.TextMatrix(MyPath);
                            g.DrawPath(myPen, MyPath.Path);
                            g.ResetTransform();
                        }
                        else
                        {
                            e.Graphics.DrawPath(myPen, MyPath.Path);
                        }
                    }
                }
            }
        }

        #endregion //OnPaintAdornments
    }

    #region ProgBarPlusActionList

    /// <summary>
    /// Class ProgBarPlusActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ProgBarPlusActionList : DesignerActionList
    {
        /// <summary>
        /// The designer service
        /// </summary>
        private readonly DesignerActionUIService _DesignerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgBarPlusActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ProgBarPlusActionList(IComponent component) : base(component)
        {
            // Save a reference to the control we are designing.
            CurrProgBarPlus = (ZeroitProgBarPlus) component;

            // Save a reference to the DesignerActionUIService
            _DesignerService = (DesignerActionUIService) GetService(typeof(DesignerActionUIService));

            //Makes the Smart Tags open automatically 
            AutoShow = true;
        }

        // Return the smart tag action items.
        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            items.Add(new DesignerActionHeaderItem("Behavior"));
            items.Add(new DesignerActionPropertyItem("BarType", "Bar Type", "Behavior",
                "Use Standard, CylonBar, or Glider Progress Bar"));
            if (CurrProgBarPlus.BarType == ZeroitProgBarPlus.eBarType.Bar)
            {
                items.Add(new DesignerActionPropertyItem("BarLength", "Bar Length Type", "Behavior",
                    "Use Fixed or Full Length Progress Bar"));
                if (CurrProgBarPlus.BarLength == ZeroitProgBarPlus.eBarLength.Fixed)
                    items.Add(new DesignerActionPropertyItem("BarLengthValue", "Bar Length Value", "Behavior",
                        "Length of the Fixed Progress Bar"));
                items.Add(new DesignerActionPropertyItem("FillDirection", "Progress Direction", "Behavior",
                    "The ZeroitProgBarPlus of the Control"));
            }
            else
            {
                if (CurrProgBarPlus.BarType == ZeroitProgBarPlus.eBarType.CylonBar)
                    items.Add(new DesignerActionPropertyItem("BarLengthValue", "Bar Length Value", "Behavior",
                        "Length of the Fixed Progress Bar"));
                items.Add(new DesignerActionPropertyItem("CylonRun", "Cylon On", "Behavior", "Start the Cylon Timer"));
                items.Add(new DesignerActionPropertyItem("CylonMove", "Move Distance", "Behavior",
                    "How far the bar moves"));
                items.Add(new DesignerActionPropertyItem("CylonInterval", "Timer Tick", "Behavior",
                    "How often the bar moves"));
            }

            items.Add(new DesignerActionPropertyItem("Orientation", "Bar Orientation", "Behavior",
                "The ZeroitProgBarPlus of the Control"));

            items.Add(new DesignerActionHeaderItem("Color and Fill"));

            items.Add(new DesignerActionPropertyItem("BarStyleFill", "Bar Fill Type", "Color and Fill",
                "Fill Solid, Gradient, Hatch, or Texture"));

            switch (CurrProgBarPlus.BarStyleFill)
            {
                case ZeroitProgBarPlus.eBarStyle.Solid:
                    items.Add(new DesignerActionPropertyItem("BarColorSolid", "Primary Solid Color", "Color and Fill",
                        "The Primary Color for Solid Fill"));
                    items.Add(new DesignerActionPropertyItem("BarColorSolidB", "Secondary Solid Color",
                        "Color and Fill", "The Secondary Color for Solid Fill"));

                    break;
                case ZeroitProgBarPlus.eBarStyle.Hatch:
                    items.Add(new DesignerActionPropertyItem("BarColorSolid", "Primary Solid Color", "Color and Fill",
                        "The Primary Color for Hatch Fill"));
                    items.Add(new DesignerActionPropertyItem("BarColorSolidB", "Secondary Solid Color",
                        "Color and Fill", "The Secondary Color for Hatch Fill"));
                    items.Add(new DesignerActionPropertyItem("BarStyleHatch", "Hatch Style", "Color and Fill",
                        "The Hatch Style for Fill"));

                    break;
                case ZeroitProgBarPlus.eBarStyle.GradientLinear:
                    items.Add(new DesignerActionPropertyItem("BarColorBlend", "Blend Colors", "Color and Fill",
                        "Color and Position Arrays for Color Blend"));
                    items.Add(new DesignerActionPropertyItem("BarStyleLinear", "Linear Style", "Color and Fill",
                        "Color and Position Arrays for Color Blend"));

                    break;
                case ZeroitProgBarPlus.eBarStyle.GradientPath:
                    items.Add(new DesignerActionPropertyItem("BarColorBlend", "Blend Colors", "Color and Fill",
                        "Color and Position Arrays for Color Blend"));
                    items.Add(new DesignerActionPropertyItem("FocalPoints", "FocalPoints", "Color and Fill",
                        "The color of the ZeroitProgBarPlus's Border"));

                    break;
                case ZeroitProgBarPlus.eBarStyle.Texture:
                    items.Add(new DesignerActionPropertyItem("BarStyleTexture", "Texture Image", "Color and Fill",
                        "The Image to fill with"));
                    items.Add(new DesignerActionPropertyItem("BarStyleWrapMode", "Texture Wrap Mode", "Color and Fill",
                        "The Wrap Mode for texture fills"));

                    break;
            }

            items.Add(new DesignerActionPropertyItem("BarBackColor", "Background Color", "Color and Fill",
                "The ZeroitProgBarPlus of the Control"));

            items.Add(new DesignerActionHeaderItem("Border"));
            items.Add(new DesignerActionPropertyItem("BorderColor", "Border Color", "Border",
                "The color of the ZeroitProgBarPlus's Border"));
            items.Add(new DesignerActionPropertyItem("BorderWidth", "Border Width", "Border",
                "The width of the ZeroitProgBarPlus's Border"));

            items.Add(new DesignerActionHeaderItem("Shape"));
            items.Add(new DesignerActionPropertyItem("Shape", "Shape", "Shape", "The Shape of the ZeroitProgBarPlus"));

            switch (CurrProgBarPlus.Shape)
            {
                case ZeroitProgBarPlus.eShape.Rectangle:
                    items.Add(new DesignerActionPropertyItem("CornersApply", "Apply Corners", "Shape",
                        "Apply the Corners to what parts of the ZeroitProgBarPlus"));
                    items.Add(new DesignerActionMethodItem(this, "AdjustCorners", "Adjust Corners ", "Shape",
                        "Adjust Corners", true));
                    break;
                case ZeroitProgBarPlus.eShape.Text:
                    items.Add(new DesignerActionPropertyItem("ShapeTextFont", "Font for Shape", "Shape",
                        "The Font for Shape of the ZeroitProgBarPlus"));
                    items.Add(new DesignerActionPropertyItem("ShapeText", "Text for Shape", "Shape",
                        "The Text for Shape of the ZeroitProgBarPlus"));
                    items.Add(new DesignerActionPropertyItem("ShapeTextRotate", "Rotate Text", "Shape",
                        "The Font for Shape of the ZeroitProgBarPlus"));
                    break;
            }

            items.Add(new DesignerActionHeaderItem("Text"));
            items.Add(new DesignerActionPropertyItem("TextShow", "Show Text", "Text",
                "The Show or not Show the Text on the ZeroitProgBarPlus"));
            if (CurrProgBarPlus.TextShow != ZeroitProgBarPlus.eTextShow.None)
            {
                items.Add(new DesignerActionPropertyItem("ForeColor", "Color for Text", "Text",
                    "The Color for Text on the Bar"));

                if (CurrProgBarPlus.TextShow == ZeroitProgBarPlus.eTextShow.FormatString)
                    items.Add(new DesignerActionPropertyItem("TextFormat", "Format String", "Text",
                        "The Text for Shape of the ZeroitProgBarPlus"));

                items.Add(new DesignerActionPropertyItem("TextPlacement", "Placement on Bar", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
                items.Add(new DesignerActionPropertyItem("TextAlignment", "Horiz Alignment", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
                items.Add(new DesignerActionPropertyItem("TextAlignmentVert", "Vert Alignment", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
                items.Add(new DesignerActionPropertyItem("TextShadow", "Text Shadow", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
                if (CurrProgBarPlus.TextShadow)
                    items.Add(new DesignerActionPropertyItem("TextShadowColor", "Text Shadow", "Text",
                        "The Text for Shape of the ZeroitProgBarPlus"));
                items.Add(new DesignerActionPropertyItem("TextRotate", "Rotate", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
                items.Add(new DesignerActionPropertyItem("TextWrap", "Wrap Text", "Text",
                    "The Text for Shape of the ZeroitProgBarPlus"));
            }


            //items.Add(New DesignerActionHeaderItem("Information"))
            //Add Text Item - I gave it an empty Category to make 
            //it appear at the end with no Header


            //items.Add(new DesignerActionTextItem(
            //    string.Format("{0}Smart Tags Are Cool{1}{2}GonzoDiver", new string(' ', 20), "\r", new string(' ', 28)),
            //    ""));

            //Another Text item but with a header
            //Dim txt As String = "Width=" & _ProgBarPlusSelector.Width & _
            // " Height=" & _ProgBarPlusSelector.Height
            //items.Add( _
            //    New DesignerActionTextItem( _
            //        txt, "Information"))

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(CurrProgBarPlus.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(CurrProgBarPlus.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                "Information"));

            return items;
        }

        #region Smart Tag Items

        #region Properties

        /// <summary>
        /// Gets or sets the fill direction.
        /// </summary>
        /// <value>The fill direction.</value>
        public ZeroitProgBarPlus.eFillDirection FillDirection
        {
            get { return CurrProgBarPlus.FillDirection; }
            set { SetControlProperty("FillDirection", value); }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public ZeroitProgBarPlus.eOrientation Orientation
        {
            get { return CurrProgBarPlus.Orientation; }
            set { SetControlProperty("Orientation", value); }
        }

        /// <summary>
        /// Gets or sets the type of the bar.
        /// </summary>
        /// <value>The type of the bar.</value>
        public ZeroitProgBarPlus.eBarType BarType
        {
            get { return CurrProgBarPlus.BarType; }
            set
            {
                SetControlProperty("BarType", value);
                _DesignerService.ShowUI(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the cylon move.
        /// </summary>
        /// <value>The cylon move.</value>
        public float CylonMove
        {
            get { return CurrProgBarPlus.CylonMove; }
            set { SetControlProperty("CylonMove", value); }
        }

        /// <summary>
        /// Gets or sets the cylon interval.
        /// </summary>
        /// <value>The cylon interval.</value>
        public short CylonInterval
        {
            get { return CurrProgBarPlus.CylonInterval; }
            set { SetControlProperty("CylonInterval", value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [cylon run].
        /// </summary>
        /// <value><c>true</c> if [cylon run]; otherwise, <c>false</c>.</value>
        public bool CylonRun
        {
            get { return CurrProgBarPlus.CylonRun; }
            set { SetControlProperty("CylonRun", value); }
        }

        /// <summary>
        /// Gets or sets the length of the bar.
        /// </summary>
        /// <value>The length of the bar.</value>
        public ZeroitProgBarPlus.eBarLength BarLength
        {
            get { return CurrProgBarPlus.BarLength; }
            set
            {
                SetControlProperty("BarLength", value);
                _DesignerService.ShowUI(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the bar length value.
        /// </summary>
        /// <value>The bar length value.</value>
        public short BarLengthValue
        {
            get { return CurrProgBarPlus.BarLengthValue; }
            set { SetControlProperty("BarLengthValue", value); }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public ZeroitProgBarPlus.eShape Shape
        {
            get { return CurrProgBarPlus.Shape; }
            set
            {
                SetControlProperty("Shape", value);
                _DesignerService.ShowUI(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the corners apply.
        /// </summary>
        /// <value>The corners apply.</value>
        public ZeroitProgBarPlus.eCornersApply CornersApply
        {
            get { return CurrProgBarPlus.CornersApply; }
            set { SetControlProperty("CornersApply", value); }
        }

        /// <summary>
        /// Gets or sets the shape text.
        /// </summary>
        /// <value>The shape text.</value>
        public string ShapeText
        {
            get { return CurrProgBarPlus.ShapeText; }
            set { SetControlProperty("ShapeText", value); }
        }

        /// <summary>
        /// Gets or sets the shape text font.
        /// </summary>
        /// <value>The shape text font.</value>
        public Font ShapeTextFont
        {
            get { return CurrProgBarPlus.ShapeTextFont; }
            set { SetControlProperty("ShapeTextFont", value); }
        }

        /// <summary>
        /// Gets or sets the shape text rotate.
        /// </summary>
        /// <value>The shape text rotate.</value>
        public ZeroitProgBarPlus.eRotateText ShapeTextRotate
        {
            get { return CurrProgBarPlus.ShapeTextRotate; }
            set { SetControlProperty("ShapeTextRotate", value); }
        }

        /// <summary>
        /// Gets or sets the bar style fill.
        /// </summary>
        /// <value>The bar style fill.</value>
        public ZeroitProgBarPlus.eBarStyle BarStyleFill
        {
            get { return CurrProgBarPlus.BarStyleFill; }
            set
            {
                SetControlProperty("BarStyleFill", value);
                _DesignerService.ShowUI(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the color of the bar back.
        /// </summary>
        /// <value>The color of the bar back.</value>
        public Color BarBackColor
        {
            get { return CurrProgBarPlus.BarBackColor; }
            set { SetControlProperty("BarBackColor", value); }
        }

        /// <summary>
        /// Gets or sets the bar color solid.
        /// </summary>
        /// <value>The bar color solid.</value>
        public Color BarColorSolid
        {
            get { return CurrProgBarPlus.BarColorSolid; }
            set
            {
                SetControlProperty("BarColorSolid", value);
                if (CurrProgBarPlus.BarStyleFill == ZeroitProgBarPlus.eBarStyle.Hatch)
                    _DesignerService.Refresh(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the bar color solid b.
        /// </summary>
        /// <value>The bar color solid b.</value>
        public Color BarColorSolidB
        {
            get { return CurrProgBarPlus.BarColorSolidB; }
            set
            {
                SetControlProperty("BarColorSolidB", value);
                if (CurrProgBarPlus.BarStyleFill == ZeroitProgBarPlus.eBarStyle.Hatch)
                    _DesignerService.Refresh(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the bar color blend.
        /// </summary>
        /// <value>The bar color blend.</value>
        [Editor(typeof(BlendTypeEditor), typeof(UITypeEditor))]
        public cBlendItems BarColorBlend
        {
            get { return CurrProgBarPlus.BarColorBlend; }
            set { SetControlProperty("BarColorBlend", value); }
        }

        /// <summary>
        /// Gets or sets the bar style linear.
        /// </summary>
        /// <value>The bar style linear.</value>
        public LinearGradientMode BarStyleLinear
        {
            get { return CurrProgBarPlus.BarStyleLinear; }
            set { SetControlProperty("BarStyleLinear", value); }
        }

        /// <summary>
        /// Gets or sets the bar style hatch.
        /// </summary>
        /// <value>The bar style hatch.</value>
        [Editor(typeof(HatchStyleEditor), typeof(UITypeEditor))]
        public HatchStyle BarStyleHatch
        {
            get { return CurrProgBarPlus.BarStyleHatch; }
            set { SetControlProperty("BarStyleHatch", value); }
        }

        /// <summary>
        /// Gets or sets the bar style texture.
        /// </summary>
        /// <value>The bar style texture.</value>
        public Image BarStyleTexture
        {
            get { return CurrProgBarPlus.BarStyleTexture; }
            set { SetControlProperty("BarStyleTexture", value); }
        }

        /// <summary>
        /// Gets or sets the bar style wrap mode.
        /// </summary>
        /// <value>The bar style wrap mode.</value>
        public WrapMode BarStyleWrapMode
        {
            get { return CurrProgBarPlus.BarStyleWrapMode; }
            set { SetControlProperty("BarStyleWrapMode", value); }
        }

        /// <summary>
        /// Gets or sets the focal points.
        /// </summary>
        /// <value>The focal points.</value>
        [Editor(typeof(FocalTypeEditor), typeof(UITypeEditor))]
        public cFocalPoints FocalPoints
        {
            get { return CurrProgBarPlus.FocalPoints; }
            set { SetControlProperty("FocalPoints", value); }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return CurrProgBarPlus.BorderColor; }
            set { SetControlProperty("BorderColor", value); }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public short BorderWidth
        {
            get { return CurrProgBarPlus.BorderWidth; }
            set { SetControlProperty("BorderWidth", value); }
        }

        /// <summary>
        /// Gets or sets the text show.
        /// </summary>
        /// <value>The text show.</value>
        public ZeroitProgBarPlus.eTextShow TextShow
        {
            get { return CurrProgBarPlus.TextShow; }
            set
            {
                SetControlProperty("TextShow", value);
                _DesignerService.Refresh(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return CurrProgBarPlus.ForeColor; }
            set { SetControlProperty("ForeColor", value); }
        }

        /// <summary>
        /// Gets or sets the text format.
        /// </summary>
        /// <value>The text format.</value>
        public string TextFormat
        {
            get { return CurrProgBarPlus.TextFormat; }
            set { SetControlProperty("TextFormat", value); }
        }

        /// <summary>
        /// Gets or sets the text placement.
        /// </summary>
        /// <value>The text placement.</value>
        public ZeroitProgBarPlus.eTextPlacement TextPlacement
        {
            get { return CurrProgBarPlus.TextPlacement; }
            set { SetControlProperty("TextPlacement", value); }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get { return CurrProgBarPlus.TextAlignment; }
            set { SetControlProperty("TextAlignment", value); }
        }

        /// <summary>
        /// Gets or sets the text alignment vert.
        /// </summary>
        /// <value>The text alignment vert.</value>
        public StringAlignment TextAlignmentVert
        {
            get { return CurrProgBarPlus.TextAlignmentVert; }
            set { SetControlProperty("TextAlignmentVert", value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text wrap].
        /// </summary>
        /// <value><c>true</c> if [text wrap]; otherwise, <c>false</c>.</value>
        public bool TextWrap
        {
            get { return CurrProgBarPlus.TextWrap; }
            set { SetControlProperty("TextWrap", value); }
        }

        /// <summary>
        /// Gets or sets the text rotate.
        /// </summary>
        /// <value>The text rotate.</value>
        public ZeroitProgBarPlus.eRotateText TextRotate
        {
            get { return CurrProgBarPlus.TextRotate; }
            set { SetControlProperty("TextRotate", value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text shadow].
        /// </summary>
        /// <value><c>true</c> if [text shadow]; otherwise, <c>false</c>.</value>
        public bool TextShadow
        {
            get { return CurrProgBarPlus.TextShadow; }
            set
            {
                SetControlProperty("TextShadow", value);
                _DesignerService.ShowUI(CurrProgBarPlus);
            }
        }

        /// <summary>
        /// Gets or sets the color of the text shadow.
        /// </summary>
        /// <value>The color of the text shadow.</value>
        public Color TextShadowColor
        {
            get { return CurrProgBarPlus.TextShadowColor; }
            set { SetControlProperty("TextShadowColor", value); }
        }


        /// <summary>
        /// Gets the curr prog bar plus.
        /// </summary>
        /// <value>The curr prog bar plus.</value>
        public ZeroitProgBarPlus CurrProgBarPlus { get; }

        #endregion //Properties

        #region Methods

        /// <summary>
        /// Adjusts the corners.
        /// </summary>
        public void AdjustCorners()
        {
            //Create a new Corners Dialog and update the controls on the form
            var dlg = new dlgCorners();

            var maxcorner = 0;
            var ratio = 0F;

            if (CurrProgBarPlus.Width > CurrProgBarPlus.Height)
            {
                dlg.TheShape.Height =
                    Convert.ToInt32(dlg.TheShape.Width * (CurrProgBarPlus.Height / (double) CurrProgBarPlus.Width));
                dlg.TheShape.Top = Convert.ToInt32((dlg.panShapeHolder.Height - dlg.TheShape.Height) / 2.0);
                maxcorner = Convert.ToInt32(dlg.TheShape.Height / 2.0 - CurrProgBarPlus.BorderWidth * 2);
                ratio = Convert.ToSingle(dlg.TheShape.Height / (double) CurrProgBarPlus.Height);
            }
            else
            {
                dlg.TheShape.Width =
                    Convert.ToInt32(dlg.TheShape.Height * (CurrProgBarPlus.Width / (double) CurrProgBarPlus.Height));
                dlg.TheShape.Left = Convert.ToInt32((dlg.panShapeHolder.Width - dlg.TheShape.Width) / 2.0);
                maxcorner = Convert.ToInt32(dlg.TheShape.Width / 2.0 - CurrProgBarPlus.BorderWidth * 2);
                ratio = Convert.ToSingle(dlg.TheShape.Width / (double) CurrProgBarPlus.Width);
            }

            // Set current Corners values
            dlg.tbarUpperLeft.Maximum = maxcorner;
            dlg.tbarUpperRight.Maximum = maxcorner;
            dlg.tbarLowerLeft.Maximum = maxcorner;
            dlg.tbarLowerRight.Maximum = maxcorner;
            dlg.tbarAll.Maximum = maxcorner;
            dlg.tbarUpperLeft.TickFrequency = Convert.ToInt32(maxcorner / 2.0);
            dlg.tbarUpperRight.TickFrequency = Convert.ToInt32(maxcorner / 2.0);
            dlg.tbarLowerLeft.TickFrequency = Convert.ToInt32(maxcorner / 2.0);
            dlg.tbarLowerRight.TickFrequency = Convert.ToInt32(maxcorner / 2.0);
            dlg.tbarAll.TickFrequency = Convert.ToInt32(maxcorner / 2.0);
            if (CurrProgBarPlus.Corners.All > -1)
                dlg.tbarAll.Value = Convert.ToInt32(System.Math.Min(CurrProgBarPlus.Corners.UpperLeft * ratio, maxcorner));
            dlg.tbarUpperLeft.Value = Convert.ToInt32(System.Math.Min(CurrProgBarPlus.Corners.UpperLeft * ratio, maxcorner));
            dlg.tbarUpperRight.Value = Convert.ToInt32(System.Math.Min(CurrProgBarPlus.Corners.UpperRight * ratio, maxcorner));
            dlg.tbarLowerLeft.Value = Convert.ToInt32(System.Math.Min(CurrProgBarPlus.Corners.LowerLeft * ratio, maxcorner));
            dlg.tbarLowerRight.Value = Convert.ToInt32(System.Math.Min(CurrProgBarPlus.Corners.LowerRight * ratio, maxcorner));

            dlg.TheShape.Shape = CurrProgBarPlus.Shape;
            dlg.TheShape.BarStyleFill = CurrProgBarPlus.BarStyleFill;
            dlg.TheShape.BarStyleLinear = CurrProgBarPlus.BarStyleLinear;
            dlg.TheShape.BarLength = CurrProgBarPlus.BarLength;
            dlg.TheShape.BarLengthValue = CurrProgBarPlus.BarLengthValue;
            dlg.TheShape.BarBackColor = CurrProgBarPlus.BarBackColor;
            dlg.TheShape.BarColorSolid = CurrProgBarPlus.BarColorSolid;
            dlg.TheShape.FillDirection = CurrProgBarPlus.FillDirection;
            dlg.TheShape.Orientation = CurrProgBarPlus.Orientation;
            dlg.TheShape.CornersApply = CurrProgBarPlus.CornersApply;
            dlg.TheShape.BarColorSolidB = CurrProgBarPlus.BarColorSolidB;
            dlg.TheShape.BorderWidth = CurrProgBarPlus.BorderWidth;
            dlg.TheShape.BorderColor = CurrProgBarPlus.BorderColor;
            dlg.TheShape.BarStyleHatch = CurrProgBarPlus.BarStyleHatch;
            dlg.TheShape.BarColorBlend =
                new cBlendItems(CurrProgBarPlus.BarColorBlend.iColor, CurrProgBarPlus.BarColorBlend.iPoint);
            dlg.TheShape.Corners = new CornersProperty(Convert.ToInt16(CurrProgBarPlus.Corners.LowerLeft * ratio),
                Convert.ToInt16(CurrProgBarPlus.Corners.LowerRight * ratio),
                Convert.ToInt16(CurrProgBarPlus.Corners.UpperLeft * ratio),
                Convert.ToInt16(CurrProgBarPlus.Corners.UpperRight * ratio));
            dlg.TheShape.FocalPoints = CurrProgBarPlus.FocalPoints;
            dlg.HSBarSample.Location = new Point(dlg.HSBarSample.Location.X,
                dlg.panShapeHolder.Location.Y + dlg.TheShape.Location.Y + dlg.TheShape.Height);

            // Update new Corners values if OK button was pressed
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var designerHost = (IDesignerHost) Component.Site.GetService(typeof(IDesignerHost));

                if (designerHost != null)
                {
                    var t = designerHost.CreateTransaction();
                    try
                    {
                        SetControlProperty("Corners",
                            new CornersProperty(Convert.ToInt16(dlg.TheShape.Corners.LowerLeft / ratio),
                                Convert.ToInt16(dlg.TheShape.Corners.LowerRight / ratio),
                                Convert.ToInt16(dlg.TheShape.Corners.UpperLeft / ratio),
                                Convert.ToInt16(dlg.TheShape.Corners.UpperRight / ratio)));
                        t.Commit();
                    }
                    catch
                    {
                        t.Cancel();
                    }
                }
            }

            CurrProgBarPlus.Refresh();
        }

        #endregion //Methods

        // Set a control property. This method makes Undo/Redo
        // work properly and marks the form as modified in the IDE.
        /// <summary>
        /// Sets the control property.
        /// </summary>
        /// <param name="property_name">Name of the property.</param>
        /// <param name="value">The value.</param>
        private void SetControlProperty(string property_name, object value)
        {
            TypeDescriptor.GetProperties(CurrProgBarPlus)[property_name].SetValue(CurrProgBarPlus, value);
        }

        #endregion // Smart Tag Items
    }

    #endregion //ProgBarPlusActionList

    #endregion //Control Designer
}