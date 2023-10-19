namespace Products.Infra.Data.UoW.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// SaveChanges in EFCore context.
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();
    }
}
