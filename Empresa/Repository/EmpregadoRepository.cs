using Empresa.Data;
using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Repository;

public class EmpregadoRepository : IEmpregadoRepository
{
    private readonly dbContext _dbContext;
    public EmpregadoRepository(dbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Empregado>> GetEmpregados()
    {
        return await _dbContext.Empregados.ToListAsync();
    }

    public async Task<Empregado> GetEmpregadoById(int EmpregadoId)
    {
        return await _dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == EmpregadoId);
    }

    public async Task<Empregado> AssociateEmpregadoToDepartamento(int EmpregadoId, int DepartamentoId)
    {
        var empregado = await _dbContext.Empregados.FindAsync(EmpregadoId);
        if (empregado == null)
        {
            return null;
        }

        empregado.DepartamentoId = DepartamentoId;
        await _dbContext.SaveChangesAsync();

        return empregado;
    }

    public async Task<Empregado> AddEmpregado(Empregado empregado)
    {
        var result = await _dbContext.Empregados.AddAsync(empregado);
        await _dbContext.SaveChangesAsync();
        return result.Entity; 
    }

    public async Task<Empregado> UpdateEmpregado(Empregado empregado)
    {
        var existingEmpregado = await _dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == empregado.EmpregadoId);
        if (existingEmpregado == null)
        {
            return null; // Retorna null se o empregado não for encontrado
        }

        // Atualiza os campos
        existingEmpregado.Nome = empregado.Nome;
        existingEmpregado.Sobrenome = empregado.Sobrenome;
        existingEmpregado.Email = empregado.Email;
        existingEmpregado.Genero = empregado.Genero;
        existingEmpregado.FotoUrl = empregado.FotoUrl;
        existingEmpregado.DepartamentoId = empregado.DepartamentoId; // Atualiza a chave estrangeira se necessário

        await _dbContext.SaveChangesAsync();
        return existingEmpregado;
    }

    public async void DeleteEmpregadoById(int EmpregadoId)
    {
        var result = await _dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == EmpregadoId);
        if (result != null)
        {
            _dbContext.Empregados.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
