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
    public class FindCommandHandler : ServiceCommandHandlerBase
    {
        private readonly Action<IEnumerable<FileCabinetRecord>> print;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindCommandHandler"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        /// <param name="print">Printer.</param>
        public FindCommandHandler(IFileCabinetService service, Action<IEnumerable<FileCabinetRecord>> print)
            : base(service)
        {
            this.print = print;
        }

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
                        IReadOnlyCollection<FileCabinetRecord> findedArray = this.service.FindByFirstName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        this.print(findedArray);
                        break;
                    case "lastname":
                        findedArray = this.service.FindByLastName(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        this.print(findedArray);
                        break;
                    case "dateofbirth":
                        findedArray = this.service.FindByDateOfBirth(inputs[1].Replace("\"", string.Empty).Replace("\'", string.Empty));
                        this.print(findedArray);
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
