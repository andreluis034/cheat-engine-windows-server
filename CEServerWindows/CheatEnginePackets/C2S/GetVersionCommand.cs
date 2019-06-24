using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CEServerWindows.CheatEnginePackets.S2C;

namespace CEServerWindows.CheatEnginePackets.C2S
{
    public class GetVersionCommand : CheatEngineCommand<GetVersionResponse>
    {
        public sealed override CommandType CommandType => CommandType.CMD_GETVERSION;

        public GetVersionCommand()
        {
            this.initialized = true;
        }

        public sealed override void Initialize(BinaryReader reader)
        {
            this.initialized = true;
        }

        public override GetVersionResponse Process()
        {
            if(!this.initialized)
            {
                throw new Exceptions.CommandNotInitializedException();
            }
            return new GetVersionResponse();
        }
    }
}
