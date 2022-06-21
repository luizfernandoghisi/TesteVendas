using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TesteVendas.Models;
using TesteVendas.Persistencia;

namespace TesteVendas.Controllers
{
    public class ClienteController : Controller
    {
        private VendasContext _context;

        public ClienteController(VendasContext context)
        {
            _context = context;
        }
        public IActionResult Index(string nomeBusca)
        {
            List<Cliente> clientes = _context.Clientes.Where(c => c.NmCliente.Contains(nomeBusca) || nomeBusca == null).ToList();
            return View(clientes);
        }
        [HttpGet]
        public IActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            TempData["msg"] = "Cliente Inserido com Sucesso!";
            return RedirectToAction("Inserir");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            TempData["msg"] = "Cliente editado com sucesso";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            TempData["msgRemove"] = "Cliente Excluído!";
            return RedirectToAction("Index");
        }
    }
}
