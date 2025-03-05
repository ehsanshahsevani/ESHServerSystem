using System.ComponentModel.DataAnnotations;
using ViewmodelSeedworks;

namespace ViewModels;

public class UserNotificationViewModel : BaseEntityViewModel
{
#pragma warning disable CS8618, CS9264
    public UserNotificationViewModel()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // *********************************************
    /// <summary>
    /// ارسال شده
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsSend))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool IsSend { get; set; }
    // *********************************************

    // *********************************************
    /// <summary>
    /// وضعیت مشاهده شدن
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsSeen))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool IsSeen { get; set; }
    // *********************************************

    // *********************************************
    /// <summary>
    /// کلیک شدن
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsClicked))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool IsClicked { get; set; }
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

    // *********************************************
    /// <summary>
    /// اعلان
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Notification))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string NotificationId { get; set; }
    
    /// <summary>
    /// اعلان
    /// </summary>
    public NotificationViewModel? NotificationViewModel { get; set; }
    // *********************************************
}