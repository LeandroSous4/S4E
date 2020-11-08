using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using S4E.Util;
using System.Data;

namespace S4E.Models
{
    public class AssociadoModel
    {
        public int idAssociado { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        public string NomeAssociado { get; set; }
        [Required(ErrorMessage = "Informe o CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        public List<AssociadoModel> ListaAssociado()
        {
            List<AssociadoModel> lista = new List<AssociadoModel>();
            AssociadoModel item;

            string sql = $"SELECT idAssociado, NomeAssociado, CPF, DataNascimento from Associado";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new AssociadoModel();
                item.idAssociado = int.Parse(dt.Rows[i]["idAssociado"].ToString());
                item.NomeAssociado = dt.Rows[i]["NomeAssociado"].ToString();
                item.CPF = dt.Rows[i]["CPF"].ToString();
                item.DataNascimento = DateTime.Parse(dt.Rows[i]["DataNascimento"].ToString());
                lista.Add(item);
            }
            return lista;
        }

        public List<AssociadoModel> ListaAssociadoEmpresa(int id)
        {
            List<AssociadoModel> lista = new List<AssociadoModel>();
            AssociadoModel item;

            string sql = $"Select E.idEmpresa, E.NomeEmpresa, E.CNPJ, A.idAssociado, A.NomeAssociado, A.CPF, A.DataNascimento "+
                    "from Associacao m "+
                    "inner join Empresa E on "+
                    "E.idEmpresa = m.Empresa_idEmpresa "+
                    "inner join Associado A on "+
                    "A.idAssociado = m.Associado_idAssociado "+
                    $"where m.Empresa_idEmpresa = {id} ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new AssociadoModel();
                item.idAssociado = int.Parse(dt.Rows[i]["idAssociado"].ToString());
                item.NomeAssociado = dt.Rows[i]["NomeAssociado"].ToString();
                item.CPF = dt.Rows[i]["CPF"].ToString();
                item.DataNascimento = DateTime.Parse(dt.Rows[i]["DataNascimento"].ToString());
                lista.Add(item);
            }
            return lista;
        }

        public void RegistrarAssociado()
        {
            string sql = "";

            if (idAssociado == 0)
            {
                sql = $"INSERT INTO Associado(NomeAssociado,CPF,DataNascimento) VALUES('{NomeAssociado}','{CPF}','{DataNascimento}')";
            }
            else
            {
                sql = $"UPDATE Associado SET NomeAssociado = '{NomeAssociado}', CPF = '{CPF}', DataNascimento = '{DataNascimento}' WHERE idAssociado = '{idAssociado}'";
            }
            DAL objDAL = new DAL();
            objDAL.ExecutarSQL(sql);
        }

        public void ExcluirAssociado(int id)
        {
            new DAL().ExecutarSQL("DELETE FROM Associado WHERE idAssociado = " + id);
            new DAL().ExecutarSQL("DELETE FROM Associacao WHERE Associado_idAssociado = " + id);
        }

        public AssociadoModel CarregarAssociado(int id)
        {
            AssociadoModel item = new AssociadoModel();

            string sql = $"SELECT idAssociado, NomeAssociado, CPF, DataNascimento FROM Associado WHERE idAssociado = {id}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.idAssociado = int.Parse(dt.Rows[0]["idAssociado"].ToString());
            item.NomeAssociado = dt.Rows[0]["NomeAssociado"].ToString();
            item.CPF = dt.Rows[0]["CPF"].ToString();
            item.DataNascimento = DateTime.Parse(dt.Rows[0]["DataNascimento"].ToString());

            return item;
        }
    }
}
