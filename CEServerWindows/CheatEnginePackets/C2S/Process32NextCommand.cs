using CEServerWindows.CheatEnginePackets.S2C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class Process32NextCommand : Process32FirstCommand
    {
        public override CommandType CommandType => CommandType.CMD_PROCESS32NEXT;

        public override Process32Response Process()
        {
            WindowsAPI.ToolHelp.PROCESSENTRY32 processEntry = new WindowsAPI.ToolHelp.PROCESSENTRY32();
            processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);

            var result = WindowsAPI.ToolHelp.Process32Next(this.Handle, ref processEntry);

            return new Process32Response(result, processEntry);
        }

    }
}
