using Core.Models.Commands;

namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);

    }
}
