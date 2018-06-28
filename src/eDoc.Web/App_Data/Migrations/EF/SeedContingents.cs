using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Common.Enums;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Model.Extensions;
using eDoc.Model.Managers;
using eDoc.Web.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public class SeedContingents : MigrationBase
    {
        public SeedContingents(string key) : base(key)
        {
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            var timestamp = DateTime.UtcNow;

            var contingents = new[]
            {
                new Contingent()
                {
                     Code = 1,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Інваліди війни"
                },
                new Contingent()
                {
                     Code = 2,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Учасники війни"
                },
                new Contingent()
                {
                     Code = 3,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Учасники бойових дій"
                },
                new Contingent()
                {
                     Code = 4,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Інваліди"
                },
                new Contingent()
                {
                     Code = 5,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Учасники ліквідації наслідків аварії на чорнобильскій АЕС"
                },
                new Contingent()
                {
                     Code = 6,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Евакуйовані"
                },
                new Contingent()
                {
                     Code = 7,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Особи, які проживають на території радіоактивного контролю"
                },
                new Contingent()
                {
                     Code = 8,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Діти, які народились від батьків які віднесені до 1, 2, 3 категорій осіб" +
                     ", що постраждали внаслідок Чорнобильскої катастрофи, із зони відчуження, а також відселені" +
                     "із зон безумовного (обов'язкового) і гарантованого добровільного відселення"
                },
                new Contingent()
                {
                     Code = 9,
                     CreationDate = timestamp,
                     LastModifiedDate = timestamp,
                     Description = "Інші пільгові категорії"
                },
            };
            (contextBase as EDocContext).Set<Contingent>().AddRange(contingents);
        }
    }
}