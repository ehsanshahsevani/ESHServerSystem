using AutoMapper;
using ControllerSeedworks;
using Domain;
using Microsoft.AspNetCore.Identity;
using PersistenceSeedworks;
using PersistenceSeedworks.LogManager;
using IUnitOfWork = Persistence.IUnitOfWork;

namespace RestFullApi.Controllers;

public class MarketPlaceProfileController :
    BaseApiIdentityController<Domain.User, Domain.Role>
{
    public MarketPlaceProfileController(Mapper mapper, IUnitOfWork unitOfWork, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, ILogDetailManager logDetailManager, ILogServerManager logServerManager) : base(mapper, unitOfWork, httpClient, configuration, httpContextAccessor, userManager, roleManager, signInManager, logDetailManager, logServerManager)
    {
    }
}