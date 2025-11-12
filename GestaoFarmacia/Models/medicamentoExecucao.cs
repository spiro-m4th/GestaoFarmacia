using System;
using System.Collections.Generic;

namespace GestaoFarmacia.Models
{
    //vou criar esta classe para armazenar dados
    public static class MedicamentoExecucao
    {
        //lista estatica para ser usada em todo o app
        private static List<Medicamento> listaDeMedicamentos = new List<Medicamento>();

        //vou criar um metodo para adicionar a lista, recebendo o objeto como parametro - create
        public static void Adicionar(Medicamento med)
        {
            listaDeMedicamentos.Add(med);
        }

        //metodo para remover, recebendo objeto como parametro - delete
        public static void Remover(Medicamento med)
        {
            listaDeMedicamentos.Remove(med);
        }

        //metodo para lista e retornar a lista com todos os objetos como parametro - read
        public static List<Medicamento> Listar()
        {
            return listaDeMedicamentos;
        }
    }
}