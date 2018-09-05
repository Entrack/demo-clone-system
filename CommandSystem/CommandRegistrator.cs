using System;
using System.Collections.Generic;

namespace CloneVersionSystem.CommandSystem
{
    class CommandRegistrator
    {
        public List<ICommand> GetCommands()
        {
            var cmds = new List<ICommand>();

            var assemblyType = typeof(CommandRegistrator);

            foreach (var type in assemblyType.Assembly.GetTypes())
            {
                if (!type.IsClass)
                    continue;
                if (type.IsAbstract)
                    continue;

                if (typeof(ICommand).IsAssignableFrom(type))
                {
                    cmds.Add(Activator.CreateInstance(type) as ICommand);
                }
            }

            return cmds;
        }
    }
}
