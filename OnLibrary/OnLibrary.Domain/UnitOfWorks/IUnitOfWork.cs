namespace OnLibrary.Domain.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
