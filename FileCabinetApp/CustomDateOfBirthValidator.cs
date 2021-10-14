﻿// <copyright file="CustomDateOfBirthValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class CustomDateOfBirthValidator.
    /// </summary>
    public class CustomDateOfBirthValidator : IRecordValidator
    {
        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="dateOfBirth">DateOfBirth.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> DateOfBirthValidator(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> FirstNameValidator(string firstName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="gender">gender.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> GenderValidator(char gender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="height">height.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> HeightValidator(short height)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> LastNameValidator(string lastName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="weight">weight.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> WeightValidator(decimal weight)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates parameter.
        /// </summary>
        /// <param name="data">Data.</param>
        public void ValidateParameters(DataForRecord data)
        {
            if (data.DateOfBirth < new DateTime(1930, 01, 01) || data.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Wrong dateOfBirth");
            }
        }
    }
}
