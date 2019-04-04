using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuImageButton : PictureBox
	{
		private int int_0 = 10;

		private System.Drawing.Image image_0;

		private System.Drawing.Image image_1;

		private IContainer icontainer_0;

		public System.Drawing.Image ImageActive
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
			}
		}

		public int Zoom
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public BunifuImageButton()
		{
			this.method_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuImageButton));
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.BackColor = Color.SeaGreen;
            base.Image = Properties.Resources.icons8_Double_Down_32px; //(System.Drawing.Image)componentResourceManager.GetObject("$this.Image");
			base.Size = new System.Drawing.Size(71, 71);
			base.SizeMode = PictureBoxSizeMode.Zoom;
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		protected override void OnClick(EventArgs e)
		{
			if (this.image_0 != null)
			{
				base.Image = this.image_1;
			}
			Styles.ZoomOut(this);
			base.OnClick(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if (this.image_0 != null)
			{
				this.image_1 = base.Image;
				base.Image = this.image_0;
			}
			Styles.ZoomIn(this, this.int_0);
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.image_0 != null)
			{
				base.Image = this.image_1;
			}
			Styles.ZoomOut(this);
			base.OnMouseLeave(e);
		}
	}
}