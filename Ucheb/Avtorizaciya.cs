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

namespace Ucheb
{
    public partial class Avtorizaciya : Form
    {
        public Avtorizaciya()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        // вход
        private void button1_Click(object sender, EventArgs e)
        {
            // Запрос к таблице Delivery.
            string query = "SELECT user_id FROM users WHERE user_log ='" + textBox1.Text + "' and  user_pwd = '" + textBox2.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            // Объект для выполнения SQL-запроса.
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                // Устанавливаем соединение с БД.
                conn.Open();
                int id_user = 0;
                id_user = Convert.ToInt32(cmDB.ExecuteScalar());
                if (id_user > 1)
                {
                    Delivery delivery = new Delivery(id_user); // Обращение к форме "Delivery", на которую будет совершаться переход.
                    delivery.Owner = this;
                    this.Hide();
                    delivery.Show(); // Запуск окна "Delivery".
                    textBox1.Clear(); // Очистка поля - логин.
                    textBox2.Clear(); // Очистка поля - пароль.
                }
                else if (id_user == 1)
                {
                    Courier courier = new Courier(id_user); // Обращение к форме курьеров.
                    courier.Owner = this;
                    this.Hide();
                    courier.Show(); // Запуск окна курьеров.
                    textBox1.Clear(); // Очистка поля - логин.
                    textBox2.Clear(); // Очистка поля - пароль.
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        // выход
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // переход на форму регистрации
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registraciya reg = new Registraciya(); // Обращение к форме "Registraciya", на которую будет совершаться переход.
            reg.Owner = this;
            this.Hide();
            reg.Show(); // Запуск окна "Registraciya".
        }

        private void Avtorizaciya_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
