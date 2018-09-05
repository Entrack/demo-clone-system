using System;
using System.Collections.Generic;


namespace CloneVersionSystem.App
{
    interface ICloneApp
    {
        CommandSystem.CommandProcessor CmdProc { get; }
        CloneSystem.CloneSystem CloneSyst { get; }
    }
}
