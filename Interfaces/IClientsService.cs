using ShpakEkzamKpzWebApi.Models;
using ShpakEkzamKpzWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Interfaces
{
    interface IClientsService
    {
        public IEnumerable<Client> GetAll();
        public Client GetById(int id);
        public void Add(ClientVM item);
        public Client UpdateById(int id, ClientVM item);
        public void DeleteById(int id);
        public IEnumerable<Client> FindByName(string word);
    }
}
