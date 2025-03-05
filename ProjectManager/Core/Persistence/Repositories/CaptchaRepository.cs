using Domain;
using Persistence.Abstarcts;

namespace Persistence.Repositories;

public class CaptchaRepository : Repository<Captcha> , ICaptchaRepository
{
    internal CaptchaRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
    
}