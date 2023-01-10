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
    public partial class frmAcceso : Form
    {
        public frmAcceso()
        {
            InitializeComponent();
        }

        clsAcceso oAcc = new clsAcceso();
        clsContraseña oCon = new clsContraseña();

        private void button1_Click(object sender, EventArgs e)
        {
            if (oAcc.verificarUsuario(txtuser.Text,txtpassword.Text) == true)
            {
                MessageBox.Show("Bienvenido al sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmContraseñas frmPass = new frmContraseñas();
                frmPass.Show();
                DataTable dt = new DataTable();
                dt = oAcc.MostrarDatos(txtuser.Text);
                frmPass.txtnom.Text = dt.Rows[0][0].ToString();
                frmPass.txtusu.Text = dt.Rows[0][1].ToString();
                frmPass.txtcon.Text = dt.Rows[0][2].ToString();
                frmPass.dataGridView1.DataSource = oCon.LlenarContraseñas(frmPass.txtusu.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contraseña y/o clave incorrecta, en caso de no tener cuenta registrese.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtpassword.Clear();
            txtuser.Clear();
            txtuser.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRegistro frmReg = new frmRegistro();
            this.Hide();
            frmReg.ShowDialog();
            
        }
    }
}
