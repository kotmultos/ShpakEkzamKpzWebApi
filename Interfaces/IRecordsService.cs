using ShpakEkzamKpzWebApi.Models;
using ShpakEkzamKpzWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Interfaces
{
    interface IRecordsService
    {
        public void Add(HelperModel helper);

        public void DeleteById(int id);

        public IEnumerable<Record> GetAll();

        public Record GetById(int id);

        public Record UpdateById(int id, HelperModel helper);
        public IEnumerable<Record> FindByName(string word);
    }
}
