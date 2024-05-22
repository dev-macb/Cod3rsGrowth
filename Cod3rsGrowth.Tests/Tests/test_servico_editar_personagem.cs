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

        private List<Personagem> GerarLista()
        {
            return new List<Personagem>()
            {
                new(1, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(2, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(3, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(4, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(5, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(6, "Guile", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(7, "Dhalsim", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(8, "Vega", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio)
            };
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
            var lista = GerarLista();
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