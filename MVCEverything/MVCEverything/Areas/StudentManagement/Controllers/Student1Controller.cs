using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEverything.Areas.StudentManagement.Models;
using MVCEverything.Models;

namespace MVCEverything.Areas.StudentManagement.Controllers
{
    public class Student1Controller : Controller
    {
       // private Student1Context db = new Student1Context();

        // GET: /StudentManagement/Student1/
        //public ActionResult Index()
        //{
        //    return View(db.Student1.ToList());
        //}

        //// GET: /StudentManagement/Student1/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student1 student1 = db.Student1.Find(id);
        //    if (student1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student1);
        //}

        //// GET: /StudentManagement/Student1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /StudentManagement/Student1/Create
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ID,Name")] Student1 student1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Student1.Add(student1);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student1);
        //}

        //// GET: /StudentManagement/Student1/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student1 student1 = db.Student1.Find(id);
        //    if (student1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student1);
        //}

        //// POST: /StudentManagement/Student1/Edit/5
        //// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ID,Name")] Student1 student1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(student1).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(student1);
        //}

        //// GET: /StudentManagement/Student1/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student1 student1 = db.Student1.Find(id);
        //    if (student1 == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student1);
        //}

        //// POST: /StudentManagement/Student1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student1 student1 = db.Student1.Find(id);
        //    db.Student1.Remove(student1);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
