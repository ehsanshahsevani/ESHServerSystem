using System.ComponentModel.DataAnnotations;

namespace DomainSeedworks;

public class BaseEntity : object
{
    public BaseEntity() : base()
    {
        Id = Guid.NewGuid().ToString();
        
        CreateDateTime = DateTime.Now;
        UpdateDateTime = DateTime.Now;
        
        IsActive = true;
        IsDeleted = false;
        Ordering = Constants.MaxValue.Ordering;
    }

    /// <summary>
    /// شناسه دیتابیس
    /// </summary>
    
    // [Key]

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
    
    public string Id { get; private set; }

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
}