using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using FluentValidation;

namespace TimeLogger.AppService.Contract.Tasks
{
    public class TaskViewValidator:AbstractValidator<TaskView>
    {
        public TaskViewValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .MaximumLength(200)
                .WithMessage("the maximum length is 200");
        }
    }
}
