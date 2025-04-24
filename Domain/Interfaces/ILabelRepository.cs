using Domain.Entities;
using Domain.Interfaces.Bases;

namespace Domain.Interfaces
{
   public interface ILabelRepository :
      IGetAsync<Label, long>,
      IGetAllAsync<Label>,
      IAddAsync<Label>,
      IUpdateAsync<Label>,
      IDeleteAsync<Label, long>,
      IAnyAsync<Label>,
      IAny<Label>,
      IFindAsync<Label, long>,
      IGet<Label, long>
   {
   }
}
