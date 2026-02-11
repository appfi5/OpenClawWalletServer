namespace OpenClawWalletServer.Domain.Dto;

public class EthSafeWalletTransactionDto
{
    /// <summary>
    /// 交易To地址
    /// </summary>
    public string ToAddress { get; set; } = default!;

    /// <summary>
    /// 交易Value
    /// </summary>
    public ulong Value { get; set; } = 0;
    
    /// <summary>
    /// 交易Data-Hash
    /// </summary>
    public string Data { get; set; } = "0x";
    
    /// <summary>
    /// 操作 0:call 1:DelegateCall 
    /// </summary>
    public int Operation { get; set; } = 0;

    /// <summary>
    /// GasLimit
    /// </summary>
    public ulong SafeTxGas { get; set; } = 0;

    /// <summary>
    /// BaseGas
    /// </summary>
    public ulong BaseGas { get; set; } = 0;
    
    /// <summary>
    /// GasPrice
    /// </summary>
    public ulong GasPrice { get; set; } = 0;

    /// <summary>
    /// GasToken
    /// </summary>
    public string GasToken { get; set; } = "0x0000000000000000000000000000000000000000";
    
    /// <summary>
    /// RefundReceiver
    /// </summary>
    public string RefundReceiver { get; set; } = "0x0000000000000000000000000000000000000000";
    
    /// <summary>
    /// Nonce
    /// </summary>
    public ulong Nonce { get; set; } = 0;

    /// <summary>
    /// 未签名交易Hash
    /// </summary>
    public string UnSignTransactionTxHash { get; set; }  = "0x";
    
    /// <summary>
    /// 签名
    /// </summary>
    public string Signature { get; set; } = string.Empty;

    /// <summary>
    /// 实际收到金额 精度六位
    /// </summary> 
    public long Amount { get; set; }
    
    /// <summary>
    /// 收款地址
    /// </summary>
    public string ToAccountAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// 代币合约地址
    /// </summary>
    public string ERC20ContractAddress { get; set; } = string.Empty;
}
