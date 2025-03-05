using System.Linq.Expressions;
using Domain;

namespace Persistence.Abstarcts;

public interface ICaptchaRepository 
{
    Task AddAsync(Captcha? entity, CancellationToken cancellationToken = default);
    Task RemoveAsync(Captcha? entity, CancellationToken cancellationToken = default);
    Task RemoveRangeAsync(IEnumerable<Captcha?> entities, CancellationToken cancellationToken = default);
    Task<IEnumerable<Captcha?>> Find(Expression<Func<Captcha?, bool>> predicate, CancellationToken cancellationToken = default);
}
