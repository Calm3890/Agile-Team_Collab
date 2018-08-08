using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agile_Team_Collab
{
    public partial class Main : Form
    {
        AddDAO dao = new AddDAO();
        List<SellItem> listSell = new List<SellItem>();
        List<Add> listBarang = new List<Add>();
        public Main()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void btnTmbhQuantity_Click(object sender, EventArgs e)
        {
            int Jlh = Int32.Parse(this.txtQuantity.Text);
            Jlh = Jlh + 1;
            this.txtQuantity.Text = Jlh.ToString();
        }

        private void btnKrangQuantity_Click(object sender, EventArgs e)
        {
            int Jlh = Int32.Parse(this.txtQuantity.Text);
            if (Jlh > 0)
            {
                Jlh = Jlh - 1;
                this.txtQuantity.Text = Jlh.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgv.DataSource = listSell;
            string kode = txtKode.Text;
            string nama = txtNama.Text;
            int jumlah = Int32.Parse(txtQuantity.Text);
            double harga = Double.Parse(txtPrice.Text);
            double tax = 0;
            if (txtTax.Text.Trim() != "")
            {
                tax = Double.Parse(txtTax.Text);
            }
            double taxValue = tax / 100;
            double subTotal = ((jumlah * harga) * taxValue) + (jumlah * harga);
            double bsc = 0;

            if (jumlah > 0)
            {

                SellItem DelItem = listSell.Find(i => i.Code == kode);
                listSell.Remove(DelItem);

                listSell.Add(new SellItem
                {
                    Code = kode,
                    Nama = nama,
                    Quantity = jumlah,
                    Price = harga,
                    Tax = tax,
                    SubTotal = subTotal
                });
            }

            dgv.DataSource = null;
            dgv.DataSource = listSell;
            dgv.Columns[3].DefaultCellStyle.Format = "n0";
            dgv.Columns[5].DefaultCellStyle.Format = "n0";

            dgv.Columns[0].DataPropertyName = "Code";
            dgv.Columns[1].DataPropertyName = "Nama";
            dgv.Columns[2].DataPropertyName = "Quantity";
            dgv.Columns[3].DataPropertyName = "Price";
            dgv.Columns[4].DataPropertyName = "Tax";
            dgv.Columns[5].DataPropertyName = "SubTotal";

            foreach (var item in listSell)
            {
                bsc += item.SubTotal;
            }
            lblBSC.Text = bsc.ToString("n0");
            lblSC.Text = (bsc * 0.1).ToString("n0");
            lblTTL.Text = (bsc + (bsc * 0.1)).ToString("n0");

            txtKode.Clear();
            txtNama.Clear();
            txtQuantity.Text = "0";
            txtPrice.Clear();
            txtTax.Clear();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_tambah frm = new Form_tambah();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kode = txtKode.Text;
                listBarang = dao.GetCode();
                foreach (var item in listBarang)
                {
                    if (item.Code == kode)
                    {
                        txtNama.Text = item.Name;
                        txtPrice.Text = item.Price.ToString();
                    }
                }
                foreach (var item in listSell)
                {
                    if (item.Code == kode)
                    {
                        txtQuantity.Text = item.Quantity.ToString();
                        txtTax.Text = item.Tax.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgv.DataSource = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            int i = dgv.SelectedRows.Count -1;

            int i1 = dgv.CurrentCell.RowIndex;

=======
            int i = dgv.CurrentCell.RowIndex;
>>>>>>> 68f5dabae4451093fdeb0a8f8b42d8a10cfe8175
            listSell.RemoveAt(i);
            dgv.DataSource = listSell;
        }

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Number Validation
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Number Validation
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Number Validation
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

    }
}
