using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpregadoController : ControllerBase
{
    private readonly IEmpregadoRepository empregadoRepository;

    public EmpregadoController(IEmpregadoRepository empregadoRepository)
    {
        this.empregadoRepository = empregadoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmpregados()
    {
        try
        {
            return Ok(await empregadoRepository.GetEmpregados());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpGet("{EmpregadoId:int}")]
    public async Task<ActionResult<Empregado>> GetEmpregadoById(int EmpregadoId)
    {
        try
        {
            var result = await empregadoRepository.GetEmpregadoById(EmpregadoId);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }

    }



    [HttpPost]
    public async Task<ActionResult<Empregado>> CreateEmpregado([FromBody] Empregado empregado)
    {
        try
        {
            if (empregado == null)
            {
                return BadRequest();
            }

            var result = await empregadoRepository.AddEmpregado(empregado);
            return CreatedAtAction(nameof(GetEmpregadoById), new { id = result.EmpregadoId }, result);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
        }
    }

    [HttpPut("{EmpregadoId:int}")]
    public async Task<ActionResult<Empregado>> UpdateEmpregado([FromBody] Empregado empregado)
    {
        try
        {
            var result = await empregadoRepository.GetEmpregadoById(empregado.EmpregadoId);
            if (result == null)
            {
                return NotFound($"Empregado solicitado = {empregado.Nome}, não foi encontrado");
            }

            return await empregadoRepository.UpdateEmpregado(empregado);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
        }
    }

    [HttpDelete("{EmpregadoId:int}")]
    public async Task<ActionResult<Empregado>> DeleteEmpregado(int EmpregadoId)
    {
        try
        {
            var result = await empregadoRepository.GetEmpregadoById(EmpregadoId);
            if (result == null)
            {
                return NotFound($"Empregado solicitado = {EmpregadoId}, não foi encontrado");
            }
            empregadoRepository.DeleteEmpregadoById(EmpregadoId);

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
        }
    }
}