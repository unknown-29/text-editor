using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using text_editor.Data;
using text_editor.Models;

namespace text_editor.Controllers
{
    public class UserFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: UserFiles
        public async Task<IActionResult> Index()
        {
              return _context.UserFiles != null ? 
                          View(await _context.UserFiles.Where(file=>file.user_id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserFiles'  is null.");
        }

        [Authorize]
        // GET: UserFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserFiles == null)
            {
                return NotFound();
            }

            var userFiles = await _context.UserFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFiles == null)
            {
                return NotFound();
            }

            return View(userFiles);
        }

        [Authorize]
        // GET: UserFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: UserFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] UserFiles userFiles)
        {
            userFiles.user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(userFiles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        // GET: UserFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserFiles == null)
            {
                return NotFound();
            }

            var userFiles = await _context.UserFiles.FindAsync(id);
            if (userFiles == null)
            {
                return NotFound();
            }
            return View(userFiles);
        }

        [Authorize]
        // POST: UserFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,user_id")] UserFiles userFiles)
        {
            if (id != userFiles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFiles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFilesExists(userFiles.Id))
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
            return View(userFiles);
        }

        [Authorize]
        // GET: UserFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserFiles == null)
            {
                return NotFound();
            }

            var userFiles = await _context.UserFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFiles == null)
            {
                return NotFound();
            }

            return View(userFiles);
        }

        [Authorize]
        // POST: UserFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserFiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserFiles'  is null.");
            }
            var userFiles = await _context.UserFiles.FindAsync(id);
            if (userFiles != null)
            {
                _context.UserFiles.Remove(userFiles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        private bool UserFilesExists(int id)
        {
          return (_context.UserFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
