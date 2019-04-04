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
	[DefaultEvent("OnTextChange")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuTextbox : UserControl
	{
		private IContainer icontainer_0;

		private PictureBox _Picture;

		public TextBox _TextBox;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;
        EventHandler eventHandler_3;


        public Image Icon
		{
			get
			{
				return this._Picture.Image;
			}
			set
			{
				this._Picture.Image = value;
				this._Picture.Image = Graphics.OverlayColor(this._Picture.Image, this.ForeColor);
			}
		}

		public string text
		{
			get
			{
				return this._TextBox.Text;
			}
			set
			{
				this._TextBox.Text = value;
			}
		}

		public BunifuTextbox()
		{
			this.InitializeComponent();
			this._Picture.Top = base.Height / 2 - this._Picture.Height / 2;
			this._TextBox.Top = base.Height / 2 - this._TextBox.Height / 2;
			this._TextBox.Width = base.Width - this._TextBox.Left - 10;
			this.BackgroundImage = Graphics.OverlayColor(this.BackgroundImage, this.ForeColor);
			this._Picture.Image = Graphics.OverlayColor(this._Picture.Image, this.ForeColor);
			BunifuCustomControl.initializeComponent(this);
		}

		private void _TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_1 == null)
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
				this.eventHandler_1(this, e);
			}
		}

		private void _TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_2 == null)
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
				this.eventHandler_2(this, e);
			}
		}

		private void _TextBox_KeyUp(object sender, KeyEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_3 == null)
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
				this.eventHandler_3(this, e);
			}
		}

		private void _TextBox_TextChanged(object sender, EventArgs e)
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
				this.eventHandler_0(this, e);
			}
		}

		private void BunifuTextbox_BackColorChanged(object sender, EventArgs e)
		{
			this._TextBox.BackColor = this.BackColor;
		}

		private void BunifuTextbox_ForeColorChanged(object sender, EventArgs e)
		{
			this._TextBox.ForeColor = this.ForeColor;
			this.BackgroundImage = Graphics.OverlayColor(this.BackgroundImage, this.ForeColor);
			this._Picture.Image = Graphics.OverlayColor(this._Picture.Image, this.ForeColor);
		}

		private void BunifuTextbox_Load(object sender, EventArgs e)
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

		private void BunifuTextbox_Resize(object sender, EventArgs e)
		{
			this._Picture.Top = base.Height / 2 - this._Picture.Height / 2;
			this._TextBox.Top = base.Height / 2 - this._TextBox.Height / 2;
			this._TextBox.Width = base.Width - this._TextBox.Left - 10;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuTextbox));
			this._TextBox = new TextBox();
			this._Picture = new PictureBox();
			((ISupportInitialize)this._Picture).BeginInit();
			base.SuspendLayout();
			this._TextBox.BackColor = Color.Silver;
			this._TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
			this._TextBox.ForeColor = Color.SeaGreen;
			this._TextBox.Location = new Point(40, 13);
			this._TextBox.Multiline = true;
			this._TextBox.Name = "_TextBox";
			this._TextBox.Size = new System.Drawing.Size(195, 20);
			this._TextBox.TabIndex = 0;
			this._TextBox.Text = "Bunifu TextBox";
			this._TextBox.TextChanged += new EventHandler(this._TextBox_TextChanged);
			this._TextBox.KeyDown += new KeyEventHandler(this._TextBox_KeyDown);
			this._TextBox.KeyPress += new KeyPressEventHandler(this._TextBox_KeyPress);
			this._TextBox.KeyUp += new KeyEventHandler(this._TextBox_KeyUp);
			this._Picture.BackColor = Color.Transparent;
            this._Picture.Image = new Bitmap(2, 2); //(Image)componentResourceManager.GetObject("_Picture.Image");
			this._Picture.Location = new Point(9, 7);
			this._Picture.Name = "_Picture";
			this._Picture.Size = new System.Drawing.Size(23, 25);
			this._Picture.SizeMode = PictureBoxSizeMode.Zoom;
			this._Picture.TabIndex = 1;
			this._Picture.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Silver;
            this.BackgroundImage = new Bitmap(5, 5); //(Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.Controls.Add(this._Picture);
			base.Controls.Add(this._TextBox);
			this.DoubleBuffered = true;
			this.ForeColor = Color.SeaGreen;
			base.Name = "BunifuTextbox";
			base.Size = new System.Drawing.Size(250, 42);
			base.Load += new EventHandler(this.BunifuTextbox_Load);
			base.BackColorChanged += new EventHandler(this.BunifuTextbox_BackColorChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuTextbox_ForeColorChanged);
			base.Resize += new EventHandler(this.BunifuTextbox_Resize);
			((ISupportInitialize)this._Picture).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public event EventHandler KeyDown
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
		}

		public event EventHandler KeyPress
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
		}

		public event EventHandler KeyUp
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
		}

		public event EventHandler OnTextChange
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