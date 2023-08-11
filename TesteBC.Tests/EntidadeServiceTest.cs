using Moq;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service;
using TesteBC.Service.Interfaces;

namespace TesteBC.Tests
{
    public class EntidadeServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private readonly IEntidadeService _lanctoService;
        private readonly Mock<IEntidadeRepository> _mockLanctoRepo;

        public EntidadeServiceTest()
        {
            _mockLanctoRepo = new Mock<IEntidadeRepository>();
            _lanctoService = new EntidadeService(_mockLanctoRepo.Object);
        }

        [Test]
        public async Task BuscaTodosTeste()
        {
            var lanctos = new List<EntidadeModel>
            {
                new EntidadeModel{},
                new EntidadeModel{},
                new EntidadeModel{},
                new EntidadeModel{},
                new EntidadeModel{}
            };

            _mockLanctoRepo.Setup(r => r.BuscaTodos()).ReturnsAsync(lanctos);

            var resultado = await _lanctoService.BuscaTodos();

            Assert.That(lanctos, Is.EqualTo(resultado));
        }

        [Test]
        public async Task AdicionaTeste()
        {
            var lancto = new EntidadeModel { };

            await _lanctoService.Adiciona(lancto);

            _mockLanctoRepo.Verify(repo => repo.Adiciona(lancto), Times.Once);
        }

        [Test]
        public async Task AtualizaTeste()
        {
            var lancto = new EntidadeModel { };

            await _lanctoService.Atualiza(lancto);

            _mockLanctoRepo.Verify(repo => repo.Atualiza(lancto), Times.Once);
        }

        [Test]
        public async Task RemoveTeste()
        {
            var lancto = new EntidadeModel { };

            await _lanctoService.Remove(lancto);

            _mockLanctoRepo.Verify(repo => repo.Remove(lancto), Times.Once);
        }

        [Test]
        public async Task BuscaEntidadeTeste()
        {
            Guid id = new Guid();

            var lancto = new EntidadeModel() { IdEntidade = id };
            //Inserir outro

            _mockLanctoRepo.Setup(r => r.BuscaEntidade(id)).ReturnsAsync(lancto);

            var resultado = await _lanctoService.BuscaEntidade(id);

            Assert.That(lancto, Is.EqualTo(resultado));
        }

    }
}