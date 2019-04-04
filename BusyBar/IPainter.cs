// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="IPainter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
