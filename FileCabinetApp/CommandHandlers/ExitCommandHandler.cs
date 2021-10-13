// <copyright file="ExitCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;

    /// <summary>
    /// Handler of exit function.
    /// </summary>
    public class ExitCommandHandler : ServiceCommandHandlerBase
    {
        /// <summary>
        /// Delegate (get function from Program to change the field isRunning).
        /// </summary>
        private readonly Action<bool> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommandHandler"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        /// <param name="action">Function from Program.</param>
        public ExitCommandHandler(IFileCabinetService service, Action<bool> action)
            : base(service)
        {
            this.action = action;
        }

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                Console.WriteLine("Exiting an application...");
                this.service.Exit();
                this.action(false);
            }
            else
            {
                base.Handle(request);
            }
        }

        /// <summary>
        /// Shows whether can this handler handle the request.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>Can or not.</returns>
        private bool CanHandle(AppCommandRequest request)
        {
            if (request.Command.ToLower() == "exit")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
