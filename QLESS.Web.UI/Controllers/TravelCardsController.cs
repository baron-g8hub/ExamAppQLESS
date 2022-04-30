#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using QLESS.Web.UI.Data;
using Common.Contracts;

namespace QLESS.Web.UI.Controllers
{
    public class TravelCardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TravelCardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TravelCards
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.TravelCard.GetTravelCardsAsync());
        }

        // GET: TravelCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelCard = await _unitOfWork.TravelCard.GetTravelCardAsync(id.Value);
            if (travelCard == null)
            {
                return NotFound();
            }

            return View(travelCard);
        }

        // GET: TravelCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelCardID,CardHolder,LoadBalance,LastUsedDate,ValidityDate,IsActive,RowVersion,IsPWDCard,IsSeniorCard,SCCNumber,PWDNumber")] TravelCard travelCard)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TravelCard.AddTravelCard(travelCard);
                await _unitOfWork.SaveAsync();  
                return RedirectToAction(nameof(Index));
            }
            return View(travelCard);
        }

        // GET: TravelCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelCard = await _unitOfWork.TravelCard.GetTravelCardAsync(id.Value);
            if (travelCard == null)
            {
                return NotFound();
            }
            return View(travelCard);
        }

        // POST: TravelCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelCardID,CardHolder,LoadBalance,LastUsedDate,ValidityDate,IsActive,RowVersion,IsPWDCard,IsSeniorCard,SCCNumber,PWDNumber")] TravelCard travelCard)
        {
            if (id != travelCard.TravelCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.TravelCard.UpdateTravelCard(travelCard);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelCardExists(travelCard.TravelCardID))
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
            return View(travelCard);
        }

        // GET: TravelCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelCard = await _unitOfWork.TravelCard.GetTravelCardAsync(id.Value);
            if (travelCard == null)
            {
                return NotFound();
            }

            return View(travelCard);
        }

        // POST: TravelCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelCard = await _unitOfWork.TravelCard.GetTravelCardAsync(id);
            _unitOfWork.TravelCard.DeleteTravelCard(travelCard.TravelCardID);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelCardExists(int id)
        {
            return _unitOfWork.TravelCard.GetAllTravelCards().Any(e => e.TravelCardID == id);
        }
    }
}
