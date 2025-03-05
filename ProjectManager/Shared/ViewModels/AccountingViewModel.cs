using System.ComponentModel.DataAnnotations;
using ViewmodelSeedworks;

namespace ViewModels;

public class AccountingViewModel : BaseEmptyViewModel
{
    // **************************************************
    /// <summary>
    /// شماره موبایل
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.PhoneNumber))]
    
    [StringLength(
        maximumLength: 11,
        MinimumLength = 11,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.FixedLengthError))]
    
    [RegularExpression(
        pattern: Constants.RegularExpression.CellPhoneNumber,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.FixedLengthError))]
    
    public string? PhoneNumber { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// کد یکبار مصرف
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.OptCode))]
    
    [StringLength(
        maximumLength: 5,
        MinimumLength = 5,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.FixedLengthError))]
    
    public string? OtpCode { get; set; }
    // **************************************************
    
    // **************************************************
    /// <summary>
    /// کد امنیتی
    /// </summary>
    
    [Display(
        ResourceType = typeof(Resources.DataDictionary),
        Name = nameof(Resources.DataDictionary.Captha))]
    
    [StringLength(
        maximumLength: 5,
        MinimumLength = 5,
        ErrorMessageResourceType = typeof(Resources.Messages),
        ErrorMessageResourceName = nameof(Resources.Messages.FixedLengthError))]
    
    public string? Captha { get; set; }
    // **************************************************
}
