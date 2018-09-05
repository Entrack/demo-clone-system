using System;
using System.Collections;
using CloneVersionSystem.App;

namespace CloneVersionSystem.CommandSystem.Commands
{
    [CommandName(Name = "exit")]
    class ExitCommand : ICommand
    {
        public ICloneApp App { get; set; }

        public void Do(ArrayList args)
        {
            App.CmdProc.ExitState = true;
        }
    }
}
