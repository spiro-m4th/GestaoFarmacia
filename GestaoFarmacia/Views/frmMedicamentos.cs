using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestaoFarmacia.Models;
using GestaoFarmacia.Controllers; 

namespace GestaoFarmacia
{
    public partial class frmMedicamentos : Form
    {
        //dediquei um controller para esta view
        private MedicamentoController controller;

        public frmMedicamentos()
        {
            InitializeComponent();
            //instanciar o controller no form
            controller = new MedicamentoController();
        }

        private void frmMedicamentos_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        //o evento de click ira coletar os dados da view e passar para o controller MedicamentoController.cs
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //obter dados
            string codBarras = txtCodigoBarras.Text;
            string desc = txtDescricao.Text;
            string preco = txtPreco.Text;
            string cat = txtCategoria.Text;
            string ind = txtIndicacao.Text;
            bool ctrl = chkControlado.Checked;
            string cnpj = txtCnpj.Text;
            string nomeFant = txtNomeFantasia.Text;
            string razaoSoc = txtRazaoSocial.Text;

            //chamar o controller para validar e adicionar os objetos a lista
            string resultado = controller.AdicionarMedicamento(
                codBarras, desc, preco, cat, ind, ctrl,
                cnpj, nomeFant, razaoSoc);

            //atualizar a view
            if (resultado != null)
            {
                MessageBox.Show(resultado, "Falha na Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se tudo validado e o resultado não for diferente de null, atualiza a lista
                AtualizarLista();
                LimparCampos();
            }
        }

        //com o evento de remover no click, ira ser o mesmo esquema: obter dados e passar para a lista atraves do controller
        private void btnRemover_Click(object sender, EventArgs e)
        {
            //obter a linha da lista que sera manipulada
            Medicamento medSelecionado = (Medicamento)lstMedicamentos.SelectedItem;

            if (medSelecionado == null)
            {
                MessageBox.Show("Selecione um item para remover.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirmar se o usuario deseja remover o item
            var resultado = MessageBox.Show($"Deseja remover: {medSelecionado.Descricao}?", "CONFIRMAÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //chamar o controller e passar o medicamento selecionado como parametro para remover da lista
                controller.RemoverMedicamento(medSelecionado);

                AtualizarLista();
            }
        }

        //como o botao visualizar segue apenas uma logica de view (ou seja, visualizar os componentes que foram digitados em outra tela)
        //nao é preciso passar pelo controller, afinal não haverá nenhuma manipulação, apenas exibição
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Medicamento medSelecionado = (Medicamento)lstMedicamentos.SelectedItem;

            if (medSelecionado == null)
            {
                MessageBox.Show("Selecione um item para visualizar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //chamar a tela de visu
            frmVisualizacao telaVis = new frmVisualizacao(medSelecionado);
            telaVis.ShowDialog();
        }

        //metodos que podem ser utilizados apenas nesta view
        private void AtualizarLista()
        {
            lstMedicamentos.Items.Clear(); //limpar o controller

            //pede a lista ao controller
            List<Medicamento> lista = controller.ListarMedicamentos();

            //preencher o controle
            foreach (Medicamento med in lista)
            {
                lstMedicamentos.Items.Add(med);
            }
        }

        private void LimparCampos()
        {
            txtCodigoBarras.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtCategoria.Clear();
            txtIndicacao.Clear();
            chkControlado.Checked = false;
            txtCnpj.Clear();
            txtNomeFantasia.Clear();
            txtRazaoSocial.Clear();
            txtCodigoBarras.Focus();
        }

    }
}