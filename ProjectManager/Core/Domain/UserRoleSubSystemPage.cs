using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// ارتباط هر نقش و صفحه های هر جدول
/// </summary>
public class UserRoleSubSystemPage : BaseEntity
{
#pragma warning disable CS8618, CS9264
    public UserRoleSubSystemPage()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // **************************************************
    /// <summary>
    /// شناسه کاربر با یک نقش خاص
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserRole))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string UserId { get; set; }
    
    
    /// <summary>
    /// شناسه کاربر با یک نقش خاص
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserRole))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string RoleId { get; set; }
    
    /// <summary>
    /// کاربر با نقش
    /// </summary>

    public UserRole? UserRole { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// زیر سیستم صفحه
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
    
    /// <summary>
    /// زیر سیستم صفحه
    /// </summary>
    public SubSystemPage? SubSystemPage { get; set; }
    // **************************************************
    
    
    // **************************************************
    public List<SubSystemPageOpration> SubSystemPageOprations { get; set; }
    // **************************************************
}