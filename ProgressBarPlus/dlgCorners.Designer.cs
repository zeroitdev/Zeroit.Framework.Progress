// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-23-2018
// ***********************************************************************
// <copyright file="dlgCorners.Designer.cs" company="Zeroit Dev Technologies">
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
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class dlgCorners : System.Windows.Forms.Form
	{
        //Form overrides dispose to clean up the component list.
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Required by the Windows Form Designer
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			cBlendItems CBlendItems2 = new cBlendItems();
			cFocalPoints CFocalPoints2 = new cFocalPoints();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCorners));
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.panShapeHolder = new System.Windows.Forms.Panel();
			this.tbarUpperLeft = new System.Windows.Forms.TrackBar();
			this.tbarUpperRight = new System.Windows.Forms.TrackBar();
			this.tbarLowerLeft = new System.Windows.Forms.TrackBar();
			this.tbarLowerRight = new System.Windows.Forms.TrackBar();
			this.tbarAll = new System.Windows.Forms.TrackBar();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.HSBarSample = new System.Windows.Forms.HScrollBar();
			this.TheShape = new ZeroitProgBarPlus();
			this.TableLayoutPanel1.SuspendLayout();
			this.panShapeHolder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.tbarUpperLeft).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tbarUpperRight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tbarLowerLeft).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tbarLowerRight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tbarAll).BeginInit();
			this.SuspendLayout();
			//
			//TableLayoutPanel1
			//
			this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(185, 302);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
			this.TableLayoutPanel1.TabIndex = 0;
			//
			//OK_Button
			//
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point(3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(67, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "OK";
			//
			//Cancel_Button
			//
			this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "Cancel";
			//
			//panShapeHolder
			//
			this.panShapeHolder.Controls.Add(this.TheShape);
			this.panShapeHolder.Location = new System.Drawing.Point(71, 54);
			this.panShapeHolder.Name = "panShapeHolder";
			this.panShapeHolder.Size = new System.Drawing.Size(200, 200);
			this.panShapeHolder.TabIndex = 5;
			//
			//tbarUpperLeft
			//
			this.tbarUpperLeft.Location = new System.Drawing.Point(71, 12);
			this.tbarUpperLeft.Maximum = 50;
			this.tbarUpperLeft.Name = "tbarUpperLeft";
			this.tbarUpperLeft.Size = new System.Drawing.Size(125, 45);
			this.tbarUpperLeft.TabIndex = 6;
			this.tbarUpperLeft.TickFrequency = 50;
			//
			//tbarUpperRight
			//
			this.tbarUpperRight.Location = new System.Drawing.Point(289, 54);
			this.tbarUpperRight.Maximum = 100;
			this.tbarUpperRight.Name = "tbarUpperRight";
			this.tbarUpperRight.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbarUpperRight.Size = new System.Drawing.Size(45, 125);
			this.tbarUpperRight.TabIndex = 7;
			this.tbarUpperRight.TickFrequency = 50;
			this.tbarUpperRight.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			//
			//tbarLowerLeft
			//
			this.tbarLowerLeft.Location = new System.Drawing.Point(12, 129);
			this.tbarLowerLeft.Maximum = 50;
			this.tbarLowerLeft.Name = "tbarLowerLeft";
			this.tbarLowerLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbarLowerLeft.Size = new System.Drawing.Size(45, 125);
			this.tbarLowerLeft.TabIndex = 8;
			this.tbarLowerLeft.TickFrequency = 50;
			//
			//tbarLowerRight
			//
			this.tbarLowerRight.Location = new System.Drawing.Point(146, 265);
			this.tbarLowerRight.Maximum = 50;
			this.tbarLowerRight.Name = "tbarLowerRight";
			this.tbarLowerRight.Size = new System.Drawing.Size(125, 45);
			this.tbarLowerRight.TabIndex = 9;
			this.tbarLowerRight.TickFrequency = 50;
			this.tbarLowerRight.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			//
			//tbarAll
			//
			this.tbarAll.Location = new System.Drawing.Point(13, 300);
			this.tbarAll.Maximum = 50;
			this.tbarAll.Name = "tbarAll";
			this.tbarAll.Size = new System.Drawing.Size(125, 45);
			this.tbarAll.TabIndex = 6;
			this.tbarAll.TickFrequency = 50;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(19, 11);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(54, 13);
			this.Label1.TabIndex = 10;
			this.Label1.Text = "UpperLeft";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(274, 42);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(61, 13);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "UpperRight";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(88, 271);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(61, 13);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "LowerRight";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(2, 113);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(54, 13);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "LowerLeft";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(22, 284);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(18, 13);
			this.Label5.TabIndex = 10;
			this.Label5.Text = "All";
			//
			//HSBarSample
			//
			this.HSBarSample.Location = new System.Drawing.Point(55, 253);
			this.HSBarSample.Maximum = 109;
			this.HSBarSample.Name = "HSBarSample";
			this.HSBarSample.Size = new System.Drawing.Size(233, 13);
			this.HSBarSample.TabIndex = 11;
			this.HSBarSample.Value = 100;
			//
			//TheShape
			//
			CBlendItems2.iColor = new System.Drawing.Color[] {System.Drawing.Color.White, System.Drawing.Color.White};
			CBlendItems2.iPoint = new float[] {0.0F, 1.0F};
			this.TheShape.BarColorBlend = CBlendItems2;
			this.TheShape.BarColorSolid = System.Drawing.Color.Blue;
			this.TheShape.BarColorSolidB = System.Drawing.Color.White;
			this.TheShape.BarLength = ZeroitProgBarPlus.eBarLength.Full;
			this.TheShape.BarLengthValue = Convert.ToInt16(25);
			this.TheShape.BarPadding = new System.Windows.Forms.Padding(0);
			this.TheShape.BarStyleFill = ZeroitProgBarPlus.eBarStyle.Solid;
			this.TheShape.BarStyleHatch = System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard;
			this.TheShape.BarStyleLinear = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
			this.TheShape.BarStyleTexture = null;
			this.TheShape.BarStyleWrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
			this.TheShape.BarType = ZeroitProgBarPlus.eBarType.Bar;
			this.TheShape.BorderWidth = Convert.ToInt16(1);
			this.TheShape.Corners.All = Convert.ToInt16(0);
			this.TheShape.Corners.LowerLeft = Convert.ToInt16(0);
			this.TheShape.Corners.LowerRight = Convert.ToInt16(0);
			this.TheShape.Corners.UpperLeft = Convert.ToInt16(0);
			this.TheShape.Corners.UpperRight = Convert.ToInt16(0);
			this.TheShape.CornersApply = ZeroitProgBarPlus.eCornersApply.Both;
			this.TheShape.CylonInterval = Convert.ToInt16(1);
			this.TheShape.CylonMove = 5.0F;
			this.TheShape.FillDirection = ZeroitProgBarPlus.eFillDirection.Up_Right;
			CFocalPoints2.CenterPoint = (System.Drawing.PointF)resources.GetObject("CFocalPoints2.CenterPoint");
			CFocalPoints2.FocusScales = (System.Drawing.PointF)resources.GetObject("CFocalPoints2.FocusScales");
			this.TheShape.FocalPoints = CFocalPoints2;
			this.TheShape.Location = new System.Drawing.Point(0, 0);
			this.TheShape.Name = "TheShape";
			this.TheShape.Orientation = ZeroitProgBarPlus.eOrientation.Horizontal;
			this.TheShape.Shape = ZeroitProgBarPlus.eShape.Rectangle;
			this.TheShape.ShapeTextFont = new System.Drawing.Font("Arial Black", 30.0F);
			this.TheShape.ShapeTextRotate = ZeroitProgBarPlus.eRotateText.None;
			this.TheShape.Size = new System.Drawing.Size(200, 200);
			this.TheShape.TabIndex = 0;
			this.TheShape.TextAlignment = System.Drawing.StringAlignment.Center;
			this.TheShape.TextAlignmentVert = System.Drawing.StringAlignment.Center;
			this.TheShape.TextPlacement = ZeroitProgBarPlus.eTextPlacement.OverBar;
			this.TheShape.TextRotate = ZeroitProgBarPlus.eRotateText.None;
			this.TheShape.TextShow = ZeroitProgBarPlus.eTextShow.None;
			this.TheShape.Value = 100;
			//
			//dlgCorners
			//
			this.AcceptButton = this.OK_Button;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(340, 339);
			this.Controls.Add(this.HSBarSample);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.tbarUpperRight);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.panShapeHolder);
			this.Controls.Add(this.tbarLowerRight);
			this.Controls.Add(this.tbarLowerLeft);
			this.Controls.Add(this.tbarAll);
			this.Controls.Add(this.tbarUpperLeft);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCorners";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Corner Adjustment";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.panShapeHolder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.tbarUpperLeft).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tbarUpperRight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tbarLowerLeft).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tbarLowerRight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tbarAll).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

//INSTANT C# NOTE: Converted design-time event handler wireups:
			OK_Button.Click += new System.EventHandler(OK_Button_Click);
			Cancel_Button.Click += new System.EventHandler(Cancel_Button_Click);
			tbarUpperLeft.Scroll += new System.EventHandler(tbarUpperLeft_Scroll);
			tbarUpperRight.Scroll += new System.EventHandler(tbarUpperRight_Scroll);
			tbarLowerLeft.Scroll += new System.EventHandler(tbarLowerLeft_Scroll);
			tbarLowerRight.Scroll += new System.EventHandler(tbarLowerRight_Scroll);
			tbarAll.Scroll += new System.EventHandler(tbarAll_Scroll);
			this.Load += new System.EventHandler(dlgCorners_Load);
			HSBarSample.Scroll += new System.Windows.Forms.ScrollEventHandler(HSBarSample_Scroll);
		}
        /// <summary>
        /// The table layout panel1
        /// </summary>
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        /// <summary>
        /// The ok button
        /// </summary>
        internal System.Windows.Forms.Button OK_Button;
        /// <summary>
        /// The cancel button
        /// </summary>
        internal System.Windows.Forms.Button Cancel_Button;
        /// <summary>
        /// The pan shape holder
        /// </summary>
        internal System.Windows.Forms.Panel panShapeHolder;
        /// <summary>
        /// The tbar upper left
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarUpperLeft;
        /// <summary>
        /// The tbar upper right
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarUpperRight;
        /// <summary>
        /// The tbar lower left
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarLowerLeft;
        /// <summary>
        /// The tbar lower right
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarLowerRight;
        /// <summary>
        /// The tbar all
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarAll;
        /// <summary>
        /// The label1
        /// </summary>
        internal System.Windows.Forms.Label Label1;
        /// <summary>
        /// The label2
        /// </summary>
        internal System.Windows.Forms.Label Label2;
        /// <summary>
        /// The label3
        /// </summary>
        internal System.Windows.Forms.Label Label3;
        /// <summary>
        /// The label4
        /// </summary>
        internal System.Windows.Forms.Label Label4;
        /// <summary>
        /// The label5
        /// </summary>
        internal System.Windows.Forms.Label Label5;
        /// <summary>
        /// The shape
        /// </summary>
        internal ZeroitProgBarPlus TheShape;
        /// <summary>
        /// The hs bar sample
        /// </summary>
        internal System.Windows.Forms.HScrollBar HSBarSample;

	}

}