using System.ComponentModel.DataAnnotations;

namespace ViewmodelSeedworks;

public class BaseEntityViewModelWithNameAndImage : BaseEntityViewModelWithName
{
    /// <summary>
    /// نام مستعار فایل
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.GuidName))]
    
    [MaxLength(
        Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public string? GuidName { get; set; }


    /// <summary>
    /// نام اصلی فایل
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.FileName))]
    
    [MaxLength(
        Constants.MaxLength.Link,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public string? FileName { get; set; }

    /// <summary>
    /// توضیحات کاملی درباره تصویر برای گوگل
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Alternative))]
    
    [MaxLength(
        Constants.MaxLength.Description,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? Alternative { get; set; }

    /// <summary>
    /// توضیحات تصویر برای زمانی که کاربر روی تصویر با موس ایستاد
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.ImageTitle))]
    
    [MaxLength(
        Constants.MaxLength.Title,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]

    public string? ImageTitle { get; set; }
}