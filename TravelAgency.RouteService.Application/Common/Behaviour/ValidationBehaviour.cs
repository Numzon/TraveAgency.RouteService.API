using Ardalis.Result.FluentValidation;
using TravelAgency.RouteService.Application.Common.Extensions;

namespace TravelAgency.RouteService.Application.Common.Behaviour;
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.AsErrors())
                .ToList();

            if (!failures.Any())
            {
                return await next();
            }

            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = typeof(TResponse).GetGenericArguments()[0];
                var invalidMethod = typeof(Result<>).MakeGenericType(resultType).GetMethod(nameof(Result<int>.Invalid), new[] { typeof(List<ValidationError>) });

                if (invalidMethod != null)
                {
                    return (TResponse)invalidMethod.Invoke(null, new object[] { failures })!;
                }
            }
            else if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Invalid(failures);
            }

            throw new FluentValidationException(failures);
        }
        return await next();
    }
}
