using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDoc.Web.Models
{
    public class UserInfoWrapper
    {
        public UserInfoModel UserInfo { get; set; }
        public object SpeciciedInfo { get; set; }
    }
}