using Domain;
using Persistence.Abstarcts;

namespace Persistence.Repositories;

public class TokenManagerRepository: Repository<TokenManager> , ITokenManagerRepository
{
    internal TokenManagerRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}