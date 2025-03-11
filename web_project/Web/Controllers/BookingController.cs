using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.Include(b => b.BookingTables).ThenInclude(bt => bt.Table).ToListAsync();
            return View(bookings);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewBag.Tables = _context.Tables.ToList(); // Передаем список столов в представление
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking, int tableId)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                // Привязываем бронь к столу через BookingTables
                var bookingTable = new BookingTables
                {
                    ID_booking = booking.Id,
                    ID_table = tableId
                };

                _context.BookingTables.Add(bookingTable);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tables = _context.Tables.ToList();
            return View(booking);
        }
    }
}