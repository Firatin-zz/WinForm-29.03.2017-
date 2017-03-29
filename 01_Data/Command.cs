using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Data
{

    public class Command
    {
        Baglanti baglanti = new Baglanti();
        public SqlCommand command(string sqlCumlesi)
        {
            SqlCommand cmd = new SqlCommand(sqlCumlesi, baglanti.BaglantiAc());
            return cmd;
        }
    }
}
