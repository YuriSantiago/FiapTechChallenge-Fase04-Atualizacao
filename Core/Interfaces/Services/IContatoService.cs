using Core.Requests.Update;

namespace Core.Interfaces.Services
{
    public interface IContatoService
    {
        void Put(ContatoUpdateRequest regiaoUpdateRequest);
    }
}
