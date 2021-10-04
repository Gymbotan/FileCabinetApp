using System;
using System.Text;
using FileCabinetApp;

namespace FileCabinetGenerator
{
    public class Program
    {
        public static string[] firstNames = { "Andrew", "John", "James", "Nick", "Fil", "Robert", "William", "Anastasia", "Holly", "Kate", "Lora", "Mila", "Nadin", "Olga", "Wanda", "Rita", "Betty", "Sam" };
        public static string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Thompson", "Clark", "Lee" };
        public static char[] genders = { 'm', 'f', 'a' };

        static void Main(string[] args)
        {
            string[] parameters = ParseArgs(args);
            Console.WriteLine("parameters in main:");
            foreach (string par in parameters)
            {
                Console.WriteLine(par);
            }

            string outputType = "csv";
            string path = "basic.csv";
            int amountOfRecords = 1;
            int startId = 1;

            if (args.Length != 0)
            {
                for (int i = 0; i < parameters.Length; i += 2)
                {
                    switch(parameters[i])
                    {
                        case "t":
                        case "output-type":
                            outputType = parameters[i + 1];
                            break;
                        case "o":
                        case "output":
                            path = parameters[i + 1];
                            break;
                        case "a":
                        case "records-amount":
                            amountOfRecords = int.Parse(parameters[i + 1]);
                            break;
                        case "i":
                        case "start-id":
                            startId = int.Parse(parameters[i + 1]);
                            break;
                    }
                }
            }
            
            for (int i = 1; i < 20; i++)
            {
                RandomRecord(i).ShowRecord();
            }
        }

        private static string[] ParseArgs(string[] args)
        {
            if (args.Length == 0)
            {
                return new string[0];
            }

            StringBuilder sb = new StringBuilder();
            foreach (string arg in args)
            {
                sb.Append(arg);
                sb.Append(" ");
            }
            sb.Remove(sb.Length - 1, 1);
            string origin = sb.ToString();
            
            string[] parameters = origin.Split(new char[] { '=', ' ' });

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].StartsWith("--"))
                {
                    parameters[i] = parameters[i].Replace("--", "");
                }

                if (parameters[i].StartsWith("-"))
                {
                    parameters[i] = parameters[i].Substring(1);
                }
            }

            return parameters;
        }

        private static FileCabinetRecord RandomRecord(int id)
        {
            Random rand = new Random();
            string firstName = firstNames[rand.Next(firstNames.Length)];
            string lastName = lastNames[rand.Next(firstNames.Length)];
            DateTime dateOfBirth = new DateTime(1900, 1, 1);
            do
            {
                try
                {
                    dateOfBirth = new DateTime(rand.Next(1950, 2020), rand.Next(1, 12), rand.Next(1, 30));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (dateOfBirth < new DateTime(1950, 1, 1));
            short height = (short)rand.Next(80, 210);
            decimal weight = ((decimal)rand.Next(100, 2000)) / 10;
            char gender = genders[rand.Next(genders.Length)];
            return new FileCabinetRecord(id, firstName, lastName, dateOfBirth, height, weight, gender);
        }
    }
}
