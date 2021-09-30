// <copyright file="FileCabinetServiceSnapshot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// FileCabinetServiceSnapshot.
    /// </summary>
    public class FileCabinetServiceSnapshot
    {
        private readonly FileCabinetRecord[] records;

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
            sw.WriteLine("Id,First Name,Last Name,Height,Weight,Gender");
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
    }
}
