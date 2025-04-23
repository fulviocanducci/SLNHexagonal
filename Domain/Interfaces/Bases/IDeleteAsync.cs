using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IDeleteAsync<T, in TKey>
   {
      Task DeleteAsync(TKey id);
      Task DeleteAsync(T model);
   }
}
