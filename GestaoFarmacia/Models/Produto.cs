using System;

namespace GestaoFarmacia.Models
{
    public abstract class Produto
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ObterCodigoDescricao()
        {
            return $"{CodigoBarras} - {Descricao}";
        }
    }
}