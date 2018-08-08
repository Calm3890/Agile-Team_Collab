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
    public partial class FrmEditDataBarang : Form
    {
        bool _result = false;
        string _code = string.Empty;

        public FrmEditDataBarang(string Code)
        {
            InitializeComponent();
            _code = Code;
        }

        public bool Run(FrmEditDataBarang form)
        {
            form.ShowDialog();
            return _result;
        }

        private void FrmEditDataBarang_Load(object sender, EventArgs e)
        {
            Add add = new AddDAO().GetDataAddByKode(_code);
            if (add != null)
            {
                txtBoxCode.Text = add.Code;
                txtBoxName.Text = add.Name;
                txtBoxPrice.Text = add.Price.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {           
                if (this.txtBoxCode.Text.Trim() == "")
                {
                    MessageBox.Show("Sorry, the code must be filled", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBoxCode.Focus();
                }
                else if (this.txtBoxName.Text.Trim() == "")
                {
                    MessageBox.Show("Sorry, the name must be filled", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBoxName.Focus();
                }
                else if (this.txtBoxPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Sorry, the price must be filled", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBoxPrice.Focus();
                }
                else
                {
                    try
                    {
                        Add add = new Add
                        {
                            Code = this.txtBoxCode.Text.Trim(),
                            Name = this.txtBoxName.Text.Trim(),
                            Price = Int32.Parse(txtBoxPrice.Text)
                        };
                        _result = new AddDAO().Update(add) > 0;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
