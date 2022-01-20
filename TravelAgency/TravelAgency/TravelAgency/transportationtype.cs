namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("travel_agency.transportationtype")]
    public partial class transportationtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public transportationtype()
        {
            traveloffers = new HashSet<traveloffer>();
        }

        [Key]
        public int idTransportationType { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<traveloffer> traveloffers { get; set; }
    }
}
