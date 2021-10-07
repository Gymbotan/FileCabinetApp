// <copyright file="ListOfXmlRecord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Class ListOfXmlRecord.
    /// </summary>
    [XmlRoot("records")]
    public class ListOfXmlRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfXmlRecord"/> class.
        /// </summary>
        public ListOfXmlRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfXmlRecord"/> class.
        /// </summary>
        /// <param name="list">List of FileCabinetRecord.</param>
        public ListOfXmlRecord(List<FileCabinetRecord> list)
        {
            this.List = new List<XmlRecord>();
            foreach (FileCabinetRecord rec in list)
            {
                this.List.Add(new XmlRecord(rec));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListOfXmlRecord"/> class.
        /// </summary>
        /// <param name="list">List of XmlRecord.</param>
        public ListOfXmlRecord(List<XmlRecord> list)
        {
            this.List = list;
        }

        /// <summary>
        /// Gets or sets list of xml records.
        /// </summary>
        [XmlElement("record")]
        public List<XmlRecord> List { get; set; }
    }
}
