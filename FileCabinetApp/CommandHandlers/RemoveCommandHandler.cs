// <copyright file="RemoveCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Handler of remove function.
    /// </summary>
    public class RemoveCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                int recordId;

                if (!int.TryParse(request.Parameters, out recordId))
                {
                    Console.WriteLine("Record's number is missed. Please input again.");
                }
                else
                {
                    if (!Program.fileCabinetService.IsRecordExist(recordId))
                    {
                        Console.WriteLine($" Record #{recordId} doesn't exist.");
                    }
                    else
                    {
                        Program.fileCabinetService.RemoveRecord(recordId);
                        Console.WriteLine($" Record #{recordId} is removed.");
                    }
                }
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
            if (request.Command.ToLower() == "remove")
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
