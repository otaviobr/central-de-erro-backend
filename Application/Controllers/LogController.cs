using Api.Repository.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        protected readonly IServiceLog _service;

        public LogController(IServiceLog service)
        {
            _service = service;
        }

        [Authorize]
        [Route("GetAll")]
        [HttpGet]
        public IList<Log> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetPrimary")]
        [Authorize]
        public ActionResult GetPrimary()
        {
            return Ok(_service.GetByBox("primary"));
        }

        [HttpGet]
        [Route("GetArchived")]
        [Authorize]
        public ActionResult GetArchived()
        {
            return Ok(_service.GetByBox("archive"));
        }

        [HttpGet]
        [Route("GetByFrequency")]
        [Authorize]
        public ActionResult GetByFrequency(int frequency)
        {
            if (frequency < 1)
                return StatusCode(400, new { message = "Frequência inválida" });

            return Ok(_service.GetByFrequency(frequency));
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public ActionResult GetById(int id)
        {
            if (id < 1)
                return StatusCode(400, new { message = "Id inválido" });

            return Ok(_service.GetById(id));
        }

        [HttpGet]
        [Route("GetByLevel")]
        [Authorize]
        public ActionResult GetByLevel(string level)
        {
            if (string.IsNullOrEmpty(level) || string.IsNullOrWhiteSpace(level))
                return StatusCode(400, new { message = "Level inválido" });

            return Ok(_service.GetByLevel(level));
        }

        [HttpGet]
        [Route("GetByOrigin")]
        [Authorize]
        public ActionResult GetByOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrWhiteSpace(origin))
                return StatusCode(400, new { message = "Level inválido" });

            return Ok(_service.GetByOrigin(origin));
        }

        [HttpPut]
        [Route("ToArchive")]
        [Authorize]
        public ActionResult ToArchive([FromBody] List<Log> logs)
        {
            if (logs.Count < 1)
                return BadRequest("Nenhum log enviado");

            return Ok(_service.ToArchive(logs));
        }

        [HttpPut]
        [Route("ToPrimary")]
        [Authorize]
        public ActionResult ToPrimary([FromBody] List<Log> logs)
        {
            if (logs.Count < 1)
                return BadRequest("Nenhum log enviado");

            return Ok(_service.ToPrimary(logs));
        }
        
        [HttpPost]
        [Route("ToPrimaryAll")]
        [Authorize]
        public ActionResult ToPrimaryAll()
        {
            string response;
            try
            {
                response =  _service.ToPrimaryAll();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(response);
        }
    }
}
