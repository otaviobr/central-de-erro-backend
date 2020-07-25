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

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="lvm">LogViewModel</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Nenhum log encontrado.</response>
        /// <response code="404"> Nenhum log encontrado.</response>
        [ProducesResponseType(typeof(Log), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize]
        [Route("Get")]
        [HttpPost]
        public ActionResult Get([FromBody] LogViewModel lvm)
        {
            if (lvm == null)
                return StatusCode(400, "Object null.");

            var log = _service.Get(lvm);
            
            if (log != null)
                return Ok(log);
            else
                return NotFound("No Content");
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        [ProducesResponseType(typeof(List<LogViewModel>), 200)]
        [Authorize]
        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        [ProducesResponseType(typeof(List<LogViewModel>), 200)]
        [HttpGet]
        [Route("GetPrimary")]
        [Authorize]
        public ActionResult GetPrimary()
        {
            return Ok(_service.GetByBox("primary"));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        [ProducesResponseType(typeof(List<LogViewModel>), 200)]
        [HttpGet]
        [Route("GetArchived")]
        [Authorize]
        public ActionResult GetArchived()
        {
            return Ok(_service.GetByBox("archive"));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="frequency">Frequencia para consulta</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Frequencia inválida.</response>
        [ProducesResponseType(typeof(List<Log>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        [Route("GetByFrequency")]
        [Authorize]
        public ActionResult GetByFrequency(int frequency)
        {
            if (frequency < 1)
                return StatusCode(400, new { message = "Frequência inválida" });

            return Ok(_service.GetByFrequency(frequency));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="id">Id para consulta</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Id inválido.</response>
        [ProducesResponseType(typeof(Log), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public ActionResult GetById(int id)
        {
            if (id < 1)
                return StatusCode(400, new { message = "Id inválido" });

            return Ok(_service.GetById(id));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="level">Level</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Level inválido.</response>
        [ProducesResponseType(typeof(IList<LogViewModel>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        [Route("GetByLevel")]
        [Authorize]
        public ActionResult GetByLevel(string level)
        {
            if (string.IsNullOrEmpty(level) || string.IsNullOrWhiteSpace(level))
                return StatusCode(400, new { message = "Level inválido" });

            return Ok(_service.GetByLevel(level));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="origin">Origem</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Origin inválido.</response>
        [ProducesResponseType(typeof(IList<LogViewModel>), 200)]
        [ProducesResponseType(400)]
        [HttpGet]
        [Route("GetByOrigin")]
        [Authorize]
        public ActionResult GetByOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrWhiteSpace(origin))
                return StatusCode(400, new { message = "Origin inválido" });

            return Ok(_service.GetByOrigin(origin));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="logs">Lista de logs</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Nenhum log enviado.</response>
        [ProducesResponseType(typeof(IList<LogViewModel>), 200)]
        [ProducesResponseType(400)]
        [HttpPut]
        [Route("ToArchive")]
        [Authorize]
        public ActionResult ToArchive([FromBody] List<LogViewModel> logs)
        {
            if (logs.Count < 1)
                return BadRequest("Nenhum log enviado");

            var retorno = _service.ToArchive(logs);

            return Ok(retorno);
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="logs">Lista de logs</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="400"> Nenhun log enviado.</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [HttpPut]
        [Route("ToPrimary")]
        [Authorize]
        public ActionResult ToPrimary([FromBody] List<LogViewModel> logs)
        {
            if (logs.Count < 1)
                return BadRequest("Nenhum log enviado");

            return Ok(_service.ToPrimary(logs));
        }

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="500"> Erro interno.</response>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Endpoints para Logs.
        /// </summary>
        /// <param name="env">Environment</param>
        /// <param name="order">Order by</param>
        /// <param name="search">string to search</param>
        /// <response code="200"> Logs obtidos com sucesso.</response>
        /// <response code="500"> Erro interno.</response>
        [ProducesResponseType(typeof(IList<LogViewModel>), 200)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("SearchFor")]
        [Authorize]
        public ActionResult SearchFor(string env, string order, string search)
        {
            List<LogViewModel> response;
            try
            {
                response = _service.SearchFor(env, order, search);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(response);
        }
    }
}
