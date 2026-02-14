using NetCorePal.Extensions.Repository.EntityFrameworkCore;
using SupeRISELocalServer.Domain.AggregatesModel.LoginPasswordAggregate;

namespace SupeRISELocalServer.Infrastructure.Repositories;

/// <summary>
/// 登录密码仓储
/// </summary>
public class LoginPasswordRepository(
    ApplicationDbContext context
) : RepositoryBase<LoginPassword, LoginPasswordId, ApplicationDbContext>(context)
{
    public async Task<LoginPassword?> FirstOrDefault()
    {
        return context.LoginPasswords.FirstOrDefault(password => !password.Deleted);
    }
}