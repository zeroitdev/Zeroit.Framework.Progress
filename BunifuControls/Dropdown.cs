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
    [DefaultEvent("onItemSelected")]
    [ProvideProperty("BunifuFramework", typeof(Control))]
    public class BunifuDropdown : UserControl
    {
        public int _BorderRadius = 3;

        private string[] string_0 = new string[0];

        private bool bool_0 = true;

        private IContainer icontainer_0;

        public BunifuFlatButton Style;

        private ComboBox Collections;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;

        public int BorderRadius
        {
            get
            {
                return this._BorderRadius;
            }
            set
            {
                this._BorderRadius = value;
                this.Style.BorderRadius = this._BorderRadius;
            }
        }

        public new Color DisabledColor
        {
            get
            {
                return this.Style.DisabledColor;
            }
            set
            {
                this.Style.DisabledColor = value;
            }
        }

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new bool Enabled
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.Style.Enabled = value;
            }
        }

        public string[] Items
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                this.Collections.Items.Clear();
                for (int i = 0; i < (int)this.string_0.Length; i++)
                {
                    this.Collections.Items.Add(this.string_0[i]);
                }
            }
        }

        public Color NomalColor
        {
            get
            {
                return this.Style.Normalcolor;
            }
            set
            {
                this.Style.Normalcolor = value;
                this.Style.Activecolor = value;
            }
        }

        public Color onHoverColor
        {
            get
            {
                return this.Style.OnHovercolor;
            }
            set
            {
                this.Style.OnHovercolor = value;
            }
        }

        public int selectedIndex
        {
            get
            {
                return this.Collections.SelectedIndex;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                if (this.Collections.Items.Count > value && value >= 0)
                {
                    this.Collections.SelectedIndex = value;
                    this.Style.ButtonText = string.Concat("    ", this.Collections.Items[value].ToString());
                    return;
                }
                if (value != -1)
                {
                    throw new Exception("Out of index");
                }
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
        }

        public string selectedValue
        {
            get
            {
                return this.Collections.Items[this.selectedIndex].ToString().Trim();
            }
        }

        public BunifuDropdown()
        {
            this.InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Collections.Visible = true;
            }
            else
            {
                this.Collections.Visible = false;
            }
            if (this.Collections.Items.Count > 0)
            {
                this.Collections.SelectedIndex = 0;
            }
            this.Style.ButtonText = this.Collections.Text;
            this.OnResize(null);
            BunifuCustomControl.initializeComponent(this);
        }

        public void AddItem(string Item)
        {
            this.Collections.Items.Add(Item);
        }

        private void BunifuDropdown_FontChanged(object sender, EventArgs e)
        {
            this.Style.Font = this.Font;
        }

        private void BunifuDropdown_ForeColorChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Style.Textcolor = this.ForeColor;
            this.Style.OnHoverTextColor = this.ForeColor;
            if (this.Style.Iconimage_right != null)
            {
                this.Style.Iconimage_right = Graphics.OverlayColor(this.Style.Iconimage_right, this.ForeColor);
            }
            if (this.Style.Iconimage == null)
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
                this.Style.Iconimage = Graphics.OverlayColor(this.Style.Iconimage, this.ForeColor);
            }
        }

        private void BunifuDropdown_Load(object sender, EventArgs e)
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

        private void BunifuDropdown_Resize(object sender, EventArgs e)
        {
        }

        public void Clear()
        {
            this.Collections.Items.Clear();
            this.string_0 = new string[0];
            this.Style.Text = "";
        }

        private void Collections_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Style.ButtonText = string.Concat("   ", this.Collections.Text);
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

        private void Collections_SelectionChangeCommitted(object sender, EventArgs e)
        {
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuDropdown));
            this.Collections = new ComboBox();
            this.Style = new BunifuFlatButton();
            base.SuspendLayout();
            this.Collections.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Collections.FormattingEnabled = true;
            this.Collections.Location = new Point(7, 12);
            this.Collections.Name = "Collections";
            this.Collections.Size = new System.Drawing.Size(201, 21);
            this.Collections.TabIndex = 1;
            this.Collections.SelectedIndexChanged += new EventHandler(this.Collections_SelectedIndexChanged);
            this.Collections.SelectionChangeCommitted += new EventHandler(this.Collections_SelectionChangeCommitted);
            this.Style.Activecolor = Color.FromArgb(46, 139, 87);
            this.Style.BackColor = Color.FromArgb(46, 139, 87);
            this.Style.BackgroundImageLayout = ImageLayout.Stretch;
            this.Style.BorderRadius = 0;
            this.Style.ButtonText = "     DropDown";
            this.Style.Cursor = Cursors.Hand;
            this.Style.DisabledColor = Color.Gray;
            this.Style.Dock = DockStyle.Fill;
            this.Style.Iconcolor = Color.Transparent;
            this.Style.Iconimage = null;
            this.Style.Iconimage_right = Properties.Resources.icons8_Double_Right_32px; //(Image)componentResourceManager.GetObject("Style.Iconimage_right");
            this.Style.Iconimage_right_Selected = null;
            this.Style.Iconimage_Selected = null;
            this.Style.IconMarginLeft = 0;
            this.Style.IconMarginRight = 0;
            this.Style.IconRightVisible = true;
            this.Style.IconRightZoom = 0;
            this.Style.IconVisible = true;
            this.Style.IconZoom = 90;
            this.Style.IsTab = false;
            this.Style.Location = new Point(0, 0);
            this.Style.Name = "Style";
            this.Style.Normalcolor = Color.FromArgb(46, 139, 87);
            this.Style.OnHovercolor = Color.FromArgb(36, 129, 77);
            this.Style.OnHoverTextColor = Color.White;
            this.Style.selected = false;
            this.Style.Size = new System.Drawing.Size(217, 35);
            this.Style.TabIndex = 2;
            this.Style.Text = "     DropDown";
            this.Style.TextAlign = ContentAlignment.MiddleLeft;
            this.Style.Textcolor = Color.White;
            this.Style.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Style.Click += new EventHandler(this.Style_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.Style);
            base.Controls.Add(this.Collections);
            this.ForeColor = Color.White;
            base.Name = "BunifuDropdown";
            base.Size = new System.Drawing.Size(217, 35);
            base.Load += new EventHandler(this.BunifuDropdown_Load);
            base.FontChanged += new EventHandler(this.BunifuDropdown_FontChanged);
            base.ForeColorChanged += new EventHandler(this.BunifuDropdown_ForeColorChanged);
            base.Resize += new EventHandler(this.BunifuDropdown_Resize);
            base.ResumeLayout(false);
        }

        public void RemoveAt(int index)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Collections.Items.RemoveAt(index);
            if (this.selectedIndex == index)
            {
                this.Style.Text = "";
            }
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
                this.eventHandler_2(this, null);
            }
        }

        public void RemoveItem(string Item)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.Collections.Items.Remove(Item);
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
                this.eventHandler_2(this, null);
            }
        }

        private void Style_Click(object sender, EventArgs e)
        {
            this.Collections.Select();
            SendKeys.Send("%{DOWN}");
        }

        public event EventHandler onItemAdded
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

        public event EventHandler onItemRemoved
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

        public event EventHandler onItemSelected
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
