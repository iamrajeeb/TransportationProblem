using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TransportationProblem.Models;

namespace TransportationProblem.Controllers
{
    public class TransportationController : Controller
    {
        static List<Transportation> data = new List<Transportation>();
        static Transportation edit;

        // GET: Transportation
        public ActionResult Index()
        {

            ViewBag.Edit = edit;
            return View(data);
        }


        /// <summary>
        ///     Handles both Create and Update
        ///     If the isEdit is true it takes it as a update
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oldName"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(Transportation model, string oldName)
        {
            if (ModelState.IsValid)
            {
                Transportation obj;
                if (!string.IsNullOrEmpty(model.Name) && data.Where(m => m.Name == model.Name).Count() > 0)
                {
                    return RedirectToAction("Index");
                }
                if (model.isEdit)
                {
                    data.Remove(data.Where(m => m.Name == oldName).SingleOrDefault());
                    //model.isEdit = false;
                    edit = null;
                }

                switch (model.TransportType)
                {
                    case enums.TransportTypes.Auto:
                        obj = new Auto(model);
                        data.Add(obj);
                        break;
                    case enums.TransportTypes.Boat:
                        obj = new Boat(model);
                        data.Add(obj);
                        break;
                    case enums.TransportTypes.Plane:
                        obj = new Plane(model);
                        data.Add(obj);
                        break;
                    case enums.TransportTypes.Train:
                        obj = new Train(model);
                        data.Add(obj);
                        break;

                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// gets the data from name as name is unique
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Edit(string name)
        {
            edit = data.Where(m => m.Name == name).SingleOrDefault();
            edit.isEdit = true;

            return RedirectToAction("Index");
        }


        /// <summary>
        /// delets one record using unique name reference
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            data.Remove(data.Where(m => m.Name == name).SingleOrDefault());
            return RedirectToAction("Index");
        }


    }
}
