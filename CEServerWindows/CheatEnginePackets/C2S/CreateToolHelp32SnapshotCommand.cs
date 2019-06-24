using CEServerWindows.CheatEnginePackets.S2C;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CEServerWindows.WindowsAPI;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class CreateToolHelp32SnapshotCommand : CheatEngineCommand<HandleResponse>
    {
        public WindowsAPI.ToolHelp.SnapshotFlags SnapshotFlags;
        public uint ProcessID;

        public sealed override CommandType CommandType => CommandType.CMD_CREATETOOLHELP32SNAPSHOT;// throw new NotImplementedException();

        public CreateToolHelp32SnapshotCommand()
        {

        }
        public CreateToolHelp32SnapshotCommand(WindowsAPI.ToolHelp.SnapshotFlags snapshotFlags, uint pid)
        {
            this.SnapshotFlags = snapshotFlags;
            this.ProcessID = pid;
            this.initialized = true;
        }

        public override HandleResponse Process()
        {
            if (!this.initialized)
            {
                throw new Exceptions.CommandNotInitializedException();
            }
            IntPtr handle = ToolHelp.CreateToolhelp32Snapshot(this.SnapshotFlags, this.ProcessID);

            return new HandleResponse(handle);
        }

        public override void Initialize(BinaryReader reader)
        {
            this.SnapshotFlags = (WindowsAPI.ToolHelp.SnapshotFlags)reader.ReadUInt32();
            this.ProcessID = reader.ReadUInt32();
            this.initialized = true;

        }
    }
}
