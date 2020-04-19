using Data;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class SearchForm : Form
    {
        private readonly ProductRepository _rep = new ProductRepository();
        public SearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {     

            SearchProductsByName(textBox1.Text);

            textBox1.Text = "";

        }
        private void SearchProductsByName(string name)
        {
            var products = _rep.GetByName(name);

            dataGridView1.DataSource = products;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
