﻿using Empresa.Models;

namespace Empresa.Repository.Interface;

public interface IDepartamentoRepository
{
    Task<IEnumerable<Departamento>> GetDepartamentos(); // Busca todos os Departamentos
    Task<Departamento> GetDepartamentoById(int DepartamentoId); // Busca somente um Departamento
    Task<IEnumerable<Departamento>> GetDepartamentoByNome(string DepartamentoNome); // Busca Departamento por Nome
    Task<Departamento> AddDepartamento(Departamento departamento); // Adiciona o Departamento
    Task<Departamento> UpdateDepartamento(Departamento departamento); // Atualiza o Departamento
    void DeleteDepartamentoById(int DepartamentoId); // Deleta o Departamento
}
