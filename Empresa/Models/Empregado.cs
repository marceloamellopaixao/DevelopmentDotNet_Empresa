using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models;

[Table("Empregados_PX")]
public class Empregado
{
    [Key]
    public int EmpregadoId { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome {  get; set; }
    public string? Email { get; set; }
    public Genero Genero { get; set; }
    public string? FotoUrl { get; set; }
    public Departamento Departamento { get; set; }

}
