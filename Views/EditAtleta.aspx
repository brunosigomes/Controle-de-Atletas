<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAtleta.aspx.cs" Inherits="EditAtleta" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <title>Editar Atleta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Incluir jQuery primeiro -->
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
    <!-- Incluir jQuery Mask Plugin depois -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="mb-4">Editar Atleta</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <div class="row mb-3">
                <label for="txtNomeCompleto" class="col-sm-2 col-form-label">Nome Completo</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNomeCompleto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtApelido" class="col-sm-2 col-form-label">Apelido</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtApelido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtDataNascimento" class="col-sm-2 col-form-label">Data de Nascimento</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtAltura" class="col-sm-2 col-form-label">Altura (m)</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" step="0.01"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtPeso" class="col-sm-2 col-form-label">Peso (kg)</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" step="0.1"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtPosicao" class="col-sm-2 col-form-label">Posição</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPosicao" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtNumeroCamisa" class="col-sm-2 col-form-label">Número da Camisa</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNumeroCamisa" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <asp:HiddenField ID="hfAtletaId" runat="server" />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
        </div>
    </form>

     <script type="text/javascript">
        $(document).ready(function () {
             // Máscara para altura e peso com duas casas decimais
             $('#txtAltura').mask('000.00', { reverse: true });
             $('#txtPeso').mask('000.00', { reverse: true });
        });
    </script>
</body>
</html>
