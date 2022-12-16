using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeOfWork { get; set; }
        public string MastersName { get; set; }
    }
}
