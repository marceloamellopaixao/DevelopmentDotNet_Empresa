using Empresa.Models;
using Empresa.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers;

[Route("api/empregado")]
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
            return Ok(result);
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
            if (empregado == null || string.IsNullOrWhiteSpace(empregado.Nome))
            {
                return BadRequest("Dados do empregado são inválidos.");
            }

            var createdEmpregado = await empregadoRepository.AddEmpregado(empregado);
            return CreatedAtAction(nameof(GetEmpregadoById), new { 
                EmpregadoId = createdEmpregado.EmpregadoId }, 
                createdEmpregado);
        }
        catch (Exception ex)
        {
            // Realiza um Log (ex) se necessário
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
        }
    }

    [HttpPut("{EmpregadoId:int}")]
    public async Task<ActionResult<Empregado>> UpdateEmpregado(int EmpregadoId, [FromBody] Empregado empregado)
    {
        try
        {
            if (empregado == null)
            {
                return BadRequest("Dados do empregado inválidos.");
            }

            empregado.EmpregadoId = EmpregadoId;

            var updatedEmpregado = await empregadoRepository.UpdateEmpregado(empregado);
            if (updatedEmpregado == null)
            {
                return NotFound($"Empregado com ID {EmpregadoId} não foi encontrado.");
            }

            return Ok(updatedEmpregado);
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