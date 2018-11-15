using Booking.Ticketing.Import;
using Booking.Ticketing.Services;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Ticketing.Controllers
{
    public class BookingTicketingController : Controller
    {
        private readonly CsvFileReader _csvFileReader;
        private readonly IElasticSearchServices _ticketingService;

        public BookingTicketingController(CsvFileReader csvFileReader,
           IElasticSearchServices ticketingService)
        {
            _csvFileReader = csvFileReader;
            _ticketingService = ticketingService;
        }




        [HttpGet]
        [Route("LoadFile/{fileName}")]
        public IActionResult LoadFile([FromRoute] string fileName)
        {
            var result = _csvFileReader.ReadDocument(fileName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


    }
}
