using AutoMapper;
using MapperProfileBase = eDoc.Web.AutoMapper.MapperProfileBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace eDoc.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => GetConfig());
        }

        private static MapperConfiguration GetConfig()
        {
            var profiles = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsAssignableFrom(typeof(MapperProfileBase)) && t != typeof(MapperProfileBase))
                .ToList();

            var config = new MapperConfiguration(
                cfg =>
                {
                    profiles.ForEach(p => cfg.AddProfile(Activator.CreateInstance(p) as Profile));
                });

            return config;
        }
    }
}