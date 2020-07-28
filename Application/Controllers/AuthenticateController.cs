using Api.Application.Services;
using Api.Repository;
using Api.Repository.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IServiceUser _service;

        public AuthenticateController(IServiceUser service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<retorno> Authenticate([FromBody] User model)
        {
            var user = _service.Get(model.Email, model.Password);

            if (user == null)
                //return StatusCode(404, new { message = "Usuário ou Senha inválidos." });
                return BadRequest(new { message = "Usuário ou Senha inválidos." });

            string token;
            try
            {
                token = TokenService.GenerateToken(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            user.Password = "";

            return new retorno
            {
                User = user,
                Token = token
            };
        }


    }

    public class retorno{
        public User User { get; set; }
        public string Token { get; set; }
    }
}
