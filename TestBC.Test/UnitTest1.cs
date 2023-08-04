using Moq;
using TesteBC.Domain.Models;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Service;
using TesteBC.Service.Interfaces;
using Xunit;

namespace TesteBC.Test
{
    public class LancamentoServiceTest
    {
        private readonly ILancamentoService _lanctoService;
        private readonly Mock<ILancamentoRepository> _mockLanctoRepo;

        public LancamentoServiceTest()
        {
            _mockLanctoRepo = new Mock<ILancamentoRepository>();
            _lanctoService = new LancamentoService(_mockLanctoRepo.Object);
        }

        [Fact]
        public async Task Teste()
        {
            var lanctos = new List<LancamentoModel>
            {
                new LancamentoModel{},
                new LancamentoModel{ }
            };

            _mockLanctoRepo.Setup(r => r.BuscaTodos()).ReturnsAsync(lanctos);

            var resultado = await _lanctoService.BuscaTodos();

            Assert.Equals(lanctos, resultado);
        }

    }
}
