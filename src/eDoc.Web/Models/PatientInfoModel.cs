using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models
{
    public class PatientInfoModel
    {
        public string Id { get; set; }

        [Display(Name = "Дата останнього візиту")]
        public DateTime? LastVisit { get; set; }

        [Display(Name = "Стать")]
        public int Gender { get; set; }

        [Display(Name = "Місце роботи")]
        public string WorkPlace { get; set; }

        [Display(Name = "Пільговий номер")]
        public string PrivilegeCertificateNo { get; set; }

        [Display(Name = "Місце народження")]
        public string BirthPlace { get; set; }
    }
}