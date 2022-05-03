using Common.DataAccess;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLESS.Web.UI.ViewModels;

namespace QLESS.Web.UI.Controllers
{
    public class TransportCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportCardsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: TransportCardsController
        public async Task<IActionResult> Index()
        {
            var transportCards = await _context.TransportCards.ToListAsync();
            var rAWSMARTCARDs = await _context.RAWSMARTCARDs.ToListAsync();
            var list = new List<TransportCard>();
            if (transportCards.Count > 0)
            {
                list = (from a in transportCards join b in rAWSMARTCARDs on a.RAWSMARTCARD.SmartCardID equals b.SmartCardID select a).ToList();
            }
            return View(list);
        }

        // GET: TransportCardsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            TransportCardViewModel? vm = new TransportCardViewModel();
            var transportCards = await _context.TransportCards.ToListAsync();
            var rAWSMARTCARDs = await _context.RAWSMARTCARDs.ToListAsync();
            var list = new List<TransportCard>();
            if (transportCards.Count > 0)
            {
                list = (from a in transportCards join b in rAWSMARTCARDs on a.RAWSMARTCARD.SmartCardID equals b.SmartCardID select a).ToList();
            }
            var entity = list.FirstOrDefault(x => x.TransportCardID == id);
            if (entity != null)
            {
                vm.Entity = entity;
              //  vm.TransportCardTripsList;
            }
            return View(vm);
        }

        // GET: TransportCardsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportCardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransportCardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransportCardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransportCardsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransportCardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
