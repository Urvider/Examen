using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btInventario_Click(object sender, EventArgs e)
        {
            frmInventario ob = new frmInventario();
            ob.Show();
            this.Hide();
        }
    }
}
