using Moq;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service;
using TesteBC.Service.Interfaces;

namespace TesteBC.Tests
{
    public class LancamentoServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private readonly ILancamentoService _lanctoService;
        private readonly Mock<ILancamentoRepository> _mockLanctoRepo;

        public LancamentoServiceTest()
        {
            _mockLanctoRepo = new Mock<ILancamentoRepository>();
            _lanctoService = new LancamentoService(_mockLanctoRepo.Object);
        }

        [Test]
        public async Task BuscaTodosTeste()
        {
            var lanctos = new List<LancamentoModel>
            {
                new LancamentoModel{},
                new LancamentoModel{},
                new LancamentoModel{},
                new LancamentoModel{},
                new LancamentoModel{}
            };

            _mockLanctoRepo.Setup(r => r.BuscaTodos()).ReturnsAsync(lanctos);

            var resultado = await _lanctoService.BuscaTodos();

            Assert.That(lanctos, Is.EqualTo(resultado));
        }

        [Test]
        public async Task AdicionaTeste()
        {
            var lancto = new LancamentoModel { };

            await _lanctoService.Adiciona(lancto);

            _mockLanctoRepo.Verify(repo => repo.Adiciona(lancto), Times.Once);
        }

        [Test]
        public async Task AtualizaTeste()
        {
            var lancto = new LancamentoModel { };

            await _lanctoService.Atualiza(lancto);

            _mockLanctoRepo.Verify(repo => repo.Atualiza(lancto), Times.Once);
        }

        [Test]
        public async Task RemoveTeste()
        {
            var lancto = new LancamentoModel { };

            await _lanctoService.Remove(lancto);

            _mockLanctoRepo.Verify(repo => repo.Remove(lancto), Times.Once);
        }

        [Test]
        public async Task BuscaLancamentoTeste()
        {
            Guid id = new Guid();

            var lancto = new LancamentoModel() { IdLancamento = id };

            _mockLanctoRepo.Setup(r => r.BuscaLancamento(id)).ReturnsAsync(lancto);

            var resultado = await _lanctoService.BuscaLancamento(id);

            Assert.That(lancto, Is.EqualTo(resultado));
        }

    }
}
