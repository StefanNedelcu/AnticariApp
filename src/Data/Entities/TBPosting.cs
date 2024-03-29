﻿#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBPosting
{
    public TBPosting()
    {
        TBExchangeOffers = new HashSet<TBExchangeOffer>();
        TBPostingImages = new HashSet<TBPostingImage>();
    }

    public long IdPosting { get; set; }
    public long IdOwnerUser { get; set; }
    public long IdBook { get; set; }
    public int PostingStatus { get; set; }
    public string PostingDescription { get; set; }
    public decimal? Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual TBBook Book { get; set; }
    public virtual TBUser Owner { get; set; }
    public virtual ICollection<TBExchangeOffer> TBExchangeOffers { get; set; }
    public virtual ICollection<TBPostingImage> TBPostingImages { get; set; }
}
