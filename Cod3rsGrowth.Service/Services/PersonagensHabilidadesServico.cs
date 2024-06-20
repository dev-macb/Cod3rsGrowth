using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;

namespace Cod3rsGrowth.Service.Services
{
    public class PersonagensHabilidadesServico
    {
        private readonly IPersonagensHabilidadesRepositorio _personagensHabilidadesRepositorio;

        public PersonagensHabilidadesServico(IPersonagensHabilidadesRepositorio personagensHabilidadesRepositorio)
        {
            _personagensHabilidadesRepositorio = personagensHabilidadesRepositorio;
        }

        public IEnumerable<PersonagensHabilidades> ObterTodos(Filtro? filtro)
        {
            return _personagensHabilidadesRepositorio.ObterTodos(filtro);
        }

        public PersonagensHabilidades? ObterPorId(int id)
        {
            return _personagensHabilidadesRepositorio.ObterPorId(id);
        }

        public List<int> ObterHabilidadesPorPersonagem(int idPersonagem)
        {
            return _personagensHabilidadesRepositorio.ObterHabilidadesPorPersonagem(idPersonagem);
        }

        public int Adicionar(PersonagensHabilidades personagensHabilidades)
        {
            return _personagensHabilidadesRepositorio.Adicionar(personagensHabilidades);
        }

        public void Atualizar(int id, PersonagensHabilidades personagensHabilidadesAtualizado)
        {
            _personagensHabilidadesRepositorio.Atualizar(id, personagensHabilidadesAtualizado);
        }

        public void Deletar(int id)
        {
            _personagensHabilidadesRepositorio.Deletar(id);
        }

        public void DeletarPorPersonagemEHabilidade(int idPersonagem, int idHabilidade)
        {
            _personagensHabilidadesRepositorio.DeletarPorPersonagemEHabilidade(idPersonagem, idHabilidade);
        }
    }
}