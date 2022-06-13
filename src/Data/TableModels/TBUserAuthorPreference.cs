#nullable disable

namespace AnticariApp.Data.TableModels;

public partial class TBUserAuthorPreference
{
    public long IdAuthorPreference { get; set; }
    public long IdUser { get; set; }
    public long IdAuthor { get; set; }

    public virtual TBAuthor IdAuthorNavigation { get; set; }
    public virtual TBUser IdUserNavigation { get; set; }
}
