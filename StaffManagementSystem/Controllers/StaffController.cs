using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StaffManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private StaffManagementContext _db;
        public StaffController(StaffManagementContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult AjaxMethod()
        {
            var item = _db.TblStaffs.ToList();

            return Json(new {data = item });
        }


        public IActionResult Create(int? id) //create or edit
        {
            if (id > 0)
            {
                var data = _db.TblStaffs.Find(id);
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblStaff staff) //Create or Edit
        {
            if(staff.StaffId > 0)
            {
                if (!ModelState.IsValid)
                {
                    return View(staff);

                }
                var data = _db.TblStaffs.Find(staff.StaffId);
                staff.StaffId = data.StaffId;
                staff.PhoneNumber = data.PhoneNumber;
                staff.SkillId = data.SkillId;
                staff.StaffName = data.StaffName;
                staff.YearsExperience = data.YearsExperience;

                _db.Entry(staff).State = EntityState.Modified;
                _db.SaveChanges();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(staff);

                }
                _db.TblStaffs.Add(staff);
                _db.SaveChanges();

            }  //return Json(staff);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            var data = _db.TblStaffs.Find(id);
            TblStaff staff = new TblStaff()
            {
                StaffId = data.StaffId,
                StaffName = data.StaffName,
                PhoneNumber = data.PhoneNumber,
                YearsExperience = data.YearsExperience,
                SkillId= data.SkillId
            };
            return View(staff);
        }
        [HttpPost]
        public IActionResult Edit(TblStaff staff)
        {
            if(!ModelState.IsValid)
            {
                return View(staff);
            }
            _db.Entry(staff).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult CreatePartial()
        {
            return PartialView();
        }
    }
}
