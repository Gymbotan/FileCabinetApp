﻿// <copyright file="CustomLastNameValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class CustomLastNameValidator.
    /// </summary>
    public class CustomLastNameValidator : IRecordValidator
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
            if (string.IsNullOrWhiteSpace(data.LastName))
            {
                throw new ArgumentNullException(data.LastName);
            }

            if (data.LastName.Length < 2 || data.LastName.Length > 50)
            {
                throw new ArgumentException(data.LastName);
            }
        }
    }
}
