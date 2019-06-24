using CEServerWindows.CheatEnginePackets.S2C;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class CloseHandleCommand : CheatEngineCommand<CloseHandleResponse>
    {
        public IntPtr Handle;
        public override CommandType CommandType => CommandType.CMD_CLOSEHANDLE;

        public CloseHandleCommand()
        {

        }
        public CloseHandleCommand(IntPtr handle)
        {
            this.Handle = handle;
            this.initialized = true;
        }

        public override void Initialize(BinaryReader reader)
        {
            this.Handle = (IntPtr)reader.ReadUInt32();
            this.initialized = true;
        }

        public override CloseHandleResponse Process()
        {
           return new CloseHandleResponse(WindowsAPI.ToolHelp.CloseHandle(this.Handle));
        }
    }
}
