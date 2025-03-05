using Domain;
using Persistence.Abstarcts;

namespace Persistence.Repositories;

public class ProvinceRepository: Repository<Province> , IProvinceRepository
{
    internal ProvinceRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}