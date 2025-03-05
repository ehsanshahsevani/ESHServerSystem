using System.ComponentModel.DataAnnotations;
using Utilities;

namespace ViewmodelSeedworks;

public class BaseEntityViewModel : BaseEmptyViewModel
{
#pragma warning disable CS8618, CS9264
    public BaseEntityViewModel() : base()
#pragma warning restore CS8618, CS9264
    {
        IsActive = true;
        Ordering = Constants.MaxValue.Ordering;
    }

    /// <summary>
    /// شناسه دیتابیس
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Guid))]
    
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

    public DateTime UpdateDateTime { get; protected set; }

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
    /// ترتیب نمایش
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Order))]

    public int Ordering { get; set; }
    
    // **************************************************
    public string CreateTime => $"{CreateDateTime.TimeOfDay.Hours}:{CreateDateTime.TimeOfDay.Minutes}";

    public string CreateDateShamsi => CreateDateTime.ToShamsi(1);
    
    public string UpdateTime => $"{UpdateDateTime.TimeOfDay.Hours}:{UpdateDateTime.TimeOfDay.Minutes}";

    public string UpdateDateShamsi => UpdateDateTime.ToShamsi(1);
    // **************************************************
}
