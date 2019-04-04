using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	public static class BunifuUserControl
	{
		private static string string_0;

		private static string string_1;

		static BunifuUserControl()
		{
			BunifuUserControl.string_0 = "";
			BunifuUserControl.string_1 = string.Empty;
		}

		private static string GetHexString(IList<byte> bt)
		{
			char chr;
			string empty = string.Empty;
			for (int i = 0; i < bt.Count; i++)
			{
				byte item = bt[i];
				int num = item & 15;
				int num1 = item >> 4 & 15;
				if (num1 <= 9)
				{
					empty = string.Concat(empty, num1.ToString(CultureInfo.InvariantCulture));
				}
				else
				{
					chr = (char)(num1 - 10 + 65);
					empty = string.Concat(empty, chr.ToString(CultureInfo.InvariantCulture));
				}
				if (num <= 9)
				{
					empty = string.Concat(empty, num.ToString(CultureInfo.InvariantCulture));
				}
				else
				{
					chr = (char)(num - 10 + 65);
					empty = string.Concat(empty, chr.ToString(CultureInfo.InvariantCulture));
				}
				if (i + 1 != bt.Count && (i + 1) % 2 == 0)
				{
					empty = string.Concat(empty, "-");
				}
			}
			return empty;
		}

		private static string smethod_0(string string_2, string string_3, string string_4)
		{
			string str = "";
			foreach (ManagementBaseObject instance in (new ManagementClass(string_2)).GetInstances())
			{
				if (instance[string_4].ToString() != "True" || str != "")
				{
					continue;
				}
				try
				{
					str = instance[string_3].ToString();
					return str;
				}
				catch
				{
				}
			}
			return str;
		}

		private static string smethod_1(string string_2, string string_3)
		{
			string str = "";
			foreach (ManagementBaseObject instance in (new ManagementClass(string_2)).GetInstances())
			{
				if (str != "")
				{
					continue;
				}
				try
				{
					str = instance[string_3].ToString();
					return str;
				}
				catch
				{
				}
			}
			return str;
		}

		private static string smethod_2()
		{
			return string.Concat(BunifuUserControl.smethod_1("Win32_DiskDrive", "Model"), BunifuUserControl.smethod_1("Win32_DiskDrive", "Manufacturer"), BunifuUserControl.smethod_1("Win32_DiskDrive", "Signature"), BunifuUserControl.smethod_1("Win32_DiskDrive", "TotalHeads"));
		}

		private static string smethod_3()
		{
			return string.Concat(BunifuUserControl.smethod_1("Win32_VideoController", "DriverVersion"), BunifuUserControl.smethod_1("Win32_VideoController", "Name"));
		}

		private static string smethod_4()
		{
			return BunifuUserControl.smethod_0("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
		}

		private static string smethod_5(string string_2)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.ASCII.GetBytes(string_2);
			return BunifuUserControl.GetHexString(mD5CryptoServiceProvider.ComputeHash(bytes));
		}

		private static string smethod_6()
		{
			return string.Concat(BunifuUserControl.smethod_1("Win32_BaseBoard", "Model"), BunifuUserControl.smethod_1("Win32_BaseBoard", "Manufacturer"), BunifuUserControl.smethod_1("Win32_BaseBoard", "Name"), BunifuUserControl.smethod_1("Win32_BaseBoard", "SerialNumber"));
		}

		private static string smethod_7()
		{
			string str = BunifuUserControl.smethod_1("Win32_Processor", "UniqueId");
			if (str != "")
			{
				return str;
			}
			str = BunifuUserControl.smethod_1("Win32_Processor", "ProcessorId");
			if (str != "")
			{
				return str;
			}
			str = BunifuUserControl.smethod_1("Win32_Processor", "Name");
			if (str == "")
			{
				str = BunifuUserControl.smethod_1("Win32_Processor", "Manufacturer");
			}
			str = string.Concat(str, BunifuUserControl.smethod_1("Win32_Processor", "MaxClockSpeed"));
			return str;
		}

		private static string smethod_8()
		{
			return string.Concat(new string[] { BunifuUserControl.smethod_1("Win32_BIOS", "Manufacturer"), BunifuUserControl.smethod_1("Win32_BIOS", "SMBIOSBIOSVersion"), BunifuUserControl.smethod_1("Win32_BIOS", "IdentificationCode"), BunifuUserControl.smethod_1("Win32_BIOS", "SerialNumber"), BunifuUserControl.smethod_1("Win32_BIOS", "ReleaseDate"), BunifuUserControl.smethod_1("Win32_BIOS", "Version") });
		}

		public static string Value()
		{
			if (string.IsNullOrEmpty(BunifuUserControl.string_1))
			{
				BunifuUserControl.string_1 = BunifuUserControl.smethod_5(string.Concat(new string[] { "CPU: ", BunifuUserControl.smethod_7(), " BIOS: ", BunifuUserControl.smethod_8(), " BASE: ", BunifuUserControl.smethod_6(), " VIDEO: ", BunifuUserControl.smethod_3() }));
			}
			return BunifuUserControl.string_1;
		}

		private class Class2
		{
			public Class2()
			{
			}

			private BunifuUserControl.Class2.Acura method_0(string string_0)
			{
				BunifuUserControl.Class2.Acura acura = new BunifuUserControl.Class2.Acura(string_0)
				{
					Text = Environment.GetFolderPath(Environment.SpecialFolder.Recent),
					Enabled = true,
					Width = Strings.Len("12345678901234567890"),
					Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH"),
					Visible = true
				};
				return acura;
			}

			private BunifuUserControl.Class2.Struct6 method_1(string string_0)
			{
				BunifuUserControl.Class2.Struct6 struct6 = new BunifuUserControl.Class2.Struct6();
				struct6.Text = checked((checked(DateTime.DaysInMonth(DateAndTime.Year(DateAndTime.Now), DateAndTime.Month(DateAndTime.Now)) + Strings.Len("1234567890"))) * Strings.Len("0123456789"));
				Environment.GetFolderPath(Environment.SpecialFolder.Recent);
				struct6.Enabled = true;
				struct6.Width = Strings.Len("12345678901234567890");
				struct6.Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH");
				struct6.Visible = true;
				return struct6;
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
					this = new BunifuUserControl.Class2.Acura()
					{
						Text = String1
					};
				}

				public BunifuUserControl.Class2.Acura Lexus(int String1)
				{
					this.Text = Conversions.ToString(String1);
					return new BunifuUserControl.Class2.Acura(this.Text);
				}

				private void method_0(int int_0, int int_1)
				{
					this.Text = Conversion.Str(checked(Strings.Len(int_0) + int_1));
					//this.(Conversions.ToInteger(SystemInformation.UserName));
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

			private struct Struct6
			{
				public int Text;

				public bool Enabled;

				public int Width;

				public int Height;

				public bool Visible;

				public Struct6(int String1)
				{
					this = new BunifuUserControl.Class2.Struct6()
					{
						Text = String1
					};
				}

				public BunifuUserControl.Class2.Acura Lexus(int String1)
				{
					this.Text = String1;
					return new BunifuUserControl.Class2.Acura(Conversions.ToString(this.Text));
				}

				private void method_0(int int_0, int int_1)
				{
					this.Text = Conversions.ToInteger(Conversion.Str(checked(Strings.Len(int_0) + int_1)));
					//this.(Conversions.ToInteger(SystemInformation.UserName));
				}
			}

			private struct Struct7
			{
				public DataTable Text;

				public bool Enabled;

				public int Width;

				public int Height;

				public bool Visible;

				public Struct7(string String1)
				{
					this = new BunifuUserControl.Class2.Struct7();
				}
			}

			private struct Struct8
			{
				public double Text;

				public bool Enabled;

				public int Width;

				public int Height;

				public bool Visible;

				public Struct8(double String1)
				{
					this = new BunifuUserControl.Class2.Struct8()
					{
						Text = String1
					};
				}
			}
		}
	}
}