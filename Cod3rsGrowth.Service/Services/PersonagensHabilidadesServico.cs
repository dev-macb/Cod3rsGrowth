using FluentValidation.Results;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Validators;

namespace Cod3rsGrowth.Service.Services
{
    public class PersonagensHabilidadesServico
    {
        private readonly IRepositorio<PersonagensHabilidades> _personagensHabilidadesRepositorio;

        public PersonagensHabilidadesServico(IRepositorio<PersonagensHabilidades> personagensHabilidadesRepositorio)
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
    }
}