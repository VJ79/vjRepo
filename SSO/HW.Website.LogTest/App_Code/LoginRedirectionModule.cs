using HW.Website.LogTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
public class LoginRedirectionModule : IHttpModule
{
    public LoginRedirectionModule()
    {
    }

    public String ModuleName
    {
        get { return "LoginRedirectionModule"; }
    }

    // In the Init function, register for HttpApplication 
    // events by adding your handlers.
    public void Init(HttpApplication application)
    {
        application.BeginRequest +=
            (new EventHandler(this.Application_BeginRequest));
        application.EndRequest +=
            (new EventHandler(this.Application_EndRequest));
    }

    private void Application_BeginRequest(Object source, EventArgs e)
    {
        ValidateUser(source);
    }

    private Uri _loginUri;
    private Uri LoginUri
    {
        get
        {
            if (_loginUri == null)
            {
                _loginUri = new Uri(new System.Configuration.AppSettingsReader().GetValue("LoginWebsite", typeof(string)).ToString());

            }
            return _loginUri;
        }
    }

    private void SetAuthenticationTicket(HttpApplication app, string userID, string roles)
    {
        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1
            , userID
            , DateTime.Now, DateTime.Now.AddMinutes(60)
            , true
            , roles
            , FormsAuthentication.FormsCookiePath);

        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        authCookie.Expires = authTicket.Expiration;
        app.Response.Cookies.Add(authCookie);
    }

    private void ValidateUser(object sender)
    {
        HttpApplication app = (HttpApplication)sender;

        //获取身份验证的cookie
        HttpCookie cookie = app.Request.Cookies[FormsAuthentication.FormsCookieName];
        var loginWebsite = LoginUri;
       
        var uticket = app.Request.QueryString["ticket"];
        var userId = app.Request.QueryString["userId"];
        if (!string.IsNullOrWhiteSpace(uticket) && !string.IsNullOrWhiteSpace(userId) && app.Request.UrlReferrer.Authority == loginWebsite.Authority)
        {           
            SetAuthenticationTicket(app, userId, "administrator");
            return;
        }
        if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
        {
            string encryptedTicket = cookie.Value;

            //解密cookie中的票据信息
            FormsAuthenticationTicket ticket =
                FormsAuthentication.Decrypt(encryptedTicket);

            //获取用户角色信息
            string[] roles = ticket.UserData.Split(',');

            //创建用户标识
            FormsIdentity identity = new FormsIdentity(ticket);

            //创建用户的主体信息
            System.Security.Principal.GenericPrincipal user =
            new System.Security.Principal.GenericPrincipal(identity, roles);
            app.Context.User = user;
        }
        else
        {
            app.Response.Redirect(loginWebsite + "/Account/Login?returnurl=" + app.Request.Url.ToString());
        }
    }   

    private void Application_EndRequest(Object source, EventArgs e)
    {

    }

    public void Dispose() { }
}