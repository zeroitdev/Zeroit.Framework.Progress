// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MyMaths.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.Progress.Math
{
    /// <summary>
    /// Class MyMaths.
    /// </summary>
    public class MyMaths
    {
        /// <summary>
        /// Percents the specified range.
        /// </summary>
        /// <param name="Range">The range.</param>
        /// <param name="Percent">The percent.</param>
        /// <returns>System.Double.</returns>
        protected static double Percent(float Range, float Percent)
        {
            return System.Math.Ceiling(Range *Percent / 100);
        }
        /// <summary>
        /// Percents the specified range.
        /// </summary>
        /// <param name="Range">The range.</param>
        /// <param name="Percent">The percent.</param>
        /// <returns>System.Int32.</returns>
        public static int Percent(int Range, int Percent)
        {
            return (int)MyMaths.Percent((float)Range,(float)Percent);
        }
    }
}
