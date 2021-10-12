// <copyright file="CommonMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Functions for inputing data.
    /// </summary>
    public static class CommonMethods
    {
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
        /// Prints an array.
        /// </summary>
        /// <param name="array">Array to print.</param>
        public static void ShowArray(IReadOnlyCollection<FileCabinetRecord> array)
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
        /// Prints information about missed command.
        /// </summary>
        /// <param name="command">command's name.</param>
        public static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }
    }
}
