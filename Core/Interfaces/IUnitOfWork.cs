namespace Core.Interfaces
{
    public interface IUnitOfWork<T> where T :class
    {
        IGenericRepository<T> entity { get; }
        void Save();
    }
}
