using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// شهر
/// </summary>
public class City : BaseEntityWithName
{
#pragma warning disable CS8618, CS9264
    public City() : base()
#pragma warning restore CS8618, CS9264
    {
    }

    // *********************************************
    /// <summary>
    /// استان
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ProvinceLbl))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    
    public string ProvinceId { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    public Province? Province { get; set; }
    // *********************************************
}