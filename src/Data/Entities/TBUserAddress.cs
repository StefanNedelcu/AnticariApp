#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBUserAddress
{
    public long IdUserAddress { get; set; }
    public long IdUser { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string StreetName { get; set; }
    public int? StreetNumber { get; set; }
    public string ZipCode { get; set; }

    public virtual TBUser User { get; set; }
}
