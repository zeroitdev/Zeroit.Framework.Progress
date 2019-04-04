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
    [DefaultEvent("OnChange")]
    [ProvideProperty("BunifuFramework", typeof(Control))]
    public class BunifuCheckbox : UserControl
    {
        private bool bool_0 = true;

        private Color color_0 = Color.FromArgb(51, 205, 117);

        private Color color_1 = Color.FromArgb(132, 135, 140);

        private IContainer icontainer_0;

        private PictureBox check;

        EventHandler eventHandler_0;


        public Color ChechedOffColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        public bool Checked
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                this.check.Visible = this.bool_0;
                if (this.bool_0)
                {
                    this.BackColor = this.color_0;
                    return;
                }
                this.BackColor = this.color_1;
            }
        }

        public Color CheckedOnColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                this.BackColor = this.color_0;
            }
        }

        public BunifuCheckbox()
        {
            this.InitializeComponent();
            Elipse.Apply(this, 5);
        }

        private void BunifuCheckbox_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.check.Visible = !this.check.Visible;
            this.Checked = this.check.Visible;
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

        private void BunifuCheckbox_ForeColorChanged(object sender, EventArgs e)
        {
            this.check.Image = Graphics.OverlayColor(this.check.Image, this.ForeColor);
        }

        private void BunifuCheckbox_Load(object sender, EventArgs e)
        {
            if (!this.bool_0)
            {
                this.BackColor = this.color_1;
            }
            else
            {
                this.BackColor = this.color_0;
            }
            BunifuCustomControl.initializeComponent(this);
        }

        private void BunifuCheckbox_Resize(object sender, EventArgs e)
        {
            base.Size = new System.Drawing.Size(20, 20);
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuCheckbox));
            this.check = new PictureBox();
            ((ISupportInitialize)this.check).BeginInit();
            base.SuspendLayout();
            this.check.BackColor = Color.Transparent;
            this.check.Dock = DockStyle.Fill;
            this.check.Image = Properties.Resources.check_Image;/*(Image)componentResourceManager.GetObject("check.Image")*/
            this.check.Location = new Point(0, 0);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(20, 20);
            this.check.SizeMode = PictureBoxSizeMode.StretchImage;
            this.check.TabIndex = 0;
            this.check.TabStop = false;
            this.check.Click += new EventHandler(this.BunifuCheckbox_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.SeaGreen;
            base.Controls.Add(this.check);
            this.ForeColor = Color.White;
            base.Name = "BunifuCheckbox";
            base.Size = new System.Drawing.Size(20, 20);
            base.Load += new EventHandler(this.BunifuCheckbox_Load);
            base.ForeColorChanged += new EventHandler(this.BunifuCheckbox_ForeColorChanged);
            base.Click += new EventHandler(this.BunifuCheckbox_Click);
            base.Resize += new EventHandler(this.BunifuCheckbox_Resize);
            ((ISupportInitialize)this.check).EndInit();
            base.ResumeLayout(false);
        }

        public event EventHandler OnChange
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
