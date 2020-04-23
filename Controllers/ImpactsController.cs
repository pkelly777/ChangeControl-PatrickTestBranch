using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChangeControl.Models.Context;
using ChangeControlApp.Models;

namespace ChangeControlApp.Controllers
{
    public class ImpactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImpactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Impacts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Impacts.Include(i => i.ChangeLog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Impacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impact = await _context.Impacts
                .Include(i => i.ChangeLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impact == null)
            {
                return NotFound();
            }

            return View(impact);
        }

        // GET: Impacts/Create
        public IActionResult Create()
        {
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "Id", "Description");
            return View();
        }

        // POST: Impacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,QmsProceduresProcesses,OtherDocumentation,FinishedProduct,ExistMaterialStockFinishProd,ProdCustSpec,MaterialQualification,ProductValidation,ProcessValidation,TestEquipMethodsCalib,RegulatoryReq,SupplierAgreementsSpec,CustomerReqSpec,NewExistEquipSoftware,Cleaning,Maintenance,Environment,ManufWorkFlowAncillaryPkgEquip,Other,ChangeLogId")] Impact impact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "Id", "Description", impact.ChangeLogId);
            return View(impact);
        }

        // GET: Impacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impact = await _context.Impacts.FindAsync(id);
            if (impact == null)
            {
                return NotFound();
            }
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "Id", "Description", impact.ChangeLogId);
            return View(impact);
        }

        // POST: Impacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,QmsProceduresProcesses,OtherDocumentation,FinishedProduct,ExistMaterialStockFinishProd,ProdCustSpec,MaterialQualification,ProductValidation,ProcessValidation,TestEquipMethodsCalib,RegulatoryReq,SupplierAgreementsSpec,CustomerReqSpec,NewExistEquipSoftware,Cleaning,Maintenance,Environment,ManufWorkFlowAncillaryPkgEquip,Other,ChangeLogId")] Impact impact)
        {
            if (id != impact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImpactExists(impact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "Id", "Description", impact.ChangeLogId);
            return View(impact);
        }

        // GET: Impacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impact = await _context.Impacts
                .Include(i => i.ChangeLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impact == null)
            {
                return NotFound();
            }

            return View(impact);
        }

        // POST: Impacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var impact = await _context.Impacts.FindAsync(id);
            _context.Impacts.Remove(impact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImpactExists(int id)
        {
            return _context.Impacts.Any(e => e.Id == id);
        }
    }
}
