﻿// <copyright file="FileCabinetCustomService.cs" company="PlaceholderCompany">
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
    /// Class that realizes all the custom services of the main class.
    /// </summary>
    public class FileCabinetCustomService : FileCabinetService
    {
        /// <summary>
        /// Validates inputed data.
        /// </summary>
        /// <param name="data">Data.</param>
        protected override void ValidateParameter(DataForRecord data)
        {
            if (string.IsNullOrWhiteSpace(data.FirstName))
            {
                throw new ArgumentNullException(data.FirstName);
            }

            if (string.IsNullOrWhiteSpace(data.LastName))
            {
                throw new ArgumentNullException(data.LastName);
            }

            if (data.FirstName.Length < 2 || data.FirstName.Length > 60)
            {
                throw new ArgumentException(data.FirstName);
            }

            if (data.LastName.Length < 2 || data.LastName.Length > 60)
            {
                throw new ArgumentException(data.LastName);
            }

            if (data.DateOfBirth < new DateTime(1950, 01, 01) || data.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Wrong dateOfBirth");
            }

            if (data.Height < 30 || data.Height > 250)
            {
                throw new ArgumentException(data.Height.ToString());
            }

            if (data.Weight <= 0)
            {
                throw new ArgumentException(data.Weight.ToString());
            }

            if (data.Gender != 'm' && data.Gender != 'f' && data.Gender != 'a')
            {
                throw new ArgumentException(data.Gender.ToString());
            }
        }
    }
}
