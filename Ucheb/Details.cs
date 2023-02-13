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
    }
}
