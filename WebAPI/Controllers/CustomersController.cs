using Application.DTOs.Customer;
using Application.DTOs.Id;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Produces(MediaTypeNames.Application.Json)]
   public class CustomersController : ControllerBase
   {
      private readonly ICustomerService CustomerService;
      private readonly IUnitOfWork UnitOfWork;
      public CustomersController(ICustomerService customerService, IUnitOfWork unitOfWork)
      {
         CustomerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
         UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      }

      [HttpGet]
      [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<IEnumerable<CustomerResponse>>> Get()
      {
         IEnumerable<CustomerResponse> items = await CustomerService.GetAllAsync(o => o.Name.Value);
         return Ok(items);
      }

      [HttpGet("{id}")]
      [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<CustomerResponse>> Get(long id)
      {
         var customerResponse = await CustomerService.GetAsync(id);
         if (customerResponse == null)
         {
            return NotFound($"Customer {id} not found ...");
         }
         return Ok(customerResponse);
      }

      [HttpPost]
      [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<CustomerResponse>> Post([FromBody] CustomerCreateRequest value)
      {
         try
         {
            if (ModelState.IsProblem())
            {
               return BadRequest(ModelState);
            }
            Customer data = await CustomerService.AddAsync(value);
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return BadRequest($"Customer add Bad Request");
            }
            CustomerResponse customerResponse = data.Adapt<CustomerResponse>();
            RouteId<long> routeId = RouteId<long>.Create(customerResponse.Id);
            return CreatedAtAction(nameof(Get), routeId, customerResponse);
         }
         catch (Exception)
         {
            throw;
         }
      }

      [HttpPut("{id}")]
      [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status304NotModified)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      public async Task<ActionResult<CustomerResponse>> Put(int id, [FromBody] CustomerUpdateRequest value)
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
            Customer data = await CustomerService.UpdateAsync(value);
            if (data == null)
            {
               return BadRequest($"Customer update error Bad Request");
            }
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return StatusCode(StatusCodes.Status304NotModified, value);
            }
            CustomerResponse customerResponse = data.Adapt<CustomerResponse>();
            return Ok(customerResponse);
         }
         catch (Exception)
         {
            throw;
         }
      }

      [HttpDelete("{id}")]
      [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
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
            bool customerExists = await CustomerService.AnyAsync(id);
            if (customerExists == false)
            {
               return NotFound($"Customer {id} not found ...");
            }
            await CustomerService.DeleteAsync(id);
            if (await UnitOfWork.CommitChangesAsync() == false)
            {
               return BadRequest($"Customer delete error Bad Request");
            }
            return Ok($"Customer {id} deleted");
         }
         catch (Exception)
         {
            throw;
         }
      }
   }
}
