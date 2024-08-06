# Controle de Atletas

README - Controle de Atletas

Descri��o do Projeto
- O Controle de Atletas � uma aplica��o web desenvolvida em ASP.NET WebForms, com o objetivo de gerenciar informa��es de atletas. O sistema permite a visualiza��o, edi��o, exclus�o e cadastro de atletas, mantendo um registro detalhado de suas informa��es, como nome completo, apelido, data de nascimento, altura, peso, posi��o e n�mero da camisa.

Funcionalidades Principais:
- Listagem de Atletas: Visualiza��o de todos os atletas cadastrados em um GridView.
- Edi��o de Atletas: Permite editar os dados de um atleta existente atrav�s de um formul�rio de edi��o.
- Exclus�o de Atletas: Funcionalidade para remover atletas do banco de dados.
- Cadastro de Novos Atletas: Interface para adicionar novos atletas ao sistema.
- Classifica��o IMC: C�lculo e exibi��o do �ndice de Massa Corporal (IMC) com base nos dados fornecidos.

Requisitos de Sistema:
- .NET Framework 4.x
- Visual Studio 2019 ou superior
- SQL Server ou outro banco de dados compat�vel
- Configura��o do Banco de Dados

1. Cria��o do Banco de Dados:
Primeiro, voc� precisa criar o banco de dados chamado banco_atletas. Isso pode ser feito utilizando o SQL Server Management Studio ou outro cliente de SQL. Utilize o seguinte comando SQL para criar o banco de dados:

CREATE DATABASE banco_atletas;

2. Configura��o da Tabela de Atletas
Depois de criar o banco de dados, crie uma tabela para armazenar as informa��es dos atletas. Um exemplo b�sico de como a tabela poderia ser estruturada:

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

3. Configura��o do Web.config
No arquivo Web.config, configure a string de conex�o para que a aplica��o possa se comunicar com o banco de dados banco_atletas. Adicione ou modifique a seguinte entrada na se��o <connectionStrings>:

<connectionStrings>
	<add name="MySqlConnection"
			connectionString="Server=127.0.0.1;Database=banco_atletas;Uid=root;Pwd='';"
			providerName="MySql.Data.MySqlClient" />
</connectionStrings>

Certifique-se de substituir SEU_SERVIDOR pelo nome ou endere�o do seu servidor SQL.

4. Integra��o com a Aplica��o
A aplica��o utilizar� a string de conex�o configurada no Web.config para se comunicar com o banco de dados banco_atletas. Certifique-se de que as opera��es de CRUD (Create, Read, Update, Delete) nos arquivos de c�digo estejam utilizando essa conex�o para interagir com a tabela Atletas.

Como Executar o Projeto:
- Clone o reposit�rio para sua m�quina local.
- Abra o projeto no Visual Studio.
- Verifique se a string de conex�o est� corretamente configurada no arquivo Web.config.
- Compile e execute o projeto.
- Acesse a aplica��o atrav�s do navegador para visualizar e gerenciar os atletas cadastrados.

Considera��es Finais
Esse projeto serve como uma base para o gerenciamento de informa��es de atletas, podendo ser estendido com novas funcionalidades conforme a necessidade. Sinta-se � vontade para contribuir ou modificar o c�digo conforme necess�rio.
