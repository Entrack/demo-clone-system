﻿using System;
using System.Collections;
using CloneVersionSystem.App;

namespace CloneVersionSystem.CommandSystem.Commands
{
    [CommandName(Name = "clone")]
    class CloneCommand : ICommand
    {
        public ICloneApp App { get; set; }

        public void Do(ArrayList args)
        {
            uint cloneID = (uint)args[0];

            App.CloneSyst.Clone(cloneID);
        }
    }
}
