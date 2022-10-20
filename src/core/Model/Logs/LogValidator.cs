using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TimeLogger.Model.Logs
{
    public class LogValidator:AbstractValidator<LogModel>
    {
        public LogValidator()
        {
            RuleFor(e => e.EndsAt)
                .GreaterThan(e => e.StartsAt)
                .NotNull()
                .WithMessage("StartsAt Time cant be same as EndsAt time");

            RuleFor(e => e.Status)
                .IsInEnum()
                .NotNull();
            RuleFor(e => e.Description)
                .MaximumLength(400);
           
        }
    }
}
//ToDO
//Check over lap for start and end date with repository
