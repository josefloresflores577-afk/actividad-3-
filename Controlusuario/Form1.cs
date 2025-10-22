using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlusuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnacceso_Click(object sender, EventArgs e)
        {
            String usuario, contrasena;

            usuario = txtUsuario.Text;
            contrasena = txtContrasena.Text;

            if (usuario == "admin" && contrasena == "1234")
            {
               Bienvenida bienvenida = new Bienvenida();
                bienvenida.Show();
                this.Hide();
            }
           

        }
        
        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                e.Cancel = true;
                txtUsuario.Focus();
                errorProvider1.SetError(txtUsuario, "Ingrese su usuario");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsuario, "");
            }
        }

        private void txtContrasena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                e.Cancel = true;
                txtContrasena.Focus();
                errorProvider2.SetError(txtContrasena, "Ingrese su contraseña");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtContrasena, "");
            }
        }
    } 
}

