// <copyright file="FileCabinetCustomService.cs" company="PlaceholderCompany">
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
    /// Class that realizes all the custom services of the main class.
    /// </summary>
    public class FileCabinetCustomService : FileCabinetService
    {
        public override IRecordValidator CreateValidator()
        {
            Console.WriteLine("Custom validator created");
            return new CustomValidator();
        }
    }
}
