// <copyright file="EditCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;

    /// <summary>
    /// Handler of edit function.
    /// </summary>
    public class EditCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditCommandHandler"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        public EditCommandHandler(IFileCabinetService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
            {
                int recordId = -1;

                if (!int.TryParse(request.Parameters, out recordId))
                {
                    Console.WriteLine("Record's number is missed. Please input again.");
                }
                else
                {
                    if (this.service.IsRecordExist(recordId))
                    {
                        Console.WriteLine($"#{recordId} record is not found.");
                    }
                    else
                    {
                        Console.Write("First name: ");
                        string firstName = CommonMethods.ReadInput<string>(CommonMethods.StringConverter, this.service.Validator.FirstNameValidator);

                        Console.Write("Last name: ");
                        var lastName = CommonMethods.ReadInput<string>(CommonMethods.StringConverter, this.service.Validator.LastNameValidator);

                        Console.Write("Date of birth: ");
                        var dateOfBirth = CommonMethods.ReadInput<DateTime>(CommonMethods.DateConverter, this.service.Validator.DateOfBirthValidator);

                        Console.Write("Height: ");
                        var height = CommonMethods.ReadInput<short>(CommonMethods.ShortConverter, this.service.Validator.HeightValidator);

                        Console.Write("Weight: ");
                        var weight = CommonMethods.ReadInput<decimal>(CommonMethods.DecimalConverter, this.service.Validator.WeightValidator);

                        Console.Write("Gender (m, f or a): ");
                        var gender = CommonMethods.ReadInput<char>(CommonMethods.CharConverter, this.service.Validator.GenderValidator);

                        DataForRecord data = new DataForRecord(firstName, lastName, dateOfBirth, height, weight, gender);

                        this.service.EditRecord(recordId, data);
                        Console.WriteLine($"Record #{recordId} is updated.");
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
            if (request.Command.ToLower() == "edit")
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
