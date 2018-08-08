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
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
            List<Add> listadd = new List<Add>();
            this.dgvData.AutoGenerateColumns = false;
        }

        Add _result = null;

        public Add Run(FormEdit form)
        {
            form.ShowDialog();
            return _result;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                FrmEditDataBarang form = new FrmEditDataBarang(this.dgvData.SelectedRows[0].Cells[0].Value.ToString().Trim());
                if (form.Run(form))
                {
                    QueryData(new Add { Code = "", Name = "", Price = 0 });
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0 && MessageBox.Show("Hapus Baris Data Terpilih ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (new AddDAO().Delete(this.dgvData.SelectedRows[0].Cells[0].Value.ToString().Trim()) > 0)
                    {
                        QueryData(new Add { Code = "", Name = "", Price = 0 });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            try
            {
                QueryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void QueryData(Add add = null)
        {
            try
            {
                this.dgvData.DataSource = null;
                List<Add> list = new AddDAO().QueryDataBarang(add);
                if (list != null)
                {
                    this.dgvData.DataSource = list;
                    this.dgvData.Columns[0].DataPropertyName = nameof(Add.Code);
                    this.dgvData.Columns[1].DataPropertyName = nameof(Add.Name);
                    this.dgvData.Columns[2].DataPropertyName = nameof(Add.Price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
