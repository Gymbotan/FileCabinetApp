// <copyright file="FileCabinetRecordCsvReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class FileCabinetRecordCsvReader.
    /// </summary>
    public class FileCabinetRecordCsvReader
    {
        private readonly StreamReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordCsvReader"/> class.
        /// </summary>
        /// <param name="reader">StreamReader.</param>
        public FileCabinetRecordCsvReader(StreamReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Reads all the records from a file.
        /// </summary>
        /// <returns>List of records.</returns>
        public IList<FileCabinetRecord> ReadAll()
        {
            List<FileCabinetRecord> list = new List<FileCabinetRecord>();
            this.reader.ReadLine();
            string line;
            while ((line = this.reader.ReadLine()) != null)
            {
                string[] array = line.Split(',');
                int id = int.Parse(array[0]);
                string firstName = array[1];
                string lastName = array[2];
                DateTime dateOfBirth = StringToDate(array[3]);
                short height = short.Parse(array[4]);
                decimal weight;
                char gender;
                if (array.Length == 7)
                {
                    weight = decimal.Parse(array[5]);
                    gender = char.Parse(array[6]);
                }
                else
                {
                    weight = decimal.Parse($"{array[5]},{array[6]}");
                    gender = char.Parse(array[7]);
                }

                FileCabinetRecord record = new FileCabinetRecord(id, firstName, lastName, dateOfBirth, height, weight, gender);
                list.Add(record);
            }

            return list;
        }

        private static DateTime StringToDate(string str)
        {
            if (str == null)
            {
                return new DateTime(2000, 1, 1);
            }
            else
            {
                try
                {
                    var inputs = str.Split('/', 3);
                    DateTime date = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
                    return date;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new DateTime(2000, 1, 1);
                }
            }
        }
    }
}
