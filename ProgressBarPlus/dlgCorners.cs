// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="dlgCorners.cs" company="Zeroit Dev Technologies">
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
using System;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class dlgCorners.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class dlgCorners
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="dlgCorners"/> class.
        /// </summary>
        internal dlgCorners()
		{
			InitializeComponent();
		}

        /// <summary>
        /// The CNRS
        /// </summary>
        private CornersProperty cnrs = new CornersProperty();

        /// <summary>
        /// Handles the Click event of the OK_Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OK_Button_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

        /// <summary>
        /// Handles the Click event of the Cancel_Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			TheShape.Corners.UpperLeft = cnrs.UpperLeft;
			TheShape.Corners.UpperRight = cnrs.UpperRight;
			TheShape.Corners.LowerLeft = cnrs.LowerLeft;
			TheShape.Corners.LowerRight = cnrs.LowerRight;

			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

        /// <summary>
        /// Handles the Scroll event of the tbarUpperLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarUpperLeft_Scroll(object sender, System.EventArgs e)
		{
			TheShape.Corners.UpperLeft = Convert.ToInt16(tbarUpperLeft.Value);
			TheShape.Invalidate();
		}

        /// <summary>
        /// Handles the Scroll event of the tbarUpperRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarUpperRight_Scroll(object sender, System.EventArgs e)
		{
			TheShape.Corners.UpperRight = Convert.ToInt16(tbarUpperRight.Value);
			TheShape.Invalidate();
		}

        /// <summary>
        /// Handles the Scroll event of the tbarLowerLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarLowerLeft_Scroll(object sender, System.EventArgs e)
		{
			TheShape.Corners.LowerLeft = Convert.ToInt16(tbarLowerLeft.Value);
			TheShape.Invalidate();
		}

        /// <summary>
        /// Handles the Scroll event of the tbarLowerRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarLowerRight_Scroll(object sender, System.EventArgs e)
		{
			TheShape.Corners.LowerRight = Convert.ToInt16(tbarLowerRight.Value);
			TheShape.Invalidate();
		}

        /// <summary>
        /// Handles the Scroll event of the tbarAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarAll_Scroll(object sender, System.EventArgs e)
		{
			tbarUpperLeft.Value = tbarAll.Value;
			tbarUpperRight.Value = tbarAll.Value;
			tbarLowerLeft.Value = tbarAll.Value;
			tbarLowerRight.Value = tbarAll.Value;
			TheShape.Corners.UpperLeft = Convert.ToInt16(tbarAll.Value);
			TheShape.Corners.UpperRight = Convert.ToInt16(tbarAll.Value);
			TheShape.Corners.LowerLeft = Convert.ToInt16(tbarAll.Value);
			TheShape.Corners.LowerRight = Convert.ToInt16(tbarAll.Value);
			TheShape.Invalidate();

		}

        /// <summary>
        /// Handles the Load event of the dlgCorners control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dlgCorners_Load(object sender, System.EventArgs e)
		{
			cnrs.UpperLeft = TheShape.Corners.UpperLeft;
			cnrs.UpperRight = TheShape.Corners.UpperRight;
			cnrs.LowerLeft = TheShape.Corners.LowerLeft;
			cnrs.LowerRight = TheShape.Corners.LowerRight;
		}

        /// <summary>
        /// Handles the Scroll event of the HSBarSample control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ScrollEventArgs"/> instance containing the event data.</param>
        private void HSBarSample_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			TheShape.Value = HSBarSample.Value;
		}

	}

}