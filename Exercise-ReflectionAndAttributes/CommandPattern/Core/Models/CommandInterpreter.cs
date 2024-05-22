using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    using Core.Contracts;
    using global::Core.Models.Commands;
    using System.Reflection;
    using System.Linq;
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string _commandSuffix = "Command";
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}{_commandSuffix}");

            ICommand command = (ICommand)Activator.CreateInstance(commandType);


            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
