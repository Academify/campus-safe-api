# 🚨 CampusSafe

## 📌 Descrição
CampusSafe é uma aplicação desenvolvida para auxiliar a comunidade acadêmica, sobretudo mulheres, a se manter segura dentro do campus da **UFV**. A plataforma permite que os usuários:
- Cadastrem **alertas de segurança**, informando a localização e o tipo de ocorrência.
- Visualizem os **alertas cadastrados por outros usuários**, mantendo-se informados sobre situações de risco.



## 🛠️ Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET 9.0
- **Banco de Dados**: MySQL
- **Autenticação**: JWT (JSON Web Token)
- **IDE**: JetBrains Rider



## 📂 Estrutura do Projeto
📁 `CampusSafe.Api` - Contém os controladores e a configuração da API.

📁 `CampusSafe.Domain` - Contém os modelos e interfaces do domínio.

📁 `CampusSafe.Domain.Base` - Contém as classes base do domínio.

📁 `CampusSafe.Infrastructure` - Contém a implementação dos repositórios e serviços.


## 🔗 Endpoints
### 🔑 Autenticação
- **POST** `/api/token` - Obtém o token para um cliente cadastrado.

### 👤 Usuário
- **GET** `/api/users/{id}` - Obtém informações de um usuário específico.

### 🚨 Alertas
- **GET** `/api/alerts` - Obtém todos os alertas cadastrados.
- **GET** `/api/alerts/{id}` - Obtém informações de um alerta específico.
- **POST** `/api/alerts` - Cadastra um novo alerta.
- **PUT** `/api/alerts/{id}` - Atualiza um alerta existente.
- **DELETE** `/api/alerts/{id}` - Deleta um alerta existente.



## ▶️ Execução
1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/campussafe.git
2. Abra o projeto no Rider ou na sua IDE de preferência.
3. Configure os segredos no appsettings.json.
4. Execute o projeto CampusSafe.Api.
5. Acesse https://localhost:7121 para testar a API.

## 🚀  Publicação
1. Suba as alterações em uma nova branch no repositório.
2. Crie um pull request para a branch `main`.
3. Aguarde a revisão e a aprovação do pull request.
4. Após a aprovação, o código será mesclado e a API será publicada automaticamente.


## 👨‍💻 Autor
- [Thiago Ferreira](https://github.com/thiagofp0)

📢 Feedbacks e contribuições são bem-vindos! 😃
