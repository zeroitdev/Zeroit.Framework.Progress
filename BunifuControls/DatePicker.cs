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
    public class BunifuDatepicker : UserControl
    {
        private DateTime dateTime_0;

        private int int_0;

        private IContainer icontainer_0;

        public BunifuFlatButton Style;

        private DateTimePicker datp;

        EventHandler eventHandler_0;


        public int BorderRadius
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                Elipse.Apply(this, this.int_0);
            }
        }

        public DateTimePickerFormat Format
        {
            get
            {
                return this.datp.Format;
            }
            set
            {
                this.datp.Format = value;
                this.Style.ButtonText = this.datp.Text;
                this.dateTime_0 = this.datp.Value;
            }
        }

        public string FormatCustom
        {
            get
            {
                return this.datp.CustomFormat;
            }
            set
            {
                this.datp.CustomFormat = value;
                this.Style.ButtonText = this.datp.Text;
                this.dateTime_0 = this.datp.Value;
            }
        }

        public DateTime Value
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
                this.datp.Value = this.dateTime_0;
                this.Style.ButtonText = this.datp.Text;
            }
        }

        public BunifuDatepicker()
        {
            this.InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.datp.Visible = true;
            }
            else
            {
                this.datp.Visible = false;
            }
            this.Style.Text = this.datp.Value.ToLongDateString();
            this.OnResize(null);
            this.dateTime_0 = this.datp.Value;
            this.Style.ButtonText = this.datp.Text;
            this.dateTime_0 = this.datp.Value;
            BunifuCustomControl.initializeComponent(this);
        }

        private void BunifuDatepicker_BackColorChanged(object sender, EventArgs e)
        {
            this.Style.Activecolor = this.BackColor;
            this.Style.Normalcolor = this.BackColor;
            int r = this.BackColor.R;
            r = (r + 10 <= 255 ? r + 10 : 255);
            int g = this.BackColor.G;
            g = (g + 10 <= 255 ? g + 10 : 255);
            int b = this.BackColor.B;
            b = (b + 10 <= 255 ? b + 10 : 255);
            this.Style.OnHovercolor = Color.FromArgb(r, g, b);
        }

        private void BunifuDatepicker_FontChanged(object sender, EventArgs e)
        {
            this.Style.Font = this.Font;
        }

        private void BunifuDatepicker_ForeColorChanged(object sender, EventArgs e)
        {
            this.Style.Textcolor = this.ForeColor;
            this.Style.OnHoverTextColor = this.ForeColor;
            this.Style.Iconimage_right = Graphics.OverlayColor(this.Style.Iconimage_right, this.ForeColor);
            this.Style.Iconimage = Graphics.OverlayColor(this.Style.Iconimage, this.ForeColor);
        }

        private void BunifuDatepicker_Load(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Style.Text = this.datp.Text;
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

        private void BunifuDatepicker_Resize(object sender, EventArgs e)
        {
            this.datp.Width = base.Width - this.datp.Left - 50;
            this.datp.Left = 0;
            this.datp.Top = this.Style.Top + this.Style.Height - this.datp.Height;
            Elipse.Apply(this, this.int_0);
        }

        private void datp_ValueChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Style.ButtonText = this.datp.Text;
            this.dateTime_0 = this.datp.Value;
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuDatepicker));
            this.datp = new DateTimePicker();
            this.Style = new BunifuFlatButton();
            base.SuspendLayout();
            this.datp.Location = new Point(3, 13);
            this.datp.Name = "datp";
            this.datp.Size = new System.Drawing.Size(241, 20);
            this.datp.TabIndex = 3;
            this.datp.ValueChanged += new EventHandler(this.datp_ValueChanged);
            this.Style.Activecolor = Color.FromArgb(46, 139, 87);
            this.Style.BackColor = Color.FromArgb(46, 139, 87);
            this.Style.BackgroundImageLayout = ImageLayout.Stretch;
            this.Style.BorderRadius = 0;
            this.Style.ButtonText = "BunifuCalendar";
            this.Style.Cursor = Cursors.Hand;
            this.Style.DisabledColor = Color.Gray;
            this.Style.Dock = DockStyle.Fill;
            this.Style.Iconcolor = Color.Transparent;
            //this.Style.Iconimage = (Image)componentResourceManager.GetObject("Style.Iconimage");
            this.Style.Iconimage_right = Properties.Resources.icons8_Double_Right_32px; //(Image)componentResourceManager.GetObject("Style.Iconimage_right");
            this.Style.Iconimage_right_Selected = null;
            this.Style.Iconimage_Selected = null;
            this.Style.IconRightVisible = true;
            this.Style.IconRightZoom = 0;
            this.Style.IconVisible = true;
            this.Style.IconZoom = 100;
            this.Style.IsTab = false;
            this.Style.Location = new Point(0, 0);
            this.Style.Name = "Style";
            this.Style.Normalcolor = Color.FromArgb(46, 139, 87);
            this.Style.OnHovercolor = Color.FromArgb(36, 129, 77);
            this.Style.OnHoverTextColor = Color.White;
            this.Style.selected = false;
            this.Style.Size = new System.Drawing.Size(303, 36);
            this.Style.TabIndex = 2;
            this.Style.Text = "BunifuCalendar";
            this.Style.TextAlign = ContentAlignment.MiddleLeft;
            this.Style.Textcolor = Color.White;
            this.Style.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Style.Click += new EventHandler(this.Style_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.SeaGreen;
            base.Controls.Add(this.Style);
            base.Controls.Add(this.datp);
            this.ForeColor = Color.White;
            base.Name = "BunifuDatepicker";
            base.Size = new System.Drawing.Size(303, 36);
            base.Load += new EventHandler(this.BunifuDatepicker_Load);
            base.BackColorChanged += new EventHandler(this.BunifuDatepicker_BackColorChanged);
            base.FontChanged += new EventHandler(this.BunifuDatepicker_FontChanged);
            base.ForeColorChanged += new EventHandler(this.BunifuDatepicker_ForeColorChanged);
            base.Resize += new EventHandler(this.BunifuDatepicker_Resize);
            base.ResumeLayout(false);
        }

        private void Style_Click(object sender, EventArgs e)
        {
            this.datp.Select();
            SendKeys.Send("%{DOWN}");
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
