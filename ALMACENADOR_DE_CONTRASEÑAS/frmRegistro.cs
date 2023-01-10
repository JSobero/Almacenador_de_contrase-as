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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        clsRegistro oReg = new clsRegistro();

        private void button2_Click(object sender, EventArgs e)
        {
            frmAcceso frmAcc = new frmAcceso();
            frmAcc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtcontrasena.PasswordChar == '*')
            {
                txtcontrasena.PasswordChar = '\0';
                button3.Text = "ocultar";
            }
            else
            {
                txtcontrasena.PasswordChar = '*';
                button3.Text = "mostrar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusuario.Text.Equals("") || txtnombre.Text.Equals("") || txtcontrasena.Text.Equals(""))
                {
                    MessageBox.Show("No se olvide rellenar la información para poder registrarse", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtnombre.Focus();
                }
                else
                {
                    oReg.RegistrarCliente(txtnombre.Text, txtusuario.Text, txtcontrasena.Text);
                    MessageBox.Show("Usuario registrado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAcceso frmAcc = new frmAcceso();
                    frmAcc.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario ya existe, registrese con otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
