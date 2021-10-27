// <copyright file="ServiceLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// ServiceLogger class.
    /// </summary>
    public class ServiceLogger : IFileCabinetService
    {
        private readonly IFileCabinetService service;
        private readonly string path = "log.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLogger"/> class.
        /// </summary>
        /// <param name="service">IFileCabinetService.</param>
        public ServiceLogger(IFileCabinetService service)
        {
            this.service = service;
            this.Validator = service.Validator;
        }

        /// <summary>
        /// Gets or sets validator.
        /// </summary>
        public IRecordValidator Validator { get; set; }

        /// <summary>
        /// Creates record.
        /// </summary>
        /// <param name="data">DataForRecord.</param>
        /// <returns>Record's id.</returns>
        public int CreateRecord(DataForRecord data)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling Create() with FirstName = {data.FirstName}, " +
                    $"LastName = {data.LastName}, DateofBirth = {data.DateOfBirth}, Height = {data.Height}cm, " +
                    $"Weight = {data.Weight}kg, Gender = {data.Gender}");
            }

            int id = this.service.CreateRecord(data);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Create() returned {id}");
            }

            return id;
        }

        /// <summary>
        /// Edits record.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">DataForRecord.</param>
        public void EditRecord(int id, DataForRecord data)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling Edit() for the record with Id = {id} with FirstName = {data.FirstName}, " +
                    $"LastName = {data.LastName}, DateofBirth = {data.DateOfBirth}, Height = {data.Height}cm, " +
                    $"Weight = {data.Weight}kg, Gender = {data.Gender}");
            }

            this.service.EditRecord(id, data);
        }

        /// <summary>
        /// Exit.
        /// </summary>
        public void Exit()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling Exit()");
            }

            this.service.Exit();
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="dateOfBirth">dateOfBirth.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling FindByDateOfBirth() with DateofBirth = {dateOfBirth}");
            }

            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByDateOfBirth(dateOfBirth);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - FindByDateOfBirth() found {list.Count} record(s)");
            }

            return list;
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling FindByFirstName() with FirstName = {firstName}");
            }

            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByFirstName(firstName);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - FindByFirstName() found {list.Count} record(s)");
            }

            return list;
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling FindByLastName() with LastName = {lastName}");
            }

            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByLastName(lastName);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - FindByLastName() found {list.Count} record(s)");
            }

            return list;
        }

        /// <summary>
        /// Gets all the records.
        /// </summary>
        /// <returns>Records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling GetRecords()");
            }

            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.GetRecords();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - GetRecords() returned {list.Count} record(s)");
            }

            return list;
        }

        /// <summary>
        /// Gets statistics of records.
        /// </summary>
        /// <returns>Statistics.</returns>
        public (int, int) GetStat()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling GetStat()");
            }

            (int, int) stats = this.service.GetStat();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - GetStat() returned {stats.Item1} existing records " +
                    $"and {stats.Item2} removed records");
            }

            return stats;
        }

        /// <summary>
        /// Checks is record exist.
        /// </summary>
        /// <param name="id">Record's id.</param>
        /// <returns>isExist.</returns>
        public bool IsRecordExist(int id)
        {
            bool isExist = this.service.IsRecordExist(id);

            return isExist;
        }

        /// <summary>
        /// Returns list of records.
        /// </summary>
        /// <returns>List of records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> ListRecords()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling ListRecords()");
            }

            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.ListRecords();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - ListRecords() showed {list.Count} records");
            }

            return list;
        }

        /// <summary>
        /// Makes snapshot.
        /// </summary>
        /// <returns>Snapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling MakeSnapshot()");
            }

            FileCabinetServiceSnapshot snapshot = this.service.MakeSnapshot();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Snapshot was created");
            }

            return snapshot;
        }

        /// <summary>
        /// Purges removed records.
        /// </summary>
        public void Purge()
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling Purge()");
            }

            this.service.Purge();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Removed records were deleted");
            }
        }

        /// <summary>
        /// Removes chosen record.
        /// </summary>
        /// <param name="recordId">RecordId.</param>
        public void RemoveRecord(int recordId)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling RemoveRecord() for record with Id = {recordId}");
            }

            this.service.RemoveRecord(recordId);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - The record was removed");
            }
        }

        /// <summary>
        /// Restores FileCabinetService from snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot.</param>
        public void Restore(FileCabinetServiceSnapshot snapshot)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Calling Restore()");
            }

            this.service.Restore(snapshot);
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                sw.WriteLine($"{DateTime.Now} - Service was restored from snapshot");
            }
        }
    }
}
