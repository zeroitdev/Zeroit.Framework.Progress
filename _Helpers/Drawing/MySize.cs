// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MySize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
