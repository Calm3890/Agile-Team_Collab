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
            if (Convert.ToInt32(txtTax.Text) > 100)
            {
                MessageBox.Show("Tax tidak bisa melebihi 100", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Nama tidak boleh kosong", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Harga tidak boleh kosong", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtKode.Text.Trim() == "")
            {
                MessageBox.Show("Code tidak boleh kosong", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(txtQuantity.Text) == 0)
            {
                MessageBox.Show("Jumlah barang tidak boleh 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string kode = txtKode.Text;
                string nama = txtNama.Text;
                int jumlah = Int32.Parse(txtQuantity.Text);
                double harga = Double.Parse(txtPrice.Text);
                double tax = Double.Parse(txtTax.Text);
                double taxValue = tax / 100;
                double subTotal = ((jumlah * harga) * taxValue);
                double bsc = 0;

                this.dgv.Rows.Add(new string[] { kode, nama, jumlah.ToString("n0"), harga.ToString("n0"), tax.ToString("n0"), subTotal.ToString("n0") });

                foreach (DataGridViewRow row in this.dgv.Rows)
                {
                    bsc += Convert.ToDouble(row.Cells[5].Value);
                }
                lblBSC.Text = bsc.ToString();
                lblSC.Text = (bsc * 0.1).ToString();
                lblTTL.Text = (bsc + (bsc * 0.1)).ToString();

                txtKode.Clear();
                txtNama.Clear();
                txtQuantity.Text = "0";
                txtPrice.Clear();
                txtTax.Clear();
            }
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

        private void txtKode_Leave(object sender, EventArgs e)
        {
            try
            {
                string kode = txtKode.Text;
                Barang itemBarang = dao.SearchItemBarang(kode);
                if (itemBarang != null)
                {
                    this.txtKode.Text = itemBarang.Code;
                    this.txtNama.Text = itemBarang.Name;
                    this.txtPrice.Text = itemBarang.Price.ToString("n0");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow != null && this.dgv.CurrentRow.IsNewRow == false)
            {
                int rowIndex = this.dgv.CurrentRow.Index;
                this.dgv.Rows.RemoveAt(rowIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            FormEdit edit = new FormEdit();
            this.Hide();
            edit.ShowDialog();
            this.Show();
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
    }
}
