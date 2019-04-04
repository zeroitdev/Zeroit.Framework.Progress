using System;
using System.Management;


namespace Zeroit.Framework.Progress.CustomControls
{
    public static class identity
    {
        public static string getMotherBoardID()
        {
            string str;
            string str1 = "";
            try
            {
                foreach (ManagementBaseObject managementBaseObject in (new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")).Get())
                {
                    str1 = ((ManagementObject)managementBaseObject)["SerialNumber"].ToString();
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = str1;
            }
            return str;
        }

        private static string smethod_0()
        {
            string str = identity.smethod_1("Win32_Processor", "UniqueId");
            if (str != "")
            {
                return str;
            }
            str = identity.smethod_1("Win32_Processor", "ProcessorId");
            if (str != "")
            {
                return str;
            }
            str = identity.smethod_1("Win32_Processor", "Name");
            if (str == "")
            {
                str = identity.smethod_1("Win32_Processor", "Manufacturer");
            }
            str = string.Concat(str, identity.smethod_1("Win32_Processor", "MaxClockSpeed"));
            return str;
        }

        private static string smethod_1(string string_0, string string_1)
        {
            string str = "";
            foreach (ManagementBaseObject instance in (new ManagementClass(string_0)).GetInstances())
            {
                if (str != "")
                {
                    continue;
                }
                try
                {
                    str = instance[string_1].ToString();
                    return str;
                }
                catch
                {
                }
            }
            return str;
        }
    }
}
