// <copyright file="ServiceCommandHandlerBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    /// <summary>
    /// Superclass ServiceCommandHandlerBase.
    /// </summary>
    public abstract class ServiceCommandHandlerBase : CommandHandlerBase
    {
        /// <summary>
        /// FileCabinetService.
        /// </summary>
        protected IFileCabinetService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCommandHandlerBase"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        public ServiceCommandHandlerBase(IFileCabinetService service)
        {
            this.service = service;
        }
    }
}
