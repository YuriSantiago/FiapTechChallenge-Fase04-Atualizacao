using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {

        T GetById(int id);

        void Update(T entidade);
    }
}
