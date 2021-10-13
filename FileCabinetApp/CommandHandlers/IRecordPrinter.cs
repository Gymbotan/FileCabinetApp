// <copyright file="IRecordPrinter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for printing records.
    /// </summary>
    public interface IRecordPrinter
    {
        /// <summary>
        /// Prints records.
        /// </summary>
        /// <param name="records">Records.</param>
        public void Print(IEnumerable<FileCabinetRecord> records);
    }
}
