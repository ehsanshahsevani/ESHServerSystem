using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainSeedworks;

namespace Domain;
/// <summary>
/// استان
/// </summary>
public class Province:BaseEntityWithName
{
    public Province():base()
    {
        Cities = new List<City>();
    }
    
    public List<City> Cities { get; set; }
    
}