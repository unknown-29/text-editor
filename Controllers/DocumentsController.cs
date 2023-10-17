using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using text_editor.Data;
using text_editor.Models;

namespace text_editor.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Document.Include(d => d.UserFile);
            var ufo = _context.UserFiles.Where(file => file.user_id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))).Select(record => record.Id).ToList();
            var ufs = _context.UserFiles.Where(file => file.user_id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier))).Select(record => record.sharedId).ToList();
            var uf = ufo.Concat(ufs);
            return View(new {Shared = await applicationDbContext.Where(doc => ufs.Contains(doc.FileId)).ToListAsync(), Owned= await applicationDbContext.Where(doc => ufo.Contains(doc.FileId)).ToListAsync() });
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.UserFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["FileId"] = new SelectList(_context.UserFiles, "Id", "Id");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,FileId")] Document document)
        {
            //if (ModelState.IsValid)
            //{
            UserFiles userFiles = new UserFiles();
            userFiles.name = document.Title;
            userFiles.user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(userFiles);
            await _context.SaveChangesAsync();
            document.FileId = _context.UserFiles.Where(uf => uf.name.Equals(document.Title) && uf.user_id.Equals(userFiles.user_id)).First().Id;
            _context.Add(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["FileId"] = new SelectList(_context.UserFiles, "Id", "Id", document.FileId);
            //return View(document);
        }
        // GET: Documents/Share/5
        public async Task<IActionResult> Share(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }
            var document = await _context.Document.FindAsync(id);
            return View (document);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Share(int id)
        {
            String email = Request.Form["Email"].ToString();
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }
            if (_context.Users.Where(user => user.Email.Equals(email)).Count() != 0)
            {
                var user=_context.Users.Where(user => user.Email.Equals(email)).First();
                UserFiles uf=new UserFiles();
                uf.user_id = user.Id;
                var d = _context.Document.Where(doc=>doc.Id.Equals(id)).First();
                uf.sharedId = d.FileId;
                uf.name = d.Title;
                _context.Add(uf);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["FileId"] = new SelectList(_context.UserFiles, "Id", "Id", document.FileId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,FileId")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            //ViewData["FileId"] = new SelectList(_context.UserFiles, "Id", "Id", document.FileId);
            //return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.UserFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Document == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Document'  is null.");
            }
            var document = await _context.Document.FindAsync(id);
            if (document != null)
            {
                var userFile=_context.UserFiles.Where(uf => uf.Id.Equals(document.FileId)).First();
                _context.UserFiles.Remove(userFile);
                _context.Document.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
          return (_context.Document?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
/*
 
 @model IEnumerable<text_editor.Models.Document>

@{
    ViewData["Title"] = "Index";
}

<h1>Index</h1>

<p>
    <a asp-action="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Title)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Content)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.UserFile)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Title)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Content)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.UserFile.Id)
            </td>
            <td>
                <a asp-action="Edit" asp-route-id="@item.Id">Edit</a> |
                    <a asp-action="Share" asp-route-id="@item.Id">Share</a> |
                <a asp-action="Details" asp-route-id="@item.Id">Details</a> |
                <a asp-action="Delete" asp-route-id="@item.Id">Delete</a>
            </td>
        </tr>
}
    </tbody>
</table>

 */