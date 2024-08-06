using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class AtletasRepository
{
    private readonly MySqlConnectionHelper _connectionHelper;

    public AtletasRepository(string connectionString)
    {
        _connectionHelper = new MySqlConnectionHelper(connectionString);
    }

    public int AddAtleta(Atleta atleta)
    {
        string query = "INSERT INTO atletas (nome_completo, apelido, data_nascimento, altura, peso, posicao, numero_camisa) " +
                       "VALUES (@nome_completo, @apelido, @data_nascimento, @altura, @peso, @posicao, @numero_camisa)";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@nome_completo", atleta.NomeCompleto),
            new MySqlParameter("@apelido", atleta.Apelido),
            new MySqlParameter("@data_nascimento", atleta.DataNascimento),
            new MySqlParameter("@altura", atleta.Altura),
            new MySqlParameter("@peso", atleta.Peso),
            new MySqlParameter("@posicao", atleta.Posicao),
            new MySqlParameter("@numero_camisa", atleta.NumeroCamisa)
        };

        return _connectionHelper.ExecuteNonQuery(query, parameters);
    }

    public List<Atleta> GetAllAtletas(string nomeCompleto = null, string apelido = null, string numeroCamisa = null, string imcFilter = null )
    {
        string query = "SELECT * FROM atletas";
        List<MySqlParameter> parameters = new List<MySqlParameter>();

        if (!string.IsNullOrEmpty(nomeCompleto))
        {
            query += " WHERE nome_completo LIKE @nomeCompleto";
            parameters.Add(new MySqlParameter("@nomeCompleto", "%" + nomeCompleto + "%"));
        }

        if (!string.IsNullOrEmpty(apelido))
        {
            query += string.IsNullOrEmpty(nomeCompleto) ? " WHERE" : " AND";
            query += " apelido LIKE @apelido";
            parameters.Add(new MySqlParameter("@apelido", "%" + apelido + "%"));
        }

        if (!string.IsNullOrEmpty(numeroCamisa))
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido)) ? " WHERE" : " AND";
            query += " numero_camisa = @numeroCamisa";
            parameters.Add(new MySqlParameter("@numeroCamisa", numeroCamisa));
        }

        if (!string.IsNullOrEmpty(imcFilter))
        {
            string[] imcRange = imcFilter.Split('-');

            if (imcRange.Length == 2)
            {
                float lowerBound = float.Parse(imcRange[0]);
                float upperBound = imcRange[1] == "+" ? float.MaxValue : float.Parse(imcRange[1]);

                query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
                query += " (peso / (altura * altura)) BETWEEN @lowerBound AND @upperBound";
                parameters.Add(new MySqlParameter("@lowerBound", lowerBound));
                parameters.Add(new MySqlParameter("@upperBound", upperBound));
            }
            else if (imcFilter == "40+")
            {
                // Filtro para IMC acima de 40
                query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
                query += " (peso / (altura * altura)) >= 40";
            }
        }
        else if (imcFilter == "Abaixo do peso normal")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) < 18.5";
        }
        else if (imcFilter == "Peso normal")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) BETWEEN 18.5 AND 24.9";
        }
        else if (imcFilter == "Excesso de peso")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) BETWEEN 25 AND 29.9";
        }
        else if (imcFilter == "Obesidade grau I")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) BETWEEN 30 AND 34.9";
        }
        else if (imcFilter == "Obesidade grau II")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) BETWEEN 35 AND 39.9";
        }
        else if (imcFilter == "Obesidade grau III")
        {
            query += (string.IsNullOrEmpty(nomeCompleto) && string.IsNullOrEmpty(apelido) && string.IsNullOrEmpty(numeroCamisa)) ? " WHERE" : " AND";
            query += " (peso / (altura * altura)) >= 40";
        }


        // Cria a lista de atletas a ser retornada
        List<Atleta> atletas = new List<Atleta>();

        using (var reader = _connectionHelper.ExecuteReader(query, parameters.ToArray()))
        {
            while (reader.Read())
            {
                Atleta atleta = new Atleta
                {
                    Id = reader.GetInt32("id"),
                    NomeCompleto = reader.GetString("nome_completo"),
                    Apelido = reader.GetString("apelido"),
                    DataNascimento = reader.GetDateTime("data_nascimento"),
                    Altura = reader.GetFloat("altura"),
                    Peso = reader.GetFloat("peso"),
                    Posicao = reader.GetString("posicao"),
                    NumeroCamisa = reader.GetInt32("numero_camisa")
                };
                atletas.Add(atleta);
            }
        }

        return atletas;
    }

    public Atleta GetAtletaById(int id)
    {
        string query = "SELECT * FROM atletas WHERE id = @id";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@id", id)
        };

        using (var reader = _connectionHelper.ExecuteReader(query, parameters))
        {
            if (reader.Read())
            {
                return new Atleta
                {
                    Id = reader.GetInt32("id"),
                    NomeCompleto = reader.GetString("nome_completo"),
                    Apelido = reader.GetString("apelido"),
                    DataNascimento = reader.GetDateTime("data_nascimento"),
                    Altura = reader.GetFloat("altura"),
                    Peso = reader.GetFloat("peso"),
                    Posicao = reader.GetString("posicao"),
                    NumeroCamisa = reader.GetInt32("numero_camisa")
                };
            }
        }

        return null;
    }

    public int UpdateAtleta(Atleta atleta)
    {
        string query = "UPDATE atletas SET nome_completo = @nome_completo, apelido = @apelido, data_nascimento = @data_nascimento, " +
                       "altura = @altura, peso = @peso, posicao = @posicao, numero_camisa = @numero_camisa WHERE id = @id";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@id", atleta.Id),
            new MySqlParameter("@nome_completo", atleta.NomeCompleto),
            new MySqlParameter("@apelido", atleta.Apelido),
            new MySqlParameter("@data_nascimento", atleta.DataNascimento),
            new MySqlParameter("@altura", atleta.Altura),
            new MySqlParameter("@peso", atleta.Peso),
            new MySqlParameter("@posicao", atleta.Posicao),
            new MySqlParameter("@numero_camisa", atleta.NumeroCamisa)
        };

        return _connectionHelper.ExecuteNonQuery(query, parameters);
    }

    public int DeleteAtleta(int id)
    {
        string query = "DELETE FROM atletas WHERE id = @id";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@id", id)
        };

        return _connectionHelper.ExecuteNonQuery(query, parameters);
    }
}
