using Microsoft.EntityFrameworkCore;
using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using OpenClawWalletServer.Domain.AggregatesModel.SignRecordAggregate;

namespace OpenClawWalletServer.Infrastructure.Repositories;

/// <summary>
/// 签名记录仓储
/// </summary>
public class SignRecordRepository(
    ApplicationDbContext context
) : RepositoryBase<SignRecord, SignRecordId, ApplicationDbContext>(context)
{
    /// <summary>
    /// 通过任务 Id 查询签名记录
    /// </summary>
    public async Task<SignRecord?> FindByTaskIdOrDefault(AgentTaskId taskId, CancellationToken cancellationToken)
    {
        return await context.SignRecords
            .Where(record => record.AgentTaskId == taskId &&
                             !record.Deleted)
            .FirstOrDefaultAsync(cancellationToken);
    }
}