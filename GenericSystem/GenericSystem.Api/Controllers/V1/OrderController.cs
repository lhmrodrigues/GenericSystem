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
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        private readonly ISystemConfiguration _systemConfiguration;

        public OrderController(IOrderAppService orderAppService, ISystemConfiguration systemConfiguration)
        {
            _orderAppService = orderAppService;
            _systemConfiguration = systemConfiguration;
        }

        /// <summary>
        /// Listar Pedidos
        /// </summary>
        /// <remarks>
        /// # Listar Pedidos
        /// 
        /// Lista Pedidos da base de dados.
        /// </remarks>
        /// <response code="200">Retorna uma lista de Pedidos</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<OrderViewModel> Get()
        {
            return _orderAppService.List();
        }

        /// <summary>
        /// Consultar Pedidos
        /// </summary>
        /// <remarks>
        /// # Consultar Pedidos
        /// 
        /// Consulta um Pedido na base de dados.
        /// </remarks>
        /// <param name="id">Id do Pedido</param>        
        /// <response code="200">Retorna um Pedido</response>
        /// <response code="404">Pedido não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<OrderViewModel> Get(Guid id)
        {
            OrderViewModel order = _orderAppService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        /// <summary>
        /// Incluir Pedido
        /// </summary>
        /// <remarks>
        /// # Incluir Pedido
        /// 
        /// Inclui um Pedido na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="obj">Pedido</param>        
        /// <response code="201">Pedido cadastrado com sucesso</response>
        /// <response code="400">Objetos não preenchidos corretamente</response>
        /// <response code="409">Guid informado já consta na base de dados</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<OrderViewModel> Post([FromBody] OrderViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _orderAppService.Post(obj);
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
        /// Alterar Pedido
        /// </summary>
        /// <remarks>
        /// # Alterar Pedido
        /// 
        /// Altera um Pedido na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /usuários
        ///     {
        ///        "Nome": "nome da categoria",
        ///       
        ///     }
        /// </remarks>
        /// <param name="id">Id do Pedido</param>        
        /// <param name="obj">Pedido</param>        
        /// <response code="204">Pedido alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put(Guid id, [FromBody] OrderViewModel obj)
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
                _orderAppService.Put(obj);
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
        /// Remover Pedido
        /// </summary>
        /// <remarks>
        /// # Remover Pedido
        /// 
        /// Remove um Pedido da base de dados.
        /// </remarks>
        /// <param name="id">Id do Pedido</param>        
        /// <response code="204">Pedido removido com sucesso</response>
        /// <response code="404">Pedido não encontrado</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="500">Erro no processamento da requisição</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            OrderViewModel obj = _orderAppService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            _orderAppService.Delete(id);

            return NoContent();
        }

        private bool ObjExists(Guid id)
        {
            return _orderAppService.Get(id) != null;
        }
    }
}
