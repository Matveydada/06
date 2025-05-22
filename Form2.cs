using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06
{
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Нужно ввести все данные");
                return;
            }

            int id = 0;
            string titl = "", page = "";


            bool b = int.TryParse(textBox1.Text, out id);

            

            if (b == false)
            {

                MessageBox.Show("Неверный формат ID" + textBox1);
                return;

            }

            string author = textBox2.Text.Trim();
            string title = textBox3.Text.Trim();
            

            Books books = new Books();

            books.ID = id;
            books.Avtor = textBox2.Text;
            books.Title = textBox3.Text;
            books.Page= textBox4.Text;


            db.Books.Add(books);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.Message);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
