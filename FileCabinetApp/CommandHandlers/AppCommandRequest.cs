// <copyright file="AppCommandRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;

    /// <summary>
    /// Class AppCommandRequest.
    /// </summary>
    public class AppCommandRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppCommandRequest"/> class.
        /// </summary>
        public AppCommandRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCommandRequest"/> class.
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="parameters">Parameters.</param>
        public AppCommandRequest(string command, string parameters)
        {
            this.Command = command;
            this.Parameters = parameters;
        }

        /// <summary>
         /// Gets Command.
         /// </summary>
        public string Command { get; }

        /// <summary>
        /// Gets Parameters.
        /// </summary>
        public string Parameters { get; }
    }
}
