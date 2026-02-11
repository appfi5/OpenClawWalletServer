using Microsoft.EntityFrameworkCore;
using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using OpenClawWalletServer.Domain.AggregatesModel.SendTransactionRecordAggregate;

namespace OpenClawWalletServer.Infrastructure.Repositories;

public class SendTransactionRecordRepository(
    ApplicationDbContext context
) : RepositoryBase<SendTransactionRecord, SendTransactionRecordId, ApplicationDbContext>(context)
{
    public async Task<SendTransactionRecord?> FindByTaskIdOrDefault(AgentSendTransactionTaskId agentSendTransactionTaskId, CancellationToken cancellationToken)
    {
        return await context.SendTransactionRecords
            .Where(record => record.AgentSendTransactionTaskId == agentSendTransactionTaskId &&
                             !record.Deleted)
            .FirstOrDefaultAsync(cancellationToken);
    }
}