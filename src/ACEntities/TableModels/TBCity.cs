using System;
using System.Collections.Generic;

#nullable disable

namespace ACEntities.TableModels
{
    public partial class TBCity
    {
        public TBCity()
        {
            TBUserAddresses = new HashSet<TBUserAddress>();
        }

        public long IdCity { get; set; }
        public long IdCountry { get; set; }
        public string CityName { get; set; }

        public virtual TBCountry IdCountryNavigation { get; set; }
        public virtual ICollection<TBUserAddress> TBUserAddresses { get; set; }
    }
}
