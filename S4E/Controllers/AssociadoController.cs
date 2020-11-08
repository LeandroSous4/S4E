using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S4E.Models;

namespace S4E.Controllers
{
    public class AssociadoController : Controller
    {
        public IActionResult Associados()
        {
            AssociadoModel associado = new AssociadoModel();
            ViewBag.ListaAssociado = associado.ListaAssociado();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarAssociado(AssociadoModel associado)
        {
            if (ModelState.IsValid)
            {
                associado.RegistrarAssociado();
                return RedirectToAction("Associados");
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegistrarAssociado()
        {
            return View();
        }
        public IActionResult Sucesso()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirAssociado(int id)
        {
            AssociadoModel empresa = new AssociadoModel();
            empresa.ExcluirAssociado(id);
            return RedirectToAction("Associados");
        }
        [HttpGet]
        public IActionResult EditarAssociado(int id)
        {
            EmpresaModel empresa = new EmpresaModel();
            ViewBag.Empresa = empresa.ListaAssociadoEmpresa(id);
            AssociadoModel associado = new AssociadoModel();
            ViewBag.Associado = associado.CarregarAssociado(id);
            return View();
        }
    }
}