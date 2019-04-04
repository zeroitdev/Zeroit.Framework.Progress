// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterLine.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Serialization;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterLine
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterLine

    //	[ ToolboxItem( typeof( ZeroitBusyBarPainterLine.ZeroitBusyBarPainterLineToolboxItem ) ) ]
    //	[ Designer( typeof( ZeroitBusyBarPainterLine.ZeroitBusyBarPainterLineDesigner ), typeof( IDesigner ) ) ]
    //	[ TypeConverter( typeof( ZeroitBusyBarPainterLine.ZeroitBusyBarPainterLineTypeConverter ) ) ]
    /// <summary>
    /// Class ZeroitBusyBarPainterLine.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBase" />
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterLine.bmp")]
    //	[ ToolboxBitmap( typeof( ResFinder ), "Bitmaps.ZeroitBusyBarPainterLine.bmp" ) ]
    //	[ ToolboxBitmap( typeof( ResFinder ), "ZeroitBusyBarPainterLine.bmp" ) ]
    public class ZeroitBusyBarPainterLine : ZeroitBusyBarPainterBase
    {
        /// <summary>
        /// Class ZeroitBusyBarPainterLineTypeConverter.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter" />
        public class ZeroitBusyBarPainterLineTypeConverter : TypeConverter
        {
            /// <summary>
            /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
            /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                bool b = base.CanConvertFrom(context, sourceType);
                MessageBox.Show("ZeroitBusyBarPainterLine.CanConvertFrom " + sourceType.FullName + "\nfrom: " + context.Instance + "\nis " + b);
                return b;
            }

            /// <summary>
            /// Returns whether this converter can convert the object to the specified type, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
            /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                bool b = base.CanConvertTo(context, destinationType);
                MessageBox.Show("ZeroitBusyBarPainterLine.CanConvertTo " + destinationType.FullName + " is " + b);
                if (destinationType == typeof(InstanceDescriptor)) return true;
                return b;
            }

            /// <summary>
            /// Converts the given value object to the specified type, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
            /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
            /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
            /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (1 == 1)
                {
                    string s = String.Empty;
                    s += "ZeroitBusyBarPainterLine.ConvertTo " + destinationType.FullName;
                    s += "\nfrom " + value.GetType().FullName;

                    if (context == null) s += "\ncontext is null";
                    else
                        if (context.Instance == null) s += "\nInstance is null";
                    else
                        s += "\nInstance: " + context.Instance.GetType().FullName;

                    MessageBox.Show(s);
                }

                if (destinationType == typeof(InstanceDescriptor))
                    if (value is ZeroitBusyBarPainterLine)
                    {
                        ZeroitBusyBarPainterLine o = (ZeroitBusyBarPainterLine)value;

                        ConstructorInfo ctor = typeof(ZeroitBusyBarPainterLine).GetConstructor(
                            Type.EmptyTypes);

                        if (ctor != null)
                        {
                            MessageBox.Show("ZeroitBusyBarPainterLine.ConvertTo success!");
                            return new InstanceDescriptor(
                                ctor,
                                null,
                                true);
                        }

                        //						ConstructorInfo ctor = typeof( ZeroitBusyBarPainterLine ).GetConstructor(
                        //							BindingFlags.Public | BindingFlags.Instance,
                        //							null,
                        //							new Type[]
                        //							{
                        //								typeof( Color ),
                        //								typeof( int ),
                        //							},
                        //							null );
                        //
                        //						if ( ctor != null )
                        //						{
                        //							MessageBox.Show( "ZeroitBusyBarPainterLine.ConvertTo success!" );
                        //							return new InstanceDescriptor(
                        //								ctor,
                        //								new object[]
                        //								{
                        //									o.LineColor,
                        //									o.LineWidth,
                        //								},
                        //								true );
                        //						}
                    }

                return base.ConvertTo(context, culture, value, destinationType);
            }

        }

        /// <summary>
        /// Class ZeroitBusyBarPainterLineToolboxItem.
        /// </summary>
        /// <seealso cref="System.Drawing.Design.ToolboxItem" />
        [Serializable]
        public class ZeroitBusyBarPainterLineToolboxItem : ToolboxItem
        //, ISerializable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLineToolboxItem"/> class.
            /// </summary>
            public ZeroitBusyBarPainterLineToolboxItem()
            {
                DisplayName = "Fubar";
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLineToolboxItem"/> class.
            /// </summary>
            /// <param name="info">The information.</param>
            /// <param name="context">The context.</param>
            public ZeroitBusyBarPainterLineToolboxItem(SerializationInfo info, StreamingContext context)
            {
                base.Deserialize(info, context);
                DisplayName = "Fubar";
            }

            /// <summary>
            /// Loads the state of the toolbox item from the specified serialization information object.
            /// </summary>
            /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to load from.</param>
            /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> that indicates the stream characteristics.</param>
            protected override void Deserialize(SerializationInfo info, StreamingContext context)
            {
                base.Deserialize(info, context);
                DisplayName = "Fubar";
            }

            /// <summary>
            /// Saves the state of the toolbox item to the specified serialization information object.
            /// </summary>
            /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to save to.</param>
            /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> that indicates the stream characteristics.</param>
            protected override void Serialize(SerializationInfo info, StreamingContext context)
            {
                base.Serialize(info, context);
            }

            //			public void GetObjectData(SerializationInfo info, StreamingContext context)
            //			{
            //			}
        }

        /// <summary>
        /// Class ZeroitBusyBarPainterLineDesigner.
        /// </summary>
        /// <seealso cref="System.ComponentModel.Design.ComponentDesigner" />
        public class ZeroitBusyBarPainterLineDesigner : ComponentDesigner
        {
        }

        /// <summary>
        /// Enum representing Presets for <c><see cref="ZeroitBusyBar" /></c>
        /// </summary>
        public enum Presets
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The bar
            /// </summary>
            Bar,
        }

        /// <summary>
        /// The preset
        /// </summary>
        private Presets _Preset = Presets.None;

        /// <summary>
        /// The line color
        /// </summary>
        private Color _LineColor = Color.Empty;
        /// <summary>
        /// The line width
        /// </summary>
        private int _LineWidth = 1;

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
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("2.Line")]
        //		[ DefaultValue( Color.Empty ) ]
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
        [DefaultValue(1)]
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
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLine"/> class.
        /// </summary>
        public ZeroitBusyBarPainterLine() { }

        //		public ZeroitBusyBarPainterLine(
        //			Color lineColor,
        //			int lineWidth )
        //		{
        //			_LineColor = lineColor;
        //			_LineWidth = lineWidth;
        //		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLine"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterLine(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLine"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterLine(ZeroitBusyBar bar, bool setBarDefaults) : base(bar)
        {
            OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterLine"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterLine(ZeroitBusyBarPainterLine o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterLine)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterLine)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterLine o)
        {
            _Preset = o._Preset;

            _LineColor = o._LineColor;
            _LineWidth = o._LineWidth;

            //			_Wrap      = o._Wrap      ;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterLine(this);
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

            _Wrap = Bar.WrapInitial;
        }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        protected override void SetDefaults(bool setBarDefaults)
        {
            base.SetDefaults(setBarDefaults);

            _LineColor = Color.Empty;
            _LineWidth = 1;

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

                case Presets.Bar:

                    SetDefaults(setBarDefaults);

                    _LineWidth = 50;

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

            if (Bar.DrawBar)
            {
                RectangleF bounds = r.GetBounds(g);
                float ratio = CalculateRatio();

                if (!Bar.Vertical)
                {
                    float x2 = bounds.Left + (bounds.Width * ratio);
                    float x1 = x2 - bounds.Width;
                    float x3 = x2 + bounds.Width;

                    if (
                        x1 + (_LineWidth / 2) < bounds.Left &&
                        x3 - (_LineWidth / 2) > bounds.Right)
                        _Wrap = Bar.Wrap;

                    using (Pen pen = new Pen(_LineColor, _LineWidth))
                    {
                        if (_Wrap) g.DrawLine(pen, x1, bounds.Top, x1, bounds.Bottom);
                        g.DrawLine(pen, x2, bounds.Top, x2, bounds.Bottom);
                        if (_Wrap) g.DrawLine(pen, x3, bounds.Top, x3, bounds.Bottom);
                    }
                }
                // Vertical
                else
                {
                    float y2 = bounds.Top + (bounds.Height * ratio);
                    float y1 = y2 - bounds.Height;
                    float y3 = y2 + bounds.Height;

                    if (
                        y1 + (_LineWidth / 2) < bounds.Top &&
                        y3 - (_LineWidth / 2) > bounds.Bottom)
                        _Wrap = Bar.Wrap;

                    using (Pen pen = new Pen(_LineColor, _LineWidth))
                    {
                        if (_Wrap) g.DrawLine(pen, bounds.Left, y1, bounds.Right, y1);
                        g.DrawLine(pen, bounds.Left, y2, bounds.Right, y2);
                        if (_Wrap) g.DrawLine(pen, bounds.Left, y3, bounds.Right, y3);
                    }
                }
            }
        }
    }
    #endregion

}
