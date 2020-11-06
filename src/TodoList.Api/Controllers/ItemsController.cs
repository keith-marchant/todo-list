using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoTrack.Common.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Items.Commands.CreateItem;
using TodoList.Application.Items.Commands.UpdateItem;
using TodoList.Application.Items.Dtos;
using TodoList.Application.Items.Queries.GetItemById;
using TodoList.Application.Items.Queries.GetItems;

namespace TodoList.Api.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetItemsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Create([FromBody] CreateItemCommand request)
        {
            var result = await Mediator.Send(request);

            //return Ok(result);
            return Created($"/items/{result.ItemId}", result);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<TodoItemDto>> GetItem([FromRoute] int itemId)
        {
            //throw new NotImplementedException();
            return Ok(await Mediator.Send(new GetItemByIdQuery(itemId)));
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int itemId, [FromBody] UpdateItemCommand request)
        {
            request.ItemId = itemId;

            await Mediator.Send(request);

            return NoContent();
        }
    }
}
