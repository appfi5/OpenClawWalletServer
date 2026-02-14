using FastEndpoints;
using MediatR;
using NetCorePal.Extensions.Dto;
using SupeRISELocalServer.Extensions;
using SupeRISELocalServer.Application.Queries;
using SupeRISELocalServer.Domain.Enums;

namespace SupeRISELocalServer.Endpoints.UI.KeyConfigEndpoints;

/// <summary>
/// KeyConfig 列表 Endpoint
/// </summary>
[Tags("UI")]
[HttpGet("api/v1/ui/key-config/list")]
public class KeyConfigListEndpoint(
    IMediator mediator
) : EndpointWithoutRequest<ResponseData<List<KeyConfigListItem>>>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = (await mediator.Send(new AllKeyConfigQuery(), ct))
            .Select(info => new KeyConfigListItem
            {
                Address = info.Address,
                PublicKey = info.PublicKey,
                AddressType = info.AddressType,
            })
            .ToList();
        
        await Send.OkAsync(result.AsSuccessResponseData(), ct);
    }
}

/// <summary>
/// KeyConfig 列表项
/// </summary>
public class KeyConfigListItem
{
    /// <summary>
    /// 签名类型
    /// </summary>
    public required AddressType AddressType { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// 公钥
    /// </summary>
    public required string PublicKey { get; set; }
}