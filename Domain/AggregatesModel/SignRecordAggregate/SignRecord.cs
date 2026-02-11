using OpenClawWalletServer.Domain.Enums;
using NetCorePal.Extensions.Domain;

namespace OpenClawWalletServer.Domain.AggregatesModel.SignRecordAggregate;

/// <summary>
/// 签名记录 Id
/// </summary>
public partial record SignRecordId : IInt64StronglyTypedId;

/// <summary>
/// 签名任务 Id
/// </summary>
public partial record AgentTaskId : IInt64StronglyTypedId;

/// <summary>
/// 订单 Id
/// </summary>
public partial record ExchangeOrderId : IInt64StronglyTypedId;

/// <summary>
/// 返还 CKB 交易记录 Id
/// </summary>
public partial record ReturnCkbTransactionRecordId : IInt64StronglyTypedId;

/// <summary>
/// 资金流出订单 Id
/// </summary>
public partial record BusinessCashOutOrderId : IInt64StronglyTypedId;

/// <summary>
/// 资金流出订单交易信息 Id
/// </summary>
public partial record BusinessCashOutOrderTransactionInfoId : IInt64StronglyTypedId;

/// <summary>
/// 资金流出订单 AgentTask Id
/// </summary>
public partial record BusinessCashOutOrderAgentTaskId : IInt64StronglyTypedId;

/// <summary>
/// 签名记录
/// </summary>
public class SignRecord : Entity<SignRecordId>, IAggregateRoot
{
    protected SignRecord()
    {
    }

    /// <summary>
    /// 签名任务 Id
    /// </summary>
    public AgentTaskId AgentTaskId { get; private set; } = default!;

    /// <summary>
    /// 关联订单 Id
    /// </summary>
    public long OrderId { get; private set; } = default!;

    /// <summary>
    /// 订单类型
    /// </summary>
    public OrderType OrderType { get; private set; } = default!;

    /// <summary>
    /// 签名类型
    /// </summary>
    public SignType SignType { get; private set; } = SignType.Unknown;

    /// <summary>
    /// 签名内容
    /// </summary>
    public string Content { get; private set; } = string.Empty;

    /// <summary>
    /// 签名时间
    /// </summary>
    public DateTime SignTime { get; private set; } = DateTime.MinValue;

    /// <summary>
    /// 是否已删除
    /// </summary>
    public bool Deleted { get; private set; } = false;

    /// <summary>
    /// 创建签名记录
    /// </summary>
    public static SignRecord Create(
        AgentTaskId taskId,
        long orderId,
        OrderType orderType,
        SignType signType
    )
    {
        var record = new SignRecord
        {
            AgentTaskId = taskId,
            OrderId = orderId,
            SignType = signType,
            OrderType = orderType,
            SignTime = DateTime.Now
        };
        return record;
    }
}
