using NetCorePal.Extensions.Primitives;
using SupeRISELocalServer.Infrastructure.Repositories;

namespace SupeRISELocalServer.Application.Commands.KeyConfigCommands;

/// <summary>
/// 删除KeyConfig命令
/// </summary>
public class DeleteKeyConfigCommand : ICommand<bool>
{
    /// <summary>
    /// 地址
    /// </summary>
    public required string Address { get; set; }
}

/// <summary>
/// 删除KeyConfig命令处理器
/// </summary>
public class DeleteKeyConfigCommandHandler(
    KeyConfigRepository keyConfigRepository
) : ICommandHandler<DeleteKeyConfigCommand, bool>
{
    public async Task<bool> Handle(DeleteKeyConfigCommand command, CancellationToken cancellationToken)
    {
        var keyConfig = await keyConfigRepository.FindByAddress(command.Address, cancellationToken);
        if (keyConfig == null)
        {
            throw new KnownException("KeyConfig not found");
        }

        keyConfig.Delete(); // 软删除

        return true;
    }
}