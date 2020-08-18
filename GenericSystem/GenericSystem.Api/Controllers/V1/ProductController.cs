using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericSystem.Application.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenericSystem.Api.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly ISystemConfiguration _systemConfiguration;

        public ProductController(IProductAppService productAppService, ISystemConfiguration systemConfiguration)
        {
            _productAppService = productAppService;
            _systemConfiguration = systemConfiguration;
        }
        /// <summary>
        /// Listar Produtos
        /// </summary>
        /// <remarks>
        /// # Listar Produto
        /// 
        /// Lista Pedidos da base de dados.
        /// </remarks>
        /// <response code="200">Retorna uma lista de Produto</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<ProductViewModel> Get()
        {
            return _productAppService.List();
        }

        /// <summary>
        /// Consultar Produto
        /// </summary>
        /// <remarks>
        /// # Consultar Produto
        /// 
        /// Consulta um Pedido na base de dados.
        /// </remarks>
        /// <param name="id">Id do Produto</param>        
        /// <response code="200">Retorna um Produto</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<ProductViewModel> Get(Guid id)
        {
            ProductViewModel product = _productAppService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Incluir Produto
        /// </summary>
        /// <remarks>
        /// # Incluir Produto
        /// 
        /// Inclui um Produto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="obj">Produto</param>        
        /// <response code="201">Produto cadastrado com sucesso</response>
        /// <response code="400">Objetos não preenchidos corretamente</response>
        /// <response code="409">Guid informado já consta na base de dados</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<ProductViewModel> Post([FromBody] ProductViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productAppService.Post(obj);
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
        /// Alterar Produto
        /// </summary>
        /// <remarks>
        /// # Alterar Produto
        /// 
        /// Altera um Produto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="id">Id do Produto</param>        
        /// <param name="obj">Produto</param>        
        /// <response code="204">Produto alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put(Guid id, [FromBody] ProductViewModel obj)
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
                _productAppService.Put(obj);
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
        /// Remover Produto
        /// </summary>
        /// <remarks>
        /// # Remover Produto
        /// 
        /// Remove um Produto da base de dados.
        /// </remarks>
        /// <param name="id">Id do Produto</param>        
        /// <response code="204">Produto removido com sucesso</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            ProductViewModel obj = _productAppService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            _productAppService.Delete(id);

            return NoContent();
        }

        private bool ObjExists(Guid id)
        {
            return _productAppService.Get(id) != null;
        }
    }
}
