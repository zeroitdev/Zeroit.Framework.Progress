// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="OSXBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms.Design;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress.Sliders
{
    #region Mac TrackBar

    #region Helper Classes

    /// <summary>
    /// Summary description for ColorHelper.
    /// </summary>
	internal class ColorHelper
    {
        /// <summary>
        /// Creates the color from RGB.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns>Color.</returns>
        public static Color CreateColorFromRGB(int red, int green, int blue)
        {
            //Corect Red element
            int r = red;
            if (r > 255)
            {
                r = 255;
            }
            if (r < 0)
            {
                r = 0;
            }
            //Corect Green element
            int g = green;
            if (g > 255)
            {
                g = 255;
            }
            if (g < 0)
            {
                g = 0;
            }
            //Correct Blue Element
            int b = blue;
            if (b > 255)
            {
                b = 255;
            }
            if (b < 0)
            {
                b = 0;
            }
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Opacities the mix.
        /// </summary>
        /// <param name="blendColor">Color of the blend.</param>
        /// <param name="baseColor">Color of the base.</param>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Color.</returns>
        public static Color OpacityMix(Color blendColor, Color baseColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = blendColor.R;
            g1 = blendColor.G;
            b1 = blendColor.B;
            r2 = baseColor.R;
            g2 = baseColor.G;
            b2 = baseColor.B;
            r3 = (int)(((r1 * ((float)opacity / 100)) + (r2 * (1 - ((float)opacity / 100)))));
            g3 = (int)(((g1 * ((float)opacity / 100)) + (g2 * (1 - ((float)opacity / 100)))));
            b3 = (int)(((b1 * ((float)opacity / 100)) + (b2 * (1 - ((float)opacity / 100)))));
            return CreateColorFromRGB(r3, g3, b3);
        }

        /// <summary>
        /// Softs the light mix.
        /// </summary>
        /// <param name="baseColor">Color of the base.</param>
        /// <param name="blendColor">Color of the blend.</param>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Color.</returns>
        public static Color SoftLightMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = baseColor.R;
            g1 = baseColor.G;
            b1 = baseColor.B;
            r2 = blendColor.R;
            g2 = blendColor.G;
            b2 = blendColor.B;
            r3 = SoftLightMath(r1, r2);
            g3 = SoftLightMath(g1, g2);
            b3 = SoftLightMath(b1, b2);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }

        /// <summary>
        /// Overlays the mix.
        /// </summary>
        /// <param name="baseColor">Color of the base.</param>
        /// <param name="blendColor">Color of the blend.</param>
        /// <param name="opacity">The opacity.</param>
        /// <returns>Color.</returns>
        public static Color OverlayMix(Color baseColor, Color blendColor, int opacity)
        {
            int r1;
            int g1;
            int b1;
            int r2;
            int g2;
            int b2;
            int r3;
            int g3;
            int b3;
            r1 = baseColor.R;
            g1 = baseColor.G;
            b1 = baseColor.B;
            r2 = blendColor.R;
            g2 = blendColor.G;
            b2 = blendColor.B;
            r3 = OverlayMath(baseColor.R, blendColor.R);
            g3 = OverlayMath(baseColor.G, blendColor.G);
            b3 = OverlayMath(baseColor.B, blendColor.B);
            return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity);
        }


        /// <summary>
        /// Softs the light math.
        /// </summary>
        /// <param name="ibase">The ibase.</param>
        /// <param name="blend">The blend.</param>
        /// <returns>System.Int32.</returns>
        private static int SoftLightMath(int ibase, int blend)
        {
            float dbase;
            float dblend;
            dbase = (float)ibase / 255;
            dblend = (float)blend / 255;
            if (dblend < 0.5)
            {
                return (int)(((2 * dbase * dblend) + (System.Math.Pow(dbase, 2)) * (1 - (2 * dblend))) * 255);
            }
            else
            {
                return (int)(((System.Math.Sqrt(dbase) * (2 * dblend - 1)) + ((2 * dbase) * (1 - dblend))) * 255);
            }
        }

        /// <summary>
        /// Overlays the math.
        /// </summary>
        /// <param name="ibase">The ibase.</param>
        /// <param name="blend">The blend.</param>
        /// <returns>System.Int32.</returns>
        public static int OverlayMath(int ibase, int blend)
        {
            double dbase;
            double dblend;
            dbase = (double)ibase / 255;
            dblend = (double)blend / 255;
            if (dbase < 0.5)
            {
                return (int)((2 * dbase * dblend) * 255);
            }
            else
            {
                return (int)((1 - (2 * (1 - dbase) * (1 - dblend))) * 255);
            }
        }

    }

    #endregion

    #region DrawMACStyleHelper
    /// <summary>
    /// Summary description for DrawMACStyleHelper.
    /// </summary>
    public sealed class DrawMACStyleHelper
    {
        /// <summary>
        /// The contructor
        /// </summary>
        private DrawMACStyleHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Draws the aqua pill.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="drawRectF">The draw rect f.</param>
        /// <param name="drawColor">Color of the draw.</param>
        /// <param name="orientation">The orientation.</param>
        public static void DrawAquaPill(Graphics g, RectangleF drawRectF, Color drawColor, Orientation orientation)

        {
            Color color1;
            Color color2;
            Color color3;
            Color color4;
            Color color5;
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush;
            System.Drawing.Drawing2D.ColorBlend colorBlend = new System.Drawing.Drawing2D.ColorBlend();

            color1 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, Color.Black, 100), 40);
            color2 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(64, 64, 64), 100), 20);
            color3 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(128, 128, 128), 100);
            color4 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(192, 192, 192), 100);
            color5 = ColorHelper.OverlayMix(ColorHelper.SoftLightMix(drawColor, Color.White, 100), Color.White, 75);

            //			
            colorBlend.Colors = new Color[] { color1, color2, color3, color4, color5 };
            colorBlend.Positions = new float[] { 0, 0.25f, 0.5f, 0.75f, 1 };
            if (orientation == Orientation.Horizontal)
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top - 1), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height + 1), color1, color5);
            else
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left - 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width + 1, (int)drawRectF.Top), color1, color5);
            gradientBrush.InterpolationColors = colorBlend;
            FillPill(gradientBrush, drawRectF, g);

            //
            color2 = Color.White;
            colorBlend.Colors = new Color[] { color2, color3, color4, color5 };
            colorBlend.Positions = new float[] { 0, 0.5f, 0.75f, 1 };
            if (orientation == Orientation.Horizontal)
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left + 1, (int)drawRectF.Top), new Point((int)drawRectF.Left + 1, (int)drawRectF.Top + (int)drawRectF.Height - 1), color2, color5);
            else
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top + 1), new Point((int)drawRectF.Left + (int)drawRectF.Width - 1, (int)drawRectF.Top + 1), color2, color5);
            gradientBrush.InterpolationColors = colorBlend;
            FillPill(gradientBrush, RectangleF.Inflate(drawRectF, -3, -3), g);

        }

        /// <summary>
        /// Draws the aqua pill single layer.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="drawRectF">The draw rect f.</param>
        /// <param name="drawColor">Color of the draw.</param>
        /// <param name="orientation">The orientation.</param>
        public static void DrawAquaPillSingleLayer(Graphics g, RectangleF drawRectF, Color drawColor, Orientation orientation)
        {
            Color color1;
            Color color2;
            Color color3;
            Color color4;
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush;
            System.Drawing.Drawing2D.ColorBlend colorBlend = new System.Drawing.Drawing2D.ColorBlend();

            color1 = drawColor;
            color2 = ControlPaint.Light(color1);
            color3 = ControlPaint.Light(color2);
            color4 = ControlPaint.Light(color3);

            colorBlend.Colors = new Color[] { color1, color2, color3, color4 };
            colorBlend.Positions = new float[] { 0, 0.25f, 0.65f, 1 };

            if (orientation == Orientation.Horizontal)
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left, (int)drawRectF.Top + (int)drawRectF.Height), color1, color4);
            else
                gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point((int)drawRectF.Left, (int)drawRectF.Top), new Point((int)drawRectF.Left + (int)drawRectF.Width, (int)drawRectF.Top), color1, color4);
            gradientBrush.InterpolationColors = colorBlend;

            FillPill(gradientBrush, drawRectF, g);

        }


        /// <summary>
        /// Fills the pill.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="g">The g.</param>
        public static void FillPill(Brush b, RectangleF rect, Graphics g)
        {
            if (rect.Width > rect.Height)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillEllipse(b, new RectangleF(rect.Left, rect.Top, rect.Height, rect.Height));
                g.FillEllipse(b, new RectangleF(rect.Left + rect.Width - rect.Height, rect.Top, rect.Height, rect.Height));

                float w = rect.Width - rect.Height;
                float l = rect.Left + ((rect.Height) / 2);
                g.FillRectangle(b, new RectangleF(l, rect.Top, w, rect.Height));
                g.SmoothingMode = SmoothingMode.Default;
            }
            else if (rect.Width < rect.Height)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillEllipse(b, new RectangleF(rect.Left, rect.Top, rect.Width, rect.Width));
                g.FillEllipse(b, new RectangleF(rect.Left, rect.Top + rect.Height - rect.Width, rect.Width, rect.Width));

                float t = rect.Top + (rect.Width / 2);
                float h = rect.Height - rect.Width;
                g.FillRectangle(b, new RectangleF(rect.Left, t, rect.Width, h));
                g.SmoothingMode = SmoothingMode.Default;
            }
            else if (rect.Width == rect.Height)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.FillEllipse(b, rect);
                g.SmoothingMode = SmoothingMode.Default;
            }
        }

    }
    #endregion

    #region Control

    #region Declaration

    /// <summary>
    /// Represents the method that will handle a change in value.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="value">The value.</param>
    public delegate void ValueChangedHandler(object sender, decimal value);

    /// <summary>
    /// Enum MACBorderStyle
    /// </summary>
    public enum MACBorderStyle
    {
        /// <summary>
        /// No border.
        /// </summary>
        None,
        /// <summary>
        /// A dashed border.
        /// </summary>
        Dashed, //from ButtonBorderStyle Enumeration
                /// <summary>
                /// A dotted-line border.
                /// </summary>
        Dotted, //from ButtonBorderStyle Enumeration
                /// <summary>
                /// A sunken border.
                /// </summary>
        Inset, //from ButtonBorderStyle Enumeration
               /// <summary>
               /// A raised border.
               /// </summary>
        Outset, //from ButtonBorderStyle Enumeration
                /// <summary>
                /// A solid border.
                /// </summary>
        Solid, //from ButtonBorderStyle Enumeration

        /// <summary>
        /// The border is drawn outside the specified rectangle, preserving the dimensions of the rectangle for drawing.
        /// </summary>
        Adjust, //from Border3DStyle Enumeration
                /// <summary>
                /// The inner and outer edges of the border have a raised appearance.
                /// </summary>
        Bump, //from Border3DStyle Enumeration
              /// <summary>
              /// The inner and outer edges of the border have an etched appearance.
              /// </summary>
        Etched, //from Border3DStyle Enumeration
                /// <summary>
                /// The border has no three-dimensional effects.
                /// </summary>
        Flat, //from Border3DStyle Enumeration
              /// <summary>
              /// The border has raised inner and outer edges.
              /// </summary>
        Raised, //from Border3DStyle Enumeration
                /// <summary>
                /// The border has a raised inner edge and no outer edge.
                /// </summary>
        RaisedInner, //from Border3DStyle Enumeration
                     /// <summary>
                     /// The border has a raised outer edge and no inner edge.
                     /// </summary>
        RaisedOuter, //from Border3DStyle Enumeration
                     /// <summary>
                     /// The border has sunken inner and outer edges.
                     /// </summary>
        Sunken, //from Border3DStyle Enumeration
                /// <summary>
                /// The border has a sunken inner edge and no outer edge.
                /// </summary>
        SunkenInner, //from Border3DStyle Enumeration
                     /// <summary>
                     /// The border has a sunken outer edge and no inner edge.
                     /// </summary>
        SunkenOuter //from Border3DStyle Enumeration
    }

    #endregion

    #region Control
    /// <summary>
    /// <para>
    /// A class collection that represents an advanced track bar that has improved features than the
    /// standard trackbar.
    /// </para>
    /// <para>
    /// This Trackbar supports the following features:
    /// <list type="bullet"><item><c>MAC style, Office2003 style, IDE2003 style and Plain style.</c></item><item><c>Vertical and Horizontal trackbar.</c></item><item><c>Supports many Text Tick styles: None, TopLeft, BottomRight, Both. You can change Text Font, ForeColor.</c></item><item><c>Supports many Tick styles: None, TopLeft, BottomRight, Both.</c></item><item><c>You can change <see cref="ZeroitOSXBar.TickColor" />, <see cref="ZeroitOSXBar.TickFrequency" />, <see cref="MACTrackBar.TickHeight" />.</c></item><item><c>You can change <see cref="ZeroitOSXBar.TrackerColor" /> and <see cref="ZeroitOSXBar.TrackerSize" />.</c></item><item><c>You can change <see cref="ZeroitOSXBar.TrackLineColor" /> and <see cref="ZeroitOSXBar.TrackLineHeight" />.</c></item><item><c>Easy to Use and Integrate in Visual Studio .NET.</c></item><item><c>100% compatible to the standard control in VS.NET.</c></item><item><c>100% managed code.</c></item><item><c>No coding RAD component.</c></item></list></para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("MACTrackBar represents an advanced track bar that is very better than the standard trackbar.")]
    [ToolboxBitmap(typeof(ZeroitOSXBar), "Editors.MACTrackBar.MACTrackBar.bmp")]
    [Designer(typeof(ZeroitOSXBarDesigner))]
    [DefaultProperty("Maximum")]
    [DefaultEvent("ValueChanged")]
    public class ZeroitOSXBar : System.Windows.Forms.Control
    {

        #region Private Members

        // Instance fields
        /// <summary>
        /// The value
        /// </summary>
        private int _value = 0;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _maximum = 10;

        /// <summary>
        /// The large change
        /// </summary>
        private int _largeChange = 2;
        /// <summary>
        /// The small change
        /// </summary>
        private int _smallChange = 1;

        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation _orientation = Orientation.Horizontal;

        /// <summary>
        /// The border style
        /// </summary>
        private MACBorderStyle _borderStyle = MACBorderStyle.None;
        /// <summary>
        /// The border color
        /// </summary>
        private Color _borderColor = SystemColors.ActiveBorder;

        /// <summary>
        /// The tracker size
        /// </summary>
        private Size _trackerSize = new Size(10, 20);
        /// <summary>
        /// The indent width
        /// </summary>
        private int _indentWidth = 6;
        /// <summary>
        /// The indent height
        /// </summary>
        private int _indentHeight = 6;

        /// <summary>
        /// The tick height
        /// </summary>
        private int _tickHeight = 2;
        /// <summary>
        /// The tick frequency
        /// </summary>
        private int _tickFrequency = 1;
        /// <summary>
        /// The tick color
        /// </summary>
        private Color _tickColor = Color.Black;
        /// <summary>
        /// The tick style
        /// </summary>
        private TickStyle _tickStyle = TickStyle.BottomRight;
        /// <summary>
        /// The text tick style
        /// </summary>
        private TickStyle _textTickStyle = TickStyle.BottomRight;

        /// <summary>
        /// The track line height
        /// </summary>
        private int _trackLineHeight = 3;
        /// <summary>
        /// The track line color
        /// </summary>
        private Color _trackLineColor = SystemColors.Control;

        /// <summary>
        /// The tracker color
        /// </summary>
        private Color _trackerColor = SystemColors.Control;
        /// <summary>
        /// The tracker rect
        /// </summary>
        public RectangleF _trackerRect = RectangleF.Empty;

        /// <summary>
        /// The automatic size
        /// </summary>
        private bool _autoSize = true;

        /// <summary>
        /// The left button down
        /// </summary>
        private bool leftButtonDown = false;
        /// <summary>
        /// The mouse start position
        /// </summary>
        private float mouseStartPos = -1;

        /// <summary>
        /// Occurs when the property Value has been changed.
        /// </summary>
        public event ValueChangedHandler ValueChanged;
        /// <summary>
        /// Occurs when either a mouse or keyboard action moves the slider.
        /// </summary>
        public event EventHandler Scroll;

        #endregion

        #region Public Contruction

        /// <summary>
        /// Constructor method of <see cref="ZeroitOSXBar" /> class
        /// </summary>
        public ZeroitOSXBar()
        {
            base.MouseDown += new MouseEventHandler(OnMouseDownSlider);
            base.MouseUp += new MouseEventHandler(OnMouseUpSlider);
            base.MouseMove += new MouseEventHandler(OnMouseMoveSlider);

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            ForeColor = Color.FromArgb(123, 125, 123);
            BackColor = Color.Transparent;

            _tickColor = Color.FromArgb(148, 146, 148);
            _tickHeight = 4;

            _trackerColor = Color.FromArgb(24, 130, 198);
            _trackerSize = new Size(16, 16);
            _indentWidth = 6;
            _indentHeight = 6;

            _trackLineColor = Color.FromArgb(90, 93, 90);
            _trackLineHeight = 3;

            _borderStyle = MACBorderStyle.None;
            _borderColor = SystemColors.ActiveBorder;

            _autoSize = true;
            this.Height = FitSize.Height;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this._autoSize)
            {
                // Calculate the Position for children controls
                if (_orientation == Orientation.Horizontal)
                {
                    this.Height = FitSize.Height;
                }
                else
                {
                    this.Width = FitSize.Width;
                }
                //=================================================
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the height or width of the track bar is being automatically sized.
        /// </summary>
        /// <value>true if the track bar is being automatically sized; otherwise, false. The default is true.</value>
        /// <remarks>You can set the AutoSize property to true to cause the track bar to adjust either its height or width, depending on orientation, to ensure that the control uses only the required amount of space.</remarks>
        [Category("Behavior")]
        [Description("Gets or sets the height of track line.")]
        [DefaultValue(true)]
        public bool AutoSize
        {
            get { return _autoSize; }

            set
            {
                if (_autoSize != value)
                {
                    _autoSize = value;
                    if (_autoSize == true)
                        this.Size = FitSize;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value to be added to or subtracted from the <see cref="Value" /> property when the slider is moved a large distance.
        /// </summary>
        /// <value>A numeric value. The default value is 2.</value>
        /// <remarks>When the user presses the PAGE UP or PAGE DOWN key or clicks the track bar on either side of the slider, the <see cref="Value" />
        /// property changes according to the value set in the <see cref="LargeChange" /> property.
        /// You might consider setting the <see cref="LargeChange" /> value to a percentage of the <see cref="Control.Height" /> (for a vertically oriented track bar) or
        /// <see cref="Control.Width" /> (for a horizontally oriented track bar) values. This keeps the distance your track bar moves proportionate to its size.</remarks>
        [Category("Behavior")]
        [Description("Gets or sets a value to be added to or subtracted from the Value property when the slider is moved a large distance.")]
        [DefaultValue(2)]
        public int LargeChange
        {
            get { return _largeChange; }

            set
            {
                _largeChange = value;
                if (_largeChange < 1)
                    _largeChange = 1;
            }
        }

        /// <summary>
        /// Gets or sets a value to be added to or subtracted from the <see cref="Value" /> property when the slider is moved a small distance.
        /// </summary>
        /// <value>A numeric value. The default value is 1.</value>
        /// <remarks>When the user presses one of the arrow keys, the <see cref="Value" /> property changes according to the value set in the SmallChange property.
        /// You might consider setting the <see cref="SmallChange" /> value to a percentage of the <see cref="Control.Height" /> (for a vertically oriented track bar) or
        /// <see cref="Control.Width" /> (for a horizontally oriented track bar) values. This keeps the distance your track bar moves proportionate to its size.</remarks>
        [Category("Behavior")]
        [Description("Gets or sets a value to be added to or subtracted from the Value property when the slider is moved a small distance.")]
        [DefaultValue(1)]
        public int SmallChange
        {
            get { return _smallChange; }

            set
            {
                _smallChange = value;
                if (_smallChange < 1)
                    _smallChange = 1;
            }
        }

        /// <summary>
        /// Gets or sets the height of track line.
        /// </summary>
        /// <value>The default value is 4.</value>
        [Category("Appearance")]
        [Description("Gets or sets the height of track line.")]
        [DefaultValue(4)]
        public int TrackLineHeight
        {
            get { return _trackLineHeight; }

            set
            {
                if (_trackLineHeight != value)
                {
                    _trackLineHeight = value;
                    if (_trackLineHeight < 1)
                        _trackLineHeight = 1;

                    if (_trackLineHeight > _trackerSize.Height)
                        _trackLineHeight = _trackerSize.Height;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the tick's <see cref="Color" /> of the control.
        /// </summary>
        /// <value>The color of the tick.</value>
        [Category("Appearance")]
        [Description("Gets or sets the tick's color of the control.")]
        public Color TickColor
        {
            get { return _tickColor; }

            set
            {
                if (_tickColor != value)
                {
                    _tickColor = value;
                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets a value that specifies the delta between ticks drawn on the control.
        /// </summary>
        /// <value>The numeric value representing the delta between ticks. The default is 1.</value>
        /// <remarks>For a <see cref="MACTrackBar" /> with a large range of values between the <see cref="Minimum" /> and the
        /// <see cref="Maximum" />, it might be impractical to draw all the ticks for values on the control.
        /// For example, if you have a control with a range of 100, passing in a value of
        /// five here causes the control to draw 20 ticks. In this case, each tick
        /// represents five units in the range of values.</remarks>
        [Category("Appearance")]
        [Description("Gets or sets a value that specifies the delta between ticks drawn on the control.")]
        [DefaultValue(1)]
        public int TickFrequency
        {
            get { return _tickFrequency; }

            set
            {
                if (_tickFrequency != value)
                {
                    _tickFrequency = value;
                    if (_tickFrequency < 1)
                        _tickFrequency = 1;
                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the height of tick.
        /// </summary>
        /// <value>The height of tick in pixels. The default value is 2.</value>
        [Category("Appearance")]
        [Description("Gets or sets the height of tick.")]
        [DefaultValue(6)]
        public int TickHeight
        {
            get { return _tickHeight; }

            set
            {
                if (_tickHeight != value)
                {
                    _tickHeight = value;

                    if (_tickHeight < 1)
                        _tickHeight = 1;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of indent (or Padding-Y).
        /// </summary>
        /// <value>The height of indent in pixels. The default value is 6.</value>
        [Category("Appearance")]
        [Description("Gets or sets the height of indent.")]
        [DefaultValue(2)]
        public int IndentHeight
        {
            get { return _indentHeight; }

            set
            {
                if (_indentHeight != value)
                {
                    _indentHeight = value;
                    if (_indentHeight < 0)
                        _indentHeight = 0;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the width of indent (or Padding-Y).
        /// </summary>
        /// <value>The width of indent in pixels. The default value is 6.</value>
        [Category("Appearance")]
        [Description("Gets or sets the width of indent.")]
        [DefaultValue(6)]
        public int IndentWidth
        {
            get { return _indentWidth; }

            set
            {
                if (_indentWidth != value)
                {
                    _indentWidth = value;
                    if (_indentWidth < 0)
                        _indentWidth = 0;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the tracker's size.
        /// The tracker's width must be greater or equal to tracker's height.
        /// </summary>
        /// <value>The <see cref="Size" /> object that represents the height and width of the tracker in pixels.</value>
        [Category("Appearance")]
        [Description("Gets or sets the tracker's size.")]
        public Size TrackerSize
        {
            get { return _trackerSize; }

            set
            {
                if (_trackerSize != value)
                {
                    _trackerSize = value;
                    if (_trackerSize.Width > _trackerSize.Height)
                        _trackerSize.Height = _trackerSize.Width;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the text tick style of the trackbar.
        /// There are 4 styles for selection: None, TopLeft, BottomRight, Both.
        /// </summary>
        /// <value>One of the <see cref="TickStyle" /> values. The default is <b>BottomRight</b>.</value>
        /// <remarks>You can use the <see cref="Control.Font" />, <see cref="Control.ForeColor" />
        /// properties to customize the tick text.</remarks>
        [Category("Appearance")]
        [Description("Gets or sets the text tick style.")]
        [DefaultValue(TickStyle.BottomRight)]
        public TickStyle TextTickStyle
        {
            get { return _textTickStyle; }

            set
            {
                if (_textTickStyle != value)
                {
                    _textTickStyle = value;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or sets the tick style of the trackbar.
        /// There are 4 styles for selection: None, TopLeft, BottomRight, Both.
        /// </summary>
        /// <value>One of the <see cref="TickStyle" /> values. The default is <b>BottomRight</b>.</value>
        /// <remarks>You can use the <see cref="TickColor" />, <see cref="TickFrequency" />,
        /// <see cref="TickHeight" /> properties to customize the trackbar's ticks.</remarks>
        [Category("Appearance")]
        [Description("Gets or sets the tick style.")]
        [DefaultValue(TickStyle.BottomRight)]
        public TickStyle TickStyle
        {
            get { return _tickStyle; }

            set
            {
                if (_tickStyle != value)
                {
                    _tickStyle = value;

                    if (_autoSize == true)
                        this.Size = FitSize;

                    this.Invalidate();
                }

            }
        }

        /// <summary>
        /// Gets or set tracker's color.
        /// </summary>
        /// <value><remarks>You can change size of tracker by <see cref="TrackerSize" /> property.</remarks>
        /// A <see cref="Color" /> that represents the color of the tracker.</value>
        [Description("Gets or set tracker's color.")]
        [Category("Appearance")]
        public Color TrackerColor
        {
            get
            {
                return _trackerColor;
            }
            set
            {
                if (_trackerColor != value)
                {
                    _trackerColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the slider on the track bar.
        /// </summary>
        /// <value>A numeric value that is within the <see cref="Minimum" /> and <see cref="Maximum" /> range.
        /// The default value is 0.</value>
        /// <remarks>The Value property contains the number that represents the current position of the slider on the track bar.</remarks>
        [Description("The current value for the MACTrackBar, in the range specified by the Minimum and Maximum properties.")]
        [Category("Behavior")]
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    if (value < _minimum)
                        _value = _minimum;
                    else
                        if (value > _maximum)
                        _value = _maximum;
                    else
                        _value = value;

                    OnValueChanged(_value);

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the lower limit of the range this <see cref="MACTrackBar" /> is working with.
        /// </summary>
        /// <value>The minimum value for the <see cref="MACTrackBar" />. The default value is 0.</value>
        /// <remarks>You can use the <see cref="SetRange" /> method to set both the <see cref="Maximum" /> and <see cref="Minimum" /> properties at the same time.</remarks>
        [Description("The lower bound of the range this MACTrackBar is working with.")]
        [Category("Behavior")]
        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;

                if (_minimum > _maximum)
                    _maximum = _minimum;
                if (_minimum > _value)
                    _value = _minimum;

                if (_autoSize == true)
                    this.Size = FitSize;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the upper limit of the range this <see cref="MACTrackBar" /> is working with.
        /// </summary>
        /// <value>The maximum value for the <see cref="MACTrackBar" />. The default value is 10.</value>
        /// <remarks>You can use the <see cref="SetRange" /> method to set both the <see cref="Maximum" /> and <see cref="Minimum" /> properties at the same time.</remarks>
        [Description("The uppper bound of the range this MACTrackBar is working with.")]
        [Category("Behavior")]
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;

                if (_maximum < _value)
                    _value = _maximum;
                if (_maximum < _minimum)
                    _minimum = _maximum;

                if (_autoSize == true)
                    this.Size = FitSize;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the horizontal or vertical orientation of the track bar.
        /// </summary>
        /// <value>One of the <see cref="Orientation" /> values. The default value is <b>Horizontal</b>.</value>
        /// <remarks>When the <b>Orientation</b> property is set to <b>Orientation.Horizontal</b>,
        /// the slider moves from left to right as the <see cref="Value" /> increases.
        /// When the <b>Orientation</b> property is set to <b>Orientation.Vertical</b>, the slider moves
        /// from bottom to top as the <see cref="Value" /> increases.</remarks>
        [Description("Gets or sets a value indicating the horizontal or vertical orientation of the track bar.")]
        [Category("Behavior")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                if (value != _orientation)
                {
                    _orientation = value;
                    if (_orientation == Orientation.Horizontal)
                    {
                        if (this.Width < this.Height)
                        {
                            int temp = this.Width;
                            this.Width = this.Height;
                            this.Height = temp;
                        }
                    }
                    else //Vertical 
                    {
                        if (this.Width > this.Height)
                        {
                            int temp = this.Width;
                            this.Width = this.Height;
                            this.Height = temp;
                        }
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border type of the trackbar control.
        /// </summary>
        /// <value>A <see cref="MACBorderStyle" /> that represents the border type of the trackbar control.
        /// The default is <b>MACBorderStyle.None</b>.</value>
        [Description("Gets or sets the border type of the trackbar control.")]
        [Category("Appearance"), DefaultValue(typeof(MACBorderStyle), "None")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public MACBorderStyle BorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                if (_borderStyle != value)
                {
                    _borderStyle = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border color of the control.
        /// </summary>
        /// <value>A <see cref="Color" /> object that represents the border color of the control.</value>
        [Category("Appearance")]
        [Description("Gets or sets the border color of the control.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (value != _borderColor)
                {
                    _borderColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the track line.
        /// </summary>
        /// <value>A <see cref="Color" /> object that represents the color of the track line.</value>
        [Category("Appearance")]
        [Description("Gets or sets the color of the track line.")]
        public Color TrackLineColor
        {
            get { return _trackLineColor; }
            set
            {
                if (value != _trackLineColor)
                {
                    _trackLineColor = value;
                    Invalidate();
                }
            }
        }


        #endregion

        #region Private Properties

        /// <summary>
        /// Gets the Size of area need for drawing.
        /// </summary>
        /// <value>The size of the fit.</value>
        [Description("Gets the Size of area need for drawing.")]
        [Browsable(false)]
        private Size FitSize
        {
            get
            {
                Size fitSize;
                float textAreaSize;

                // Create a Graphics object for the Control.
                Graphics g = this.CreateGraphics();

                Rectangle workingRect = Rectangle.Inflate(this.ClientRectangle, -_indentWidth, -_indentHeight);
                float currentUsedPos = 0;

                if (_orientation == Orientation.Horizontal)
                {
                    currentUsedPos = _indentHeight;
                    //==========================================================================

                    // Get Height of Text Area
                    textAreaSize = g.MeasureString(_maximum.ToString(), this.Font).Height;

                    if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                        currentUsedPos += _tickHeight + 1;

                    currentUsedPos += _trackerSize.Height;

                    if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                    {
                        currentUsedPos += 1;
                        currentUsedPos += _tickHeight;
                    }

                    if (_textTickStyle == TickStyle.BottomRight || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    currentUsedPos += _indentHeight;

                    fitSize = new Size(this.ClientRectangle.Width, (int)currentUsedPos);
                }
                else //_orientation == Orientation.Vertical
                {
                    currentUsedPos = _indentWidth;
                    //==========================================================================

                    // Get Width of Text Area
                    textAreaSize = g.MeasureString(_maximum.ToString(), this.Font).Width;

                    if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                        currentUsedPos += _tickHeight + 1;

                    currentUsedPos += _trackerSize.Height;

                    if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                    {
                        currentUsedPos += 1;
                        currentUsedPos += _tickHeight;
                    }

                    if (_textTickStyle == TickStyle.BottomRight || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    currentUsedPos += _indentWidth;

                    fitSize = new Size((int)currentUsedPos, this.ClientRectangle.Height);

                }

                // Clean up the Graphics object.
                g.Dispose();

                return fitSize;
            }
        }


        /// <summary>
        /// Gets the rectangle containing the tracker.
        /// </summary>
        /// <value>The tracker rect.</value>
        [Description("Gets the rectangle containing the tracker.")]
        private RectangleF TrackerRect
        {
            get
            {
                RectangleF trackerRect;
                float textAreaSize;

                // Create a Graphics object for the Control.
                Graphics g = this.CreateGraphics();

                Rectangle workingRect = Rectangle.Inflate(this.ClientRectangle, -_indentWidth, -_indentHeight);
                float currentUsedPos = 0;

                if (_orientation == Orientation.Horizontal)
                {
                    currentUsedPos = _indentHeight;
                    //==========================================================================

                    // Get Height of Text Area
                    textAreaSize = g.MeasureString(_maximum.ToString(), this.Font).Height;

                    if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                        currentUsedPos += _tickHeight + 1;


                    //==========================================================================
                    // Caculate the Tracker's rectangle
                    //==========================================================================
                    float currentTrackerPos;
                    if (_maximum == _minimum)
                        currentTrackerPos = workingRect.Left;
                    else
                        currentTrackerPos = (workingRect.Width - _trackerSize.Width) * (_value - _minimum) / (_maximum - _minimum) + workingRect.Left;
                    trackerRect = new RectangleF(currentTrackerPos, currentUsedPos, _trackerSize.Width, _trackerSize.Height);// Remember this for drawing the Tracker later
                    trackerRect.Inflate(0, -1);
                }
                else //_orientation == Orientation.Vertical
                {
                    currentUsedPos = _indentWidth;
                    //==========================================================================

                    // Get Width of Text Area
                    textAreaSize = g.MeasureString(_maximum.ToString(), this.Font).Width;

                    if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                        currentUsedPos += textAreaSize;

                    if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                        currentUsedPos += _tickHeight + 1;

                    //==========================================================================
                    // Caculate the Tracker's rectangle
                    //==========================================================================
                    float currentTrackerPos;
                    if (_maximum == _minimum)
                        currentTrackerPos = workingRect.Top;
                    else
                        currentTrackerPos = (workingRect.Height - _trackerSize.Width) * (_value - _minimum) / (_maximum - _minimum);

                    trackerRect = new RectangleF(currentUsedPos, workingRect.Bottom - currentTrackerPos - _trackerSize.Width, _trackerSize.Height, _trackerSize.Width);// Remember this for drawing the Tracker later
                    trackerRect.Inflate(-1, 0);


                }

                // Clean up the Graphics object.
                g.Dispose();

                return trackerRect;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="value">The new value</param>
        public virtual void OnValueChanged(int value)
        {
            // Any attached event handlers?
            if (ValueChanged != null)
                ValueChanged(this, value);

        }

        /// <summary>
        /// Raises the Scroll event.
        /// </summary>
        public virtual void OnScroll()
        {
            try
            {
                // Any attached event handlers?
                if (Scroll != null)
                    Scroll(this, new System.EventArgs());
            }
            catch (Exception Err)
            {
                MessageBox.Show("OnScroll Exception: " + Err.Message);
            }

        }


        /// <summary>
        /// Call the Increment() method to increase the value displayed by an integer you specify
        /// </summary>
        /// <param name="value">The value.</param>
        public void Increment(int value)
        {
            if (_value < _maximum)
            {
                _value += value;
                if (_value > _maximum)
                    _value = _maximum;
            }
            else
                _value = _maximum;

            OnValueChanged(_value);
            this.Invalidate();
        }

        /// <summary>
        /// Call the Decrement() method to decrease the value displayed by an integer you specify
        /// </summary>
        /// <param name="value">The value to decrement</param>
        public void Decrement(int value)
        {
            if (_value > _minimum)
            {
                _value -= value;
                if (_value < _minimum)
                    _value = _minimum;
            }
            else
                _value = _minimum;

            OnValueChanged(_value);
            this.Invalidate();
        }

        /// <summary>
        /// Sets the minimum and maximum values for a TrackBar.
        /// </summary>
        /// <param name="minValue">The lower limit of the range of the track bar.</param>
        /// <param name="maxValue">The upper limit of the range of the track bar.</param>
        public void SetRange(int minValue, int maxValue)
        {
            _minimum = minValue;

            if (_minimum > _value)
                _value = _minimum;

            _maximum = maxValue;

            if (_maximum < _value)
                _value = _maximum;
            if (_maximum < _minimum)
                _minimum = _maximum;

            this.Invalidate();
        }

        /// <summary>
        /// Reset the appearance properties.
        /// </summary>
        public void ResetAppearance()
        {
            Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            ForeColor = Color.FromArgb(123, 125, 123);
            BackColor = Color.Transparent;

            _tickColor = Color.FromArgb(148, 146, 148);
            _tickHeight = 4;

            _trackerColor = Color.FromArgb(24, 130, 198);
            _trackerSize = new Size(16, 16);
            //_trackerRect.Size = _trackerSize;

            _indentWidth = 6;
            _indentHeight = 6;

            _trackLineColor = Color.FromArgb(90, 93, 90);
            _trackLineHeight = 3;

            _borderStyle = MACBorderStyle.None;
            _borderColor = SystemColors.ActiveBorder;

            //==========================================================================

            if (_autoSize == true)
                this.Size = FitSize;
            Invalidate();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// The OnCreateControl method is called when the control is first created.
        /// </summary>
        protected override void OnCreateControl()
        {
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnLostFocus">Control.OnLostFocus</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.Invalidate();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnGotFocus">Control.OnGotFocus</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            this.Invalidate();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnClick">Control.OnClick</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            this.Invalidate();
            base.OnClick(e);
        }

        /// <summary>
        /// This member overrides <see cref="Control.ProcessCmdKey">Control.ProcessCmdKey</see>.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the character was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool blResult = true;

            /// <summary>
            /// Specified WM_KEYDOWN enumeration value.
            /// </summary>
            const int WM_KEYDOWN = 0x0100;

            /// <summary>
            /// Specified WM_SYSKEYDOWN enumeration value.
            /// </summary>
            const int WM_SYSKEYDOWN = 0x0104;


            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Left:
                    case Keys.Down:
                        this.Decrement(_smallChange);
                        break;
                    case Keys.Right:
                    case Keys.Up:
                        this.Increment(_smallChange);
                        break;

                    case Keys.PageUp:
                        this.Increment(_largeChange);
                        break;
                    case Keys.PageDown:
                        this.Decrement(_largeChange);
                        break;

                    case Keys.Home:
                        Value = _maximum;
                        break;
                    case Keys.End:
                        Value = _minimum;
                        break;

                    default:
                        blResult = base.ProcessCmdKey(ref msg, keyData);
                        break;
                }
            }

            return blResult;
        }

        /// <summary>
        /// Dispose of instance resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region Painting Methods

        /// <summary>
        /// This member overrides <see cref="Control.OnPaint">Control.OnPaint</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush brush;
            RectangleF rectTemp, drawRect;
            float textAreaSize;

            Rectangle workingRect = Rectangle.Inflate(this.ClientRectangle, -_indentWidth, -_indentHeight);
            float currentUsedPos = 0;

            //==========================================================================
            // Draw the background of the ProgressBar control.
            //==========================================================================
            brush = new SolidBrush(this.BackColor);
            rectTemp = this.ClientRectangle;
            e.Graphics.FillRectangle(brush, rectTemp);
            brush.Dispose();
            //==========================================================================

            //==========================================================================
            if (_orientation == Orientation.Horizontal)
            {
                currentUsedPos = _indentHeight;
                //==========================================================================

                // Get Height of Text Area
                textAreaSize = e.Graphics.MeasureString(_maximum.ToString(), this.Font).Height;

                if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 1st Text Line.
                    //==========================================================================
                    drawRect = new RectangleF(workingRect.Left, currentUsedPos, workingRect.Width, textAreaSize);
                    drawRect.Inflate(-_trackerSize.Width / 2, 0);
                    currentUsedPos += textAreaSize;

                    DrawTickTextLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, this.ForeColor, this.Font, _orientation);
                    //==========================================================================
                }

                if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 1st Tick Line.
                    //==========================================================================
                    drawRect = new RectangleF(workingRect.Left, currentUsedPos, workingRect.Width, _tickHeight);
                    drawRect.Inflate(-_trackerSize.Width / 2, 0);
                    currentUsedPos += _tickHeight + 1;

                    DrawTickLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, _tickColor, _orientation);
                    //==========================================================================
                }

                //==========================================================================
                // Caculate the Tracker's rectangle
                //==========================================================================
                float currentTrackerPos;
                if (_maximum == _minimum)
                    currentTrackerPos = workingRect.Left;
                else
                    currentTrackerPos = (workingRect.Width - _trackerSize.Width) * (_value - _minimum) / (_maximum - _minimum) + workingRect.Left;
                _trackerRect = new RectangleF(currentTrackerPos, currentUsedPos, _trackerSize.Width, _trackerSize.Height);// Remember this for drawing the Tracker later
                                                                                                                          //_trackerRect.Inflate(0,-1);

                //==========================================================================
                // Draw the Track Line
                //==========================================================================
                drawRect = new RectangleF(workingRect.Left, currentUsedPos + _trackerSize.Height / 2 - _trackLineHeight / 2, workingRect.Width, _trackLineHeight);
                DrawTrackLine(e.Graphics, drawRect);
                currentUsedPos += _trackerSize.Height;


                //==========================================================================

                if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 2st Tick Line.
                    //==========================================================================
                    currentUsedPos += 1;
                    drawRect = new RectangleF(workingRect.Left, currentUsedPos, workingRect.Width, _tickHeight);
                    drawRect.Inflate(-_trackerSize.Width / 2, 0);
                    currentUsedPos += _tickHeight;

                    DrawTickLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, _tickColor, _orientation);
                    //==========================================================================
                }

                if (_textTickStyle == TickStyle.BottomRight || _textTickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 2st Text Line.
                    //==========================================================================
                    // Get Height of Text Area
                    drawRect = new RectangleF(workingRect.Left, currentUsedPos, workingRect.Width, textAreaSize);
                    drawRect.Inflate(-_trackerSize.Width / 2, 0);
                    currentUsedPos += textAreaSize;

                    DrawTickTextLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, this.ForeColor, this.Font, _orientation);
                    //==========================================================================
                }
            }
            else //_orientation == Orientation.Vertical
            {
                currentUsedPos = _indentWidth;
                //==========================================================================

                // Get Width of Text Area
                textAreaSize = e.Graphics.MeasureString(_maximum.ToString(), this.Font).Width;

                if (_textTickStyle == TickStyle.TopLeft || _textTickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 1st Text Line.
                    //==========================================================================
                    // Get Height of Text Area
                    drawRect = new RectangleF(currentUsedPos, workingRect.Top, textAreaSize, workingRect.Height);
                    drawRect.Inflate(0, -_trackerSize.Width / 2);
                    currentUsedPos += textAreaSize;

                    DrawTickTextLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, this.ForeColor, this.Font, _orientation);
                    //==========================================================================
                }

                if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 1st Tick Line.
                    //==========================================================================
                    drawRect = new RectangleF(currentUsedPos, workingRect.Top, _tickHeight, workingRect.Height);
                    drawRect.Inflate(0, -_trackerSize.Width / 2);
                    currentUsedPos += _tickHeight + 1;

                    DrawTickLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, _tickColor, _orientation);
                    //==========================================================================
                }

                //==========================================================================
                // Caculate the Tracker's rectangle
                //==========================================================================
                float currentTrackerPos;
                if (_maximum == _minimum)
                    currentTrackerPos = workingRect.Top;
                else
                    currentTrackerPos = (workingRect.Height - _trackerSize.Width) * (_value - _minimum) / (_maximum - _minimum);

                _trackerRect = new RectangleF(currentUsedPos, workingRect.Bottom - currentTrackerPos - _trackerSize.Width, _trackerSize.Height, _trackerSize.Width);// Remember this for drawing the Tracker later
                                                                                                                                                                    //_trackerRect.Inflate(-1,0);

                rectTemp = _trackerRect;//Testing

                //==========================================================================
                // Draw the Track Line
                //==========================================================================
                drawRect = new RectangleF(currentUsedPos + _trackerSize.Height / 2 - _trackLineHeight / 2, workingRect.Top, _trackLineHeight, workingRect.Height);
                DrawTrackLine(e.Graphics, drawRect);
                currentUsedPos += _trackerSize.Height;
                //==========================================================================

                if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 2st Tick Line.
                    //==========================================================================
                    currentUsedPos += 1;
                    drawRect = new RectangleF(currentUsedPos, workingRect.Top, _tickHeight, workingRect.Height);
                    drawRect.Inflate(0, -_trackerSize.Width / 2);
                    currentUsedPos += _tickHeight;

                    DrawTickLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, _tickColor, _orientation);
                    //==========================================================================
                }

                if (_textTickStyle == TickStyle.BottomRight || _textTickStyle == TickStyle.Both)
                {
                    //==========================================================================
                    // Draw the 2st Text Line.
                    //==========================================================================
                    // Get Height of Text Area
                    drawRect = new RectangleF(currentUsedPos, workingRect.Top, textAreaSize, workingRect.Height);
                    drawRect.Inflate(0, -_trackerSize.Width / 2);
                    currentUsedPos += textAreaSize;

                    DrawTickTextLine(e.Graphics, drawRect, _tickFrequency, _minimum, _maximum, this.ForeColor, this.Font, _orientation);
                    //==========================================================================
                }
            }

            //==========================================================================
            // Check for special values of Max, Min & Value
            if (_maximum == _minimum)
            {
                // Draw border only and exit;
                DrawBorder(e.Graphics);
                return;
            }
            //==========================================================================

            //==========================================================================
            // Draw the Tracker
            //==========================================================================
            DrawTracker(e.Graphics, _trackerRect);
            //==========================================================================

            // Draw border
            DrawBorder(e.Graphics);
            //==========================================================================

            // Draws a focus rectangle
            //if(this.Focused && this.BackColor != Color.Transparent)
            if (this.Focused)
                ControlPaint.DrawFocusRectangle(e.Graphics, Rectangle.Inflate(this.ClientRectangle, -2, -2));
            //==========================================================================
        }

        /// <summary>
        /// Draws the track line.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="drawRect">The draw rect.</param>
        private void DrawTrackLine(Graphics g, RectangleF drawRect)
        {
            DrawMACStyleHelper.DrawAquaPillSingleLayer(g, drawRect, _trackLineColor, _orientation);
        }

        /// <summary>
        /// Draws the tracker.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="trackerRect">The tracker rect.</param>
        private void DrawTracker(Graphics g, RectangleF trackerRect)
        {
            DrawMACStyleHelper.DrawAquaPill(g, trackerRect, _trackerColor, _orientation);
        }

        /// <summary>
        /// Draws the tick text line.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="drawRect">The draw rect.</param>
        /// <param name="tickFrequency">The tick frequency.</param>
        /// <param name="minimum">The minimum.</param>
        /// <param name="maximum">The maximum.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <param name="font">The font.</param>
        /// <param name="orientation">The orientation.</param>
        private void DrawTickTextLine(Graphics g, RectangleF drawRect, int tickFrequency, int minimum, int maximum, Color foreColor, Font font, Orientation orientation)
        {

            //Check input value
            if (maximum == minimum)
                return;

            //Caculate tick number
            int tickCount = (int)((maximum - minimum) / tickFrequency);
            if ((maximum - minimum) % tickFrequency == 0)
                tickCount -= 1;

            //Prepare for drawing Text
            //===============================================================
            StringFormat stringFormat;
            stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            stringFormat.HotkeyPrefix = HotkeyPrefix.Show;

            Brush brush = new SolidBrush(foreColor);
            string text;
            float tickFrequencySize;
            //===============================================================

            if (_orientation == Orientation.Horizontal)
            {
                // Calculate tick's setting
                tickFrequencySize = drawRect.Width * tickFrequency / (maximum - minimum);

                //===============================================================

                // Draw each tick text
                for (int i = 0; i <= tickCount; i++)
                {
                    text = Convert.ToString(_minimum + tickFrequency * i, 10);
                    g.DrawString(text, font, brush, drawRect.Left + tickFrequencySize * i, drawRect.Top + drawRect.Height / 2, stringFormat);

                }
                // Draw last tick text at Maximum
                text = Convert.ToString(_maximum, 10);
                g.DrawString(text, font, brush, drawRect.Right, drawRect.Top + drawRect.Height / 2, stringFormat);

                //===============================================================
            }
            else //Orientation.Vertical
            {
                // Calculate tick's setting
                tickFrequencySize = drawRect.Height * tickFrequency / (maximum - minimum);
                //===============================================================

                // Draw each tick text
                for (int i = 0; i <= tickCount; i++)
                {
                    text = Convert.ToString(_minimum + tickFrequency * i, 10);
                    g.DrawString(text, font, brush, drawRect.Left + drawRect.Width / 2, drawRect.Bottom - tickFrequencySize * i, stringFormat);
                }
                // Draw last tick text at Maximum
                text = Convert.ToString(_maximum, 10);
                g.DrawString(text, font, brush, drawRect.Left + drawRect.Width / 2, drawRect.Top, stringFormat);
                //===============================================================

            }
        }

        /// <summary>
        /// Draws the tick line.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="drawRect">The draw rect.</param>
        /// <param name="tickFrequency">The tick frequency.</param>
        /// <param name="minimum">The minimum.</param>
        /// <param name="maximum">The maximum.</param>
        /// <param name="tickColor">Color of the tick.</param>
        /// <param name="orientation">The orientation.</param>
        private void DrawTickLine(Graphics g, RectangleF drawRect, int tickFrequency, int minimum, int maximum, Color tickColor, Orientation orientation)
        {
            //Check input value
            if (maximum == minimum)
                return;

            //Create the Pen for drawing Ticks
            Pen pen = new Pen(tickColor, 1);
            float tickFrequencySize;

            //Caculate tick number
            int tickCount = (int)((maximum - minimum) / tickFrequency);
            if ((maximum - minimum) % tickFrequency == 0)
                tickCount -= 1;

            if (_orientation == Orientation.Horizontal)
            {
                // Calculate tick's setting
                tickFrequencySize = drawRect.Width * tickFrequency / (maximum - minimum);

                //===============================================================

                // Draw each tick
                for (int i = 0; i <= tickCount; i++)
                {
                    g.DrawLine(pen, drawRect.Left + tickFrequencySize * i, drawRect.Top, drawRect.Left + tickFrequencySize * i, drawRect.Bottom);
                }
                // Draw last tick at Maximum
                g.DrawLine(pen, drawRect.Right, drawRect.Top, drawRect.Right, drawRect.Bottom);
                //===============================================================
            }
            else //Orientation.Vertical
            {
                // Calculate tick's setting
                tickFrequencySize = drawRect.Height * tickFrequency / (maximum - minimum);
                //===============================================================

                // Draw each tick
                for (int i = 0; i <= tickCount; i++)
                {
                    g.DrawLine(pen, drawRect.Left, drawRect.Bottom - tickFrequencySize * i, drawRect.Right, drawRect.Bottom - tickFrequencySize * i);
                }
                // Draw last tick at Maximum
                g.DrawLine(pen, drawRect.Left, drawRect.Top, drawRect.Right, drawRect.Top);
                //===============================================================
            }
        }

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBorder(Graphics g)
        {

            switch (_borderStyle)
            {
                case MACBorderStyle.Dashed: //from ButtonBorderStyle Enumeration
                    ControlPaint.DrawBorder(g, this.ClientRectangle, _borderColor, ButtonBorderStyle.Dashed);
                    break;
                case MACBorderStyle.Dotted: //from ButtonBorderStyle Enumeration
                    ControlPaint.DrawBorder(g, this.ClientRectangle, _borderColor, ButtonBorderStyle.Dotted);
                    break;
                case MACBorderStyle.Inset: //from ButtonBorderStyle Enumeration
                    ControlPaint.DrawBorder(g, this.ClientRectangle, _borderColor, ButtonBorderStyle.Inset);
                    break;
                case MACBorderStyle.Outset: //from ButtonBorderStyle Enumeration
                    ControlPaint.DrawBorder(g, this.ClientRectangle, _borderColor, ButtonBorderStyle.Outset);
                    break;
                case MACBorderStyle.Solid: //from ButtonBorderStyle Enumeration
                    ControlPaint.DrawBorder(g, this.ClientRectangle, _borderColor, ButtonBorderStyle.Solid);
                    break;

                case MACBorderStyle.Adjust: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Adjust);
                    break;
                case MACBorderStyle.Bump: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Bump);
                    break;
                case MACBorderStyle.Etched: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Etched);
                    break;
                case MACBorderStyle.Flat: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Flat);
                    break;
                case MACBorderStyle.Raised: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Raised);
                    break;
                case MACBorderStyle.RaisedInner: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.RaisedInner);
                    break;
                case MACBorderStyle.RaisedOuter: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.RaisedOuter);
                    break;
                case MACBorderStyle.Sunken: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Sunken);
                    break;
                case MACBorderStyle.SunkenInner: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenInner);
                    break;
                case MACBorderStyle.SunkenOuter: //from Border3DStyle Enumeration
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.SunkenOuter);
                    break;
                case MACBorderStyle.None:
                default:
                    break;
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the <see cref="E:MouseDownSlider" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseDownSlider(object sender, MouseEventArgs e)
        {
            int offsetValue = 0;
            int oldValue = 0;
            PointF currentPoint;

            currentPoint = new PointF(e.X, e.Y);
            if (_trackerRect.Contains(currentPoint))
            {
                if (!leftButtonDown)
                {
                    leftButtonDown = true;
                    this.Capture = true;
                    switch (this._orientation)
                    {
                        case Orientation.Horizontal:
                            mouseStartPos = currentPoint.X - _trackerRect.X;
                            break;

                        case Orientation.Vertical:
                            mouseStartPos = currentPoint.Y - _trackerRect.Y;
                            break;
                    }
                }
            }
            else
            {
                switch (this._orientation)
                {
                    case Orientation.Horizontal:
                        if (currentPoint.X + _trackerSize.Width / 2 >= this.Width - _indentWidth)
                            offsetValue = _maximum - _minimum;
                        else if (currentPoint.X - _trackerSize.Width / 2 <= _indentWidth)
                            offsetValue = 0;
                        else
                            offsetValue = (int)(((currentPoint.X - _indentWidth - _trackerSize.Width / 2) * (_maximum - _minimum)) / (this.Width - 2 * _indentWidth - _trackerSize.Width) + 0.5);

                        break;

                    case Orientation.Vertical:
                        if (currentPoint.Y + _trackerSize.Width / 2 >= this.Height - _indentHeight)
                            offsetValue = 0;
                        else if (currentPoint.Y - _trackerSize.Width / 2 <= _indentHeight)
                            offsetValue = _maximum - _minimum;
                        else
                            offsetValue = (int)(((this.Height - currentPoint.Y - _indentHeight - _trackerSize.Width / 2) * (_maximum - _minimum)) / (this.Height - 2 * _indentHeight - _trackerSize.Width) + 0.5);

                        break;

                    default:
                        break;
                }

                oldValue = _value;
                _value = _minimum + offsetValue;
                this.Invalidate();

                if (oldValue != _value)
                {
                    OnScroll();
                    OnValueChanged(_value);
                }
            }

        }

        /// <summary>
        /// Handles the <see cref="E:MouseUpSlider" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseUpSlider(object sender, MouseEventArgs e)
        {
            leftButtonDown = false;
            this.Capture = false;

        }

        /// <summary>
        /// Handles the <see cref="E:MouseMoveSlider" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseMoveSlider(object sender, MouseEventArgs e)
        {
            int offsetValue = 0;
            int oldValue = 0;
            PointF currentPoint;

            currentPoint = new PointF(e.X, e.Y);

            if (leftButtonDown)
            {
                try
                {
                    switch (this._orientation)
                    {
                        case Orientation.Horizontal:
                            if ((currentPoint.X + _trackerSize.Width - mouseStartPos) >= this.Width - _indentWidth)
                                offsetValue = _maximum - _minimum;
                            else if (currentPoint.X - mouseStartPos <= _indentWidth)
                                offsetValue = 0;
                            else
                                offsetValue = (int)(((currentPoint.X - mouseStartPos - _indentWidth) * (_maximum - _minimum)) / (this.Width - 2 * _indentWidth - _trackerSize.Width) + 0.5);

                            break;

                        case Orientation.Vertical:
                            if (currentPoint.Y + _trackerSize.Width / 2 >= this.Height - _indentHeight)
                                offsetValue = 0;
                            else if (currentPoint.Y + _trackerSize.Width / 2 <= _indentHeight)
                                offsetValue = _maximum - _minimum;
                            else
                                offsetValue = (int)(((this.Height - currentPoint.Y + _trackerSize.Width / 2 - mouseStartPos - _indentHeight) * (_maximum - _minimum)) / (this.Height - 2 * _indentHeight) + 0.5);

                            break;
                    }

                }
                catch (Exception) { }
                finally
                {
                    oldValue = _value;
                    Value = _minimum + offsetValue;
                    this.Invalidate();

                    if (oldValue != _value)
                    {
                        OnScroll();
                        OnValueChanged(_value);
                    }
                }
            }

        }


        #endregion

    }
    #endregion

    #endregion

    #region Designer

    /// <summary>
    /// The Designer for the <see cref="MACTrackBar" />.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    //public class MACTrackBarDesigner : System.Windows.Forms.Design.ControlDesigner
    //   {
    //       public MACTrackBarDesigner()
    //       { }

    //       /// <summary>
    //       /// Returns the allowable design time selection rules.
    //       /// </summary>
    //       public override SelectionRules SelectionRules
    //       {

    //           get
    //           {
    //               ZeroitOSXBar control = this.Control as ZeroitOSXBar;

    //               // Disallow vertical or horizontal sizing when AutoSize = True
    //               if (control != null && control.AutoSize == true)
    //                   if (control.Orientation == Orientation.Horizontal)
    //                       return (base.SelectionRules & ~SelectionRules.TopSizeable) & ~SelectionRules.BottomSizeable;
    //                   else //control.Orientation == Orientation.Vertical
    //                       return (base.SelectionRules & ~SelectionRules.LeftSizeable) & ~SelectionRules.RightSizeable;
    //               else
    //                   return base.SelectionRules;

    //           }
    //       }



    //       //Overrides
    //       /// <summary>
    //       /// Remove Button and Control properties that are 
    //       /// not supported by the <see cref="MACTrackBar"/>.
    //       /// </summary>
    //       protected override void PostFilterProperties(IDictionary Properties)
    //       {
    //           Properties.Remove("AllowDrop");
    //           Properties.Remove("BackgroundImage");
    //           Properties.Remove("ContextMenu");

    //           Properties.Remove("Text");
    //           Properties.Remove("TextAlign");
    //           Properties.Remove("RightToLeft");
    //       }


    //       //Overrides
    //       /// <summary>
    //       /// Remove Button and Control events that are 
    //       /// not supported by the <see cref="MACTrackBar"/>.
    //       /// </summary>
    //       protected override void PostFilterEvents(IDictionary events)
    //       {
    //           //Actions
    //           events.Remove("Click");
    //           events.Remove("DoubleClick");

    //           //Appearence
    //           events.Remove("Paint");

    //           //Behavior
    //           events.Remove("ChangeUICues");
    //           events.Remove("ImeModeChanged");
    //           events.Remove("QueryAccessibilityHelp");
    //           events.Remove("StyleChanged");
    //           events.Remove("SystemColorsChanged");

    //           //Drag Drop
    //           events.Remove("DragDrop");
    //           events.Remove("DragEnter");
    //           events.Remove("DragLeave");
    //           events.Remove("DragOver");
    //           events.Remove("GiveFeedback");
    //           events.Remove("QueryContinueDrag");
    //           events.Remove("DragDrop");

    //           //Layout
    //           events.Remove("Layout");
    //           events.Remove("Move");
    //           events.Remove("Resize");

    //           //Property Changed
    //           events.Remove("BackColorChanged");
    //           events.Remove("BackgroundImageChanged");
    //           events.Remove("BindingContextChanged");
    //           events.Remove("CausesValidationChanged");
    //           events.Remove("CursorChanged");
    //           events.Remove("FontChanged");
    //           events.Remove("ForeColorChanged");
    //           events.Remove("RightToLeftChanged");
    //           events.Remove("SizeChanged");
    //           events.Remove("TextChanged");

    //           base.PostFilterEvents(events);
    //       }

    //   }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitOSXBarDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOSXBarDesigner"/> class.
        /// </summary>
        public ZeroitOSXBarDesigner()
        { }

        /// <summary>
        /// Returns the allowable design time selection rules.
        /// </summary>
        /// <value>The selection rules.</value>
        public override SelectionRules SelectionRules
        {

            get
            {
                ZeroitOSXBar control = this.Control as ZeroitOSXBar;

                // Disallow vertical or horizontal sizing when AutoSize = True
                if (control != null && control.AutoSize == true)
                    if (control.Orientation == Orientation.Horizontal)
                        return (base.SelectionRules & ~SelectionRules.TopSizeable) & ~SelectionRules.BottomSizeable;
                    else //control.Orientation == Orientation.Vertical
                        return (base.SelectionRules & ~SelectionRules.LeftSizeable) & ~SelectionRules.RightSizeable;
                else
                    return base.SelectionRules;

            }
        }



        //Overrides
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="ZeroitOSXBar" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            Properties.Remove("AllowDrop");
            Properties.Remove("BackgroundImage");
            Properties.Remove("ContextMenu");

            Properties.Remove("Text");
            Properties.Remove("TextAlign");
            Properties.Remove("RightToLeft");
        }


        //Overrides
        /// <summary>
        /// Remove Button and Control events that are
        /// not supported by the <see cref="MACTrackBar" />.
        /// </summary>
        /// <param name="events">The events for the class of the component.</param>
        protected override void PostFilterEvents(IDictionary events)
        {
            //Actions
            events.Remove("Click");
            events.Remove("DoubleClick");

            //Appearence
            events.Remove("Paint");

            //Behavior
            events.Remove("ChangeUICues");
            events.Remove("ImeModeChanged");
            events.Remove("QueryAccessibilityHelp");
            events.Remove("StyleChanged");
            events.Remove("SystemColorsChanged");

            //Drag Drop
            events.Remove("DragDrop");
            events.Remove("DragEnter");
            events.Remove("DragLeave");
            events.Remove("DragOver");
            events.Remove("GiveFeedback");
            events.Remove("QueryContinueDrag");
            events.Remove("DragDrop");

            //Layout
            events.Remove("Layout");
            events.Remove("Move");
            events.Remove("Resize");

            //Property Changed
            events.Remove("BackColorChanged");
            events.Remove("BackgroundImageChanged");
            events.Remove("BindingContextChanged");
            events.Remove("CausesValidationChanged");
            events.Remove("CursorChanged");
            events.Remove("FontChanged");
            events.Remove("ForeColorChanged");
            events.Remove("RightToLeftChanged");
            events.Remove("SizeChanged");
            events.Remove("TextChanged");

            base.PostFilterEvents(events);
        }

        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitOSXBarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitOSXBarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitOSXBarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOSXBar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOSXBarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitOSXBarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOSXBar;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic size].
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        public bool AutoSize
        {
            get
            {
                return colUserControl.AutoSize;
            }
            set
            {
                GetPropertyByName("AutoSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        public int LargeChange
        {
            get
            {
                return colUserControl.LargeChange;
            }
            set
            {
                GetPropertyByName("LargeChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        public int SmallChange
        {
            get
            {
                return colUserControl.SmallChange;
            }
            set
            {
                GetPropertyByName("SmallChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the track line.
        /// </summary>
        /// <value>The height of the track line.</value>
        public int TrackLineHeight
        {
            get
            {
                return colUserControl.TrackLineHeight;
            }
            set
            {
                GetPropertyByName("TrackLineHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor
        {
            get
            {
                return colUserControl.TickColor;
            }
            set
            {
                GetPropertyByName("TickColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick frequency.
        /// </summary>
        /// <value>The tick frequency.</value>
        public int TickFrequency
        {
            get
            {
                return colUserControl.TickFrequency;
            }
            set
            {
                GetPropertyByName("TickFrequency").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the tick.
        /// </summary>
        /// <value>The height of the tick.</value>
        public int TickHeight
        {
            get
            {
                return colUserControl.TickHeight;
            }
            set
            {
                GetPropertyByName("TickHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the indent.
        /// </summary>
        /// <value>The height of the indent.</value>
        public int IndentHeight
        {
            get
            {
                return colUserControl.IndentHeight;
            }
            set
            {
                GetPropertyByName("IndentHeight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the indent.
        /// </summary>
        /// <value>The width of the indent.</value>
        public int IndentWidth
        {
            get
            {
                return colUserControl.IndentWidth;
            }
            set
            {
                GetPropertyByName("IndentWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the tracker.
        /// </summary>
        /// <value>The size of the tracker.</value>
        public Size TrackerSize
        {
            get
            {
                return colUserControl.TrackerSize;
            }
            set
            {
                GetPropertyByName("TrackerSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text tick style.
        /// </summary>
        /// <value>The text tick style.</value>
        public TickStyle TextTickStyle
        {
            get
            {
                return colUserControl.TextTickStyle;
            }
            set
            {
                GetPropertyByName("TextTickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick style.
        /// </summary>
        /// <value>The tick style.</value>
        public TickStyle TickStyle
        {
            get
            {
                return colUserControl.TickStyle;
            }
            set
            {
                GetPropertyByName("TickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tracker.
        /// </summary>
        /// <value>The color of the tracker.</value>
        public Color TrackerColor
        {
            get
            {
                return colUserControl.TrackerColor;
            }
            set
            {
                GetPropertyByName("TrackerColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        public MACBorderStyle BorderStyle
        {
            get
            {
                return colUserControl.BorderStyle;
            }
            set
            {
                GetPropertyByName("BorderStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the track line.
        /// </summary>
        /// <value>The color of the track line.</value>
        public Color TrackLineColor
        {
            get
            {
                return colUserControl.TrackLineColor;
            }
            set
            {
                GetPropertyByName("TrackLineColor").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the Fore color."));

            items.Add(new DesignerActionPropertyItem("AutoSize",
                                 "Auto Size", "Appearance",
                                 "Sets if the control should be auto sized."));

            items.Add(new DesignerActionPropertyItem("LargeChange",
                                 "Large Change", "Appearance",
                                 "Change in value."));

            items.Add(new DesignerActionPropertyItem("SmallChange",
                                 "Small Change", "Appearance",
                                 "Change in value."));

            items.Add(new DesignerActionPropertyItem("TrackLineHeight",
                                 "Track Line Height", "Appearance",
                                 "Sets the trackbar line height."));

            items.Add(new DesignerActionPropertyItem("TickColor",
                                 "Tick Color", "Appearance",
                                 "Sets the color of the ticks."));

            items.Add(new DesignerActionPropertyItem("TickFrequency",
                                 "Tick Frequency", "Appearance",
                                 "Sets the tick frequency."));

            items.Add(new DesignerActionPropertyItem("TickHeight",
                                 "Tick Height", "Appearance",
                                 "Sets the height of the ticks."));

            items.Add(new DesignerActionPropertyItem("IndentHeight",
                                 "Indent Height", "Appearance",
                                 "Sets the indent height."));

            items.Add(new DesignerActionPropertyItem("IndentWidth",
                                 "Indent Width", "Appearance",
                                 "Sets the indentation width."));

            items.Add(new DesignerActionPropertyItem("TrackerSize",
                                 "Tracker Size", "Appearance",
                                 "Sets the size of the trackbar."));

            items.Add(new DesignerActionPropertyItem("TextTickStyle",
                                 "Text Tick Style", "Appearance",
                                 "Sets the text tick style."));

            items.Add(new DesignerActionPropertyItem("TickStyle",
                                 "Tick Style", "Appearance",
                                 "Sets the tickstyle of the trackbar."));

            items.Add(new DesignerActionPropertyItem("TrackerColor",
                                 "Tracker Color", "Appearance",
                                 "Sets the trackbar color."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the control."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value of the control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the control."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                                 "Orientation", "Appearance",
                                 "Sets the line orientation."));

            items.Add(new DesignerActionPropertyItem("BorderStyle",
                                 "Border Style", "Appearance",
                                 "Sets the borderstyle of the control."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the bordercolor of the control."));

            items.Add(new DesignerActionPropertyItem("TrackLineColor",
                                 "Track Line Color", "Appearance",
                                 "Sets the trackline color."));


            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion
}
