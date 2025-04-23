using Domain.Entities;
using Domain.Interfaces.Bases;
namespace Domain.Interfaces
{
   public interface ICustomerRepository :
      IGetAsync<Customer, long>,
      IGetAllAsync<Customer>,
      IAddAsync<Customer>,
      IUpdateAsync<Customer>,
      IDeleteAsync<Customer, long>,
      IAnyAsync<Customer>
   {
   }
}