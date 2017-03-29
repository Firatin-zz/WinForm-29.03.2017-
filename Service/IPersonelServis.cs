using _02_Service.DTO;
using System.Collections.Generic;

namespace _02_Service
{
    public interface IPersonelServis
    {
        int insert(string sqlCumlesi);
        void Delete(string sqlCumlesi);
        void Update(string sqlCumlesi);
        List<PersonelDTO> personelListesi(string sqlCumlesi);
    }
}
