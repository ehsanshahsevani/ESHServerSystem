using System.ComponentModel.DataAnnotations;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// کپچا - کد اعتبارسنجی
/// </summary>
public class Captcha : BaseEntityWithName
{
#pragma warning disable CS8618, CS9264
    public Captcha() : base()
#pragma warning restore CS8618, CS9264
    {
    }

    // **************************************************
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.User))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? UserId { get; set; }
    
    /// <summary>
    /// کاربر
    /// </summary>
    public User? User { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// آدرس آی پی
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IpAddress))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]

    [MaxLength(
        length: Constants.MaxLength.IP,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string IpAddress { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// کد امنیتی
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Captcha))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]

    [MaxLength(
        length: Constants.MaxLength.Captcha,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string CaptchaText { get; set; }
    // **************************************************

    // **************************************************
    /// <summary>
    /// بخشی که برایش کپتچا نیاز است
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.SubSystemPage))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]

    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string SubSystemPageId { get; set; }
    // **************************************************
}