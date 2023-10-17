using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using text_editor.Data;
using text_editor.Models;

namespace text_editor.Controllers
{
    public class SharedDocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharedDocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserFiles
        public async Task<IActionResult> Index()
        {
            return _context.UserFiles != null ?
                          View(await _context.UserFiles.Where(uf=>uf.sharedId!=0).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserFiles'  is null.");
        }
    }
}
