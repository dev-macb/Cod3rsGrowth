using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Tests.RepositoriesMock;
using FluentValidation;

namespace Cod3rsGrowth.Tests.Tests.Personagens
{
    public class TesteServicoAtualizarPersonagem : TesteBase
    {
        private readonly PersonagemServico _personagemServico;
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public TesteServicoAtualizarPersonagem() : base()
        {
            _personagemServico = _serviceProvider.GetRequiredService<PersonagemServico>();
            RepositorioMock.ResetarInstancia();
        }

        [Fact]
        public async void AtualizarPersonagemComExito()
        {
            // Arrange
            int idTeste = 1;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act
            novoPersonagem.Nome = "Testudo";
            novoPersonagem.Vida = 10;
            novoPersonagem.Energia = 5;
            novoPersonagem.Velocidade = 0.5;
            novoPersonagem.Forca = CategoriasEnum.Fraco;
            novoPersonagem.Inteligencia = CategoriasEnum.Fraco;
            await _personagemServico.Atualizar(idTeste, novoPersonagem);

            // Assert
            var personagemAtualizado = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.Equivalent(novoPersonagem, personagemAtualizado);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComIdInvalido()
        {
            // Arrange
            int idTeste = 2, idInvalido = 99999;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Testudo";
            var resultado = await Assert.ThrowsAsync<Exception>(() => _personagemServico.Atualizar(idInvalido, novoPersonagem));
            Assert.Equal("Personagem não encontrado.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComNomeCurto()
        {
            // Arrange
            int idTeste = 3;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "T";
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComNomeGrande()
        {
            // Arrange
            int idTeste = 4;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Nome = "Um nome qualquer que seja grande o suficiente para ser inutil";
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("O nome deve ter no mínimo 3 caracteres e no máximo 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComVidaMenorQueZero()
        {
            // Arrange
            int idTeste = 5;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = -1;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComVidaMaiorQueCem()
        {
            // Arrange
            int idTeste = 6;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Vida = 101;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A vida deve estar entre 0 e 100.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComEnergiaMenorQueZero()
        {
            // Arrange
            int idTeste = 7;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = -1;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComEnergiaMaiorQueCinquenta()
        {
            // Arrange
            int idTeste = 8;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Energia = 51;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A energia deve estar entre 0 e 50.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComVelocidadeMenorQueZero()
        {
            // Arrange
            int idTeste = 9;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = -1;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoAtualizarComVelocidadeMaiorQueDois()
        {
            // Arrange
            int idTeste = 10;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Velocidade = 2.1;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A velocidade deve estar entre 0 e 2.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoCriarComForcaInvalida()
        {
            // Arrange
            int idTeste = 11;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Forca = (CategoriasEnum)99999;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A força deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }

        [Fact]
        public async void DeveLancarExcecaoAoCriarComInteligenciaInvalida()
        {
            // Arrange
            int idTeste = 12;
            _personagens.Add(new Personagem
            {
                Id = idTeste,
                Nome = "Teste",
                Vida = 100,
                Energia = 50,
                Velocidade = 1.0,
                Forca = CategoriasEnum.Bom,
                Inteligencia = CategoriasEnum.Bom,
                Habilidades = new List<int> { 1, 2, 3, },
                EVilao = false
            });
            var novoPersonagem = _personagens.Find(personagem => personagem.Id == idTeste);
            Assert.NotNull(novoPersonagem);

            // Act - Assert
            novoPersonagem.Inteligencia = (CategoriasEnum)99999; ;
            var resultado = await Assert.ThrowsAsync<ValidationException>(() => _personagemServico.Atualizar(idTeste, novoPersonagem));
            Assert.Contains("A inteligência deve ser um valor válido de CategoriasEnum.", resultado.Message);
        }
    }
}