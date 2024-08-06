using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : Page
{
    private readonly AtletasRepository _atletasRepository;

    public Default()
    {
        // Certifique-se de que a string de conexão está correta
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        _atletasRepository = new AtletasRepository(connectionString);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string nomeCompleto = txtNomeCompleto.Text.Trim();
        string apelido = txtApelido.Text.Trim();
        string numeroCamisa = txtNumeroCamisa.Text.Trim();
        string imcFilter = ddlIMC.SelectedValue;

        BindGrid(nomeCompleto, apelido, numeroCamisa, imcFilter);
    }

    private void BindGrid(string nomeCompleto = null, string apelido = null, string numeroCamisa = null, string imcFilter = null)
    {
        List<Atleta> atletas = _atletasRepository.GetAllAtletas(nomeCompleto, apelido, numeroCamisa, imcFilter);
        DataTable dt = ConvertToDataTable(atletas);
        gvAtletas.DataSource = dt;
        gvAtletas.DataBind();
    }


    private DataTable ConvertToDataTable(List<Atleta> atletas)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("NomeCompleto", typeof(string));
        dt.Columns.Add("Apelido", typeof(string));
        dt.Columns.Add("DataNascimento", typeof(DateTime));
        dt.Columns.Add("Altura", typeof(float));
        dt.Columns.Add("Peso", typeof(float));
        dt.Columns.Add("Posicao", typeof(string));
        dt.Columns.Add("NumeroCamisa", typeof(int));

        foreach (var atleta in atletas)
        {
            dt.Rows.Add(atleta.Id, atleta.NomeCompleto, atleta.Apelido, atleta.DataNascimento, atleta.Altura, atleta.Peso, atleta.Posicao, atleta.NumeroCamisa);
        }

        return dt;
    }


    protected void btnAddAtleta_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAtleta.aspx");
    }

    protected void gvAtletas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int atletaId = Convert.ToInt32(gvAtletas.DataKeys[index].Value);
            Response.Redirect(string.Format("EditAtleta.aspx?id={0}", atletaId));
        }
    }

    protected void gvAtletas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Obtém o ID do atleta a partir da chave de dados
        int atletaId = Convert.ToInt32(gvAtletas.DataKeys[e.RowIndex].Value);

        // Chama o método do repositório para deletar o atleta
        _atletasRepository.DeleteAtleta(atletaId);

        // Recarrega os dados na GridView
        BindGridView();
    }

    private void BindGridView()
    {
        var atletas = _atletasRepository.GetAllAtletas();
        gvAtletas.DataSource = atletas;
        gvAtletas.DataBind();
    }

    protected int CalculateAge(DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
        {
            age--;
        }
        return age;
    }

    protected string CalculateIMC(float peso, float altura)
    {
        if (altura <= 0) return "Altura inválida";
        float imc = peso / (altura * altura);
        return imc.ToString("F2"); // Formata o IMC com 2 casas decimais
    }

    protected string CalculateIMCClass(float peso, float altura)
    {
        float imc = peso / (altura * altura);
        if (imc > 25)
        {
            return "bg-warning text-white rounded-1 p-1";
        }
        return "";
    }

    protected string GetIMCClassification(double peso, double altura)
    {
        if (altura == 0)
        {
            return "Altura inválida";
        }

        double imc = peso / (altura * altura);

        if (imc < 18.5)
            return "Abaixo do peso normal";
        else if (imc >= 18.5 && imc < 25)
            return "Peso normal";
        else if (imc >= 25 && imc < 30)
            return "Excesso de peso";
        else if (imc >= 30 && imc < 35)
            return "Obesidade grau I";
        else if (imc >= 35 && imc < 40)
            return "Obesidade grau II";
        else
            return "Obesidade grau III";
    }

}
