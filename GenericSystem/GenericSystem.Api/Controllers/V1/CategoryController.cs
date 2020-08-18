using GenericSystem.Application.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ISystemConfiguration _systemConfiguration;

        public CategoryController(ICategoryAppService categoryAppService, ISystemConfiguration systemConfiguration)
        {
            _categoryAppService = categoryAppService;
            _systemConfiguration = systemConfiguration;
        }

        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <remarks>
        /// # Listar Categorias
        /// 
        /// Lista Categorias da base de dados.
        /// </remarks>
        /// <response code="200">Retorna uma lista de Categorias</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<CategoryViewModel> Get()
        {
            return _categoryAppService.List();
        }

        /// <summary>
        /// Consultar Categorias
        /// </summary>
        /// <remarks>
        /// # Consultar Categorias
        /// 
        /// Consulta uma Categoria na base de dados.
        /// </remarks>
        /// <param name="id">Id da Categoria</param>        
        /// <response code="200">Retorna uma Categorias</response>
        /// <response code="404">Categoria não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<CategoryViewModel> Get(Guid id)
        {
            CategoryViewModel category = _categoryAppService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Incluir categoria
        /// </summary>
        /// <remarks>
        /// # Incluir categoria
        /// 
        /// Inclui uma categoria na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="obj">categoria</param>        
        /// <response code="201">categoria cadastrado com sucesso</response>
        /// <response code="400">Objetos não preenchidos corretamente</response>
        /// <response code="409">Guid informado já consta na base de dados</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<CategoryViewModel> Post([FromBody] CategoryViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _categoryAppService.Post(obj);
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
        /// Alterar categoria
        /// </summary>
        /// <remarks>
        /// # Alterar categoria
        /// 
        /// Altera uma categoria na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="id">Id da categoria</param>        
        /// <param name="obj">categoria</param>        
        /// <response code="204">categoria alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put(Guid id, [FromBody] CategoryViewModel obj)
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
                _categoryAppService.Put(obj);
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
        /// Remover categoria
        /// </summary>
        /// <remarks>
        /// # Remover categoria
        /// 
        /// Remove uma categoria da base de dados.
        /// </remarks>
        /// <param name="id">Id da categoria</param>        
        /// <response code="204">categoria removido com sucesso</response>
        /// <response code="404">categoria não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            CategoryViewModel obj = _categoryAppService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            _categoryAppService.Delete(id);

            return NoContent();
        }

        private bool ObjExists(Guid id)
        {
            return _categoryAppService.Get(id) != null;
        }
    }
}
