using Application.DTOs.Customer;
using Application.DTOs.Id;
using Application.DTOs.Label;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPI.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Produces(MediaTypeNames.Application.Json)]
   public class LabelsController : ControllerBase
   {
      private readonly ILabelService LabelService;
      private readonly IUnitOfWork UnitOfWork;
      public LabelsController(ILabelService labelService, IUnitOfWork unitOfWork)
      {
         LabelService = labelService ?? throw new ArgumentNullException(nameof(labelService));
         UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      }

      [HttpGet]
      [ProducesResponseType(typeof(IEnumerable<LabelResponse>), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<LabelResponse>>> Get()
      {
         IEnumerable<LabelResponse> items = await LabelService.GetAllAsync(o => o.Description);
         return Ok(items);
      }

      [HttpGet("{id}")]
      [ProducesResponseType(typeof(LabelResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<LabelResponse>> Get(long id)
      {
         var labelResponse = await LabelService.GetAsync(id);
         if (labelResponse == null)
         {
            return NotFound($"Label {id} not found ...");
         }
         return Ok(labelResponse);
      }

      [HttpPost]
      [ProducesResponseType(typeof(LabelResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<LabelResponse>> Post([FromBody] LabelCreateRequest value)
      {
         try
         {
            if (ModelState.IsProblem())
            {
               return BadRequest(ModelState);
            }
            Label data = await LabelService.AddAsync(value);
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return BadRequest($"Label add Bad Request");
            }
            LabelResponse labelResponse = data.Adapt<LabelResponse>();
            RouteId<long> routeId = RouteId<long>.Create(labelResponse.Id);
            return CreatedAtAction(nameof(Get), routeId, labelResponse);
         }
         catch (Exception)
         {
            throw;
         }
      }

      [HttpPut("{id}")]
      [ProducesResponseType(typeof(LabelResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status304NotModified)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<LabelResponse>> Put(int id, [FromBody] LabelUpdateRequest value)
      {
         try
         {
            if (id <= 0)
            {
               return BadRequest($"Id update error Bad Request");
            }
            if (ModelState.IsProblem())
            {
               return BadRequest(ModelState);
            }
            Label data = await LabelService.UpdateAsync(value);
            if (data == null)
            {
               return BadRequest($"Label update error Bad Request");
            }
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return StatusCode(StatusCodes.Status304NotModified, value);
            }
            LabelResponse labelResponse = data.Adapt<LabelResponse>();
            return Ok(labelResponse);
         }
         catch (Exception)
         {
            throw;
         }
      }

      [HttpDelete("{id}")]
      [ProducesResponseType(typeof(LabelResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult> Delete(int id)
      {
         try
         {
            if (id <= 0)
            {
               return BadRequest($"Id delete error Bad Request");
            }
            bool customerExists = await LabelService.AnyAsync(id);
            if (customerExists == false)
            {
               return NotFound($"Label {id} not found ...");
            }
            await LabelService.DeleteAsync(id);
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return BadRequest($"Label delete error Bad Request");
            }
            return Ok($"Label {id} deleted");
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}
