using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDoc.Model.Common.Constants;
using eDoc.Model.Data.Context;
using eDoc.Model.Data.Entities;
using eDoc.Web.Base;
using static eDoc.Web.Managers.MigrationManager;

namespace eDoc.Web.App_Data.Migrations
{
    public class SeedDiseasesAndSympthomesMigration : MigrationBase
    {
        public SeedDiseasesAndSympthomesMigration(string key) : base(key)
        {
        }

        private Disease GetDisease(string name, string code, string descr = null)
        {
            return new Disease()
            {
                Name = name,
                Description = descr ?? name,
                ICDCode = code ?? DataConstants.NoDiseaseCode,

                CreationDate = UtcExecutionTime,
                LastModifiedDate = UtcExecutionTime
            };
        }
        private Sympthome  GetSymphome(string name, string descr = null)
        {
            return new Sympthome()
            {
                Name = name,
                Description = descr ?? name,

                CreationDate = UtcExecutionTime,
                LastModifiedDate = UtcExecutionTime,
            };
        }

        private DiseaseSympthomeMapping GetMapping(Disease disease, Sympthome sympthome)
        {
            return new DiseaseSympthomeMapping()
            {
                DiseaseId = disease.Id,
                SympthomeId = sympthome.Id,

                CreationDate = UtcExecutionTime,
                LastModifiedDate = UtcExecutionTime,    
            };
        }

        protected override void OnExecute(ApplicationContextBase contextBase)
        {
            var context = contextBase as EDocContext;

            var symthomes = new Dictionary<int, Sympthome>
            {
                { 0, GetSymphome("Кашель сухий") },
                { 1, GetSymphome("Кашель з мокротою") },
                { 2, GetSymphome("Нежить") },
                { 3, GetSymphome("Головний біль") },
                { 4, GetSymphome("Різь в очах") },
                { 5, GetSymphome("Температура", "Підвищена температура") },
                { 6, GetSymphome("Болі в горлі") },
                { 7, GetSymphome("Ломота") },
                { 8, GetSymphome("Слабкість") },
            };

            var diseases = new Dictionary<int, Disease>
            {
                { 0, GetDisease("ГРЗ", "J06", "Гостре распіраторне захворювання") },
                { 1, GetDisease("Гострий фарингіт", "J02") },
                { 2, GetDisease("Гострий тонзиліт", "J03", "Ангіна") },
                { 3, GetDisease("Грип ідентифікований", "J10") },
                { 4, GetDisease("Грип неідентифікований", "J11") },
                { 5, GetDisease("Гострий бронхіт", "J20") },
            };

            var mappings = new[]
            {
                // грз
                GetMapping(diseases[0], symthomes[1]),
                GetMapping(diseases[0], symthomes[2]),
                GetMapping(diseases[0], symthomes[6]),

                // фарингіт
                GetMapping(diseases[1], symthomes[1]),
                GetMapping(diseases[1], symthomes[5]),
                GetMapping(diseases[1], symthomes[6]),

                //Ангіна
                GetMapping(diseases[2], symthomes[3]),
                GetMapping(diseases[2], symthomes[5]),
                GetMapping(diseases[2], symthomes[6]),

                // Грип ід
                GetMapping(diseases[3], symthomes[2]),
                GetMapping(diseases[3], symthomes[4]),
                GetMapping(diseases[3], symthomes[5]),
                GetMapping(diseases[3], symthomes[7]),
                GetMapping(diseases[3], symthomes[8]),

                // грип не ід
                GetMapping(diseases[4], symthomes[2]),
                GetMapping(diseases[4], symthomes[4]),
                GetMapping(diseases[4], symthomes[5]),
                GetMapping(diseases[4], symthomes[7]),
                GetMapping(diseases[4], symthomes[8]),

                // бронхіт
                GetMapping(diseases[5], symthomes[0]),
                GetMapping(diseases[5], symthomes[1]),
                GetMapping(diseases[5], symthomes[3]),
                GetMapping(diseases[5], symthomes[5]),
            };

            context.Sympthomes.AddRange(symthomes.Select(s => s.Value));
            context.Diseases.AddRange(diseases.Select(d => d.Value));
            context.DiseaseSympthomeMappings.AddRange(mappings);
        }
    }
}