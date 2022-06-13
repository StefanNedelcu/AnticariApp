﻿#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBUserAddress
{
    public long IdUserAddress { get; set; }
    public long IdUser { get; set; }
    public long IdCity { get; set; }
    public string StreetName { get; set; }
    public int? StreetNumber { get; set; }
    public string ZipCode { get; set; }

    public virtual TBCity City { get; set; }
    public virtual TBUser User { get; set; }
}