using Microsoft.EntityFrameworkCore;
using ShpakEkzamKpzWebApi.Interfaces;
using ShpakEkzamKpzWebApi.Models;
using ShpakEkzamKpzWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Services
{
    public class RecordsService : IRecordsService
    {
        private AppDbContext _context;
        public RecordsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(HelperModel helper)
        {
            var _client = _context.Clients.Find(helper.DesiredId);

            if (_client != null)
            {
                var _record = new Record()
                {
                    Date = helper.Time,
                    Client = _client
                };

                _context.Records.Add(_record);
                _context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var _record = _context.Records.Find(id);
            if (_record != null)
            {
                _context.Records.Remove(_record);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Record> GetAll()
        {
            return _context.Records.Include(c => c.Client).ToList();
        }

        public Record GetById(int id)
        {
            return _context.Records.Include(c => c.Client).FirstOrDefault(n => n.Id == id);
        }

        public Record UpdateById(int id, HelperModel helper)
        {
            var _record = _context.Records.Find(id);
            var _client = _context.Clients.Find(helper.DesiredId);

            if (_record != null && _client != null)
            {
                _record.Date = helper.Time;
                _record.Client = _client;

                _context.SaveChanges();
            }
            
            return _record;
        }

        public IEnumerable<Record> FindByName(string word)
        {
            var result = _context.Records.Where(d => d.Client.Name.Contains(word)
            || d.Client.MastersName.Contains(word)).Include(c => c.Client).ToList();
            return result;
        }
    }
}
