using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure;
using FluentValidation;

namespace API.Validation
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(command => command.Author).NotEmpty();
            RuleFor(command => command.Text).NotEmpty().MaximumLength(30);
        }
    }
}