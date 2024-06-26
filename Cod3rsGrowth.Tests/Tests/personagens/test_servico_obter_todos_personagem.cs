using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoObterTodosPersonagem : TesteBase
    {
        private readonly PersonagemRepositorioMock _personagemRepositorioMock;

        public TesteServicoObterTodosPersonagem() : base()
        {
            _personagemRepositorioMock = _serviceProvider.GetRequiredService<PersonagemRepositorioMock>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public void ObterTodosPersonagensRetornaLista()
        {
            // Act
            var personagens = _personagemRepositorioMock.ObterTodos("");

            // Assert
            Assert.IsType<List<Personagem>>(personagens);
        }
    }
}