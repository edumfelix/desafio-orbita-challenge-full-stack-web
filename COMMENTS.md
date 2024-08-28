## Decisão da Arquitetura Utilizada

A arquitetura adotada no sistema segue o padrão MVC (Model-View-Controller), complementado pelo uso de Value Objects (VO) e o padrão Repository.

Separação de Responsabilidades: A clara separação entre o controller, o repositório e o modelo facilita a manutenção e a escalabilidade do sistema.
Abstração de Dados: O repositório abstrai a lógica de acesso a dados, permitindo que o controller se concentre na lógica de aplicação e no processamento de requisições.
Essa arquitetura proporciona uma estrutura robusta e modular, ideal para aplicações que requerem uma separação clara entre lógica de negócios, acesso a dados e apresentação.

## Lista de Bibliotecas de Terceiros Utilizadas

### Front-End
- Vue
- Vuetify
- Axios

### Back-End
- Bibliotecas padrão
- AutoMapper
- Npgsql

### Testes Unitários
- XUnit
- Moq

## O Que Você Melhoraria se Tivesse Mais Tempo

- Melhoraria a formatação e tratamento dos campos de texto, utilizando máscaras e verificando se o campo CPF é válido.
- Implementaria a ferramenta de busca de registros na consulta de alunos.
- Implementaria cadastro e login de usuários.
- Implementaria autenticação de dois fatores.
- Criaria mais testes unitários
- Realizaria o deploy da aplicação.

## Quais Requisitos Obrigatórios Não Foram Entregues

Nenhum.
