using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
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
        private readonly IHostingEnvironment _path;

        public HelpsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _path = hostingEnvironment;
        }

        // GET: Helps
        public IActionResult Index()
        {
            ICollection<Help> model = _context.Helps.Include(z => z.UserHelp).Include(z=>z.Photos).ToList();
            if (User.IsInRole("User") && model != null && model.Count > 0)
            {
                var ActualUser = UrlHelperExtensions.GetUserLogin(User.Identity.Name, _context);

                model = model.Where(z => z.UserHelp.Id == ActualUser.Id).ToList();
                return View(model);
            }
            if (model == null)
                return View(new List<Help>());
            return View(model);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Helps.Include(z=>z.Photos).SingleOrDefaultAsync(m => m.IdHelp == id);
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
            var typesJobs = _context.TypesJob.Include(z => z.Job);
            List<HelpTypeJob> ListHelpTypeJobs = new List<HelpTypeJob>();
            foreach (var item in typesJobs)
            {
                HelpTypeJob typeJob = new HelpTypeJob()
                {
                    IdTypeJob = item.IdTypeJob,
                    TypeJob = item,
                    Rating = 0
                };
                ListHelpTypeJobs.Add(typeJob);
            }
            HelpVM model = new HelpVM()
            {
                Help = help,
                HelpsTypesJobElectricity = ListHelpTypeJobs.Where(z => z.TypeJob.Job.Name == "Electricidad").ToList(),
                HelpsTypesJobPainting = ListHelpTypeJobs.Where(z => z.TypeJob.Job.Name == "Pintura").ToList(),
                HelpsTypesJobPlumbing = ListHelpTypeJobs.Where(z => z.TypeJob.Job.Name == "Fontaneria").ToList(),
                HelpsTypesJobMansonry = ListHelpTypeJobs.Where(z => z.TypeJob.Job.Name == "Albañileria").ToList(),
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
                model.Help.HelpsTypesJobs = new List<HelpTypeJob>();
                AddToCollection(model.HelpsTypesJobPainting, model.Help.HelpsTypesJobs);
                AddToCollection(model.HelpsTypesJobElectricity, model.Help.HelpsTypesJobs);
                AddToCollection(model.HelpsTypesJobPlumbing, model.Help.HelpsTypesJobs);
                AddToCollection(model.HelpsTypesJobMansonry, model.Help.HelpsTypesJobs);
                if (ModelState.IsValid)
                {
                    if (model.Help.Photos == null)
                        model.Help.Photos = new List<Photo>();
                    if (model.Photos != null && model.Photos.Count > 0)
                    {
                        updatePhotos(model, ActualUser);
                    }
                    _context.Add(model.Help);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", model.Help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", model.Help.IdTypeRoad);
            return View(model);
        }

        private void AddToCollection(IEnumerable<HelpTypeJob> collection, ICollection<HelpTypeJob> ListEnterpriseJob)
        {
            foreach (var item in collection)
            {
                ListEnterpriseJob.Add(item);
            }
        }


        private void updatePhotos(HelpVM model, ApplicationUser actualUser)
        {
            string path = Path.Combine(_path.WebRootPath, "Photos", actualUser.Id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var item in model.Photos)
            {
                string extension = Path.GetExtension(item.FileName);
                string fileName = item.FileName.Split('.')[0].Replace(" ", "") + "_" + DateTime.Now.Minute + extension;
                Photo photo = new Photo()
                {
                    DateLastModified = DateTime.Now,
                    FileName = fileName,
                    DateUpload = DateTime.Now,
                    IdUserLastModified = actualUser.Id,
                    Path = "/Photos/" + actualUser.Id + '/' +fileName
                };
                using (var stream = new FileStream(path + '/' +  fileName, FileMode.CreateNew,FileAccess.ReadWrite))
                {
                    item.CopyTo(stream);
                    model.Help.Photos.Add(photo);
                }
            }
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
            var help = await _context.Helps.Include(z=>z.Photos).Include(z=>z.HelpsTypesJobs).ThenInclude(z=>z.TypeJob).ThenInclude(z=>z.Job).SingleOrDefaultAsync(m => m.IdHelp == id);
            if (help == null)
            {
                return NotFound();
            }
            HelpVM model = new HelpVM()
            {
                Help = help,
                HelpsTypesJobElectricity = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Electricidad").ToList(),
                HelpsTypesJobPainting = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Pintura").ToList(),
                HelpsTypesJobPlumbing = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Fontaneria").ToList(),
                HelpsTypesJobMansonry = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Albañileria").ToList(),
            };
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", help.IdTypeRoad);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HelpVM model)
        {

            ApplicationUser ActualUser = _context.Users.Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (model != null && model.Help != null && ActualUser != null)
            {
                model.Help.IdUserLastModified = ActualUser.Id;
                model.Help.DateLastModified = DateTime.Now;

                UpdateCollection(model.HelpsTypesJobPainting);
                UpdateCollection(model.HelpsTypesJobElectricity);
                UpdateCollection(model.HelpsTypesJobMansonry);
                UpdateCollection(model.HelpsTypesJobPlumbing);

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
            }
            ViewData["Help.IdCountry"] = new SelectList(_context.Countries, "IdCountry", "Name", model.Help.IdCountry);
            ViewData["Help.IdTypeRoad"] = new SelectList(_context.TypesRoad, "IdTypeRoad", "Name", model.Help.IdTypeRoad);
            return View(model);
        }

        private void UpdateCollection(ICollection<HelpTypeJob> collection)
        {
            foreach (var item in collection)
            {
                _context.Update(item);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var help = await _context.Helps.SingleOrDefaultAsync(m => m.IdHelp == id);
            if (help == null)
            {
                return NotFound();
            }

            return PartialView(help);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Help model)
        {
            var help = await _context.Helps.SingleOrDefaultAsync(m => m.IdHelp == model.IdHelp);
            _context.Helps.Remove(help);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HelpExists(long id)
        {
            return _context.Helps.Any(e => e.IdHelp == id);
        }
    }
}
