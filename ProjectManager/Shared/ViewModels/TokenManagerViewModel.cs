using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViewmodelSeedworks;

namespace ViewModels;

public class TokenManagerViewModel: BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public TokenManagerViewModel()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // *********************************************
    /// <summary>
    /// توکن
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.TokenFA))]
    public string Token { get; set; }
    // *********************************************
    
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
    
}