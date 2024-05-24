using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Demirbas
{
    public partial class Form1 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=demirbas;user=root");

        public Form1()
        {
            InitializeComponent();
            txtSifre.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eposta = txtEposta.Text;
            string sifre = txtSifre.Text;

            if (AuthenticateUser(eposta, sifre))
            {
                DemirbasTakip demirbas = new DemirbasTakip(eposta);
                demirbas.Show();
                this.Hide();
            }
            else
            {
                lblHata.Text = "Eposta veya Şifre hatalı";
            }
        }

            private bool AuthenticateUser(string eposta, string sifre)
            {

            bool isAuthenticated = false;
            try
            {
                baglanti.Open();
                string query = "SELECT COUNT(*) FROM personel WHERE eposta = @eposta AND sifre = @sifre";
                MySqlCommand command = new MySqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@eposta", eposta);
                command.Parameters.AddWithValue("@sifre", sifre);

                int userCount = Convert.ToInt32(command.ExecuteScalar());
                if (userCount > 0)
                {
                    isAuthenticated = true;
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

            return isAuthenticated;

            }
        }
    }
