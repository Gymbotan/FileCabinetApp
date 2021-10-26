// <copyright file="FirstName.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.ValidationParameters
{
    using Newtonsoft.Json;

    /// <summary>
    /// FirstName parameters.
    /// </summary>
    [JsonObject("firstName")]
    public class FirstName
    {
        /// <summary>
        /// Gets or sets Min length of firstName.
        /// </summary>
        [JsonProperty]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets Max length of firstName.
        /// </summary>
        [JsonProperty]
        public int Max { get; set; }
    }
}
