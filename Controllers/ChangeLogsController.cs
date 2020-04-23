using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChangeControl.Models;
using ChangeControl.Models.Context;
using ChangeControlApp.Models.ViewModels;

namespace ChangeControlApp.Controllers
{
    public class ChangeLogsController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ChangeImpactVM changeImpactVM { get; set; }

        public ChangeLogsController(ApplicationDbContext context)
        {
            _db = context;
            changeImpactVM = new ChangeImpactVM()
            {
                ChangeLog = new ChangeLog(),
                Impact = new Models.Impact(),
            };
        }
        public IActionResult Index()
        {
            return View(changeImpactVM);
        }
        public IActionResult UpsertVm(int? id)
        {
            changeImpactVM = new ChangeImpactVM();
            if (id == null)
            {
                //create
                changeImpactVM.ChangeLog = new ChangeLog();
                changeImpactVM.Impact = new Models.Impact();
                return View(changeImpactVM);
            }
            //Update
            changeImpactVM.ChangeLog = _db.ChangeLogs.FirstOrDefault(r => r.Id == id);
            changeImpactVM.Impact = _db.Impacts.FirstOrDefault(i => i.ChangeLogId == id);
            if ((changeImpactVM.ChangeLog == null) )
            {
                NotFound();
            }
            return View(changeImpactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertVm()
        {

            if (ModelState.IsValid)
            {
                if (changeImpactVM.ChangeLog.Id == 0)
                {
                    //create
                    _db.ChangeLogs.Add(changeImpactVM.ChangeLog);
                }
                else
                {
                    //Update
                    _db.ChangeLogs.Update(changeImpactVM.ChangeLog);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(changeImpactVM.ChangeLog);
        }
        // GET: Changes
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Upsert(int? id)
        //{
        //    changeLog = new ChangeLog();
        //    if (id == null)
        //    {
        //        //create
        //        return View(changeLog);
        //    }
        //    //Update
        //    changeLog =  _db.ChangeLogs.FirstOrDefault(r => r.Id == id);
        //    if (changeLog == null)
        //    {
        //        NotFound();
        //    }
        //    return View(changeLog);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (changeLog.Id == 0)
        //        {
        //            //create
        //            _db.ChangeLogs.Add(changeLog);
        //        }
        //        else
        //        {
        //            //Update
        //            _db.ChangeLogs.Update(changeLog);
        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(changeLog);
        //}



        #region API calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.ChangeLogs.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookInDB = await _db.ChangeLogs.FirstOrDefaultAsync(mbox => mbox.Id == id);
            if (bookInDB == null)
            {
                return Json(new { success = false, message = "Error while Deleting." });
            }
            else
            {
                _db.ChangeLogs.Remove(bookInDB);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }
        #endregion

        //// GET: Changes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var change = await _db.ChangeLogs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (change == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(change);
        //}

        //// GET: Changes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Changes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Description,Reason,AffectedProductsAndProcesses")] ChangeLog changeLog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(changeLog);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(changeLog);
        //}

        //// GET: Changes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var change = await _db.ChangeLogs.FindAsync(id);
        //    if (change == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(change);
        //}

        //// POST: Changes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Reason,AffectedProductsAndProcesses")] ChangeLog changeLog)
        //{
        //    if (id != changeLog.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _db.Update(changeLog);
        //            await _db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ChangeExists(changeLog.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(changeLog);
        //}

        // GET: Changes/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var change = await _db.ChangeLogs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (change == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(change);
        //}

        //// POST: Changes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var change = await _db.ChangeLogs.FindAsync(id);
        //    _db.ChangeLogs.Remove(change);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ChangeExists(int id)
        //{
        //    return _db.ChangeLogs.Any(e => e.Id == id);
        //}
    }
}
