// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterClock.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterClock
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterClock

    /// <summary>
    /// Class ZeroitBusyBarPainterClock.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterClock.bmp")]
    public class ZeroitBusyBarPainterClock : ZeroitBusyBarPainterBase
    {
        /// <summary>
        /// Enum representing Presets
        /// </summary>
        public enum Presets
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The watch
            /// </summary>
            Watch,
            /// <summary>
            /// The circle
            /// </summary>
            Circle,
        }

        /// <summary>
        /// Enum representing the Hand Types
        /// </summary>
        public enum HandTypes
        {
            /// <summary>
            /// The line
            /// </summary>
            Line,
            /// <summary>
            /// The pie
            /// </summary>
            Pie,
        }

        /// <summary>
        /// The default hour length begin
        /// </summary>
        private const int _DefaultHourLengthBegin = 0;
        /// <summary>
        /// The default hour length end
        /// </summary>
        private const int _DefaultHourLengthEnd = 50;
        /// <summary>
        /// The default hour width
        /// </summary>
        private const int _DefaultHourWidth = 3;

        /// <summary>
        /// The default minute length begin
        /// </summary>
        private const int _DefaultMinuteLengthBegin = 0;
        /// <summary>
        /// The default minute length end
        /// </summary>
        private const int _DefaultMinuteLengthEnd = 90;
        /// <summary>
        /// The default minute width
        /// </summary>
        private const int _DefaultMinuteWidth = 2;


        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;

        /// <summary>
        /// The marks color
        /// </summary>
        private Color _MarksColor = Color.Empty;
        /// <summary>
        /// The marks width
        /// </summary>
        private int _MarksWidth = 1;

        /// <summary>
        /// The hour color
        /// </summary>
        private Color _HourColor = Color.Empty;
        /// <summary>
        /// The hour type
        /// </summary>
        private HandTypes _HourType = HandTypes.Line;
        /// <summary>
        /// The hour length begin
        /// </summary>
        private int _HourLengthBegin = _DefaultHourLengthBegin;
        /// <summary>
        /// The hour length end
        /// </summary>
        private int _HourLengthEnd = _DefaultHourLengthEnd;
        /// <summary>
        /// The hour width
        /// </summary>
        private int _HourWidth = _DefaultHourWidth;

        /// <summary>
        /// The minute color
        /// </summary>
        private Color _MinuteColor = Color.Empty;
        /// <summary>
        /// The minute type
        /// </summary>
        private HandTypes _MinuteType = HandTypes.Line;
        /// <summary>
        /// The minute length begin
        /// </summary>
        private int _MinuteLengthBegin = _DefaultMinuteLengthBegin;
        /// <summary>
        /// The minute length end
        /// </summary>
        private int _MinuteLengthEnd = _DefaultMinuteLengthEnd;
        /// <summary>
        /// The minute width
        /// </summary>
        private int _MinuteWidth = _DefaultMinuteWidth;
        /// <summary>
        /// The speed ratio
        /// </summary>
        private int _SpeedRatio = 4;

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
        /// Gets or sets the color of the marks.
        /// </summary>
        /// <value>The color of the marks.</value>
        [Category("2.Marks")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the marks")]
        public Color MarksColor
        {
            get { return _MarksColor; }

            set
            {
                _MarksColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the marks.
        /// </summary>
        /// <value>The width of the marks.</value>
        [Category("2.Marks")]
        [DefaultValue(1)]
        [Description("The width of the marks lines")]
        public int MarksWidth
        {
            get { return _MarksWidth; }

            set
            {
                _MarksWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the hour.
        /// </summary>
        /// <value>The color of the hour.</value>
        [Category("3.Hour")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the hour hand")]
        public Color HourColor
        {
            get { return _HourColor; }

            set
            {
                _HourColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the hour.
        /// </summary>
        /// <value>The type of the hour.</value>
        [Category("3.Hour")]
        [DefaultValue(HandTypes.Line)]
        [Description("The type of the hour hand")]
        public HandTypes HourType
        {
            get { return _HourType; }

            set
            {
                _HourType = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hour length begin.
        /// </summary>
        /// <value>The hour length begin.</value>
        [Category("3.Hour")]
        [DefaultValue(_DefaultHourLengthBegin)]
        [Description("The begin length of the hour hand in percent of the radius")]
        public int HourLengthBegin
        {
            get { return _HourLengthBegin; }

            set
            {
                _HourLengthBegin = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hour length end.
        /// </summary>
        /// <value>The hour length end.</value>
        [Category("3.Hour")]
        [DefaultValue(_DefaultHourLengthEnd)]
        [Description("The end length of the hour hand in percent of the radius")]
        public int HourLengthEnd
        {
            get { return _HourLengthEnd; }

            set
            {
                _HourLengthEnd = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the hour.
        /// </summary>
        /// <value>The width of the hour.</value>
        [Category("3.Hour")]
        [DefaultValue(_DefaultHourWidth)]
        [Description("The width of the hour hand")]
        public int HourWidth
        {
            get { return _HourWidth; }

            set
            {
                _HourWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the minute.
        /// </summary>
        /// <value>The color of the minute.</value>
        [Category("4.Minute")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the minute hand")]
        public Color MinuteColor
        {
            get { return _MinuteColor; }

            set
            {
                _MinuteColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the minute.
        /// </summary>
        /// <value>The type of the minute.</value>
        [Category("4.Minute")]
        [DefaultValue(HandTypes.Line)]
        [Description("The type of the minute hand")]
        public HandTypes MinuteType
        {
            get { return _MinuteType; }

            set
            {
                _MinuteType = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minute length begin.
        /// </summary>
        /// <value>The minute length begin.</value>
        [Category("4.Minute")]
        [DefaultValue(_DefaultMinuteLengthBegin)]
        [Description("The begin length of the minute hand in percent of the radius")]
        public int MinuteLengthBegin
        {
            get { return _MinuteLengthBegin; }

            set
            {
                _MinuteLengthBegin = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minute length end.
        /// </summary>
        /// <value>The minute length end.</value>
        [Category("4.Minute")]
        [DefaultValue(_DefaultMinuteLengthEnd)]
        [Description("The end length of the minute hand in percent of the radius")]
        public int MinuteLengthEnd
        {
            get { return _MinuteLengthEnd; }

            set
            {
                _MinuteLengthEnd = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the minute.
        /// </summary>
        /// <value>The width of the minute.</value>
        [Category("4.Minute")]
        [DefaultValue(_DefaultMinuteWidth)]
        [Description("The width of the minute hand")]
        public int MinuteWidth
        {
            get { return _MinuteWidth; }

            set
            {
                _MinuteWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the speed ratio.
        /// </summary>
        /// <value>The speed ratio.</value>
        [Category("4.Minute")]
        [DefaultValue(4)]
        [Description("The speed ratio of the minute hand")]
        public int SpeedRatio
        {
            get { return _SpeedRatio; }

            set
            {
                _SpeedRatio = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterClock"/> class.
        /// </summary>
        public ZeroitBusyBarPainterClock() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterClock"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterClock(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterClock"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterClock(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterClock"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterClock(ZeroitBusyBarPainterClock o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterClock)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterClock)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterClock o)
        {
            _Preset = o._Preset;

            _MarksColor = o._MarksColor;
            _MarksWidth = o._MarksWidth;

            _HourColor = o._HourColor;
            _HourType = o._HourType;
            _HourLengthBegin = o._HourLengthBegin;
            _HourLengthEnd = o._HourLengthEnd;
            _HourWidth = o._HourWidth;

            _MinuteColor = o._MinuteColor;
            _MinuteType = o._MinuteType;
            _MinuteLengthBegin = o._MinuteLengthBegin;
            _MinuteLengthEnd = o._MinuteLengthEnd;
            _MinuteWidth = o._MinuteWidth;
            _SpeedRatio = o._SpeedRatio;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterClock(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            if (_MarksColor == Color.Empty) _MarksColor = Bar.ForeColor;
            if (_MinuteColor == Color.Empty) _MinuteColor = Bar.ForeColor;
            if (_HourColor == Color.Empty) _HourColor = Bar.ForeColor;
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

            _MarksColor = Color.Empty;
            _MarksWidth = 1;

            _HourColor = Color.Empty;
            _HourType = HandTypes.Line;
            _HourLengthBegin = _DefaultHourLengthBegin;
            _HourLengthEnd = _DefaultHourLengthEnd;
            _HourWidth = _DefaultHourWidth;

            _MinuteColor = Color.Empty;
            _MinuteType = HandTypes.Line;
            _MinuteLengthBegin = _DefaultMinuteLengthBegin;
            _MinuteLengthEnd = _DefaultMinuteLengthEnd;
            _MinuteWidth = _DefaultMinuteWidth;
            _SpeedRatio = 4;

            if (Bar != null)
            {
                _MarksColor = Bar.ForeColor;
                _HourColor = Bar.ForeColor;
                _MinuteColor = Bar.ForeColor;
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

                case Presets.Watch:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.CornerRadius = 70;
                        Bar.Maximum = 400;
                    }

                    _MarksColor = Color.Orange;
                    _MarksWidth = 10;

                    _HourType = HandTypes.Pie;
                    _HourLengthBegin = -20;
                    _HourLengthEnd = 50;
                    _HourColor = Color.Gold;
                    _HourWidth = 20;

                    _MinuteType = HandTypes.Pie;
                    _MinuteLengthBegin = -10;
                    _MinuteLengthEnd = 90;
                    _MinuteColor = Color.Orange;
                    _MinuteWidth = 10;

                    _SpeedRatio = 12;

                    break;

                case Presets.Circle:

                    SetDefaults(setBarDefaults);

                    if (Bar != null)
                    {
                        Bar.CornerRadius = 100;
                        Bar.Maximum = 400;
                        Bar.Reverse = true;
                    }

                    _MarksColor = Color.Blue;
                    _MarksWidth = 3;

                    _HourType = HandTypes.Pie;
                    _HourLengthBegin = -20;
                    _HourLengthEnd = 40;
                    _HourColor = Color.DarkBlue;
                    _HourWidth = 20;

                    _MinuteType = HandTypes.Pie;
                    _MinuteLengthBegin = 30;
                    _MinuteLengthEnd = 90;
                    _MinuteColor = Color.Red;
                    _MinuteWidth = 10;

                    _SpeedRatio = 12;

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

            float minRadius = Single.MaxValue;
            using (Pen penMarks = new Pen(_MarksColor, _MarksWidth))
                for (int marks = 0; marks < 360; marks += 30)
                {
                    //					float radius = CalcRadius( bounds, marks );
                    float radius = CalcRadius(g, r, marks);

                    if (_MarksWidth > 0)
                        DrawLine(g, bounds, penMarks, marks, radius * 0.9f, radius);

                    if (radius < minRadius) minRadius = radius;
                }

            if (1 == 1)
            {
                float hour = (ratio * 360) - 90;

                float begin = minRadius * _HourLengthBegin / 100;
                float end = minRadius * _HourLengthEnd / 100;

                switch (_HourType)
                {
                    case HandTypes.Line:
                        using (Pen penHour = new Pen(_HourColor, _HourWidth))
                            DrawLine(g, bounds, penHour, hour, begin, end);
                        break;

                    case HandTypes.Pie:
                        DrawPie(g, bounds, _HourColor, _HourWidth, hour, begin, end);
                        break;

                    default:
                        Debug.Assert(false);
                        break;
                }
            }

            if (1 == 1)
            {
                float minute = (_SpeedRatio * ratio * 360) - 90;

                float begin = minRadius * _MinuteLengthBegin / 100;
                float end = minRadius * _MinuteLengthEnd / 100;

                switch (_MinuteType)
                {
                    case HandTypes.Line:
                        using (Pen penMinute = new Pen(_MinuteColor, _MinuteWidth))
                            DrawLine(g, bounds, penMinute, minute, begin, end);
                        break;

                    case HandTypes.Pie:
                        DrawPie(g, bounds, _MinuteColor, _MinuteWidth, minute, begin, end);
                        break;

                    default:
                        Debug.Assert(false);
                        break;
                }
            }

        }

        /// <summary>
        /// Calculates the radius.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Single.</returns>
        private float CalcRadius(RectangleF r, float angle)
        {
            double radians = angle * System.Math.PI / 180;

            float a = (float)System.Math.Abs(System.Math.Cos(radians));
            float o = (float)System.Math.Abs(System.Math.Sin(radians));

            float r1 = (a > 0) ? (r.Width / 2) / a : Single.MaxValue;
            float r2 = (o > 0) ? (r.Height / 2) / o : Single.MaxValue;

            return System.Math.Min(r1, r2);
        }

        /// <summary>
        /// Calculates the radius.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="region">The region.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>System.Single.</returns>
        private float CalcRadius(Graphics g, Region region, float angle)
        {
            RectangleF bounds = region.GetBounds(g);
            float maxRadius = (float)System.Math.Sqrt(System.Math.Pow(bounds.Width / 2, 2) + System.Math.Pow(bounds.Height / 2, 2));
            PointF centre = new PointF((bounds.Left + bounds.Right) / 2, (bounds.Top + bounds.Bottom) / 2);

            PointF point = centre;
            for (float radius = 0; radius < maxRadius; radius += 1)
            {
                PointF p = CalcPointF(bounds, angle, radius);
                if (!region.IsVisible(p, g)) break;
                point = p;
            }

            float result = (float)System.Math.Sqrt(System.Math.Pow(point.X - centre.X, 2) + System.Math.Pow(point.Y - centre.Y, 2));

            return result;
        }

        /// <summary>
        /// Calculates the point f.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>PointF.</returns>
        private PointF CalcPointF(RectangleF r, float angle, float radius)
        {
            double radians = angle * System.Math.PI / 180;

            float xOffset = (float)(radius * System.Math.Cos(radians));
            float yOffset = (float)(radius * System.Math.Sin(radians));

            float xMiddle = (r.Left + r.Right) / 2;
            float yMiddle = (r.Top + r.Bottom) / 2;

            return new PointF(xMiddle + xOffset, yMiddle + yOffset);
        }

        /// <summary>
        /// Draws the line.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private void DrawLine(Graphics g, RectangleF r, Pen pen, float angle, float start, float end)
        {
            PointF s = CalcPointF(r, angle, start);
            PointF e = CalcPointF(r, angle, end);

            g.DrawLine(pen, s, e);
        }

        /// <summary>
        /// Draws the pie.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="r">The r.</param>
        /// <param name="color">The color.</param>
        /// <param name="sweep">The sweep.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private void DrawPie(Graphics g, RectangleF r, Color color, int sweep, float angle, float start, float end)
        {
            PointF pCentre = CalcPointF(r, angle, end);

            float radius = end - start;
            float diameter = 2 * radius;

            if (radius <= 0) return;

            RectangleF e = new RectangleF(pCentre.X - radius, pCentre.Y - radius, diameter, diameter);

            float startAngle = angle - (sweep / 2) - 180;

            using (Brush brush = new SolidBrush(color))
                g.FillPie(brush, e.X, e.Y, e.Width, e.Height, startAngle, sweep);
        }

    }
    #endregion

}
