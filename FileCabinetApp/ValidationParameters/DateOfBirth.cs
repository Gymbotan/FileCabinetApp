// <copyright file="DateOfBirth.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.ValidationParameters
{
    using Newtonsoft.Json;

    /// <summary>
    /// DateOfBirth parameters.
    /// </summary>
    [JsonObject("dateOfBirth")]
    public class DateOfBirth
    {
        /// <summary>
        /// Gets or sets DateOfBirth from.
        /// </summary>
        [JsonProperty]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets DateOfBirth to.
        /// </summary>
        [JsonProperty]
        public string To { get; set; }
    }
}
