using System;
using System.Collections;
using CloneVersionSystem.App;

namespace CloneVersionSystem.CommandSystem.Commands
{
    [CommandName(Name = "learn")]
    class LearnCommand : ICommand
    {
        public ICloneApp App { get; set; }

        public void Do(ArrayList args)
        {
            uint cloneID = (uint)args[0];
            uint courseID = (uint)args[1];

            var course = new CloneSystem.LearningCourse(courseID);

            App.CloneSyst.Learn(cloneID, course);
        }
    }
}
