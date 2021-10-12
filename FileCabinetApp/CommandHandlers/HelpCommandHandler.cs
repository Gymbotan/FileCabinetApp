// <copyright file="HelpCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;

    /// <summary>
    /// Handler of help function.
    /// </summary>
    public class HelpCommandHandler : CommandHandlerBase
    {
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints a help screen", "The 'help' command prints a help screen." },
            new string[] { "create", "create a new record", "The 'create' command creates a new record." },
            new string[] { "stat", "prints records' statistics", "The 'stat' command prints records' statistics." },
            new string[] { "list", "shows existing records", "The 'list' command shows existing records." },
            new string[] { "edit", "edits an existing record", "The 'edit' command edits an existing record." },
            new string[] { "export", "exports existing records into a file", "The 'export' command exports existing records into a file." },
            new string[] { "import", "imports records from an existing file", "The 'export' command imports records from an existing file." },
            new string[] { "find", "finds existing records", "The 'find' command finds existing records." },
            new string[] { "remove", "removes an existing record", "The 'remove' command removes an existing record." },
            new string[] { "purge", "deletes removed records", "The 'purge' command deletes removed records." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                if (!string.IsNullOrEmpty(request.Parameters))
                {
                    var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[CommandHelpIndex], request.Parameters, StringComparison.InvariantCultureIgnoreCase));
                    if (index >= 0)
                    {
                        Console.WriteLine(helpMessages[index][ExplanationHelpIndex]);
                    }
                    else
                    {
                        Console.WriteLine($"There is no explanation for '{request.Parameters}' command.");
                    }
                }
                else
                {
                    Console.WriteLine("Available commands:");

                    foreach (var helpMessage in helpMessages)
                    {
                        Console.WriteLine("\t{0}\t- {1}", helpMessage[CommandHelpIndex], helpMessage[DescriptionHelpIndex]);
                    }
                }

                Console.WriteLine();
            }
            else
            {
                base.Handle(request);
            }
        }

        /// <summary>
        /// Shows whether can this handler handle the request.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>Can or not.</returns>
        private bool CanHandle(AppCommandRequest request)
        {
            if (request.Command.ToLower() == "help")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
