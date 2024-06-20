using Cod3rsGrowth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IPersonagensHabilidadesRepositorio : IRepositorio<PersonagensHabilidades>
    {
        public List<int> ObterHabilidadesPorPersonagem(int idPersonagem);
        public void DeletarPorPersonagemEHabilidade(int idPersonagem, int idHabilidade);
    }
}
