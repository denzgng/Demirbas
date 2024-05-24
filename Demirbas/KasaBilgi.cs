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
    public partial class KasaBilgi : Form
    {

        private MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=demirbas;User=root");
        private int donanimId;


        public KasaBilgi(int donanimId)
        {
            InitializeComponent();
            this.donanimId = donanimId;
            txtId.Text = donanimId.ToString(); // Id'yi txtId'ye yazdır
            txtId.ReadOnly = true; // ID'yi sadece okuma modunda yap
            LoadKasaData(donanimId);
        }

        private bool KasaKaydiVarMi(int donanimId)
        {
            bool kayitVar = false;
            try
            {
                baglanti.Open();
                string query = "SELECT COUNT(*) FROM kasa WHERE id = @donanimId";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@donanimId", donanimId);
                object result = command.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) > 0)
                {
                    kayitVar = true;
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
            return kayitVar;
        }

        private void LoadKasaData(int donanimId)
        {
            try
            {
                baglanti.Open();
                string query = "SELECT * FROM kasa WHERE id = @donanimId";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@donanimId", donanimId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtDemirbasNo.Text = reader["demirbas_no"].ToString();
                        txtIsletimSistemi.Text = reader["isletim_sistemi"].ToString();
                        txtIslemciModel.Text = reader["islemci_model"].ToString();
                        txtRam.Text = reader["ram"].ToString();
                        txtKapasite.Text = reader["disk_kapasite"].ToString();
                        txtEkranKarti.Text = reader["ekran_karti"].ToString();
                        txtModel.Text = reader["model"].ToString();
                        txtIslemciHizi.Text = reader["islemci_hizi"].ToString();
                        txtCekirdekSayisi.Text = reader["cekirdek_sayisi"].ToString();
                        txtEkranBoyut.Text = reader["ekran_boyut"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Kasa bilgileri bulunamadı.");
                    }
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

        private void KasaBilgi_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (KasaKaydiVarMi(donanimId))
            {
                UpdateKasaData();
            }
            else
            {
                InsertKasaData();
            }
        }

        private void UpdateKasaData()
        {
            try
            {
                baglanti.Open();
                string query = "UPDATE kasa SET demirbas_no = @demirbasNo, isletim_sistemi = @isletimSistemi, islemci_model = @islemciModel, ram = @ram, disk_kapasite = @kapasite, ekran_karti = @ekranKarti, model = @model, islemci_hizi = @islemciHizi, cekirdek_sayisi = @cekirdekSayisi, ekran_boyut = @ekranBoyut WHERE id = @donanimId";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@demirbasNo", txtDemirbasNo.Text);
                command.Parameters.AddWithValue("@isletimSistemi", txtIsletimSistemi.Text);
                command.Parameters.AddWithValue("@islemciModel", txtIslemciModel.Text);
                command.Parameters.AddWithValue("@ram", txtRam.Text);
                command.Parameters.AddWithValue("@kapasite", txtKapasite.Text);
                command.Parameters.AddWithValue("@ekranKarti", txtEkranKarti.Text);
                command.Parameters.AddWithValue("@model", txtModel.Text);
                command.Parameters.AddWithValue("@islemciHizi", txtIslemciHizi.Text);
                command.Parameters.AddWithValue("@cekirdekSayisi", txtCekirdekSayisi.Text);
                command.Parameters.AddWithValue("@ekranBoyut", txtEkranBoyut.Text);
                command.Parameters.AddWithValue("@donanimId", donanimId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kasa bilgileri güncellendi.");
                }
                else
                {
                    MessageBox.Show("Kasa bilgileri güncellenemedi.");
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

        private void InsertKasaData()
        {
            try
            {
                baglanti.Open();
                string query = "INSERT INTO kasa (demirbas_no, isletim_sistemi, islemci_model, ram, disk_kapasite, ekran_karti, model, islemci_hizi, cekirdek_sayisi, ekran_boyut) VALUES (@demirbasNo, @isletimSistemi, @islemciModel, @ram, @kapasite, @ekranKarti, @model, @islemciHizi, @cekirdekSayisi, @ekranBoyut)";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@demirbasNo", txtDemirbasNo.Text);
                command.Parameters.AddWithValue("@isletimSistemi", txtIsletimSistemi.Text);
                command.Parameters.AddWithValue("@islemciModel", txtIslemciModel.Text);
                command.Parameters.AddWithValue("@ram", txtRam.Text);
                command.Parameters.AddWithValue("@kapasite", txtKapasite.Text);
                command.Parameters.AddWithValue("@ekranKarti", txtEkranKarti.Text);
                command.Parameters.AddWithValue("@model", txtModel.Text);
                command.Parameters.AddWithValue("@islemciHizi", txtIslemciHizi.Text);
                command.Parameters.AddWithValue("@cekirdekSayisi", txtCekirdekSayisi.Text);
                command.Parameters.AddWithValue("@ekranBoyut", txtEkranBoyut.Text);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kasa bilgileri başarıyla eklendi.");
                }
                else
                {
                    MessageBox.Show("Kasa bilgileri eklenemedi.");
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
