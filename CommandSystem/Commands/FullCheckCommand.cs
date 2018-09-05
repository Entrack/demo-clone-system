using System;
using System.Collections;
using CloneVersionSystem.App;

namespace CloneVersionSystem.CommandSystem.Commands
{
    [CommandName(Name = "fchk")]
    class FullCheckCommand : ICommand
    {
        public ICloneApp App { get; set; }

        public void Do(ArrayList args)
        {
            uint cloneID = (uint)args[0];

            App.CloneSyst.FullCheck(cloneID);
        }
    }
}
