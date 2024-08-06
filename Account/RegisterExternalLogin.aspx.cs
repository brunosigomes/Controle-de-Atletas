using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using Controle_de_Atletas;

public partial class Account_RegisterExternalLogin : System.Web.UI.Page
{
    protected string ProviderName
    {
        get { return (string)ViewState["ProviderName"] ?? String.Empty; }
        private set { ViewState["ProviderName"] = value; }
    }

    protected string ProviderAccountKey
    {
        get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
        private set { ViewState["ProviderAccountKey"] = value; }
    }

    protected void Page_Load()
    {
        // Processar o resultado a partir de um provedor de autenticação da solicitação
        ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);
        if (String.IsNullOrEmpty(ProviderName))
        {
            Response.Redirect("~/Account/Login");
        }
        if (!IsPostBack)
        {
            var manager = new UserManager();
            var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
            if (loginInfo == null)
            {
                Response.Redirect("~/Account/Login");
            }
            var user = manager.Find(loginInfo.Login);
            if (user != null)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else if (User.Identity.IsAuthenticated)
            {
                // Aplicar a verificação XSRF durante a vinculação
                var verifiedloginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, User.Identity.GetUserId());
                if (verifiedloginInfo == null)
                {
                    Response.Redirect("~/Account/Login");
                }

                var result = manager.AddLogin(User.Identity.GetUserId(), verifiedloginInfo.Login);
                if (result.Succeeded)
                {
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    AddErrors(result);
                    return;
                }
            }
            else
            {
                userName.Text = loginInfo.DefaultUserName;
            }
        }
    }

    protected void LogIn_Click(object sender, EventArgs e)
    {
        CreateAndLoginUser();
    }

    private void CreateAndLoginUser()
    {
        if (!IsValid)
        {
            return;
        }
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = userName.Text };
        IdentityResult result = manager.Create(user);
        if (result.Succeeded)
        {
            var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
            if (loginInfo == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }
            result = manager.AddLogin(user.Id, loginInfo.Login);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                return;
            }
        }
        AddErrors(result);
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }
}