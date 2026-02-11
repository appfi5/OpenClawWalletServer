namespace OpenClawWalletServer.Domain.Enums;

/// <summary>
/// 订单类型
/// </summary>
public enum OrderType
{
    /// <summary>
    /// 未知
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// C 端兑换订单
    /// </summary>
    ConsumerExchange = 1,
    
    /// <summary>
    /// B 端资金流出订单
    /// </summary>
    BusinessCashOut = 2,
    
    /// <summary>
    /// 返还 CKB
    /// </summary>
    ReturnCkb = 3,
}