using Mapster;
using Microsoft.EntityFrameworkCore;
using TravelAgency.RouteService.Application.Common.Interfaces;
using TravelAgency.RouteService.Application.Payments.Commands;
using TravelAgency.RouteService.Application.Payments.Queries;
using TravelAgency.RouteService.Domain.ValueObjects;

namespace TravelAgency.RouteService.Infrastructure.Repositories;
public sealed class PaymentRepository : IPaymentRepository
{
    private readonly IRouteServiceDbContext _context;

    public PaymentRepository(IRouteServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> CreateAsync(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = request.Adapt<Payment>();
        payment.Status = PaymentStatus.WaitingForPayment;

        await _context.Payment.AddAsync(payment);
        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task<IEnumerable<Payment>> ListByDatesAsync(ListPaymentRequest request, CancellationToken cancellationToken)
    {
        var from = request.From.ToDateTime(TimeOnly.MinValue);
        var to = request.To.ToDateTime(TimeOnly.MaxValue);

        return await _context.Payment
            .Where(x => x.Status == PaymentStatus.Paid && x.Created >= from && x.Created <= to)
            .ToListAsync(cancellationToken);
    }
}
