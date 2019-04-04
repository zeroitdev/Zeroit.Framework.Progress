// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IPainter.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region IPainter
    //-----------------------------------------------------------------------------
    // IPainter

    /// <summary>
    /// Interface IPainter
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    public interface IPainter : ICloneable
    {
        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>IPainter.</returns>
        IPainter CreateCopy();
        /// <summary>
        /// Gets or sets the zeroit busy bar.
        /// </summary>
        /// <value>The zeroit busy bar.</value>
        ZeroitBusyBar ZeroitBusyBar { get; set; }
        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();
        /// <summary>
        /// Paints the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="r">The r.</param>
        void Paint(Graphics g, Region r);
    }
    #endregion
}
