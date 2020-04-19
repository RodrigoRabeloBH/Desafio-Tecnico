using Data;
using Domain;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class CreateProductForm : Form
    {
        private readonly ProductRepository _rep = new ProductRepository();
        public CreateProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textDescription.Text == "" || textName.Text == "" || textQuantity.Text == "" || textPrice.Text == "")
            {
                MessageBox.Show("Preencha todos os campos corretamente!");
            }
            else
            {
                InsertProdut();

                MessageBox.Show("Produto registrado com sucesso!!!");
            }
        }

        private void InsertProdut()
        {
            var product = new Product
            {
                Description = textDescription.Text,
                Name = textName.Text,
                Price = double.Parse(textPrice.Text),
                Quantity = double.Parse(textQuantity.Text)
            };
            _rep.Create(product);

            ClearField();
        }

        private void ClearField()
        {
            textDescription.Text = "";
            textName.Text = "";
            textPrice.Text = "";
            textQuantity.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void CreateProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
