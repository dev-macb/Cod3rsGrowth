using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteServicoCriarPersonagem : TesteBase
    {
        private readonly IPersonagemServico _personagemService;

        public TesteServicoCriarPersonagem() : base()
        {
            _personagemService = ServiceProvider.GetRequiredService<IPersonagemServico>();
        }

        [Fact]
        public void CriarNovoPersonagemComExito()
        {
            // Arrange
            var novoPersonagem = new Personagem(null, "Teste da Silva", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act
            var resultado = _personagemService.Criar(novoPersonagem);
            var personagemCriado = _personagemService.ObterPorId(resultado);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equal(personagemCriado.Id, resultado);
            Assert.Equal(novoPersonagem.Nome, personagemCriado.Nome);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComNomeCurto()
        {
            // Arrange
            string nomeCurto = "Te";
            var personagemInvalido = new Personagem(null, nomeCurto, 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("O nome deve ter no mínimo 5 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Um nome qualquer que seja grande o suficiente para ser inutil";
            var personagemInvalido = new Personagem(null, nomeGrande, 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("O nome deve ter no mínimo 5 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComVidaMenorQueZero()
        {
            // Arrange
            int vidaNegativa = -1;
            var personagemInvalido = new Personagem(null, "Testudo", vidaNegativa, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A vida deve estar entre 0 e 100.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComVidaMaiorQueCem()
        {
            // Arrange
            int vidaMaiorQueCem = 101;
            var personagemInvalido = new Personagem(null, "Testudo", vidaMaiorQueCem, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A vida deve estar entre 0 e 100.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComEnergiaMenorQueZero()
        {
            // Arrange
            int EnergiaMenorQueZero = -1;
            var personagemInvalido = new Personagem(null, "Testudo", 100, EnergiaMenorQueZero, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A energia deve estar entre 0 e 50.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComEnergiaMaiorQueCinquenta()
        {
            // Arrange
            int energiaMaiorQueCinquenta = 51;
            var personagemInvalido = new Personagem(null, "Testudo", 100, energiaMaiorQueCinquenta, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A energia deve estar entre 0 e 50.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComVelocidadeMenorQueZero()
        {
            // Arrange
            int velocidadeMenorQueZero = -1;
            var personagemInvalido = new Personagem(null, "Testudo", 100, 50, velocidadeMenorQueZero, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComVelocidadeMaiorQueDois()
        {
            // Arrange
            double velocidadeMaiorQueDois = 2.1;
            var personagemInvalido = new Personagem(null, "Testudo", 100, 50, velocidadeMaiorQueDois, CategoriasEnum.Bom, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComForcaInvalida()
        {
            // Arrange
            int forcaInvalida = 99999;
            var personagemInvalido = new Personagem(null, "Testudo", 100, 50, 1.5, (CategoriasEnum)forcaInvalida, CategoriasEnum.Medio);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A força deve ser um valor válido de CategoriasEnum.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComInteligenciaInvalida()
        {
            // Arrange
            int inteligenciaInvalida = 99999;
            var personagemInvalido = new Personagem(null, "Testudo", 100, 50, 1.5, CategoriasEnum.Bom, (CategoriasEnum)inteligenciaInvalida);

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal("A inteligência deve ser um valor válido de CategoriasEnum.", excecao.Message);
        }

        [Fact]
        public void TentaCriarNovoPersonagemComNomeVidaEnergiaVelociadeForcaEInteligenciaIncorreto()
        {
            // Arrange
            string nomePequeno = "T";
            int vidaNegativa = -1;
            int energiaNegativa = -1;
            double velocidadeNegativa = -0.1;
            int forcaInvalida = 99999;
            int inteligenciaInvalida = 99999;
            var personagemInvalido = new Personagem(
                null, 
                nomePequeno, 
                vidaNegativa, 
                energiaNegativa, 
                velocidadeNegativa, 
                (CategoriasEnum)forcaInvalida, 
                (CategoriasEnum)inteligenciaInvalida
            );
            string mensagemEsperada = "O nome deve ter no mínimo 5 caracteres e no máximo 50. " +
                "A vida deve estar entre 0 e 100. " +
                "A energia deve estar entre 0 e 50. " +
                "A velocidade deve estar entre 0 e 2. " +
                "A força deve ser um valor válido de CategoriasEnum. " +
                "A inteligência deve ser um valor válido de CategoriasEnum.";


            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemService.Criar(personagemInvalido));
            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}