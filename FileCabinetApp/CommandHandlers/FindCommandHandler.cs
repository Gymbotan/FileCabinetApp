// <copyright file="FindCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Handler of find function.
    /// </summary>
    public class FindCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                var inputs = request.Parameters.Split(' ', 2);
                switch (inputs[0].ToLower())
                {
                    case "firstname":
                        IReadOnlyCollection<FileCabinetRecord> findedArray = Program.fileCabinetService.FindByFirstName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        CommonMethods.ShowArray(findedArray);
                        break;
                    case "lastname":
                        findedArray = Program.fileCabinetService.FindByLastName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        CommonMethods.ShowArray(findedArray);
                        break;
                    case "dateofbirth":
                        findedArray = Program.fileCabinetService.FindByDateOfBirth(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        CommonMethods.ShowArray(findedArray);
                        break;
                    default:
                        Console.WriteLine("You unput wrong parameters.");
                        break;
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
            if (request.Command.ToLower() == "find")
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
