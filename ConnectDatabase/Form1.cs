using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ConnectDatabase
{
    public partial class Form1 : Form
    {


        // Button btn

        string strcon = "Data Source=127.0.0;Initial Catalog=dbname;User ID=Your User;PWD=Your Password;";
        SqlConnection cn;


        public Form1()
        {
            InitializeComponent();


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(strcon);

            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
                string txt = "SELECT * FROM TABLE";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter(txt, cn);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
            }

            for (int i = 1; i <= 10; i++)
            {
                Button btn = new Button();
                btn.Text = "ปุ่มที่ " + i;
                btn.Width = 50;
                btn.Height = 50;

                btn.Click += new EventHandler(btnclick);
                flowLayoutPanel1.Controls.Add(btn);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnclick(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            MessageBox.Show(btn.Text, "Info Button");
        }


    }
}
