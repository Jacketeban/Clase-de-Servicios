
using FluentValidation;
using TeamsAPI.Dtos;

namespace TeamsAPI.Validations

{
    public class TeamValidator : AbstractValidator<TeamDto>
    {
        public TeamValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
