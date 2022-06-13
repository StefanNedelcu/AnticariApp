﻿#nullable disable

namespace AnticariApp.Data.TableModels;

public partial class TBCountry
{
    public TBCountry()
    {
        TBCities = new HashSet<TBCity>();
    }

    public long IdCountry { get; set; }
    public string CountryName { get; set; }

    public virtual ICollection<TBCity> TBCities { get; set; }
}