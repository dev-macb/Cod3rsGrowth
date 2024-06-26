using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoAdicionarPersonagem : TesteBase
    {
        private readonly PersonagemRepositorioMock _personagemRepositorioMock;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoAdicionarPersonagem() : base()
        {
            _personagemRepositorioMock = _serviceProvider.GetRequiredService<PersonagemRepositorioMock>();
        }

        [Fact]
        public void AdicionarNovoPersonagemComExito()
        {
            // Arrange
            RepositorioMock.ResetarInstancia();
            var novoPersonagem = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act
            int idnovoPersonagem = _personagemRepositorioMock.Adicionar(novoPersonagem);
            var personagemCriado = _personagens.Find(personagem => personagem.Id == idnovoPersonagem);

            // Assert
            Assert.NotNull(personagemCriado);
            Assert.Equivalent(personagemCriado, novoPersonagem);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComNomeCurto()
        {
            // Arrange
            string nomeCurto = "Te";
            var personagemInvalido = new Personagem
            {
                Nome = nomeCurto,
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComNomeGrande()
        {
            // Arrange
            string nomeGrande = "Um nome qualquer que seja grande o suficiente para ser inutil";
            var personagemInvalido = new Personagem
            {
                Nome = nomeGrande,
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("O nome deve ter no mínimo 3 caracteres e no máximo 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComVidaMenorQueZero()
        {
            // Arrange
            int vidaNegativa = -1;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = vidaNegativa,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A vida deve estar entre 0 e 100.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComVidaMaiorQueCem()
        {
            // Arrange
            int vidaMaiorQueCem = 101;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = vidaMaiorQueCem,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A vida deve estar entre 0 e 100.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComEnergiaMenorQueZero()
        {
            // Arrange
            int EnergiaMenorQueZero = -1;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = EnergiaMenorQueZero,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A energia deve estar entre 0 e 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComEnergiaMaiorQueCinquenta()
        {
            // Arrange
            int energiaMaiorQueCinquenta = 51;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = energiaMaiorQueCinquenta,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A energia deve estar entre 0 e 50.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComVelocidadeMenorQueZero()
        {
            // Arrange
            int velocidadeMenorQueZero = -1;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = velocidadeMenorQueZero,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComVelocidadeMaiorQueDois()
        {
            // Arrange
            double velocidadeMaiorQueDois = 2.1;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = velocidadeMaiorQueDois,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A velocidade deve estar entre 0 e 2.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComForcaInvalida()
        {
            // Arrange
            int forcaInvalida = 99999;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = (CategoriasEnum)forcaInvalida,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };

            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A força deve ser um valor válido de CategoriasEnum.", excecao.Message);
        }

        [Fact]
        public void DeveLancarExcecaoAoAdicionarComInteligenciaInvalida()
        {
            // Arrange
            int inteligenciaInvalida = 99999;
            var personagemInvalido = new Personagem
            {
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = (CategoriasEnum)inteligenciaInvalida,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            };
            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal("A inteligência deve ser um valor válido de CategoriasEnum.", excecao.Message);
        }

        [Fact]
        public void TentaAdicionarNovoPersonagemComNomeVidaEnergiaVelociadeForcaEInteligenciaIncorreto()
        {
            // Arrange
            string nomePequeno = "T";
            int vidaNegativa = -1;
            int energiaNegativa = -1;
            double velocidadeNegativa = -0.1;
            int forcaInvalida = 99999;
            int inteligenciaInvalida = 99999;
            var personagemInvalido = new Personagem
            {
                Nome = nomePequeno,
                Vida = vidaNegativa,
                Energia = energiaNegativa,
                Velocidade = velocidadeNegativa,
                Forca = (CategoriasEnum)forcaInvalida,
                Inteligencia = (CategoriasEnum)inteligenciaInvalida,
            };
            string mensagemEsperada = "O nome deve ter no mínimo 3 caracteres e no máximo 50. " +
                "A vida deve estar entre 0 e 100. " +
                "A energia deve estar entre 0 e 50. " +
                "A velocidade deve estar entre 0 e 2. " +
                "A força deve ser um valor válido de CategoriasEnum. " +
                "A inteligência deve ser um valor válido de CategoriasEnum.";


            // Act - Assert
            var excecao = Assert.Throws<Exception>(() => _personagemRepositorioMock.Adicionar(personagemInvalido));
            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}