// <copyright file="CommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Class CommandHandler.
    /// </summary>
    public class CommandHandler : CommandHandlerBase
    {
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("edit", Edit),
            new Tuple<string, Action<string>>("export", Export),
            new Tuple<string, Action<string>>("import", Import),
            new Tuple<string, Action<string>>("find", Find),
            new Tuple<string, Action<string>>("remove", Remove),
            new Tuple<string, Action<string>>("purge", Purge),
            new Tuple<string, Action<string>>("exit", Exit),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "create", "create a new record", "The 'create' command creates a new record." },
            new string[] { "stat", "prints the record's statistics", "The 'stat' command prints the record's statistics." },
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
        /// Reads input of record's parameters.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="converter">Used converter.</param>
        /// <param name="validator">Used validator.</param>
        /// <returns>Inputed value.</returns>
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

        /// <summary>
        /// StringConverter.
        /// </summary>
        /// <param name="str">Inputed string.</param>
        /// <returns>Converted tuple.</returns>
        public static Tuple<bool, string, string> StringConverter(string str)
        {
            return Tuple.Create(true, str, str);
        }

        /// <summary>
        /// DateConverter.
        /// </summary>
        /// <param name="str">Inputed string.</param>
        /// <returns>Converted tuple.</returns>
        public static Tuple<bool, string, DateTime> DateConverter(string str)
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

        /// <summary>
        /// ShortConverter.
        /// </summary>
        /// <param name="str">Inputed string.</param>
        /// <returns>Converted tuple.</returns>
        public static Tuple<bool, string, short> ShortConverter(string str)
        {
            short sh;
            bool isSuccess = short.TryParse(str, out sh);
            return Tuple.Create(isSuccess, str, sh);
        }

        /// <summary>
        /// DecimalConverter.
        /// </summary>
        /// <param name="str">Inputed string.</param>
        /// <returns>Converted tuple.</returns>
        public static Tuple<bool, string, decimal> DecimalConverter(string str)
        {
            decimal dec;
            bool isSuccess = decimal.TryParse(str, out dec);
            return Tuple.Create(isSuccess, str, dec);
        }

        /// <summary>
        /// CharConverter.
        /// </summary>
        /// <param name="str">Inputed string.</param>
        /// <returns>Converted tuple.</returns>
        public static Tuple<bool, string, char> CharConverter(string str)
        {
            char ch;
            bool isSuccess = char.TryParse(str, out ch);
            return Tuple.Create(isSuccess, str, ch);
        }

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (string.IsNullOrEmpty(request.Command))
            {
                Console.WriteLine(CommandHandler.HintMessage);
            }
            else
            {
                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(request.Command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    commands[index].Item2(request.Parameters);
                }
                else
                {
                    PrintMissedCommandInfo(request.Command);
                }
            }
        }

        /// <summary>
        /// Set next handler.
        /// </summary>
        /// <param name="handler">Handler.</param>
        public override void SetNext(ICommandHandler handler)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints help for existing commands.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[CommandHandler.CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][CommandHandler.ExplanationHelpIndex]);
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
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[CommandHandler.CommandHelpIndex], helpMessage[CommandHandler.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
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
        /// Shows amount of records.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Stat(string parameters)
        {
            var recordsCount = Program.fileCabinetService.GetStat();
            Console.WriteLine($"There are {recordsCount.Item1} record(s), {recordsCount.Item2} record(s) were removed.");
        }

        /// <summary>
        /// Creates new record.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Create(string parameters)
        {
            Console.Write("First name: ");
            string firstName = ReadInput<string>(StringConverter, Program.fileCabinetService.Validator.FirstNameValidator);

            Console.Write("Last name: ");
            var lastName = ReadInput<string>(StringConverter, Program.fileCabinetService.Validator.LastNameValidator);

            Console.Write("Date of birth: ");
            var dateOfBirth = ReadInput<DateTime>(DateConverter, Program.fileCabinetService.Validator.DateOfBirthValidator);

            Console.Write("Height: ");
            var height = ReadInput<short>(ShortConverter, Program.fileCabinetService.Validator.HeightValidator);

            Console.Write("Weight: ");
            var weight = ReadInput<decimal>(DecimalConverter, Program.fileCabinetService.Validator.WeightValidator);

            Console.Write("Gender (m, f or a): ");
            var gender = ReadInput<char>(CharConverter, Program.fileCabinetService.Validator.GenderValidator);

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
                if (!Program.fileCabinetService.IsRecordExist(recordId))
                {
                    Console.WriteLine($"#{recordId} record is not found.");
                }
                else
                {
                    Console.Write("First name: ");
                    string firstName = ReadInput<string>(StringConverter, Program.fileCabinetService.Validator.FirstNameValidator);

                    Console.Write("Last name: ");
                    var lastName = ReadInput<string>(StringConverter, Program.fileCabinetService.Validator.LastNameValidator);

                    Console.Write("Date of birth: ");
                    var dateOfBirth = ReadInput<DateTime>(DateConverter, Program.fileCabinetService.Validator.DateOfBirthValidator);

                    Console.Write("Height: ");
                    var height = ReadInput<short>(ShortConverter, Program.fileCabinetService.Validator.HeightValidator);

                    Console.Write("Weight: ");
                    var weight = ReadInput<decimal>(DecimalConverter, Program.fileCabinetService.Validator.WeightValidator);

                    Console.Write("Gender (m, f or a): ");
                    var gender = ReadInput<char>(CharConverter, Program.fileCabinetService.Validator.GenderValidator);

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
                    IReadOnlyCollection<FileCabinetRecord> findedArray = Program.fileCabinetService.FindByFirstName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                    ShowArray(findedArray);
                    break;
                case "lastname":
                    findedArray = Program.fileCabinetService.FindByLastName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                    ShowArray(findedArray);
                    break;
                case "dateofbirth":
                    findedArray = Program.fileCabinetService.FindByDateOfBirth(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
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
            Program.fileCabinetService.Exit();
            Program.isRunning = false;
        }

        /// <summary>
        /// Exports data to file.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        private static void Export(string parameters)
        {
            bool isSuccess = true;
            string[] inputs = new string[2];
            string path = null;
            string fileName = null;
            string directoryName = null;
            try
            {
                inputs = parameters.Split(' ', 2);
            }
            catch
            {
                Console.WriteLine("Export failed: you inputed wrong parameters");
                isSuccess = false;
            }

            if (isSuccess)
            {
                try
                {
                    path = inputs[1];
                    fileName = Path.GetFileName(path);
                }
                catch
                {
                    Console.WriteLine("Export failed: file namу is incorrect.");
                    isSuccess = false;
                }
            }

            if (isSuccess)
            {
                try
                {
                    directoryName = Path.GetDirectoryName(path);
                    if (string.IsNullOrWhiteSpace(directoryName))
                    {
                        directoryName = "i:\\";
                        path = directoryName + path;
                    }

                    if (!Directory.Exists(directoryName))
                    {
                        Console.WriteLine($"Export failed: can't open file {path}");
                    }
                }
                catch
                {
                    isSuccess = false;
                }
            }

            if (isSuccess && File.Exists(path))
            {
                Console.Write($"File is exist - rewrite {path}? [y/n] ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToUpper() == "N")
                    {
                        isSuccess = false;
                        break;
                    }
                    else if (input.ToUpper() == "Y")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Wrong input. Choose again [y/n] ");
                    }
                }
            }

            if (isSuccess && inputs[0].ToUpper() == "CSV")
            {
                StreamWriter sw = new StreamWriter(path);
                FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                snapshot.SaveToCsv(sw);
                Console.WriteLine($"All records are exported to file {fileName}");
            }

            if (isSuccess && inputs[0].ToUpper() == "XML")
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                XmlWriter xw = XmlWriter.Create(path, settings);
                FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                snapshot.SaveToXml(xw);
                Console.WriteLine($"All records are exported to file {fileName}");
            }
        }

        private static void Import(string parameters)
        {
            bool isSuccess = true;
            string[] inputs = new string[2];
            string path = null;
            string fileName = null;
            string directoryName = null;
            try
            {
                inputs = parameters.Split(' ', 2);
            }
            catch
            {
                Console.WriteLine("Import failed: you inputed wrong parameters");
                isSuccess = false;
            }

            if (isSuccess)
            {
                try
                {
                    path = inputs[1];
                    fileName = Path.GetFileName(path);
                }
                catch
                {
                    Console.WriteLine("Import failed: file namу is incorrect.");
                    isSuccess = false;
                }
            }

            if (isSuccess)
            {
                try
                {
                    directoryName = Path.GetDirectoryName(path);
                    if (string.IsNullOrWhiteSpace(directoryName))
                    {
                        directoryName = "i:\\";
                        path = directoryName + path;
                    }

                    if (!Directory.Exists(directoryName))
                    {
                        Console.WriteLine($"Import failed: can't open file {path}");
                    }
                }
                catch
                {
                    isSuccess = false;
                }
            }

            if (isSuccess && inputs[0].ToUpper() == "CSV")
            {
                try
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                    snapshot.LoadFromCsv(fs);
                    Console.WriteLine($"All records were imported from file {fileName}");

                    Program.fileCabinetService.Restore(snapshot);
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (isSuccess && inputs[0].ToUpper() == "XML")
            {
                try
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                    snapshot.LoadFromXml(fs);
                    Console.WriteLine($"All records were imported from file {fileName}");

                    Program.fileCabinetService.Restore(snapshot);
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void Remove(string parameters)
        {
            int recordId = -1;

            if (!int.TryParse(parameters, out recordId))
            {
                Console.WriteLine("Record's number is missed. Please input again.");
            }
            else
            {
                if (!Program.fileCabinetService.IsRecordExist(recordId))
                {
                    Console.WriteLine($" Record #{recordId} doesn't exist.");
                }
                else
                {
                    Program.fileCabinetService.RemoveRecord(recordId);
                    Console.WriteLine($" Record #{recordId} is removed.");
                }
            }
        }

        private static void Purge(string parameters)
        {
            Program.fileCabinetService.Purge();
        }
    }
}
