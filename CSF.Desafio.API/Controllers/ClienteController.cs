using AutoMapper;
using CSF.Desafio.API.Entities;
using CSF.Desafio.API.Models;
using CSF.Desafio.API.ResourceParameters;
using CSF.Desafio.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CSF.Desafio.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {

            _clienteRepository = clienteRepository ??
                throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ClienteDto>> GetClientesByFilters([FromQuery] ClienteParameters clienteParameters)
        {
            var clientesFromRepo = _clienteRepository.GetClientes(clienteParameters);

            return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientesFromRepo));
        }

        [HttpGet("{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<ClienteDto> GetCliente(int clienteId)
        {
            var cliente = _clienteRepository.GetCliente(clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.ClienteDto>(cliente));
        }

        [HttpOptions]
        public IActionResult GetClientesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<ClienteDto> AddCliente(ClienteForCreationDto cliente)
        {

            if (!_clienteRepository.ClienteExistePorEmpresa(cliente.CodEmpresa, cliente.Cpf))
            {
                return BadRequest("Cpf ja cadastrado para esta empresa.");
            }
            var clienteEntity = _mapper.Map<Entities.Cliente>(cliente);
            _clienteRepository.AddCliente( clienteEntity);
            _clienteRepository.Save();

            var clienteToReturn = _mapper.Map<ClienteDto>(clienteEntity);
            return Ok(clienteToReturn);
            //var rota = CreatedAtRoute("GetCliente",
            //    new { clienteId = clienteToReturn.Id },
            //    clienteToReturn);
            //return rota;
        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(404)]
        //public ActionResult<Cliente> UpdateCliente(int id, Cliente cliente)
        //{
        //    //if (_service.UpdateCliente(id, cliente))
        //    //{
        //    //    return NoContent();
        //    //}

        //    return BadRequest();
        //}

        [HttpDelete("{clienteId}")]
        public ActionResult DeleteCliente(int clienteId)
        {
            var cliente = _clienteRepository.GetCliente(clienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.DeleteCliente(cliente);
            _clienteRepository.Save();
            return NoContent();
           
        }
    }
}
