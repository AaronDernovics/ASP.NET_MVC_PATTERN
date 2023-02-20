using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MyExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expenses> objList = _db.Expenses;
            return View(objList);
            
        }

        // Get-Create
        public IActionResult Create()
        {

            return View();
        }
     

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expenses obj)
        {
            if(ModelState.IsValid)
            {
            _db.Expenses.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            }
            
            
                return View(obj);
            
        }

        // GET-Delete
      
        public IActionResult Delete(int? id)
        {
         
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
        
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET-Update

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Expenses obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(obj);

        }
    }
}
