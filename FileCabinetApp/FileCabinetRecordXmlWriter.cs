// <copyright file="FileCabinetRecordXmlWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// FileCabinetRecordXmlWriter.
    /// </summary>
    public class FileCabinetRecordXmlWriter
    {
        private readonly XmlWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordXmlWriter"/> class.
        /// </summary>
        /// <param name="writer">Text writer.</param>
        public FileCabinetRecordXmlWriter(XmlWriter writer)
        {
            this.writer = writer;
        }

        /// <summary>
        /// Writes records in file.
        /// </summary>
        /// <param name="record">Record.</param>
        public void Write(FileCabinetRecord record)
        {
            this.writer.WriteStartElement("record");
            this.writer.WriteAttributeString("id", record.Id.ToString());

            this.writer.WriteStartElement("name", string.Empty);
            this.writer.WriteAttributeString("first", record.FirstName);
            this.writer.WriteAttributeString("last", record.LastName);
            this.writer.WriteEndElement();

            this.writer.WriteStartElement("dateOfBirth");
            this.writer.WriteString(DateAsString(record.DateOfBirth));
            this.writer.WriteEndElement();

            this.writer.WriteStartElement("height");
            this.writer.WriteString(record.Height.ToString());
            this.writer.WriteEndElement();

            this.writer.WriteStartElement("weight");
            this.writer.WriteString(record.Weight.ToString());
            this.writer.WriteEndElement();

            this.writer.WriteStartElement("gender");
            this.writer.WriteString(record.Gender.ToString());
            this.writer.WriteEndElement();

            this.writer.WriteEndElement();
        }

        private static string DateAsString(DateTime dt)
        {
            return string.Format("{0:00}", dt.Month) + "/" + string.Format("{0:00}", dt.Day) + "/" + dt.Year.ToString();
        }

    }
}
