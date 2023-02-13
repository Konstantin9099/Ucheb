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
    public partial class ChangeOrders : Form
    {
        public int ID = 0;
        public ChangeOrders(int id_user)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
        }

        private void ChangeOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Функция, позволяющая отправить команду на сервер БД для оптимизации кода.
        public void Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // изменяем запись
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода/вывода данных.
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show(
                    "Внесите необходимые изменения.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Изменить заказ?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string zakaz = textBox2.Text;
                    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    int id = Convert.ToInt32(ChangeOrder.Order);
                    if (zakaz == "")
                    {
                        string query = "UPDATE delivery SET del_date='" + date + "', del_list='" + textBox1.Text + "' WHERE  del_id='" + ChangeOrder.Order + "'; ";
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
                        MessageBox.Show("Заказ изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string query = "UPDATE delivery SET del_date='" + date + "', del_list='" + textBox1.Text + "', del_comm='" + textBox2.Text + "' WHERE  del_id='" + ChangeOrder.Order + "'; ";
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
                        MessageBox.Show("Заказ изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // возврат на форму заказов
        private void button2_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery(ID); // Переход назад
            delivery.Owner = this;
            this.Hide();
            delivery.Show();
        }

        private void ChangeOrders_Load(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                string query = "select del_date, del_list, del_comm from delivery where del_id='" + ChangeOrder.Order + "'; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //dateTimePicker1.Text = cmDB.CommandText[0].ToString();
                    dateTimePicker1.Text = reader["del_date"].ToString();
                    textBox1.Text = reader["del_list"].ToString();
                    textBox2.Text = reader["del_comm"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
