using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViewmodelSeedworks;

namespace ViewModels;

public class MarketPlaceProfileViewModel : BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public MarketPlaceProfileViewModel()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // *********************************************
    /// <summary>
    /// کاربر
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.User))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string UserId { get; set; }
    /// <summary>
    /// کاربر
    /// </summary>
    public UserViewModel? UserViewModel { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نام کاربر
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserName))]
    public string? DisplayName { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// جنسیت
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Gender))]
    public string? GenderId { get; set; }
    /// <summary>
    /// جنسیت
    /// </summary>
    public GenderViewModel? GenderViewModel { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نام شغل
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.JobPost))]
    public string? JobString { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تاریخ تولد
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.BirhtDate))]
    public DateTime? BirthDate { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// شماره شبا
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Shaba))]
    public string? Shaba { get; set; }
    // *********************************************
    
}