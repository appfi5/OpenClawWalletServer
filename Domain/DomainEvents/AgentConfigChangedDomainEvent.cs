using OpenClawWalletServer.Domain.AggregatesModel.AgentConfigAggregate;
using NetCorePal.Extensions.Domain;

namespace OpenClawWalletServer.Domain.DomainEvents;

/// <summary>
/// AgentConfig 变更领域事件
/// </summary>
public record AgentConfigChangedDomainEvent(AgentConfig AgentConfig) : IDomainEvent;
