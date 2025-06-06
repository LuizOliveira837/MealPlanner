﻿using FluentValidation;
using MealPlanner.Commnication.Request;
using MealPlanner.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Application.Patient.UseCases.DeletePatient
{
    public class ValidateRequestDeletePatient : AbstractValidator<RequestDeletePatient>
    {
        public ValidateRequestDeletePatient()
        {
            RuleFor
                (patient => patient.Id)
                .NotEmpty().WithMessage(MealPlannerResource.ID_NOT_NULL);
        }
    }
}
