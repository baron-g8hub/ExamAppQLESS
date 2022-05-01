using Common.DataAccess;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QLESS.Web.UI.Controllers
{
    public class RAWSMARTCARDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RAWSMARTCARDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RAWSMARTCARDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.RAWSMARTCARDs.ToListAsync());
        }

        // GET: RAWSMARTCARDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAWSMARTCARD = await _context.RAWSMARTCARDs
                .FirstOrDefaultAsync(m => m.SmartCardID == id);
            if (rAWSMARTCARD == null)
            {
                return NotFound();
            }

            return View(rAWSMARTCARD);
        }

        // GET: RAWSMARTCARDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RAWSMARTCARDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SmartCardID,SmartCardName,SerialNumber,IsActive,ActivatedDate,DeactivatedDate,IsValid,RowVersion")] RAWSMARTCARD rAWSMARTCARD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rAWSMARTCARD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rAWSMARTCARD);
        }

        // GET: RAWSMARTCARDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAWSMARTCARD = await _context.RAWSMARTCARDs.FindAsync(id);
            if (rAWSMARTCARD == null)
            {
                return NotFound();
            }
            return View(rAWSMARTCARD);
        }

        // POST: RAWSMARTCARDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SmartCardID,SmartCardName,SerialNumber,IsActive,ActivatedDate,DeactivatedDate,IsValid,RowVersion")] RAWSMARTCARD rAWSMARTCARD)
        {
            if (id != rAWSMARTCARD.SmartCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rAWSMARTCARD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RAWSMARTCARDExists(rAWSMARTCARD.SmartCardID))
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
            return View(rAWSMARTCARD);
        }

        // GET: RAWSMARTCARDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rAWSMARTCARD = await _context.RAWSMARTCARDs
                .FirstOrDefaultAsync(m => m.SmartCardID == id);
            if (rAWSMARTCARD == null)
            {
                return NotFound();
            }

            return View(rAWSMARTCARD);
        }

        // POST: RAWSMARTCARDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rAWSMARTCARD = await _context.RAWSMARTCARDs.FindAsync(id);
            _context.RAWSMARTCARDs.Remove(rAWSMARTCARD!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RAWSMARTCARDExists(int id)
        {
            return _context.RAWSMARTCARDs.Any(e => e.SmartCardID == id);
        }
    }
}
