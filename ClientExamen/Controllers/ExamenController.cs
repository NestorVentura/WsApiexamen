using ApiExamen;
using ClientExamen.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientExamen.Controllers
{
    public class ExamenController : Controller
    {
        private readonly ClsExamen _clsExamen;

        public ExamenController()
        {
            _clsExamen = new ClsExamen("");
        }

        // GET: ExamenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExamenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Description")] AgregarExamenModel model)
        {
            try
            {
                var result = _clsExamen.AgregarAsync(model.Name, model.Description, model.UseApi).GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamenController/Edit/5
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

        // GET: ExamenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamenController/Delete/5
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
