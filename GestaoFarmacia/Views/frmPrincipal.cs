using System;
using System.Windows.Forms;

namespace GestaoFarmacia
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void menuMedicamentos_Click(object sender, EventArgs e)
        {
            //chamar o form de cadastro de medicmentos
            frmMedicamentos telaCadastro = new frmMedicamentos();
            telaCadastro.ShowDialog();
        }
    }
}