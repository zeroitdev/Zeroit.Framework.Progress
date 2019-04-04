#region Imports

//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{
    #region BusyBarProgress !!!!!!!!!!! Slowooooooooooowwwwww !!!!!!!!!!!!!!!!!!!!!

    //   #region BlockFadeBusyBar

    //   public class BlockFadeBusyBar : BusyBarBase
    //   {
    //       protected Pen _borderPen;
    //       protected Color _borderColor = DefaultBorderColor;
    //       protected Brush _foregroundBrush;
    //       protected Brush _currentFillBrush;
    //       protected Color _currentFillColor = DefaultCurrentPositionColor;
    //       protected Bitmap _blockBitmap;
    //       protected Bitmap _CurrentBlockBitmap;
    //       protected int _iBlockCount = -1;
    //       protected int _iBlockWidth = DefaultBlockWidth;
    //       protected int _iBlockSpace;
    //       private bool _bRandomMode = false;
    //       protected Random _randomNumberGenerator = new Random();

    //       public static int DefaultBlockWidth
    //       { get { return 30; } }
    //       public static Color DefaultBorderColor
    //       { get { return Color.Black; } }
    //       public static Color DefaultCurrentPositionColor
    //       { get { return SystemColors.HighlightText; } }
    //       new public static int DefaultStepTimeout
    //       { get { return 250; } }
    //       new public static int DefaultStepSize
    //       { get { return 1; } }

    //       public bool RandomMode
    //       {
    //           get { return _bRandomMode; }
    //           set { _bRandomMode = value; }
    //       }

    //       public BlockFadeBusyBar()
    //       {
    //       }

    //       protected override void OnBackColorChanged(EventArgs e)
    //       {
    //           base.OnBackColorChanged(e);
    //           this.CreateBackgroundBrush();
    //           this.CreateBlockBitmaps();
    //           this.Invalidate();
    //       }

    //       protected override void OnForeColorChanged(EventArgs e)
    //       {
    //           base.OnForeColorChanged(e);
    //           this.CreateForegroundBrush();
    //           this.CreateBlockBitmaps();
    //           this.Invalidate();
    //       }

    //       protected override void OnSizeChanged(EventArgs e)
    //       {
    //           this.CreateBlockBitmaps();
    //           this.Invalidate();
    //       }

    //       public Color BorderColor
    //       {
    //           set
    //           {
    //               _borderColor = value;
    //               CreateBorderPen();
    //               CreateBlockBitmaps();
    //               Invalidate();
    //           }
    //           get { return _borderColor; }
    //       }

    //       public Color CurrentFillColor
    //       {
    //           set
    //           {
    //               _currentFillColor = value;
    //               CreateFillCurrentBrush();
    //               CreateBlockBitmaps();
    //               Invalidate();
    //           }
    //           get { return _currentFillColor; }
    //       }

    //       public int BlockWidth
    //       {
    //           set
    //           {
    //               _iBlockWidth = value; ;
    //               CreateBlockBitmaps();
    //               Invalidate();
    //           }
    //           get { return _iBlockWidth; }
    //       }

    //       protected override void IncreaseBarPosition()
    //       {
    //           if (this._iBlockCount == -1)
    //               return;

    //           if (this._bRandomMode)
    //           {
    //               int iNewPos;

    //               do
    //               {
    //                   iNewPos = _randomNumberGenerator.Next(this._iBlockCount);
    //               } while (iNewPos == this._iBarPosition);
    //               _iBarPosition = iNewPos;
    //           }
    //           else
    //           {
    //               _iBarPosition += this._iStepSize;
    //               if (_iBarPosition > _iBlockCount - 1)
    //                   _iBarPosition = _iBarPosition - this._iBlockCount;
    //           }
    //       }

    //       protected void CreateBlockBitmaps()
    //       {
    //           try
    //           {
    //               lock (this)
    //               {
    //                   //
    //                   // create the block bitmap, erase the bitmap using the control's background color and clone it to get the current bitmap
    //                   //
    //                   this._blockBitmap = new Bitmap(this._iBlockWidth, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    //                   Graphics gfx1 = Graphics.FromImage(this._blockBitmap);
    //                   gfx1.FillRectangle(this._backgroundBrush, 0, 0, this._blockBitmap.Width, this._blockBitmap.Height);
    //                   this._CurrentBlockBitmap = (Bitmap)this._blockBitmap.Clone();
    //                   Graphics gfx2 = Graphics.FromImage(this._CurrentBlockBitmap);


    //                   gfx1.FillRectangle(this._foregroundBrush, 0, 0, this._iBlockWidth, this._blockBitmap.Height);
    //                   gfx2.FillRectangle(this._currentFillBrush, 0, 0, this._iBlockWidth, this._CurrentBlockBitmap.Height);

    //                   //
    //                   // draw the border
    //                   //
    //                   gfx1.DrawLine(this._borderPen, 0, 0, this._CurrentBlockBitmap.Width, 0);
    //                   gfx1.DrawLine(this._borderPen, 0, 0, 0, this._CurrentBlockBitmap.Height);
    //                   gfx1.DrawLine(this._borderPen, this._CurrentBlockBitmap.Width - 1, 0, this._CurrentBlockBitmap.Width - 1, this._CurrentBlockBitmap.Height - 1);
    //                   gfx1.DrawLine(this._borderPen, 0, this._CurrentBlockBitmap.Height - 1, this._CurrentBlockBitmap.Width - 1, this._CurrentBlockBitmap.Height - 1);

    //                   gfx2.DrawLine(this._borderPen, 0, 0, this._CurrentBlockBitmap.Width, 0);
    //                   gfx2.DrawLine(this._borderPen, 0, 0, 0, this._CurrentBlockBitmap.Height);
    //                   gfx2.DrawLine(this._borderPen, this._CurrentBlockBitmap.Width - 1, 0, this._CurrentBlockBitmap.Width - 1, this._CurrentBlockBitmap.Height - 1);
    //                   gfx2.DrawLine(this._borderPen, 0, this._CurrentBlockBitmap.Height - 1, this._CurrentBlockBitmap.Width - 1, this._CurrentBlockBitmap.Height - 1);
    //               }
    //           }
    //           catch (Exception e)
    //           {
    //           }
    //       }

    //       protected void CreateFillCurrentBrush()
    //       {
    //           this._currentFillBrush = new SolidBrush(this._currentFillColor);
    //       }
    //       protected void CreateForegroundBrush()
    //       {
    //           this._foregroundBrush = new SolidBrush(this.ForeColor);
    //       }
    //       protected void CreateBorderPen()
    //       {
    //           this._borderPen = new Pen(this._borderColor);
    //       }

    //       protected override void DoPaint(System.Drawing.Graphics g)
    //       {
    //           int iDrawHeight = this.Height;

    //           g.FillRectangle(this._backgroundBrush, 0, 0, this.Width, this.Height);

    //           //
    //           // calculate the amount of blocks to draw
    //           //
    //           _iBlockCount = this.Width / (this._iBlockWidth + this._iBlockWidth / 5); //initial space is the width/5s (can change later to fit the block on the right and left border)

    //           if (_iBlockCount < 2)
    //               return;

    //           double dSpace = (Convert.ToDouble(this.Width) - Convert.ToDouble(_iBlockCount * this._iBlockWidth)) / Convert.ToDouble(_iBlockCount - 1);
    //           for (int i = 0; i < _iBlockCount; i++)
    //           {
    //               double dPos = Convert.ToDouble(i) * (Convert.ToDouble(this._iBlockWidth + dSpace));

    //               if (i == this._iBarPosition)
    //                   g.DrawImage(this._CurrentBlockBitmap, Convert.ToInt32(dPos), 0);
    //               else
    //                   g.DrawImage(this._blockBitmap, Convert.ToInt32(dPos), 0);
    //           }

    //       }
    //   }

    //   #endregion

    //   #region BorderedBusyBar
    //   public abstract class BorderedBusyBar : BusyBarBase
    //   {
    //       protected Border3DStyle _iBorderStyle;
    //       protected bool _bShowBorder = true;

    //       protected BorderedBusyBar()
    //       {
    //           this._iBorderStyle = Border3DStyle.SunkenInner;
    //       }

    //       public bool ShowBorder
    //       {
    //           get { return _bShowBorder; }
    //           set
    //           {
    //               _bShowBorder = value;
    //               OnShowBorderChanged();
    //               this.Invalidate();
    //           }
    //       }

    //       public Border3DStyle BorderStyle3D
    //       {
    //           get { return this._iBorderStyle; }
    //           set { this._iBorderStyle = value; }
    //       }

    //       protected virtual void OnShowBorderChanged()
    //       {
    //       }


    //       protected void DrawBorder(System.Drawing.Graphics g)
    //       {
    //           if (_bShowBorder)
    //               ControlPaint.DrawBorder3D(g, 0, 0, this.Width, this.Height, this.BorderStyle3D);
    //       }

    //       protected override void DoPaint(System.Drawing.Graphics g)
    //       {
    //           DrawBorder(g);
    //       }

    //   }
    //   #endregion

    //   #region BorderedBusyBarWithText
    //   /// <summary>
    ///// Summary description for BorderedBusyBarWithText.
    ///// </summary>
    //public class BorderedBusyBarWithText : BorderedBusyBar
    //   {
    //       private string _strText;
    //       private Color _textColor;
    //       private SolidBrush _textBrush;
    //       private StringFormat _stringFormat;
    //       public static readonly Color DefaultTextColor = System.Drawing.SystemColors.ControlText;

    //       public new string Text
    //       {
    //           get { return _strText; }
    //           set
    //           {
    //               _strText = value;
    //               Invalidate();
    //           }
    //       }

    //       public Color TextColor
    //       {
    //           get { return _textColor; }
    //           set
    //           {
    //               _textColor = value;
    //               _textBrush = new SolidBrush(_textColor);
    //               Invalidate();
    //           }
    //       }

    //       public BorderedBusyBarWithText()
    //       {
    //           this.TextColor = DefaultTextColor;
    //           _stringFormat = new StringFormat();
    //           _stringFormat.Alignment = StringAlignment.Center;
    //           _stringFormat.LineAlignment = StringAlignment.Center;

    //       }

    //       protected void DoDrawText(System.Drawing.Graphics g)
    //       {
    //           if (this._strText == null)
    //               return;

    //           if (this._strText == "")
    //               return;

    //           g.DrawString(_strText, this.Font, _textBrush, this.ClientRectangle, this._stringFormat);

    //       }

    //       protected override void DoPaint(System.Drawing.Graphics g)
    //       {
    //           base.DoPaint(g);
    //           DrawBorder(g);
    //       }
    //   }
    //   #endregion

    //   #region BusyBarBase


    //   public abstract class BusyBarBase : System.Windows.Forms.UserControl
    //   {
    //       protected bool _bRunning = false;
    //       protected int _iBarPosition = 0;
    //       protected int _iStepSize = DefaultStepSize;
    //       protected int _iStepTimeout = DefaultStepTimeout;
    //       protected bool _bDisposing = false;
    //       protected System.Threading.Thread _thread;
    //       protected SolidBrush _backgroundBrush;


    //       new public static Color DefaultForeColor
    //       { get { return SystemColors.Highlight; } }
    //       new public static Color DefaultBackColor
    //       { get { return SystemColors.Control; } }
    //       public static int DefaultStepSize
    //       { get { return 1; } }
    //       public static int DefaultStepTimeout
    //       { get { return 250; } }

    //       public int StepTimeout
    //       {
    //           get { return _iStepTimeout; }
    //           set { _iStepTimeout = value; }
    //       }
    //       public int StepSize
    //       {
    //           get { return _iStepSize; }
    //           set { _iStepSize = value; }
    //       }

    //       public BusyBarBase()
    //       {
    //           this.ForeColor = DefaultForeColor;
    //           this.BackColor = DefaultBackColor;

    //           this.Size = new Size(300, 25); //default size

    //           CreateBackgroundBrush();

    //           // Turn on double buffering to reduce flicker here
    //           SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //           SetStyle(ControlStyles.DoubleBuffer, true);
    //           SetStyle(ControlStyles.ResizeRedraw, true);
    //           UpdateStyles();

    //           _thread = new Thread(new System.Threading.ThreadStart(WorkerThread));
    //           _thread.Start();

    //       }

    //       protected override void OnBackColorChanged(EventArgs e)
    //       {
    //           CreateBackgroundBrush();
    //       }



    //       protected void CreateBackgroundBrush()
    //       {
    //           lock (this)
    //           {
    //               _backgroundBrush = new SolidBrush(this.BackColor);
    //           }
    //       }


    //       //we do not erase the background. this would cause "flickering"
    //       protected override void OnPaintBackground(PaintEventArgs e)
    //       {

    //       }

    //       protected override void Dispose(bool disposing)
    //       {
    //           base.Dispose(disposing);
    //           _bDisposing = true;
    //           bool bRet = _thread.Join(new TimeSpan(1, 1, 1, 1));
    //           bRet = _thread.IsAlive;
    //       }

    //       protected virtual void DoPaint(System.Drawing.Graphics g)
    //       {
    //       }

    //       protected virtual void IncreaseBarPosition()
    //       {
    //           _iBarPosition += _iStepSize;
    //       }

    //       protected void WorkerThread()
    //       {
    //           while (_bDisposing == false)
    //           {
    //               System.Threading.Thread.Sleep(this._iStepTimeout);

    //               if (_bRunning == false)
    //                   continue;

    //               IncreaseBarPosition();

    //               this.Invalidate();
    //           }
    //       }

    //       public bool IsRunning
    //       {
    //           get { return _bRunning; }
    //       }

    //       public void Start()
    //       {
    //           _bRunning = true;
    //       }

    //       public void Stop()
    //       {
    //           _bRunning = false;
    //       }

    //       //do not allow to override OnPaint() in derived classed because we do a lock here
    //       protected sealed override void OnPaint(PaintEventArgs e)
    //       {
    //           lock (this)
    //           {
    //               DoPaint(e.Graphics);
    //           }
    //       }

    //       //
    //       // hide the following attributes	
    //       //
    //       [Browsable(false)]
    //       public override System.Drawing.Image BackgroundImage
    //       {
    //           get { return null; }
    //           set { }
    //       }

    //   }

    //   #endregion

    //   #region ColorFadeBusyBar

    //   public class ColorFadeBusyBar : FadeBusyBar
    //   {
    //       protected Color _color2;
    //       protected int _iFadeLength;

    //       public static Color DefaultColor2
    //       { get { return SystemColors.Control; } }

    //       public ColorFadeBusyBar()
    //       {
    //           this.Color2 = DefaultColor2;

    //           this._iStepTimeout = 50;
    //           this._iStepSize = 5;
    //           this._iFadeLength = -1;
    //       }

    //       public int FadeLength
    //       {
    //           get { return this._iFadeLength; }
    //           set
    //           {
    //               lock (this)
    //               {
    //                   if (value > this.Width)
    //                       throw new Exception("FadeLength cannot be bigger than the width of the control");
    //                   _iFadeLength = value;
    //                   CreateImage();
    //                   Invalidate();
    //               }
    //           }
    //       }

    //       protected override void CreateImage()
    //       {
    //           lock (this)
    //           {
    //               int iLen;
    //               int iHeight = this.Height;

    //               if (this.ShowBorder)
    //                   iHeight -= 2;

    //               if (this._iFadeLength <= 0)
    //                   iLen = this.Width / 2;
    //               else
    //                   iLen = this._iFadeLength;

    //               this._imageForward = new Bitmap(iLen, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

    //               Graphics gfx = Graphics.FromImage(_imageForward);

    //               System.Drawing.Drawing2D.LinearGradientBrush washBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, _imageForward.Width, _imageForward.Height), this._color2, this.ForeColor, 0.90f, true);
    //               gfx.FillRectangle(washBrush, this.ClientRectangle);
    //               /*
    //                               for (int i=0 ; i<_imageForward.Width; i++)
    //                               {
    //                                   //
    //                                   // calculate the new color to use (linear color mix)
    //                                   //
    //                                   int colorR = ( (int)(this.ForeColor.R - this.Color2.R ) ) * i / _imageForward.Width;
    //                                   int colorG = ( (int)(this.ForeColor.G - this.Color2.G ) ) * i / _imageForward.Width;
    //                                   int colorB = ( (int)(this.ForeColor.B - this.Color2.B ) ) * i / _imageForward.Width;
    //                                   Color color = Color.FromArgb( this.Color2.R+colorR, this.Color2.G+colorG, this.Color2.B+colorB );

    //                                   gfx.DrawLine( new Pen( new SolidBrush( color )), i, 0, i, iHeight );
    //                               }
    //               */
    //               this._imageReverse = (Image)this._imageForward.Clone();
    //               this._imageReverse.RotateFlip(RotateFlipType.Rotate180FlipNone);
    //           }
    //       }

    //       public Color Color2
    //       {
    //           get { return _color2; }
    //           set
    //           {
    //               _color2 = value;
    //               OnColor2Changed();
    //           }
    //       }

    //       protected override void OnSizeChanged(EventArgs e)
    //       {
    //           CreateImage();
    //           this.Invalidate();
    //       }


    //       protected override void OnBackColorChanged(EventArgs e)
    //       {
    //           base.OnBackColorChanged(e);
    //           CreateImage();
    //           this.Invalidate();
    //       }
    //       protected override void OnForeColorChanged(EventArgs e)
    //       {
    //           CreateImage();
    //           this.Invalidate();
    //       }

    //       protected void OnColor2Changed()
    //       {
    //           CreateImage();
    //           this.Invalidate();
    //       }
    //   }

    //   #endregion

    //   #region FadeBusyBar

    //   public abstract class FadeBusyBar : BorderedBusyBarWithText
    //   {
    //       protected Image _imageForward;
    //       protected Image _imageReverse;

    //       protected bool _bPingPong = false;
    //       protected bool _bLeftToRight = true;
    //       protected bool _bInitialSlide = true;

    //       protected bool _bSwitchFlag = false;

    //       public FadeBusyBar()
    //       {
    //           this._iStepTimeout = 50;
    //           this._iStepSize = 5;

    //       }

    //       public bool PingPong
    //       {
    //           get { return _bPingPong; }
    //           set
    //           {
    //               lock (this)
    //               {
    //                   if (value == false)
    //                       this._bLeftToRight = true;
    //                   _bPingPong = value;
    //               }
    //           }
    //       }

    //       protected abstract void CreateImage();

    //       protected override void OnShowBorderChanged()
    //       {
    //           base.OnShowBorderChanged();
    //           this.CreateImage();
    //       }


    //       protected override void IncreaseBarPosition()
    //       {
    //           bool bChangeDirection = false;

    //           if (_bLeftToRight)
    //           {
    //               int iNewPos = _iBarPosition + _iStepSize;
    //               if (this.PingPong)
    //               {
    //                   if (iNewPos <= this.Width)
    //                       _iBarPosition = iNewPos;
    //                   else
    //                   {
    //                       _iBarPosition = this.Width - (iNewPos - this.Width);
    //                       bChangeDirection = true;
    //                   }
    //               }
    //               else
    //               {
    //                   _iBarPosition = iNewPos;
    //                   if (_iBarPosition > this.Width)
    //                       _iBarPosition = iNewPos - this.Width;
    //               }
    //           }
    //           else
    //           {
    //               int iNewPos = _iBarPosition - _iStepSize;

    //               if (iNewPos >= 0)
    //                   _iBarPosition = iNewPos;
    //               else
    //               {
    //                   _iBarPosition = iNewPos * -1;
    //                   bChangeDirection = true;
    //               }
    //           }

    //           if (bChangeDirection)
    //               _bLeftToRight = !_bLeftToRight;
    //       }

    //       protected void DoPaintPingPong(System.Drawing.Graphics g)
    //       {
    //           int iLowestPos = -1;
    //           int iHighestPos = -1;
    //           int iDrawHeight = this.Height;
    //           int iStartPosY = 0;

    //           if (this.ShowBorder)
    //           {
    //               iDrawHeight -= 2;
    //               iStartPosY = 1;
    //           }


    //           if (_bLeftToRight)
    //           {
    //               //
    //               // check if we have to draw a refelection behind the current pos
    //               //
    //               if (this._iBarPosition < this._imageForward.Width)
    //               {
    //                   // first draw the reflection in the reverse order
    //                   int iReflectionLen = this._imageReverse.Width - this._iBarPosition;
    //                   g.DrawImage(this._imageReverse, -(_imageReverse.Width - iReflectionLen), iStartPosY);

    //                   iHighestPos = iReflectionLen;
    //                   if (iHighestPos < _iBarPosition)
    //                       iHighestPos = _iBarPosition;
    //               }
    //               else
    //               {
    //                   iLowestPos = this._iBarPosition - _imageReverse.Width;
    //                   iHighestPos = this._iBarPosition;
    //               }
    //               g.DrawImage(_imageForward, this._iBarPosition - _imageForward.Width, iStartPosY);
    //           }
    //           else
    //           {
    //               //
    //               // check if we have to draw a refelection in front the current pos
    //               //
    //               if (this._iBarPosition + this._imageForward.Width > this.Width)
    //               {
    //                   // first draw the reflection in the reverse order
    //                   int iReflectionLen = this._imageForward.Width - (this.Width - this._iBarPosition);
    //                   g.DrawImage(this._imageForward, this.Width - iReflectionLen, iStartPosY);
    //                   iLowestPos = this.Width - iReflectionLen;

    //                   if (this._iBarPosition < iLowestPos)
    //                       iLowestPos = this._iBarPosition;
    //               }
    //               else
    //               {
    //                   iLowestPos = _iBarPosition;
    //                   iHighestPos = _iBarPosition + _imageForward.Width;
    //               }
    //               g.DrawImage(_imageReverse, this._iBarPosition, iStartPosY);
    //           }

    //           if (iLowestPos != -1 || iHighestPos != -1)
    //           {
    //               if (iLowestPos != -1)
    //                   g.FillRectangle(_backgroundBrush, 0, iStartPosY, iLowestPos, iDrawHeight);

    //               if (iHighestPos != -1)
    //                   g.FillRectangle(_backgroundBrush, iHighestPos, iStartPosY, this.Width - iHighestPos, iDrawHeight);
    //           }

    //       }
    //       protected void DoPaintNormal(System.Drawing.Graphics g)
    //       {
    //           int iDrawHeight = this.Height;
    //           int iStartPosY = 0;

    //           if (this.ShowBorder)
    //           {
    //               iDrawHeight -= 2;
    //               iStartPosY = 1;
    //           }


    //           // check if we have to draw something on the left side (the end)
    //           if (this._iBarPosition < this._imageForward.Width)
    //           {
    //               int iEndLen = this._imageForward.Width - this._iBarPosition;
    //               g.DrawImage(this._imageForward, this.Width - iEndLen, iStartPosY);
    //               g.DrawImage(_imageForward, this._iBarPosition - _imageForward.Width, iStartPosY);

    //               //erase the rect in the middle
    //               g.FillRectangle(_backgroundBrush, _iBarPosition, iStartPosY, this.Width - this._imageForward.Width, iDrawHeight);
    //           }
    //           else
    //           {
    //               g.DrawImage(_imageForward, this._iBarPosition - _imageForward.Width, iStartPosY);

    //               //erase the left rect
    //               if (this._iBarPosition - this._imageForward.Width > 0)
    //                   g.FillRectangle(_backgroundBrush, 0, iStartPosY, this._iBarPosition - this._imageForward.Width, iDrawHeight);

    //               //erase the right rect
    //               if (this._iBarPosition < this.Width)
    //                   g.FillRectangle(_backgroundBrush, this._iBarPosition, iStartPosY, this.Width - _iBarPosition, iDrawHeight);
    //           }
    //       }

    //       protected override void DoPaint(System.Drawing.Graphics g)
    //       {
    //           if (this.PingPong)
    //               DoPaintPingPong(g);
    //           else
    //               DoPaintNormal(g);
    //           this.DrawBorder(g);
    //           this.DoDrawText(g);
    //           return;
    //       }
    //   }

    //   #endregion

    //   #region ImageFadeBusyBar

    //   public class ImageFadeBusyBar : FadeBusyBar
    //   {
    //       public ImageFadeBusyBar()
    //       {
    //           CreateInitialImage();
    //           CreateImage();
    //       }


    //       public Image Image
    //       {
    //           get { return this._imageForward; }
    //           set
    //           {
    //               lock (this)
    //               {
    //                   if (value == null)
    //                       CreateInitialImage();
    //                   else
    //                       this._imageForward = value;

    //                   CreateImage();
    //                   Invalidate();
    //               }
    //           }
    //       }

    //       protected void CreateInitialImage()
    //       {
    //           lock (this)
    //           {
    //               int iHeight = this.Height;

    //               if (this.ShowBorder)
    //                   iHeight -= 2;

    //               _imageForward = new Bitmap(30, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

    //               Graphics gfx = Graphics.FromImage(_imageForward);
    //               for (int i = 0; i < _imageForward.Width; i++)
    //               {
    //                   //
    //                   // calculate the new color to use (linear color mix)
    //                   //
    //                   int colorR = ((int)(this.ForeColor.R - this.BackColor.R)) * i / _imageForward.Width;
    //                   int colorG = ((int)(this.ForeColor.G - this.BackColor.G)) * i / _imageForward.Width;
    //                   int colorB = ((int)(this.ForeColor.B - this.BackColor.B)) * i / _imageForward.Width;
    //                   Color color = Color.FromArgb(this.BackColor.R + colorR, this.BackColor.G + colorG, this.BackColor.B + colorB);

    //                   gfx.DrawLine(new Pen(new SolidBrush(color)), i, 0, i, iHeight);
    //               }
    //           }
    //       }

    //       protected override void CreateImage()
    //       {
    //           lock (this)
    //           {
    //               this._imageReverse = (Image)this._imageForward.Clone();
    //               this._imageReverse.RotateFlip(RotateFlipType.Rotate180FlipNone);
    //           }
    //       }


    //   }

    //   #endregion

    #endregion
}
