using ShpakEkzamKpzWebApi.Interfaces;
using ShpakEkzamKpzWebApi.Models;
using ShpakEkzamKpzWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Services
{
    public class ClientsService : IClientsService
    {
        private AppDbContext _context;
        public ClientsService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ClientVM item)
        {
            var _client = new Client()
            {
                Name = item.Name,
                TypeOfWork = item.TypeOfWork,
                MastersName = item.MastersName,
            };
            _context.Clients.Add(_client);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var _client = _context.Clients.Find(id);
            if (_client != null)
            {
                var records = _context.Records.Where(d => d.Client.Id == _client.Id).ToList();
                _context.Records.RemoveRange(records);
                _context.Clients.Remove(_client);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Client> FindByName(string word)
        {
            var result = _context.Clients.Where(d => d.Name.Contains(word) || d.MastersName.Contains(word)).ToList();
            return result;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.FirstOrDefault(n => n.Id == id);
        }

        public Client UpdateById(int id, ClientVM item)
        {
            var _client = _context.Clients.Find(id);

            if (_client != null)
            {
                _client.Name = item.Name;
                _client.TypeOfWork = item.TypeOfWork;
                _client.MastersName = item.MastersName;
            }

            _context.SaveChanges();
            return _client;
        }
    }
}
