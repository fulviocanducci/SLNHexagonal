using Infrastructure.Interfaces;

namespace Infrastructure.Context
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly DataAccess _context;
      public UnitOfWork(DataAccess context)
      {
         _context = context;
      }
      public async Task<bool> CommitChangesAsync()
      {
         return await _context.SaveChangesAsync() > 0;
      }
      public async Task<bool> CommitChangesAsync(CancellationToken cancellationToken)
      {
         return await _context.SaveChangesAsync(cancellationToken) > 0;
      }
   }
}
