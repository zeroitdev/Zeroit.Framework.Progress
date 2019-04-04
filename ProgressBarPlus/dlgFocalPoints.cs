// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="dlgFocalPoints.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class dlgFocalPoints.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class dlgFocalPoints
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="dlgFocalPoints"/> class.
        /// </summary>
        internal dlgFocalPoints()
		{
			InitializeComponent();
		}

        /// <summary>
        /// The FPP
        /// </summary>
        private cFocalPoints fpp = new cFocalPoints();

        /// <summary>
        /// Handles the KeyDown event of the dlgEditSelected control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void dlgEditSelected_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
			if (e.KeyCode == Keys.Enter)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

        /// <summary>
        /// Handles the MouseDown event of the tbarFocalX control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void tbarFocalX_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				((TrackBar)sender).Value = 0;
				UpdateFocusScales();
			}
		}

        /// <summary>
        /// Handles the Scroll event of the tbarFocalY control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tbarFocalY_Scroll(object sender, System.EventArgs e)
		{
			UpdateFocusScales();
		}

        /// <summary>
        /// Updates the focus scales.
        /// </summary>
        public void UpdateFocusScales()
		{
			TheShape.FocalPoints.FocusScales = new PointF(Convert.ToSingle(tbarFocalX.Value / 1000.0), Convert.ToSingle(tbarFocalY.Value / 1000.0));
			TheShape.Invalidate();
			lblFx.Text = TheShape.FocalPoints.FocusScales.X.ToString();
			lblFy.Text = TheShape.FocalPoints.FocusScales.Y.ToString();
		}

        /// <summary>
        /// Handles the MouseDown event of the TheShape control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void TheShape_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				TheShape.FocalPoints.CenterPoint = new PointF(Convert.ToSingle(e.X / (double)TheShape.Width), Convert.ToSingle(e.Y / (double)TheShape.Height));
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				TheShape.FocalPoints.CenterPoint = new PointF(0.5F, 0.5F);
			}
			TheShape.Invalidate();
			UpdateCenterLabels(TheShape.FocalPoints.CenterPoint.X, TheShape.FocalPoints.CenterPoint.Y);
		}

        /// <summary>
        /// Updates the center labels.
        /// </summary>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        public void UpdateCenterLabels(double cx, double cy)
		{
			lblCx.Text = "Center X=" + System.Math.Round(cx, 4);
			lblCy.Text = "Center Y=" + System.Math.Round(cy, 4);
		}

        /// <summary>
        /// Handles the Shown event of the dlgFocalPoints control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dlgFocalPoints_Shown(object sender, System.EventArgs e)
		{
			fpp = new cFocalPoints(TheShape.FocalPoints.CenterPoint.X, TheShape.FocalPoints.CenterPoint.Y, TheShape.FocalPoints.FocusScales.X, TheShape.FocalPoints.FocusScales.Y);
			tbarFocalX.Value = Convert.ToInt32(fpp.FocusScales.X * 1000);
			tbarFocalY.Value = Convert.ToInt32(fpp.FocusScales.Y * 1000);
			UpdateCenterLabels(fpp.CenterPoint.X, fpp.CenterPoint.Y);
			lblFx.Text = fpp.FocusScales.X.ToString();
			lblFy.Text = fpp.FocusScales.Y.ToString();
		}

        /// <summary>
        /// Handles the Click event of the butCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void butCancel_Click(object sender, System.EventArgs e)
		{
			TheShape.FocalPoints = new cFocalPoints(fpp.CenterPoint.X, fpp.CenterPoint.Y, fpp.FocusScales.X, fpp.FocusScales.Y);
		}
	}

}