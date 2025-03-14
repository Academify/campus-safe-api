# CampusSafe

## Descrição

CampusSafe é uma aplicação criada para auxiliar a comunidade acadêmica, sobretudo mulheres, a se manter segura dentro do campus da UFV. A aplicação permite que os usuários cadastrem alertas de segurança, informando a localização e o tipo de ocorrência. Além disso, a aplicação permite que os usuários visualizem os alertas cadastrados por outros usuários.

## Tecnologias Utilizadas

- **Linguagem**: C\#
- **Framework**: .NET 9.0
- **Banco de Dados**: MySQL
- **Autenticação**: JWT (JSON Web Token)
- **IDE**: JetBrains Rider

## Estrutura do Projeto

- `CampusSafe.Api`: Contém os controladores e a configuração da API.
- `CampusSafe.Domain`: Contém os modelos e interfaces do domínio.
- `CampusSafe.Domain.Base`: Conmém as classes base do domínio.
- `CampusSafe.Infrastructure`: Contém a implementação dos repositórios e serviços.

## Endpoints

### Auth
- **POST** `/api/token`: Obtém o token para um cliente cadastrado.

### User
- **GET** `/api/users/{id}`: Obtém informações de um usuário específico.

### Alert
- **GET** `/api/alerts`: Obtém todos os alertas cadastrados.
- **GET** `/api/alerts/{id}`: Obtém informações de um alerta específico.
- **POST** `/api/alerts`: Cadastra um novo alerta.
- **PUT** `/api/alerts/{id}`: Atualiza um alerta existente.
- **DELETE** `/api/alerts/{id}`: Deleta um alerta existente.

## Execução

1. Clone o repositório.
2. Abra o projeto no Rider ou na sua IDE de preferência
3. Adicione os segredos no appsettings.json
4. Execute o projeto `CampusSafe.Api`
5. Acesse `https://localhost:7121` para testar a API.

## Publicação
⏰ Em breve 

## Autores

- [Thiago Ferreira](https://github.com/thiagofp0)