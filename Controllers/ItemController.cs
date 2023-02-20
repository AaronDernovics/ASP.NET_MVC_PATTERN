using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class ItemController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ItemController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Item> objList = _db.Items;
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
        public IActionResult Create(Item obj)
        {
			_db.Items.Add(obj);
			_db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
