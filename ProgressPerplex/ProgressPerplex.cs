namespace Zeroit.Framework.Progress
{

    #region ProgressBarPerplex

    //public class ProgressBarPerplex : Control
    //{
    //    private int progress;
    //    public ProgressBarPerplex()
    //    {

    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

    //        BackColor = Color.Transparent;

    //        Size = new Size(100, 100);

    //        progress = 3;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {

    //        base.OnPaint(e);

    //        var G = e.Graphics;

    //        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

    //        G.TranslateTransform(this.Width / 2, this.Height / 2);
    //        G.RotateTransform(-90);


    //        //Rectangle rect1 = new Rectangle(0 - (this.Width / 2) + 20, 0 - (this.Height / 2) + 20, this.Width - 40, this.Height);
    //        Pen obj_pen = new Pen(Color.Red);
    //        Rectangle rect = new Rectangle(0 - (Width/2) + 5, 0 - (this.Height / 2) + 5, Width-10, Height-10);
    //        G.DrawPie(obj_pen, rect, 0, (int)(progress*3.6)); //360/100*3.6
    //        G.FillPie(new SolidBrush(Color.Red), rect, 0, (int)(progress * 3.6));

    //        Pen obj_pen1 = new Pen(Color.White);
    //        Rectangle rect1 = new Rectangle(0 - (Width / 2) + 10, 0 - (this.Height / 2) + 10, Width - 20, Height - 20);
    //        G.DrawPie(obj_pen1, rect1, 0, 360);
    //        G.FillPie(new SolidBrush(Color.White), rect1, 0, 360);

    //        G.RotateTransform(90);
    //        StringFormat ft = new StringFormat();
    //        ft.LineAlignment = StringAlignment.Center;
    //        ft.Alignment = StringAlignment.Center;
    //        G.DrawString("100%", new Font("Verdana", 12), new SolidBrush(Color.Red), rect1, ft);


    //    }

    //    public void UpdateProgress(int progress)
    //    {
    //        this.progress = progress;
    //    }


    //}

    #endregion

}
