using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp
{
    class ServiceMeter : IFileCabinetService
    {
        private readonly IFileCabinetService service;
        private Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMeter"/> class.
        /// </summary>
        /// <param name="service">IFileCabinetService.</param>
        public ServiceMeter(IFileCabinetService service)
        {
            this.service = service;
            this.Validator = service.Validator;
        }

        /// <summary>
        /// Gets or sets validator.
        /// </summary>
        public IRecordValidator Validator { get; set; }

        /// <summary>
        /// Creates record.
        /// </summary>
        /// <param name="data">DataForRecord.</param>
        /// <returns>Record's id.</returns>
        public int CreateRecord(DataForRecord data)
        {
            this.watch.Start();
            int id = this.service.CreateRecord(data);
            this.watch.Stop();
            Console.WriteLine($"Create method execution duration is {this.watch.ElapsedTicks} ticks.");
            return id;
        }

        /// <summary>
        /// Edits record.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">DataForRecord.</param>
        public void EditRecord(int id, DataForRecord data)
        {
            this.watch.Start();
            this.service.EditRecord(id, data);
            this.watch.Stop();
            Console.WriteLine($"Edit method execution duration is {this.watch.ElapsedTicks} ticks.");
        }

        /// <summary>
        /// Exit.
        /// </summary>
        public void Exit()
        {
            this.watch.Start();
            this.service.Exit();
            this.watch.Stop();
            Console.WriteLine($"Exit method execution duration is {this.watch.ElapsedTicks} ticks.");
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="dateOfBirth">dateOfBirth.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByDateOfBirth(string dateOfBirth)
        {
            this.watch.Start();
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByDateOfBirth(dateOfBirth);
            this.watch.Stop();
            Console.WriteLine($"FindByDateOfBirth method execution duration is {this.watch.ElapsedTicks} ticks.");
            return list;
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByFirstName(string firstName)
        {
            this.watch.Start();
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByFirstName(firstName);
            this.watch.Stop();
            Console.WriteLine($"FindByFirstName method execution duration is {this.watch.ElapsedTicks} ticks.");
            return list;
        }

        /// <summary>
        /// Finds records.
        /// </summary>
        /// <param name="lastName">lastName.</param>
        /// <returns>Finded records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> FindByLastName(string lastName)
        {
            this.watch.Start();
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.FindByLastName(lastName);
            this.watch.Stop();
            Console.WriteLine($"FindByLastName method execution duration is {this.watch.ElapsedTicks} ticks.");
            return list;
        }

        /// <summary>
        /// Gets all the records.
        /// </summary>
        /// <returns>Records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            this.watch.Start();
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.GetRecords();
            this.watch.Stop();
            Console.WriteLine($"GetRecords method execution duration is {this.watch.ElapsedTicks} ticks.");
            return list;
        }

        /// <summary>
        /// Gets statistics of records.
        /// </summary>
        /// <returns>Statistics.</returns>
        public (int, int) GetStat()
        {
            this.watch.Start();
            (int, int) stats = this.service.GetStat();
            this.watch.Stop();
            Console.WriteLine($"GetStat method execution duration is {this.watch.ElapsedTicks} ticks.");
            return stats;
        }

        /// <summary>
        /// Checks is record exist.
        /// </summary>
        /// <param name="id">Record's id.</param>
        /// <returns>isExist.</returns>
        public bool IsRecordExist(int id)
        {
            this.watch.Start();
            bool isExist = this.service.IsRecordExist(id);
            this.watch.Stop();
            Console.WriteLine($"FindByLastName method execution duration is {this.watch.ElapsedTicks} ticks.");
            return isExist;
        }

        /// <summary>
        /// Returns list of records.
        /// </summary>
        /// <returns>List of records.</returns>
        public IReadOnlyCollection<FileCabinetRecord> ListRecords()
        {
            this.watch.Start();
            List<FileCabinetRecord> list = (List<FileCabinetRecord>)this.service.ListRecords();
            this.watch.Stop();
            Console.WriteLine($"FindByLastName method execution duration is {this.watch.ElapsedTicks} ticks.");
            return list;
        }

        /// <summary>
        /// Makes snapshot.
        /// </summary>
        /// <returns>Snapshot.</returns>
        public FileCabinetServiceSnapshot MakeSnapshot()
        {
            this.watch.Start();
            FileCabinetServiceSnapshot snapshot = this.service.MakeSnapshot();
            this.watch.Stop();
            Console.WriteLine($"FindByLastName method execution duration is {this.watch.ElapsedTicks} ticks.");
            return snapshot;
        }

        /// <summary>
        /// Purges removed records.
        /// </summary>
        public void Purge()
        {
            this.watch.Start();
            this.service.Purge();
            this.watch.Stop();
            Console.WriteLine($"Edit method execution duration is {this.watch.ElapsedTicks} ticks.");
        }

        /// <summary>
        /// Removes chosen record.
        /// </summary>
        /// <param name="recordId">RecordId.</param>
        public void RemoveRecord(int recordId)
        {
            this.watch.Start();
            this.service.RemoveRecord(recordId);
            this.watch.Stop();
            Console.WriteLine($"Edit method execution duration is {this.watch.ElapsedTicks} ticks.");
        }

        /// <summary>
        /// Restores FileCabinetService from snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot.</param>
        public void Restore(FileCabinetServiceSnapshot snapshot)
        {
            this.watch.Start();
            this.service.Restore(snapshot);
            this.watch.Stop();
            Console.WriteLine($"Edit method execution duration is {this.watch.ElapsedTicks} ticks.");
        }
    }
}
