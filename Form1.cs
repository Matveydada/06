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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            booksBindingSource.DataSource = db.Books.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.db = db;

            DialogResult dr = form2.ShowDialog();

            if (dr == DialogResult.OK)
            {
                booksBindingSource.DataSource = db.Books.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            Books books = (Books)booksBindingSource.Current;
            frm.db = db;
            frm.books = books;

            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                booksBindingSource.DataSource = db.Books.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Books books = (Books)booksBindingSource.Current;

            DialogResult dr = MessageBox.Show("ВЫ дествительно хотите удалить роль - " +
               books.ID.ToString(), "Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                db.Books.Remove(books);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                booksBindingSource.DataSource = db.Books.ToList();
            }
        }
    }
}
