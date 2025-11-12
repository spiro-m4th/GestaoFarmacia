using System;

namespace GestaoFarmacia.Models
{
    public class Medicamento : Produto  //medicamento é um produto portanto esta classe herda de produto
    {
        public string Categoria { get; set; }
        public bool Controlado { get; set; }
        public string Indicacao { get; set; }

        public Fabricante FabricanteInfo { get; set; }

        //métodos obrigatorios:
        //retornar concatenação do Código de Barras, Descrição e Categoria
        public string ObterDadosPrincipais()
        {
            //CodigoBarras / Descricao herdam de produto
            return $"{CodigoBarras} - {Descricao} - {Categoria}";
        }

        //retorna concatenação do Código de Barras, Descrição, Categoria e Nome Fantasia
        //este é o formato exato pedido para a ListBox
        public string ObterDadosParaLista()
        {
            return $"{CodigoBarras} - {Descricao} - {Categoria} - {FabricanteInfo.NomeFantasia}";
        }

        //metodo para a ListBox
        //sobrescrever (override) o método ToString()
        //hora que a ListBox for exibir o objeto, ela ira usar este método
        public override string ToString()   //com override 'substituo' o comportamento do metodo original

        {
            return ObterDadosParaLista();
        }
    }
}