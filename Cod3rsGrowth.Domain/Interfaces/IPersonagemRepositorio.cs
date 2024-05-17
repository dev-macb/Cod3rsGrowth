using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IPersonagemRepositorio
    {
        List<Personagem> ObterTodos();
        Personagem? ObterPorId(int id);
        int Criar(string nome, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia);
        void Editar(int id, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia);
        void Remover(int id);
    }
}