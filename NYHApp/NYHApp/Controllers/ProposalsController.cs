using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NYHApp.Data;
using NYHApp.Models;
using NYHApp.ViewModels.ProposalsViewModels;

namespace NYHApp.Controllers
{
    public class ProposalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProposalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proposals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proposals.Include(p => p.Enterprise).Include(p => p.Help).Include(p => p.UserLastModified);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposals
                .Include(p => p.Enterprise)
                .Include(p => p.Help).ThenInclude(z => z.HelpsTypesJobs).ThenInclude(z => z.TypeJob).ThenInclude(z => z.Job)
                .Include(p => p.Help).ThenInclude(z => z.TypeRoad)
                .Include(p => p.Help).ThenInclude(z => z.Photos)
                .Include(z => z.LinesProposals)
                .Include(p => p.UserLastModified)
                .SingleOrDefaultAsync(m => m.IdProposal == id);
            if (proposal == null)
            {
                return NotFound();
            }

            ProposalHelpViewModel model = new ProposalHelpViewModel()
            {
                Proposal = proposal,
                HelpsTypesJobElectricity = proposal.Help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Electricidad").ToList(),
                HelpsTypesJobPainting = proposal.Help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Pintura").ToList(),
                HelpsTypesJobPlumbing = proposal.Help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Fontaneria").ToList(),
                HelpsTypesJobMansonry = proposal.Help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Albañileria").ToList(),
            };

            return View(model);
        }

        // GET: Proposals/Create
        public IActionResult Create(long id)
        {
            Help help = _context.Helps.Include(z => z.Photos).Include(z => z.HelpsTypesJobs).ThenInclude(z => z.TypeJob).ThenInclude(z => z.Job).SingleOrDefault(z => z.IdHelp == id);
            ApplicationUser ActualUser = _context.Users.Include(z => z.Enterprise).Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (help != null && ActualUser != null && ActualUser.Enterprise != null)
            {
                Proposal proposal = new Proposal()
                {
                    IdHelp = id,
                    Help = help,
                    IdEnterprise = ActualUser.IdEnterprise ?? 0
                };
                ProposalHelpViewModel model = new ProposalHelpViewModel()
                {
                    Proposal = proposal,
                    HelpsTypesJobElectricity = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Electricidad").ToList(),
                    HelpsTypesJobPainting = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Pintura").ToList(),
                    HelpsTypesJobPlumbing = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Fontaneria").ToList(),
                    HelpsTypesJobMansonry = help.HelpsTypesJobs.Where(z => z.TypeJob.Job.Name == "Albañileria").ToList(),
                };
                return View(model);
            }
            return NotFound();
        }

        // POST: Proposals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProposalHelpViewModel model)
        {
            ApplicationUser UsuarioActual = _context.Users.Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (UsuarioActual != null)
            {
                if (model.Proposal.Description != null && model.Proposal.Description.Length > 0)
                {
                    Help help = _context.Helps.Find(model.Proposal.IdHelp);
                    model.Proposal.Help = help;
                    if (model.Proposal.LinesProposals != null && model.Proposal.LinesProposals.Count() > 0)
                    {
                        model.Proposal.Total = model.Proposal.LinesProposals.Sum(z => z.Price);
                    }
                    else
                    {
                        model.Proposal.Total = 0;
                    }
                    _context.Add(model.Proposal);
                    await _context.SaveChangesAsync();
                    return Redirect("/Helps/Index");
                }
                ModelState.AddModelError("Proposal.Description", "Introduce un Descripción");
                return View(model);
            }
            return RedirectToAction("/Home/Index");
        }

        // GET: Proposals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposals.SingleOrDefaultAsync(m => m.IdProposal == id);
            if (proposal == null)
            {
                return NotFound();
            }
            ViewData["IdEnterprise"] = new SelectList(_context.Enterprises, "IdEnterprise", "Address", proposal.IdEnterprise);
            ViewData["IdHelp"] = new SelectList(_context.Helps, "IdHelp", "Address", proposal.IdHelp);
            ViewData["IdUserLastModified"] = new SelectList(_context.Users, "Id", "Id", proposal.IdUserLastModified);
            return View(proposal);
        }

        // POST: Proposals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdProposal,Description,Total,IdHelp,IdEnterprise,DateLastModified,IdUserLastModified")] Proposal proposal)
        {
            if (id != proposal.IdProposal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProposalExists(proposal.IdProposal))
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
            ViewData["IdEnterprise"] = new SelectList(_context.Enterprises, "IdEnterprise", "Address", proposal.IdEnterprise);
            ViewData["IdHelp"] = new SelectList(_context.Helps, "IdHelp", "Address", proposal.IdHelp);
            ViewData["IdUserLastModified"] = new SelectList(_context.Users, "Id", "Id", proposal.IdUserLastModified);
            return View(proposal);
        }

        // GET: Proposals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposals
                .Include(p => p.Enterprise)
                .Include(p => p.Help)
                .Include(p => p.UserLastModified)
                .SingleOrDefaultAsync(m => m.IdProposal == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return PartialView(proposal);
        }

        // POST: Proposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Proposal model)
        {
            var proposal = await _context.Proposals.SingleOrDefaultAsync(m => m.IdProposal == model.IdProposal);
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
            return Redirect("/Helps/Index");
        }

        private bool ProposalExists(long id)
        {
            return _context.Proposals.Any(e => e.IdProposal == id);
        }
    }
}
