using System;
using System.Linq;
using Trinity.Core.Security;

namespace Trinity.Encore.Game.Commands.System
{
    [Command("Help", "Commands", "Command", "?")]
    public sealed class HelpCommand : Command
    {
        public override string Description
        {
            get { return "Lists all available commands."; }
        }

        public override void Execute(CommandArguments args, ICommandUser sender)
        {
            var commands = CommandManager.Instance.Commands;

            foreach (var cmd in commands.Values.Distinct())
            {
                var perm = cmd.RequiredPermission;
                if (sender != null && perm != null && !sender.HasPermission(perm))
                    continue;

                var cmd1 = cmd;
                var triggers = commands.Where(x => x.Value == cmd1).Select(x => x.Key).ToList();
                var count = triggers.Count;

                for (var i = 0; i < count; i++)
                {
                    Console.Write(triggers[i]);

                    if (i < count - 1)
                        Console.Write("|");
                }

                Console.WriteLine(": {0}", cmd.Description);
            }
        }
    }
}
