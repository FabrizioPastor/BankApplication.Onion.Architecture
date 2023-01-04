using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Clients.Commands;
using Application.Features.Clients.Commands.CreateClienteCommand;
using Application.Features.Clients.Commands.DeleteClienteCommand;
using Application.Features.Clients.Commands.UpdateClienteCommand;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Post([FromRoute] int id, UpdateClienteCommand command)
        {
            if (!id.Equals(command.Id))
                return BadRequest();
            
            return Ok(await Mediator.Send(command));
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Post([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();
            
            return Ok(await Mediator.Send(new DeleteClienteCommand { Id = id }));
        }
    }
}
