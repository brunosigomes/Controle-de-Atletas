<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <title>Controle de Atletas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="mb-4">Controle de Atletas</h1>
            <div class="row mb-3">
                <div class="col-sm-2">
                    <asp:TextBox ID="txtNomeCompleto" runat="server" CssClass="form-control" Placeholder="Nome Completo..." />
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtApelido" runat="server" CssClass="form-control" Placeholder="Apelido..." />
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtNumeroCamisa" runat="server" CssClass="form-control" Placeholder="Número da Camisa..." />
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlIMC" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Todos os IMC</asp:ListItem>
                        <asp:ListItem Value="0-18,5">Abaixo do peso normal</asp:ListItem>
                        <asp:ListItem Value="18,5-24,99">Peso normal</asp:ListItem>
                        <asp:ListItem Value="25-29,99">Excesso de peso</asp:ListItem>
                        <asp:ListItem Value="30-34,99">Obesidade grau I</asp:ListItem>
                        <asp:ListItem Value="35-39,99">Obesidade grau II</asp:ListItem>
                        <asp:ListItem Value="40+">Obesidade grau III</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
            <asp:GridView ID="gvAtletas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-striped" OnRowCommand="gvAtletas_RowCommand" OnRowDeleting="gvAtletas_RowDeleting" EmptyDataText="Nenhum atleta encontrado.">
                <Columns>
                    <asp:BoundField DataField="NumeroCamisa" HeaderText="Número da Camisa" SortExpression="NumeroCamisa" />
                    <asp:BoundField DataField="Apelido" HeaderText="Apelido" SortExpression="Apelido" />
                    <asp:BoundField DataField="Posicao" HeaderText="Posição" SortExpression="Posicao" />
                    <asp:TemplateField HeaderText="Idade">
                        <ItemTemplate>
                            <%# CalculateAge(Convert.ToDateTime(Eval("DataNascimento"))) %> anos </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Altura (m)">
                        <ItemTemplate>
                            <%# Convert.ToSingle(Eval("Altura")).ToString("F2") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Peso (kg)">
                        <ItemTemplate>
                            <%# Convert.ToSingle(Eval("Peso")).ToString("F2") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="IMC">
                        <ItemTemplate>
                            <%# CalculateIMC(Convert.ToSingle(Eval("Peso")), Convert.ToSingle(Eval("Altura"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Classificação do IMC">
                        <ItemTemplate>
                            <span class='<%# CalculateIMCClass(Convert.ToSingle(Eval("Peso")), Convert.ToSingle(Eval("Altura"))) %>'>                                 
                                <%# GetIMCClassification(Convert.ToSingle(Eval("Peso")), Convert.ToSingle(Eval("Altura"))) %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument="<%# Container.DataItemIndex %>" Text="Editar" CssClass="btn btn-primary btn-sm" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" Text="Deletar" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Tem certeza que deseja excluir este atleta?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="col-sm-6 mt-3">
                <asp:Button ID="Button2" runat="server" Text="Adicionar Atleta" CssClass="btn btn-success" OnClick="btnAddAtleta_Click" />
            </div>
        </div>
    </form>

    <script>
        $(document).ready(function () {
            $('#<%= gvAtletas.ClientID %>').DataTable();
        });
    </script>
</body>
</html>
