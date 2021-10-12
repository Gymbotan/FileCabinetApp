// <copyright file="CreateCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;

    /// <summary>
    /// Handler of create function.
    /// </summary>
    public class CreateCommandHandler : ServiceCommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommandHandler"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        public CreateCommandHandler(IFileCabinetService service)
            : base(service)
        {
        }

        /// <summary>
        /// Handles request.
        /// </summary>
        /// <param name="request">Request.</param>
        public override void Handle(AppCommandRequest request)
        {
            if (this.CanHandle(request))
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

                Console.WriteLine($"Record #{this.service.CreateRecord(data)} is created");
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
            if (request.Command.ToLower() == "create")
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
