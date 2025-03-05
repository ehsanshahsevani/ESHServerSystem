using Domain;
using Persistence.Abstarcts;

namespace Persistence.Repositories;

public class CityRepository: Repository<City> , ICityRepository
{
    internal CityRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}