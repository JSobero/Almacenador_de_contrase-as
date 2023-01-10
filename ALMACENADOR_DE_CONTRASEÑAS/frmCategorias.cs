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
    public partial class frmCategorias : Form
    {

        clsContraseña oCon = new clsContraseña();
        clsRegistro oReg = new clsRegistro();
        clsEditar oEdi = new clsEditar();

        public void llenarTabla()
        {
            dataGridView1.DataSource = oCon.RellenarDatos();
        }

        public frmCategorias()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtnombre.Text.Equals("") || txtdescripcion.Text.Equals(""))
            {
                MessageBox.Show("Rellenar datos para poder agregar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oReg.AgregarCategoria(txtnombre.Text,txtdescripcion.Text);
                oCon.RellenarDatos();
                llenarTabla();

                frmContraseñas frmCon = Owner as frmContraseñas;

                DataTable dt = new DataTable();
                dt = oCon.LlenarCategoria();
                frmCon.comboBox1.DataSource = dt;
                frmCon.comboBox1.DisplayMember = "nombre";
                frmCon.comboBox1.ValueMember = "idcategoria";

                txtdescripcion.Clear();
                txtnombre.Clear();
                MessageBox.Show("Categoría registrada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Equals("") || txtdescripcion.Text.Equals(""))
            {
                MessageBox.Show("Rellena la información para poder editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oEdi.EditarCategoria(txtnombre.Text, txtdescripcion.Text);
                MessageBox.Show("Actualizado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdescripcion.Clear();
                txtnombre.Clear();
                llenarTabla();
            }  
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtnombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
