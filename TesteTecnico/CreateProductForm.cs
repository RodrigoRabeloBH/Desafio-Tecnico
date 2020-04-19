using Data;
using Domain;
using System;
using System.Windows.Forms;

namespace TesteTecnico
{
    public partial class CreateProductForm : Form
    {
        private ProductRepository _rep = new ProductRepository();
        public CreateProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertProdut();
        }

        private void InsertProdut()
        {
            var product = new Product
            {
                Description = textDescription.Text,
                Name = textName.Text,
                Price = decimal.Parse(textPrice.Text),
                Quantity = decimal.Parse(textQuantity.Text),
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
    }
}
