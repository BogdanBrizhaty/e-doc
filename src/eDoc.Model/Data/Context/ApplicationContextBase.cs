using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Entities;
using eDoc.Model.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Context
{
    public abstract class ApplicationContextBase : IdentityDbContext<ApplicationUserBase, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ContextDeleteOption OnDelete { get; }
        public ApplicationContextBase(string connStringName)
            : this(connStringName, ContextDeleteOption.MarkAsDeleted)
        {

        }
        public ApplicationContextBase(string connStringName, ContextDeleteOption onDelete)
            : base(connStringName)
        {

        }
    }
}