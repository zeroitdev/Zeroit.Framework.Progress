// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="dlgFocalPoints.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class dlgFocalPoints.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class dlgFocalPoints : System.Windows.Forms.Form
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
			cBlendItems CBlendItems1 = new cBlendItems();
			cFocalPoints CFocalPoints1 = new cFocalPoints();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFocalPoints));
			this.butApply = new System.Windows.Forms.Button();
			this.tbarFocalX = new System.Windows.Forms.TrackBar();
			this.tbarFocalY = new System.Windows.Forms.TrackBar();
			this.panShapeHolder = new System.Windows.Forms.Panel();
			this.TheShape = new ZeroitProgBarPlus();
			this.lblFy = new System.Windows.Forms.Label();
			this.lblFx = new System.Windows.Forms.Label();
			this.lblCx = new System.Windows.Forms.Label();
			this.lblCy = new System.Windows.Forms.Label();
			this.butCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.tbarFocalX).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tbarFocalY).BeginInit();
			this.panShapeHolder.SuspendLayout();
			this.SuspendLayout();
			//
			//butApply
			//
			this.butApply.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.butApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.butApply.Location = new System.Drawing.Point(106, 301);
			this.butApply.Name = "butApply";
			this.butApply.Size = new System.Drawing.Size(67, 23);
			this.butApply.TabIndex = 0;
			this.butApply.Text = "Apply";
			//
			//tbarFocalX
			//
			this.tbarFocalX.LargeChange = 10;
			this.tbarFocalX.Location = new System.Drawing.Point(12, 218);
			this.tbarFocalX.Maximum = 1000;
			this.tbarFocalX.Name = "tbarFocalX";
			this.tbarFocalX.Size = new System.Drawing.Size(200, 45);
			this.tbarFocalX.TabIndex = 3;
			this.tbarFocalX.TickFrequency = 50;
			this.tbarFocalX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.tbarFocalX.Value = 500;
			//
			//tbarFocalY
			//
			this.tbarFocalY.Location = new System.Drawing.Point(218, 12);
			this.tbarFocalY.Maximum = 1000;
			this.tbarFocalY.Name = "tbarFocalY";
			this.tbarFocalY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbarFocalY.Size = new System.Drawing.Size(45, 200);
			this.tbarFocalY.TabIndex = 3;
			this.tbarFocalY.TickFrequency = 50;
			this.tbarFocalY.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.tbarFocalY.Value = 500;
			//
			//panShapeHolder
			//
			this.panShapeHolder.Controls.Add(this.TheShape);
			this.panShapeHolder.Location = new System.Drawing.Point(12, 12);
			this.panShapeHolder.Name = "panShapeHolder";
			this.panShapeHolder.Size = new System.Drawing.Size(200, 200);
			this.panShapeHolder.TabIndex = 4;
			//
			//TheShape
			//
			CBlendItems1.iColor = new System.Drawing.Color[] {System.Drawing.Color.White, System.Drawing.Color.White};
			CBlendItems1.iPoint = new float[] {0.0F, 1.0F};
			this.TheShape.BarColorBlend = CBlendItems1;
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
			this.TheShape.CylonMove = 5.0F;
			this.TheShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TheShape.BorderWidth = Convert.ToInt16(1);
			this.TheShape.Corners.All = Convert.ToInt16(0);
			this.TheShape.Corners.LowerLeft = Convert.ToInt16(0);
			this.TheShape.Corners.LowerRight = Convert.ToInt16(0);
			this.TheShape.Corners.UpperLeft = Convert.ToInt16(0);
			this.TheShape.Corners.UpperRight = Convert.ToInt16(0);
			this.TheShape.CornersApply = ZeroitProgBarPlus.eCornersApply.Both;
			this.TheShape.FillDirection = ZeroitProgBarPlus.eFillDirection.Up_Right;
			CFocalPoints1.CenterPoint = (System.Drawing.PointF)resources.GetObject("CFocalPoints1.CenterPoint");
			CFocalPoints1.FocusScales = (System.Drawing.PointF)resources.GetObject("CFocalPoints1.FocusScales");
			this.TheShape.FocalPoints = CFocalPoints1;
			this.TheShape.CylonInterval = Convert.ToInt16(1);
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
			//lblFy
			//
			this.lblFy.Location = new System.Drawing.Point(220, 208);
			this.lblFy.Name = "lblFy";
			this.lblFy.Size = new System.Drawing.Size(37, 17);
			this.lblFy.TabIndex = 5;
			this.lblFy.Text = "0.5";
			this.lblFy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			//
			//lblFx
			//
			this.lblFx.Location = new System.Drawing.Point(206, 230);
			this.lblFx.Name = "lblFx";
			this.lblFx.Size = new System.Drawing.Size(37, 17);
			this.lblFx.TabIndex = 5;
			this.lblFx.Text = "0.5";
			this.lblFx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			//lblCx
			//
			this.lblCx.AutoSize = true;
			this.lblCx.Location = new System.Drawing.Point(14, 272);
			this.lblCx.Name = "lblCx";
			this.lblCx.Size = new System.Drawing.Size(48, 13);
			this.lblCx.TabIndex = 6;
			this.lblCx.Text = "Center X";
			//
			//lblCy
			//
			this.lblCy.AutoSize = true;
			this.lblCy.Location = new System.Drawing.Point(132, 272);
			this.lblCy.Name = "lblCy";
			this.lblCy.Size = new System.Drawing.Size(48, 13);
			this.lblCy.TabIndex = 7;
			this.lblCy.Text = "Center Y";
			//
			//butCancel
			//
			this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(179, 301);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(67, 23);
			this.butCancel.TabIndex = 0;
			this.butCancel.Text = "Cancel";
			//
			//dlgFocalPoints
			//
			this.AcceptButton = this.butApply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 336);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butApply);
			this.Controls.Add(this.lblCy);
			this.Controls.Add(this.lblCx);
			this.Controls.Add(this.lblFx);
			this.Controls.Add(this.lblFy);
			this.Controls.Add(this.panShapeHolder);
			this.Controls.Add(this.tbarFocalY);
			this.Controls.Add(this.tbarFocalX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgFocalPoints";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Adjust CenterPoint & Focus Scales";
			((System.ComponentModel.ISupportInitialize)this.tbarFocalX).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tbarFocalY).EndInit();
			this.panShapeHolder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

//INSTANT C# NOTE: Converted design-time event handler wireups:
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(dlgEditSelected_KeyDown);
			tbarFocalX.MouseDown += new System.Windows.Forms.MouseEventHandler(tbarFocalX_MouseDown);
			tbarFocalY.MouseDown += new System.Windows.Forms.MouseEventHandler(tbarFocalX_MouseDown);
			tbarFocalY.Scroll += new System.EventHandler(tbarFocalY_Scroll);
			tbarFocalX.Scroll += new System.EventHandler(tbarFocalY_Scroll);
			TheShape.MouseDown += new System.Windows.Forms.MouseEventHandler(TheShape_MouseDown);
			TheShape.MouseMove += new System.Windows.Forms.MouseEventHandler(TheShape_MouseDown);
			this.Shown += new System.EventHandler(dlgFocalPoints_Shown);
			butCancel.Click += new System.EventHandler(butCancel_Click);
		}
        /// <summary>
        /// The but apply
        /// </summary>
        internal System.Windows.Forms.Button butApply;
        /// <summary>
        /// The tbar focal x
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarFocalX;
        /// <summary>
        /// The tbar focal y
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarFocalY;
        /// <summary>
        /// The pan shape holder
        /// </summary>
        internal System.Windows.Forms.Panel panShapeHolder;
        /// <summary>
        /// The label fy
        /// </summary>
        internal System.Windows.Forms.Label lblFy;
        /// <summary>
        /// The label fx
        /// </summary>
        internal System.Windows.Forms.Label lblFx;
        /// <summary>
        /// The label cx
        /// </summary>
        internal System.Windows.Forms.Label lblCx;
        /// <summary>
        /// The label cy
        /// </summary>
        internal System.Windows.Forms.Label lblCy;
        /// <summary>
        /// The but cancel
        /// </summary>
        internal System.Windows.Forms.Button butCancel;
        /// <summary>
        /// The shape
        /// </summary>
        internal ZeroitProgBarPlus TheShape;

	}

}