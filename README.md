# Dieta inteligente

Este projeto é uma API de nutrição que permite aos usuários se cadastrarem e receberem uma dieta personalizada com base em suas informações pessoais, como altura, peso e objetivo com a dieta.

## Entidades

- **Alimento**: Contém informações sobre os alimentos.
- **GrupoAlimentar**: Agrupa alimentos relacionados.
- **InformacoesNutricionais**: Detalha as informações nutricionais de cada alimento.
- **Dieta**: Representa a dieta personalizada de um usuário, contendo a identificação do usuário e a data de criação da dieta.
- **DietaAlimento**: Associa uma dieta a um alimento e especifica a quantidade em gramas do alimento na dieta.
- **RestricaoDietetica**: Define restrições dietéticas para um usuário, como a exclusão de grupos alimentares específicos devido a preferências ou necessidades dietéticas, como dietas veganas.
- **Usuario**: Armazena informações sobre o usuário, incluindo dados pessoais e o objetivo da dieta.
- **Objetivos**: Enumeração que define os objetivos dietéticos de um usuário.

## Tecnologias Utilizadas

- .NET 8
- CQRS com MediatR
- Clean Architecture
- DDD (Domain-Driven Design)
- TDD (Test-Driven Development) com xUnit
- Entity Framework Core
- AutoMapper
- Padrão Repository
- DTOs (Data Transfer Objects)

## Banco de Dados

MySQL é utilizado como o sistema de gerenciamento de banco de dados.

## Executando o Projeto
Para executar o projeto, siga os passos abaixo:

1. Clone o repositório.
3. Abra o terminal na pasta do projeto.
5. Execute o comando dotnet restore para restauras os pacotes necessários.
7. Configure a ConnectionString no arquivo appsettings.json.
8. Execute o comando dotnet run para iniciar a API.

Para rodar o projeto, é necessário configurar a `ConnectionString` no arquivo `appsettings.json` para apontar para o seu banco de dados MySQL local.

```json
{
  "ConnectionStrings": {
    "AppDbConnectionString": "SUA_CONNECTION_STRING_AQUI"
  }
}
```
Substitua `SUA_CONNECTION_STRING_AQUI` pela sua string de conexão do MySQL.
