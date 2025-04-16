using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests.Create;
using Core.Requests.Update;
using Core.Services;
using Moq;

namespace ServiceTests.Services
{
    public class RegiaoServiceTests
    {

        private readonly Mock<IRegiaoRepository> _regiaoRepositoryMock;
        private readonly RegiaoService _regiaoService;

        public RegiaoServiceTests()
        {
            _regiaoRepositoryMock = new Mock<IRegiaoRepository>();
            _regiaoService = new RegiaoService(_regiaoRepositoryMock.Object);
        }

        [Fact]
        public void Put_ShouldUpdateRegiao_WhenRegiaoExists()
        {
            // Arrange
            var regiaoUpdateRequest = new RegiaoUpdateRequest
            {
                Id = 1,
                DDD = 11,
                Descricao = "São Paulo"
            };

            var regiao = new Regiao
            {
                Id = 1,
                DDD = 11,
                Descricao = "SP"
            };

            _regiaoRepositoryMock.Setup(repo => repo.GetById(regiaoUpdateRequest.Id)).Returns(regiao);

            // Act
            _regiaoService.Put(regiaoUpdateRequest);

            // Assert
            _regiaoRepositoryMock.Verify(repo => repo.Update(It.IsAny<Regiao>()), Times.Once);
        }

    }
}

