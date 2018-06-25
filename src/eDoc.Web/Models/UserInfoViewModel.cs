using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models
{
    public class UserInfoModel
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

        [Display(Name = "Дозволити дзвінки")]
        public bool AllowToCall { get; set; }

        [Display(Name = "Дозволити отримувати СМС сповіщення")]
        public bool AllowToSMS { get; set; }

        [Display(Name = "Дозволити електронні повідомлення")]
        public bool AllowEmailingMe { get; set; }

        public string AvatarPath { get; set; } = "/Resources/Images/Defaults/default-avatar-doc.jpg";
        public string AvatarThumbnailPath { get; set; } = "/Resources/Images/Defaults/default-avatar-doc.jpg";
    }

}