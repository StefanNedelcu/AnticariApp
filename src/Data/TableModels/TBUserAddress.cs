#nullable disable

namespace AnticariApp.Data.TableModels;

public partial class TBUserAddress
{
    public long IdUserAddress { get; set; }
    public long IdUser { get; set; }
    public long IdCity { get; set; }
    public string StreetName { get; set; }
    public int? StreetNumber { get; set; }
    public string ZipCode { get; set; }

    public virtual TBCity IdCityNavigation { get; set; }
    public virtual TBUser IdUserNavigation { get; set; }
}
