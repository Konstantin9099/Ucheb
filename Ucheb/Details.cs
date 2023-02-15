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
    public partial class Details : Form
    {
        public int ID = 0;
        public Details(int id_user)
        {
            InitializeComponent();
            ID = id_user;
        }



        private void Details_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delivery del = new Delivery(ID);
            del.Owner = this;
            this.Hide();
            del.Show();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ChangeOrder.Detali);
            //string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                string query = "select del_id,  del_date, user_name, user_adress, cour_name, status_name from delivery, users, courier, statuses where users.user_id=delivery.del_recive and courier.cour_id=delivery.del_courier and statuses.status_id=delivery.del_status and delivery.del_id=" + id + "; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //dateTimePicker1.Text = cmDB.CommandText[0].ToString();
                    dateTimePicker1.Text = reader["del_date"].ToString();
                    textBox1.Text = reader["user_name"].ToString();
                    textBox2.Text = reader["user_adress"].ToString();
                    textBox3.Text = reader["cour_name"].ToString();
                    textBox4.Text = reader["status_name"].ToString();
                    textBox5.Text = reader["del_id"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
