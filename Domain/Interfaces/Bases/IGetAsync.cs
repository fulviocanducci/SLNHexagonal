using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IGetAsync<T, in TKey>
   {
      Task<T> GetAsync(TKey id);
   }
}
