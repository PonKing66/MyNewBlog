using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TestXml
{
    public class OperateDataBase
    {

        private string sqlStr;
        private SqlConnection sqlConnection;

        [Obsolete]
        public OperateDataBase()
        {
            sqlStr = "Server=localhost;User Id=sa;Pwd=123456;DataBase=NewsInformation";
        }
        public void Open()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(sqlStr);
                sqlConnection.Open();
            }
            else
            {
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                {
                    sqlConnection.Open();
                }
            }
        }

        public void Close()
        {
            if (sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }



        public void ExceRead(List<NewsItem> newsItems)
        {

            int count = 0;
            foreach (NewsItem nt in newsItems)
            {
                Open();
                
                string strSqlCom = string.Format("insert into article" +
                "(title, description, link, categoryId, date, author)values" +
                "('{0}','{1}','{2}',1,'{3}','{4}')",
                nt.title,nt.desc,nt.link,nt.date,null);
                SqlCommand sqlCommand = new SqlCommand(strSqlCom, sqlConnection);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    count++;
                }
                catch
                {

                }
                Close();
            }
            Console.WriteLine(String.Format("成功导入{0}篇文章", count));
        }
    }
}
