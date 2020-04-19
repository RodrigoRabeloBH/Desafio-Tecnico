using Data;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class ListProductsForm : Form
    {
        private readonly ProductRepository _rep = new ProductRepository();
        public ListProductsForm()
        {
            InitializeComponent();
        }

        private void ListProductsForm_Load(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            dataGridView1.DataSource = _rep.GetAll();
        }
    }
}
