// <copyright file="FileCabinetServiceSnapshot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// FileCabinetServiceSnapshot.
    /// </summary>
    public class FileCabinetServiceSnapshot
    {
        private FileCabinetRecord[] records;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetServiceSnapshot"/> class.
        /// </summary>
        /// <param name="records">Existing records.</param>
        public FileCabinetServiceSnapshot(FileCabinetRecord[] records)
        {
            this.records = records;
        }

        /// <summary>
        /// Save to csv.
        /// </summary>
        /// <param name="sw">Stream writer.</param>
        public void SaveToCsv(StreamWriter sw)
        {
            FileCabinetRecordCsvWriter csvWriter = new FileCabinetRecordCsvWriter(sw);
            sw.WriteLine("Id,First Name,Last Name,Date Of Birth,Height,Weight,Gender");
            foreach (var rec in this.records)
            {
                csvWriter.Write(rec);
            }

            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// Save to xml.
        /// </summary>
        /// <param name="xw">Xml writer.</param>
        public void SaveToXml(XmlWriter xw)
        {
            FileCabinetRecordXmlWriter xmlWriter = new FileCabinetRecordXmlWriter(xw);
            xw.WriteStartDocument();
            xw.WriteStartElement("records");

            foreach (var rec in this.records)
            {
                xmlWriter.Write(rec);
            }

            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
            xw.Dispose();
        }

        /// <summary>
        /// Loads data from csv file.
        /// </summary>
        /// <param name="fs">FileStream.</param>
        public void LoadFromCsv(FileStream fs)
        {
            FileCabinetRecordCsvReader reader = new FileCabinetRecordCsvReader(new StreamReader(fs));
            List<FileCabinetRecord> resultList = new List<FileCabinetRecord>(this.records);
            List<FileCabinetRecord> readedList = (List<FileCabinetRecord>)reader.ReadAll();

            int index;
            foreach (FileCabinetRecord record in readedList)
            {
                if ((index = resultList.IndexOf(resultList.Find(x => x.Id == record.Id))) != -1)
                {
                    resultList[index] = record;
                }
                else
                {
                    resultList.Add(record);
                }
            }

            this.records = resultList.ToArray();
        }

        /// <summary>
        /// Returns all the records from snapshot.
        /// </summary>
        /// <returns>Array of records.</returns>
        public FileCabinetRecord[] GetRecords()
        {
            return this.records;
        }
    }
}
