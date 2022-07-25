using cms_net.Context;
using cms_net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace cms_net.Controllers
{
    public class PageController : Controller
    {
        private readonly CMSContext db;

        public PageController()
        {
            db = new CMSContext();
        }
        public IActionResult Index()
        {
           List<Page> pages = db.Pages.ToList();
            return View(pages);
        }
        public IActionResult Details(int id)
        {
            Page page = db.Pages.Where(p => p.Id == id).Include(p => p.Components).FirstOrDefault();
            return View(page);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Page page = db.Pages.Where(p => p.Id == id).Include(p => p.Components).FirstOrDefault();
            ViewData["pageId"] = page.Id;
            return View(page);
        }
    }
}