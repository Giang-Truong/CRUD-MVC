using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace CRUD_MVC_TEST.Controllers
{
    public class HomeController : Controller
    {
        CRUDContext _context = new CRUDContext();
        public ActionResult Index()
        {
            var listData = _context.Students.ToList();
            return View(listData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student Model)
        {
            _context.Students.Add(Model);
            _context.SaveChanges();
            ViewBag.messsage = "Done!";
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student Model)
        {
            var data = _context.Students.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentName = Model.StudentName;
                data.StudentBirtday = Model.StudentBirtday;
                data.StudentAddress = Model.StudentAddress;
                data.StudentClass = Model.StudentClass;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Deleted!";
            return RedirectToAction("index");
        }
    }
}