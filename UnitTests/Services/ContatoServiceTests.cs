using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests.Update;
using Core.Services;
using Moq;

namespace UnitTests.Services
{
    public class ContatoServiceTests
    {

        private readonly Mock<IContatoRepository> _contatoRepositoryMock;
        private readonly Mock<IRegiaoRepository> _regiaoRepositoryMock;
        private readonly ContatoService _contatoService;

        public ContatoServiceTests()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();
            _regiaoRepositoryMock = new Mock<IRegiaoRepository>();
            _contatoService = new ContatoService(_contatoRepositoryMock.Object, _regiaoRepositoryMock.Object);
        }

    
        [Fact]
        public void Put_ShouldUpdateContato_WhenContatoExists()
        {
            // Arrange
            var contatoUpdateRequest = new ContatoUpdateRequest
            {
                Id = 1,
                Nome = "Yuri",
                Telefone = "999999999",
                Email = "yuri@email.com",
                DDD = 11
            };

            var contato = new Contato
            {
                Id = 1,
                Nome = "Yuri",
                Telefone = "999999999",
                Email = "yuri@email.com",
                RegiaoId = 1,
                Regiao = new Regiao { Id = 1, DDD = 11, Descricao = "São Paulo" }
            };

            _contatoRepositoryMock.Setup(repo => repo.GetById(contatoUpdateRequest.Id)).Returns(contato);

            // Act
            _contatoService.Put(contatoUpdateRequest);

            // Assert
            _contatoRepositoryMock.Verify(repo => repo.Update(It.IsAny<Contato>()), Times.Once);
        }


    }
}
