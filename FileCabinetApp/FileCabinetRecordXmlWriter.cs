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
            throw new NotSupportedException();
        }
    }
}
