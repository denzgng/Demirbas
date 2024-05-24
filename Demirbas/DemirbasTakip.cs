using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Demirbas
{
    public partial class DemirbasTakip : Form
    {
        private MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=demirbas;User=root");
        private string currentUserEmail;



        public DemirbasTakip(string eposta)
        {
            InitializeComponent();
            currentUserEmail = eposta;
            FillUserData(currentUserEmail);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void FillUserData(string eposta)
        {
            try
            {
                baglanti.Open();
                string query = "SELECT * FROM personel WHERE eposta = @eposta";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@eposta", eposta);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    txtAd.Text = row["ad"].ToString();
                    txtSoyad.Text = row["soyad"].ToString();
                    txtSicilNo.Text = row["sicil_no"].ToString();
                    txtUnvan.Text = row["unvan"].ToString();
                    txtBolum.Text = row["bolum"].ToString();
                    txtEposta.Text = row["eposta"].ToString();
                    txtOdaNumarasi.Text = row["oda_numarasi"].ToString();

                    // Tarih alanı null kontrolü
                    if (row["baslama_tarihi"] != DBNull.Value && DateTime.TryParse(row["baslama_tarihi"].ToString(), out DateTime baslamaTarihi))
                    {
                        txtBaslamaTarihi.Text = baslamaTarihi.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtBaslamaTarihi.Text = string.Empty;
                    }

                    rtxtNotlar.Text = row["notlar"].ToString();
                }
                else
                {
                    MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
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


        private void DemirbasTakip_Load(object sender, EventArgs e)
        {


        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(filePath);

                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    try
                    {
                        baglanti.Open();
                        string query = "UPDATE personel SET resim = @resim WHERE eposta = @eposta";
                        MySqlCommand command = new MySqlCommand(query, baglanti);
                        command.Parameters.AddWithValue("@resim", base64String);
                        command.Parameters.AddWithValue("@eposta", currentUserEmail);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                    finally
                    {
                        baglanti.Close();
                    }
                }
            }

        }

        private void donanımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentUserEmail = txtEposta.Text;
            int personelId = GetPersonelIdFromDatabase(currentUserEmail);

            if (personelId != -1)
            {
                Donanım donanim = new Donanım(personelId, this); // Referansı geçin
                donanim.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
            }
        }

        private int GetPersonelIdFromDatabase(string eposta)
        {
            int personelId = -1;
            try
            {
                baglanti.Open();
                string query = "SELECT id FROM personel WHERE eposta = @eposta";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@eposta", eposta);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    personelId = Convert.ToInt32(result);
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

            return personelId;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            UpdateUserData();
        }

        private void UpdateUserData()
        {
            try
            {
                baglanti.Open();
                string query = "UPDATE personel SET ad = @ad, soyad = @soyad, sicil_no = @sicilNo, unvan = @unvan, bolum = @bolum, oda_numarasi = @odaNumarasi, baslama_tarihi = @baslamaTarihi, notlar = @notlar WHERE eposta = @eposta";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@ad", txtAd.Text);
                command.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                command.Parameters.AddWithValue("@sicilNo", txtSicilNo.Text);
                command.Parameters.AddWithValue("@unvan", txtUnvan.Text);
                command.Parameters.AddWithValue("@bolum", txtBolum.Text);
                command.Parameters.AddWithValue("@odaNumarasi", txtOdaNumarasi.Text);

                if (DateTime.TryParse(txtBaslamaTarihi.Text, out DateTime baslamaTarihi))
                {
                    command.Parameters.AddWithValue("@baslamaTarihi", baslamaTarihi);
                }
                else
                {
                    command.Parameters.AddWithValue("@baslamaTarihi", DBNull.Value);
                }

                command.Parameters.AddWithValue("@notlar", rtxtNotlar.Text);
                command.Parameters.AddWithValue("@eposta", currentUserEmail);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kullanıcı bilgileri güncellendi.");
                }
                else
                {
                    MessageBox.Show("Kullanıcı bilgileri güncellenemedi.");
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
