// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 12-30-2017
// ***********************************************************************
// <copyright file="ProgressAntonio.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ProgressBarBoxed

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitProgressBarNormal" />
    public class ZeroitProgressBarNormalBoxed : ZeroitProgressBarNormal
    {

        /// <summary>
        /// The active color
        /// </summary>
        public Color activeColor = Color.Red;

        /// <summary>
        /// Gets or sets the color of the active back.
        /// </summary>
        /// <value>The color of the active back.</value>
        [DefaultValue(typeof(Color), "Red")]
        public Color ActiveBackColor
        {
            get { return activeColor; }
            set
            {
                activeColor = value;
                Invalidate();
            }


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarNormalBoxed"/> class.
        /// </summary>
        public ZeroitProgressBarNormalBoxed() : base()
        {

            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            _InnerGridType = InnerGridTypes.Full;

            ActiveBlockColor = activeColor;

            NumberOfBlocks = 5;
        }


        #region Drawing
        /// <summary>
        /// The maximum block to draw
        /// </summary>
        private int _MaxBlockToDraw = -1;
        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        protected override void DrawBackground(Graphics g)
        {


            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
            }
            for (int i = 0; i < _MaxBlockToDraw; i++)
            {
                FillRectangle(g, _BlockRects[i], xBrushes[BrushProgress]);
            }
            if (_MaxBlockToDraw < _NumberOfBlocks && _MaxBlockToDraw > -1)
                FillRectangle(g, _BlockRects[_MaxBlockToDraw], xBrushes[BrushActiveBlock]);

            DrawInnerGrid(g);
        }

        /// <summary>
        /// Draws the inner grid.
        /// </summary>
        /// <param name="g">The g.</param>
        protected void DrawInnerGrid(Graphics g)
        {
            if (_InnerGridType == InnerGridTypes.None)
                return;
            int MaxGrid = 0;
            if (_InnerGridType == InnerGridTypes.UntilActive)
                MaxGrid = _MaxBlockToDraw + 1;
            if (_InnerGridType == InnerGridTypes.Full)
                MaxGrid = _NumberOfBlocks;
            if (MaxGrid > _NumberOfBlocks)
                MaxGrid = _NumberOfBlocks;
            for (int i = 0; i < MaxGrid; i++)
            {
                Point[] PathAround = Zeroit.Framework.Progress.Drawing.MyRectangle.PathAround(_BlockRects[i]);
                g.DrawLine(xPens[PenBorder], PathAround[1], PathAround[2]);
            }

        }


        #endregion

        #region Overrides
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("Value Value"), Category("Progress")]
        public override int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                int Temp = _MaxBlockToDraw;
                _TurnOffInvalidation = true;
                base.Value = value;
                ComputeMaxBlockToDraw();
                if (_MaxBlockToDraw == Temp)
                    _TurnOffInvalidation = true;
                Invalidate();
            }
        }
        #endregion

        #region Blocks
        /// <summary>
        /// Computes the maximum block to draw.
        /// </summary>
        private void ComputeMaxBlockToDraw()
        {
            if (_iPercent > 0)
                _MaxBlockToDraw = (int)System.Math.Floor(_fPercent / 100 * _NumberOfBlocks);
            else
                _MaxBlockToDraw = -1;
            //if (_MaxBlockToDraw > _NumberOfBlocks-1)
            //    _MaxBlockToDraw = _NumberOfBlocks-1;
        }

        /// <summary>
        /// The brush active block
        /// </summary>
        protected const string BrushActiveBlock = "BrushActiveBlock";

        /// <summary>
        /// The inner grid type
        /// </summary>
        private InnerGridTypes _InnerGridType;

        /// <summary>
        /// Gets or sets the type of the inner grid.
        /// </summary>
        /// <value>The type of the inner grid.</value>
        [Description("Inner Grid Type"), Category("Blocks")]
        public InnerGridTypes InnerGridType
        {
            get { return _InnerGridType; }
            set
            {
                _InnerGridType = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The active block color
        /// </summary>
        private Color _ActiveBlockColor = Color.Red;
        /// <summary>
        /// Gets or sets the color of the active block.
        /// </summary>
        /// <value>The color of the active block.</value>
        [Description("Active Block Color"), Category("ProgressApearance")]
        public Color ActiveBlockColor
        {
            get
            {
                return _ActiveBlockColor;
            }
            set
            {
                xBrushes[BrushActiveBlock] = new SolidBrush(value);
                _ActiveBlockColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The number of blocks
        /// </summary>
        private int _NumberOfBlocks;
        /// <summary>
        /// Gets or sets the number of blocks.
        /// </summary>
        /// <value>The number of blocks.</value>
        /// <exception cref="ArgumentOutOfRangeException">NumberOfBlocks - Value must greater than 1</exception>
        [Description("Number of Blocks"), Category("Blocks")]
        public int NumberOfBlocks
        {
            get
            {
                return _NumberOfBlocks;
            }
            set
            {
                if (value < 2)
                    throw new ArgumentOutOfRangeException("NumberOfBlocks", "Value must greater than 1");
                _NumberOfBlocks = value;
                ComputeMaxBlockToDraw();
                PrepareBlocks();
                Invalidate();
            }
        }

        /// <summary>
        /// The block rects
        /// </summary>
        protected Rectangle[] _BlockRects = null;

        /// <summary>
        /// Prepares the blocks.
        /// </summary>
        protected void PrepareBlocks()
        {
            _BlockRects = Zeroit.Framework.Progress.Drawing.MyRectangle.SplitInParts(
                ClientRectangle,
                _NumberOfBlocks,
                Zeroit.Framework.Progress.Drawing.MyRectangle.SplitType.Horizontal
                );
        }
        /// <summary>
        /// Gets the blocks.
        /// </summary>
        /// <returns>Rectangle[].</returns>
        public Rectangle[] GetBlocks()
        {
            return _BlockRects;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            PrepareBlocks();
            base.OnSizeChanged(e);
        }
        #endregion

        #region Hidding Properties
        /// <summary>
        /// Gets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
        }
        /// <summary>
        /// Gets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Browsable(false)]
        public override TextAlignmentTypes TextAlign
        {
            get
            {
                return base.TextAlign;
            }
        }
        /// <summary>
        /// Gets the type of the text color.
        /// </summary>
        /// <value>The type of the text color.</value>
        [Browsable(false)]
        public override TextColorTypes TextColorType
        {
            get
            {
                return base.TextColorType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether display the progress.
        /// </summary>
        /// <value><c>true</c> if display progress; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public override bool DisplayProgress
        {
            get
            {
                return base.DisplayProgress;
            }
        }

        /// <summary>
        /// Gets the roll block percent.
        /// </summary>
        /// <value>The roll block percent.</value>
        [Browsable(false)]
        public override int RollBlockPercent
        {
            get
            {
                return base.RollBlockPercent;
            }
        }
        /// <summary>
        /// Gets the type of rolling.
        /// </summary>
        /// <value>The type of rolling.</value>
        [Browsable(false)]
        public override RollingTypes RollingType
        {
            get
            {
                return base.RollingType;
            }
        }
        /// <summary>
        /// Gets the roll timer.
        /// </summary>
        /// <value>The roll timer.</value>
        [Browsable(false)]
        public override int RollTimer
        {
            get
            {
                return base.RollTimer;
            }
        }

        #endregion

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }


        /// <summary>
        /// Enum that represents InnerGridTypes
        /// </summary>
        public enum InnerGridTypes
        {
            None,
            /// <summary>
            /// The until active
            /// </summary>
            UntilActive,
            /// <summary>
            /// The full
            /// </summary>
            Full
        }
    }

    #endregion

}
