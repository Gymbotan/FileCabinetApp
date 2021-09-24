// <copyright file="IFileCabinetService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for FileCabinetService.
    /// </summary>
    public interface IFileCabinetService
    {
        /// <summary>
        /// Creates new record.
        /// </summary>
        /// <param name="data">Data for a new record.</param>
        /// <returns>Record's id.</returns>
        public int CreateRecord(DataForRecord data);

        /// <summary>
        /// Edits an existing record.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data for a new record.</param>
        public void EditRecord(int id, DataForRecord data);

        /// <summary>
        /// Prints all the existing records.
        /// </summary>
        public void ListRecords();

        /// <summary>
        /// Returns amount of records.
        /// </summary>
        /// <returns>Amount of records.</returns>
        public int GetStat();

        /// <summary>
        /// Checks is a record with this id is exist.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Is a record exist or no.</returns>
        public bool IsRecordExist(int id);

        /// <summary>
        /// Finds all the records with chosen first name.
        /// </summary>
        /// <param name="firstName">FirstName.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName);

        /// <summary>
        /// Finds all the records withchosen last name.
        /// </summary>
        /// <param name="lastName">LastName.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName);

        /// <summary>
        /// Finds all the records with chosen date of birth.
        /// </summary>
        /// <param name="dateOfBirth">DateOfBirth.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth);
    }
}
