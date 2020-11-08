using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S4E.Models;

namespace S4E.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Empresas()
        {
            EmpresaModel empresa = new EmpresaModel();
            ViewBag.ListaEmpresa = empresa.ListaEmpresa();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEmpresa(EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.RegistrarEmpresa();
                return RedirectToAction("Empresas");
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegistrarEmpresa()
        {
            return View();
        }
        public IActionResult Sucesso()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirEmpresa(int id)
        {
            EmpresaModel empresa = new EmpresaModel();
            empresa.ExcluirEmpresa(id);
            return RedirectToAction("Empresas");
        }
        [HttpGet]
        public IActionResult EditarEmpresa(int id)
        {
            AssociadoModel associado = new AssociadoModel();
            ViewBag.ListaAssociado = associado.ListaAssociadoEmpresa(id);
            EmpresaModel empresa = new EmpresaModel();
            ViewBag.Empresa = empresa.CarregarEmpresa(id);
            return View();
        }
    }
}