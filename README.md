# 📇 Contact Service API (.NET 10)

Esta é uma **Web API de nível profissional** desenvolvida para o gerenciamento de contatos. O projeto foca em operações CRUD (Create, Read, Update, Delete) utilizando as tecnologias mais modernas do ecossistema Microsoft para 2026.

O desenvolvimento foi realizado acompanhando o conteúdo da **Crislaine D'Paula**, com foco em persistência de dados real e boas práticas de backend.

## 🚀 Tecnologias Utilizadas

* **C# / .NET 10**: Versão mais atual do framework, focada em alta performance.
* **ASP.NET Core Web API**: Estrutura robusta para criação de endpoints REST.
* **Entity Framework Core**: ORM para mapeamento e manipulação de dados de forma simplificada.
* **SQL Server**: Banco de dados relacional para armazenamento seguro das informações.
* **Scalar**: Interface interativa de documentação e testes (sucessor do Swagger no .NET 10).

## 🛠️ Funcionalidades

A API permite o gerenciamento completo de uma agenda de contatos:
- **Listar contatos**: Recupera todos os registros do banco de dados.
- **Buscar por ID**: Localiza um contato específico.
- **Criar contato**: Adiciona novos registros com validação de formato de e-mail.
- **Atualizar contato**: Edita informações de contatos existentes.
- **Remover contato**: Exclusão definitiva de registros.

## 📋 Status do Projeto

- [x] Configuração do ambiente de desenvolvimento (Visual Studio 2026 + SQL Server)
- [x] Criação do repositório e estruturação inicial
- [ ] Implementação da conexão com banco de dados e Migrations
- [ ] Desenvolvimento dos Controllers e Endpoints CRUD
- [ ] Validação de regras de negócio (e-mail, campos obrigatórios)
- [ ] Testes finais e documentação no Scalar

> **Nota:** O projeto está atualmente em **fase de estudo e testes**. Estou seguindo o cronograma de aprendizado para consolidar os fundamentos de ASP.NET Core. 🚧

## ⚙️ Como rodar o projeto na sua máquina

1. **Clone o repositório**:
   ```bash
   git clone [https://github.com/PedroInCode/contact-service-csharp.git](https://github.com/PedroInCode/contact-service-csharp.git)