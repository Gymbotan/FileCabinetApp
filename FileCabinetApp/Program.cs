﻿// <auto-generated />
namespace FileCabinetApp
{
    using System;

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
            new Tuple<string, Action<string>>("exit", Exit),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "create", "create a new record", "The 'create' command creates a new record." },
            new string[] { "stat", "prints the record's statistics", "The 'stat' command prints the record's statistics." },
            new string[] { "list", "shows existing records", "The 'list' command shows existing records." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        private static FileCabinetService fileCabinetService = new FileCabinetService();

        public static void Main(string[] args)
        {
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

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

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

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

        private static void Stat(string parameters)
        {
            var recordsCount = Program.fileCabinetService.GetStat();
            Console.WriteLine($"{recordsCount} record(s).");
        }

        private static void Create(string parameters)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            DateTime dateOfBirth = DateTime.Now;
            short height = 0;
            decimal weight = 0;
            char gender = 'm';
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name shouldn't be empty. Please input again");
                }
                else if (firstName.Length < 2 || firstName.Length > 60)
                {
                    Console.WriteLine("First name's length should more than 1 and less than 61. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name shouldn't be empty. Please input again");
                }
                else if (lastName.Length < 2 || lastName.Length > 60)
                {
                    Console.WriteLine("Last name's length should more than 1 and less than 61. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Date of birth: ");
                    var inputs = Console.ReadLine().Split('/', 3);
                    dateOfBirth = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
                    if (dateOfBirth < new DateTime(1950, 01, 01) || dateOfBirth > DateTime.Now)
                    {
                        Console.WriteLine("Wrong date of birth");
                    }
                    else
                    {
                        isCorrect = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong date of birth");
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Height (cm): ");
                height = short.Parse(Console.ReadLine());
                if (height < 30 || height > 250)
                {
                    Console.WriteLine("Height should more than 29 and less than 251. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Weight (kg): ");
                weight = decimal.Parse(Console.ReadLine());
                if (weight <= 0)
                {
                    Console.WriteLine("Height should more than 0. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }

            isCorrect = false;
            while (!isCorrect)
            {
                Console.WriteLine("Gender (m - male, f - female, a - another): ");
                gender = char.Parse(Console.ReadLine());
                if (gender != 'm' && gender != 'f' && gender != 'a')
                {
                    Console.WriteLine("Gender  should be: m - male, f - female, a - another. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }

            Console.WriteLine($"Record #{Program.fileCabinetService.CreateRecord(firstName, lastName, dateOfBirth, height, weight, gender)} is created");




            /*try
            {
                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Date of birth: ");
                var inputs = Console.ReadLine().Split('/', 3);
                DateTime dateOfBirth = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
                Console.Write("Height (cm): ");
                short height = short.Parse(Console.ReadLine());
                Console.Write("Weight (kg): ");
                decimal weight = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Gender (m - male, f - female, a - another): ");
                char gender = char.Parse(Console.ReadLine());
                Console.WriteLine($"Record #{Program.fileCabinetService.CreateRecord(firstName, lastName, dateOfBirth, height, weight, gender)} is created");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }*/
        }

        private static void List(string parameters)
        {
            Program.fileCabinetService.ListRecords();

            /*Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of birth: ");
            var inputs = Console.ReadLine().Split('/', 3);
            DateTime dateOfBirth = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
            Console.WriteLine($"Record #{Program.fileCabinetService.CreateRecord(firstName, lastName, dateOfBirth)} is created");*/
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }
    }
}