using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoObterTodosPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void ObterTodosPersonagensComListaVazia()
        {
            // Act
            var personagens = _personagemService.ObterTodos();

            // Assert
            Assert.IsType<List<Personagem>>(personagens);
        }
    }
}