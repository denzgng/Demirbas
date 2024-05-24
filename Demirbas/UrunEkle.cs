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
    public partial class UrunEkle : Form
    {
        private MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=demirbas;User=root");
        private int personelId;
        public UrunEkle(int personelId)
        {
            InitializeComponent();
            this.personelId = personelId;
            txtKullaniciId.Text = personelId.ToString();
            txtKullaniciId.ReadOnly = true;
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string query = "INSERT INTO donanim (marka, model, aciklama, verildigiTarih, kullanici_id) " +
                               "VALUES (@marka, @model, @aciklama, @verildigiTarih, @personelId)";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@marka", txtMarka.Text);
                command.Parameters.AddWithValue("@model", txtModel.Text);
                command.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                command.Parameters.AddWithValue("@verildigiTarih", dtpVerildigiTarih.Value);
                command.Parameters.AddWithValue("@personelId", personelId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    int yeniUrunId = (int)command.LastInsertedId; // Yeni eklenen ürünün ID'sini al
                    MessageBox.Show("Ürün başarıyla eklendi. ID: " + yeniUrunId);

                    // KasaBilgi formunu aç ve yeni eklenen ürünün ID'sini geç
                    KasaBilgi kasaBilgi = new KasaBilgi(yeniUrunId);
                    kasaBilgi.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ürün eklenemedi.");
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
        }
    }
 }
