using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShpakEkzamKpzWebApi.Services;
using ShpakEkzamKpzWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShpakEkzamKpzWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public ClientsService _service;
        public ClientsController(ClientsService service)
        {
            _service = service;
        }

        [HttpPost("add-client")]
        public IActionResult AddClient([FromBody] ClientVM client)
        {
            _service.Add(client);
            return Ok();
        }

        [HttpGet("get-all-clients")]
        public IActionResult GetAllClients()
        {
            var allClients = _service.GetAll();
            return Ok(allClients);
        }

        [HttpGet("get-client-by-id/{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _service.GetById(id);
            return Ok(client);
        }

        //[HttpGet("find-patient-by-name/{name}")]
        //public IActionResult FindPatientByName(string name)
        //{
        //    var patients = _service.FindByWord(name);
        //    return Ok(patients);
        //}

        [HttpPut("update-client/{id}")]
        public IActionResult UpdateClientById(int id, [FromBody] ClientVM client)
        {
            var res = _service.UpdateById(id, client);
            return Ok(res);
        }

        [HttpDelete("delete-client/{id}")]
        public IActionResult DeleteClientById(int id)
        {
            _service.DeleteById(id);
            return Ok();
        }

        [HttpGet("find-clients-by-name/{name}")]
        public IActionResult FindClientsByName(string name)
        {
            var clients = _service.FindByName(name);
            return Ok(clients);
        }
    }
}
