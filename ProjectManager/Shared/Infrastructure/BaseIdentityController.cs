using Domain;
using AutoMapper;
using Persistence;
using ControllerSeedworks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PersistenceSeedworks.LogManager;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class BaseIdentityController : BaseApiIdentityController<Domain.User, Domain.Role>
{
    public IUnitOfWork UnitOfWork { get; }

    public BaseIdentityController(IMapper mapper, IUnitOfWork unitOfWork, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, ILogDetailManager logDetailManager, ILogServerManager logServerManager) : base(mapper, unitOfWork, httpClient, configuration, httpContextAccessor, userManager, roleManager, signInManager, logDetailManager, logServerManager)
    {
        UnitOfWork = unitOfWork;
    }
}