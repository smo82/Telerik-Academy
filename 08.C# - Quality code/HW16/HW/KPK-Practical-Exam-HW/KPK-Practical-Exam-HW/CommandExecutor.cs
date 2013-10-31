// -----------------------------------------------------------------------
// <copyright file="CommandExecutor.cs" company="">
// Telerik
// </copyright>
// -----------------------------------------------------------------------

namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    ExecuteAddBookCommand(catalog, command, output);
                    break;

                case CommandType.AddMovie:
                    ExecuteAddMovieCommand(catalog, command, output);
                    break;

                case CommandType.AddSong:
                    ExecuteAddSongCommand(catalog, command, output);
                    break;

                case CommandType.AddApplication:
                    ExecuteAddApplicationCommand(catalog, command, output);
                    break;

                case CommandType.Update:
                    ExecuteUpdateCommand(catalog, command, output);
                    break;

                case CommandType.Find:
                    ExecuteFindCommand(catalog, command, output);
                    break;

                default:
                    {
                        throw new InvalidOperationException("Unknown command!");
                    }
            }
        }

        private static void ExecuteAddBookCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            catalog.Add(new ContentItem(ItemType.Book, command.Parameters));
            output.AppendLine("Book added");
        }

        private static void ExecuteAddMovieCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            catalog.Add(new ContentItem(ItemType.Movie, command.Parameters));
            output.AppendLine("Movie added");
        }

        private static void ExecuteAddSongCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            catalog.Add(new ContentItem(ItemType.Song, command.Parameters));
            output.AppendLine("Song added");
        }

        private static void ExecuteAddApplicationCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            catalog.Add(new ContentItem(ItemType.Application, command.Parameters));
            output.AppendLine("Application added");
        }

        private static void ExecuteUpdateCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new FormatException(string.Format("Invalid number of parameters {0}!", command.Parameters.Length));
            }

            int itemsUpdated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            string updateCommandResult = string.Format("{0} items updated", itemsUpdated);
            output.AppendLine(updateCommandResult);
        }

        private static void ExecuteFindCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent contentItem in foundContent)
                {
                    output.AppendLine(contentItem.TextRepresentation);
                }
            }
        }
    }
}
