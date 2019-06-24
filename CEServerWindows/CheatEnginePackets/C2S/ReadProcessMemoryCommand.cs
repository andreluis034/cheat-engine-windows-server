using CEServerWindows.CheatEnginePackets.S2C;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class ReadProcessMemoryCommand : CheatEngineCommand<ReadProcessMemoryResponse>
    {
        public IntPtr Handle;
        public UInt64 Address;
        public int Size;
        public bool Compress;

        public override CommandType CommandType => CommandType.CMD_READPROCESSMEMORY;

        public ReadProcessMemoryCommand() { }

        public ReadProcessMemoryCommand(IntPtr handle, UInt64 address, int size, bool compress)
        {
            this.Handle = handle;
            this.Address = address;
            this.Size = size;
            this.Compress = compress;
            this.initialized = true;
        }

        public override void Initialize(BinaryReader reader)
        {
            Handle = (IntPtr)reader.ReadInt32();
            Address = reader.ReadUInt64();
            Size = reader.ReadInt32();
            Compress = reader.ReadByte() == 0 ? false : true;
            this.initialized = true;
        }

        public override ReadProcessMemoryResponse Process()
        {
            var data = new byte[this.Size];
            IntPtr dataRead;
            WindowsAPI.MemoryAPI.ReadProcessMemory(this.Handle, (IntPtr)this.Address, data, this.Size, out dataRead);
            if((int)dataRead < this.Size)
            {
                var data2 = new byte[(int)dataRead];
                Array.Copy(data, 0, data2, 0, data2.Length);
                data = data2;
            }

            return new ReadProcessMemoryResponse(data, this.Compress);
        }
    }
}
