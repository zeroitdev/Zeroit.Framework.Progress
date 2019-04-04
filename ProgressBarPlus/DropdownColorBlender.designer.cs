// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="DropdownColorBlender.designer.cs" company="Zeroit Dev Technologies">
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
    /// Class DropdownColorBlender.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class DropdownColorBlender : System.Windows.Forms.UserControl
	{
        //UserControl overrides dispose to clean up the component list.
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
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
			this.panProps = new System.Windows.Forms.Panel();
			this.lblPos = new System.Windows.Forms.Label();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.Panel20 = new System.Windows.Forms.Panel();
			this.Panel7 = new System.Windows.Forms.Panel();
			this.Panel22 = new System.Windows.Forms.Panel();
			this.Panel6 = new System.Windows.Forms.Panel();
			this.Panel29 = new System.Windows.Forms.Panel();
			this.Panel23 = new System.Windows.Forms.Panel();
			this.Panel8 = new System.Windows.Forms.Panel();
			this.Panel24 = new System.Windows.Forms.Panel();
			this.Panel9 = new System.Windows.Forms.Panel();
			this.Panel25 = new System.Windows.Forms.Panel();
			this.Panel10 = new System.Windows.Forms.Panel();
			this.Panel26 = new System.Windows.Forms.Panel();
			this.Panel11 = new System.Windows.Forms.Panel();
			this.Panel27 = new System.Windows.Forms.Panel();
			this.Panel12 = new System.Windows.Forms.Panel();
			this.Panel28 = new System.Windows.Forms.Panel();
			this.Panel13 = new System.Windows.Forms.Panel();
			this.Panel18 = new System.Windows.Forms.Panel();
			this.Panel19 = new System.Windows.Forms.Panel();
			this.Panel21 = new System.Windows.Forms.Panel();
			this.Panel14 = new System.Windows.Forms.Panel();
			this.Panel17 = new System.Windows.Forms.Panel();
			this.Panel15 = new System.Windows.Forms.Panel();
			this.Panel16 = new System.Windows.Forms.Panel();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.nudRed = new System.Windows.Forms.NumericUpDown();
			this.nudGreen = new System.Windows.Forms.NumericUpDown();
			this.nudBlue = new System.Windows.Forms.NumericUpDown();
			this.ColorBox = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.txbAlpha = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.tbarAlpha = new System.Windows.Forms.TrackBar();
			this.txbCurrColor = new System.Windows.Forms.TextBox();
			this.panCurrColor = new System.Windows.Forms.Panel();
			this.butClear = new System.Windows.Forms.Button();
			this.butApply = new System.Windows.Forms.Button();
			this.panProps.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.nudRed).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nudGreen).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nudBlue).BeginInit();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.tbarAlpha).BeginInit();
			this.SuspendLayout();
			//
			//panProps
			//
			this.panProps.Controls.Add(this.lblPos);
			this.panProps.Controls.Add(this.TabControl1);
			this.panProps.Controls.Add(this.txbCurrColor);
			this.panProps.Controls.Add(this.panCurrColor);
			this.panProps.Location = new System.Drawing.Point(3, 43);
			this.panProps.Name = "panProps";
			this.panProps.Size = new System.Drawing.Size(186, 115);
			this.panProps.TabIndex = 6;
			//
			//lblPos
			//
			this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblPos.Location = new System.Drawing.Point(151, 5);
			this.lblPos.Name = "lblPos";
			this.lblPos.Size = new System.Drawing.Size(34, 16);
			this.lblPos.TabIndex = 12;
			this.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.TabControl1.ItemSize = new System.Drawing.Size(59, 18);
			this.TabControl1.Location = new System.Drawing.Point(4, 24);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(182, 90);
			this.TabControl1.TabIndex = 11;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.Panel20);
			this.TabPage1.Controls.Add(this.Panel7);
			this.TabPage1.Controls.Add(this.Panel22);
			this.TabPage1.Controls.Add(this.Panel6);
			this.TabPage1.Controls.Add(this.Panel29);
			this.TabPage1.Controls.Add(this.Panel23);
			this.TabPage1.Controls.Add(this.Panel8);
			this.TabPage1.Controls.Add(this.Panel24);
			this.TabPage1.Controls.Add(this.Panel9);
			this.TabPage1.Controls.Add(this.Panel25);
			this.TabPage1.Controls.Add(this.Panel10);
			this.TabPage1.Controls.Add(this.Panel26);
			this.TabPage1.Controls.Add(this.Panel11);
			this.TabPage1.Controls.Add(this.Panel27);
			this.TabPage1.Controls.Add(this.Panel12);
			this.TabPage1.Controls.Add(this.Panel28);
			this.TabPage1.Controls.Add(this.Panel13);
			this.TabPage1.Controls.Add(this.Panel18);
			this.TabPage1.Controls.Add(this.Panel19);
			this.TabPage1.Controls.Add(this.Panel21);
			this.TabPage1.Controls.Add(this.Panel14);
			this.TabPage1.Controls.Add(this.Panel17);
			this.TabPage1.Controls.Add(this.Panel15);
			this.TabPage1.Controls.Add(this.Panel16);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(174, 64);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Swatches";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//Panel20
			//
			this.Panel20.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(0)));
			this.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel20.Location = new System.Drawing.Point(48, 6);
			this.Panel20.Name = "Panel20";
			this.Panel20.Size = new System.Drawing.Size(17, 17);
			this.Panel20.TabIndex = 35;
			//
			//Panel7
			//
			this.Panel7.BackColor = System.Drawing.Color.White;
			this.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel7.Location = new System.Drawing.Point(6, 6);
			this.Panel7.Name = "Panel7";
			this.Panel7.Size = new System.Drawing.Size(17, 17);
			this.Panel7.TabIndex = 29;
			//
			//Panel22
			//
			this.Panel22.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Panel22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel22.Location = new System.Drawing.Point(153, 44);
			this.Panel22.Name = "Panel22";
			this.Panel22.Size = new System.Drawing.Size(17, 17);
			this.Panel22.TabIndex = 43;
			//
			//Panel6
			//
			this.Panel6.BackColor = System.Drawing.Color.Black;
			this.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel6.Location = new System.Drawing.Point(6, 44);
			this.Panel6.Name = "Panel6";
			this.Panel6.Size = new System.Drawing.Size(17, 17);
			this.Panel6.TabIndex = 30;
			//
			//Panel29
			//
			this.Panel29.BackColor = System.Drawing.Color.Silver;
			this.Panel29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel29.Location = new System.Drawing.Point(6, 25);
			this.Panel29.Name = "Panel29";
			this.Panel29.Size = new System.Drawing.Size(17, 17);
			this.Panel29.TabIndex = 28;
			//
			//Panel23
			//
			this.Panel23.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(255)));
			this.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel23.Location = new System.Drawing.Point(111, 44);
			this.Panel23.Name = "Panel23";
			this.Panel23.Size = new System.Drawing.Size(17, 17);
			this.Panel23.TabIndex = 44;
			//
			//Panel8
			//
			this.Panel8.BackColor = System.Drawing.Color.Red;
			this.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel8.Location = new System.Drawing.Point(27, 6);
			this.Panel8.Name = "Panel8";
			this.Panel8.Size = new System.Drawing.Size(17, 17);
			this.Panel8.TabIndex = 33;
			//
			//Panel24
			//
			this.Panel24.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)));
			this.Panel24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel24.Location = new System.Drawing.Point(132, 44);
			this.Panel24.Name = "Panel24";
			this.Panel24.Size = new System.Drawing.Size(17, 17);
			this.Panel24.TabIndex = 45;
			//
			//Panel9
			//
			this.Panel9.BackColor = System.Drawing.Color.Lime;
			this.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel9.Location = new System.Drawing.Point(90, 6);
			this.Panel9.Name = "Panel9";
			this.Panel9.Size = new System.Drawing.Size(17, 17);
			this.Panel9.TabIndex = 32;
			//
			//Panel25
			//
			this.Panel25.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel25.Location = new System.Drawing.Point(90, 44);
			this.Panel25.Name = "Panel25";
			this.Panel25.Size = new System.Drawing.Size(17, 17);
			this.Panel25.TabIndex = 42;
			//
			//Panel10
			//
			this.Panel10.BackColor = System.Drawing.Color.Blue;
			this.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel10.Location = new System.Drawing.Point(132, 6);
			this.Panel10.Name = "Panel10";
			this.Panel10.Size = new System.Drawing.Size(17, 17);
			this.Panel10.TabIndex = 31;
			//
			//Panel26
			//
			this.Panel26.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel26.Location = new System.Drawing.Point(69, 44);
			this.Panel26.Name = "Panel26";
			this.Panel26.Size = new System.Drawing.Size(17, 17);
			this.Panel26.TabIndex = 39;
			//
			//Panel11
			//
			this.Panel11.BackColor = System.Drawing.Color.Cyan;
			this.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel11.Location = new System.Drawing.Point(111, 6);
			this.Panel11.Name = "Panel11";
			this.Panel11.Size = new System.Drawing.Size(17, 17);
			this.Panel11.TabIndex = 24;
			//
			//Panel27
			//
			this.Panel27.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel27.Location = new System.Drawing.Point(48, 44);
			this.Panel27.Name = "Panel27";
			this.Panel27.Size = new System.Drawing.Size(17, 17);
			this.Panel27.TabIndex = 40;
			//
			//Panel12
			//
			this.Panel12.BackColor = System.Drawing.Color.Fuchsia;
			this.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel12.Location = new System.Drawing.Point(153, 6);
			this.Panel12.Name = "Panel12";
			this.Panel12.Size = new System.Drawing.Size(17, 17);
			this.Panel12.TabIndex = 23;
			//
			//Panel28
			//
			this.Panel28.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel28.Location = new System.Drawing.Point(27, 44);
			this.Panel28.Name = "Panel28";
			this.Panel28.Size = new System.Drawing.Size(17, 17);
			this.Panel28.TabIndex = 41;
			//
			//Panel13
			//
			this.Panel13.BackColor = System.Drawing.Color.Maroon;
			this.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel13.Location = new System.Drawing.Point(27, 25);
			this.Panel13.Name = "Panel13";
			this.Panel13.Size = new System.Drawing.Size(17, 17);
			this.Panel13.TabIndex = 22;
			//
			//Panel18
			//
			this.Panel18.BackColor = System.Drawing.Color.Purple;
			this.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel18.Location = new System.Drawing.Point(153, 25);
			this.Panel18.Name = "Panel18";
			this.Panel18.Size = new System.Drawing.Size(17, 17);
			this.Panel18.TabIndex = 34;
			//
			//Panel19
			//
			this.Panel19.BackColor = System.Drawing.Color.Yellow;
			this.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel19.Location = new System.Drawing.Point(69, 6);
			this.Panel19.Name = "Panel19";
			this.Panel19.Size = new System.Drawing.Size(17, 17);
			this.Panel19.TabIndex = 27;
			//
			//Panel21
			//
			this.Panel21.BackColor = System.Drawing.Color.Teal;
			this.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel21.Location = new System.Drawing.Point(111, 25);
			this.Panel21.Name = "Panel21";
			this.Panel21.Size = new System.Drawing.Size(17, 17);
			this.Panel21.TabIndex = 36;
			//
			//Panel14
			//
			this.Panel14.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(128)), Convert.ToInt32(Convert.ToByte(64)), Convert.ToInt32(Convert.ToByte(0)));
			this.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel14.Location = new System.Drawing.Point(48, 25);
			this.Panel14.Name = "Panel14";
			this.Panel14.Size = new System.Drawing.Size(17, 17);
			this.Panel14.TabIndex = 26;
			//
			//Panel17
			//
			this.Panel17.BackColor = System.Drawing.Color.Navy;
			this.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel17.Location = new System.Drawing.Point(132, 25);
			this.Panel17.Name = "Panel17";
			this.Panel17.Size = new System.Drawing.Size(17, 17);
			this.Panel17.TabIndex = 38;
			//
			//Panel15
			//
			this.Panel15.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(0)));
			this.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel15.Location = new System.Drawing.Point(69, 25);
			this.Panel15.Name = "Panel15";
			this.Panel15.Size = new System.Drawing.Size(17, 17);
			this.Panel15.TabIndex = 25;
			//
			//Panel16
			//
			this.Panel16.BackColor = System.Drawing.Color.Green;
			this.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel16.Location = new System.Drawing.Point(90, 25);
			this.Panel16.Name = "Panel16";
			this.Panel16.Size = new System.Drawing.Size(17, 17);
			this.Panel16.TabIndex = 37;
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.nudRed);
			this.TabPage3.Controls.Add(this.nudGreen);
			this.TabPage3.Controls.Add(this.nudBlue);
			this.TabPage3.Controls.Add(this.ColorBox);
			this.TabPage3.Controls.Add(this.Label2);
			this.TabPage3.Controls.Add(this.Label4);
			this.TabPage3.Controls.Add(this.Label3);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(174, 64);
			this.TabPage3.TabIndex = 2;
			this.TabPage3.Text = "Color";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//nudRed
			//
			this.nudRed.Location = new System.Drawing.Point(21, 41);
			this.nudRed.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudRed.Name = "nudRed";
			this.nudRed.Size = new System.Drawing.Size(40, 20);
			this.nudRed.TabIndex = 8;
			this.nudRed.Value = new decimal(new int[] {255, 0, 0, 0});
			//
			//nudGreen
			//
			this.nudGreen.Location = new System.Drawing.Point(67, 41);
			this.nudGreen.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudGreen.Name = "nudGreen";
			this.nudGreen.Size = new System.Drawing.Size(40, 20);
			this.nudGreen.TabIndex = 8;
			this.nudGreen.Value = new decimal(new int[] {255, 0, 0, 0});
			//
			//nudBlue
			//
			this.nudBlue.Location = new System.Drawing.Point(113, 41);
			this.nudBlue.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudBlue.Name = "nudBlue";
			this.nudBlue.Size = new System.Drawing.Size(40, 20);
			this.nudBlue.TabIndex = 8;
			this.nudBlue.Value = new decimal(new int[] {255, 0, 0, 0});
			//
			//ColorBox
			//
			this.ColorBox.Font = new System.Drawing.Font("Tahoma", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.ColorBox.FormattingEnabled = true;
			this.ColorBox.Location = new System.Drawing.Point(5, 3);
			this.ColorBox.Name = "ColorBox";
			this.ColorBox.Size = new System.Drawing.Size(164, 24);
			this.ColorBox.TabIndex = 4;
			//
			//Label2
			//
			this.Label2.Font = new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Location = new System.Drawing.Point(18, 28);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(42, 14);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "Red";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//Label4
			//
			this.Label4.Font = new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.ForeColor = System.Drawing.Color.Blue;
			this.Label4.Location = new System.Drawing.Point(110, 28);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(42, 14);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Blue";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//Label3
			//
			this.Label3.Font = new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.ForeColor = System.Drawing.Color.Green;
			this.Label3.Location = new System.Drawing.Point(64, 28);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(42, 14);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Green";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//TabPage2
			//
			this.TabPage2.BackColor = System.Drawing.Color.White;
			this.TabPage2.Controls.Add(this.txbAlpha);
			this.TabPage2.Controls.Add(this.Label1);
			this.TabPage2.Controls.Add(this.tbarAlpha);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(174, 64);
			this.TabPage2.TabIndex = 3;
			this.TabPage2.Text = "Transparency";
			//
			//txbAlpha
			//
			this.txbAlpha.Location = new System.Drawing.Point(115, 12);
			this.txbAlpha.Name = "txbAlpha";
			this.txbAlpha.Size = new System.Drawing.Size(27, 20);
			this.txbAlpha.TabIndex = 13;
			this.txbAlpha.Text = "255";
			//
			//Label1
			//
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(29, 14);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(81, 17);
			this.Label1.TabIndex = 9;
			this.Label1.Text = "Alpha Value";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//tbarAlpha
			//
			this.tbarAlpha.AutoSize = false;
			this.tbarAlpha.BackColor = System.Drawing.Color.White;
			this.tbarAlpha.Location = new System.Drawing.Point(6, 35);
			this.tbarAlpha.Maximum = 255;
			this.tbarAlpha.Name = "tbarAlpha";
			this.tbarAlpha.Size = new System.Drawing.Size(164, 21);
			this.tbarAlpha.TabIndex = 12;
			this.tbarAlpha.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbarAlpha.Value = 255;
			//
			//txbCurrColor
			//
			this.txbCurrColor.Location = new System.Drawing.Point(26, 2);
			this.txbCurrColor.Name = "txbCurrColor";
			this.txbCurrColor.Size = new System.Drawing.Size(124, 20);
			this.txbCurrColor.TabIndex = 7;
			//
			//panCurrColor
			//
			this.panCurrColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panCurrColor.Location = new System.Drawing.Point(4, 2);
			this.panCurrColor.Name = "panCurrColor";
			this.panCurrColor.Size = new System.Drawing.Size(21, 21);
			this.panCurrColor.TabIndex = 7;
			//
			//butClear
			//
			this.butClear.Location = new System.Drawing.Point(195, 129);
			this.butClear.Name = "butClear";
			this.butClear.Size = new System.Drawing.Size(42, 23);
			this.butClear.TabIndex = 8;
			this.butClear.Text = "Clear";
			this.butClear.UseVisualStyleBackColor = true;
			//
			//butApply
			//
			this.butApply.Location = new System.Drawing.Point(243, 129);
			this.butApply.Name = "butApply";
			this.butApply.Size = new System.Drawing.Size(42, 23);
			this.butApply.TabIndex = 8;
			this.butApply.Text = "Apply";
			this.butApply.UseVisualStyleBackColor = true;
			//
			//DropdownColorBlender
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.butApply);
			this.Controls.Add(this.butClear);
			this.Controls.Add(this.panProps);
			this.Name = "DropdownColorBlender";
			this.Size = new System.Drawing.Size(293, 161);
			this.panProps.ResumeLayout(false);
			this.panProps.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.nudRed).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nudGreen).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nudBlue).EndInit();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.tbarAlpha).EndInit();
			this.ResumeLayout(false);

//INSTANT C# NOTE: Converted design-time event handler wireups:
			this.Load += new System.EventHandler(ColorBlender_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(ColorBlender_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(ColorBlender_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(ColorBlender_MouseUp);
			ColorBox.SelectedIndexChanged += new System.EventHandler(ColorBox_SelectedIndexChanged);
			Panel22.Click += new System.EventHandler(Panel7_Click);
			Panel7.Click += new System.EventHandler(Panel7_Click);
			Panel8.Click += new System.EventHandler(Panel7_Click);
			Panel9.Click += new System.EventHandler(Panel7_Click);
			Panel10.Click += new System.EventHandler(Panel7_Click);
			Panel11.Click += new System.EventHandler(Panel7_Click);
			Panel12.Click += new System.EventHandler(Panel7_Click);
			Panel13.Click += new System.EventHandler(Panel7_Click);
			Panel20.Click += new System.EventHandler(Panel7_Click);
			Panel19.Click += new System.EventHandler(Panel7_Click);
			Panel14.Click += new System.EventHandler(Panel7_Click);
			Panel15.Click += new System.EventHandler(Panel7_Click);
			Panel16.Click += new System.EventHandler(Panel7_Click);
			Panel17.Click += new System.EventHandler(Panel7_Click);
			Panel21.Click += new System.EventHandler(Panel7_Click);
			Panel18.Click += new System.EventHandler(Panel7_Click);
			Panel28.Click += new System.EventHandler(Panel7_Click);
			Panel27.Click += new System.EventHandler(Panel7_Click);
			Panel26.Click += new System.EventHandler(Panel7_Click);
			Panel25.Click += new System.EventHandler(Panel7_Click);
			Panel24.Click += new System.EventHandler(Panel7_Click);
			Panel23.Click += new System.EventHandler(Panel7_Click);
			Panel6.Click += new System.EventHandler(Panel7_Click);
			Panel29.Click += new System.EventHandler(Panel7_Click);
			Panel22.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel7.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel8.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel9.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel10.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel11.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel12.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel13.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel20.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel19.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel14.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel15.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel16.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel17.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel21.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel18.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel28.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel27.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel26.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel25.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel24.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel23.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel6.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			Panel29.MouseEnter += new System.EventHandler(Panel10_MouseEnter);
			TabControl1.MouseLeave += new System.EventHandler(TabControl1_MouseLeave);
			nudRed.ValueChanged += new System.EventHandler(nud_ValueChanged);
			nudGreen.ValueChanged += new System.EventHandler(nud_ValueChanged);
			nudBlue.ValueChanged += new System.EventHandler(nud_ValueChanged);
			tbarAlpha.ValueChanged += new System.EventHandler(nud_ValueChanged);
			txbAlpha.TextChanged += new System.EventHandler(txbAlpha_TextChanged);
			butApply.Click += new System.EventHandler(butApply_Click);
			butClear.Click += new System.EventHandler(butClear_Click);
		}
        /// <summary>
        /// The pan props
        /// </summary>
        internal System.Windows.Forms.Panel panProps;
        /// <summary>
        /// The label4
        /// </summary>
        internal System.Windows.Forms.Label Label4;
        /// <summary>
        /// The label3
        /// </summary>
        internal System.Windows.Forms.Label Label3;
        /// <summary>
        /// The label2
        /// </summary>
        internal System.Windows.Forms.Label Label2;
        /// <summary>
        /// The label1
        /// </summary>
        internal System.Windows.Forms.Label Label1;
        /// <summary>
        /// The nud blue
        /// </summary>
        internal System.Windows.Forms.NumericUpDown nudBlue;
        /// <summary>
        /// The TXB curr color
        /// </summary>
        internal System.Windows.Forms.TextBox txbCurrColor;
        /// <summary>
        /// The pan curr color
        /// </summary>
        internal System.Windows.Forms.Panel panCurrColor;
        /// <summary>
        /// The nud green
        /// </summary>
        internal System.Windows.Forms.NumericUpDown nudGreen;
        /// <summary>
        /// The nud red
        /// </summary>
        internal System.Windows.Forms.NumericUpDown nudRed;
        /// <summary>
        /// The panel20
        /// </summary>
        internal System.Windows.Forms.Panel Panel20;
        /// <summary>
        /// The panel22
        /// </summary>
        internal System.Windows.Forms.Panel Panel22;
        /// <summary>
        /// The color box
        /// </summary>
        internal System.Windows.Forms.ComboBox ColorBox;
        /// <summary>
        /// The panel23
        /// </summary>
        internal System.Windows.Forms.Panel Panel23;
        /// <summary>
        /// The panel24
        /// </summary>
        internal System.Windows.Forms.Panel Panel24;
        /// <summary>
        /// The panel25
        /// </summary>
        internal System.Windows.Forms.Panel Panel25;
        /// <summary>
        /// The panel26
        /// </summary>
        internal System.Windows.Forms.Panel Panel26;
        /// <summary>
        /// The panel27
        /// </summary>
        internal System.Windows.Forms.Panel Panel27;
        /// <summary>
        /// The panel28
        /// </summary>
        internal System.Windows.Forms.Panel Panel28;
        /// <summary>
        /// The panel18
        /// </summary>
        internal System.Windows.Forms.Panel Panel18;
        /// <summary>
        /// The panel21
        /// </summary>
        internal System.Windows.Forms.Panel Panel21;
        /// <summary>
        /// The panel17
        /// </summary>
        internal System.Windows.Forms.Panel Panel17;
        /// <summary>
        /// The panel16
        /// </summary>
        internal System.Windows.Forms.Panel Panel16;
        /// <summary>
        /// The panel15
        /// </summary>
        internal System.Windows.Forms.Panel Panel15;
        /// <summary>
        /// The panel14
        /// </summary>
        internal System.Windows.Forms.Panel Panel14;
        /// <summary>
        /// The panel19
        /// </summary>
        internal System.Windows.Forms.Panel Panel19;
        /// <summary>
        /// The panel13
        /// </summary>
        internal System.Windows.Forms.Panel Panel13;
        /// <summary>
        /// The panel12
        /// </summary>
        internal System.Windows.Forms.Panel Panel12;
        /// <summary>
        /// The panel11
        /// </summary>
        internal System.Windows.Forms.Panel Panel11;
        /// <summary>
        /// The panel10
        /// </summary>
        internal System.Windows.Forms.Panel Panel10;
        /// <summary>
        /// The panel9
        /// </summary>
        internal System.Windows.Forms.Panel Panel9;
        /// <summary>
        /// The panel8
        /// </summary>
        internal System.Windows.Forms.Panel Panel8;
        /// <summary>
        /// The panel29
        /// </summary>
        internal System.Windows.Forms.Panel Panel29;
        /// <summary>
        /// The panel7
        /// </summary>
        internal System.Windows.Forms.Panel Panel7;
        /// <summary>
        /// The panel6
        /// </summary>
        internal System.Windows.Forms.Panel Panel6;
        /// <summary>
        /// The tab control1
        /// </summary>
        internal System.Windows.Forms.TabControl TabControl1;
        /// <summary>
        /// The tab page1
        /// </summary>
        internal System.Windows.Forms.TabPage TabPage1;
        /// <summary>
        /// The tab page3
        /// </summary>
        internal System.Windows.Forms.TabPage TabPage3;
        /// <summary>
        /// The tbar alpha
        /// </summary>
        internal System.Windows.Forms.TrackBar tbarAlpha;
        /// <summary>
        /// The TXB alpha
        /// </summary>
        internal System.Windows.Forms.TextBox txbAlpha;
        /// <summary>
        /// The tab page2
        /// </summary>
        internal System.Windows.Forms.TabPage TabPage2;
        /// <summary>
        /// The but clear
        /// </summary>
        internal System.Windows.Forms.Button butClear;
        /// <summary>
        /// The but apply
        /// </summary>
        internal System.Windows.Forms.Button butApply;
        /// <summary>
        /// The label position
        /// </summary>
        internal System.Windows.Forms.Label lblPos;

	}

}