// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterFrustratorBar.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarPainterFrustratoBar
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterFrustratoBar

    //	[ DesignTimeVisible( false ) ]
    /// <summary>
    /// Class ZeroitBusyBarPainterFrustratoBar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterXP" />
    [DesignerCategory("Component")]
    [Designer(typeof(ZeroitBusyBarPainterFrustratoBar.ZeroitBusyBarPainterFrustratoBarDesigner), typeof(ComponentDesigner))]
    [TypeConverter(typeof(ZeroitBusyBarPainterFrustratoBar.ZeroitBusyBarPainterFrustratoBarTypeConverter))]
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBarPainterFrustratoBar.bmp")]
    public class ZeroitBusyBarPainterFrustratoBar : ZeroitBusyBarPainterXP
    {
        /// <summary>
        /// Class ZeroitBusyBarPainterFrustratoBarTypeConverter.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter" />
        public class ZeroitBusyBarPainterFrustratoBarTypeConverter : TypeConverter
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBarTypeConverter"/> class.
            /// </summary>
            public ZeroitBusyBarPainterFrustratoBarTypeConverter()
            {
                //				MessageBox.Show( "ZeroitBusyBarPainterFrustratoBarTypeConverter()" );
            }

            /// <summary>
            /// Returns whether this object supports properties, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <returns>true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.</returns>
            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                //				MessageBox.Show( "ZeroitBusyBarPainterFrustratoBarTypeConverter.GetPropertiesSupported()" );

                if (context.Instance is ZeroitBusyBarPainterFrustratoBar) return true;

                return base.GetPropertiesSupported(context);
            }

            /// <summary>
            /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
            /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
            /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.</returns>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                //				MessageBox.Show( "ZeroitBusyBarPainterFrustratoBarTypeConverter.GetProperties()" );
                //				MessageBox.Show( value.GetType().ToString() );

                PropertyDescriptorCollection pds = base.GetProperties(context, value, attributes);
                Debug.Assert(pds == null);

                if (!(value is ZeroitBusyBarPainterFrustratoBar)) return null;

                PropertyDescriptorCollection pdsAll = TypeDescriptor.GetProperties(value);

                PropertyDescriptor[] properties = new PropertyDescriptor[1];
                properties[0] = pdsAll.Find("ResetPercent", false);

                PropertyDescriptorCollection pdsFiltered = new PropertyDescriptorCollection(properties);

                return pdsFiltered;
            }

        }

        /// <summary>
        /// Class ZeroitBusyBarPainterFrustratoBarDesigner.
        /// </summary>
        /// <seealso cref="System.ComponentModel.Design.ComponentDesigner" />
        public class ZeroitBusyBarPainterFrustratoBarDesigner : ComponentDesigner
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBarDesigner"/> class.
            /// </summary>
            public ZeroitBusyBarPainterFrustratoBarDesigner()
            {
                MessageBox.Show("ZeroitBusyBarPainterFrustratoBarDesigner()");
            }

            /// <summary>
            /// Prepares the designer to view, edit, and design the specified component.
            /// </summary>
            /// <param name="component">The component for this designer.</param>
            public override void Initialize(IComponent component)
            {
                MessageBox.Show("Initialize");

                base.Initialize(component);
            }

            /// <summary>
            /// Allows a designer to add to the set of properties that it exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
            /// </summary>
            /// <param name="properties">The properties for the class of the component.</param>
            protected override void PreFilterProperties(IDictionary properties)
            {
                MessageBox.Show("properties include preset: " + (properties.Contains("Preset") ? "True" : "False"));

                base.PreFilterProperties(properties);

                properties.Remove("Preset");
            }

            /// <summary>
            /// Allows a designer to change or remove items from the set of properties that it exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
            /// </summary>
            /// <param name="properties">The properties for the class of the component.</param>
            protected override void PostFilterProperties(IDictionary properties)
            {
                MessageBox.Show("properties include preset: " + (properties.Contains("Preset") ? "True" : "False"));

                base.PostFilterProperties(properties);
            }
        }

        /// <summary>
        /// The default bar maximum
        /// </summary>
        private const int _DefaultBarMaximum = 1000;

        /// <summary>
        /// The default reset percent
        /// </summary>
        private const int _DefaultResetPercent = 90;

        /// <summary>
        /// The reset percent
        /// </summary>
        private int _ResetPercent = _DefaultResetPercent;

        /// <summary>
        /// Gets or sets the reset percent.
        /// </summary>
        /// <value>The reset percent.</value>
        [Category("1.Frustration Level")]
        [DefaultValue(_DefaultResetPercent)]
        [Description("Percent of bar at which to reset")]
        public int ResetPercent
        {
            get { return _ResetPercent; }

            set
            {
                _ResetPercent = value;

                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBar"/> class.
        /// </summary>
        public ZeroitBusyBarPainterFrustratoBar() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBar"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        public ZeroitBusyBarPainterFrustratoBar(ZeroitBusyBar bar) : base(bar)
        {
            //			OnBarSet();

            // Presets.None
            SetFromPreset(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBar"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        public ZeroitBusyBarPainterFrustratoBar(ZeroitBusyBar bar, bool setBarDefaults) : base(bar, setBarDefaults)
        {
            //			OnBarSet();

            // Presets.None
            SetFromPreset(setBarDefaults);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterFrustratoBar"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterFrustratoBar(ZeroitBusyBarPainterFrustratoBar o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterFrustratoBar)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterFrustratoBar)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterFrustratoBar o)
        {
            _ResetPercent = o._ResetPercent;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        public override IPainter CreateCopy()
        {
            return new ZeroitBusyBarPainterFrustratoBar(this);
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            //			if ( _ColorDark  == Color.Empty ) _ColorDark  = _DefaultColorDark  ;
            //			if ( _ColorLight == Color.Empty ) _ColorLight = _DefaultColorLight ;

            Bar.Maximum = _DefaultBarMaximum;
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

            //			_ColorDark  = _DefaultColorDark  ;
            //			_ColorLight = _DefaultColorLight ;
        }

        /// <summary>
        /// Sets from preset.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        private void SetFromPreset(bool setBarDefaults)
        {
            base.Preset = ZeroitBusyBarPainterXP.Presets.System;

            Bar.Maximum = _DefaultBarMaximum;
        }

        /// <summary>
        /// Calculates the ratio.
        /// </summary>
        /// <returns>System.Single.</returns>
        protected override float CalculateRatio()
        {
            float ratio = base.CalculateRatio();

            int percent = (int)(ratio * 100); // between 0 and 100

            if (percent == 0) return 0f;

            float log = (float)System.Math.Log10(percent); // between 0 and 2

            float ratio2 = (log / 2f);

            if (ratio2 > (_ResetPercent / 100f))
            {
                Bar.Value = Bar.Minimum;
                return 0f;
            }

            return ratio2;
        }

    }

    //----------------------------------------------------------------------------- 
    #endregion

}
