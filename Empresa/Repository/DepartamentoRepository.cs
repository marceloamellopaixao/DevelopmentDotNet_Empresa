using Empresa.Data;
using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly dbContext _dbContext;

    public DepartamentoRepository(dbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<IEnumerable<Departamento>> GetDepartamentos()
    {
        return await _dbContext.Departamentos.ToListAsync();
    }

    public async Task<Departamento> GetDepartamentoById(int DepartamentoId)
    {
        return await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == DepartamentoId);
    }

    public async Task<IEnumerable<Departamento>> GetDepartamentoByNome(string DepartamentoNome)
    {
        return await _dbContext.Departamentos.Where(d => d.DepartamentoNome.Contains(DepartamentoNome)).ToListAsync();
    }

    public async Task<Departamento> AddDepartamento(Departamento departamento)
    {
        var result = await _dbContext.Departamentos.AddAsync(departamento);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Departamento> UpdateDepartamento(Departamento departamento)
    {
        var result = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == departamento.DepartamentoId);
        if (result != null)
        {
            result.DepartamentoNome = departamento.DepartamentoNome;
            await _dbContext.SaveChangesAsync();

            return result;
        }
        return null;
    }

    public async void DeleteDepartamentoById(int DepartamentoId)
    {
        var result = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == DepartamentoId);
        if (result != null)
        {
            _dbContext.Departamentos.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
