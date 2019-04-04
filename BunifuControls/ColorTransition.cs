using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Zeroit.Framework.Progress.CustomControls
{
    public class BunifuColorTransition : Component
    {
        private int int_0;

        private Color color_0 = Color.White;

        private Color color_1 = Color.White;

        private Color color_2 = Color.White;

        private IContainer icontainer_0;

        EventHandler eventHandler_0;

        public Color Color1
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                this.method_0();
            }
        }

        public Color Color2
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                this.method_0();
            }
        }

        public int ProgessValue
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                this.method_0();
            }
        }

        public Color Value
        {
            get
            {
                return this.color_2;
            }
        }

        public BunifuColorTransition()
        {
            this.method_1();
        }

        public BunifuColorTransition(IContainer container)
        {
            container.Add(this);
            this.method_1();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public static Color getColorScale(int Passentage, Color startColor, Color endColor)
        {
            Color color;
            try
            {
                double num = Math.Round((double)startColor.R + (double)((endColor.R - startColor.R) * Passentage) * 0.01, 0);
                int num1 = int.Parse(num.ToString());
                num = Math.Round((double)startColor.G + (double)((endColor.G - startColor.G) * Passentage) * 0.01, 0);
                int num2 = int.Parse(num.ToString());
                num = Math.Round((double)startColor.B + (double)((endColor.B - startColor.B) * Passentage) * 0.01, 0);
                int num3 = int.Parse(num.ToString());
                color = Color.FromArgb(255, num1, num2, num3);
            }
            catch (Exception exception)
            {
                color = startColor;
            }
            return color;
        }

        private void method_0()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            Color colorScale = BunifuColorTransition.getColorScale(this.ProgessValue, this.Color1, this.Color2);
            if (colorScale != this.Value)
            {
                this.color_2 = colorScale;
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
                    return;
                }
                this.eventHandler_0(this, new EventArgs());
                return;
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

        private void method_1()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
        }

        public event EventHandler OnValueChange
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
