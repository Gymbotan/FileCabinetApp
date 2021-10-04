// <copyright file="FileCabinetFilesystemService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
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
            this.fileStream.Seek(0, SeekOrigin.End);
            this.WriteRecordIntoFile(++this.size, data);
            return this.size;
        }

        /// <summary>
        /// EditRecord.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data.</param>
        public void EditRecord(int id, DataForRecord data)
        {
            this.fileStream.Seek(270 * (id - 1), SeekOrigin.Begin);
            this.WriteRecordIntoFile(id, data);
        }

        /// <summary>
        /// FindByDateOfBirth.
        /// </summary>
        /// <param name="dateOfBirth">dateOfBirth.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth)
        {
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.GetRecords();
            var result = from rec in list
                         where GetDateAsString(rec.DateOfBirth).ToUpper() == dateOfBirth.ToUpper()
                         select rec;
            List<FileCabinetRecord> resultList = new List<FileCabinetRecord>();
            foreach (var res in result)
            {
                resultList.Add(res);
            }

            return resultList;
        }

        /// <summary>
        /// FindByFirstName.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName)
        {
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.GetRecords();
            var result = from rec in list
                         where rec.FirstName.ToUpper() == firstName.ToUpper()
                         select rec;
            List<FileCabinetRecord> resultList = new List<FileCabinetRecord>();
            foreach (var res in result)
            {
                resultList.Add(res);
            }

            return resultList;
        }

        /// <summary>
        /// FindByLastName.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Collection.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName)
        {
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.GetRecords();
            var result = from rec in list
                         where rec.LastName.ToUpper() == lastName.ToUpper()
                         select rec;
            List<FileCabinetRecord> resultList = new List<FileCabinetRecord>();
            foreach (var res in result)
            {
                resultList.Add(res);
            }

            return resultList;
        }

        /// <summary>
        /// GetStat.
        /// </summary>
        /// <returns>Int.</returns>
        public int GetStat()
        {
            return this.size;
        }

        /// <summary>
        /// IsRecordExist.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool IsRecordExist(int id)
        {
            if (id <= this.size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ListRecords.
        /// </summary>
        public void ListRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all the records in a file.
        /// </summary>
        /// <returns>Records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            List<FileCabinetRecord> list = new List<FileCabinetRecord>();
            this.fileStream.Seek(0, SeekOrigin.Begin);
            byte[] byte2 = new byte[2];
            byte[] byte4 = new byte[4];
            byte[] byte8 = new byte[8];
            byte[] byte120 = new byte[120];
            while (this.fileStream.Position < this.fileStream.Length)
            {
                this.fileStream.Seek(2, SeekOrigin.Current);
                this.fileStream.Read(byte4, 0, 4);
                int id = BitConverter.ToInt32(byte4);

                this.fileStream.Read(byte120, 0, 120);
                char[] charArray = Encoding.Default.GetChars(byte120);
                StringBuilder sb = new StringBuilder();
                foreach (char ch in charArray)
                {
                    if (char.IsLetter(ch))
                    {
                        sb.Append(ch);
                    }
                }

                string firstName = sb.ToString();

                this.fileStream.Read(byte120, 0, 120);
                charArray = Encoding.Default.GetChars(byte120);
                StringBuilder sb2 = new StringBuilder();
                foreach (char ch in charArray)
                {
                    if (char.IsLetter(ch))
                    {
                        sb2.Append(ch);
                    }
                }

                string lastName = sb2.ToString();

                this.fileStream.Read(byte4, 0, 4);
                int year = BitConverter.ToInt32(byte4);
                this.fileStream.Read(byte4, 0, 4);
                int month = BitConverter.ToInt32(byte4);
                this.fileStream.Read(byte4, 0, 4);
                int day = BitConverter.ToInt32(byte4);
                DateTime dateOfBirth = new DateTime(year, month, day);

                this.fileStream.Read(byte2, 0, 2);
                short height = BitConverter.ToInt16(byte2);

                this.fileStream.Read(byte8, 0, 8);
                decimal weight = Convert.ToDecimal(BitConverter.ToDouble(byte8));

                this.fileStream.Read(byte2, 0, 2);
                char gender = BitConverter.ToChar(byte2);

                list.Add(new FileCabinetRecord(id, firstName, lastName, dateOfBirth, height, weight, gender));
            }

            return list;
        }

        /// <summary>
        /// MakeSnapshot.
        /// </summary>
        /// <returns>FileCabinetServiceSnapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exit.
        /// </summary>
        public void Exit()
        {
            this.fileStream.Close();
            this.fileStream.Dispose();
        }

        private static string GetDateAsString(DateTime date)
        {
            return $"{date.Year}-{date.ToString("MMM", CultureInfo.GetCultureInfo("en-us"))}-{date.Day}".ToUpper();
        }

        private void WriteRecordIntoFile(int id, DataForRecord data)
        {
            this.fileStream.Write(new byte[2]);

            this.fileStream.Write(BitConverter.GetBytes(id));

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
        }
    }
}
