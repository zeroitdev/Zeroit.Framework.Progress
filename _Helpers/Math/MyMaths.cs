// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MyMaths.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
