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
    public partial class Form_tambah : Form
    {
        List<Add> listBarang = null;

        bool _result = false;

        public bool Run(Form_tambah form)
        {
            form.ShowDialog();
            return _result;
        }

        public Form_tambah()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            listBarang = new List<Add>();
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Price";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (this.txtboxPrice.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, harga tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (this.txtboxCode.Text.Trim() == "" || this.txtboxName.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, data barang tidak boleh kosong ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtboxCode.Focus();
            }
            else
            {
                dataGridView1.DataSource = null;
                listBarang.Add( new Add
                {
                    Code = txtboxCode.Text,
                    Name = txtboxName.Text,
                    Price = Int32.Parse(txtboxPrice.Text)
                });

                dataGridView1.DataSource = listBarang;
                txtboxName.Clear();
                txtboxPrice.Clear();
                txtboxCode.Text = $"{(Int32.Parse(txtboxCode.Text) + 1).ToString("000")}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addDao = new AddDAO())
                {
                    addDao.Simpan(listBarang);
                }
                MessageBox.Show("Success", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form_tambah_Load(object sender, EventArgs e)
        {
            try
            {
                txtboxCode.Text = new AddDAO().GetKodeBarangBerikutnya();
                txtboxName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtboxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
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
