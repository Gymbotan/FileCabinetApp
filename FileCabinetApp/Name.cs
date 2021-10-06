// <copyright file="Name.cs" company="PlaceholderCompany">
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
    /// Class Name.
    /// </summary>
    public class Name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        public Name()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="first">FirstName.</param>
        /// <param name="last">LastName.</param>
        public Name(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        /// <summary>
        /// Gets or sets firstName.
        /// </summary>
        [XmlAttribute("first")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets lastName.
        /// </summary>
        [XmlAttribute("last")]
        public string LastName { get; set; }
    }
}
