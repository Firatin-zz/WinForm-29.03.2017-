using _02_Service;
using _02_Service.DTO;
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
        private void Personel_Load(object sender, EventArgs e)
        {
            personelListe();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                personelService = new PersonelServis();

                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                DateTime tarih = DateTime.Parse(dtpTarih.Text);

                personelService.insert("insert into Personel (Adi,Soyadi,KayitTarihi) values ('" + ad + "','" + soyad + "','" + tarih.ToString("yyyy-MM-dd") + "')");
                personelListe();
                MessageBox.Show("Eklendi");
            }
            catch
            {


            }
        }


        void personelListe()
        {
            personelService = new PersonelServis();
            var sonuc = personelService.personelListesi("select*from Personel");
            dgvPersonelListe.DataSource = sonuc;

            cmbPersonel.DataSource = sonuc;
            cmbPersonel.ValueMember = "Id";
            cmbPersonel.DisplayMember = "Ad";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (PersonelDTO)dgvPersonelListe.SelectedRows[0].DataBoundItem;
                personelService = new PersonelServis();
                personelService.Delete("delete from Personel where Id=" + item.Id + "");
                MessageBox.Show("Silindi!");

            }
            catch
            {

            }
            personelListe();
        }
        private void dgvPersonelListe_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPersonelListe.SelectedRows.Count != 0)
            {
                var item = (PersonelDTO)dgvPersonelListe.SelectedRows[0].DataBoundItem;
                txtAd.Text = item.Ad;
                txtSoyad.Text = item.Soyad;
                dtpTarih.Text = item.KayitTarihi.ToString();
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvPersonelListe.SelectedRows.Count != 0)
            {
                var tarih = Convert.ToDateTime(dtpTarih.Text);

                var item = (PersonelDTO)dgvPersonelListe.SelectedRows[0].DataBoundItem;
                personelService = new PersonelServis();
                personelService.Update("update Personel set Adi='" + txtAd.Text + "',Soyadi='" + txtSoyad.Text + "',KayitTarihi='" + tarih.ToString("yyyy-MM-dd") + "' where id='" + item.Id + "'");
                personelListe();
            }
        }

        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sonuc = (PersonelDTO)cmbPersonel.SelectedItem;
            txtAd.Text = sonuc.Ad;
            txtSoyad.Text = sonuc.Soyad;
            dtpTarih.Text = sonuc.KayitTarihi.ToString();
        }
    }
}
