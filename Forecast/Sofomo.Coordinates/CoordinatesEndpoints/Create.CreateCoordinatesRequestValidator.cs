using FastEndpoints;
using FluentValidation;

namespace Sofomo.Coordinates.Endpoints;

internal class CreateCoordinatesRequestValidator : Validator<CreateCoordinatesRequest>
{
    public CreateCoordinatesRequestValidator()
    {
        RuleFor(x => x.Latitude).GreaterThan(0).WithMessage("Latitude cannot be negative");
        RuleFor(x => x.Longitude).GreaterThan(0).WithMessage("Longitude cannot be negative");
    }
}