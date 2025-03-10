using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstarcts;
using Persistence.ModelParameters;
using RequestFeatures;
using Utilities;

namespace Persistence.Repositories;

public class MarketPlaceProfileRepository: Repository<MarketPlaceProfile> , IMarketPlaceProfileRepository
{
    internal MarketPlaceProfileRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }
    
    public async Task<PagedList<MarketPlaceProfile>> GetAllInPageAsync(
        RequestParameter requestParameters
        ,CancellationToken cancellationToken = default)
    {
        var date = requestParameters.Text.StringToDateTimeMiladi();

        var monthNumberShamsi =
            requestParameters.Text.ChangeMonthNameShamsiToNumberMonth();

        int? monthNumberMiladi = null;

        if (monthNumberShamsi.HasValue == true)
        {
            var dateString = $"1403/{monthNumberShamsi.Value.ToString().PadLeft(2, '0')}/01";

            monthNumberMiladi = dateString.StringToDateTimeMiladi()!.Value.Month;
        }

        var source = DbSet
            .Include(x => x.User)
            .Include(x => x.Gender)
            .Where(current => current.IsActive)
            .Where(current =>
                string.IsNullOrEmpty(requestParameters.Text)
                || current.DisplayName.Contains(requestParameters.Text)
                || current.JobString.Contains(requestParameters.Text)
                || current.Shaba.Contains(requestParameters.Text)
                || current.Description.Contains(requestParameters.Text)
                ||
                (
                    !string.IsNullOrEmpty(current.User!.UserName)
                    && current.User.UserName.Contains(requestParameters.Text)
                )
                || current.User.PhoneNumber.Contains(requestParameters.Text))

            .Where(current =>
                !date.HasValue
                || (current.CreateDateTime == date.Value)
                || current.CreateDateTime == date.Value
                
                || !monthNumberMiladi.HasValue
                || (current.CreateDateTime.Month == monthNumberMiladi.Value)
                || current.CreateDateTime.Month == monthNumberMiladi.Value
                || (current.BirthDate.HasValue == true &&
                    current.BirthDate == date.Value 
                || current.BirthDate.Value.Month == monthNumberMiladi.Value
                || current.BirthDate.Value.Month == monthNumberMiladi.Value))

            .OrderBy(o => o.Ordering)
            .ThenByDescending(p => p.CreateDateTime);
            
        var result = await PagedList
            <MarketPlaceProfile>.ToPagedList(source, requestParameters);
        
        return result;
    }
}