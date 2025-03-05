using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViewmodelSeedworks;

namespace ViewModels;

public class CityViewModel  : BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public CityViewModel()
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
    
    public ProvinceViewModel? ProvinceViewModel { get; set; }
    // *********************************************
    
}