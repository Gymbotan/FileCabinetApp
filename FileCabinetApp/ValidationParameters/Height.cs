// <copyright file="Height.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.ValidationParameters
{
    using Newtonsoft.Json;

    /// <summary>
    /// Height parameters.
    /// </summary>
    [JsonObject("height")]
    public class Height
    {
        /// <summary>
        /// Gets or sets Min value of Height.
        /// </summary>
        [JsonProperty]
        public short Min { get; set; }

        /// <summary>
        /// Gets or sets Max value of Height.
        /// </summary>
        [JsonProperty]
        public short Max { get; set; }
    }
}
