using AutoMapper;
using MealPlanner.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.Test.Services
{
    public static class MappingsBuilder
    {

        public static IMapper Build()
        {
            return new MapperConfiguration(config =>
                {
                    config.AddProfile(new MealPlannerMapper());
                }).CreateMapper();
        }
    }
}
