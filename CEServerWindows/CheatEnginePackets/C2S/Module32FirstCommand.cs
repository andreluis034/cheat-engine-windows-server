using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class Module32FirstCommand : CheatEngineCommand<S2C.Module32Response>
    {
        public override CommandType CommandType => CommandType.CMD_MODULE32FIRST;

        public IntPtr Handle;
        public Module32FirstCommand()
        {
        }

        public Module32FirstCommand(IntPtr handle)
        {
            this.Handle = handle;
            this.initialized = true;
        }

        public sealed override void Initialize(BinaryReader reader)
        {
            this.Handle = (IntPtr)reader.ReadUInt32();
            this.initialized = true;
        }

        public override S2C.Module32Response Process()
        {
            WindowsAPI.ToolHelp.MODULEENTRY32 moduleEntry = new WindowsAPI.ToolHelp.MODULEENTRY32();
            moduleEntry.dwSize = (uint)Marshal.SizeOf(moduleEntry);

            var result = WindowsAPI.ToolHelp.Module32First(this.Handle, ref moduleEntry);

            return new S2C.Module32Response(result, moduleEntry);
        }
    }
}
