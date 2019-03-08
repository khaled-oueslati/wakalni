using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wakalni.Entities;
using wakalni.services;
using MediatR;
using wakalni.Application.Items.Queries;
using Microsoft.Extensions.Logging;

namespace wakalni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly IMediator mediatR;
        private readonly ILogger logger;


        public ItemsController(ItemService itemService, IMediator mediatR, ILogger<ItemsController> logger)
        {
            _itemService = itemService;
            this.mediatR = mediatR;
            this.logger = logger;
        }

        // GET: api/Items
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetItems([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            logger.LogInformation("kjkjkjkjk");
            //if (pageNumber <1)
            //{
            //    return BadRequest(new { pageNumber = "PageNumber must be > 1" });
            //}

            //if (pageSize < 1 || pageSize > 500)
            //{
            //    return BadRequest(new { pageSize = "PageNumber must be > 1 and 500 <" });
            //}

            //var items = await _itemService.GetItems(pageNumber-1, pageSize);
            var result = await mediatR.Send(new GetItemsQuery {PageNumber = pageNumber,PageSize = pageSize });
            return Ok(result);
        }

        // GET: api/Items
        [HttpGet("static")]
        public IActionResult GetStaticItem()
        {
            var item = new Item
            {
                Content = "Essai 1 create 1",
                Created = DateTime.Now,
                Description = "Description Create1 essai 1 ",
                Modified = DateTime.Now,
                Name = "First Item Plat nchallah ta5tef"
            };

            return Ok(item);
        }
        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _itemService.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] int id, [FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                await _itemService.Update(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_itemService.ItemExists(id))
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

        //// POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _itemService.Create(item);

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _itemService.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _itemService.Delete(item);

            return Ok(item);
        }

    }
}