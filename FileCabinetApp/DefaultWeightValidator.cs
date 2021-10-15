// <copyright file="DefaultWeightValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class DefaultWeightValidator.
    /// </summary>
    public class DefaultWeightValidator : IRecordValidator
    {
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
            if (data.Weight <= 0)
            {
                throw new ArgumentException(data.Weight.ToString());
            }
        }
    }
}
