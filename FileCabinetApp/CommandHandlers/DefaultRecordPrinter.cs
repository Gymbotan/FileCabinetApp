// <copyright file="DefaultRecordPrinter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class DefaultRecordPrinter.
    /// </summary>
    public class DefaultRecordPrinter : IRecordPrinter
    {
        /// <summary>
        /// Prints records.
        /// </summary>
        /// <param name="records">Records.</param>
        public void Print(IEnumerable<FileCabinetRecord> records)
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
