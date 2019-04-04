using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("onValueChanged")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuRating : UserControl
	{
		private int int_0;

		private IContainer icontainer_0;

		private PictureBox star1;

		private PictureBox star2;

		private PictureBox star3;

		private PictureBox star4;

		private PictureBox star5;

		private PictureBox off;

		private PictureBox on;

		private PictureBox offOrig;

		private PictureBox onOrig;

        EventHandler eventHandler_0;

        public int Value
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value < 0 && value > 5)
				{
					throw new Exception("Invalid Value ( >=0 || <=5)");
				}
				this.int_0 = value;
				this.method_0();
				this.method_1();
			}
		}

		public BunifuRating()
		{
			this.InitializeComponent();
			this.OnForeColorChanged(null);
			LicenseUsageMode usageMode = LicenseManager.UsageMode;
			BunifuCustomControl.initializeComponent(this);
		}

		private void BunifuRating_ForeColorChanged(object sender, EventArgs e)
		{
			this.on.Image = this.onOrig.Image;
			this.off.Image = this.offOrig.Image;
			this.on.Image = Graphics.OverlayColor(this.on.Image, this.ForeColor);
			this.off.Image = Graphics.OverlayColor(this.off.Image, this.ForeColor);
			if (this.star1.Tag.ToString() != "on")
			{
				this.star1.Image = this.off.Image;
			}
			else
			{
				this.star1.Image = this.on.Image;
			}
			if (this.star2.Tag.ToString() != "on")
			{
				this.star2.Image = this.off.Image;
			}
			else
			{
				this.star2.Image = this.on.Image;
			}
			if (this.star3.Tag.ToString() != "on")
			{
				this.star3.Image = this.off.Image;
			}
			else
			{
				this.star3.Image = this.on.Image;
			}
			if (this.star4.Tag.ToString() != "on")
			{
				this.star4.Image = this.off.Image;
			}
			else
			{
				this.star4.Image = this.on.Image;
			}
			if (this.star5.Tag.ToString() == "on")
			{
				this.star5.Image = this.on.Image;
				return;
			}
			this.star5.Image = this.off.Image;
		}

		private void BunifuRating_Load(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (!base.DesignMode)
			{
				do
				{
					if (num != num1)
					{
						break;
					}
					num1 = 1;
					num2 = num;
					num = 1;
				}
				while (1 <= num2);
			}
			else
			{
				BunifuCustomControl.initializeComponent(this);
			}
		}

		private void BunifuRating_Resize(object sender, EventArgs e)
		{
			PictureBox pictureBox = this.star1;
			PictureBox pictureBox1 = this.star2;
			PictureBox pictureBox2 = this.star3;
			PictureBox pictureBox3 = this.star4;
			PictureBox pictureBox4 = this.star5;
			int height = base.Height;
			int num = height;
			pictureBox4.Height = height;
			int num1 = num;
			int num2 = num1;
			pictureBox3.Height = num1;
			int num3 = num2;
			int num4 = num3;
			pictureBox2.Height = num3;
			int num5 = num4;
			int num6 = num5;
			pictureBox1.Height = num5;
			pictureBox.Height = num6;
			PictureBox pictureBox5 = this.star1;
			PictureBox pictureBox6 = this.star2;
			PictureBox pictureBox7 = this.star3;
			PictureBox pictureBox8 = this.star4;
			PictureBox pictureBox9 = this.star5;
			int height1 = base.Height;
			num = height1;
			pictureBox9.Width = height1;
			int num7 = num;
			num2 = num7;
			pictureBox8.Width = num7;
			int num8 = num2;
			num4 = num8;
			pictureBox7.Width = num8;
			int num9 = num4;
			num6 = num9;
			pictureBox6.Width = num9;
			pictureBox5.Width = num6;
			int width = (base.Width - base.Height * 5) / 4;
			this.star2.Left = this.star1.Right + width;
			this.star3.Left = this.star2.Right + width;
			this.star4.Left = this.star3.Right + width;
			this.star5.Left = this.star4.Right + width;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuRating));
			this.star1 = new PictureBox();
			this.star2 = new PictureBox();
			this.star3 = new PictureBox();
			this.star4 = new PictureBox();
			this.star5 = new PictureBox();
			this.off = new PictureBox();
			this.on = new PictureBox();
			this.offOrig = new PictureBox();
			this.onOrig = new PictureBox();
			((ISupportInitialize)this.star1).BeginInit();
			((ISupportInitialize)this.star2).BeginInit();
			((ISupportInitialize)this.star3).BeginInit();
			((ISupportInitialize)this.star4).BeginInit();
			((ISupportInitialize)this.star5).BeginInit();
			((ISupportInitialize)this.off).BeginInit();
			((ISupportInitialize)this.on).BeginInit();
			((ISupportInitialize)this.offOrig).BeginInit();
			((ISupportInitialize)this.onOrig).BeginInit();
			base.SuspendLayout();
			this.star1.BackColor = Color.Transparent;
			this.star1.Cursor = Cursors.Hand;
			this.star1.Image = (Image)componentResourceManager.GetObject("star1.Image");
			this.star1.Location = new Point(0, 1);
			this.star1.Name = "star1";
			this.star1.Size = new System.Drawing.Size(50, 46);
			this.star1.SizeMode = PictureBoxSizeMode.Zoom;
			this.star1.TabIndex = 0;
			this.star1.TabStop = false;
			this.star1.Tag = "1";
			this.star1.Click += new EventHandler(this.star5_Click);
			this.star2.BackColor = Color.Transparent;
			this.star2.Cursor = Cursors.Hand;
			this.star2.Image = (Image)componentResourceManager.GetObject("star2.Image");
			this.star2.Location = new Point(66, 1);
			this.star2.Name = "star2";
			this.star2.Size = new System.Drawing.Size(50, 46);
			this.star2.SizeMode = PictureBoxSizeMode.Zoom;
			this.star2.TabIndex = 1;
			this.star2.TabStop = false;
			this.star2.Tag = "2";
			this.star2.Click += new EventHandler(this.star5_Click);
			this.star3.BackColor = Color.Transparent;
			this.star3.Cursor = Cursors.Hand;
			this.star3.Image = (Image)componentResourceManager.GetObject("star3.Image");
			this.star3.Location = new Point(132, 1);
			this.star3.Name = "star3";
			this.star3.Size = new System.Drawing.Size(50, 46);
			this.star3.SizeMode = PictureBoxSizeMode.Zoom;
			this.star3.TabIndex = 2;
			this.star3.TabStop = false;
			this.star3.Tag = "3";
			this.star3.Click += new EventHandler(this.star5_Click);
			this.star4.BackColor = Color.Transparent;
			this.star4.Cursor = Cursors.Hand;
			this.star4.Image = (Image)componentResourceManager.GetObject("star4.Image");
			this.star4.Location = new Point(198, 1);
			this.star4.Name = "star4";
			this.star4.Size = new System.Drawing.Size(50, 46);
			this.star4.SizeMode = PictureBoxSizeMode.Zoom;
			this.star4.TabIndex = 3;
			this.star4.TabStop = false;
			this.star4.Tag = "4";
			this.star4.Click += new EventHandler(this.star5_Click);
			this.star5.BackColor = Color.Transparent;
			this.star5.Cursor = Cursors.Hand;
			this.star5.Image = (Image)componentResourceManager.GetObject("star5.Image");
			this.star5.Location = new Point(264, 1);
			this.star5.Name = "star5";
			this.star5.Size = new System.Drawing.Size(50, 46);
			this.star5.SizeMode = PictureBoxSizeMode.Zoom;
			this.star5.TabIndex = 4;
			this.star5.TabStop = false;
			this.star5.Tag = "5";
			this.star5.Click += new EventHandler(this.star5_Click);
			this.off.Cursor = Cursors.Hand;
			this.off.Image = (Image)componentResourceManager.GetObject("off.Image");
			this.off.Location = new Point(44, 46);
			this.off.Name = "off";
			this.off.Size = new System.Drawing.Size(82, 36);
			this.off.SizeMode = PictureBoxSizeMode.Zoom;
			this.off.TabIndex = 6;
			this.off.TabStop = false;
			this.off.Tag = "false";
			this.off.Visible = false;
			this.on.Cursor = Cursors.Hand;
			this.on.Image = (Image)componentResourceManager.GetObject("on.Image");
			this.on.Location = new Point(-22, 46);
			this.on.Name = "on";
			this.on.Size = new System.Drawing.Size(82, 36);
			this.on.SizeMode = PictureBoxSizeMode.Zoom;
			this.on.TabIndex = 5;
			this.on.TabStop = false;
			this.on.Tag = "false";
			this.on.Visible = false;
			this.offOrig.Cursor = Cursors.Hand;
			this.offOrig.Image = (Image)componentResourceManager.GetObject("offOrig.Image");
			this.offOrig.Location = new Point(122, 51);
			this.offOrig.Name = "offOrig";
			this.offOrig.Size = new System.Drawing.Size(82, 36);
			this.offOrig.SizeMode = PictureBoxSizeMode.Zoom;
			this.offOrig.TabIndex = 8;
			this.offOrig.TabStop = false;
			this.offOrig.Tag = "false";
			this.offOrig.Visible = false;
			this.onOrig.Cursor = Cursors.Hand;
			this.onOrig.Image = (Image)componentResourceManager.GetObject("onOrig.Image");
			this.onOrig.Location = new Point(44, 58);
			this.onOrig.Name = "onOrig";
			this.onOrig.Size = new System.Drawing.Size(82, 36);
			this.onOrig.SizeMode = PictureBoxSizeMode.Zoom;
			this.onOrig.TabIndex = 7;
			this.onOrig.TabStop = false;
			this.onOrig.Tag = "false";
			this.onOrig.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.offOrig);
			base.Controls.Add(this.onOrig);
			base.Controls.Add(this.off);
			base.Controls.Add(this.on);
			base.Controls.Add(this.star5);
			base.Controls.Add(this.star4);
			base.Controls.Add(this.star3);
			base.Controls.Add(this.star2);
			base.Controls.Add(this.star1);
			this.ForeColor = Color.SeaGreen;
			base.Name = "BunifuRating";
			base.Size = new System.Drawing.Size(316, 50);
			base.Load += new EventHandler(this.BunifuRating_Load);
			base.ForeColorChanged += new EventHandler(this.BunifuRating_ForeColorChanged);
			base.Resize += new EventHandler(this.BunifuRating_Resize);
			((ISupportInitialize)this.star1).EndInit();
			((ISupportInitialize)this.star2).EndInit();
			((ISupportInitialize)this.star3).EndInit();
			((ISupportInitialize)this.star4).EndInit();
			((ISupportInitialize)this.star5).EndInit();
			((ISupportInitialize)this.off).EndInit();
			((ISupportInitialize)this.on).EndInit();
			((ISupportInitialize)this.offOrig).EndInit();
			((ISupportInitialize)this.onOrig).EndInit();
			base.ResumeLayout(false);
		}

		private void method_0()
		{
			switch (this.int_0)
			{
				case 0:
				{
					this.star1.Image = this.off.Image;
					this.star2.Image = this.off.Image;
					this.star3.Image = this.off.Image;
					this.star4.Image = this.off.Image;
					this.star5.Image = this.off.Image;
					return;
				}
				case 1:
				{
					this.star1.Image = this.on.Image;
					this.star2.Image = this.off.Image;
					this.star3.Image = this.off.Image;
					this.star4.Image = this.off.Image;
					this.star5.Image = this.off.Image;
					return;
				}
				case 2:
				{
					this.star1.Image = this.on.Image;
					this.star2.Image = this.on.Image;
					this.star3.Image = this.off.Image;
					this.star4.Image = this.off.Image;
					this.star5.Image = this.off.Image;
					return;
				}
				case 3:
				{
					this.star1.Image = this.on.Image;
					this.star2.Image = this.on.Image;
					this.star3.Image = this.on.Image;
					this.star4.Image = this.off.Image;
					this.star5.Image = this.off.Image;
					return;
				}
				case 4:
				{
					this.star1.Image = this.on.Image;
					this.star2.Image = this.on.Image;
					this.star3.Image = this.on.Image;
					this.star4.Image = this.on.Image;
					this.star5.Image = this.off.Image;
					return;
				}
				case 5:
				{
					this.star1.Image = this.on.Image;
					this.star2.Image = this.on.Image;
					this.star3.Image = this.on.Image;
					this.star4.Image = this.on.Image;
					this.star5.Image = this.on.Image;
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void method_1()
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_0 == null)
			{
				do
				{
					if (num != num1)
					{
						break;
					}
					num1 = 1;
					num2 = num;
					num = 1;
				}
				while (1 <= num2);
			}
			else
			{
				this.eventHandler_0(this, null);
			}
		}

		private void star5_Click(object sender, EventArgs e)
		{
			int num = int.Parse(((PictureBox)sender).Tag.ToString());
			if (((PictureBox)sender).Image != this.on.Image)
			{
				this.int_0 = num;
				this.method_0();
				this.method_1();
				return;
			}
			this.int_0 = num - 1;
			this.method_0();
			this.method_1();
		}

		public event EventHandler onValueChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
		}
	}
}