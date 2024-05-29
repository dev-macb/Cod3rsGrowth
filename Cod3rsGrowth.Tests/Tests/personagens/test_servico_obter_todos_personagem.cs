using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemService;

        public TesteServicoObterTodosPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void ObterTodosPersonagensRetornaLista()
        {
            // Act
            var personagens = _personagemService.ObterTodos();

            // Assert
            Assert.IsType<List<Personagem>>(personagens);
        }
    }
}