using manage_staff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manage_staff.Controllers
{
    public class StaffController : Controller
    {
        private readonly ExamDistributionTestContext _db;

        public StaffController(ExamDistributionTestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var staffList = _db.Staff.ToList();
            return View(staffList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            var existingStaffCode = await _db.Staff.Where(x => x.StaffCode == staff.StaffCode).FirstOrDefaultAsync();

            if (existingStaffCode != null)
            {
                ModelState.AddModelError("StaffCode", "Mã nhân viên đã tồn tại");
            }

            var existingFE = await _db.Staff.Where(x => x.AccountFe == staff.AccountFe).FirstOrDefaultAsync();
            if (existingFE != null)
            {
                ModelState.AddModelError("StaffCode", "Email FE đã tồn tại");
            }

            var existingFPT = await _db.Staff.Where(x => x.AccountFpt == staff.AccountFpt).FirstOrDefaultAsync();
            if (existingFPT != null)
            {
                ModelState.AddModelError("StaffCode", "Email FPT đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _db.Staff.Add(staff);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        public IActionResult Edit(Guid id)
        {
            var staffUpdate = _db.Staff.Find(id);
            return View(staffUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            var existingStaffCode = await _db.Staff.Where(x => x.StaffCode == staff.StaffCode).FirstOrDefaultAsync();

            if (existingStaffCode != null)
            {
                ModelState.AddModelError("StaffCode", "Mã nhân viên đã tồn tại");
            }

            var existingFE = await _db.Staff.Where(x => x.AccountFe == staff.AccountFe).FirstOrDefaultAsync();
            if (existingFE != null)
            {
                ModelState.AddModelError("StaffCode", "Email FE đã tồn tại");
            }

            var existingFPT = await _db.Staff.Where(x => x.AccountFpt == staff.AccountFpt).FirstOrDefaultAsync();
            if (existingFPT != null)
            {
                ModelState.AddModelError("StaffCode", "Email FPT đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _db.Staff.Update(staff);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            var staff = await _db.Staff.FindAsync(id);
            if (staff != null)
            {
                staff.Status = (staff.Status == 0) ? (byte?)1 : (byte?)0;
                _db.Update(staff);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Detail(Guid id)
        {
            var staffDetail = _db.Staff.Find(id);
            return View(staffDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(Staff staff)
        {
            _db.Staff.Update(staff);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}