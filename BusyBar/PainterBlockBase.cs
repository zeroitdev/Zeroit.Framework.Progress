// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="PainterBlockBase.cs" company="Zeroit Dev Technologies">
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

    #region ZeroitBusyBarPainterBlockBase
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarPainterBlockBase

    /// <summary>
    /// Class ZeroitBusyBarPainterBlockBase.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitBusyBarPainterBase" />
    public abstract class ZeroitBusyBarPainterBlockBase : ZeroitBusyBarPainterBase
    {
        /// <summary>
        /// The default block percent
        /// </summary>
        private const float _DefaultBlockPercent = 50;
        /// <summary>
        /// The default block width
        /// </summary>
        private const int _DefaultBlockWidth = 6;
        /// <summary>
        /// The default block smooth
        /// </summary>
        private const bool _DefaultBlockSmooth = false;
        /// <summary>
        /// The default block scroll
        /// </summary>
        private const bool _DefaultBlockScroll = true;
        /// <summary>
        /// The default block line color
        /// </summary>
        private static readonly Color _DefaultBlockLineColor = Color.Empty;
        /// <summary>
        /// The default block line width
        /// </summary>
        private const int _DefaultBlockLineWidth = 2;

        /// <summary>
        /// The block percent
        /// </summary>
        private float _BlockPercent = _DefaultBlockPercent;
        /// <summary>
        /// The block width
        /// </summary>
        private int _BlockWidth = _DefaultBlockWidth;
        /// <summary>
        /// The block smooth
        /// </summary>
        private bool _BlockSmooth = _DefaultBlockSmooth;
        /// <summary>
        /// The block scroll
        /// </summary>
        private bool _BlockScroll = _DefaultBlockScroll;
        /// <summary>
        /// The block line color
        /// </summary>
        private Color _BlockLineColor = _DefaultBlockLineColor;
        /// <summary>
        /// The block line width
        /// </summary>
        private int _BlockLineWidth = _DefaultBlockLineWidth;

        /// <summary>
        /// Gets or sets the block percent.
        /// </summary>
        /// <value>The block percent.</value>
        /// <exception cref="ArgumentException">Value must be between 0 and 100</exception>
        [Category("Blocks")]
        [DefaultValue(_DefaultBlockPercent)]
        [Description("The percentage of the control filled with blocks")]
        public float BlockPercent
        {
            get { return _BlockPercent; }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(
                        "Value must be between 0 and 100");

                _BlockPercent = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the block.
        /// </summary>
        /// <value>The width of the block.</value>
        [Category("Blocks")]
        [DefaultValue(_DefaultBlockWidth)]
        [Description("The width of each block")]
        public int BlockWidth
        {
            get { return _BlockWidth; }

            set
            {
                _BlockWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [block smooth].
        /// </summary>
        /// <value><c>true</c> if [block smooth]; otherwise, <c>false</c>.</value>
        [Category("Blocks")]
        [DefaultValue(_DefaultBlockSmooth)]
        [Description("Whether partial blocks are drawn")]
        public bool BlockSmooth
        {
            get { return _BlockSmooth; }

            set
            {
                _BlockSmooth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [block scroll].
        /// </summary>
        /// <value><c>true</c> if [block scroll]; otherwise, <c>false</c>.</value>
        [Category("Blocks")]
        [DefaultValue(_DefaultBlockScroll)]
        [Description("Whether the blocks move")]
        public bool BlockScroll
        {
            get { return _BlockScroll; }

            set
            {
                _BlockScroll = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the block line.
        /// </summary>
        /// <value>The color of the block line.</value>
        [Category("Blocks")]
        //		[ DefaultValue( Color.Empty ) ]
        [Description("The Color used to draw the lines separating the blocks")]
        public Color BlockLineColor
        {
            get { return _BlockLineColor; }

            set
            {
                _BlockLineColor = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the block line.
        /// </summary>
        /// <value>The width of the block line.</value>
        [Category("Blocks")]
        [DefaultValue(_DefaultBlockLineWidth)]
        [Description("The width of the lines separating the blocks")]
        public int BlockLineWidth
        {
            get { return _BlockLineWidth; }

            set
            {
                _BlockLineWidth = value;
                if (Bar != null) Bar.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBlockBase"/> class.
        /// </summary>
        protected ZeroitBusyBarPainterBlockBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBlockBase"/> class.
        /// </summary>
        /// <param name="bar">The bar.</param>
        protected ZeroitBusyBarPainterBlockBase(ZeroitBusyBar bar) : base(bar)
        {
            OnBarSet();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBarPainterBlockBase"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBarPainterBlockBase(ZeroitBusyBarPainterBlockBase o) : base(o)
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

            if (!(o is ZeroitBusyBarPainterBlockBase)) Debug.Assert(false);
            else
                CopyThis((ZeroitBusyBarPainterBlockBase)o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBarPainterBlockBase o)
        {
            _BlockPercent = o._BlockPercent;
            _BlockWidth = o._BlockWidth;
            _BlockSmooth = o._BlockSmooth;
            _BlockScroll = o._BlockScroll;
            _BlockLineColor = o._BlockLineColor;
            _BlockLineWidth = o._BlockLineWidth;
        }

        /// <summary>
        /// Called when [bar set].
        /// </summary>
        protected override void OnBarSet()
        {
            base.OnBarSet();

            _BlockLineColor = Bar.BackColor;
        }

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        /// <param name="setBarDefaults">if set to <c>true</c> [set bar defaults].</param>
        protected override void SetDefaults(bool setBarDefaults)
        {
            base.SetDefaults(setBarDefaults);

            _BlockPercent = _DefaultBlockPercent;
            _BlockWidth = _DefaultBlockWidth;
            _BlockSmooth = _DefaultBlockSmooth;
            _BlockScroll = _DefaultBlockScroll;
            _BlockLineColor = _DefaultBlockLineColor;
            _BlockLineWidth = _DefaultBlockLineWidth;

            if (Bar != null) _BlockLineColor = Bar.BackColor;
        }

    }
    #endregion

}
