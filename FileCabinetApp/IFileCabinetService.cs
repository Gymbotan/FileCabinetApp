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
        /// Gets or sets validator.
        /// </summary>
        public IRecordValidator Validator { get; set; }

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
        /// <returns>List of existing records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> ListRecords();

        /// <summary>
        /// Returns amount of records.
        /// </summary>
        /// <returns>Amount of records.</returns>
        public (int, int) GetStat();

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

        /// <summary>
        /// Returns all the records.
        /// </summary>
        /// <returns>Records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> GetRecords();

        /// <summary>
        /// Make shapshot.
        /// </summary>
        /// <returns>Snapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot();

        /// <summary>
        /// Restores state from snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot.</param>
        public void Restore(FileCabinetServiceSnapshot snapshot);

        /// <summary>
        /// Removes an existing record.
        /// </summary>
        /// <param name="recordId">Record's id.</param>
        public void RemoveRecord(int recordId);

        /// <summary>
        /// Deletes removed records.
        /// </summary>
        public void Purge();

        /// <summary>
        /// Exit.
        /// </summary>
        public void Exit();
    }
}
