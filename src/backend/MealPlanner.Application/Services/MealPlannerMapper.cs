using AutoMapper;
using MealPlanner.Commnication;
using MealPlanner.Commnication.Request;

namespace MealPlanner.Application.Services
{
    public class MealPlannerMapper : Profile
    {

        public MealPlannerMapper()
        {
            CreateMap<RequestRegisterPatient, MealPlanner.Domain.Patient>
                ();

            CreateMap<MealPlanner.Domain.Patient, ResponseGetPatientById>
                ();

            CreateMap<RequestRegisterFood, MealPlanner.Domain.Food>
                ();

            CreateMap<RequestRegisterMealPlan, MealPlanner.Domain.MealPlan>
               ();

            CreateMap<RequestAddMealPlanFood, MealPlanner.Domain.MealPlanFood>
               ();

            CreateMap<RequestAddMealPlanFood,  ResponsePatientMealPlanTodayDetail>
              ();




            





        }
    }
}
