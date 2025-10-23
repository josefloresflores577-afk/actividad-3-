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
    public partial class Contacto : Form
    {
        public Contacto()
        {
            InitializeComponent();
        }

        private void btnSalircontac_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
