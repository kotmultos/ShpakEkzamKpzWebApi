using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public Client Client { get; set; }
    }
}
