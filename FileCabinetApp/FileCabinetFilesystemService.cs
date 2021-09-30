// <copyright file="FileCabinetFilesystemService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class FileCabinetFilesystemService.
    /// </summary>
    public class FileCabinetFilesystemService : IFileCabinetService
    {
        private readonly FileStream fileStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetFilesystemService"/> class.
        /// </summary>
        /// <param name="validator">Validator.</param>
        public FileCabinetFilesystemService(IRecordValidator validator)
        {
            this.Validator = validator;
            this.fileStream = File.Create("cabinet-records.db");
        }

        /// <summary>
        /// Gets or sets validator.
        /// </summary>
        public IRecordValidator Validator { get; set; }

        /// <summary>
        /// Create record.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>Int.</returns>
        public int CreateRecord(DataForRecord data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// EditRecord.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data.</param>
        public void EditRecord(int id, DataForRecord data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FindByDateOfBirth.
        /// </summary>
        /// <param name="dateOfBirth">dateOfBirth.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FindByFirstName.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FindByLastName.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetStat.
        /// </summary>
        /// <returns>Int.</returns>
        public int GetStat()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IsRecordExist.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool IsRecordExist(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ListRecords.
        /// </summary>
        public void ListRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// MakeSnapshot.
        /// </summary>
        /// <returns>FileCabinetServiceSnapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot()
        {
            throw new NotImplementedException();
        }
    }
}
