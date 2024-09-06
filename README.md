# Documentação da API da Empresa

Esta é a documentação da API para gerenciamento de empregados e departamentos. A API permite realizar operações CRUD (Create, Read, Update, Delete) sobre os recursos de empregados e departamentos.

## Índice

- [Base URL](#base-url)
- [Recursos da API](#recursos-da-api)
  - [Empregados](#empregados)
    - [Listar Empregados](#listar-empregados)
    - [Buscar Empregado por ID](#buscar-empregado-por-id)
    - [Adicionar Empregado](#adicionar-empregado)
    - [Atualizar Empregado](#atualizar-empregado)
    - [Deletar Empregado](#deletar-empregado)
  - [Departamentos](#departamentos)
    - [Listar Departamentos](#listar-departamentos)
    - [Buscar Departamento por ID](#buscar-departamento-por-id)
    - [Adicionar Departamento](#adicionar-departamento)
    - [Atualizar Departamento](#atualizar-departamento)
    - [Deletar Departamento](#deletar-departamento)
    - [Buscar Empregados por ID do Departamento](#buscar-empregados-por-id-do-departamento)
- [Exemplos de Requisições](#exemplos-de-requisições)

## Base URL

`http://localhost:porta/api`

## Recursos da API

### Empregados

#### Listar Empregados

- **URL:** `/empregado`
- **Método:** `GET`
- **Resposta:** Lista de todos os empregados.

```json
[
    {
        "empregadoId": 1,
        "nome": "João",
        "sobrenome": "Silva",
        "email": "joao.silva@example.com",
        "genero": 1,
        "departamentoId": 2,
        "fotoUrl": "http://exemplo.com/foto.jpg"
    }
]
```

#### Buscar Empregado por ID

- **URL:** `/empregado/{EmpregadoId}`
- **Método:** `GET`
- **Parâmetros:**
  - **EmpregadoId:** ID do empregado.
- **Resposta:** Detalhes do empregado.

```json
{
    "empregadoId": 1,
    "nome": "João",
    "sobrenome": "Silva",
    "email": "joao.silva@example.com",
    "genero": 1,
    "departamentoId": 2,
    "fotoUrl": "http://exemplo.com/foto.jpg"
}
```

#### Adicionar Empregado

- **URL:** `/empregado`
- **Método:** `POST`
- **Corpo da Requisição:**

```json
{
    "nome": "João",
    "sobrenome": "Silva",
    "email": "joao.silva@example.com",
    "genero": 1,
    "departamentoId": 2,
    "fotoUrl": "http://exemplo.com/foto.jpg"
}
```

- **Resposta:** Detalhes do empregado criado.

#### Atualizar Empregado

- **URL:** `/empregado/{EmpregadoId}`
- **Método:** `PUT`
- **Parâmetros:**
  - **EmpregadoId:** ID do empregado.
- **Corpo da Requisição:**

```json
{
    "nome": "João",
    "sobrenome": "Silva",
    "email": "joao.silva@example.com",
    "genero": 1,
    "departamentoId": 2,
    "fotoUrl": "http://exemplo.com/foto.jpg"
}
```

- **Resposta:** Detalhes do empregado atualizado.

#### Deletar Empregado

- **URL:** `/empregado/{EmpregadoId}`
- **Método:** `DELETE`
- **Parâmetros:**
  - **EmpregadoId:** ID do empregado.
- **Resposta:** Detalhes do empregado deletado.

### Departamentos

#### Listar Departamentos

- **URL:** `/departamento`
- **Método:** `GET`
- **Resposta:** Lista de todos os departamentos.

```json
[
    {
        "departamentoId": 1,
        "departamentoNome": "TI"
    }
]
```

#### Buscar Departamento por ID

- **URL:** `/departamento/{DepartamentoId}`
- **Método:** `GET`
- **Parâmetros:**
  - **DepartamentoId:** ID do departamento.
- **Resposta:** Detalhes do departamento.

```json
{
    "departamentoId": 1,
    "departamentoNome": "TI"
}
```

#### Adicionar Departamento

- **URL:** `/departamento`
- **Método:** `POST`
- **Corpo da Requisição:**

```json
{
    "departamentoNome": "TI"
}
```

- **Resposta:** Detalhes do departamento criado.

#### Atualizar Departamento

- **URL:** `/departamento/{DepartamentoId}`
- **Método:** `PUT`
- **Parâmetros:**
  - **DepartamentoId:** ID do departamento.
- **Corpo da Requisição:**

```json
{
    "departamentoNome": "Desenvolvimento"
}
```

- **Resposta:** Detalhes do departamento atualizado.

#### Deletar Departamento

- **URL:** `/departamento/{DepartamentoId}`
- **Método:** `DELETE`
- **Parâmetros:**
  - **DepartamentoId:** ID do departamento.
- **Resposta:** Detalhes do departamento deletado.

#### Buscar Empregados por ID do Departamento

- **URL:** `/departamento/empregados/{DepartamentoId}`
- **Método:** `GET`
- **Parâmetros:**
  - **DepartamentoId:** ID do departamento.
- **Resposta:** Lista de empregados associados ao departamento.

```json
[
    {
        "empregadoId": 1,
        "nome": "João",
        "sobrenome": "Silva"
    }
]
```

## Exemplos de Requisições

### Exemplo de Requisição POST para Adicionar um Empregado

```bash
curl -X POST http://localhost:5000/api/empregado \
-H "Content-Type: application/json" \
-d '{"nome": "Ana", "sobrenome": "Pereira", "email": "ana.pereira@example.com", "genero": 0, "departamentoId": 1, "fotoUrl": "http://exemplo.com/foto.jpg"}'
```

### Exemplo de Requisição PUT para Atualizar um Departamento

```bash
curl -X PUT http://localhost:5000/api/departamento/1 \
-H "Content-Type: application/json" \
-d '{"departamentoNome": "Recursos Humanos"}'
```
