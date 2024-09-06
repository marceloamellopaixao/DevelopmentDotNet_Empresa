using Empresa.Models;
using Empresa.Repository;
using Empresa.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers;

[Route("api/departamento")]
[ApiController]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoRepository departamentoRepository;

    public DepartamentoController(IDepartamentoRepository departamentoRepository)
    {
        this.departamentoRepository = departamentoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetDepartamentos()
    {
        try
        {
            return Ok(await departamentoRepository.GetDepartamentos());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpGet("{DepartamentoId:int}")]
    public async Task<ActionResult<Departamento>> GetDepartamentoById(int DepartamentoId)
    {
        try
        {
            var result = await departamentoRepository.GetDepartamentoById(DepartamentoId);
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

    [HttpGet("empregados/{DepartamentoId:int}")]
    public async Task<ActionResult<IEnumerable<Empregado>>> GetEmpregadosByDepartamentoId(int DepartamentoId)
    {
        try
        {
            var empregados = await departamentoRepository.GetEmpregadosByDepartamentoId(DepartamentoId);
            if (!empregados.Any()) // Verifica se a lista de empregados está vazia
            {
                return NotFound($"Nenhum empregado encontrado para o departamento ID: {DepartamentoId}");
            }
            return Ok(empregados);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Departamento>> CreateDepartamento([FromBody] Departamento departamento)
    {
        try
        {
            if (departamento == null)
            {
                return BadRequest();
            }

            var createdDepartamento = await departamentoRepository.AddDepartamento(departamento);
            return CreatedAtAction(nameof(GetDepartamentoById), new { 
                DepartamentoId = createdDepartamento.DepartamentoId }, 
                createdDepartamento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
        }
    }

    [HttpPut("{DepartamentoId:int}")]
    public async Task<ActionResult<Departamento>> UpdateDepartamento(int DepartamentoId, [FromBody] Departamento departamento)
    {
        try
        {
            if (departamento == null)
            {
                return BadRequest("Dados do departamento inválidos.");
            }

            departamento.DepartamentoId = DepartamentoId;

            var updatedDepartamento = await departamentoRepository.UpdateDepartamento(departamento);
            if (updatedDepartamento == null)
            {
                return NotFound($"Empregado com ID {DepartamentoId} não foi encontrado.");
            }

            return Ok(updatedDepartamento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
        }
    }

    [HttpDelete("{DepartamentoId:int}")]
    public async Task<ActionResult<Departamento>> DeleteDepartamento(int DepartamentoId)
    {
        try
        {
            var result = await departamentoRepository.GetDepartamentoById(DepartamentoId);
            if (result == null)
            {
                return NotFound($"Departamento com id = {DepartamentoId}, não foi encontrado");
            }
            departamentoRepository.DeleteDepartamentoById(DepartamentoId);

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
        }
    }
}