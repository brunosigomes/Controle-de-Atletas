<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAtleta.aspx.cs" Inherits="AddAtleta" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <title>Adicionar Atleta</title>
     <link href="/Content/bootstrap.theme.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet"/>

    <!-- Incluir jQuery primeiro -->
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
    <!-- Incluir jQuery Mask Plugin depois -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="mb-4">Adicionar Atleta</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <div class="row mb-3">
                <label for="nomeCompleto" class="col-sm-2 col-form-label">Nome Completo</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNomeCompleto" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="apelido" class="col-sm-2 col-form-label">Apelido</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtApelido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="dataNascimento" class="col-sm-2 col-form-label">Data de Nascimento</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="altura" class="col-sm-2 col-form-label">Altura (m)</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="peso" class="col-sm-2 col-form-label">Peso (kg)</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" TextMode="Number" step="0.1"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="posicao" class="col-sm-2 col-form-label">Posi��o</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPosicao" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="numeroCamisa" class="col-sm-2 col-form-label">N�mero da Camisa</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNumeroCamisa" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnAdicionarAtleta" runat="server" Text="Adicionar Atleta" CssClass="btn btn-primary" OnClick="btnAdicionarAtleta_Click" />
        </div>
    </form>

     <script type="text/javascript">
         $(document).ready(function () {
             // M�scara para altura e peso com duas casas decimais
             $('#txtAltura').mask('000.00', { reverse: true });
             $('#txtPeso').mask('000.00', { reverse: true });
         });
</script>
</body>
</html>
