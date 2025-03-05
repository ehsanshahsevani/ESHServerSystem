using System.ComponentModel.DataAnnotations;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// جدول میانی ارتباط بین صفحات هر حدول و عملیاتهای آن صفحه
/// </summary>
public class SubSystemPageOpration : BaseEntity
{
#pragma warning disable CS8618, CS9264
    public SubSystemPageOpration()
#pragma warning restore CS8618, CS9264
    {
    }
    
    // **************************************************
    /// <summary>
    /// ارتباط بین صفحه و رول
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserRoleSubSystemPage))]
    
    [Required(
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.RequiredError))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string UserRoleSubSystemPageId { get; set; }
    
    /// <summary>
    /// صفحه
    /// </summary>
    public UserRoleSubSystemPage? UserRoleSubSystemPage { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// عملیات های صفحه
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
    
    public string OprationPageId { get; set; }
    
    /// <summary>
    /// عملیات های صفحه
    /// </summary>
    public OprationPage? OprationPage { get; set; }
    // **************************************************
    
}