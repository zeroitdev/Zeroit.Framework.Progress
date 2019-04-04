// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterBase.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitBusyPainterBase
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterBase

    //	[ Designer( typeof( ZeroitBusyBarPainterBase.ZeroitBusyBarPainterBaseDesigner ), typeof( IDesigner ) ) ]
    //	[ TypeConverter( typeof( ZeroitBusyBarPainterBase.ZeroitBusyBarPainterBaseTypeConverter ) ) ]
    /// <summary>
    /// Class ZeroitBusyBarPainterBase.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.Progress.IPainter" />
    public abstract class ZeroitBusyBarPainterBase : Component, IPainter
    //	public class ZeroitBusyBarPainterBase : Component, IPainter
    {
        /// <summary>
        /// Class ZeroitBusyBarPainterBaseDesigner.
        /// </summary>
        /// <seealso cref="System.ComponentModel.Design.ComponentDesigner" />
        public class ZeroitBusyBarPainterBaseDesigner : ComponentDesigner
        {
        }

        /// <summary>
        /// Class ZeroitBusyBarPainterBaseTypeConverter.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter" />
        public class ZeroitBusyBarPainterBaseTypeConverter : TypeConverter
        {
            /// <summary>
            /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
            /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                MessageBox.Show("ZeroitBusyBarPainterBase.CanConvertFrom " + sourceType.FullName);
                return base.CanConvertFrom(context, sourceType);
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
                MessageBox.Show("ZeroitBusyBarPainterBase.CanConvertTo " + destinationType.FullName + " is " + b);
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
                MessageBox.Show("ZeroitBusyBarPainterBase.ConvertTo " + destinationType.FullName + "\nfrom " + value.GetType().FullName);
                //				if ( destinationType == typeof( InstanceDescriptor ) );
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }

        /// <summary>
        /// The bar
        /// </summary>
        private ZeroitBusyBar _Bar = null;

        /// <summary>
        /// Gets the bar.
        /// </summary>
        /// <value>The bar.</value>
        protected ZeroitBusyBar Bar { get { return _Bar; } }

        /// <summary>
        /// Gets or sets the zeroit busy bar.
        /// </summary>
        /// <value>The zeroit busy bar.</value>
        [Browsable(false)]
        [Category("0.ZeroitBusyBar")]
        [DefaultValue(null)]
        [Description("The ZeroitBusyBar that is using this painter")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZeroitBusyBar ZeroitBusyBar
        {
            get { return _Bar; }

            set
            {
                //				if ( value == null ) throw new ArgumentException( "Value must not be null" );

                _Bar = value;

                if (_Bar != null) OnBarSet();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBase"/> class.
        /// </summary>
        protected ZeroitBusyBarPainterBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBase"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        protected ZeroitBusyBarPainterBase(ZeroitBusyBar bar)
        {
            _Bar = bar;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBase"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterBase(ZeroitBusyBarPainterBase o)
        {
            CopyThis(o);
        }

        /// <summary>
        /// Copies the specified o.
        /// </summary>
        /// <param name="o">The o.</param>
        public virtual void Copy(ZeroitBusyBarPainterBase o)
        {
            CopyThis(o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterBase o)
        {
            _Bar = o._Bar;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public abstract IPainter CreateCopy();
        //		public virtual IPainter CreateCopy() { Debug.Assert( false ); return null; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public virtual object Clone()
        {
            return CreateCopy();
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected virtual void OnBarSet()
        {
            Reset();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public virtual void Reset() { }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        protected virtual void SetDefaults(bool setBarDefaults)
        {
            if (Bar != null && setBarDefaults) Bar.SetDefaults();
        }

        /// <summary>
        /// Calculates the ratio.
        /// </summary>
        /// <returns>System.Single.</returns>
        protected virtual float CalculateRatio()
        {
            return ((float)Bar.Value - Bar.Minimum) / (Bar.Maximum - Bar.Minimum);
        }

        /// <summary>
        /// Paints the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="r">The r.</param>
        public virtual void Paint(Graphics g, Region r)
        {
            //			g.FillRegion( Brushes.Silver, r );
        }
    }
    #endregion
}
