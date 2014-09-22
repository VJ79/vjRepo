using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ConsoleApplication1.SQLserver
{
    public class Xml
    {
        public static void testXML()
        {
            using (SqlConnection con = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=PruductManagement;Integrated Security=True"))
            {
                string sql = "select * from xmlTest";
                SqlCommand com = new SqlCommand(sql, con);
               
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataSet ds=new DataSet();
                sda.Fill(ds);
                string s=  ds.Tables[0].Rows[2][2].ToString();
                con.Open();
                string ss = "<f/>";


                Encoding utf8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");//Encoding.Default ,936
                byte[] temp = utf8.GetBytes(ss);
                byte[] temp1 = Encoding.Convert(utf8, gb2312, temp);
                string result = gb2312.GetString(temp1);
                


                com.CommandText = "insert into xmltest(id,description,xmlcontent) values(1,'f','"+result+"')";
                com.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
