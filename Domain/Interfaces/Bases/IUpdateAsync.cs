using System.Threading.Tasks;

namespace Domain.Interfaces.Bases
{
   public interface IUpdateAsync<T>
   {
      Task UpdateAsync(T value);
   }
}
