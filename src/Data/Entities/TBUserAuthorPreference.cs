﻿#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBUserAuthorPreference
{
    public long IdAuthorPreference { get; set; }
    public long IdUser { get; set; }
    public long IdAuthor { get; set; }

    public virtual TBAuthor Author { get; set; }
    public virtual TBUser User { get; set; }
}
