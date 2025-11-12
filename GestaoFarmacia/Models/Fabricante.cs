using System;

namespace GestaoFarmacia.Models
{
    public class Fabricante
    {
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        
        public string ObterCnpjNomeFantasia()
        {
            return $"{CNPJ} - {NomeFantasia}";
        }
    }
}