using System;
using System.Collections;
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
    [DefaultEvent("Click")]
    [ProvideProperty("BunifuFramework", typeof(Control))]
    public class BunifuFlatButton : UserControl
    {
        private Image image_0;

        public Color colbackground = Color.FromArgb(46, 139, 87);

        public Color colhover = Color.FromArgb(36, 129, 77);

        public Color colselected = Color.FromArgb(46, 139, 87);

        private bool bool_0;

        private int int_0;

        private bool bool_1 = true;

        private Color color_0 = Color.Gray;

        private Color color_1 = Color.Transparent;

        private int int_1;

        private int int_2;

        private double double_0 = 90;

        private double double_1;

        private Color color_2 = Color.White;

        private Color color_3 = Color.White;

        private bool bool_2;

        private Image image_1;

        private Image image_2;

        private IContainer icontainer_0;

        private ImageList imageList_0;

        public PictureBox limage;

        public PictureBox rimage;

        private BunifuCustomLabel txttext;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;

        public Color Activecolor
        {
            get
            {
                return this.colselected;
            }
            set
            {
                this.colselected = value;
            }
        }

        public int BorderRadius
        {
            get
            {
                return this.int_0;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                if (value >= 8)
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
                    this.int_0 = value;
                    Elipse.Apply(this, this.int_0);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ButtonText
        {
            get
            {
                return this.txttext.Text;
            }
            set
            {
                this.txttext.Text = value;
            }
        }

        public new Color DisabledColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
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
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
                if (value)
                {
                    this.BackColor = this.Normalcolor;
                    return;
                }
                this.BackColor = this.color_0;
            }
        }

        public Color Iconcolor
        {
            get
            {
                return this.limage.BackColor;
            }
            set
            {
                this.color_1 = value;
                this.limage.BackColor = value;
            }
        }

        public Image Iconimage
        {
            get
            {
                return this.limage.Image;
            }
            set
            {
                this.limage.Image = value;
                this.image_1 = value;
                this.OnResize(new EventArgs());
            }
        }

        public Image Iconimage_right
        {
            get
            {
                return this.rimage.Image;
            }
            set
            {
                this.rimage.Image = value;
                this.image_2 = value;
                this.OnResize(new EventArgs());
            }
        }

        public Image Iconimage_right_Selected
        {
            get
            {
                return (Image)this.rimage.Tag;
            }
            set
            {
                this.rimage.Tag = value;
                this.OnResize(new EventArgs());
            }
        }

        public Image Iconimage_Selected
        {
            get
            {
                return (Image)this.limage.Tag;
            }
            set
            {
                this.limage.Tag = value;
                this.OnResize(new EventArgs());
            }
        }

        public int IconMarginLeft
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
                this.BunifuFlatButton_Resize(this, new EventArgs());
            }
        }

        public int IconMarginRight
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
                this.BunifuFlatButton_Resize(this, new EventArgs());
            }
        }

        public bool IconRightVisible
        {
            get
            {
                return this.rimage.Visible;
            }
            set
            {
                this.rimage.Visible = value;
                this.method_0();
            }
        }

        public double IconRightZoom
        {
            get
            {
                return this.double_1;
            }
            set
            {
                this.double_1 = value;
                this.method_2();
            }
        }

        public bool IconVisible
        {
            get
            {
                return this.limage.Visible;
            }
            set
            {
                this.limage.Visible = value;
                this.method_0();
            }
        }

        public double IconZoom
        {
            get
            {
                return this.double_0;
            }
            set
            {
                this.double_0 = value;
                this.method_1();
            }
        }

        public bool IsTab
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public Color Normalcolor
        {
            get
            {
                return this.colbackground;
            }
            set
            {
                this.BackColor = value;
                this.colbackground = value;
            }
        }

        public Color OnHovercolor
        {
            get
            {
                return this.colhover;
            }
            set
            {
                this.colhover = value;
            }
        }

        public Color OnHoverTextColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        public bool selected
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                this.bool_2 = value;
                if (!this.bool_2)
                {
                    this.BackColor = this.colbackground;
                    if (this.Iconimage_Selected != null)
                    {
                        this.limage.Image = this.image_1;
                    }
                    if (this.Iconimage_right_Selected == null)
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
                        return;
                    }
                    this.rimage.Image = this.image_2;
                    return;
                }
                else
                {
                    this.BackColor = this.colselected;
                    if (this.Iconimage_Selected != null)
                    {
                        this.limage.Image = this.Iconimage_Selected;
                    }
                    if (this.Iconimage_right_Selected != null)
                    {
                        this.rimage.Image = this.Iconimage_right_Selected;
                        return;
                    }
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

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return this.ButtonText;
            }
            set
            {
                this.ButtonText = value;
            }
        }

        public ContentAlignment TextAlign
        {
            get
            {
                return this.txttext.TextAlign;
            }
            set
            {
                this.txttext.TextAlign = value;
            }
        }

        public Color Textcolor
        {
            get
            {
                return this.txttext.ForeColor;
            }
            set
            {
                this.color_3 = value;
                this.txttext.ForeColor = value;
            }
        }

        public System.Drawing.Font TextFont
        {
            get
            {
                return this.txttext.Font;
            }
            set
            {
                this.txttext.Font = value;
                this.method_0();
            }
        }

        public BunifuFlatButton()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            this.InitializeComponent();
            if (!this.selected)
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
                this.selected = true;
            }
        }

        private void BunifuFlatButton_DoubleClick(object sender, EventArgs e)
        {
        }

        private void BunifuFlatButton_Load(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            BunifuCustomControl.initializeComponent(this);
            if (!this.bool_1)
            {
                this.BackColor = this.DisabledColor;
            }
            else
            {
                this.BackColor = this.Normalcolor;
            }
            if (!this.IsTab || !this.selected)
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
                this.selected = true;
            }
        }

        private void BunifuFlatButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.bool_1)
            {
                return;
            }
            this.bool_2 = true;
            this.BackColor = this.colselected;
            this.method_5();
        }

        private void BunifuFlatButton_MouseEnter(object sender, EventArgs e)
        {
            if (!this.bool_1)
            {
                this.BackColor = this.DisabledColor;
                return;
            }
            this.txttext.ForeColor = this.color_2;
            this.limage.BackColor = Color.Transparent;
            this.BackColor = this.colhover;
        }

        private void BunifuFlatButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.bool_1)
            {
                this.BackColor = this.DisabledColor;
                return;
            }
            if (!this.bool_0)
            {
                this.BackColor = this.colbackground;
            }
            else if (!this.bool_2)
            {
                this.BackColor = this.colbackground;
                if (this.Iconimage_Selected != null)
                {
                    this.limage.Image = this.image_1;
                }
                if (this.Iconimage_right_Selected != null)
                {
                    this.rimage.Image = this.image_2;
                }
            }
            else
            {
                this.BackColor = this.colselected;
                if (this.Iconimage_Selected != null)
                {
                    this.limage.Image = this.Iconimage_Selected;
                }
                if (this.Iconimage_right_Selected != null)
                {
                    this.rimage.Image = this.Iconimage_right_Selected;
                }
            }
            this.txttext.ForeColor = this.color_3;
            this.limage.BackColor = this.color_1;
        }

        private void BunifuFlatButton_Resize(object sender, EventArgs e)
        {
            if (this.limage.Image != null)
            {
                this.limage.Width = this.limage.Height;
            }
            else
            {
                this.limage.Width = 0;
            }
            if (this.rimage.Image != null)
            {
                this.rimage.Width = this.rimage.Height;
            }
            else
            {
                this.rimage.Width = 0;
            }
            this.rimage.Top = base.Height / 2 - this.rimage.Height / 2;
            this.limage.Top = this.rimage.Top;
            if (this.IconMarginLeft <= 0)
            {
                this.limage.Left = this.limage.Top;
            }
            else
            {
                this.limage.Left = this.IconMarginLeft;
            }
            if (this.IconMarginRight <= 0)
            {
                this.rimage.Left = base.Width - this.rimage.Width - this.rimage.Top;
            }
            else
            {
                this.rimage.Left = this.IconMarginRight;
            }
            this.txttext.Top = base.Height / 2 - this.txttext.Height / 2;
            this.method_0();
            Elipse.Apply(this, this.int_0);
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
            this.icontainer_0 = new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuFlatButton));
            this.imageList_0 = new ImageList(this.icontainer_0);
            this.limage = new PictureBox();
            this.rimage = new PictureBox();
            this.txttext = new BunifuCustomLabel();
            ((ISupportInitialize)this.limage).BeginInit();
            ((ISupportInitialize)this.rimage).BeginInit();
            base.SuspendLayout();
            this.imageList_0.ColorDepth = ColorDepth.Depth8Bit;
            this.imageList_0.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_0.TransparentColor = Color.Transparent;
            this.limage.BackColor = Color.Transparent;
            this.limage.BackgroundImageLayout = ImageLayout.Stretch;
            //this.limage.Image = (Image)componentResourceManager.GetObject("limage.Image");
            this.limage.Location = new Point(0, 0);
            this.limage.Name = "limage";
            this.limage.Size = new System.Drawing.Size(50, 48);
            this.limage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.limage.TabIndex = 1;
            this.limage.TabStop = false;
            this.limage.Click += new EventHandler(this.txttext_Click);
            this.limage.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
            this.limage.MouseDoubleClick += new MouseEventHandler(this.limage_MouseDoubleClick);
            this.limage.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
            this.limage.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
            this.limage.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
            this.limage.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
            this.rimage.BackColor = Color.Transparent;
            this.rimage.BackgroundImageLayout = ImageLayout.Stretch;
            this.rimage.Location = new Point(191, 0);
            this.rimage.Name = "rimage";
            this.rimage.Size = new System.Drawing.Size(50, 48);
            this.rimage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.rimage.TabIndex = 3;
            this.rimage.TabStop = false;
            this.rimage.Click += new EventHandler(this.txttext_Click);
            this.rimage.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
            this.rimage.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
            this.txttext.AutoEllipsis = true;
            this.txttext.BackColor = Color.Transparent;
            this.txttext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txttext.ForeColor = Color.White;
            this.txttext.Location = new Point(50, 0);
            this.txttext.Name = "txttext";
            this.txttext.Size = new System.Drawing.Size(188, 48);
            this.txttext.TabIndex = 4;
            this.txttext.Text = "     Bunifu Flat Button";
            this.txttext.TextAlign = ContentAlignment.MiddleLeft;
            this.txttext.Click += new EventHandler(this.txttext_Click);
            this.txttext.DoubleClick += new EventHandler(this.txttext_DoubleClick);
            this.txttext.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
            this.txttext.MouseDown += new MouseEventHandler(this.txttext_MouseDown);
            this.txttext.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
            this.txttext.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
            this.txttext.MouseUp += new MouseEventHandler(this.txttext_MouseUp);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.SeaGreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.Controls.Add(this.limage);
            base.Controls.Add(this.rimage);
            base.Controls.Add(this.txttext);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
            base.Name = "BunifuFlatButton";
            base.Size = new System.Drawing.Size(241, 48);
            base.Load += new EventHandler(this.BunifuFlatButton_Load);
            base.DoubleClick += new EventHandler(this.BunifuFlatButton_DoubleClick);
            base.MouseClick += new MouseEventHandler(this.BunifuFlatButton_MouseClick);
            base.MouseEnter += new EventHandler(this.BunifuFlatButton_MouseEnter);
            base.MouseLeave += new EventHandler(this.BunifuFlatButton_MouseLeave);
            base.Resize += new EventHandler(this.BunifuFlatButton_Resize);
            ((ISupportInitialize)this.limage).EndInit();
            ((ISupportInitialize)this.rimage).EndInit();
            base.ResumeLayout(false);
        }

        private void limage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void method_0()
        {
            if (!this.limage.Visible)
            {
                this.txttext.Left = 0;
            }
            else
            {
                this.txttext.Left = this.limage.Right;
            }
            if (!this.rimage.Visible)
            {
                this.txttext.Width = base.Width - this.txttext.Left;
                return;
            }
            this.txttext.Width = this.rimage.Left - this.txttext.Left;
        }

        private void method_1()
        {
            double height = (double)base.Height;
            double num = Math.Round(this.double_0 / 100 * height, 0);
            PictureBox pictureBox = this.limage;
            PictureBox pictureBox1 = this.rimage;
            int num1 = int.Parse(num.ToString());
            int num2 = num1;
            pictureBox1.Height = num1;
            pictureBox.Height = num2;
            this.OnResize(new EventArgs());
        }

        private void method_2()
        {
            double height = (double)base.Height;
            double num = Math.Round(this.double_1 / 100 * height, 0);
            PictureBox pictureBox = this.rimage;
            PictureBox pictureBox1 = this.rimage;
            int num1 = int.Parse(num.ToString());
            int num2 = num1;
            pictureBox1.Height = num1;
            pictureBox.Height = num2;
            this.OnResize(new EventArgs());
        }

        private void method_3(object sender, PaintEventArgs e)
        {
        }

        private void method_4(object sender, EventArgs e)
        {
        }

        private void method_5()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            foreach (Control control in base.Parent.Controls)
            {
                if (!(control.GetType() == typeof(BunifuFlatButton)) || !((BunifuFlatButton)control).IsTab || !(((BunifuFlatButton)control).Name != base.Name) || base.Parent != ((BunifuFlatButton)control).Parent || !((BunifuFlatButton)control).Enabled)
                {
                    continue;
                }
                ((BunifuFlatButton)control).selected = false;
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

        public void reset()
        {
            this.bool_2 = false;
            this.BackColor = this.colbackground;
        }

        private void txttext_Click(object sender, EventArgs e)
        {
            if (!this.bool_1)
            {
                return;
            }
            base.OnClick(e);
        }

        private void txttext_DoubleClick(object sender, EventArgs e)
        {
            if (!this.bool_1)
            {
                return;
            }
            base.OnDoubleClick(e);
        }

        private void txttext_MouseDown(object sender, MouseEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (!this.bool_1)
            {
                return;
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
                this.eventHandler_0(this, e);
            }
        }

        private void txttext_MouseUp(object sender, MouseEventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (!this.bool_1)
            {
                return;
            }
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

        public event EventHandler MouseDown
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

        public event EventHandler MouseUp
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
    }

}
