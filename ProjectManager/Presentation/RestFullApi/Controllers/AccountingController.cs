using Domain;
using SkiaSharp;
using ViewModels;
using AutoMapper;
using ControllerSeedworks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Persistence;
using PersistenceSeedworks.LogManager;
using RestFullApi.Infrastructure.Filters.FilterActions;
using IUnitOfWork = PersistenceSeedworks.IUnitOfWork;

namespace RestFullApi.Controllers;

public class AccountingController : BaseApiIdentityController<User, Role>
{
    #region DI Settings & Constructor

    public Persistence.IUnitOfWork UnitOfWork { get; }

    public AccountingController(
        IMapper mapper,
        Persistence.IUnitOfWork unitOfWork,
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        SignInManager<User> signInManager,
        ILogDetailManager logDetailManager,
        ILogServerManager logServerManager) :
        base(mapper, unitOfWork, httpClient, configuration, httpContextAccessor,
        userManager, roleManager, signInManager, logDetailManager, logServerManager)
    {
        UnitOfWork = unitOfWork;
    }

    #endregion

    #region GET : /
    
    /// <summary>
    /// ورود به سیستم
    /// </summary>
    /// <param name="numberPhone">شماره تلفن</param>
    /// <param name="captchaCode">کد امنیتی</param>
    /// <returns></returns>
    
    [HttpGet]
    [ServiceFilter<LoginFilterAction>]
    public IActionResult Login(string numberPhone, string captchaCode)
    {
        var result = new FluentResults.Result();

        return FluentResult(result);
    }

    #endregion

    #region POST : /

    [HttpPost]
    public async Task<IActionResult> SendOtp(
        string mobileNumber, string captha, string userRoleSubSystemPageId)
    {
        // if (model.capcha != captha)
        // {
        //     return BadRequest("Invalid capcha");
        // }

        var ipAddress =
            HttpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

        // var  captcha= UnitOfWork.CaptchaRepository
        //     .Find(p=> p.CaptchaText==captha && 
        //               p.CreateDateTime>=DateTime.Now.AddMinutes(-2) &&
        //               p.IpAddress == ipAddress &&
        //               p.UserRoleSubSystemPageId == userRoleSubSystemPageId );
        // if (captcha == null)
        // {
        //     return BadRequest("Invalid capcha");
        // }

        var user =
            await UserManager.FindByNameAsync(mobileNumber);
        
        if (user == null)
        {
            user = new User
            {
                PhoneNumber = mobileNumber,
                UserName = mobileNumber,
            };
            
            await UserManager.CreateAsync(user);
        }

        var rand = new Random((int)DateTime.Now.Ticks);
        var randomNumber = rand.Next(100000, 999999);
        user.OtpCode = randomNumber.ToString();
        await UserManager.UpdateAsync(user);

        //Send OTP With SMS

        return Ok();
    }

    #endregion

    #region GET : profile/{userId}

    [HttpGet(template: "profile/{userId}")]
    [ServiceFilter<CheckEntityUserIdFilterAction>]
    public IActionResult GetProfile(string? userId)
    {
        var result = new FluentResults.Result<object>();

        var user =
            HttpContext.Items[Constants.ProjectKeyName.ObjectKey] as User;

        var profile =
            Mapper.Map<MarketPlaceProfileViewModel>(user!.MarketPlaceProfile);

        result.WithValue(profile);

        return FluentResult(result);
    }

    #endregion

    #region GET : verify-opt
    
    [HttpGet(template: "verify-opt")]
    public IActionResult VerifyOtp()
    {
        return Ok();
    }
    
    #endregion

    #region POST : /verify-opt-confirm

    [HttpPost(template: "verify-opt-confirm")]
    public async Task<IActionResult> VerifyOtpConfirm(string mobileNumber, string otpCode)
    {
        var user =
            await UserManager.FindByNameAsync(mobileNumber);

        if (user == null)
        {
            return BadRequest("Invalid mobile number");
        }

        if (user.OtpCode != otpCode)
        {
            return BadRequest("Invalid OTP Code");
        }

        await SignInManager.SignOutAsync();

        return Ok();
    }

    #endregion

    #region POST : captcha-image

    [HttpPost(template: "captcha-image")]
    public async Task<IActionResult> CaptchaImage(string userRoleSubSystemPageId)
    {
        var rand = new Random((int)DateTime.Now.Ticks);
        var randomNumber = rand.Next(100000, 999999);
        var stringRandomNumber = string.Format("{0}", randomNumber).ToString();

        FileContentResult? captchaImage = null;

        using (var memory = new MemoryStream())
        {
            var info = new SKImageInfo(96, 30);
            using (var surface = SKSurface.Create(info))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                for (var i = 0; i < 10; i++)
                {
                    var paint = new SKPaint
                    {
                        Color = new SKColor(
                            (byte)rand.Next(0, 255),
                            (byte)rand.Next(0, 255),
                            (byte)rand.Next(0, 255)),
                        IsStroke = true
                    };

                    var r = rand.Next(0, 96 / 3);
                    var x = rand.Next(0, 96);
                    var y = rand.Next(0, 30);

                    canvas.DrawCircle(x, y, r, paint);
                }

                var textPaint = new SKPaint
                {
                    Color = SKColors.Gray,
#pragma warning disable CS0618 // Type or member is obsolete
                    TextSize = 18,
#pragma warning restore CS0618 // Type or member is obsolete
                    IsAntialias = true
                };

                //canvas.DrawText(stringRandomNumber, 2, 25,textPaint);
                canvas.DrawText(stringRandomNumber, 2, 25, SKTextAlign.Center, new SKFont(SKTypeface.Default),
                    textPaint);

                using var snapshot = surface.Snapshot();
                using var data = snapshot.Encode(SKEncodedImageFormat.Jpeg, 100);
                data.SaveTo(memory);
                captchaImage = File(memory.ToArray(), "image/jpeg");
            }
        }

        var ipAddress =
            HttpContextAccessor.HttpContext?
                .Connection.RemoteIpAddress?.ToString();

        var captcha = new Captcha
        {
            CaptchaText = stringRandomNumber,
            IpAddress = ipAddress!,
            // UserRoleSubSystemPageId = userRoleSubSystemPageId
        };

        await UnitOfWork.CaptchaRepository.AddAsync(captcha);
        await UnitOfWork.SaveAsync();

        return captchaImage;
    }

    #endregion
}