using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CashCollectionController : Controller
    {
        private static List<CashCollection> _collections = new();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            if (_collections.Count > 0)
                ViewBag.CurrentIndex = _collections.Count - 1;
            return View(_collections);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CashCollection collection)
        {
            if (ModelState.IsValid)
            {
                collection.Id = _nextId++;
                _collections.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        public IActionResult Details(int id)
        {
            var collection = _collections.Find(c => c.Id == id);
            if (collection == null) return NotFound();
            ViewBag.CurrentIndex = _collections.FindIndex(c => c.Id == id);
            return View(collection);
        }

        public IActionResult Edit(int id)
        {
            var collection = _collections.Find(c => c.Id == id);
            if (collection == null) return NotFound();
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CashCollection collection)
        {
            if (ModelState.IsValid)
            {
                var existing = _collections.Find(c => c.Id == collection.Id);
                if (existing == null) return NotFound();
                existing.CollectionName = collection.CollectionName;
                existing.Amount = collection.Amount;
                existing.CreationDate = collection.CreationDate;
                existing.Phone = collection.Phone;
                existing.IsCompleted = collection.IsCompleted;
                existing.Description = collection.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        [HttpPost]
        public IActionResult SetHelper(bool useInternal)
        {
            TempData["UseInternalHelper"] = useInternal;
            return RedirectToAction(nameof(Index));
        }
    }
}