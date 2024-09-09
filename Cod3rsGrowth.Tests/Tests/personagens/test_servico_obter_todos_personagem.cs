using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemServico;

        public TesteServicoObterTodosPersonagem() : base()
        {
            _personagemServico = _serviceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void ObterTodosPersonagensRetornaLista()
        {
            // Act
            var personagens = await _personagemServico.ObterTodos(new Filtro());

            // Assert
            Assert.IsType<List<Personagem>>(personagens);
        }
    }
}