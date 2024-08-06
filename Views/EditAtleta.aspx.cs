using System;

public partial class EditAtleta : System.Web.UI.Page
{
    private readonly AtletasRepository _atletasRepository;

    public EditAtleta()
    {
        // Certifique-se de que a string de conexão está correta
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        _atletasRepository = new AtletasRepository(connectionString);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int atletaId;
            if (int.TryParse(Request.QueryString["id"], out atletaId))
            {
                LoadAtleta(atletaId);
            }
            else
            {
                Response.Redirect("Views/Default.aspx"); // Redirecionar para a página de listagem se o ID não for válido
            }
        }
    }

    private void LoadAtleta(int id)
    {
        Atleta atleta = _atletasRepository.GetAtletaById(id);
        if (atleta != null)
        {
            hfAtletaId.Value = atleta.Id.ToString();
            txtNomeCompleto.Text = atleta.NomeCompleto;
            txtApelido.Text = atleta.Apelido;
            txtDataNascimento.Text = atleta.DataNascimento.ToString("yyyy-MM-dd");
            txtAltura.Text = atleta.Altura.ToString("F2");
            txtPeso.Text = atleta.Peso.ToString("F2");
            txtPosicao.Text = atleta.Posicao;
            txtNumeroCamisa.Text = atleta.NumeroCamisa.ToString();
        }
        else
        {
            Response.Redirect("Views/Default.aspx"); // Redirecionar se o atleta não for encontrado
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Atleta atleta = new Atleta
        {
            Id = int.Parse(hfAtletaId.Value),
            NomeCompleto = txtNomeCompleto.Text.Trim(),
            Apelido = txtApelido.Text.Trim(),
            DataNascimento = DateTime.Parse(txtDataNascimento.Text.Trim()),
            Altura = float.Parse(txtAltura.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture),
            Peso = float.Parse(txtPeso.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture),
            Posicao = txtPosicao.Text.Trim(),
            NumeroCamisa = int.Parse(txtNumeroCamisa.Text.Trim())
        };

        _atletasRepository.UpdateAtleta(atleta);
        Response.Redirect("Views/Default.aspx"); // Redirecionar para a página de listagem após salvar
    }
}
