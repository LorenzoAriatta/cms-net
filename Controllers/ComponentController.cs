using cms_net.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cms_net.Controllers
{
    public class ComponentController : Controller
    {
        // GET: ComponentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComponentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Select(int id)
        {
            CMSContext db = new CMSContext();
            List<ComponentDefinition> installedComp = db.ComponentDefinitions.ToList();

            ViewData["pageId"] = id;

            return View(installedComp);
        }

        // GET: ComponentController/Create
        public ActionResult Create(int pageId, string key)
        {

            // todo: crea nuova classe di supporto es "ComponentSupp o ComponentHelp"
            using(CMSContext db = new CMSContext())
            {
                //Page page = db.Pages.Where(p => p.Id == pageId).FirstOrDefault();

                //if(page != null)
                //{

                //}
                ViewData["pageId"] = pageId;

                return View();
            }
        }

        // POST: ComponentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, string key, int id)
        {
            using (CMSContext db = new CMSContext())
            {
                Component comp = new Component();

                comp.PageId = id;
                comp.ComponentDefinitionKey = key;
                comp.Fields = new List<Field>();

                foreach(string field in collection.Keys)
                {
                    comp.Fields.Add(new Field(field, collection[field]));
                }

                db.Components.Add(comp);
                db.SaveChanges();

                return RedirectToAction("Edit", "Page", new {id = id});
            }
        }

        // GET: ComponentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComponentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ComponentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComponentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
