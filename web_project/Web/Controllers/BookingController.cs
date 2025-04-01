using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var bookings = await _context.Bookings.Include(x => x.Table).Include(b => b.BookingTables).ThenInclude(bt => bt.Table).ToListAsync();
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
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                // Привязываем бронь к столу через BookingTables
                var bookingTable = new BookingTables
                {
                    ID_booking = booking.Id,
                    TableId = booking.ID_table
                };

                _context.BookingTables.Add(bookingTable);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tables = _context.Tables.ToList();
            return View(booking);
        }
        // GET: Booking/Delete/1 (Загружает страницу подтверждения удаления)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/DeleteConfirmed (Фактически удаляет запись)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Бронирование удалено!"; // Сообщение об успехе
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.Tables = _context.Tables.ToList(); // Передаём список столов
            return View(booking);
        }

        [HttpPost]
        public IActionResult Edit(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingBooking = _context.Bookings.Find(id);
                if (existingBooking == null)
                {
                    return NotFound();
                }

                // Обновляем данные бронирования
                existingBooking.ID_table = booking.ID_table;
                existingBooking.Date = booking.Date;
                existingBooking.Status = booking.Status;

                _context.SaveChanges(); // Сохраняем изменения
                return RedirectToAction("Index");
            }

            ViewBag.Tables = _context.Tables.ToList(); // Перезаполняем список столов, если форма невалидна
            return View(booking);
        }
    }
    
}
