# ByGrace

O objetivo do projeto é criar uma plataforma web para realizar vendas de roupas online.

## Alunos integrantes da equipe

* Gabriel Henrique Mota Rodrigues  
* Matheus Vinicius Mota Rodrigues
* Gabriel Matos Martins Fialho Da Silva
* Paula De Freitas Camargos
* Matheus Martins Da Silva Porto

## Professores responsáveis

* Eveline Alonso Veloso
* Pedro Pongelupe Lopes
* Lucas Henrique Pereira

## Instruções de utilização

*Instalações:
    - Para utilizar a aplicação de maneira local, primeiro você irá precisar instalar o Visual Studio e o SQL Server;
    - Após a instalação, crie um projeto .NET CORE 7 e substitua os arquivos do projeto pelos arquivos da pasta *`Código`* neste repositório;

*Preparação:
    - Após substituir o código, abra o arquivo *`appsettings.json`* e atualize a string de conexão de acordo com o seu banco de dados. Ex: *`"ByGrace": "server=localhost\\SQLEXPRESS; database=ByGrace; trusted_connection=true; trustservercertificate=true",`*
    - Logo em seguida, apague a pasta *`Migrations`* do projeto e no Package Manage Console, rode o comando *`add-migration NomeDaMigration`* e em seguida o comando *`update-databse`*.
    - Caso os passos tenham sido seguidos corretamente, o software deve estar pronto para ser usado.

*Possíveis erros:
    1 - Não foi possível se conectar a base de dados: Verifique sua string de conexão no arquivo *`appsettings.json`* e garanta que ela bate com as informações do seu SQL Server;
    2 - Ao realizar alguma ação ocorre um erro no console do navegador: Tente realizar a limpeza do cache do seu navegador e tente novamente.
