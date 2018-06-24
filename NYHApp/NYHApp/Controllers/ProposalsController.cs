using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NYHApp.Data;
using NYHApp.Models;

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

        // GET: Proposals/Details/5
        public async Task<IActionResult> Details(long? id)
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

            return View(proposal);
        }

        // GET: Proposals/Create
        public IActionResult Create(long id)
        {
            Help help = _context.Helps.SingleOrDefault(z => z.IdHelp == id);
            ApplicationUser ActualUser = _context.Users.Include(z=>z.Enterprise).Where(z => z.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (help != null && ActualUser != null && ActualUser.Enterprise != null)
            {
                Proposal model = new Proposal()
                {
                    IdHelp = id,
                    Help = help,
                    IdEnterprise = ActualUser.IdEnterprise ?? 0
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
        public async Task<IActionResult> Create(Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proposal);
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

            return View(proposal);
        }

        // POST: Proposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var proposal = await _context.Proposals.SingleOrDefaultAsync(m => m.IdProposal == id);
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProposalExists(long id)
        {
            return _context.Proposals.Any(e => e.IdProposal == id);
        }
    }
}
