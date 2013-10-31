// -----------------------------------------------------------------------
// <copyright file="Command.cs" company="">
// Telerik
// </copyright>
// -----------------------------------------------------------------------

namespace FreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    public class Command : ICommand
    {
        private readonly char[] ParameterSeparators = { ';' };
        private readonly char CommandEndSymbol = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.InitialParse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("The command name cannot contain ':' or ';'");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    return CommandType.AddBook;

                case "Add movie":
                    return CommandType.AddMovie;

                case "Add song":
                    return CommandType.AddSong;

                case "Add application":
                    return CommandType.AddApplication;

                case "Update":
                    return CommandType.Update;

                case "Find":
                    return CommandType.Find;

                default:
                    throw new FormatException("Invalid command name!");
            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsStartIndex = this.commandNameEndIndex + 3;
            int paramsLength = this.OriginalForm.Length - paramsStartIndex;

            string paramsOriginalForm = this.OriginalForm.Substring(paramsStartIndex, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.ParameterSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.CommandEndSymbol) - 1;

            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name + " ");

            foreach (string param in this.Parameters)
            {
                result.Append(param + " ");
            }

            return result.ToString();
        }
        
        private void InitialParse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
