// <copyright file="LastNameValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class LastNameValidator.
    /// </summary>
    public class LastNameValidator : IRecordValidator
    {
        private readonly int minLength;
        private readonly int maxLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastNameValidator"/> class.
        /// </summary>
        /// <param name="minLength">MinLength.</param>
        /// <param name="maxLength">MaxLength.</param>
        public LastNameValidator(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="dateOfBirth">DateOfBirth.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> DateOfBirthValidation(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> FirstNameValidation(string firstName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="gender">gender.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> GenderValidation(char gender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="height">height.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> HeightValidation(short height)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> LastNameValidation(string lastName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unused validator.
        /// </summary>
        /// <param name="weight">weight.</param>
        /// <returns>Nothing.</returns>
        public Tuple<bool, string> WeightValidation(decimal weight)
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

            if (data.LastName.Length < this.minLength || data.LastName.Length > this.maxLength)
            {
                throw new ArgumentException(data.LastName);
            }
        }
    }
}
