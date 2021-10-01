﻿// <auto-generated />
namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Class that realizes all the services of the main class.
    /// </summary>
    public class FileCabinetMemoryService : IFileCabinetService
    {
        public FileCabinetMemoryService(IRecordValidator validator)
        {
            this.Validator = validator;
        }

        private readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

        private readonly Dictionary<string, List<FileCabinetRecord>> firstNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        private readonly Dictionary<string, List<FileCabinetRecord>> lastNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        private readonly Dictionary<string, List<FileCabinetRecord>> dateOfBirthDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        public IRecordValidator Validator { get; set; }
        
        /// <summary>
        /// Transforms DateTime to string in special format.
        /// </summary>
        /// <param name="date">Date to transform.</param>
        /// <returns>String format of date.</returns>
        public static string GetDateAsString(DateTime date)
        {
            return $"{date.Year}-{date.ToString("MMM", CultureInfo.GetCultureInfo("en-us"))}-{date.Day}".ToUpper();
        }

        /// <summary>
        /// Adds record to a chosen dictionary.
        /// </summary>
        /// <param name="dictionary">Chosen dictionary.</param>
        /// <param name="value">Key for a record.</param>
        /// <param name="record">Record to add.</param>
        public void AddToDictionary(Dictionary<string, List<FileCabinetRecord>> dictionary, string value, FileCabinetRecord record)
        {
            if (dictionary.ContainsKey(value))
            {
                dictionary[value].Add(record);
            }
            else
            {
                dictionary.Add(value, new List<FileCabinetRecord> { record });
            }
        }

        /// <summary>
        /// Removes a record from a chosen dictionary.
        /// </summary>
        /// <param name="dictionary">A chosen dictionary.</param>
        /// <param name="value">Key for a record.</param>
        /// <param name="id">Record's id.</param>
        public void RemoveFromDictionary(Dictionary<string, List<FileCabinetRecord>> dictionary, string value, int id)
        {
            FileCabinetRecord itemToDelete = dictionary[value].SingleOrDefault(x => x.Id == id);
            dictionary[value].Remove(itemToDelete);
        }

        /// <summary>
        /// Creates new record.
        /// </summary>
        /// <param name="data">Data for a new record.</param>
        public int CreateRecord(DataForRecord data)
        {
            this.Validator.ValidateParameters(data);
            
            int id = this.list.Count + 1;

            this.list.Add(new FileCabinetRecord(id, data));

            this.AddToDictionary(this.firstNameDictionary, data.FirstName.ToUpper(), new FileCabinetRecord(id, data));
            this.AddToDictionary(this.lastNameDictionary, data.LastName.ToUpper(), new FileCabinetRecord(id, data));
            string dateAsString = GetDateAsString(data.DateOfBirth);
            this.AddToDictionary(this.dateOfBirthDictionary, dateAsString, new FileCabinetRecord(id, data));

            return id;
        }

        /// <summary>
        /// Prints all the existing records.
        /// </summary>
        public void ListRecords()
        {
            foreach (FileCabinetRecord record in this.list)
            {
                record.ShowRecord();
            }
        }

        /// <summary>
        /// Checks is a record with this id is exist.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Is a record exist or no.</returns>
        public bool IsRecordExist(int id)
        {
            if (this.list.Exists(x => x.Id == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Edits an existing record.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data for a new record.</param>
        public void EditRecord(int id, DataForRecord data)
        {
            this.Validator.ValidateParameters(data);
            FileCabinetRecord record = this.list.Find(x => x.Id == id);
            
            this.RemoveFromDictionary(this.firstNameDictionary, record.FirstName.ToUpper(), id);
            this.RemoveFromDictionary(this.lastNameDictionary, record.LastName.ToUpper(), id);
            string dateAsString = GetDateAsString(record.DateOfBirth);
            this.RemoveFromDictionary(this.dateOfBirthDictionary, dateAsString, id);
            
            this.AddToDictionary(this.firstNameDictionary, data.FirstName.ToUpper(), new FileCabinetRecord(id, data));
            this.AddToDictionary(this.lastNameDictionary, data.FirstName.ToUpper(), new FileCabinetRecord(id, data));
            dateAsString = GetDateAsString(data.DateOfBirth);
            this.AddToDictionary(this.dateOfBirthDictionary, dateAsString, new FileCabinetRecord(id, data));

            record.UpdateRecord(data);
        }

        /// <summary>
        /// Finds all the records with chosen first name.
        /// </summary>
        /// <param name="firstName">FirstName.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName) 
        {
            /*var result = from rec in this.list
                         where rec.FirstName.ToUpper() == firstName.ToUpper()
                         select rec;
            return result.ToArray();*/ //Realization with LINQ
            if (firstNameDictionary.ContainsKey(firstName.ToUpper()) && this.firstNameDictionary[firstName.ToUpper()].Count > 0)
            {
                return this.firstNameDictionary[firstName.ToUpper()];
            }
            else
            {
                Console.WriteLine($"There are no records with first name {firstName}");
                return null;
            }
        }

        /// <summary>
        /// Finds all the records withchosen last name.
        /// </summary>
        /// <param name="lastName">LastName.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName)
        {
            if (lastNameDictionary.ContainsKey(lastName.ToUpper()) && this.lastNameDictionary[lastName.ToUpper()].Count > 0)
            {
                return this.lastNameDictionary[lastName.ToUpper()];
            }
            else
            {
                Console.WriteLine($"There are no records with last name {lastName}");
                return null;
            }
        }

        /// <summary>
        /// Finds all the records with chosen date of birth.
        /// </summary>
        /// <param name="dateOfBirth">DateOfBirth.</param>
        /// <returns>Array of finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth)
        {
            if (dateOfBirthDictionary.ContainsKey(dateOfBirth.ToUpper()) && this.dateOfBirthDictionary[dateOfBirth.ToUpper()].Count > 0)
            {
                return this.dateOfBirthDictionary[dateOfBirth.ToUpper()];
            }
            else
            {
                Console.WriteLine($"There are no records with date of birth {dateOfBirth}");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            return Array.Empty<FileCabinetRecord>();
        }

        /// <summary>
        /// Returns amount of records
        /// </summary>
        /// <returns>Amount of records</returns>
        public int GetStat()
        {
            return this.list.Count;
        }

        /// <summary>
        /// Creates snapshot.
        /// </summary>
        /// <returns>Shapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot()
        {
            return new FileCabinetServiceSnapshot(this.list.ToArray());
        }
    }
}