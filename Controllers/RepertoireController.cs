using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHubCore.Domain;
using MovieHubCore.Models;
using System.Threading.Tasks;

namespace MovieHubCore.Controllers
{
    public class RepertoireController : Controller
    {
        private readonly CinemaDbContext _context;

        public RepertoireController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Repertoires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repertoires.ToListAsync());
        }

        // GET: Repertoires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (repertoire == null)
            {
                return NotFound();
            }

            return View(repertoire);
        }

        // GET: Repertoires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repertoires/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,Date,StartTime,Price")] Repertoire repertoire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repertoire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repertoire);
        }

        // GET: Repertoires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires.FindAsync(id);
            if (repertoire == null)
            {
                return NotFound();
            }
            return View(repertoire);
        }

        // POST: Repertoires/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionId,Date,StartTime,Price")] Repertoire repertoire)
        {
            if (id != repertoire.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repertoire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepertoireExists(repertoire.SessionId))
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
            return View(repertoire);
        }

        // GET: Repertoires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (repertoire == null)
            {
                return NotFound();
            }

            return View(repertoire);
        }

        // POST: Repertoires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repertoire = await _context.Repertoires.FindAsync(id);
            _context.Repertoires.Remove(repertoire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepertoireExists(int id)
        {
            return _context.Repertoires.Any(e => e.SessionId == id);
        }
    }
}
