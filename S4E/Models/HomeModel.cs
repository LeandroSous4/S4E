using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using S4E.Util;

namespace S4E.Models
{
    public class HomeModel
    {
        public string LerNomeEmpresa()
        {
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable("select * from Empresa");

            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["NomeEmpresa"].ToString();
                }
            }
            return "Nome não encontrado";
        }
    }
}
