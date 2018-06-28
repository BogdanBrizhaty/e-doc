using eDoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers
{
    public class PatientController : Base.ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ChangeInfo(PatientInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Manage/Index.cshtml", model);
            }

            var dbEntry = UnitOfWork.Patients.Get(model.Id);
            if (dbEntry == null)
                return HttpNotFound();

            dbEntry.Gender = model.Gender;
            dbEntry.BirthPlace = model.BirthPlace;
            dbEntry.PrivilegeCertificateNo = model.PrivilegeCertificateNo;

            UnitOfWork.Patients.Update(dbEntry);

            await UnitOfWork.SaveChangesAsync();
            return RedirectToAction("Index", "Manage");
        }
    }
}