using GestaoFarmacia.Models; //vou precisar dos models aqui para poder manipular as informações
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoFarmacia.Controllers
{
    public class MedicamentoController
    {
        //o controller ira literalmente controlar as ações da view
        //preciso validar dados e retornar mensagem de erro ou sucesso
        public string AdicionarMedicamento(
            string codigoBarras, string descricao, string precoStr,
            string categoria, string indicacao, bool controlado,
            string cnpj, string nomeFantasia, string razaoSocial)
        {
        //validar campos vazios
            if (string.IsNullOrWhiteSpace(codigoBarras) ||
                string.IsNullOrWhiteSpace(descricao) ||
                string.IsNullOrWhiteSpace(precoStr) ||
                string.IsNullOrWhiteSpace(categoria) ||
                string.IsNullOrWhiteSpace(cnpj) ||
                string.IsNullOrWhiteSpace(nomeFantasia))
            {
                return "Todos os campos são obrigatórios! (exceto indicação e razão social).";      //retornar desta forma uma mensagem de erro tb é valido
            }

            //validar o valor inserido no campo txtPreco
            //vou deixar como double para preços com casas
            double preco;
            //tentar converter o valor digitado para double
            try
            {
                preco = Convert.ToDouble(precoStr);
            }
            catch (Exception ex)
            {
                return "Preço inválido. Digite apenas números (ex: 10,50)." + ex.Message;
            }

            //criar objetos para mandar como parâmetro
            Fabricante novoFabricante = new Fabricante
            {
                CNPJ = cnpj,
                NomeFantasia = nomeFantasia,
                RazaoSocial = razaoSocial
            };

            Medicamento novoMedicamento = new Medicamento
            {
                CodigoBarras = codigoBarras,
                Descricao = descricao,
                Preco = preco,
                Categoria = categoria,
                Indicacao = indicacao,
                Controlado = controlado,
                FabricanteInfo = novoFabricante
            };

            //chamar a classe de execução para adicionar o medicamento na listbox apos validar
            MedicamentoExecucao.Adicionar(novoMedicamento);

            //retornar sucesso
            return null;
        }

        //metodo para remover o medicamento da lista
        public void RemoverMedicamento(Medicamento med)
        {
            if (med == null) return;

            //passsar a classe de execução para remover
            MedicamentoExecucao.Remover(med);
        }

        //lista para mostrar os medicamentos na listbox p o usuario selecionar depois
        public List<Medicamento> ListarMedicamentos()
        {
            //passar a chamada 
            return MedicamentoExecucao.Listar();
        }
    }
}