using FluentValidation;

namespace TimeLogger.Model.Projects
{
    public class ProjectValidator : AbstractValidator<ProjectModel>
    {

        public ProjectValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .MaximumLength(200);

            RuleFor(e => e.PricePerHour)
                .Must(price => price > 0);
        }
    }
}