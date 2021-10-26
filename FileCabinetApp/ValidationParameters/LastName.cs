// <copyright file="LastName.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.ValidationParameters
{
    using Newtonsoft.Json;

    /// <summary>
    /// LastName parameters.
    /// </summary>
    [JsonObject("lastName")]
    public class LastName
    {
        /// <summary>
        /// Gets or sets Min length of LastName.
        /// </summary>
        [JsonProperty]
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets Max length of LastName.
        /// </summary>
        [JsonProperty]
        public int Max { get; set; }
    }
}
