using System.ComponentModel.DataAnnotations;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// صفحات موجود برای هر جدول
/// </summary>
public class SubSystemPage : BaseEntityWithName
{
#pragma warning disable CS8618, CS9264
    public SubSystemPage()
#pragma warning restore CS8618, CS9264
    {
        UserRoleSubSystemPages = new List<UserRoleSubSystemPage>();
    }
    
    // **************************************************
    /// <summary>
    /// زیر سیستم - جدول - بخش
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.SubSystem))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string SubSystemId { get; set; }
    
    /// <summary>
    /// زیر سیستم
    /// </summary>
    public SubSystem? SubSystem { get; set; }
    // **************************************************
    
    // **************************************************
    public List<UserRoleSubSystemPage> UserRoleSubSystemPages { get; set; }
    // **************************************************
}