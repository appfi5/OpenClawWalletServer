using OpenClawWalletServer.Domain.DomainEvents;
using NetCorePal.Extensions.Domain;

namespace OpenClawWalletServer.Domain.AggregatesModel.AgentConfigAggregate;

/// <summary>
/// Agent 配置 Id
/// </summary>
public partial record AgentConfigId : IInt64StronglyTypedId;

/// <summary>
/// Agent 配置
/// </summary>
public class AgentConfig : Entity<AgentConfigId>, IAggregateRoot
{
    protected AgentConfig()
    {
    }

    /// <summary>
    /// 服务端 Url
    /// </summary>
    public string ServerUrl { get; private set; } = string.Empty;

    /// <summary>
    /// Agent 唯一标识
    /// </summary>
    public string Code { get; private set; } = string.Empty;

    /// <summary>
    /// 服务端分配的访问 Token
    /// </summary>
    public string Token { get; private set; } = string.Empty;

    /// <summary>
    /// 是否被删除
    /// </summary>
    public bool Deleted { get; private set; } = false;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.MinValue;

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateAt { get; private set; } = DateTime.MinValue;

    /// <summary>
    /// 创建 Agent 配置
    /// </summary>
    public static AgentConfig Create(
        string serverUrl,
        string token
    )
    {
        var config =  new AgentConfig
        {
            ServerUrl = serverUrl,
            Code = Guid.NewGuid().ToString("N"),
            Token = token,
            Deleted = false,
            CreatedAt = DateTime.Now,
            UpdateAt = DateTime.Now,
        };
        config.AddDomainEvent(new AgentConfigChangedDomainEvent(config));
        return config;
    }

    /// <summary>
    /// 配置 Agent
    /// </summary>
    public void Config(string serverUrl, string token)
    {
        ServerUrl = serverUrl;
        Token = token;
        UpdateAt = DateTime.Now;
        AddDomainEvent(new AgentConfigChangedDomainEvent(this));
    }
}
