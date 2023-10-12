# WebAPI com Autenticação JWT, CRUD Completo e SQLite
Descrição
Este projeto é uma aplicação WebAPI desenvolvida em .NET 7, oferecendo operações CRUD completas e seguras, autenticação JWT para proteger endpoints sensíveis e utiliza um banco de dados SQLite para armazenar dados de forma eficiente. O sistema permite que usuários autenticados realizem operações de criação, leitura, atualização e exclusão de dados, mantendo a integridade e a segurança das informações.

Funcionalidades
Autenticação JWT: Implementação segura de autenticação com JSON Web Tokens (JWT), garantindo que apenas usuários autenticados possam acessar endpoints protegidos.

Autorização: Além da autenticação, a API implementa autorização para controlar o acesso a operações específicas, protegendo dados sensíveis.

SQLite Database: Utilização de um banco de dados SQLite para armazenar dados de forma eficiente e fácil de configurar.

Operações CRUD: Endpoints para criar, ler, atualizar e excluir dados, proporcionando uma funcionalidade completa de gerenciamento de dados.

Endpoints
POST /login: Endpoint para autenticação de usuários. Requer um corpo de requisição contendo credenciais válidas (por exemplo, email e senha) e retorna um token JWT válido para acesso futuro aos endpoints protegidos.
POST /register: Endpoint para cadastro de usuários. Acesso Público.

GET /v1/users/buscar: Endpoint para recuperar todos os usuários. Requer autenticação.

GET /v1/users/buscarPor{id}: Endpoint para recuperar dados de usuário por ID. Requer autenticação.

POST /v1/users/adicionar: Endpoint para criar novo usuário. Requer autenticação.

PUT /v1/users/editar: Endpoint para atualizar usuário existente. Requer autenticação.

DELETE /v1/users/deletar{id}: Endpoint para excluir usuário por ID. Requer autenticação.

Tecnologias Utilizadas
.NET 7

JSON Web Tokens (JWT): Protocolo seguro para autenticação e troca de informações.

SQLite: Banco de dados leve e eficiente, ideal para aplicativos com requisitos de armazenamento moderados.

Como Usar
Clone o repositório para sua máquina local.
Abra o projeto em seu ambiente de desenvolvimento (por exemplo, Visual Studio ou VS Code).
Configure a conexão com o banco de dados SQLite.
Compile e execute a aplicação.
Acesse os endpoints conforme descrito acima usando uma ferramenta como Postman ou Swagger.


Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.
