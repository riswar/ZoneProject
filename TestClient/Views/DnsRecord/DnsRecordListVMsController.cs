using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestClient.Data;
using Zone.ViewModel;

namespace TestClient.Views.DnsRecord
{
    public class DnsRecordListVMsController : Controller
    {
        private readonly TestClientContext _context;

        public DnsRecordListVMsController(TestClientContext context)
        {
            _context = context;
        }

        // GET: DnsRecordListVMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DnsRecordListVM.ToListAsync());
        }

        // GET: DnsRecordListVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecordListVM = await _context.DnsRecordListVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnsRecordListVM == null)
            {
                return NotFound();
            }

            return View(dnsRecordListVM);
        }

        // GET: DnsRecordListVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DnsRecordListVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fqdn,RecordName,Type,Ttl,Data,Zone")] DnsRecordListVM dnsRecordListVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnsRecordListVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dnsRecordListVM);
        }

        // GET: DnsRecordListVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecordListVM = await _context.DnsRecordListVM.FindAsync(id);
            if (dnsRecordListVM == null)
            {
                return NotFound();
            }
            return View(dnsRecordListVM);
        }

        // POST: DnsRecordListVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fqdn,RecordName,Type,Ttl,Data,Zone")] DnsRecordListVM dnsRecordListVM)
        {
            if (id != dnsRecordListVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnsRecordListVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnsRecordListVMExists(dnsRecordListVM.Id))
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
            return View(dnsRecordListVM);
        }

        // GET: DnsRecordListVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnsRecordListVM = await _context.DnsRecordListVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dnsRecordListVM == null)
            {
                return NotFound();
            }

            return View(dnsRecordListVM);
        }

        // POST: DnsRecordListVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dnsRecordListVM = await _context.DnsRecordListVM.FindAsync(id);
            if (dnsRecordListVM != null)
            {
                _context.DnsRecordListVM.Remove(dnsRecordListVM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnsRecordListVMExists(int id)
        {
            return _context.DnsRecordListVM.Any(e => e.Id == id);
        }
    }
}
