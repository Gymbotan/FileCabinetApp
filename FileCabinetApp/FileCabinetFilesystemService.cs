// <copyright file="FileCabinetFilesystemService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class FileCabinetFilesystemService.
    /// </summary>
    public class FileCabinetFilesystemService : IFileCabinetService
    {
        private readonly FileStream fileStream;
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetFilesystemService"/> class.
        /// </summary>
        /// <param name="validator">Validator.</param>
        public FileCabinetFilesystemService(IRecordValidator validator)
        {
            this.Validator = validator;
            string path = "cabinet-records.db";
            this.fileStream = new FileStream(path, FileMode.OpenOrCreate);
            this.size = (int)(this.fileStream.Length / 270);
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
            this.fileStream.Write(new byte[2]);

            this.fileStream.Write(BitConverter.GetBytes(++this.size));

            byte[] ar = new UTF8Encoding(true).GetBytes(data.FirstName);
            this.fileStream.Write(ar, 0, Math.Min(ar.Length, 120));
            this.fileStream.Write(new byte[120 - Math.Min(ar.Length, 120)]);

            ar = new UTF8Encoding(true).GetBytes(data.LastName);
            this.fileStream.Write(ar, 0, Math.Min(ar.Length, 120));
            this.fileStream.Write(new byte[120 - Math.Min(ar.Length, 120)]);

            this.fileStream.Write(BitConverter.GetBytes(data.DateOfBirth.Year));
            this.fileStream.Write(BitConverter.GetBytes(data.DateOfBirth.Month));
            this.fileStream.Write(BitConverter.GetBytes(data.DateOfBirth.Day));

            this.fileStream.Write(BitConverter.GetBytes(data.Height));

            this.fileStream.Write(BitConverter.GetBytes(Convert.ToDouble(data.Weight)));
            this.fileStream.Write(BitConverter.GetBytes(data.Gender));
            return this.size;
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
