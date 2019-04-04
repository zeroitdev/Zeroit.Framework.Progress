// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MySize.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.Progress.Drawing
{
    /// <summary>
    /// Class MySize.
    /// </summary>
    public class MySize
    {
        /// <summary>
        /// Compares the specified s1.
        /// </summary>
        /// <param name="S1">The s1.</param>
        /// <param name="S2">The s2.</param>
        /// <returns>CompareOutputTypes.</returns>
        public static CompareOutputTypes Compare(Size S1, Size S2)
        {
            if (S1.Height == S2.Height && S1.Width == S2.Width)
                return CompareOutputTypes.Equal;
            if (S1.Height <= S2.Height && S1.Width <= S2.Width)
                return CompareOutputTypes.Smaller;
            if (S1.Height <= S2.Height && S1.Width >= S2.Width)
                return CompareOutputTypes.Unknown;
            return CompareOutputTypes.Larger;

        }
        /// <summary>
        /// Enum CompareOutputTypes
        /// </summary>
        public enum CompareOutputTypes { Smaller, Equal, Larger,Unknown };
    }
    
}
