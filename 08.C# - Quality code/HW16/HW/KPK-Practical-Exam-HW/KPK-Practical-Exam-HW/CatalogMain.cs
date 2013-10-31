namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CatalogMain
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder(); 
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> userCommands = ReadUserCommands();
            foreach (ICommand comand in userCommands)
            {
                commandExecutor.ExecuteCommand(catalog, comand, output); 
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadUserCommands()
        {
            List<ICommand> commands = new List<ICommand>();

            do
            {
                string line = Console.ReadLine();
                if (line.Trim() == "End")
                {
                    break;
                }

                commands.Add(new Command(line));
            }
            while (true);

            return commands;
        }
    }
}
