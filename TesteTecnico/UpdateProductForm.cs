using Data;
using Domain;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class UpdateProductForm : Form
    {
        private readonly ProductRepository _rep = new ProductRepository();
        public UpdateProductForm()
        {
            InitializeComponent();
        }

        private void UpdateProductForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateProdut(int id)
        {
            var product = _rep.GetById(id);

            product.Name = textName.Text;
            product.Description = textDescription.Text;
            product.Price = double.Parse(textPrice.Text);
            product.Quantity = double.Parse(textQuantity.Text);

            _rep.Update(id, product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textDescription.Text == "" || textName.Text == "" || textQuantity.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("Preencha todos os campos corretamente!");
            }
            else
            {
                UpdateProdut(int.Parse(textBox1.Text));

                MessageBox.Show("Produto atualizado!");

                ClearField();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Esse campo é obrigatório!!");
                ClearField();
            }
            else
            {
                int eh_numero = 0;

                if (!(int.TryParse(textBox1.Text.ToString(), out eh_numero)))
                {
                    MessageBox.Show("Favor Digitar um Nº Id: apenas números são aceitos", "ERRO", MessageBoxButtons.OK);
                    ClearField();
                }
                else
                {
                    product = _rep.GetById(int.Parse(textBox1.Text));
                }

            }

            if (product == null)
            {
                MessageBox.Show($"Produto de ID: {int.Parse(textBox1.Text)} não encontrado");

                ClearField();
            }
            else
            {
                textName.Text = product.Name;
                textDescription.Text = product.Description;
                textPrice.Text = product.Price.ToString();
                textQuantity.Text = product.Quantity.ToString();
            }
        }

        private void ClearField()
        {
            textDescription.Text = "";
            textName.Text = "";
            textPrice.Text = "";
            textQuantity.Text = "";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearField();
        }
    }
}
