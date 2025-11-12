using System;
using System.Windows.Forms;
using GestaoFarmacia.Models;

namespace GestaoFarmacia
{
    public partial class frmVisualizacao : Form
    {
        //variavel local para armazenar o objeto
        private Medicamento medicamento;

        public frmVisualizacao()
        {
            InitializeComponent();
        }

        //iniciar o form recebendo o medicamento como paramtro
        public frmVisualizacao(Medicamento med)
        {
            InitializeComponent();
            medicamento = med; //guardar o objeto na variavel
        }

        //rodar um evento (em load) quando o form for carregado
        private void frmVisualizacao_Load(object sender, EventArgs e)
        {
            //pegar os dados do objeto e joga na VIEW
            if (medicamento != null)
            {
                txtCodigoBarras.Text = medicamento.CodigoBarras;
                txtDescricao.Text = medicamento.Descricao;
                txtPreco.Text = medicamento.Preco.ToString("C2"); //C2 é formato de moeda
                txtCategoria.Text = medicamento.Categoria;
                txtIndicacao.Text = medicamento.Indicacao;
                chkControlado.Checked = medicamento.Controlado;

                //requisito do trabalho: apenas um text box para mostrar as infos do fabricante
                txtFabricanteInfo.Text = medicamento.FabricanteInfo.ObterCnpjNomeFantasia();
            }
        }
    }
}