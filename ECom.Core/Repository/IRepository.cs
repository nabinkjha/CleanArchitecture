namespace ECom.Core.Repository
{
    public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class { }
}