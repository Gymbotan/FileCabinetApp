// <copyright file="xmlRecord.cs" company="PlaceholderCompany">
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
    /// Class XmlRecord.
    /// </summary>
    [XmlType(TypeName = "record")]
    public class XmlRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlRecord"/> class.
        /// </summary>
        public XmlRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlRecord"/> class.
        /// </summary>
        /// <param name="record">record.</param>
        public XmlRecord(FileCabinetRecord record)
        {
            this.Id = record.Id;
            this.Name = new Name(record.FirstName, record.LastName);
            this.DateOfBirth = DateAsString(record.DateOfBirth);
            this.Height = record.Height;
            this.Weight = record.Weight;
            this.Gender = record.Gender.ToString();
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }

        /// <summary>
        /// Gets or sets dateOfBirth.
        /// </summary>
        [XmlElement(ElementName = "dateOfBirth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        [XmlElement(ElementName = "height")]
        public short Height { get; set; }

        /// <summary>
        /// Gets or sets weight.
        /// </summary>
        [XmlElement(ElementName = "weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets gender.
        /// </summary>
        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Transforms this class into FileCabinetRecord.
        /// </summary>
        /// <returns>new FileCabinetRecord.</returns>
        public FileCabinetRecord ToFileCabinetRecord()
        {
            return new FileCabinetRecord(this.Id, this.Name.FirstName, this.Name.LastName, StringToDate(this.DateOfBirth), this.Height, this.Weight, char.Parse(this.Gender));
        }

        private static string DateAsString(DateTime dt)
        {
            return string.Format("{0:00}", dt.Month) + "/" + string.Format("{0:00}", dt.Day) + "/" + dt.Year.ToString();
        }

        private static DateTime StringToDate(string str)
        {
            if (str == null)
            {
                return new DateTime(2000, 1, 1);
            }
            else
            {
                try
                {
                    var inputs = str.Split('/', 3);
                    DateTime date = new DateTime(int.Parse(inputs[2]), int.Parse(inputs[0]), int.Parse(inputs[1]));
                    return date;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new DateTime(2000, 1, 1);
                }
            }
        }
    }
}
