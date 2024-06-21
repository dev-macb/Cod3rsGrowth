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

        public async Task<IEnumerable<PersonagensHabilidades>> ObterTodos(Filtro? filtro)
        {
            return await _personagensHabilidadesRepositorio.ObterTodos(filtro);
        }

        public async Task<PersonagensHabilidades?> ObterPorId(int id)
        {
            return await _personagensHabilidadesRepositorio.ObterPorId(id);
        }

        public async Task<List<int>> ObterHabilidadesPorPersonagem(int idPersonagem)
        {
            return await _personagensHabilidadesRepositorio.ObterHabilidadesPorPersonagem(idPersonagem);
        }

        public async Task<int> Adicionar(PersonagensHabilidades personagensHabilidades)
        {
            return await _personagensHabilidadesRepositorio.Adicionar(personagensHabilidades);
        }

        public async Task Atualizar(int id, PersonagensHabilidades personagensHabilidadesAtualizado)
        {
            await _personagensHabilidadesRepositorio.Atualizar(id, personagensHabilidadesAtualizado);
        }

        public async Task Deletar(int id)
        {
            await _personagensHabilidadesRepositorio.Deletar(id);
        }

        public async Task DeletarPorPersonagemEHabilidade(int idPersonagem, int idHabilidade)
        {
            await _personagensHabilidadesRepositorio.DeletarPorPersonagemEHabilidade(idPersonagem, idHabilidade);
        }
    }
}