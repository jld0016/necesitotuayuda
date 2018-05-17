using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NYHApp.Data;
using NYHApp.Models;
using NYHApp.ViewModels;

namespace NYHApp.Controllers
{
    [Authorize]
    public class HelpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HelpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Helps
        public IActionResult Index()
        {
            ICollection<Help> model = _context.Helps.ToList(); 
            if (User.IsInRole("User"))
            {
                var ActualUser = UrlHelperExtensions.GetUserLogin(User.Identity.Name, _context);
                model = model.Where(z => z.UserHelp.Id == ActualUser.Id).ToList();
            }
            return View(model);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Helps.SingleOrDefaultAsync(m => m.IdHelp == id);
            if (help == null)
            {
                return NotFound();
            }

            return PartialView(help);
        }

        // GET: Helps/Create
        public IActionResult Create()
        {
            ApplicationUser UsuarioActual = _context.Users.Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            Help help = new Help()
            {
                Address = UsuarioActual.Address,
                City = UsuarioActual.City,
                CodeHelp = _context.Helps.Count().ToString(),
                Date = DateTime.Now,
                Door = UsuarioActual.Door,
                Floor = UsuarioActual.Floor,
                IdCountry = UsuarioActual.IdCountry,
                IdTypeRoad = UsuarioActual.IdTypeRoad,
                Number = UsuarioActual.Number,
                Phone1 = UsuarioActual.Phone1,
                Phone2 = UsuarioActual.Phone2,
                PostalCode = UsuarioActual.PostalCode,
                UnstructuredAddress = UsuarioActual.UnstructuredAddress,
                State = UsuarioActual.State,
                IdUser = UsuarioActual.Id,
            };
            HelpVM model = new HelpVM()
            {
                Help = help
            };
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name");
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name");
            return View(model);
        }

        // POST: Helps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HelpVM model)
        {
            ApplicationUser ActualUser = _context.Users.Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (model != null && model.Help != null && ActualUser != null)
            {
                model.Help.IdUser = ActualUser.Id;
                model.Help.IdUserLastModified = ActualUser.Id;
                model.Help.DateLastModified = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _context.Add(model.Help);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", model.Help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", model.Help.IdTypeRoad);
            return View(model);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".pdf", "application/pdf"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
            };
        }

        // GET: Helps/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Helps.SingleOrDefaultAsync(m => m.IdHelp == id);
            if (help == null)
            {
                return NotFound();
            }
            HelpVM model = new HelpVM()
            {
                Help = help
            };
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", help.IdTypeRoad);
            return View(model);
        }

        // POST: Helps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HelpVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model.Help);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpExists(model.Help.IdHelp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", model.Help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", model.Help.IdTypeRoad);
            return View(model);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Helps
                .Include(h => h.Country)
                .Include(h => h.TypeRoad)
                .Include(h => h.UserHelp)
                .Include(h => h.UserLastModified)
                .SingleOrDefaultAsync(m => m.IdHelp == id);
            if (help == null)
            {
                return NotFound();
            }

            return View(help);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var help = await _context.Helps.SingleOrDefaultAsync(m => m.IdHelp == id);
            _context.Helps.Remove(help);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpExists(long id)
        {
            return _context.Helps.Any(e => e.IdHelp == id);
        }
    }
}
