﻿/*
 * ITSE 1430
 *
 * Section 2
 */
using System;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //PlayingWithProductMembers();
        }

        private void PlayingWithProductMembers ()
        {
            var product = new Product();

            Decimal.TryParse("123", out decimal price);
            product.Price = price;

            var name = product.Name;
            //var name = product.GetName();
            product.Name = "Product A";
            product.Price = 50;
            product.IsDiscontinued = true;

            //product.ActualPrice = 10;
            var price2 = product.ActualPrice;

            //product.SetName("Product A");
            //product.Description = "None";
            var error = product.Validate();

            var str = product.ToString();

            var productB = new Product();
            //productB.Name = "Product B";
            //productB.SetName("Product B");
            //productB.Description = product.Description;
            error = productB.Validate();
        }

        private void fileToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void OnProductAdd( object sender, EventArgs e )
        { 
            var form = new ProductDetailForm("Add Product");

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //"Add" the product
            _product = form.Product;
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            if (_product == null)
            { 
                MessageBox.Show(this, "There is no product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var form = new ProductDetailForm(_product);

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //"Editing" the product
            _product = form.Product;
        }

        private void OnProductRemove( object sender, EventArgs e )
        {
            if (!ShowConfirmation("Are you sure?", "Remove Product"))
                return;

            _product = null;
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented.", "Help About", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool ShowConfirmation (string message, string title)
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes;
        }

        private Product _product;
    }
}
