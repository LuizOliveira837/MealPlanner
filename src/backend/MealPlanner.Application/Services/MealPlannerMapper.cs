using AutoMapper;
using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Services
{
    public class MealPlannerMapper : Profile
    {

        public MealPlannerMapper()
        {
            CreateMap<RequestRegisterPatient, MealPlanner.Domain.Patient>
                ();
        }
    }
}
