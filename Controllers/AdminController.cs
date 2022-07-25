using cms_net.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cms_net.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ComponentList()
        {
            string pathComponent = "C:/.NET_projects/csharp/cms-net/Views/Pages/Components/";
            string[] directory = Directory.GetDirectories(pathComponent, "*",SearchOption.TopDirectoryOnly);

            List<string> componentList = new List<string>();

            foreach (string directoryPath in directory)
            {
                string[] separe = directoryPath.Split("/");
                string nameComponent = separe.Last();
                componentList.Add(nameComponent);
            }

            ViewData["componentList"] = componentList;

            return View();
        }

        public ActionResult InstallComponent(string name)
        {
            using(CMSContext db = new CMSContext())
            {
                ComponentDefinition installComp = new ComponentDefinition(name);

                db.ComponentDefinitions.Add(installComp);

                db.SaveChanges();

                return RedirectToAction("ComponentList");
            }

        }

        public ActionResult UninstallComponent(string name)
        {
            using (CMSContext db = new CMSContext())
            {
                ComponentDefinition cd = db.ComponentDefinitions.Where(cd => cd.Key == name).FirstOrDefault();

                db.ComponentDefinitions.Remove(cd);

                db.SaveChanges();

                return RedirectToAction("ComponentList");
            }
        }
    }
}
