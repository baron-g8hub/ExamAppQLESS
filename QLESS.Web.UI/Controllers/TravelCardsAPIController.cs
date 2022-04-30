using Common.Contracts;
using Common.DataAccess;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLESS.Web.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TravelCardsAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TravelCardsAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<TravelCardsAPIController>
        [HttpGet]
        public async Task<IEnumerable<TravelCard>> Get()
        {
            var list = await _unitOfWork.TravelCard.GetTravelCardsAsync();
            //return new string[] { "value1", "value2" };
            return list;
        }

        // GET api/<TravelCardsAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TravelCardsAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TravelCardsAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TravelCardsAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
