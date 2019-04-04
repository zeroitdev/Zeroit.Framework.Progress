#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress.CustomControls
{
    //[ProvideProperty("ZeroitFramework", typeof(Control))]
    public class DragControl : Component
    {
        private Drag drag_0 = new Drag();

        private Control control_0;

        private ContainerControl containerControl_0;

        private bool bool_0 = true;

        private bool bool_1 = true;

        private bool bool_2 = true;

        private IContainer icontainer_0;

        private System.Windows.Forms.Timer timer_0;



        private ContainerControl containerControl
        {
            get
            {
                return this.containerControl_0;
            }
            set
            {
                this.containerControl_0 = value;
            }
        }

        public bool Fixed
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

        public bool Horizontal
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                base.Site = value;
                if (value == null)
                {
                    return;
                }
                IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service != null)
                {
                    IComponent rootComponent = service.RootComponent;
                    if (!(rootComponent is ContainerControl))
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
                    this.containerControl = rootComponent as ContainerControl;
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
        }

        public Control TargetControl
        {
            get
            {
                return this.control_0;
            }
            set
            {
                this.control_0 = value;
            }
        }

        public bool Vertical
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public DragControl()
        {
            this.method_3();
            //LicenseUsageMode usageMode = LicenseManager.UsageMode;
        }

        public DragControl(IContainer container)
        {
            container.Add(this);
            this.method_3();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Drag(bool horixontal = true, bool Vertical = true)
        {
            this.drag_0.MoveObject(Vertical, horixontal);
        }

        public void Grab(Control _control)
        {
            this.drag_0.Grab(_control);
        }

        public void Grab()
        {
            Control containerControl0 = this.containerControl_0;
            this.drag_0.Grab(containerControl0);
        }

        private void method_0(object sender, MouseEventArgs e)
        {
            this.Drag(this.Vertical, this.Horizontal);
        }

        private void method_1(object sender, MouseEventArgs e)
        {
            this.Release();
        }

        private void method_2(object sender, MouseEventArgs e)
        {
            if (!this.bool_0)
            {
                this.Grab((Control)sender);
                return;
            }
            Control parent = (Control)sender;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            this.Grab(parent);
        }

        private void method_3()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0)
            {
                Enabled = true,
                Interval = 1
            };
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        public void Release()
        {
            this.drag_0.Release();
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                this.timer_0.Stop();
                Control control0 = this.containerControl;
                if (this.control_0 != null)
                {
                    control0 = this.control_0;
                }
                control0.MouseDown += new MouseEventHandler(this.method_2);
                control0.MouseMove += new MouseEventHandler(this.method_0);
                control0.MouseUp += new MouseEventHandler(this.method_1);
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
    }



}
