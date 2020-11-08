using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S4E.Models;

namespace S4E.Controllers
{
    public class AssociacaoController : Controller
    {
        public IActionResult CriarRelacao()
        {
            EmpresaModel empresa = new EmpresaModel();
            ViewBag.ListaEmpresa = empresa.ListaEmpresa();
            AssociadoModel associado = new AssociadoModel();
            ViewBag.ListaAssociado = associado.ListaAssociado();
            return View();
        }
        public IActionResult RegistrarAssociacao(AssociacaoModel associacao)
        {
            if (ModelState.IsValid)
            {
                associacao.SalvarRelacao(associacao.idAssociado,associacao.idEmpresa);
                return RedirectToAction("Sucesso");
            }            
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirAssociacao(int idAss, int idEmp)
        {
            AssociacaoModel associacao = new AssociacaoModel();
            associacao.ExcluirAssociacao(idAss, idEmp);
            return RedirectToAction("CriarRelacao");
        }
        public IActionResult Sucesso()
        {
            return View();
        }
    }
}