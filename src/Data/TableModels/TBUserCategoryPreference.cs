#nullable disable

namespace AnticariApp.Data.TableModels;

public partial class TBUserCategoryPreference
{
    public long IdCategoryPreference { get; set; }
    public long IdUser { get; set; }
    public long IdCategory { get; set; }

    public virtual TBCategory IdCategoryNavigation { get; set; }
    public virtual TBUser IdUserNavigation { get; set; }
}
