using _01_Data;
using _02_Service;
using _02_Service.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service
{
    public class PersonelServis : IPersonelServis
    {
        Baglanti bag = new Baglanti();
        Command cmd = new Command();
        public void Delete(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();
        }

        public int insert(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();
          
            return 0;
        }

        public List<PersonelDTO> personelListesi(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            SqlDataReader dr = cmd1.ExecuteReader();
            List<PersonelDTO> pdto = new List<PersonelDTO>();

            while (dr.Read())
            {
                pdto.Add(new PersonelDTO
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Ad = dr["Adi"].ToString(),
                    Soyad = dr["Soyadi"].ToString(),
                    KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"].ToString()),                    
                });
            }
            bag.BaglantiKapat();
            return pdto;
        }
        public void Update(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.command(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();
        }
    }
}
