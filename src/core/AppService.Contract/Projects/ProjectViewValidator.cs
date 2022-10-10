using System;
using FluentValidation;

namespace TimeLogger.AppService.Contract.Projects
{
    public class ProjectViewValidator : AbstractValidator<ProjectView>
    {
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        public ProjectViewValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .MaximumLength(200)
                .WithMessage("The maximum length of name is 200.");
            RuleFor(e => e.Status)
                .IsInEnum()
                .WithMessage("The Status Value could be 1, 2, or 3.");
            RuleFor(e=>e.PricePerHour)
                .ScalePrecision(2,18)
                .WithMessage("PricePerHour value should be decimal");
            RuleFor(e => e.DeadlineTime)
                .NotNull().WithMessage("DeadlineTime cant be null.")
                .Must(BeAValidDate).WithMessage("DeadlineTime should be valid DateTime");
        }
    }
}