using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class TestePersonagem : TesteBase
    {
        public PersonagemRepositorio personagemRepositorio;

        public TestePersonagem() : base() 
        {
            personagemRepositorio = ServiceProvider.GetRequiredService<PersonagemRepositorio>();
        }

        [Fact]
        public void Teste1()
        {

        }
    }
}