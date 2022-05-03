using Common.DataAccess;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.CardTransactions.ToListAsync();
            var transportCards = await _context.TransportCards.ToListAsync();
            var rAWSMARTCARDs = await _context.RAWSMARTCARDs.ToListAsync();
            var list = new List<TransportCard>();
            if (transportCards.Count > 0)
            {
                list = (from a in transportCards join b in rAWSMARTCARDs on a.RAWSMARTCARD.SmartCardID equals b.SmartCardID select a).ToList();

                foreach (var item in list)
                {
                    item.LoadBalance = transactions.FindAll(x => x.TransportCard?.TransportCardID == item.TransportCardID).Sum(x => x.AmountTotal);
                }
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            TransportCardViewModel? vm = new TransportCardViewModel();
            var transactions = await _context.CardTransactions.ToListAsync();
            var transportCards = await _context.TransportCards.ToListAsync();
            var rAWSMARTCARDs = await _context.RAWSMARTCARDs.ToListAsync();
            var trips = await _context.TransportCardTrips.ToListAsync();
            var list = new List<TransportCard>();
            var listTransactions = new List<CardTransaction>();
            if (transportCards.Count > 0)
            {
                list = (from a in transportCards join b in rAWSMARTCARDs on a.RAWSMARTCARD.SmartCardID equals b.SmartCardID select a).ToList();
                listTransactions = (from a in transactions join b in transportCards on a.TransportCard?.TransportCardID equals b.TransportCardID where b.TransportCardID == id select a).ToList();
            }
            var entity = list.FirstOrDefault(x => x.TransportCardID == id);
            if (entity != null)
            {
                vm.Entity = entity;
                vm.Entity.LoadBalance = listTransactions.Sum(x => x.AmountTotal);
                foreach (var item in trips.FindAll(x => x.TransportCard?.TransportCardID == id))
                {
                    var trans = listTransactions.FirstOrDefault(x => x.TransportCardTrip?.TransportCardTripID == item.TransportCardTripID);
                    if (trans != null)
                    {
                        item.CurrentBalance = trans.AmountReceived;
                        item.DiscountPercentage = trans.DiscountPercentage;
                        item.AmountDiscounted = trans.AmountDiscounted;
                        item.RunningBalance = trans.AmountChange;
                    }
                    vm.TransportCardTripsList.Add(item);
                }
            }
            return View(vm);
        }


        public async Task<IActionResult> AddTrip(int id)
        {
            var transactions = await _context.CardTransactions.ToListAsync();
            var transportCards = await _context.TransportCards.ToListAsync();

            var list = new List<CardTransaction>();
            if (transportCards.Count > 0)
            {
                list = (from a in transactions join b in transportCards on a.TransportCard?.TransportCardID equals b.TransportCardID where b.TransportCardID == id select a).ToList();
                if (list.Count > 0)
                {
                    var total = list.Sum(x => x.AmountTotal);
                    if (total > 15)
                    {
                        // Validate Account Balance
                        var cardTrip = new TransportCardTrip
                        {
                            TransportCard = await _context.TransportCards.FindAsync(id),
                            TransportCardTripDate = DateTime.Now,
                            AmountTripCharge = 15,
                            HasGateIN = true,
                            HasGateOUT = true,
                            OriginStationCode = "ST1",
                            DestinationStationCode = "ST2",
                            TransportCardTripOperatorCode = "OPR007"
                        };
                        await _context.TransportCardTrips.AddAsync(cardTrip);

                        var transaction = new CardTransaction
                        {
                            TransportCardTrip = cardTrip,
                            TransportCard = await _context.TransportCards.FindAsync(id),
                            PostingDate = DateTime.Now,
                            AmountTotal = -15,
                            AmountReceived = total,
                            DiscountPercentage = 0,
                            AmountDiscounted = 0,
                            AmountChange = total - 15,
                        };
                        await _context.CardTransactions.AddAsync(transaction);
                        IDbContextTransaction? trans = null;
                        try
                        {
                            using (trans = await _context.Database.BeginTransactionAsync())
                            {
                                await _context.SaveChangesAsync();
                                await trans.CommitAsync();
                            }

                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException is SqlException sqlexception)
                            {
                                ModelState.AddModelError(string.Empty, sqlexception.Message.ToString());
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                            }
                        }
                        finally
                        {
                            trans?.RollbackAsync();
                        }
                    }
                }
            }
            return RedirectToAction("Details", "TransportCards", new { id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTrip(TransportCardViewModel vm)
        {
            try
            {
                vm.TransportCardID = vm.Entity.TransportCardID;

                //List<TrainStation> stations = new List<TrainStation>();
                //stations = await _context.TrainStations.ToListAsync();
                //vm.TrainStationsList = stations.OrderBy(x => x.TrainStationNumber).ToList();
                //vm.OriginList.AddRange(collection: vm.TrainStationsList.Select(x => new SelectListItem { Value = x.TrainStationID.ToString(), Text = x.TrainStationCode }).ToList());
                //vm.DestinationList.AddRange(collection: vm.TrainStationsList.Select(x => new SelectListItem { Value = x.TrainStationID.ToString(), Text = x.TrainStationCode }).ToList());









                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
