using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TimeLogger.AppService.Contract.Logs
{
    public class LogViewValidator : AbstractValidator<LogView>
    {
        public LogViewValidator()
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