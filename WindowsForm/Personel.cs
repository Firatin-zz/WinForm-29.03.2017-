using _02_Service;
using Service;
using System;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Personel : Form
    {
        IPersonelServis personelService;
        public Personel()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            personelService = new PersonelServis();

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            DateTime tarih = Convert.ToDateTime(dtpTarih.Text);

            personelService.insert("insert into Personel (Adi,Soyadi,KayitTarihi) values ('" + ad + "','" + soyad + "','"+ DateTime.Now+ "')");
            personelListe();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            personelListe();
        }

        void personelListe()
        {
            personelService = new PersonelServis();
            var sonuc = personelService.personelListesi("select*from Personel");
            dgvPersonelListe.DataSource = sonuc;
        }
    }
}
