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
	[DefaultEvent("OnValueChange")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuiOSSwitch : UserControl
	{
		private bool bool_0 = true;

		private Color color_0 = Color.FromArgb(71, 202, 94);

		private Color color_1 = Color.Gray;

		private Image image_0;

		private Image image_1;

		private IContainer icontainer_0;

		private PictureBox pictureBox1;

        EventHandler eventHandler_0;

		public Color OffColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				if (this.BackgroundImage != null)
				{
					this.image_1 = Graphics.OverlayColor(this.BackgroundImage, this.OffColor);
				}
				this.method_0();
			}
		}

		public Color OnColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				if (this.BackgroundImage != null)
				{
					this.image_0 = Graphics.OverlayColor(this.BackgroundImage, this.OnColor);
				}
				this.method_0();
			}
		}

		public bool Value
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.method_0();
			}
		}

		public BunifuiOSSwitch()
		{
			this.InitializeComponent();
			this.image_0 = Graphics.OverlayColor(this.BackgroundImage, this.OnColor);
			this.image_1 = Graphics.OverlayColor(this.BackgroundImage, this.OffColor);
		}

		private void BunifuiOSSwitch_Click(object sender, EventArgs e)
		{
			this.Value = !this.bool_0;
		}

		private void BunifuiOSSwitch_Load(object sender, EventArgs e)
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

		private void BunifuiOSSwitch_Resize(object sender, EventArgs e)
		{
			base.Size = new System.Drawing.Size(35, 20);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuiOSSwitch));
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = Properties.Resources.SwitchHandle; //(Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(14, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(21, 20);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
            this.BackgroundImage = Properties.Resources.SwitchBackground; //(Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.Controls.Add(this.pictureBox1);
			this.Cursor = Cursors.Hand;
			this.DoubleBuffered = true;
			base.Name = "BunifuiOSSwitch";
			base.Size = new System.Drawing.Size(35, 20);
			base.Load += new EventHandler(this.BunifuiOSSwitch_Load);
			base.Click += new EventHandler(this.BunifuiOSSwitch_Click);
			base.Resize += new EventHandler(this.BunifuiOSSwitch_Resize);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		private void method_0()
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (!this.Value)
			{
				this.BackgroundImage = this.image_1;
				this.pictureBox1.Left = 0;
			}
			else
			{
				this.BackgroundImage = this.image_0;
				this.pictureBox1.Left = base.Width - this.pictureBox1.Width;
			}
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
				this.eventHandler_0(this, new EventArgs());
			}
		}

		public event EventHandler OnValueChange
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