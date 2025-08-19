# Sistema de Gerenciamento de Livros / Biblioteca

Este projeto consiste em uma API REST para gerenciamento de uma biblioteca, incluindo operações de cadastro, consulta, empréstimos de livros.

---

## Funcionalidades

- Consultar todos os livros
- Consultar livro por título
- Editar livro
- Remover um livro
- Cadastrar um usuário
- Cadastrar um empréstimo
- Devolver um livro
- Emitir mensagem de devolução atrasada ou dentro do prazo

## Regras de Negócio

- Um usuário pode ter no máximo **3 livros alugados** ao mesmo tempo.
- A **data de devolução** depende da quantidade de livros alugados:

| Quantidade de Livros | Prazo de Devolução |
|----------------------|--------------------|
| 1 livro              | 30 dias            |
| 2 livros             | 15 dias            |
| 3 livros             | 7 dias             |

- Ao tentar ultrapassar o limite de 3 livros, o sistema **bloqueia o empréstimo** com uma mensagem.
- Não é permitido alugar o **mesmo livro mais de uma vez sem devolução**.
- Ao realizar um novo empréstimo, a **data de devolução de todos os livros ativos é atualizada automaticamente**.


