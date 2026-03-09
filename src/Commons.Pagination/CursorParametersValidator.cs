using FluentValidation;

namespace Commons.Pagination;

/// <summary>
/// Reusable validator for cursor pagination parameters.
/// Ensures PageSize is within acceptable bounds.
/// </summary>
public sealed class CursorParametersValidator<T> : AbstractValidator<T>
    where T : CursorParameters
{
    public CursorParametersValidator(int maxPageSize = 100)
    {
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, maxPageSize)
            .WithMessage($"PageSize must be between 1 and {maxPageSize}");
    }
}
