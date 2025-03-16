using FastEndpoints;
using FluentValidation;

namespace Sofomo.Coordinates.Endpoints;

internal class CreateCoordinatesRequestValidator : Validator<CreateCoordinatesRequest>
{
    public CreateCoordinatesRequestValidator()
    {
        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude must be between -90 and 90");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude must be between -180 and 180");
    }
}