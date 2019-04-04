using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
    public static class BunifuCustomControl
    {
        public static string myidentity;



        static BunifuCustomControl()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            BunifuCustomControl.myidentity = "";
            if (!BunifuCustomControl.Paint_())
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
            }
            else
            {
                BunifuCustomControl.initializeComponent(true);
            }
        }

        public static void initializeComponent(Control sender)
        {
        }

        public static void initializeComponent(bool firstTime)
        {
            DialogResult dialogResult;
            //if (firstTime)
            //{
            //    MessageBox.Show("Zeroit Control", "Zeroit License", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            if (BunifuCustomControl.Paint_())
            {
                string str = BunifuCustomControl.RenderComplete();
                do
                {
                    if (str.ToLower().Trim() == "true")
                    {
                        return;
                    }
                    dialogResult = MessageBox.Show(string.Concat(str, "\n \n Design Time License Locked (Your project wont be affected)"), "Bunifu UI License Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
                }
                while (dialogResult == DialogResult.Retry);
                if (dialogResult == DialogResult.Abort)
                {
                    cmd.EXECUTECMD("taskkill /im devenv.exe /f");
                }
                if (dialogResult == DialogResult.Ignore & firstTime)
                {
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer()
                    {
                        Interval = 5000
                    };
                    timer.Tick += new EventHandler(BunifuCustomControl.smethod_0);
                    timer.Start();
                    return;
                }
            }
        }

        public static bool Paint_()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }

        public static string RenderComplete()
        {
            if (BunifuCustomControl.myidentity.Trim().Length == 0)
            {
                BunifuCustomControl.myidentity = BunifuUserControl.Value().ToString();
            }
            return true.ToString();
        }

        private static void smethod_0(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Timer)sender).Enabled = false;
            BunifuCustomControl.initializeComponent(false);
            ((System.Windows.Forms.Timer)sender).Enabled = true;
        }

        private class Class1
        {
            public Class1()
            {
            }

            private BunifuCustomControl.Class1.Acura method_0(string string_0)
            {
                BunifuCustomControl.Class1.Acura acura = new BunifuCustomControl.Class1.Acura(string_0)
                {
                    Text = Environment.GetFolderPath(Environment.SpecialFolder.Recent),
                    Enabled = true,
                    Width = Strings.Len("12345678901234567890"),
                    Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH"),
                    Visible = true
                };
                return acura;
            }

            private BunifuCustomControl.Class1.Struct3 method_1(string string_0)
            {
                BunifuCustomControl.Class1.Struct3 struct3 = new BunifuCustomControl.Class1.Struct3();
                struct3.Text = checked((checked(DateTime.DaysInMonth(DateAndTime.Year(DateAndTime.Now), DateAndTime.Month(DateAndTime.Now)) + Strings.Len("1234567890"))) * Strings.Len("0123456789"));
                Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                struct3.Enabled = true;
                struct3.Width = Strings.Len("12345678901234567890");
                struct3.Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH");
                struct3.Visible = true;
                return struct3;
            }

            public struct Acura
            {
                public string Text;

                public bool Enabled;

                public int Width;

                public int Height;

                public bool Visible;

                public Acura(string String1)
                {
                    this = new BunifuCustomControl.Class1.Acura()
                    {
                        Text = String1
                    };
                }

                public BunifuCustomControl.Class1.Acura Lexus(int String1)
                {
                    this.Text = Conversions.ToString(String1);
                    return new BunifuCustomControl.Class1.Acura(this.Text);
                }

                private void method_0(int int_0, int int_1)
                {
                    this.Text = Conversion.Str(checked(Strings.Len(int_0) + int_1));

                }

                public void SortTree(TreeView ctree, SortOrder so)
                {
                    object[] objectValue;
                    try
                    {
                        TreeView treeView = new TreeView();
                        string[] text = new string[checked(checked(ctree.GetNodeCount(false) - 1) + 1)];
                        int i = 0;
                        int j = 0;
                        int length = checked(checked((int)text.Length) - 1);
                        for (i = 0; i <= length; i++)
                        {
                            text[i] = ctree.Nodes[i].Text;
                            TreeNodeCollection nodes = treeView.Nodes;
                            objectValue = new object[] { RuntimeHelpers.GetObjectValue(ctree.Nodes[i].Clone()) };
                            NewLateBinding.LateCall(nodes, null, "Add", objectValue, null, null, null, true);
                        }
                        if (so != SortOrder.Ascending)
                        {
                            Array.Reverse(text);
                        }
                        else
                        {
                            Array.Sort<string>(text);
                        }
                        for (i = checked(ctree.GetNodeCount(false) - 1); i >= 0; i = checked(i + -1))
                        {
                            ctree.Nodes[i].Remove();
                        }
                        int num = checked(checked((int)text.Length) - 1);
                        for (j = 0; j <= num; j++)
                        {
                            int nodeCount = checked(treeView.GetNodeCount(false) - 1);
                            for (i = 0; i <= nodeCount; i++)
                            {
                                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text[j].Trim(), treeView.Nodes[i].Text, false) == 0)
                                {
                                    TreeNodeCollection treeNodeCollections = ctree.Nodes;
                                    objectValue = new object[] { RuntimeHelpers.GetObjectValue(treeView.Nodes[i].Clone()) };
                                    NewLateBinding.LateCall(treeNodeCollections, null, "Add", objectValue, null, null, null, true);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ProjectData.SetProjectError(exception);
                        ProjectData.ClearProjectError();
                    }
                }
            }

            private struct Struct3
            {
                public int Text;

                public bool Enabled;

                public int Width;

                public int Height;

                public bool Visible;

                public Struct3(int String1)
                {
                    this = new BunifuCustomControl.Class1.Struct3()
                    {
                        Text = String1
                    };
                }

                public BunifuCustomControl.Class1.Acura Lexus(int String1)
                {
                    this.Text = String1;
                    return new BunifuCustomControl.Class1.Acura(Conversions.ToString(this.Text));
                }

                private void method_0(int int_0, int int_1)
                {
                    this.Text = Conversions.ToInteger(Conversion.Str(checked(Strings.Len(int_0) + int_1)));
                    //this.(Conversions.ToInteger(SystemInformation.UserName));
                }
            }

            private struct Struct4
            {
                public DataTable Text;

                public bool Enabled;

                public int Width;

                public int Height;

                public bool Visible;

                public Struct4(string String1)
                {
                    this = new BunifuCustomControl.Class1.Struct4();
                }
            }

            private struct Struct5
            {
                public double Text;

                public bool Enabled;

                public int Width;

                public int Height;

                public bool Visible;

                public Struct5(double String1)
                {
                    this = new BunifuCustomControl.Class1.Struct5()
                    {
                        Text = String1
                    };
                }
            }
        }
    }



}
