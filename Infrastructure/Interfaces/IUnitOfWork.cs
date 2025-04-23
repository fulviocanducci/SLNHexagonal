namespace Infrastructure.Interfaces
{
   public interface IUnitOfWork
   {
      Task<bool> CommitChangesAsync();
      Task<bool> CommitChangesAsync(CancellationToken cancellationToken);
   }
}
