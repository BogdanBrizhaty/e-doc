using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Model.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Services
{
    public sealed class OwinFactory<TContext> where TContext : ApplicationContextBase
    {
        private readonly IDbContextFactory<TContext> _contextFactory;

        public OwinFactory(IDbContextFactory<TContext> contextFactory)
        {
            if (contextFactory is null)
                throw new ArgumentOutOfRangeException("Connection string can not be empty", null as Exception);
            _contextFactory = contextFactory;
        }

        public ApplicationContextBase CreateApplicationContext() 
        {
            return _contextFactory.Create();
        }

        public ApplicationUserManager CreateUserManager(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUserBase, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(context.Get<ApplicationContextBase>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUserBase>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUserBase>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUserBase>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUserBase>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public SignInManagerBase CreateSignInManager(IdentityFactoryOptions<SignInManagerBase> options, IOwinContext context)
        {
            return new SignInManagerBase(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
