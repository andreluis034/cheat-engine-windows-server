using CEServerWindows.CheatEnginePackets.S2C;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class OpenProcessCommand : CheatEngineCommand<HandleResponse>
    {
        public override CommandType CommandType => CommandType.CMD_OPENPROCESS;// throw new NotImplementedException();
        public int ProcessID;
        public OpenProcessCommand()
        {

        }

        public OpenProcessCommand(int pid)
        {
            this.ProcessID = pid;
            this.initialized = true;
        }

        public override void Initialize(BinaryReader reader)
        {
            this.ProcessID = reader.ReadInt32();
            this.initialized = true;
        }

        public override HandleResponse Process()
        {
            IntPtr handle = WindowsAPI.ToolHelp.OpenProcess(
                WindowsAPI.ToolHelp.ProcessAccessFlags.VirtualMemoryRead |
                WindowsAPI.ToolHelp.ProcessAccessFlags.VirtualMemoryWrite |
                WindowsAPI.ToolHelp.ProcessAccessFlags.QueryInformation, 
                false, this.ProcessID);

            return new HandleResponse(handle);
        }
    }
}
