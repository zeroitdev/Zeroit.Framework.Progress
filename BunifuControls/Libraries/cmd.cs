using System;
using System.Diagnostics;

namespace Zeroit.Framework.Progress.CustomControls
{

    [DebuggerStepThrough]
    internal static class cmd
    {
        private static Process process_0;

        internal static void EXECUTECMD(string CMD)
        {
            cmd.process_0 = new Process();
            cmd.process_0.StartInfo.FileName = "CMD.exe";
            cmd.process_0.StartInfo.Arguments = string.Concat("/C ", CMD);
            cmd.process_0.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.process_0.Start();
            cmd.process_0.WaitForExit();
        }
    }

}
