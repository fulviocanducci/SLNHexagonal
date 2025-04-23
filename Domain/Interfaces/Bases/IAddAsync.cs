using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IAddAsync<T>
   {
      Task AddAsync(T value);
   }
}
