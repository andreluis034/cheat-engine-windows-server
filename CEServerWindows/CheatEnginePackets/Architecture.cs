using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEServerWindows.CheatEnginePackets
{
    //https://github.com/cheat-engine/cheat-engine/blob/master/Cheat%20Engine/ceserver/ceserver.c#L137-L153
    public enum Architecture
    {
        i386 = 1,
        x86_64 = 2,
        arm = 3,
        aarch = 4
    }
}
