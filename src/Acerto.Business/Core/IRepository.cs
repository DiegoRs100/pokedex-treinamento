namespace Acerto.Business.Core
{
    public interface IRepository : IDisposable
    {
        Task CommitAsync();
    }
}