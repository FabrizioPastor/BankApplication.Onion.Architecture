using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Se han producido uno o más erroes de validación")
    {
        Errors = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }

    public List<string> Errors { get; }
}