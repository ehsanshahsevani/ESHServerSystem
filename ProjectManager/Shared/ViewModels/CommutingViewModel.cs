using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;
using ViewmodelSeedworks;

namespace ViewModels;

public class CommutingViewModel  : BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public CommutingViewModel()
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
    /// نوع فعالیت
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.CommutingType))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public CommutingType CommutingType { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// توکن
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.TokenFA))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string Token { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// کد OTP
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.OptCode))]
    public string? OptCode { get; set; }
    // *********************************************
    
}