using System.ComponentModel.DataAnnotations;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Identity;

namespace Domain;

/// <summary>
/// کاربرها
/// </summary>
public class User : IdentityUser<string>
{
#pragma warning disable CS8618, CS9264
    public User() : base()
#pragma warning restore CS8618, CS9264
    {
        Id = Guid.NewGuid().ToString();

        CreateDateTime = DateTime.Now;
        UpdateDateTime = DateTime.Now;

        IsActive = true;
        IsDeleted = false;
        Ordering = Constants.MaxValue.Ordering;

        Captchas = new List<Captcha>();
    }

    // **************************************************
    /// <summary>
    /// شناسه دیتابیس
    /// </summary>

    [Key]
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Guid))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public override string Id { get; set; }
    // **************************************************

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.CreateDate))]

    public DateTime CreateDateTime { get; private set; }

    /// <summary>
    /// تاریخ بروزرسانی
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UpdateDate))]

    public DateTime UpdateDateTime { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Description))]

    public string? Description { get; set; }

    /// <summary>
    /// فعال بودن یا نبودن
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.IsActive))]

    public bool IsActive { get; set; }

    /// <summary>
    /// وضیعت حذف
    /// </summary>

    public bool IsDeleted { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Order))]

    public int Ordering { get; set; }

    // **************************************************
    /// <summary>
    /// کد یکبار مصرف
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.OptCode))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    [MaxLength(
        length: Constants.MaxLength.OptCode,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public string OtpCode { get; set; }
    // **************************************************

    // **************************************************
    /// <summary>
    /// پروفایل کاربر در بخش فروشگاه
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.User))]
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public string MarketPlaceProfileId { get; set; }

    // **************************************************
    /// <summary>
    /// پروفایل کاربر در بخش فروشگاه
    /// </summary>
    public MarketPlaceProfile MarketPlaceProfile { get; set; }
    // **************************************************

    // **************************************************
    public List<Captcha> Captchas { get; set; }
    // **************************************************
}