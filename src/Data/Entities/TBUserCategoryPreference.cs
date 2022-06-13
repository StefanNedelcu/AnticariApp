#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBUserCategoryPreference
{
    public long IdCategoryPreference { get; set; }
    public long IdUser { get; set; }
    public long IdCategory { get; set; }

    public virtual TBCategory Category { get; set; }
    public virtual TBUser User { get; set; }
}
