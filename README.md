<h1 align="center">FandiApi</h1>

Tabela de conteúdos
=================
<!--ts-->
   * [Sobre o projeto](#-sobre-o-projeto)
   * [Como executar o projeto](#-como-executar-o-projeto)
   * [Autor](#-autor)
   * [Licença](#-licença)
<!--te--> 
 
## 💻 Sobre o projeto

O projeto é dividido em três partes, uma api com um CRUD para produtos, uma outra api para validar a compra, e uma solução de testes unitarios.

Tecnologias utilizadas: EntityFramework, Postgres, Xunit.

Foram seguidos alguns principios do SOLID.

[Documentação](https://documenter.getpostman.com/view/17392143/UVz1NXt4) das apis.

---

## 🚀 Como executar o projeto

Para executar o programa você vai precisar ter instalado em sua máquina o [SDK .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Precisa ter o postgresql na maquina ou em cloud.

Após baixar os arquivos do projeto, use o comando dotnet ef database update no diretorio FandiApi, [documentação](https://docs.microsoft.com/pt-br/ef/core/cli/dotnet). 

Por fim, caso seja preciso, altere a connectionString no arquivo appSettings.

Para iniciar você deve estar no diretorio FandiApi e usar o comando dotnet run

E fazer o mesmo no diretorio FandiPaymentMicroservice para iniciar a segunda aplicação

---

## 🦸 Autor
 <h2>João Paulo Fontes🚀</h2>
 <br />


[![Linkedin Badge](https://img.shields.io/badge/-João-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/jo%C3%A3o-paulo-fontes-vasconcelos/)](https://www.linkedin.com/in/jo%C3%A3o-paulo-fontes-vasconcelos/) 
[![Gmail Badge](https://img.shields.io/badge/-vasconcelosjoao438@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:vasconcelosjoao438@gmail.com)](mailto:vasconcelosjoao438@gmail.com)

---
