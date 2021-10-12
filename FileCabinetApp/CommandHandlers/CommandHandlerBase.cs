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
        private ICommandHandler nextHandler;

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public virtual void Handle(AppCommandRequest request)
        {
            if (this.nextHandler != null)
            {
                this.nextHandler.Handle(request);
            }
            else
            {
                CommonMethods.PrintMissedCommandInfo(request.Command);
            }
        }

        /// <summary>
        /// Set next handler.
        /// </summary>
        /// <param name="handler">Next handler.</param>
        public void SetNext(ICommandHandler handler)
        {
            this.nextHandler = handler;
        }
    }
}
