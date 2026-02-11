using OpenClawWalletServer.Domain.Enums;
using NetCorePal.Extensions.Domain;

namespace OpenClawWalletServer.Domain.AggregatesModel.SendTransactionRecordAggregate;

/// <summary>
/// 交易发送记录 Id
/// </summary>
public partial record SendTransactionRecordId : IInt64StronglyTypedId;

/// <summary>
/// Agent 发送交易任务 Id
/// </summary>
public partial record AgentSendTransactionTaskId : IInt64StronglyTypedId;

public class SendTransactionRecord : Entity<SendTransactionRecordId>, IAggregateRoot
{
    /// <summary>
    /// 任务ld
    /// </summary>
    public AgentSendTransactionTaskId AgentSendTransactionTaskId { get; private set; } =
        new AgentSendTransactionTaskId(0);

    /// <summary>
    /// 关联订单 Id
    /// </summary>
    public long OrderId { get; private set; } = default!;

    /// <summary>
    /// 订单类型
    /// </summary>
    public OrderType OrderType { get; private set; } = OrderType.Unknown;

    /// <summary>
    /// 币种
    /// </summary>
    public CurrencyType CurrencyType { get; private set; }

    /// <summary>
    /// 交易内容
    /// </summary>
    public string Content { get; private set; } = string.Empty;

    /// <summary>
    /// 发送时间
    /// </summary>
    public DateTime ExecuteTime { get; private set; }

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool Deleted { get; private set; }

    /// <summary>
    /// 创建
    /// </summary>
    public static SendTransactionRecord Create(
        AgentSendTransactionTaskId agentSendTransactionTaskId,
        long orderId,
        OrderType orderType,
        CurrencyType currencyType,
        string content,
        DateTime executeTime
    )
    {
        var record = new SendTransactionRecord
        {
            AgentSendTransactionTaskId = agentSendTransactionTaskId,
            OrderId = orderId,
            OrderType = orderType,
            CurrencyType = currencyType,
            Content = content,
            ExecuteTime = executeTime,
            Deleted = false
        };
        return record;
    }
}
