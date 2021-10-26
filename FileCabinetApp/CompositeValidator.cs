// <copyright file="CompositeValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class CompositeValidator.
    /// </summary>
    public class CompositeValidator : IRecordValidator
    {
        private readonly List<IRecordValidator> validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidator"/> class.
        /// </summary>
        /// <param name="recordValidators">Validators.</param>
        public CompositeValidator(IEnumerable<IRecordValidator> recordValidators)
        {
            this.validators = new List<IRecordValidator>();
            if (recordValidators != null)
            {
                foreach (var validator in recordValidators)
                {
                    if (validator != null)
                    {
                        this.validators.Add(validator);
                    }
                }
            }
        }

        /// <summary>
        /// Validates parameters.
        /// </summary>
        /// <param name="data">Data.</param>
        public void ValidateParameters(DataForRecord data)
        {
            foreach (var validator in this.validators)
            {
                validator.ValidateParameters(data);
            }
        }

        /// <summary>
        /// Validation of the first name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> FirstNameValidation(string firstName)
        {
            bool isSuccess = true;
            if (firstName.Length < 2 || firstName.Length > 50)
            {
                isSuccess = false;
            }

            return Tuple.Create(isSuccess, "First name's length should more than 1 and less than 51)");
        }

        /// <summary>
        /// Validation of the last name.
        /// </summary>
        /// <param name="lastName">Last name.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> LastNameValidation(string lastName)
        {
            bool isSuccess = true;
            if (lastName.Length < 2 || lastName.Length > 50)
            {
                isSuccess = false;
            }

            return Tuple.Create(isSuccess, "Last name's length should more than 1 and less than 51");
        }

        /// <summary>
        /// Validation of the date of birth.
        /// </summary>
        /// <param name="dateOfBirth">Date of birth.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> DateOfBirthValidation(DateTime dateOfBirth)
        {
            bool isSuccess = true;
            if (dateOfBirth < new DateTime(1930, 01, 01) || dateOfBirth > DateTime.Now)
            {
                isSuccess = false;
            }

            string str = "Wrong date of birth";
            return Tuple.Create(isSuccess, str);
        }

        /// <summary>
        /// Validation of the height.
        /// </summary>
        /// <param name="height">Height.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> HeightValidation(short height)
        {
            bool isSuccess = true;
            if (height < 30 || height > 250)
            {
                isSuccess = false;
            }

            string str = "Height should be more than 29 and less than 251";
            return Tuple.Create(isSuccess, str);
        }

        /// <summary>
        /// Validation of the weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> WeightValidation(decimal weight)
        {
            bool isSuccess = true;
            if (weight <= 0)
            {
                isSuccess = false;
            }

            string str = "Weight should be a positive number";
            return Tuple.Create(isSuccess, str);
        }

        /// <summary>
        /// Validation of the gender.
        /// </summary>
        /// <param name="gender">Gender.</param>
        /// <returns>Tuple(is successful, error message).</returns>
        public Tuple<bool, string> GenderValidation(char gender)
        {
            bool isSuccess = true;
            if (gender != 'm' && gender != 'f' && gender != 'a')
            {
                isSuccess = false;
            }

            string str = "Gender should be: m - male, f - female, a - another";
            return Tuple.Create(isSuccess, str);
        }
    }
}
