using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models;

[Table("Departamentos_PX")]
public class Departamento
{
    [Key]
    public int DepartamentoId { get; set; }
    public string? DepartamentoNome { get; set; }
    public List<Empregado> Empregados { get; set; }

}
