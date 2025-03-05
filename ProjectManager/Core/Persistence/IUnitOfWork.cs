using Persistence.Abstarcts;

namespace Persistence;

public interface IUnitOfWork : PersistenceSeedworks.IUnitOfWork
{
    ICaptchaRepository CaptchaRepository { get; }
}