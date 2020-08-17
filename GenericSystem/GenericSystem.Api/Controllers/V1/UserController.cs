using GenericSystem.Application.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericSystem.Api.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ISystemConfiguration _systemConfiguration;

        public UserController(IUserAppService userAppService, ISystemConfiguration systemConfiguration)
        {
            _userAppService = userAppService;
            _systemConfiguration = systemConfiguration;
        }

        /// <summary>
        /// Listar Usuarios
        /// </summary>
        /// <remarks>
        /// # Listar apontamentos
        /// 
        /// Lista usuários da base de dados.
        /// </remarks>
        /// <response code="200">Retorna uma lista de usuários</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<UserViewModel> Get()
        {
            return _userAppService.List();
        }

        /// <summary>
        /// Consultar usuários
        /// </summary>
        /// <remarks>
        /// # Consultar usuários
        /// 
        /// Consulta um usuários na base de dados.
        /// </remarks>
        /// <param name="id">Id do usuários</param>        
        /// <response code="200">Retorna um usuários</response>
        /// <response code="404">usuários não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserViewModel> Get(Guid id)
        {
            UserViewModel apontamento = _userAppService.Get(id);

            if (apontamento == null)
            {
                return NotFound();
            }

            return Ok(apontamento);
        }

        /// <summary>
        /// Incluir usuários
        /// </summary>
        /// <remarks>
        /// # Incluir usuários
        /// 
        /// Inclui um usuários na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /usuários
        ///     {
        ///        "Nome": "nome do usuários",
        ///        "Data Nascimento": "2019-09-21T15:56:00.503Z",
        ///        "CPF": "123.456.789-00",
        ///     }
        /// </remarks>
        /// <param name="obj">usuários</param>        
        /// <response code="201">usuários cadastrado com sucesso</response>
        /// <response code="400">Objetos não preenchidos corretamente</response>
        /// <response code="409">Guid informado já consta na base de dados</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<UserViewModel> Post([FromBody] UserViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _userAppService.Post(obj);
            }
            catch (Exception)
            {
                if (ObjExists(obj.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        /// <summary>
        /// Alterar usuários
        /// </summary>
        /// <remarks>
        /// # Alterar usuários
        /// 
        /// Altera um usuários na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /usuários
        ///     {
        ///        "Nome": "nome do usuários",
        ///        "Data Nascimento": "2019-09-21T15:56:00.503Z",
        ///        "CPF": "123.456.789-00",
        ///     }
        /// </remarks>
        /// <param name="id">Id do usuários</param>        
        /// <param name="obj">usuários</param>        
        /// <response code="204">usuários alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put(Guid id, [FromBody] UserViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obj.Id)
            {
                return BadRequest();
            }

            try
            {
                _userAppService.Put(obj);
            }
            catch (Exception)
            {
                if (!ObjExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Remover usuários
        /// </summary>
        /// <remarks>
        /// # Remover usuários
        /// 
        /// Remove um usuários da base de dados.
        /// </remarks>
        /// <param name="id">Id do usuários</param>        
        /// <response code="204">usuários removido com sucesso</response>
        /// <response code="404">usuários não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            UserViewModel obj = _userAppService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            _userAppService.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Autentica usuário
        /// </summary>
        /// <remarks>
        /// # Autentica usuário
        /// 
        /// Autentica um usuário na base de dados.
        /// </remarks>
        /// <param name="id">Id do usuários</param>        
        /// <response code="200">Retorna um usuários</response>
        /// <response code="404">usuários não encontrado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("Auth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserViewModel> Auth(string username, string password)
        {
            try
            {
                UserViewModel user = _userAppService.Authenticate(username, password);

                if (user == null)
                {
                    return NotFound();
                }                

                return Ok(new { user });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Verifica username
        /// </summary>
        /// <remarks>
        /// # Verifica username
        /// 
        /// Verifica um username na base de dados.
        /// </remarks>
        /// <param name="id">USername</param>        
        /// <response code="200">Retorna validação</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("VerifyUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> VerifyUsername(string username)
        {
            try
            {
                bool response = _userAppService.VerifyUsername(username);                

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        private bool ObjExists(Guid id)
        {
            return _userAppService.Get(id) != null;
        }
    }
}
