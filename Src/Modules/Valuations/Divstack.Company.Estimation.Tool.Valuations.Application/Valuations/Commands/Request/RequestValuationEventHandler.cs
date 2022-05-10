﻿namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

using Inquiries.IntegrationsEvents.External;
using Shared.Infrastructure.EventBus.Subscribe;

internal sealed class RequestValuationEventHandler : IIntegrationEventHandler<InquiryMadeEvent>
{
    private readonly IValuationsRepository _valuationsRepository;
    private readonly IIntegrationEventPublisher _integrationEventPublisher;

    public RequestValuationEventHandler(IValuationsRepository valuationsRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async ValueTask Handle(InquiryMadeEvent @event, CancellationToken cancellationToken = default)
    {
        var inquiryId = new InquiryId(@event.InquiryId);
        var valuation = Valuation.Request(inquiryId);
        await _valuationsRepository.AddAsync(valuation, cancellationToken);
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, cancellationToken);
    }
}
