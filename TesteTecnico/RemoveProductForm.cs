using Data;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class RemoveProductForm : Form
    {
        private readonly ProductRepository _rep = new ProductRepository();
        public RemoveProductForm()
        {
            InitializeComponent();
        }

        private void RemoveProductForm_Load(object sender, EventArgs e)
        {

        }
        private void SearchProductsByName(string name)
        {
            var products = _rep.GetByName(name);

            dataGridView1.DataSource = products;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductsByName(textBox1.Text);

            textBox1.Text = "";
        }

        private void Remove()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Este campo é obrigatório!");
            }
            else
            {
                int eh_numero = 0;

                if (!(int.TryParse(textBox2.Text.ToString(), out eh_numero)))
                {
                    MessageBox.Show("Favor Digitar um Nº Id: apenas números são aceitos", "ERRO", MessageBoxButtons.OK);
                    ClearField();
                }
                else
                {
                    var product = _rep.GetById(int.Parse(textBox2.Text));

                    if (product == null)
                    {
                        MessageBox.Show($"Produto de ID: {int.Parse(textBox2.Text)} não encontrado");
                    }
                    else
                    {
                        _rep.Delete(int.Parse(textBox2.Text));

                        MessageBox.Show("Produto removido com sucesso!!");

                        ClearField();
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
            ClearField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void ClearField()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
