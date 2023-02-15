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
    public partial class Courier : Form
    {
        public int ID = 0;
        public Courier(int id_user)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ID = id_user;
            Get_Info(id_user);
        }

        public void Get_Info(int ID)
        {
            string query = "select del_id as 'Код заказа', del_date as 'Дата заказа', user_name as 'ФИО заказчика', user_adress as 'Адрес доставки', del_list as 'Заказ', del_comm as 'Комментарий закзчика' from delivery LEFT JOIN users ON users.user_id=delivery.del_recive WHERE delivery.del_status=" + 4  + "; ";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                this.dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].Width = 70;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 100;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].Width = 220;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].Width = 240;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].Width = 200;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].Width = 300;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            string query1 = " select del_id as 'Код заказа', del_date as 'Дата заказа', user_name as 'ФИО заказчика', user_adress as 'Адрес доставки', del_list as 'Заказ', del_comm as 'Комментарий закзчика', cour_name as 'ФИО курьера', status_name as 'Статус заказа' from delivery, users, courier, statuses where users.user_id=delivery.del_recive and courier.cour_id=delivery.del_courier and statuses.status_id=delivery.del_status and delivery.del_status=" + 1 + "; ";
            MySqlConnection conn1 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn1);
            DataTable dt1 = new DataTable();
            try
            {
                conn1.Open();
                sda1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                dataGridView2.ClearSelection();
                this.dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[0].Width = 70;
                this.dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[1].Width = 90;
                this.dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[2].Width = 220;
                this.dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[3].Width = 240;
                this.dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[4].Width = 200;
                this.dataGridView2.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[5].Width = 300;
                this.dataGridView2.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[6].Width = 180;
                this.dataGridView2.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[7].Width = 80;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            string query2 = " select del_id as 'Код заказа', del_date as 'Дата заказа', user_name as 'ФИО заказчика', user_adress as 'Адрес доставки', del_list as 'Заказ', del_comm as 'Комментарий закзчика', cour_name as 'ФИО курьера', status_name as 'Статус заказа' from delivery, users, courier, statuses where users.user_id=delivery.del_recive and courier.cour_id=delivery.del_courier and statuses.status_id=delivery.del_status and delivery.del_status=" + 2 + "; ";
            MySqlConnection conn2 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dt2 = new DataTable();
            try
            {
                conn2.Open();
                sda2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                this.dataGridView3.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[0].Width = 70;
                this.dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[1].Width = 90;
                this.dataGridView3.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[2].Width = 220;
                this.dataGridView3.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[3].Width = 240;
                this.dataGridView3.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[4].Width = 200;
                this.dataGridView3.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[5].Width = 300;
                this.dataGridView3.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[6].Width = 180;
                this.dataGridView3.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[7].Width = 80;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
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

        private void Courier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            comboBox1.Items.Clear();
            string query = "SELECT courier.cour_name FROM courier ORDER BY cour_name;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["cour_name"].ToString());
            }
            reader.Close();
        }

        private void Courier_Load(object sender, EventArgs e)
        {
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.ClearSelection();

            try
            {
                string query = "SELECT cour_name FROM courier ORDER BY cour_name;";
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["cour_name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // запись курьера на доставку
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены все поля.
            if (textBox1.Text == null || textBox1.Text == "" || comboBox1.Text.Equals(""))
            {
                MessageBox.Show(
                    "Для выполнения доставки выберете заказ и курьера.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Выполнить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE delivery SET del_courier=(select courier.cour_id from courier where courier.cour_name='" + comboBox1.Text + "'), del_status= " + 1 + " WHERE  del_id=" + textBox1.Text + "; ";
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
                        Get_Info(ID);
                        textBox1.Clear();
                        MessageBox.Show("Заявка перешла из статуса Создано в статус В пути!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }

        // запись стутуса о выполнении заявки
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверка, что выбрана строка в таблице доставки.
            if (dataGridView2.SelectedRows.Count < 1)
            {
                MessageBox.Show("Не выбрана строка!");
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Завершить выполнение доставки?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        int id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()); // Определяем id.                                                                  // Проверяем, чтобы была выбрана строка в таблице доставки.
                        string query = "UPDATE delivery SET del_status= " + 2 + " WHERE  del_id=" + id + "; ";
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
                        Get_Info(ID);
                        MessageBox.Show("Заявка перешла из статуса В пути в статус Доставлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }
    }
}
