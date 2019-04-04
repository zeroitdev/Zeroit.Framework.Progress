// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="BlockLines.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Imports

using System.Collections;
using System.Drawing;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Progress
{

    #region ZeroitBusyBarBlockLines
    //-----------------------------------------------------------------------------
    // ZeroitBusyBarBlockLines

    /// <summary>
    /// Class ZeroitBusyBarBlockLines.
    /// </summary>
    public class ZeroitBusyBarBlockLines
    {
        /// <summary>
        /// The block width
        /// </summary>
        private float _BlockWidth = 0;
        /// <summary>
        /// The block line width
        /// </summary>
        private float _BlockLineWidth = 0;
        /// <summary>
        /// The block scroll
        /// </summary>
        private bool _BlockScroll = false;
        /// <summary>
        /// The bounds
        /// </summary>
        private RectangleF _Bounds = RectangleF.Empty;
        /// <summary>
        /// The r1
        /// </summary>
        private RectangleF _R1 = RectangleF.Empty;
        /// <summary>
        /// The r2
        /// </summary>
        private RectangleF _R2 = RectangleF.Empty;
        /// <summary>
        /// The r3
        /// </summary>
        private RectangleF _R3 = RectangleF.Empty;
        /// <summary>
        /// The x value
        /// </summary>
        private float _XValue = 0;
        /// <summary>
        /// The y value
        /// </summary>
        private float _YValue = 0;
        //		private ZeroitBusyBar.Pins _Pin = ZeroitBusyBar.Pins.None;

        /// <summary>
        /// The r1 top
        /// </summary>
        private float _R1Top = 0;
        /// <summary>
        /// The r1 left
        /// </summary>
        private float _R1Left = 0;
        /// <summary>
        /// The r1 right
        /// </summary>
        private float _R1Right = 0;
        /// <summary>
        /// The r1 bottom
        /// </summary>
        private float _R1Bottom = 0;
        /// <summary>
        /// The r2 top
        /// </summary>
        private float _R2Top = 0;
        /// <summary>
        /// The r2 left
        /// </summary>
        private float _R2Left = 0;
        /// <summary>
        /// The r2 right
        /// </summary>
        private float _R2Right = 0;
        /// <summary>
        /// The r2 bottom
        /// </summary>
        private float _R2Bottom = 0;
        /// <summary>
        /// The r3 top
        /// </summary>
        private float _R3Top = 0;
        /// <summary>
        /// The r3 left
        /// </summary>
        private float _R3Left = 0;
        /// <summary>
        /// The r3 right
        /// </summary>
        private float _R3Right = 0;
        /// <summary>
        /// The r3 bottom
        /// </summary>
        private float _R3Bottom = 0;

        /// <summary>
        /// The r1 top set
        /// </summary>
        private bool _R1TopSet = false;
        /// <summary>
        /// The r1 left set
        /// </summary>
        private bool _R1LeftSet = false;
        /// <summary>
        /// The r2 top set
        /// </summary>
        private bool _R2TopSet = false;
        /// <summary>
        /// The r2 left set
        /// </summary>
        private bool _R2LeftSet = false;
        /// <summary>
        /// The r3 left set
        /// </summary>
        private bool _R3LeftSet = false;
        /// <summary>
        /// The r3 top set
        /// </summary>
        private bool _R3TopSet = false;

        /// <summary>
        /// Gets or sets the width of the block.
        /// </summary>
        /// <value>The width of the block.</value>
        public float BlockWidth { get { return _BlockWidth; } set { _BlockWidth = value; } }
        /// <summary>
        /// Gets or sets the width of the block line.
        /// </summary>
        /// <value>The width of the block line.</value>
        public float BlockLineWidth { get { return _BlockLineWidth; } set { _BlockLineWidth = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether [block scroll].
        /// </summary>
        /// <value><c>true</c> if [block scroll]; otherwise, <c>false</c>.</value>
        public bool BlockScroll { get { return _BlockScroll; } set { _BlockScroll = value; } }
        /// <summary>
        /// Gets or sets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public RectangleF Bounds { get { return _Bounds; } set { _Bounds = value; } }
        /// <summary>
        /// Gets or sets the r1.
        /// </summary>
        /// <value>The r1.</value>
        public RectangleF R1 { get { return _R1; } set { _R1 = value; } }
        /// <summary>
        /// Gets or sets the r2.
        /// </summary>
        /// <value>The r2.</value>
        public RectangleF R2 { get { return _R2; } set { _R2 = value; } }
        /// <summary>
        /// Gets or sets the r3.
        /// </summary>
        /// <value>The r3.</value>
        public RectangleF R3 { get { return _R3; } set { _R3 = value; } }
        /// <summary>
        /// Gets or sets the x value.
        /// </summary>
        /// <value>The x value.</value>
        public float XValue { get { return _XValue; } set { _XValue = value; } }
        /// <summary>
        /// Gets or sets the y value.
        /// </summary>
        /// <value>The y value.</value>
        public float YValue { get { return _YValue; } set { _YValue = value; } }
        //		public ZeroitBusyBar.Pins Pin { get { return _Pin; } set { _Pin = value; } }

        /// <summary>
        /// Gets the r1 top.
        /// </summary>
        /// <value>The r1 top.</value>
        public float R1Top { get { return _R1Top; } }
        /// <summary>
        /// Gets the r1 left.
        /// </summary>
        /// <value>The r1 left.</value>
        public float R1Left { get { return _R1Left; } }
        /// <summary>
        /// Gets the r1 right.
        /// </summary>
        /// <value>The r1 right.</value>
        public float R1Right { get { return _R1Right; } }
        /// <summary>
        /// Gets the r1 bottom.
        /// </summary>
        /// <value>The r1 bottom.</value>
        public float R1Bottom { get { return _R1Bottom; } }
        /// <summary>
        /// Gets the r2 top.
        /// </summary>
        /// <value>The r2 top.</value>
        public float R2Top { get { return _R2Top; } }
        /// <summary>
        /// Gets the r2 left.
        /// </summary>
        /// <value>The r2 left.</value>
        public float R2Left { get { return _R2Left; } }
        /// <summary>
        /// Gets the r2 right.
        /// </summary>
        /// <value>The r2 right.</value>
        public float R2Right { get { return _R2Right; } }
        /// <summary>
        /// Gets the r2 bottom.
        /// </summary>
        /// <value>The r2 bottom.</value>
        public float R2Bottom { get { return _R2Bottom; } }
        /// <summary>
        /// Gets the r3 top.
        /// </summary>
        /// <value>The r3 top.</value>
        public float R3Top { get { return _R3Top; } }
        /// <summary>
        /// Gets the r3 left.
        /// </summary>
        /// <value>The r3 left.</value>
        public float R3Left { get { return _R3Left; } }
        /// <summary>
        /// Gets the r3 right.
        /// </summary>
        /// <value>The r3 right.</value>
        public float R3Right { get { return _R3Right; } }
        /// <summary>
        /// Gets the r3 bottom.
        /// </summary>
        /// <value>The r3 bottom.</value>
        public float R3Bottom { get { return _R3Bottom; } }

        /// <summary>
        /// Gets the horizontal lines.
        /// </summary>
        /// <value>The horizontal lines.</value>
        public ArrayList HorizontalLines
        {
            get
            {
                ArrayList list = new ArrayList();

                float period = _BlockWidth + _BlockLineWidth;

                if (!_BlockScroll)
                {
                    float xLine = _Bounds.Left - (2 * period);
                    for (; xLine < _Bounds.Right + (2 * period); xLine += period)
                    {
                        bool z = false;

                        if (xLine >= _R1.Left && xLine <= _R1.Right)
                        {
                            if (!_R1LeftSet) { _R1LeftSet = true; _R1Left = xLine; }
                            _R1Right = xLine;
                            z = true;
                        }

                        if (xLine >= _R2.Left && xLine <= _R2.Right)
                        {
                            if (!_R2LeftSet) { _R2LeftSet = true; _R2Left = xLine; }
                            _R2Right = xLine;
                            z = true;
                        }

                        if (xLine >= _R3.Left && xLine <= _R3.Right)
                        {
                            if (!_R3LeftSet) { _R3LeftSet = true; _R3Left = xLine; }
                            _R3Right = xLine;
                            z = true;
                        }

                        if (z) list.Add(xLine);
                    }

                    //					if ( _Pin == ZeroitBusyBar.Pins.End )
                    //					{
                    //						_R2Right += period;
                    //						list.Add( _R2Right );
                    //					}
                }
                // BlockScroll
                else
                {
                    float xLine = 0;

                    xLine = _Bounds.Left - (2 * period);
                    xLine += _XValue % period;
                    xLine -= _Bounds.Width % period;
                    for (; xLine < _Bounds.Right + (2 * period); xLine += period)
                        if (xLine >= _R1.Left && xLine <= _R1.Right)
                        {
                            if (!_R1LeftSet) { _R1LeftSet = true; _R1Left = xLine; }
                            _R1Right = xLine;
                            list.Add(xLine);
                        }

                    xLine = _Bounds.Left - (2 * period);
                    xLine += _XValue % period;
                    for (; xLine < _Bounds.Right + (2 * period); xLine += period)
                        if (xLine >= _R2.Left && xLine <= _R2.Right)
                        {
                            if (!_R2LeftSet) { _R2LeftSet = true; _R2Left = xLine; }
                            _R2Right = xLine;
                            list.Add(xLine);
                        }

                    xLine = _Bounds.Left - (2 * period);
                    xLine += _XValue % period;
                    xLine += _Bounds.Width % period;
                    for (; xLine < _Bounds.Right + (2 * period); xLine += period)
                        if (xLine >= _R3.Left && xLine <= _R3.Right)
                        {
                            if (!_R3LeftSet) { _R3LeftSet = true; _R3Left = xLine; }
                            _R3Right = xLine;
                            list.Add(xLine);
                        }
                }

                return list;
            }
        }
        /// <summary>
        /// Gets the vertical lines.
        /// </summary>
        /// <value>The vertical lines.</value>
        public ArrayList VerticalLines
        {
            get
            {
                ArrayList list = new ArrayList();

                float period = _BlockWidth + _BlockLineWidth;

                if (!_BlockScroll)
                {
                    float yLine = _Bounds.Top - (2 * period);
                    for (; yLine < _Bounds.Bottom + (2 * period); yLine += period)
                    {
                        bool z = false;

                        if (yLine >= _R1.Top && yLine <= _R1.Bottom)
                        {
                            if (!_R1TopSet) { _R1TopSet = true; _R1Top = yLine; }
                            _R1Bottom = yLine;
                            z = true;
                        }

                        if (yLine >= _R2.Top && yLine <= _R2.Bottom)
                        {
                            if (!_R2TopSet) { _R2TopSet = true; _R2Top = yLine; }
                            _R2Bottom = yLine;
                            z = true;
                        }

                        if (yLine >= _R3.Top && yLine <= _R3.Bottom)
                        {
                            if (!_R3TopSet) { _R3TopSet = true; _R3Top = yLine; }
                            _R3Bottom = yLine;
                            z = true;
                        }

                        if (z) list.Add(yLine);
                    }
                }
                else
                {
                    float yLine = 0;

                    yLine = _Bounds.Top - (2 * period);
                    yLine += _YValue % period;
                    yLine -= _Bounds.Height % period;
                    for (; yLine < _Bounds.Bottom + (2 * period); yLine += period)
                        if (yLine >= _R1.Top && yLine <= _R1.Bottom)
                        {
                            if (!_R1TopSet) { _R1TopSet = true; _R1Top = yLine; }
                            _R1Bottom = yLine;
                            list.Add(yLine);
                        }

                    yLine = _Bounds.Top - (2 * period);
                    yLine += _YValue % period;
                    for (; yLine < _Bounds.Bottom + (2 * period); yLine += period)
                        if (yLine >= _R2.Top && yLine <= _R2.Bottom)
                        {
                            if (!_R2TopSet) { _R2TopSet = true; _R2Top = yLine; }
                            _R2Bottom = yLine;
                            list.Add(yLine);
                        }

                    yLine = _Bounds.Top - (2 * period);
                    yLine += _YValue % period;
                    yLine += _Bounds.Height % period;
                    for (; yLine < _Bounds.Bottom + (2 * period); yLine += period)
                        if (yLine >= _R3.Top && yLine <= _R3.Bottom)
                        {
                            if (!_R3TopSet) { _R3TopSet = true; _R3Top = yLine; }
                            _R3Bottom = yLine;
                            list.Add(yLine);
                        }
                }

                return list;
            }
        }
    }

    #endregion

}
