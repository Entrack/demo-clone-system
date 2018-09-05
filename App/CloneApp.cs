using System;
using CloneVersionSystem.CommandSystem;
using CloneVersionSystem.CloneSystem;

namespace CloneVersionSystem.App
{
    class CloneApp : ICloneApp
    {
        public CommandSystem.CommandProcessor CmdProc { get; set; }
        public CloneSystem.CloneSystem CloneSyst { get; set; }

        public void InitApp()
        {
            CmdProc = new CommandProcessor();
            CloneSyst = new CloneSystem.CloneSystem();

            CreateDefaults();
            RegisterCommands();
        }

        private void CreateDefaults()
        {
            CloneSyst.CreateDefaultArmy();
        }

        public void RegisterCommands()
        {
            var reg = new CommandRegistrator();
            var cmds = reg.GetCommands();

            foreach (var cmd in cmds)
            {
                cmd.App = this;
                CmdProc.AddCommand(cmd);
            }
        }

        public void Run()
        {
            CmdProc.ProcessCommands();
        }
    }
}
