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
    public class FileCabinetService
    {
        public FileCabinetService(IRecordValidator validator)
        {
            this.validator = validator;
        }

        private readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

        private readonly Dictionary<string, List<FileCabinetRecord>> firstNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        private readonly Dictionary<string, List<FileCabinetRecord>> lastNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        private readonly Dictionary<string, List<FileCabinetRecord>> dateOfBirthDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        public IRecordValidator validator;
        
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
        /// Creates new record
        /// </summary>
        /// <param name="data">Data for a new record</param>
        public int CreateRecord(DataForRecord data)
        {
            this.validator.ValidateParameters(data);
            
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
            this.validator.ValidateParameters(data);
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
        /// Finds all the records with chosen first name
        /// </summary>
        /// <param name="firstName">FirstName</param>
        /// <returns>Array of finded records</returns>
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
        /// Finds all the records withchosen last name
        /// </summary>
        /// <param name="lastName">LastName</param>
        /// <returns>Array of finded records</returns>
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
        /// Finds all the records with chosen date of birth
        /// </summary>
        /// <param name="dateOfBirth">DateOfBirth</param>
        /// <returns>Array of finded records</returns>
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
            // TODO: добавьте реализацию метода
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
        /// Allows you to input first name of a record.
        /// </summary>
        /// <param name="firstName">First name.</param>
        public void InputFirstName(ref string firstName)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name shouldn't be empty. Please input again");
                }
                else if (firstName.Length < 2 || firstName.Length > 60)
                {
                    Console.WriteLine("First name's length should more than 1 and less than 61. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }
        }

        /// <summary>
        /// Allows you to input larst name of a record.
        /// </summary>
        /// <param name="lastName">Last name.</param>
        public void InputLastName(ref string lastName)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name shouldn't be empty. Please input again");
                }
                else if (lastName.Length < 2 || lastName.Length > 60)
                {
                    Console.WriteLine("Last name's length should more than 1 and less than 61. Please input again");
                }
                else
                {
                    isCorrect = true;
                }
            }
        }

        /// <summary>
        /// Allows you to input date of birth of a record.
        /// </summary>
        /// <param name="dateOfBirth">Date of birth.</param>
        public void InputDateOfBirth(ref DateTime dateOfBirth)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Console.Write("Date of birth: ");
                    var inputs = Console.ReadLine().Split('/', 3);
                    dateOfBirth = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
                    if (dateOfBirth < new DateTime(1950, 01, 01) || dateOfBirth > DateTime.Now)
                    {
                        Console.WriteLine("Wrong date of birth");
                    }
                    else
                    {
                        isCorrect = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong date of birth");
                }
            }
        }

        /// <summary>
        /// Allows you to input height of a record.
        /// </summary>
        /// <param name="height">Height.</param>
        public void InputHeight(ref short height)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Height (cm): ");
                string temp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("Height shouldn't be empty. Please input again");
                }
                else
                {
                    try
                    {
                        height = short.Parse(temp);
                        if (height < 30 || height > 250)
                        {
                            Console.WriteLine("Height should be more than 29 and less than 251. Please input again");
                        }
                        else
                        {
                            isCorrect = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Height should be a number. Please imput again");
                    }
                }
            }
        }

        /// <summary>
        /// Allows you to input weight of a record.
        /// </summary>
        /// <param name="weight">Weight.</param>
        public void InputWeight(ref decimal weight)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Weight (kg): ");
                string temp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("Weight shouldn't be empty. Please input again");
                }
                else
                {
                    try
                    {
                        weight = decimal.Parse(temp);
                        if (weight <= 0)
                        {
                            Console.WriteLine("Weight should be a positive number. Please input again");
                        }
                        else
                        {
                            isCorrect = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Weight should be a positive number. Please imput again");
                    }
                }
            }
        }

        /// <summary>
        /// Allows you to input gender of a record.
        /// </summary>
        /// <param name="gender">Gender.</param>
        public void InputGender(ref char gender)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write("Gender (m - male, f - female, a - another): ");
                string gen = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gen))
                {
                    Console.WriteLine("Gender shouldn't be empty. Please input again");
                }
                else if (gen.Length > 1)
                {
                    Console.WriteLine("Gender should be: m - male, f - female, a - another. Please input again");
                }
                else
                {
                    gender = char.Parse(gen);
                    if (gender != 'm' && gender != 'f' && gender != 'a')
                    {
                        Console.WriteLine("Gender should be: m - male, f - female, a - another. Please input again");
                    }
                    else
                    {
                        isCorrect = true;
                    }
                }
            }
        }
    }
}
