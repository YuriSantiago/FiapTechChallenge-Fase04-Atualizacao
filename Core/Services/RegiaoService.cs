using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests.Update;

namespace Core.Services
{
    public class RegiaoService : IRegiaoService
    {

        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        public void Put(RegiaoUpdateRequest regiaoUpdateRequest)
        {
            var regiao = _regiaoRepository.GetById(regiaoUpdateRequest.Id);
            regiao.DDD = regiaoUpdateRequest.DDD ?? regiao.DDD;
            regiao.Descricao = regiaoUpdateRequest.Descricao ?? regiao.Descricao;

            _regiaoRepository.Update(regiao);
        }

    }
}
