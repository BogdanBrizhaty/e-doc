using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models
{
    public class DoctorInfoModel
    {
        public string Id { get; set; }

        [Display(Name = "Місце роботи")]
        public string Workplace { get; set; }

        [Display(Name = "Біографія")]
        public string Bio { get; set; }

        [Display(Name = "Досвід роботи")]
        public int WorkingExp { get; set; }

        [Display(Name = "Спеціалізація")]
        public int SpecializationCode { get; set; }

        public string Specialization { get; set; }
    }
}