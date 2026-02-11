using Nethereum.Hex.HexTypes;

namespace OpenClawWalletServer.Domain.Dto;

/// <summary>
/// Eth 发送交易 Dto
/// </summary>
public class EthSendTransactionDto
{
    /// <summary>
    /// Gas
    /// </summary>
    public HexBigInteger Gas { get; set; } = new HexBigInteger(0);

    /// <summary>
    /// 交易Hash
    /// </summary>
    public string TxHash { get; set; } = "0x";
    
}
