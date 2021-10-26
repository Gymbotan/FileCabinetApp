// <copyright file="Weight.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.ValidationParameters
{
    using Newtonsoft.Json;

    /// <summary>
    /// Weight parameters.
    /// </summary>
    [JsonObject("weight")]
    public class Weight
    {
        /// <summary>
        /// Gets or sets Min value of Weight.
        /// </summary>
        [JsonProperty]
        public decimal Min { get; set; }

        /// <summary>
        /// Gets or sets Max value of Weight.
        /// </summary>
        [JsonProperty]
        public decimal Max { get; set; }
    }
}
