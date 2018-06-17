using AutoMapper;
using MapperProfileBase = eDoc.Web.AutoMapper.MapperProfileBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TypeLoader = eDoc.Web.Loader.TypeLoader;

namespace eDoc.Web.App_Start
{
    public static class AutoMapperConfig
    {
        [Obsolete("Do not use this. Use ctor DI instead")]
        public static void Initialize()
        {
            Mapper.Initialize(cfg => GetConfig());
        }

        public static MapperConfiguration GetConfig()
        {
            var profiles = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(MapperProfileBase).IsAssignableFrom(t) && t != typeof(MapperProfileBase))
                .ToList();

            var config = new MapperConfiguration(
                cfg =>
                {
                    profiles.ForEach(p => cfg.AddProfile(TypeLoader.Initialize<MapperProfileBase>(p)));
                });

            return config;
        }
    }
}