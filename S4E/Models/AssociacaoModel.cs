using S4E.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S4E.Models
{
    public class AssociacaoModel
    {
        public int idAssociado { get; set; }
        public int idEmpresa { get; set; }


        public void SalvarRelacao(int idAss, int idEmp)
        {
            new DAL().ExecutarSQL("Insert into Associacao([Empresa_idEmpresa],[Associado_idAssociado]) values ("+ idEmp +","+idAss+")");
        }

        public void ExcluirAssociacao(int idAss, int idEmp)
        {
            new DAL().ExecutarSQL("DELETE FROM Associacao WHERE Associado_idAssociado = " + idAss + " and Empresa_idEmpresa = " + idEmp);
        }
    }
}
