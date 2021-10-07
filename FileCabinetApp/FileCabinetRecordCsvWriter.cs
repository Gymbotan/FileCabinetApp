// <copyright file="FileCabinetRecordCsvWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// FileCabinetRecordCsvWriter.
    /// </summary>
    public class FileCabinetRecordCsvWriter
    {
        private readonly TextWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordCsvWriter"/> class.
        /// </summary>
        /// <param name="writer">Text writer.</param>
        public FileCabinetRecordCsvWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        /// <summary>
        /// Writes records in file.
        /// </summary>
        /// <param name="record">Record.</param>
        public void Write(FileCabinetRecord record)
        {
            this.writer.WriteLine($"{record.Id},{record.FirstName},{record.LastName},{DateAsString(record.DateOfBirth)},{record.Height},{record.Weight},{record.Gender}");
        }

        private static string DateAsString(DateTime dt)
        {
            return string.Format("{0:00}", dt.Month) + "/" + string.Format("{0:00}", dt.Day) + "/" + dt.Year.ToString();
        }
    }
}
