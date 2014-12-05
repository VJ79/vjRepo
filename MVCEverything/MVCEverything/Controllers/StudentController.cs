using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEverything.Models;
using System.Data.Entity.Migrations;
using ClaySharp;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace MVCEverything.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Student/
        [ActionName("Index")]
        public ActionResult tt()
        {
           // Program.test();
            var str="{a:1,b:'5'}";
            dynamic v = Parse(str);

            dynamic New = new ClayFactory();
            var person = New.Pserson();
            person.FirstName = "Louis";
            person.LastName = "Dejardin";
            person.SayFullName = new Func<string, string>(x => person.FirstName + person.LastName + x);

            var ff = person.SayFullName()(" Here!");
            //QEReportEntities ff = new QEReportEntities();
            //var faf = ff.StudentRankForModules.Where(i => 1 == 1);
            //var dd=faf.ToList();
            return View(db.Students.ToList());
        }
        public ActionResult webpages() {
            return View();
        }

        public static dynamic Parse(string json)
        {
            using (var reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.Unicode.GetBytes(json), XmlDictionaryReaderQuotas.Max))
            {
                var f = reader.Value;
                return ToValue(XElement.Load(reader));
            }
        }

        private static dynamic ToValue(XElement element)
        {
            var type = (JsonType)Enum.Parse(typeof(JsonType), element.Attribute("type").Value);
            switch (type)
            {
                case JsonType.boolean:
                    return (bool)element;
                case JsonType.number:
                    return (double)element;
                case JsonType.@string:
                    return (string)element;
                case JsonType.@object:
                case JsonType.array:
                    //return new DynamicJson(element, type);
                case JsonType.@null:
                default:
                    return null;
            }
        }
        public enum JsonType {
            boolean,
            number,
            @string,
            @object,
            array,
            @null
        }
        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.AddOrUpdate(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
