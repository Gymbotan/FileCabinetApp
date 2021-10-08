// <copyright file="FileCabinetRecordXmlReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Class FileCabinetRecordXmlReader.
    /// </summary>
    public class FileCabinetRecordXmlReader
    {
        private readonly FileStream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordXmlReader"/> class.
        /// </summary>
        /// <param name="stream">FileStream.</param>
        public FileCabinetRecordXmlReader(FileStream stream)
        {
            this.stream = stream;
        }

        /// <summary>
        /// Reads all the records from a file.
        /// </summary>
        /// <returns>List of records.</returns>
        public IList<FileCabinetRecord> ReadAll()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ListOfXmlRecord));
            ListOfXmlRecord readedList = (ListOfXmlRecord)formatter.Deserialize(this.stream);

            List<FileCabinetRecord> list = new List<FileCabinetRecord>();
            foreach (XmlRecord rec in readedList.List)
            {
                list.Add(rec.ToFileCabinetRecord());
            }

            return list;
        }
    }
}
