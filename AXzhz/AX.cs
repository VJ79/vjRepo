using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Text;


    public class AX : System.Web.UI.Page, IHttpHandler
    {
        //���URLΪ*.ax,��ִ������ķ���
        public new void ProcessRequest(HttpContext context)
        {
            /**/
            /*��ǰ�����ĵ�����
    ɾ����,����:
    �쳣��ϸ��Ϣ: System.Web.HttpException: �����ڴ��������в�����*/
            HttpRequest Request = context.Request;

            //��ȡ�������������
            string strPathAndQuery = Request.Url.PathAndQuery;
            //ȡ��URL������ҳ����
            string filename = strPathAndQuery.Substring(strPathAndQuery.LastIndexOf("/"), strPathAndQuery.LastIndexOf(".") - strPathAndQuery.LastIndexOf("/"));
            //�趨Ҫת�����ҳ
            Server.Transfer("~/" +  "Default.aspx");
            /**/
            /*������仰����ʹ�κ���.ax��׺��URLת��
    һ���̶������·����ҳtarget.aspx��*/
            //Server .Transfer ("/target/target.aspx");

        }
        //HttpHandler������Ϊͬ����ͬ�������������ɶ�Ϊ����øô������� HTTP ����Ĵ����Ż᷵�ء�
        public new bool IsReusable
        {
            get { return false; }
        }
   
}
