### 1. **Visão Geral do Sistema**

- **Descrição do Sistema:**  
  O sistema desenvolvido é uma aplicação para o cadastro e gerenciamento de matrículas de alunos na instituição EdTech. O objetivo principal é permitir que administradores da instituição possam cadastrar novos alunos, listar alunos existentes, editar informações e excluir registros de maneira intuitiva e eficiente. A aplicação deve ser robusta, com uma interface de usuário amigável e uma API eficiente para suportar as operações de CRUD (Criar, Ler, Atualizar, Excluir) nos registros de alunos.

- **Escopo:**  
  *Incluído:*
  - Desenvolvimento da interface de usuário para listagem, criação, edição e exclusão de alunos.
  - Implementação de uma API para gerenciar os dados de alunos.
  - Utilização de tecnologias específicas como Vuetify, .NET Core, C#, e Entity Framework.
  - Persistência dos dados em um banco de dados Postgres ou MySQL.

  *Fora do Escopo:*
  - Funcionalidades avançadas de autenticação e autorização de usuários.
  - Integrações com sistemas externos além dos requisitos básicos.
  - Funcionalidades adicionais como relatórios ou análises avançadas.

### 2. **Arquitetura do Sistema**

- **Diagramas de Arquitetura:**  

   *Fluxo Detalhado:*
      Front-end faz uma requisição HTTP (GET, POST, PUT, DELETE) para o Controller.
      Controller processa a requisição e utiliza o VO para encapsular os dados a serem enviados ao Repository.
      Repository usa AutoMapper para converter entre VO e a entidade Model. O repositório interage com o Entity Framework Core para realizar operações de CRUD no banco de dados.
      O Entity Framework Core executa as operações no banco de dados e retorna os resultados para o Repository.
      Repository converte os resultados de volta para VO e os retorna para o Controller.
      Controller envia a resposta processada de volta ao Front-end.

- **Telas do Sistema:**
   Tela de listagem de alunos

   Tela de confirmação de exclusão de aluno

   Tela de criação de aluno

   Tela de edição de aluno  


### 3. **Tecnologias e Ferramentas**

- **Tecnologias Utilizadas:**  
  *Front-End:*
  - **Vue.js:** Framework JavaScript para construção da interface de usuário.
  - **Vuetify:** Framework de componentes UI baseado em Vue.js para uma aparência moderna e responsiva.
  - **Axios:** Biblioteca para realizar requisições HTTP para a API.

  *Back-End:*
  - **.NET Core:** Framework para desenvolvimento da API.
  - **C#:** Linguagem de programação utilizada para implementar a lógica de negócios.
  - **Entity Framework:** ORM para interagir com o banco de dados.

  *Banco de Dados:*
  - **Postgres:** Sistema de gerenciamento de banco de dados para armazenar as informações dos alunos.

### 4. **Fluxo de Dados e Comunicação**

- **Protocolos e APIs:**
  - **API Endpoints:**
    - `GET /students`: Recupera a lista de alunos.
    - `GET /students/{id}`: Recupera um aluno específico.
    - `POST /students`: Cria um novo aluno.
    - `PUT /students/{id}`: Atualiza as informações de um aluno existente.
    - `DELETE /students/{id}`: Exclui um aluno.

### 5. **Considerações**

- **Dependências:**
  - IDEs (Visual Studio, VS Code), Node.JS (20.9.0), PostgreSQL (16)  e .NET Core (8.0.1).

### 6. **Execução do Sistema**

- **Execução:**  
  Para rodar o sistema, siga os seguintes passos:

  *Clonar repositório:*
  - No terminal, digite `git clone <link-para-repositorio>`
  - Em seguida, entre dentro da pasta que foi gerada e siga os passos abaixo.

  *Front-End:*
  - No terminal, garanta que está dentro da pasta frontend
  - Instale as dependências com `npm install`.
  - Inicie o servidor de desenvolvimento com `npm run dev`.

  *Back-End:*
  - No terminal, garanta que está dentro da pasta WebApi
  - Instale as dependências com `dotnet restore`.
  - Execute a aplicação com `dotnet run`.

  *Banco de Dados:*
  - Configure o banco de dados (Postgres)
  - No terminal, garanta que está dentro da pasta WebApi e execute os seguintes comandos:
    - `dotnet ef database update`
    - `dotnet ef migrations add <NomeDaMigration>`
  - Certique-se de configurar também a ConnectionString que se encontra no arquivo appSettings.json dentro de WebApi

  *Configuração Adicional:*
  - Certifique-se de que as variáveis de ambiente e configurações necessárias estão corretamente definidas.
