using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViewmodelSeedworks;

namespace ViewModels;

public class NotificationViewModel : BaseEntityViewModelWithImage
{
#pragma warning disable CS8618, CS9264
    public NotificationViewModel()
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
    /// قابلیت ارسال در لحظه
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.SendNowFeature))]
    public bool? SendNowFeature { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// وضعیت ارسال به فایربیس
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.SendToFirebase))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool SendToFireBase { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نمایش در نرم افزار موبایل
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ShowInApp))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool ShowInApp { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نمایش در سامانه
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ShowInWeb))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public bool ShowInWeb { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// آدرس مربوط به اعلان
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.NotificationUrl))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string NotificationUrl { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نقش های انتخاب شده
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.RolesSelectedByAdmin))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string RolesSelectedByAdmin { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// زمان ارسال
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.SendDate))]
    public DateTime? SendDateTime { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نوع اعلان
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.NotificationType))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string NotificationTypeId { get; set; }
    /// <summary>
    /// نوع اعلان
    /// </summary>
    public NotificationTypeViewModel? NotificationTypeViewModel { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// کاربر ذخیره کننده
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.User))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    public string SavedByUserId { get; set; }
    /// <summary>
    /// کاربر ذخیره کننده
    /// </summary>
    public UserViewModel? UserViewModel { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تعداد کاربر
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserCount))]
    public int UserCount { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تعداد اعلانات ارسال شده
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.DeliveredCount))]
    public int DeliveredCount { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تعداد کلیک های سامانه
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ClickedOnWebCount))]
    public int ClickedOnWebCount { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تعداد کلیک های نرم افزار موبایل
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ClickedOnAppCount))]
    public int ClickedOnAppCount { get; set; }
    // *********************************************
}