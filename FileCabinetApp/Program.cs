﻿// <auto-generated />
namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Main class with main functionality.
    /// </summary>
    public static class Program
    {
        private const string DeveloperName = "Anatoliy Pecherny";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;

        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("edit", Edit),
            new Tuple<string, Action<string>>("find", Find),
            new Tuple<string, Action<string>>("exit", Exit),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "create", "create a new record", "The 'create' command creates a new record." },
            new string[] { "stat", "prints the record's statistics", "The 'stat' command prints the record's statistics." },
            new string[] { "list", "shows existing records", "The 'list' command shows existing records." },
            new string[] { "edit", "edits an existing record", "The 'edit' command edits an existing record." },
            new string[] { "find", "finds existing records", "The 'find' command finds existing records." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        private static IFileCabinetService fileCabinetService = new FileCabinetService(new DefaultValidator());

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
            //fileCabinetService.validator = fileCabinetService.CreateValidator();
            
            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        /// <summary>
        /// Prints information about missed command.
        /// </summary>
        /// <param name="command">command's name.</param>
        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints help for existing commands.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Shows amount of records
        /// </summary>
        /// <param name="parameters">Parameters</param>
        private static void Stat(string parameters)
        {
            var recordsCount = Program.fileCabinetService.GetStat();
            Console.WriteLine($"{recordsCount} record(s).");
        }

        /// <summary>
        /// Creates new record.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Create(string parameters)
        {
            Console.Write("First name: ");
            string firstName = ReadInput<string>(stringConverter, Program.fileCabinetService.Validator.FirstNameValidator);

            Console.Write("Last name: ");
            var lastName = ReadInput<string>(stringConverter, Program.fileCabinetService.Validator.LastNameValidator);

            Console.Write("Date of birth: ");
            var dateOfBirth = ReadInput<DateTime>(dateConverter, Program.fileCabinetService.Validator.DateOfBirthValidator);

            Console.Write("Height: ");
            var height = ReadInput<short>(shortConverter, Program.fileCabinetService.Validator.HeightValidator);

            Console.Write("Weight: ");
            var weight = ReadInput<decimal>(decimalConverter, Program.fileCabinetService.Validator.WeightValidator);

            Console.Write("Gender (m, f or a): ");
            var gender = ReadInput<char>(charConverter, Program.fileCabinetService.Validator.GenderValidator);
            
            DataForRecord data = new DataForRecord(firstName, lastName, dateOfBirth, height, weight, gender);

            Console.WriteLine($"Record #{Program.fileCabinetService.CreateRecord(data)} is created");
        }

        /// <summary>
        /// Edits an existing record.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Edit(string parameters)
        {
            int recordId = -1;
            
            if (!int.TryParse(parameters, out recordId))
            {
                Console.WriteLine("Record's number is missed. Please input again.");
            }
            else
            {
                if (!fileCabinetService.IsRecordExist(recordId))
                {
                    Console.WriteLine($"#{recordId} record is not found.");
                }
                else
                {
                    Console.Write("First name: ");
                    string firstName = ReadInput<string>(stringConverter, Program.fileCabinetService.Validator.FirstNameValidator);

                    Console.Write("Last name: ");
                    var lastName = ReadInput<string>(stringConverter, Program.fileCabinetService.Validator.LastNameValidator);

                    Console.Write("Date of birth: ");
                    var dateOfBirth = ReadInput<DateTime>(dateConverter, Program.fileCabinetService.Validator.DateOfBirthValidator);

                    Console.Write("Height: ");
                    var height = ReadInput<short>(shortConverter, Program.fileCabinetService.Validator.HeightValidator);

                    Console.Write("Weight: ");
                    var weight = ReadInput<decimal>(decimalConverter, Program.fileCabinetService.Validator.WeightValidator);

                    Console.Write("Gender (m, f or a): ");
                    var gender = ReadInput<char>(charConverter, Program.fileCabinetService.Validator.GenderValidator);
                    
                    DataForRecord data = new DataForRecord(firstName, lastName, dateOfBirth, height, weight, gender);

                    Program.fileCabinetService.EditRecord(recordId, data);
                    Console.WriteLine($"Record #{recordId} is updated.");
                }
            }
        }

        /// <summary>
        /// Finds records that fit inputed conditions.
        /// </summary>
        /// <param name="parameters">2 parameters: field for search, value for search.</param>
        private static void Find(string parameters)
        {
            var inputs = parameters.Split(' ', 2);
            switch (inputs[0].ToLower())
            {
                case "firstname":
                    IReadOnlyCollection<FileCabinetRecord> findedArray = Program.fileCabinetService.FindByFirstName(inputs[1].Replace("\"", "").Replace("\'", ""));
                    ShowArray(findedArray);
                    break;
                case "lastname":
                    findedArray = Program.fileCabinetService.FindByLastName(inputs[1].Replace("\"", "").Replace("\'", ""));
                    ShowArray(findedArray);
                    break;
                case "dateofbirth":
                    findedArray = Program.fileCabinetService.FindByDateOfBirth(inputs[1].Replace("\"", "").Replace("\'", ""));
                    ShowArray(findedArray);
                    break;
                default:
                    Console.WriteLine("You unput wrong parameters.");
                    break;
            }
        }

        /// <summary>
        /// Prints an array.
        /// </summary>
        /// <param name="array">Array to print.</param>
        private static void ShowArray(IReadOnlyCollection<FileCabinetRecord> array)
        {
            if (array != null)
            {
                foreach (var ar in array)
                {
                    ar.ShowRecord();
                }
            }
        }

        /// <summary>
        /// Shows all the records.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void List(string parameters)
        {
            Program.fileCabinetService.ListRecords();
        }

        /// <summary>
        /// Exit.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        private static string[] ParseArgs(string[] args)
        {
            try
            {
                if (args[0].StartsWith("--"))
                {
                    Console.WriteLine("Work with --");
                    args[0] = args[0].Replace("--", "");
                    string[] parameters = args[0].Split('=', 2);
                    foreach (string par in parameters)
                    {
                        Console.WriteLine(par);
                    }
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
                    Program.fileCabinetService = new FileCabinetService(new CustomValidator());
                    break;
                default:
                    Console.WriteLine($"Using default validation rules.");
                    break;
            }
        }

        public static T ReadInput<T>(Func<string, Tuple<bool, string, T>> converter, Func<T, Tuple<bool, string>> validator)
        {
            do
            {
                T value;

                var input = Console.ReadLine();
                var conversionResult = converter(input);

                if (!conversionResult.Item1)
                {
                    Console.WriteLine($"Conversion failed: {conversionResult.Item2}. Please, correct your input.");
                    continue;
                }

                value = conversionResult.Item3;

                var validationResult = validator(value);
                if (!validationResult.Item1)
                {
                    Console.WriteLine($"Validation failed: {validationResult.Item2}. Please, correct your input.");
                    continue;
                }

                return value;
            }
            while (true);
        }

        public static Tuple<bool, string, string> stringConverter (string str)
        {
            return Tuple.Create(true, str, str);
        }

        public static Tuple<bool, string, DateTime> dateConverter(string str)
        {
            bool isSuccess = true;
            DateTime date = DateTime.Now;
            try
            {
                var inputs = str.Split('/', 3);
                date = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
            }
            catch
            {
                isSuccess = false;
            }
            return Tuple.Create(isSuccess, str, date);
        }

        public static Tuple<bool, string, short> shortConverter(string str)
        {
            short sh;
            bool isSuccess = short.TryParse(str, out sh);
            return Tuple.Create(isSuccess, str, sh);
        }

        public static Tuple<bool, string, decimal> decimalConverter(string str)
        {
            decimal dec;
            bool isSuccess = decimal.TryParse(str, out dec);
            return Tuple.Create(isSuccess, str, dec);
        }

        public static Tuple<bool, string, char> charConverter(string str)
        {
            char ch;
            bool isSuccess = char.TryParse(str, out ch);
            return Tuple.Create(isSuccess, str, ch);
        }
    }
}