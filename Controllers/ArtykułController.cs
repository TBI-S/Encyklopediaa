using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encyklopediaa.Data;
using Encyklopediaa.Models.Objects;
using Humanizer;

namespace Encyklopediaa.Controllers
{
    public class ArtykułController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtykułController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artykuł
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Artykuł.Include(a => a.Admin).Include(a => a.Multimedia).Include(a => a.Rodzina).Include(a => a.Użytkownik);
            var applicationDbContext = _context.Artykul.Include(a => a.Admin).Include(a => a.Rodzina).Include(a => a.Użytkownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artykuł/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artykuł = await _context.Artykul
                //.Include(a => a.Admin)
                //.Include(a => a.Multimedia)
                .Include(a => a.Rodzina.Name)
                .Include(a => a.Użytkownik.Name)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artykuł == null)
            {
                return NotFound();
            }

            return View(artykuł);
        }

        // GET: Artykuł/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Email");
            //ViewData["MultimediaId"] = new SelectList(_context.Multimedia, "Id", "Description");
            ViewData["RodzinaID"] = new SelectList(_context.Rodzina, "Id", "Description");
            ViewData["UżytkownikId"] = new SelectList(_context.Użytkownik, "Id", "Email");
            return View();
        }

        // POST: Artykuł/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DataPublication,UżytkownikId,RodzinaID,AdminId,MultimediaId")] Artykul artykuł, FileStream stream)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artykuł);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Admin"] = new SelectList(_context.Admin, "Id", "Email", artykuł.AdminId);
            //ViewData["Multimedia"] = new SelectList(_context.Multimedia, "Id", "Description", artykuł.Multimedia);
            ViewData["Rodzina"] = new SelectList(_context.Rodzina, "Id", "Description", artykuł.Rodzina);
            ViewData["Użytkownik"] = new SelectList(_context.Użytkownik, "Id", "Email", artykuł.Użytkownik);
            if (artykuł.URL != null)
            {
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var uniqueFileName = $"{timestamp}_{artykuł.Obraz}";
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                using (var filestream = new FileStream(imagePath, FileMode.Create))
                {
                    artykuł.Obraz.CopyTo(stream);
                }

                artykuł.URL = $"/images/{uniqueFileName}";
            }
            return View(artykuł);
        }

        // GET: Artykuł/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artykuł = await _context.Artykul.FindAsync(id);
            if (artykuł == null)
            {
                return NotFound();
            }
            ViewData["Admin"] = new SelectList(_context.Admin, "Id", "Email", artykuł.AdminId);
            //ViewData["MultimediaId"] = new SelectList(_context.Multimedia, "Id", "Description", artykuł.MultimediaId);
            ViewData["RodzinaID"] = new SelectList(_context.Rodzina, "Id", "Description", artykuł.RodzinaID);
            ViewData["UżytkownikId"] = new SelectList(_context.Użytkownik, "Id", "Email", artykuł.UżytkownikId);
            return View(artykuł);
        }

        // POST: Artykuł/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DataPublication,UżytkownikId,RodzinaID,AdminId,MultimediaId")] Artykul artykuł)
        {
            if (id != artykuł.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artykuł);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtykułExists(artykuł.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Email", artykuł.AdminId);
            //ViewData["MultimediaId"] = new SelectList(_context.Multimedia, "Id", "Description", artykuł.MultimediaId);
            ViewData["RodzinaID"] = new SelectList(_context.Rodzina, "Id", "Description", artykuł.RodzinaID);
            ViewData["UżytkownikId"] = new SelectList(_context.Użytkownik, "Id", "Email", artykuł.UżytkownikId);
            return View(artykuł);
        }

        // GET: Artykuł/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artykuł = await _context.Artykul
                .Include(a => a.Admin)
                //.Include(a => a.Multimedia)
                .Include(a => a.Rodzina)
                .Include(a => a.Użytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artykuł == null)
            {
                return NotFound();
            }

            return View(artykuł);
        }

        // POST: Artykuł/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artykuł = await _context.Artykul.FindAsync(id);
            if (artykuł != null)
            {
                _context.Artykul.Remove(artykuł);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtykułExists(int id)
        {
            return _context.Artykul.Any(e => e.Id == id);
        }
    }
}
