using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models
{
    public class UserInfoModel : IValidatableObject
    {
        [Required]
        [MinLength(4)]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "По-батькові")]
        public string Patronymic { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Прописка")]
        public string RegistrationAddress { get; set; }

        [Required]
        [Display(Name = "Поточна адреса проживання")]
        public string CurrentAddress { get; set; }

        [Required]
        [Display(Name = "Контактний телефон (моб)")]
        public string CellPhone { get; set; }

        [Required]
        [Display(Name = "Контактний імейл")]
        public string ContactEmail { get; set; }

        [Display(Name = "Дата реєстрації")]
        public DateTime CreationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            var model = validationContext.ObjectInstance as UserInfoModel;
            if (model != null)
            {
                //if (model.FirstName)
            }
            return result;
        }
    }
}