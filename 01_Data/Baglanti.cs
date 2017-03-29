using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Data
{
    public class Baglanti
    {
        SqlConnection conn = new SqlConnection("server=.;user id=sa;password=123; initial catalog=Personel");

        public SqlConnection BaglantiAc()
        {
            conn.Open();
            return conn;
        }
        public SqlConnection BaglantiKapat()
        {
            conn.Close();
            return conn;
        }
    }
}
