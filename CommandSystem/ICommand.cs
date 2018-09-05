using System;
using System.Collections;

namespace CloneVersionSystem.CommandSystem
{
    interface ICommand
    {
        App.ICloneApp App { get; set; }

        void Do(ArrayList args);
    }
}
