using Empresa.Models;

namespace Empresa.Repository.Interface;

public interface IEmpregadoRepository
{
    Task<IEnumerable<Empregado>> GetEmpregados(); // Busca todos os Colaboradores
    Task<Empregado> GetEmpregadoById(int EmpregadoId); // Busca somente um Colaborador
    Task<Empregado> AddEmpregado(Empregado empregado); // Adiciona o Colaborador
    Task<Empregado> UpdateEmpregado(Empregado empregado); // Atualiza o Colaborador
    void DeleteEmpregadoById(int EmpregadoId); // Deleta o Colaborador
}
