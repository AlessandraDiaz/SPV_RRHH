using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SPV.DA
{
    public class DataBaseDA
    {
        private String Server = "(local)";
        private String DB = "BD_SPV";
        private String User = "sa";
        private String Password = "riveras";
        //private SqlConnection cn = new SqlConnection("SERVER=(local);DATABASE=SGS_PlazaVea;USER=JuniorJava;PASSWORD=Sulca@8524");

        public SqlConnection getConecction() { 
            String strCn = "SERVER=" + this.Server + ";DATABASE=" + this.DB + ";USER=" + this.User + ";PASSWORD=" + this.Password+ "";
            SqlConnection cn = new SqlConnection(strCn);
            return cn;
        }

        public MySqlConnection getConnectionMysql()
        {
            String strCn = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(strCn);
            return cn;
        }
    }
}
