// <copyright file="IRecordValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;

    /// <summary>
    /// Interface for record validation.
    /// </summary>
    public interface IRecordValidator
    {
        /// <summary>
        /// Validates parameters.
        /// </summary>
        /// <param name="data">Data.</param>
        void ValidateParameters(DataForRecord data);

        /// <summary>
        /// Validation of the first name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> FirstNameValidator(string firstName);

        /// <summary>
        /// Validation of the last name.
        /// </summary>
        /// <param name="lastName">Last name.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> LastNameValidator(string lastName);

        /// <summary>
        /// Validation of the date of birth.
        /// </summary>
        /// <param name="dateOfBirth">Date of birth.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> DateOfBirthValidator(DateTime dateOfBirth);

        /// <summary>
        /// Validation of the height.
        /// </summary>
        /// <param name="height">Height.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> HeightValidator(short height);

        /// <summary>
        /// Validation of the weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> WeightValidator(decimal weight);

        /// <summary>
        /// Validation of the gender.
        /// </summary>
        /// <param name="gender">Gender.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> GenderValidator(char gender);
    }
}
