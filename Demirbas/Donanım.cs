using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demirbas
{
    public partial class Donanım : Form
    {
        private MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=demirbas;User=root");
        private DemirbasTakip demirbasTakipForm;
        private int personelId;

        public Donanım(int personelId, DemirbasTakip demirbasTakipForm)
        {
            InitializeComponent();
            this.personelId = personelId;
            this.demirbasTakipForm = demirbasTakipForm;
            LoadDonanimData(personelId);

        }

        private void LoadDonanimData(int personelId)
        {
            try
            {
                baglanti.Open();
                string query = "SELECT id, marka, model, aciklama, verildigiTarih, kullanici_id " +
                               "FROM donanim " +
                               "WHERE kullanici_id = @personelId";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@personelId", personelId);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void Donanım_Load(object sender, EventArgs e)
        {

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            UrunEkle urunEkle = new UrunEkle(personelId);
            urunEkle.FormClosed += UrunEkle_FormClosed;
            urunEkle.Show();
        }

        private void UrunEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDonanimData(personelId); // UrunEkle formu kapandığında DataGridView'i yenile

            // Son eklenen ürünün id'sini al
            int sonEklenenUrunId = GetSonEklenenUrunId();
            if (sonEklenenUrunId != -1)
            {
                KasaBilgi kasaBilgi = new KasaBilgi(sonEklenenUrunId);
                kasaBilgi.Show();
            }
        }


        private int GetSonEklenenUrunId()
        {
            int id = -1;
            try
            {
                baglanti.Open();
                string query = "SELECT id FROM donanim WHERE kullanici_id = @personelId ORDER BY id DESC LIMIT 1";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@personelId", personelId);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return id;
        }

        private void genelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            demirbasTakipForm.Show();
            this.Close();
        }

        private void btnKasaBlgisi_Click(object sender, EventArgs e)
        {
            int donanimId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            KasaBilgi kasaBilgi = new KasaBilgi(donanimId);
            kasaBilgi.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int donanimId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                try
                {
                    baglanti.Open();

                    // İlk olarak kasa bilgilerini sil
                    string deleteKasaQuery = "DELETE FROM kasa WHERE id = @donanimId";
                    MySqlCommand deleteKasaCommand = new MySqlCommand(deleteKasaQuery, baglanti);
                    deleteKasaCommand.Parameters.AddWithValue("@donanimId", donanimId);
                    deleteKasaCommand.ExecuteNonQuery();

                    // Sonra donanım bilgilerini sil
                    string deleteDonanimQuery = "DELETE FROM donanim WHERE id = @donanimId";
                    MySqlCommand deleteDonanimCommand = new MySqlCommand(deleteDonanimQuery, baglanti);
                    deleteDonanimCommand.Parameters.AddWithValue("@donanimId", donanimId);
                    deleteDonanimCommand.ExecuteNonQuery();

                    MessageBox.Show("Seçilen ürün ve ilgili kasa bilgileri başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                    LoadDonanimData(personelId); // DataGridView'i yenile
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
            }
        }
    }
}
