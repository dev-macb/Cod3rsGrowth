using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Enums;
using CodersGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoEditarPersonagem : TesteBase
    {
        private readonly IPersonagemServico personagemService;

        public TesteServicoEditarPersonagem() : base()
        {
            personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void EditarPersonagemComExito()
        {
            // Arrange
            var personagemOriginal = new Personagem(null, "Testudo", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            int idNovoPersonagem = personagemService.Criar(personagemOriginal);
            var novoPersonagem = personagemService.ObterPorId(idNovoPersonagem);

            // Act
            novoPersonagem.Nome = "Testudo Alterado";
            novoPersonagem.Vida = 10;
            personagemService.Editar(idNovoPersonagem, novoPersonagem);

            // Assert
            var personagemAtualizado = personagemService.ObterPorId(idNovoPersonagem);
            Assert.Equal("Testudo Alterado", personagemAtualizado.Nome);
            Assert.Equal(10, personagemAtualizado.Vida);
        }

        [Fact]
        public void TentarEditarPersonagemComIdInvalido()
        {
            // Arrange
            var personagemOriginal = new Personagem(null, "Testudo", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            int idNovoPersonagem = personagemService.Criar(personagemOriginal);
            var novoPersonagem = personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "T";
            novoPersonagem.Vida = 10;
            Assert.Throws<Exception>(() => personagemService.Editar(idNovoPersonagem, novoPersonagem));
        }

        [Fact]
        public void TentarEditarPersonagemComNomeCurto()
        {
            // Arrange
            var personagemOriginal = new Personagem(null, "Testudo", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);
            int idNovoPersonagem = personagemService.Criar(personagemOriginal);
            var novoPersonagem = personagemService.ObterPorId(idNovoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "T";
            novoPersonagem.Vida = 10;
            Assert.Throws<Exception>(() => personagemService.Editar(idNovoPersonagem, novoPersonagem));
        }
    }
}