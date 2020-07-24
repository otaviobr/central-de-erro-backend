using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IServiceUser _service;

        public UserController(IServiceUser service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAll()
        {
            var lista = _service.GetAll();

            if (lista == null)
                return StatusCode(404, new { message = "Nenhum registro encontrado." });

            return Ok(lista);
        }

        [HttpGet]
        [Route("Get")]
        [Authorize]
        public ActionResult Get(string email, string password)
        {
            if (String.IsNullOrEmpty(email.Trim()) && String.IsNullOrEmpty(password.Trim()))
                return StatusCode(400, new { message = "Email inválido." });

            User user;

            try
            {
                user = _service.Get(email, password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

            if (user == null)
                return StatusCode(404, new { message = "Nenhum registro encontrado." });

            return Ok(user);
        }

        [HttpGet]
        [Route("GetByEmail")]
        [Authorize]
        public ActionResult GetByEmail([FromBody] string email)
        {
            if (String.IsNullOrEmpty(email))
                return StatusCode(400, new { message = "Email inválido." });

            User user;

            try
            {
                user = _service.GetByEmail(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

            if (user == null)
                return StatusCode(404, new { message = "Nenhum registro encontrado." });

            return Ok(user);
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public ActionResult GetById(int id)
        {
            if (id < 1)
                return StatusCode(400, new { message = "Id inválido." });

            User user;

            try
            {
                user = _service.GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

            if (user == null)
                return StatusCode(404, new { message = "Nenhum registro encontrado." });

            return Ok(user);
        }
    }
}
