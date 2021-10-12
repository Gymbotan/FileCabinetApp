// <copyright file="ExportCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Handler of export function.
    /// </summary>
    public class ExportCommandHandler : ServiceCommandHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportCommandHandler"/> class.
        /// </summary>
        /// <param name="service">FileCabinetService.</param>
        public ExportCommandHandler(IFileCabinetService service)
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
                bool isSuccess = true;
                string[] inputs = new string[2];
                string path = null;
                string fileName = null;
                string directoryName;
                try
                {
                    inputs = request.Parameters.Split(' ', 2);
                }
                catch
                {
                    Console.WriteLine("Export failed: you inputed wrong parameters");
                    isSuccess = false;
                }

                if (isSuccess)
                {
                    try
                    {
                        path = inputs[1];
                        fileName = Path.GetFileName(path);
                    }
                    catch
                    {
                        Console.WriteLine("Export failed: file namу is incorrect.");
                        isSuccess = false;
                    }
                }

                if (isSuccess)
                {
                    try
                    {
                        directoryName = Path.GetDirectoryName(path);
                        if (string.IsNullOrWhiteSpace(directoryName))
                        {
                            directoryName = "i:\\";
                            path = directoryName + path;
                        }

                        if (!Directory.Exists(directoryName))
                        {
                            Console.WriteLine($"Export failed: can't open file {path}");
                        }
                    }
                    catch
                    {
                        isSuccess = false;
                    }
                }

                if (isSuccess && File.Exists(path))
                {
                    Console.Write($"File is exist - rewrite {path}? [y/n] ");
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input.ToUpper() == "N")
                        {
                            isSuccess = false;
                            break;
                        }
                        else if (input.ToUpper() == "Y")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Wrong input. Choose again [y/n] ");
                        }
                    }
                }

                if (isSuccess && inputs[0].ToUpper() == "CSV")
                {
                    StreamWriter sw = new StreamWriter(path);
                    FileCabinetServiceSnapshot snapshot = this.service.MakeSnapshot();

                    snapshot.SaveToCsv(sw);
                    Console.WriteLine($"All records are exported to file {fileName}");
                }

                if (isSuccess && inputs[0].ToUpper() == "XML")
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "\t";
                    XmlWriter xw = XmlWriter.Create(path, settings);
                    FileCabinetServiceSnapshot snapshot = this.service.MakeSnapshot();

                    snapshot.SaveToXml(xw);
                    Console.WriteLine($"All records are exported to file {fileName}");
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
            if (request.Command.ToLower() == "export")
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
