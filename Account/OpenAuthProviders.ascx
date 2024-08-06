<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpenAuthProviders.ascx.cs" Inherits="OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Use outro serviço para fazer o logon.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Faça logon usando sua <%#: Item %> conta.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>Não há serviços de autenticação externos configurados. Consulte <a href="https://go.microsoft.com/fwlink/?LinkId=252803">este artigo</a> para obter detalhes sobre como configurar este aplicativo ASP.NET para dar suporte ao registro em log por meio de serviços externos.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>