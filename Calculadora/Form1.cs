using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Variables para almacenar los valores y operaciones
        private double valorActual = 0;
        private double valorAnterior = 0;
        private string operacionActual = "";
        private bool operacionPendiente = false;
        private bool nuevoNumero = true;

        // Método auxiliar para agregar números
        private void AgregarNumero(string numero)
        {
            if (nuevoNumero || txtPantalla.Text == "0")
            {
                txtPantalla.Text = numero;
                nuevoNumero = false;
            }
            else
            {
                txtPantalla.Text += numero;
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            AgregarNumero("0");
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            AgregarNumero("1");
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            AgregarNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            AgregarNumero("3");
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            AgregarNumero("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AgregarNumero("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            AgregarNumero("6");
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            AgregarNumero("7");
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            AgregarNumero("8");
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            AgregarNumero("9");
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (nuevoNumero)
            {
                txtPantalla.Text = "0.";
                nuevoNumero = false;
            }
            else if (!txtPantalla.Text.Contains("."))
            {
                txtPantalla.Text += ".";
            }

        }
        // Método auxiliar para establecer operación
        private void EstablecerOperacion(string operacion)
        {
            if (operacionPendiente)
            {
                RealizarOperacion();
            }

            valorAnterior = double.Parse(txtPantalla.Text);
            operacionActual = operacion;
            operacionPendiente = true;
            nuevoNumero = true;
        }
        // Método que realiza las operaciones
        private void RealizarOperacion()
        {
            try
            {
                valorActual = double.Parse(txtPantalla.Text);
                double resultado = 0;

                switch (operacionActual)
                {
                    case "+":
                        resultado = valorAnterior + valorActual;
                        break;
                    case "-":
                        resultado = valorAnterior - valorActual;
                        break;
                    case "X":
                    case "×":
                        resultado = valorAnterior * valorActual;
                        break;
                    case "÷":
                    case "/":
                        if (valorActual == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnCE_Click(null, null);
                            return;
                        }
                        resultado = valorAnterior / valorActual;
                        break;
                }

                txtPantalla.Text = resultado.ToString();
                valorAnterior = resultado;
                nuevoNumero = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCE_Click(null, null);
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtPantalla.Text = "0";
            valorActual = 0;
            valorAnterior = 0;
            operacionActual = "";
            operacionPendiente = false;
            nuevoNumero = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtPantalla.Text = "0";
            nuevoNumero = true;
        }

        private void btnNega_Posi_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text.Length > 0)
            {
                // Eliminar el último carácter
                txtPantalla.Text = txtPantalla.Text.Substring(0, txtPantalla.Text.Length - 1);

                // Si queda vacío, poner 0
                if (txtPantalla.Text == "" || txtPantalla.Text == "-")
                {
                    txtPantalla.Text = "0";
                    nuevoNumero = true;
                }
            }

        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            nuevoNumero = false;

            double numero = Convert.ToDouble(txtPantalla.Text);

            if (numero < 0)
            {
                MessageBox.Show("No se puede calcular raíz de número negativo");
                txtPantalla.Text = "0";
                nuevoNumero = true;
                return;
            }

            double resultado = Math.Sqrt(numero);
            txtPantalla.Text = resultado.ToString();




        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            EstablecerOperacion("+");
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            EstablecerOperacion("-");
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            EstablecerOperacion("X");
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            EstablecerOperacion("÷");

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacionPendiente)
            {
                RealizarOperacion();
                operacionPendiente = false;
                operacionActual = "";
            }

        }

        private void btnElevar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPantalla.Text))
                {
                    txtPantalla.Text = "0";
                    return;
                }

                double valor = Convert.ToDouble(txtPantalla.Text);
                // Elevar al cuadrado: multiplicar el número por sí mismo
                double resultado = valor * valor;
                txtPantalla.Text = resultado.ToString("G");
                nuevoNumero = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el cuadrado: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPantalla.Text = "0";
                nuevoNumero = true;
            }


        }
    }


}
