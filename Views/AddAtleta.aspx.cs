using System;

public partial class AddAtleta : System.Web.UI.Page
{
    protected AtletasRepository atletasRepository;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Certifique-se de que a string de conexão está correta
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        atletasRepository = new AtletasRepository(connectionString);
    }

    protected void btnAdicionarAtleta_Click(object sender, EventArgs e)
    {
        // Captura os dados do formulário
        string nomeCompleto = txtNomeCompleto.Text;
        string apelido = txtApelido.Text;
        DateTime dataNascimento = DateTime.Parse(txtDataNascimento.Text);
        float altura = float.Parse(txtAltura.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
        float peso = float.Parse(txtPeso.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
        string posicao = txtPosicao.Text;
        int numeroCamisa = int.Parse(txtNumeroCamisa.Text);

        // Cria uma nova instância do atleta
        Atleta novoAtleta = new Atleta
        {
            NomeCompleto = nomeCompleto,
            Apelido = apelido,
            DataNascimento = dataNascimento,
            Altura = altura,
            Peso = peso,
            Posicao = posicao,
            NumeroCamisa = numeroCamisa
        };

        try
        {
            int result = atletasRepository.AddAtleta(novoAtleta);
            if (result > 0)
            {
                // Atleta adicionado com sucesso
                Response.Redirect("Default.aspx"); // Redireciona para uma página de sucesso ou exibe uma mensagem
            }
            else
            {
                // Exibe uma mensagem de erro
                Response.Write("<script>alert('Erro ao adicionar o atleta.');</script>");
            }
        }
        catch (Exception ex)
        {
            // Lida com exceções
            Response.Write("<script>alert('Erro: " + ex.Message + "');</script>");
        }
    }
}
