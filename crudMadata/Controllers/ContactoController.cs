using crudMadata.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using crudMadata.Models;

namespace crudMadata.Controllers
{
    public class ContactoController : Controller
    {
        private readonly AppDbContext _context;

        public ContactoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Contactos.ToListAsync();
            return View(clientes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactoModel contacto)
        {
            if (!ModelState.IsValid)
            {
                return View(contacto);
            }

            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactoModel contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(contacto);
            }

            _context.Update(contacto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}
