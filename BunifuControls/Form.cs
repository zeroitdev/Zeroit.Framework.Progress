using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
    [DebuggerStepThrough]
    public class BunifuForm : Form
    {
        private int int_0;

        private IContainer icontainer_0;

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

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ClassStyle = createParams.ClassStyle | 131072;
                createParams.ExStyle = createParams.ExStyle | 33554432;
                return createParams;
            }
        }

        public BunifuForm()
        {
            this.InitializeComponent();
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(284, 261);
            base.Name = "BunifuForm";
            this.Text = "BunifuForm";
            base.ResumeLayout(false);
        }

        protected override void OnResize(EventArgs e)
        {
            Elipse.Apply(this, this.int_0);
            base.OnResize(e);
        }
    }

}
