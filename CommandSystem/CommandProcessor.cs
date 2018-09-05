using System;
using System.Collections;
using System.Collections.Generic;

namespace CloneVersionSystem.CommandSystem
{
    class CommandProcessor
    {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
        public bool ExitState { get; set; }

        public void AddCommand(ICommand cmd)
        {
            var name = GetName(cmd);

            name = name.Replace("Command", "");

            _commands.Add(name, cmd);
        }

        private string GetName(ICommand cmd)
        {
            var attrs = cmd.GetType().GetCustomAttributes(false);

            foreach (var attr in attrs)
            {
                var nameAttr = attr as CommandNameAttribute;
                if (nameAttr == null)
                    continue;

                return nameAttr.Name;
            }

            return cmd.GetType().Name;
        }

        public void ProcessCommands()
        {
            while(true)
            {
                var line = Console.ReadLine();

                var cmd = GetCommand(line);
                var args = GetArguments(line);

                if (cmd != null)
                {
                    cmd.Do(ParseArguments(args));
                }
                else
                {
                    Console.WriteLine("Unknown command\n");
                    PrintAllCmds();
                }

                if (ExitState)
                    break;
            }
        }

        private ICommand GetCommand(string line)
        {
            ICommand cmd = null;

            var cmdName = GetCommandString(line);

            _commands.TryGetValue(cmdName, out cmd);

            return cmd;
        }

        private string GetCommandString(string line)
        {
            int index = line.IndexOf(" ");

            if (index > 0)
                return line.Substring(0, index);
            return line;
        }

        private string GetArguments(string line)
        {
            var cmd = GetCommandString(line);

            return line.Replace(cmd, "");
        }

        private ArrayList ParseArguments(string line)
        {
            var args = new ArrayList();

            foreach(string arg in line.Split(' '))
            {
                if (arg.Length > 0)
                    args.Add(Convert.ToUInt32(arg));
            }

            return args;
        }

        public void PrintAllCmds()
        {
            foreach (var cmdName in _commands.Keys)
            {
                Console.WriteLine(cmdName);
            }
        }
    }
}
