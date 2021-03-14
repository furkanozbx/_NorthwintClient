using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _NorthwintClient.NorthwindServiceReference;

namespace _NorthwintClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindDataServiceSoapClient client = new NorthwindDataServiceSoapClient();


        private void button1_Click(object sender, EventArgs e)
        {
            List();
        }

        private void List()
        {
            string key = client.Login("goksel", "1");
            dataGridView1.DataSource = client.List(key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Insert(new AuthHeader { Username = "admin", Password = "1" }, new Category
            {
                CategoryName = textBox1.Text,
                Description = textBox2.Text
            });
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Delete(Convert.ToInt32(textBox3.Text));
            List();
        }
    }
}
