using DomainSeedworks;

namespace Domain;
/// <summary>
/// عملیات هایی موجود در صفحات
/// </summary>
public class OprationPage : BaseEntityWithName
{
    public OprationPage()
    {
        SubSystemPageOprations = new List<SubSystemPageOpration>();
    }
    
    public List<SubSystemPageOpration> SubSystemPageOprations { get; set; }
}