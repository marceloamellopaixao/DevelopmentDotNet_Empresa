using Empresa.Data;
using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Repository;

public class EmpregadoRepository : IEmpregadoRepository
{
    private readonly dbContext dbContext;
    public EmpregadoRepository(dbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Empregado> AddEmpregado(Empregado empregado)
    {
        var result = await dbContext.Empregados.AddAsync(empregado);
        await dbContext.SaveChangesAsync();
        return result.Entity;

    }

    public async Task<IEnumerable<Empregado>> GetEmpregados()
    {
        return await dbContext.Empregados.ToListAsync();
    }

    public async Task<Empregado> GetEmpregadoById(int EmpregadoId)
    {
        return await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == EmpregadoId);
    }

    public async Task<Empregado> UpdateEmpregado(Empregado empregado)
    {
        var result = await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == empregado.EmpregadoId);
        if (result != null)
        {
            result.Nome = empregado.Nome;
            result.Sobrenome = empregado.Sobrenome;
            result.Email = empregado.Email;
            result.Genero = empregado.Genero;
            result.FotoUrl = empregado.FotoUrl;
            await dbContext.SaveChangesAsync();

            return result;
        }
        return null;
    }

    public async void DeleteEmpregadoById(int EmpregadoId)
    {
        var result = await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpregadoId == EmpregadoId);
        if (result != null)
        {
            dbContext.Empregados.Remove(result);
            await dbContext.SaveChangesAsync();
        }
    }
}
