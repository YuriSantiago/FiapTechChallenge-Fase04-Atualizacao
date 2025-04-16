using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase

    {
        void Update(T entidade);
    }
}
