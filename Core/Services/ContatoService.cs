using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests.Create;
using Core.Requests.Update;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;
        private readonly IRegiaoRepository _regiaoRepository;

        public ContatoService(IContatoRepository contatoRepository, IRegiaoRepository regiaoRepository)
        {
            _contatoRepository = contatoRepository;
            _regiaoRepository = regiaoRepository;
        }

        public void Put(ContatoUpdateRequest contatoUpdateRequest)
        {
            var contato = _contatoRepository.GetById(contatoUpdateRequest.Id);

            contato.Nome = contatoUpdateRequest.Nome ?? contato.Nome;
            contato.Telefone = contatoUpdateRequest.Telefone ?? contato.Telefone;
            contato.Email = contatoUpdateRequest.Email ?? contato.Email;

            if (contatoUpdateRequest.DDD is not null)
            {
                var regiao = _regiaoRepository.GetByDDD(contatoUpdateRequest.DDD.Value);

                if (regiao is not null)
                    contato.RegiaoId = regiao.Id;
            }

            _contatoRepository.Update(contato);
        }

    }
}
