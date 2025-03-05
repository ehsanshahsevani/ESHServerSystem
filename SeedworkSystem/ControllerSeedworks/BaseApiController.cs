using DomainSeedworks.Log;
using Microsoft.AspNetCore.Http;
using SampleResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersistenceSeedworks;
using PersistenceSeedworks.LogManager;
using Utilities;

namespace ControllerSeedworks;

[ApiController]
[Route(template: "[controller]")]
public abstract class BaseApiController : ControllerBase
{
    public HttpClient HttpClient { get; }
    public IConfiguration Configuration { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ILogDetailManager LogDetailManager { get; }
    public ILogServerManager LogServerManager { get; }

    public BaseApiController(
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork,
        ILogDetailManager logDetailManager, ILogServerManager logServerManager)
    {
        HttpClient = httpClient;
        Configuration = configuration;
        HttpContextAccessor = httpContextAccessor;
        UnitOfWork = unitOfWork;
        LogDetailManager = logDetailManager;
        LogServerManager = logServerManager;
    }
    
    // Overload
    // **************************************************
    [NonAction]
    protected IActionResult FluentResult<TResult>(FluentResults.Result<TResult> result)
    {
        var res =
            result.ConvertToSampleResult();

        if (res.IsSuccess)
        {
            return Ok(res);
        }
        else
        {
            return BadRequest(res);
        }
    }
    // **************************************************

    // **************************************************
    [NonAction]
    protected IActionResult FluentResult(FluentResults.Result result)
    {
        var res =
            result.ConvertToSampleResult();

        if (res.IsSuccess)
        {
            return Ok(res);
        }
        else
        {
            return BadRequest(res);
        }
    }
    // **************************************************
    
    // **************************************************
    [NonAction]
    public async Task SaveAsync()
    {
        // var token = GetTokenDetail();

        var date = DateTime.Now;

        var detailsLog = new LogDetail()
        {
            // UserId = token.UserId,
            // Token_JWT = token.Token,

            RemoteIP = HttpContext.Connection.RemoteIpAddress?.ToString(),

            PortIP = HttpContext.Connection.RemotePort.ToString(),
			
            HttpReferrer = HttpContext.Request.Headers["Referer"].ToString(),

            IsDeleted = false,

            RequestPath = HttpContext.Request.Path,

            Description = $"{date.ToShamsi(1)} - {date.ToString("HH:mm:ss")} - {date.ToShamsi()}",
        };
        
        await LogDetailManager.CreateAsync(detailsLog);
        
        await UnitOfWork.SaveAsync();
    }
    // **************************************************
}