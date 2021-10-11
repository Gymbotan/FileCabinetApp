// <copyright file="ICommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    /// <summary>
    /// Interface ICommandHandler.
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Set next handler.
        /// </summary>
        /// <param name="handler">Handler.</param>
        public void SetNext(ICommandHandler handler);

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public void Handle(AppCommandRequest request);
    }
}
