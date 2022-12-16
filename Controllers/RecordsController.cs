using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShpakEkzamKpzWebApi.Models;
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
    public class RecordsController : ControllerBase
    {
        public RecordsService _service;
        public RecordsController(RecordsService service)
        {
            _service = service;
        }

        [HttpPost("add-record")]
        public IActionResult AddRecord([FromBody] HelperModel helper)
        {
            _service.Add(helper);
            return Ok();
        }

        [HttpGet("get-all-records")]
        public IActionResult GetAllRecords()
        {
            var allRecords = _service.GetAll();
            return Ok(allRecords);
        }

        [HttpGet("get-record-by-id/{id}")]
        public IActionResult GetRecordById(int id)
        {
            var record = _service.GetById(id);
            return Ok(record);
        }

        [HttpPut("update-record/{id}")]
        public IActionResult UpdateRecord(int id, [FromBody] HelperModel helper)
        {
            var res = _service.UpdateById(id, helper);
            return Ok(res);
        }

        [HttpDelete("delete-record/{id}")]
        public IActionResult DeleteClientById(int id)
        {
            _service.DeleteById(id);
            return Ok();
        }

        [HttpGet("find-records-by-name/{name}")]
        public IActionResult FindRecordsByName(string name)
        {
            var records = _service.FindByName(name);
            return Ok(records);
        }
    }
}
