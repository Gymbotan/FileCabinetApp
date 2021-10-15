﻿// <copyright file="CustomValidator.cs" company="PlaceholderCompany">
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
    /// Custom validator.
    /// </summary>
    public class CustomValidator : IRecordValidator
    {
        /// <summary>
        /// Validates parameters.
        /// </summary>
        /// <param name="data">Data.</param>
        public void ValidateParameters(DataForRecord data)
        {
            new FirstNameValidator(2, 50).ValidateParameters(data);
            new LastNameValidator(2, 50).ValidateParameters(data);
            new DateOfBirthValidator(new DateTime(1930, 1, 1), DateTime.Now).ValidateParameters(data);
            new HeightValidator(30, 250).ValidateParameters(data);
            new WeightValidator(1, 200).ValidateParameters(data);
            new GenderValidator(new char[] { 'm', 'f', 'a' }).ValidateParameters(data);
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
