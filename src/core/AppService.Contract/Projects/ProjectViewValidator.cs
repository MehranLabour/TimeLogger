using FluentValidation;

namespace TimeLogger.AppService.Contract.Projects
{
    public class ProjectViewValidator : AbstractValidator<ProjectView>
    {

        public ProjectViewValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .MaximumLength(200)
                .WithMessage("The maximum length of name is 200.");
            RuleFor(e => e.Status)
                .IsInEnum()
                .WithMessage("The Status Value could be 1, 2, or 3.");
        }
    }
}