using TravelAgency.RouteService.Application.Payments.Commands;

namespace TraveAgency.RouteService.API.Endpoints.Payments;

public sealed class CreatePayment : EndpointBaseAsync.WithRequest<CreatePaymentRequest>.WithResult<Result<CreatePaymentResponse>>
{
    private readonly ISender _sender;

    public CreatePayment(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("api/payments")]
    [SwaggerOperation(Summary = "Creates payment", Tags = new[] { "Payments" })]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public override async Task<Result<CreatePaymentResponse>> HandleAsync([FromBody] CreatePaymentRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(request, cancellationToken);

        return result;
    }
}
