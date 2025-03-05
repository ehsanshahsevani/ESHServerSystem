using System.ComponentModel.DataAnnotations;
using ViewmodelSeedworks;

namespace ViewModels;

public class NotificationTypeViewModel: BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public NotificationTypeViewModel()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // *********************************************    
    /// <summary>
    /// عنوان
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Title))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string Title { get; set; }
    // *********************************************

    // *********************************************    
    /// <summary>
    /// عمومی
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsPublic))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool IsPublic { get; set; }
    // *********************************************
}