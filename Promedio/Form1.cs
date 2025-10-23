using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Promedioguia3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double notaGuia = 0;
        double notaControl = 0;
        double porcentajeGuia = 0;
        double porcentajeControl = 0;

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncontac_Click(object sender, EventArgs e)
        {
            Contacto contacto = new Contacto();
            contacto.Show();
            this.Hide();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar que se ingresó el nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor ingrese el nombre del alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y obtener nota del parcial
                if (!double.TryParse(txtParcial.Text, out double notaParcial) || notaParcial < 0 || notaParcial > 10)
                {
                    MessageBox.Show("Ingrese una nota válida para el parcial (0-10).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double notaGuia = 0;
                double notaControl = 0;
                double porcentajeGuia = 0;
                double porcentajeControl = 0;

                // Obtener porcentaje y nota de la guía
                string porcentajeGuiaStr = cboGuia.SelectedItem.ToString();
                if (porcentajeGuiaStr == "40%")
                {
                    porcentajeGuia = 0.40;
                    if (!double.TryParse(txtGuia.Text, out notaGuia) || notaGuia < 0 || notaGuia > 10)
                    {
                        MessageBox.Show("Ingrese una nota válida para la guía (0-10).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (porcentajeGuiaStr == "20%")
                {
                    porcentajeGuia = 0.20;
                }
                // Si es 0%, porcentajeGuia = 0 y notaGuia = 0

                // Obtener porcentaje y nota del control de lectura
                string porcentajeControlStr = cboControl.SelectedItem.ToString();
                if (porcentajeControlStr == "20%")
                {
                    porcentajeControl = 0.20;
                    if (!double.TryParse(txtControl.Text, out notaControl) || notaControl < 0 || notaControl > 10)
                    {
                        MessageBox.Show("Ingrese una nota válida para el control de lectura (0-10).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                // Si es 0%, porcentajeControl = 0 y notaControl = 0

                // Calcular el promedio
                double promedio = (notaParcial * 0.60) + (notaGuia * porcentajeGuia) + (notaControl * porcentajeControl);

                // Determinar si aprobó o reprobó
                string resultado = promedio >= 6.0 ? "APROBO" : "REPROBO";

                // Mostrar el resultado
                MessageBox.Show($"Alumno: {txtNombre.Text}\n\nPromedio: {promedio:F2}\n\nResultado: {resultado}",
                    "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
    
