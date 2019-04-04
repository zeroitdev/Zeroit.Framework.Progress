using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
    public class BunifuCustomLabel : Label
    {
        public BunifuCustomLabel()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (base.Enabled)
            {
                base.OnPaint(e);
                return;
            }
            SolidBrush solidBrush = new SolidBrush(this.ForeColor);
            e.Graphics.DrawString(this.Text, this.Font, solidBrush, 0f, 0f);
        }
    }
}
