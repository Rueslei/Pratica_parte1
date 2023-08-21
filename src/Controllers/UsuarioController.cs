using Microsoft.AspNetCore.Mvc;
using Pratica_parte1.src.Models;
using Pratica_parte1.src.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pratica_parte1.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase

    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return _usuarioService.GetAllUsuarios();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{cpf}")]
        public ActionResult<Usuario> Get(string cpf)
        {
            try
            {
                var usuario = _usuarioService.GetUsuario(cpf);
                if (usuario == null)
                    return NotFound($"Usuário de CPF {cpf} não foi encontrado.");
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario value)
        {
            try
            {
                var usuario = _usuarioService.InsertUsuario(value);
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Usuario value)
        {
            try
            {
                return Ok(_usuarioService.UpdateUsuario(value));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{cpf}")]
        public ActionResult Delete(string cpf)
        {
            try
            {
                return Ok(_usuarioService.DeleteUsuario(cpf));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
