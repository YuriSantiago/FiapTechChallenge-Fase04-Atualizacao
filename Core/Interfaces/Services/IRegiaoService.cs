using Core.Requests.Update;

namespace Core.Interfaces.Services
{
    public interface IRegiaoService
    {
        void Put(RegiaoUpdateRequest regiaoUpdateRequest);
    }
}
