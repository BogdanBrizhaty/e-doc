using eDoc.Model.Common.Enums;
using eDoc.Web.Base.Authorization;
using eDoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers
{
    [RoleAuthorize(ApplicationRoles = RoleAccessPoint.Doctor | RoleAccessPoint.Administrator | RoleAccessPoint.SystemProfile)]
    public class DoctorController : Base.ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ChangeInfo(DoctorInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Manage/Index.cshtml", model);
            }

            var dbEntry = UnitOfWork.Doctors.Get(model.Id);
            if (dbEntry == null)
                return HttpNotFound();

            dbEntry.Workplace = model.Workplace;
            dbEntry.WorkingExp = model.WorkingExp;
            dbEntry.Bio = model.Bio;
            dbEntry.SpecializationCode = model.SpecializationCode;

            UnitOfWork.Doctors.Update(dbEntry);

            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Manage");
        }

        [HttpGet]
        public ActionResult TestDoctorAccess()
        {
            return Content("doctor and administrative access");
        }
    }
}