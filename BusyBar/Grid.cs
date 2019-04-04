// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Grid.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarGrid
    //-----------------------------------------------------------------------------
    // 

    /// <summary>
    /// Class ZeroitBusyBarGrid.
    /// </summary>
    public class ZeroitBusyBarGrid
    {
        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineWidth">Width of the line.</param>
        /// <param name="spaceX">The space x.</param>
        /// <param name="spaceY">The space y.</param>
        public static void Draw(
            Graphics g,
            Color lineColor,
            int lineWidth,
            float spaceX,
            float spaceY)
        {
            if (lineWidth <= 0) return;

            RectangleF r = g.Clip.GetBounds(g);

            using (Pen pen = new Pen(lineColor, lineWidth))
            {
                // Vertical
                float xCentre = r.Left + (r.Width / 2f);
                float xCount = (r.Width % spaceX) + 1;
                float xExtent = spaceX * xCount;
                float xLeft = xCentre - xExtent;
                float xRight = xCentre + xExtent;

                for (float x = xLeft; x < xRight; x += spaceX)
                    g.DrawLine(pen, x, r.Top, x, r.Bottom);

                // Horizontal
                float yCentre = r.Top + (r.Height / 2f);
                float yCount = (r.Height % spaceY) + 1;
                float yExtent = spaceY * yCount;
                float yTop = yCentre - yExtent;
                float yBottom = yCentre + yExtent;

                for (float y = yTop; y < yBottom; y += spaceY)
                    g.DrawLine(pen, r.Left, y, r.Right, y);
            }
        }
    }


    #endregion

}
