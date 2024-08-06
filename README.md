# Controle de Atletas

README - Controle de Atletas

Descrição do Projeto
- O Controle de Atletas é uma aplicação web desenvolvida em ASP.NET WebForms, com o objetivo de gerenciar informações de atletas. O sistema permite a visualização, edição, exclusão e cadastro de atletas, mantendo um registro detalhado de suas informações, como nome completo, apelido, data de nascimento, altura, peso, posição e número da camisa.

Funcionalidades Principais:
- Listagem de Atletas: Visualização de todos os atletas cadastrados em um GridView.
- Edição de Atletas: Permite editar os dados de um atleta existente através de um formulário de edição.
- Exclusão de Atletas: Funcionalidade para remover atletas do banco de dados.
- Cadastro de Novos Atletas: Interface para adicionar novos atletas ao sistema.
- Classificação IMC: Cálculo e exibição do Índice de Massa Corporal (IMC) com base nos dados fornecidos.

Requisitos de Sistema:
- .NET Framework 4.x
- Visual Studio 2019 ou superior
- SQL Server ou outro banco de dados compatível
- Configuração do Banco de Dados

1. Criação do Banco de Dados:
Primeiro, você precisa criar o banco de dados chamado banco_atletas. Isso pode ser feito utilizando o SQL Server Management Studio ou outro cliente de SQL. Utilize o seguinte comando SQL para criar o banco de dados:

CREATE DATABASE banco_atletas;

2. Configuração da Tabela de Atletas
Depois de criar o banco de dados, crie uma tabela para armazenar as informações dos atletas. Um exemplo básico de como a tabela poderia ser estruturada:

CREATE TABLE Atletas (
    Id INT PRIMARY KEY IDENTITY,
    NomeCompleto NVARCHAR(100),
    Apelido NVARCHAR(50),
    DataNascimento DATE,
    Altura DECIMAL(3, 2),
    Peso DECIMAL(5, 2),
    Posicao NVARCHAR(50),
    NumeroCamisa INT
);

3. Configuração do Web.config
No arquivo Web.config, configure a string de conexão para que a aplicação possa se comunicar com o banco de dados banco_atletas. Adicione ou modifique a seguinte entrada na seção <connectionStrings>:

<connectionStrings>
	<add name="MySqlConnection"
			connectionString="Server=127.0.0.1;Database=banco_atletas;Uid=root;Pwd='';"
			providerName="MySql.Data.MySqlClient" />
</connectionStrings>

Certifique-se de substituir SEU_SERVIDOR pelo nome ou endereço do seu servidor SQL.

4. Integração com a Aplicação
A aplicação utilizará a string de conexão configurada no Web.config para se comunicar com o banco de dados banco_atletas. Certifique-se de que as operações de CRUD (Create, Read, Update, Delete) nos arquivos de código estejam utilizando essa conexão para interagir com a tabela Atletas.

Como Executar o Projeto:
- Clone o repositório para sua máquina local.
- Abra o projeto no Visual Studio.
- Verifique se a string de conexão está corretamente configurada no arquivo Web.config.
- Compile e execute o projeto.
- Acesse a aplicação através do navegador para visualizar e gerenciar os atletas cadastrados.

Considerações Finais
Esse projeto serve como uma base para o gerenciamento de informações de atletas, podendo ser estendido com novas funcionalidades conforme a necessidade. Sinta-se à vontade para contribuir ou modificar o código conforme necessário.
