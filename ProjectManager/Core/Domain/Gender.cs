using DomainSeedworks;

namespace Domain;

/// <summary>
/// جنسیت
/// </summary>
public class Gender : BaseEntityWithName
{
#pragma warning disable CS8618, CS9264
    public Gender() : base()
#pragma warning restore CS8618, CS9264
    {
        MarketPlaceProfiles = new List<MarketPlaceProfile>();
    }

    public List<MarketPlaceProfile> MarketPlaceProfiles { get; set; }
}