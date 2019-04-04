using System;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
    public class BunifuCustomTextbox : TextBox
    {

        private Color color_0 = Color.SeaGreen;

        private IContainer icontainer_0;

        public Color BorderColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                this.Refresh();
            }
        }

        public BunifuCustomTextbox()
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
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(this.BorderColor, 1f);
            int x = e.ClipRectangle.X;
            int y = e.ClipRectangle.Y;
            Rectangle clipRectangle = e.ClipRectangle;
            int width = clipRectangle.Width - 1;
            clipRectangle = e.ClipRectangle;
            Rectangle rectangle = new Rectangle(x, y, width, clipRectangle.Height - 1);
            e.Graphics.DrawRectangle(pen, rectangle);
            clipRectangle = e.ClipRectangle;
            int num = clipRectangle.X + 1;
            clipRectangle = e.ClipRectangle;
            int y1 = clipRectangle.Y + 1;
            clipRectangle = e.ClipRectangle;
            int width1 = clipRectangle.Width - 1;
            clipRectangle = e.ClipRectangle;
            Rectangle rectangle1 = new Rectangle(num, y1, width1, clipRectangle.Height - 1);
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rectangle1, this.ForeColor, this.BackColor, TextFormatFlags.Default);
        }

    }

}
