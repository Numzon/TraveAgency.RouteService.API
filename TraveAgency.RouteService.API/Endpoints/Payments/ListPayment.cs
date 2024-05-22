using TravelAgency.RouteService.Application.Payments.Commands;
using TravelAgency.RouteService.Application.Payments.Queries;

namespace TraveAgency.RouteService.API.Endpoints.Payments;

public sealed class ListPayment : EndpointBaseAsync.WithRequest<ListPaymentRequest>.WithResult<Result<ListPaymentResponse>>
{
    private readonly ISender _sender;

    public ListPayment(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("api/payments")]
    [SwaggerOperation(Summary = "Lists payment", Tags = new[] { "Payments" })]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public override async Task<Result<ListPaymentResponse>> HandleAsync([FromQuery] ListPaymentRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(request, cancellationToken);

        return result;
    }
}
