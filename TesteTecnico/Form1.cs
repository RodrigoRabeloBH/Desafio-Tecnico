using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createdForm = new CreateProductForm();
            createdForm.Show();
        }

        private void listarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listForm = new ListProductsForm();
            listForm.Show();
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            searchForm.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var updateForm = new UpdateProductForm();
            updateForm.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var removeForm = new RemoveProductForm();
            removeForm.Show();
        }
    }
}
