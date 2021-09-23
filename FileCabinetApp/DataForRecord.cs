// <copyright file="DataForRecord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Data for FileCabinetRecord.
    /// </summary>
    public class DataForRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataForRecord"/> class.
        /// </summary>
        /// <param name="firstName">FirstName.</param>
        /// <param name="lastName">LastName.</param>
        /// <param name="dateOfBirth">DateOfBirth.</param>
        /// <param name="height">Height.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="gender">Gender.</param>
        public DataForRecord(string firstName, string lastName, DateTime dateOfBirth, short height, decimal weight, char gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Height = height;
            this.Weight = weight;
            this.Gender = gender;
        }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets DateOfBirth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets Height.
        /// </summary>
        public short Height { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets Gender.
        /// </summary>
        public char Gender { get; set; }
    }
}
