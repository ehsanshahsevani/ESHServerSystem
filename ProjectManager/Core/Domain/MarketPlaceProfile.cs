using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// پروفایل کاربر در مارکت پلیس
/// </summary>
public class MarketPlaceProfile : BaseEntityWithName
{
#pragma warning disable CS8618, CS9264
    public MarketPlaceProfile():base()
#pragma warning restore CS8618, CS9264
    {
    }
    
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
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string UserId { get; set; }

    /// <summary>
    /// کاربر
    /// </summary>
    public User? User { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نام کاربر
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.UserName))]
    
    [MaxLength(
        length: Constants.MaxLength.Username,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? DisplayName { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// جنسیت
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Gender))]
    
    [MaxLength(
        length: Constants.FixedLength.Guid,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? GenderId { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public Gender? Gender { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// نام شغل
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.JobPost))]
    
    [MaxLength(
        length: Constants.MaxLength.FullName,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? JobString { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// تاریخ تولد
    /// </summary>

    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.BirhtDate))]
    
    public DateTime? BirthDate { get; set; }
    // *********************************************
    
    // *********************************************
    /// <summary>
    /// شماره شبا
    /// </summary>
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Shaba))]
    
    [MaxLength(
        length: Constants.MaxLength.ShabaNumber,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.MaxLengthError))]
    
    public string? Shaba { get; set; }
    // *********************************************
}