// <copyright file="ValidatorBuilder.cs" company="PlaceholderCompany">
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
    /// Class ValidatorBuilder.
    /// </summary>
    public class ValidatorBuilder
    {
        private readonly List<IRecordValidator> validators = new List<IRecordValidator>();

        /// <summary>
        /// ValidateFirstName.
        /// </summary>
        /// <param name="min">Min.</param>
        /// <param name="max">Max.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidateFirstName(int min, int max)
        {
            this.validators.Add(new FirstNameValidator(min, max));
            return this;
        }

        /// <summary>
        /// ValidateLastName.
        /// </summary>
        /// <param name="min">Min.</param>
        /// <param name="max">Max.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidateLastName(int min, int max)
        {
            this.validators.Add(new LastNameValidator(min, max));
            return this;
        }

        /// <summary>
        /// ValidateDateOfBirth.
        /// </summary>
        /// <param name="from">Date from.</param>
        /// <param name="to">Date to.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidateDateOfBirth(DateTime from, DateTime to)
        {
            this.validators.Add(new DateOfBirthValidator(from, to));
            return this;
        }

        /// <summary>
        /// ValidateHeight.
        /// </summary>
        /// <param name="min">Min.</param>
        /// <param name="max">Max.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidateHeight(short min, short max)
        {
            this.validators.Add(new HeightValidator(min, max));
            return this;
        }

        /// <summary>
        /// ValidateWeight.
        /// </summary>
        /// <param name="min">Min.</param>
        /// <param name="max">Max.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidateWeight(decimal min, decimal max)
        {
            this.validators.Add(new WeightValidator(min, max));
            return this;
        }

        /// <summary>
        /// ValidatorGender.
        /// </summary>
        /// <param name="array">Array of chars.</param>
        /// <returns>ValidatorBuilder.</returns>
        public ValidatorBuilder ValidatorGender(char[] array)
        {
            this.validators.Add(new GenderValidator(array));
            return this;
        }

        /// <summary>
        /// Create CompositeValidator.
        /// </summary>
        /// <returns>CompositeValidator.</returns>
        public CompositeValidator Create()
        {
            return new CompositeValidator(this.validators);
        }
    }
}
