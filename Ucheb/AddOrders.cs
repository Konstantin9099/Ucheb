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
    public partial class AddOrders : Form
    {
        public int ID = 0;
        public AddOrders(int id_user)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
        }

        void Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!");
            }
        }

        // добавить
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show(
                    "Введите заказ.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Добавить данные о заказе?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string zakaz = textBox2.Text;
                        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        if (zakaz == "")
                        {
                            string query = "INSERT INTO delivery (del_date,  del_recive, del_list, del_status) VALUES ('" + date + "', '" + ID + "', '" + textBox1.Text + "', " + 4 + "); ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            textBox1.Clear();
                            textBox2.Clear();
                            MessageBox.Show("Заказ добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            string query = "INSERT INTO delivery (del_date, del_recive, del_list, del_comm, del_status) VALUES ('" + date + "', '" + ID + "', '" + textBox1.Text + "', '" + textBox2.Text + "', " + 4 + "); ";
                            MySqlConnection conn = DBUtils.GetDBConnection();
                            MySqlCommand cmDB = new MySqlCommand(query, conn);
                            try
                            {
                                conn.Open();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                            }
                            Action(query);
                            textBox1.Clear();
                            textBox2.Clear();
                            MessageBox.Show("Заказ добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }

        // назад
        private void button2_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery(ID); // Переход назад
            delivery.Owner = this;
            this.Hide();
            delivery.Show();
        }

        private void AddOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
