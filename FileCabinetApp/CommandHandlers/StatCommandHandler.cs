// <copyright file="StatCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Handler of stat function.
    /// </summary>
    public class StatCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                var recordsCount = Program.fileCabinetService.GetStat();
                Console.WriteLine($"There are {recordsCount.Item1} record(s), {recordsCount.Item2} record(s) were removed.");
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
            if (request.Command.ToLower() == "stat")
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
