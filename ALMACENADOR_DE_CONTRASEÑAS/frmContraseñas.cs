using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    public partial class frmContraseñas : Form
    {

        clsContraseña oCon = new clsContraseña();
        clsAcceso oAcc = new clsAcceso();

        public frmContraseñas()
        {
            InitializeComponent();
            llenarComboCategoria();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCategorias frmCat = new frmCategorias();
            AddOwnedForm(frmCat);
            frmCat.ShowDialog();
        }

        private void llenarComboCategoria()
        {
            DataTable dt = new DataTable();
            dt = oCon.LlenarCategoria();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idcategoria";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmCon = new frmConfiguracion();
            AddOwnedForm(frmCon);
            DataTable dt = new DataTable();
            dt = oAcc.MostrarDatos(txtusu.Text);
            frmCon.txtnom.Text = dt.Rows[0][0].ToString();
            frmCon.txtusu.Text = dt.Rows[0][1].ToString();
            frmCon.txtcon.Text = dt.Rows[0][2].ToString();
            frmCon.ShowDialog();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals("") || txtdescripcion.Text.Equals("") || txtusuario.Text.Equals(""))
            {
                MessageBox.Show("Rellenar los datos para poder agregar una contraseña","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                oCon.AgregarContraseña(txtdescripcion.Text,txtusuario.Text,txtcontraseña.Text,Convert.ToInt32(comboBox1.SelectedValue),txtusu.Text);
                dataGridView1.DataSource = oCon.LlenarContraseñas(txtusu.Text);
                txtdescripcion.Clear();
                txtcontraseña.Clear();
                txtusuario.Clear();
                MessageBox.Show("Contraseña añadida correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtdescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtusuario.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtcontraseña.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                llenarComboCategoria();
            }
            catch (Exception)
            {

            }
        }

        private void brneditar_Click(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals("") || txtdescripcion.Text.Equals("") || txtusuario.Text.Equals(""))
            {
                MessageBox.Show("Dar doble click a la contraseña que desea eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                oCon.EliminarContraseña(txtid.Text);
                dataGridView1.DataSource = oCon.LlenarContraseñas(txtusu.Text);
                txtdescripcion.Clear();
                txtcontraseña.Clear();
                txtusuario.Clear();
                txtid.Clear();
                MessageBox.Show("Contraseña eliminada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtcontraseña.Text.Equals("") || txtdescripcion.Text.Equals("") || txtusuario.Text.Equals(""))
            {
                MessageBox.Show("Dar doble click a la contraseña que desea editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                oCon.EditarContraseña(Convert.ToInt32(txtid.Text), txtdescripcion.Text, txtusuario.Text, txtcontraseña.Text, Convert.ToInt32(comboBox1.SelectedValue));
                dataGridView1.DataSource = oCon.LlenarContraseñas(txtusu.Text);
                txtdescripcion.Clear();
                txtcontraseña.Clear();
                txtusuario.Clear();
                txtid.Clear();
                MessageBox.Show("Contraseña editada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                dataGridView1.DataSource = oCon.Check(); ;
            }
            else
            {
                dataGridView1.DataSource = oCon.LlenarContraseñas(txtusu.Text);
            }
        }
    }
}
