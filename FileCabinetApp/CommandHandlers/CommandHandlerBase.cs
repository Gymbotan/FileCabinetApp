// <copyright file="CommandHandlerBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    /// <summary>
    /// Class CommandHandlerBase.
    /// </summary>
    public abstract class CommandHandlerBase : ICommandHandler
    {
        /// <summary>
        /// NextHandler.
        /// </summary>
        private readonly ICommandHandler nextHandler;

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public abstract void Handle(AppCommandRequest request);

        /// <summary>
        /// Set next handler.
        /// </summary>
        /// <param name="handler">Next handler.</param>
        public abstract void SetNext(ICommandHandler handler);
    }
}
