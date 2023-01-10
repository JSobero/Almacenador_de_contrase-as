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
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        clsEditar oEdi = new clsEditar();
        clsAcceso oAcc = new clsAcceso();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnom.Text.Equals("") || txtusu.Text.Equals("") || txtcon.Text.Equals(""))
                {
                    MessageBox.Show("Rellene los datos a cambiar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    oEdi.EditarUsuario(txtnom.Text, txtusu.Text, txtcon.Text);
                    frmContraseñas frmCon = Owner as frmContraseñas;
                    MessageBox.Show("Datos actualizados correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DataTable dt = new DataTable();
                    dt = oAcc.MostrarDatos(txtusu.Text);

                    frmCon.txtnom.Text = dt.Rows[0][0].ToString();
                    frmCon.txtusu.Text = dt.Rows[0][1].ToString();
                    frmCon.txtcon.Text = dt.Rows[0][2].ToString();

                    this.Hide();
                }       
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
