// <copyright file="ImportCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileCabinetApp.CommandHandlers
{
    using System;
    using System.IO;

    /// <summary>
    /// Handler of import function.
    /// </summary>
    public class ImportCommandHandler : CommandHandlerBase
    {
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
                    Console.WriteLine("Import failed: you inputed wrong parameters");
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
                        Console.WriteLine("Import failed: file namу is incorrect.");
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
                            Console.WriteLine($"Import failed: can't open file {path}");
                        }
                    }
                    catch
                    {
                        isSuccess = false;
                    }
                }

                if (isSuccess && inputs[0].ToUpper() == "CSV")
                {
                    try
                    {
                        FileStream fs = new FileStream(path, FileMode.Open);
                        FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                        snapshot.LoadFromCsv(fs);
                        Console.WriteLine($"All records were imported from file {fileName}");

                        Program.fileCabinetService.Restore(snapshot);
                        fs.Close();
                        fs.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (isSuccess && inputs[0].ToUpper() == "XML")
                {
                    try
                    {
                        FileStream fs = new FileStream(path, FileMode.Open);
                        FileCabinetServiceSnapshot snapshot = Program.fileCabinetService.MakeSnapshot();

                        snapshot.LoadFromXml(fs);
                        Console.WriteLine($"All records were imported from file {fileName}");

                        Program.fileCabinetService.Restore(snapshot);
                        fs.Close();
                        fs.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
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
            if (request.Command.ToLower() == "import")
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
