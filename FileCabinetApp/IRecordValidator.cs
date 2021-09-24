// <copyright file="IRecordValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp
{
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
    }
}
