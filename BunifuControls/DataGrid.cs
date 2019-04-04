using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
    public class BunifuCustomDataGrid : DataGridView
    {
        private bool bool_0 = true;

        public Color Hcolor = Color.SeaGreen;

        public Color HBgcolor = Color.SeaGreen;

        private IContainer icontainer_0;

        public new bool DoubleBuffered
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                this.ApplyDoubleBuffer(this, this.bool_0);
            }
        }

        public Color HeaderBgColor
        {
            get
            {
                return this.Hcolor;
            }
            set
            {
                this.Hcolor = value;
                base.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
                base.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
                base.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

        public Color HeaderForeColor
        {
            get
            {
                return this.HBgcolor;
            }
            set
            {
                this.HBgcolor = value;
                base.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
                base.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
                base.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

        public BunifuCustomDataGrid()
        {
            this.method_0();
            base.ColumnHeadersDefaultCellStyle.BackColor = this.Hcolor;
            base.ColumnHeadersDefaultCellStyle.ForeColor = this.HBgcolor;
            base.BorderStyle = System.Windows.Forms.BorderStyle.None;
            base.EnableHeadersVisualStyles = false;
        }

        public void ApplyDoubleBuffer(DataGridView dgv, bool setting)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgv, setting, null);
            }
            catch (Exception exception)
            {
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
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle seaGreen = new DataGridViewCellStyle();
            ((ISupportInitialize)this).BeginInit();
            base.SuspendLayout();
            dataGridViewCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            base.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
            base.BackgroundColor = Color.Gainsboro;
            base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            seaGreen.Alignment = DataGridViewContentAlignment.MiddleLeft;
            seaGreen.BackColor = Color.SeaGreen;
            seaGreen.Font = new System.Drawing.Font("Century Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            seaGreen.ForeColor = Color.White;
            seaGreen.SelectionBackColor = SystemColors.Highlight;
            seaGreen.SelectionForeColor = SystemColors.HighlightText;
            seaGreen.WrapMode = DataGridViewTriState.True;
            base.ColumnHeadersDefaultCellStyle = seaGreen;
            base.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ((ISupportInitialize)this).EndInit();
            base.ResumeLayout(false);
        }
    }

}
