# ApiFilmes
Api que retorna uma lista  paginada de filmes.

## Tecnologias
- .Net6.0
- C#

## Como Instalar
- Primeiramente deve-se ter ao menos o runtime do .net6.0 instalado em sua máquina. Pode fazer o download pelo link https://dotnet.microsoft.com/en-us/download/dotnet/6.0 e instalar manualmente ou utilizar o chocolatey. Chamada Chocolatey: **_choco install dotnet-runtime --version=6.0.0._**
- Clonar o repositório em sua máquina, ir até onde foi salvo pelo prompt de comando e digitar **_dotnet build -c release_** ou **_dotnet build_** (em debug) para compilar o projeto na pasta bin. (As vezes é necessário rodar o **_dotnet restore_** para restaurar dependencias do nuget)
- Navegar até a pasta bin\Debug\net6.0 ou bin\Release\net6.0 e executar a **_ApiFilmes.exe_** para iniciar a aplicação nas portas http://localhost:5000 ou https://localhost:5001.

## AppSettings
- No arquivos de configuração da aplicação se encontra a x-api-key da mesma, podendo ela ser configurada pelo usuário a qualquer momento. Por padrão está a **_teste-1234_**.

## Rotas
- https://localhost:5001/api/filme/listar-filmes lista os 20 primeiros filmes da lista. Pode-se passar a paginação via query para obter outros filmes da lista. Ex: https://localhost:5001/api/filme/listar-filmes?pagina=10&pagina-tamanho=35. Obs: Tamanho máximo para página é de 50.
- https://localhost:5001/api/filme/buscar-filmes?letras=Ose faz uma busca de todos os filmes que o nome inicie com as 3 letras informadas na rota. Só é permitido 3 letras, nem a mais ou a menos.

