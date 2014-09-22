using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// EncryptionHyperLink 的摘要说明
/// </summary>
namespace uc
{
    public class EncryptionHyperLink : System.Web.UI.WebControls.HyperLink, IEncryption
    {
        public EncryptionHyperLink()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.Load += new EventHandler(EncryptionHyperLink_Load);
        }
        //public string EncryptionNavigateUrl
        //{

        //}


        protected void EncryptionHyperLink_Load(object sender, EventArgs e)
        {
            this.NavigateUrl = EncryptionURL(NavigateUrl);
            this.Text = "fdsfds";
        }

        public string EncryptionURL(string url)
        {
            //string strUserName = url.Split;
            //byte[] b = System.Text.Encoding.Default.GetBytes(strUserName);
            //strUserName = Convert.ToBase64String(b);
            //strUserName = strUserName.Replace("+", "%2B");
            return url+".cn";
        }

    }
    public interface IEncryption
    {
        string EncryptionURL(string url);
    }
}