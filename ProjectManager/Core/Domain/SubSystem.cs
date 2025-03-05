using DomainSeedworks;

namespace Domain;
/// <summary>
/// جدوال موجود در سیستم
/// </summary>
public class SubSystem : BaseEntityWithName
{
    public SubSystem() :base()
    {
        SubSystemPage = new List<SubSystemPage>();
    }
    
    public List<SubSystemPage> SubSystemPage { get; set; }
}