using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using S4E.Util;
using System.Data;

namespace S4E.Models
{
    public class EmpresaModel
    {
        public int idEmpresa { get; set; }
        [Required(ErrorMessage ="Informe o nome")]
        public string NomeEmpresa { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ")]
        public string CNPJ { get; set; }

        public List<EmpresaModel> ListaEmpresa()
        {
            List<EmpresaModel> lista = new List<EmpresaModel>();
            EmpresaModel item;

            string sql = $"SELECT idEmpresa, NomeEmpresa, CNPJ from Empresa";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new EmpresaModel();
                item.idEmpresa = int.Parse(dt.Rows[i]["idEmpresa"].ToString());
                item.NomeEmpresa = dt.Rows[i]["NomeEmpresa"].ToString();
                item.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public List<EmpresaModel> ListaAssociadoEmpresa(int id)
        {
            List<EmpresaModel> lista = new List<EmpresaModel>();
            EmpresaModel item;

            string sql = $"Select E.idEmpresa, E.NomeEmpresa, E.CNPJ, A.idAssociado, A.NomeAssociado, A.CPF, A.DataNascimento " +
                    "from Associacao m " +
                    "inner join Empresa E on " +
                    "E.idEmpresa = m.Empresa_idEmpresa " +
                    "inner join Associado A on " +
                    "A.idAssociado = m.Associado_idAssociado " +
                    $"where m.Associado_idAssociado = {id} ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new EmpresaModel();
                item.idEmpresa = int.Parse(dt.Rows[i]["idEmpresa"].ToString());
                item.NomeEmpresa = dt.Rows[i]["NomeEmpresa"].ToString();
                item.CNPJ = dt.Rows[i]["CNPJ"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public void RegistrarEmpresa()
        {
            string sql = "";

            if (idEmpresa == 0)
            {
                sql = $"INSERT INTO Empresa(NomeEmpresa,CNPJ) VALUES('{NomeEmpresa}','{CNPJ}')";
            }
            else
            {
                sql = $"UPDATE Empresa SET NomeEmpresa = '{NomeEmpresa}', CNPJ = '{CNPJ}' WHERE idEmpresa = '{idEmpresa}'";
            }

            DAL objDAL = new DAL();
            objDAL.ExecutarSQL(sql);


        }

        public void ExcluirEmpresa(int id)
        {
            new DAL().ExecutarSQL("DELETE FROM Empresa WHERE idEmpresa = " + id);
            new DAL().ExecutarSQL("DELETE FROM Associacao WHERE Empresa_idEmpresa = " + id);
        }

        public EmpresaModel CarregarEmpresa(int id)
        {
            EmpresaModel item = new EmpresaModel();

            string sql = $"SELECT idEmpresa, NomeEmpresa, CNPJ FROM Empresa WHERE idEmpresa = {id}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.idEmpresa= int.Parse(dt.Rows[0]["idEmpresa"].ToString());
            item.NomeEmpresa = dt.Rows[0]["NomeEmpresa"].ToString();
            item.CNPJ = dt.Rows[0]["CNPJ"].ToString();

            return item;
        }        
    }
}
