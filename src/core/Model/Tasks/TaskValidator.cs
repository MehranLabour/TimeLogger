using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TimeLogger.Model.Tasks
{
    public class TaskValidator:AbstractValidator<TaskModel>
    {
        public TaskValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .MaximumLength(200);
        }

    }
}
