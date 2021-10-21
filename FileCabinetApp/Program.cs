﻿// <auto-generated />
namespace FileCabinetApp
{
    using System;
    using FileCabinetApp.CommandHandlers;
    using System.Collections.Generic;

    /// <summary>
    /// Main class with main functionality.
    /// </summary>
    public static class Program
    {
        private const string DeveloperName = "Anatoliy Pecherny";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";

        private static bool isRunning = true;
        
        private static IFileCabinetService fileCabinetService = new FileCabinetMemoryService(new ValidatorBuilder()
            .ValidateFirstName(2, 60)
            .ValidateLastName(2, 60)
            .ValidateDateOfBirth(new DateTime(1950, 1, 1), DateTime.Now)
            .ValidateHeight(30,250)
            .ValidateWeight(1, 200)
            .ValidatorGender(new char[] { 'm', 'f', 'a' })
            .Create());

        public static void Main(string[] args)
        {
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            if (args.Length > 0)
            {
                string[] parameters = ParseArgs(args);
                SetSettings(parameters);
            }
            else
            {
                Console.WriteLine($"Using default validation rules.");
            }
            
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            var commandHandler = Program.CreateCommandHandlers();

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                var parameters = inputs.Length > 1 ? inputs[1] : string.Empty;
                commandHandler.Handle(new AppCommandRequest(inputs[0], parameters));
            }
            while (isRunning);
        }

        private static string[] ParseArgs(string[] args)
        {
            try
            {
                if (args[0].StartsWith("--"))
                {
                    args[0] = args[0].Replace("--", "");
                    string[] parameters = args[0].Split('=', 2);
                    return parameters;
                }
                else if (args[0].StartsWith('-'))
                {
                    string[] parameters = new string[2] { args[0].Replace("-", ""), args[1] };
                    return parameters;
                }
                else
                {
                    return null;
                }
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        private static void SetSettings(string[] parameters)
        {
            switch (parameters[0].ToUpper())
            {
                case "V":
                case "VALIDATION-RULES":
                    SetValidationRule(parameters[1]);
                    break;
                case "S":
                case "STORAGE":
                    SetServiceType(parameters[1]);
                    break;
                default:
                    SetValidationRule("Default");
                    break;
            }
        }

        private static void SetValidationRule(string parameter)
        {
            switch (parameter.ToUpper())
            {
                case "DEFAULT":
                    Console.WriteLine($"Using {parameter.ToLower()} validation rules.");
                    break;
                case "CUSTOM":
                    Console.WriteLine($"Using {parameter.ToLower()} validation rules.");
                    Program.fileCabinetService = new FileCabinetMemoryService(new ValidatorBuilder()
                            .ValidateFirstName(2, 50)
                            .ValidateLastName(2, 50)
                            .ValidateDateOfBirth(new DateTime(1930, 1, 1), DateTime.Now)
                            .ValidateHeight(30, 250)
                            .ValidateWeight(1, 200)
                            .ValidatorGender(new char[] { 'm', 'f', 'a' })
                            .Create());
                    break;
                default:
                    Console.WriteLine($"Using default validation rules.");
                    break;
            }
        }

        private static void SetServiceType(string parameter)
        {
            switch (parameter.ToUpper())
            {
                case "MEMORY":
                    Console.WriteLine($"Using {parameter.ToLower()} service type.");
                    break;
                case "FILE":
                    Console.WriteLine($"Using {parameter.ToLower()} service type.");
                    Program.fileCabinetService = new FileCabinetFilesystemService(new ValidatorBuilder()
                            .ValidateFirstName(2, 60)
                            .ValidateLastName(2, 60)
                            .ValidateDateOfBirth(new DateTime(1950, 1, 1), DateTime.Now)
                            .ValidateHeight(30, 250)
                            .ValidateWeight(1, 200)
                            .ValidatorGender(new char[] { 'm', 'f', 'a' })
                            .Create());
                    break;
                default:
                    Console.WriteLine($"Using default service type.");
                    break;
            }
        }

        /// <summary>
        /// Sets value for isRunning field.
        /// </summary>
        /// <param name="value">Value.</param>
        private static void SetIsRunning(bool value)
        {
            isRunning = value;
        }

        private static ICommandHandler CreateCommandHandlers()
        {
            var recordPrinter = new DefaultRecordPrinter();

            var helpHandler = new HelpCommandHandler();
            var createHandler = new CreateCommandHandler(Program.fileCabinetService);
            var statHandler = new StatCommandHandler(Program.fileCabinetService);
            var listHandler = new ListCommandHandler(Program.fileCabinetService, Print);
            var editHandler = new EditCommandHandler(Program.fileCabinetService);
            var exportHandler = new ExportCommandHandler(Program.fileCabinetService);
            var importHandler = new ImportCommandHandler(Program.fileCabinetService);
            var findHandler = new FindCommandHandler(Program.fileCabinetService, Print);
            var removeHandler = new RemoveCommandHandler(Program.fileCabinetService);
            var purgeHandler = new PurgeCommandHandler(Program.fileCabinetService);
            var exitHandler = new ExitCommandHandler(Program.fileCabinetService, SetIsRunning);

            helpHandler.SetNext(createHandler);
            createHandler.SetNext(statHandler);
            statHandler.SetNext(listHandler);
            listHandler.SetNext(editHandler);
            editHandler.SetNext(exportHandler);
            exportHandler.SetNext(importHandler);
            importHandler.SetNext(findHandler);
            findHandler.SetNext(removeHandler);
            removeHandler.SetNext(purgeHandler);
            purgeHandler.SetNext(exitHandler);

            return helpHandler;
        }

        /// <summary>
        /// Prints records.
        /// </summary>
        /// <param name="records">Records.</param>
        private static void Print(IEnumerable<FileCabinetRecord> records)
        {
            if (records != null)
            {
                foreach (var ar in records)
                {
                    ar.ShowRecord();
                }
            }
        }
    }
}