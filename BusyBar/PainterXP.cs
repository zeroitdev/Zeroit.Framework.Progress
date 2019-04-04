// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterXP.cs" company="Zeroit Dev Technologies">
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

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterXP
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterXP

    /// <summary>
    /// Class ZeroitBusyBarPainterXP.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBlockBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterXP.bmp")]
    public class ZeroitBusyBarPainterXP : ZeroitBusyBarPainterBlockBase
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
            /// The system
            /// </summary>
            System,
            /// <summary>
            /// The startup
            /// </summary>
            Startup,
        }

        /// <summary>
        /// The default color dark
        /// </summary>
        private static readonly Color _DefaultColorDark = Color.FromArgb(131, 174, 119);
        /// <summary>
        /// The default color light
        /// </summary>
        private static readonly Color _DefaultColorLight = Color.FromArgb(195, 227, 186);

        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;

        /// <summary>
        /// The color dark
        /// </summary>
        private Color _ColorDark = _DefaultColorDark;
        /// <summary>
        /// The color light
        /// </summary>
        private Color _ColorLight = _DefaultColorLight;

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
        /// Gets or sets the color dark.
        /// </summary>
        /// <value>The color dark.</value>
        [Category("2.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the bar")]
        public Color ColorDark
        {
            get { return _ColorDark; }

            set
            {
                _ColorDark = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color light.
        /// </summary>
        /// <value>The color light.</value>
        [Category("2.Colors")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the bar")]
        public Color ColorLight
        {
            get { return _ColorLight; }

            set
            {
                _ColorLight = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterXP"/> class.
        /// </summary>
        public ZeroitBusyBarPainterXP() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterXP"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterXP(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterXP"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterXP(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterXP"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterXP(ZeroitBusyBarPainterXP o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterXP)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterXP)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterXP o)
        {
            _Preset = o._Preset;

            _ColorDark = o._ColorDark;
            _ColorLight = o._ColorLight;

            //			_Wrap            = o._Wrap            ;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterXP(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            if (_ColorDark == Color.Empty) _ColorDark = _DefaultColorDark;
            if (_ColorLight == Color.Empty) _ColorLight = _DefaultColorLight;
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

            _ColorDark = _DefaultColorDark;
            _ColorLight = _DefaultColorLight;
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

                case Presets.System:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.Pin = ZeroitBusyBar.Pins.Start;
                    }

                    BlockScroll = false;

                    break;

                case Presets.Startup:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.BackColor = Color.Black;
                    }

                    ColorDark = Color.MediumBlue;

                    BlockPercent = 33;
                    BlockLineColor = Color.Black;

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
            //			g.ResetClip();

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
                float xLeft = xValue - (b / 2f);

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

                if (r1.Right < bounds.Left && r3.Left > bounds.Right) _Wrap = Bar.Wrap;

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

                if (r2.Width <= 0 || r2.Height <= 0) return;

                //				g.DrawRectangle( pen, r2.X, r2.Y, r2.Width, r2.Height );

                Blend blend = new Blend(5);
                blend.Positions = new float[] { 0f, 0.2f, 0.3f, 0.8f, 1f };
                blend.Factors = new float[] { 0f, 1f, 0f, 0f, 0.8f };

                ColorBlend colourBlend = new ColorBlend(5);
                colourBlend.Colors = new Color[] { _ColorDark, _ColorLight, _ColorDark, _ColorDark, _ColorLight };
                colourBlend.Positions = new float[] { 0f, 0.2f, 0.3f, 0.8f, 1f };

                using (LinearGradientBrush brush = new LinearGradientBrush(
                            //							r2, Color.Empty, Color.Empty, LinearGradientMode.Vertical ) ) 
                            //							bounds, _ColorDark, _ColorLight, LinearGradientMode.Vertical ) ) 
                            r2, _ColorDark, _ColorLight, LinearGradientMode.Vertical))
                {
                    brush.Blend = blend;
                    //					brush.InterpolationColors = colourBlend;
                    brush.GammaCorrection = true;
                    //					brush.WrapMode = WrapMode.Tile;

                    bool bOther = _Wrap && (Bar.Pin == ZeroitBusyBar.Pins.None);

                    if (bOther) g.FillRectangle(brush, r1);
                    if (1 == 1) g.FillRectangle(brush, r2);
                    //					if ( 1 == 1 ) g.FillRectangle( Brushes.Red, r2 );
                    if (bOther) g.FillRectangle(brush, r3);
                }

                if (BlockLineWidth > 0)
                    using (Pen pen2 = new Pen(BlockLineColor, BlockLineWidth))
                    {
                        foreach (float xLine in lines)
                            g.DrawLine(pen2, xLine, bounds.Top, xLine, bounds.Bottom);
                    }

                //				g.DrawLine( Pens.Red, blocks.R1Left, bounds.Top, blocks.R1Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R1Right, bounds.Top, blocks.R1Right, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R2Left, bounds.Top, blocks.R2Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R2Right, bounds.Top, blocks.R2Right, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R3Left, bounds.Top, blocks.R3Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R3Right, bounds.Top, blocks.R3Right, bounds.Bottom );
            }
            // Vertical
            else
            {
                float yOffset = bounds.Height * ratio;

                if (!BlockSmooth && Bar.Pin != ZeroitBusyBar.Pins.None)
                {
                    int yPeriod = BlockWidth + BlockLineWidth;
                    int yIntPeriods = (int)System.Math.Floor(bounds.Height / yPeriod);

                    float yWholeHeight = (1 + yIntPeriods) * yPeriod;
                    float yFudge = yWholeHeight / bounds.Height;

                    yOffset *= yFudge;
                    //					yOffset += yPeriod;
                }

                float yValue = bounds.Top + yOffset;

                float b = bounds.Height * BlockPercent / 100f;
                float yTop = yValue - (b / 2f);

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
                                bounds.Top,
                                yValue,
                                bounds.Width,
                                bounds.Height - yOffset);

                            break;
                        }

                    default:
                        Debug.Assert(false);
                        return;
                }

                if (r1.Bottom < bounds.Top && r3.Top > bounds.Bottom) _Wrap = Bar.Wrap;

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

                if (r2.Width <= 0 || r2.Height <= 0) return;

                //				g.DrawRectangle( pen, r2.X, r2.Y, r2.Width, r2.Height );

                Blend blend = new Blend(5);
                blend.Positions = new float[] { 0f, 0.2f, 0.3f, 0.8f, 1f };
                blend.Factors = new float[] { 0f, 1f, 0f, 0f, 0.8f };

                ColorBlend colourBlend = new ColorBlend(5);
                colourBlend.Colors = new Color[] { _ColorDark, _ColorLight, _ColorDark, _ColorDark, _ColorLight };
                colourBlend.Positions = new float[] { 0f, 0.2f, 0.3f, 0.8f, 1f };

                using (LinearGradientBrush brush = new LinearGradientBrush(
                            //							r2, Color.Empty, Color.Empty, LinearGradientMode.Vertical ) ) 
                            //							bounds, _ColorDark, _ColorLight, LinearGradientMode.Vertical ) ) 
                            r2, _ColorDark, _ColorLight, LinearGradientMode.Horizontal))
                {
                    brush.Blend = blend;
                    //					brush.InterpolationColors = colourBlend;
                    brush.GammaCorrection = true;
                    //					brush.WrapMode = WrapMode.Tile;

                    bool bOther = _Wrap && (Bar.Pin == ZeroitBusyBar.Pins.None);

                    if (bOther) g.FillRectangle(brush, r1);
                    if (1 == 1) g.FillRectangle(brush, r2);
                    //					if ( 1 == 1 ) g.FillRectangle( Brushes.Red, r2 );
                    if (bOther) g.FillRectangle(brush, r3);
                }

                if (BlockLineWidth > 0)
                    using (Pen pen2 = new Pen(BlockLineColor, BlockLineWidth))
                    {
                        foreach (float yLine in lines)
                            g.DrawLine(pen2, bounds.Left, yLine, bounds.Right, yLine);
                    }

                //				g.DrawLine( Pens.Red, blocks.R1Left, bounds.Top, blocks.R1Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R1Right, bounds.Top, blocks.R1Right, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R2Left, bounds.Top, blocks.R2Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R2Right, bounds.Top, blocks.R2Right, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R3Left, bounds.Top, blocks.R3Left, bounds.Bottom );
                //				g.DrawLine( Pens.Red, blocks.R3Right, bounds.Top, blocks.R3Right, bounds.Bottom );
            }
        }
    }
    #endregion

}
