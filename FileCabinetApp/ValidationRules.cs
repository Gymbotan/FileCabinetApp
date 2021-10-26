// <copyright file="ValidationRules.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
    using FileCabinetApp.ValidationParameters;
    using Newtonsoft.Json;

    /// <summary>
    /// ValidationRules class.
    /// </summary>
    [JsonObject("validationrules")]
    public class ValidationRules
    {
        /// <summary>
        /// Gets or sets firstName.
        /// </summary>
        [JsonProperty]
        public FirstName FirstName { get; set; }

        /// <summary>
        /// Gets or sets lastName.
        /// </summary>
        [JsonProperty]
        public LastName LastName { get; set; }

        /// <summary>
        /// Gets or sets dateOfBirth.
        /// </summary>
        [JsonProperty]
        public DateOfBirth DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        [JsonProperty]
        public Height Height { get; set; }

        /// <summary>
        /// Gets or sets weight.
        /// </summary>
        [JsonProperty]
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets or sets gender.
        /// </summary>
        [JsonProperty]
        public char[] Gender { get; set; }
    }
}
