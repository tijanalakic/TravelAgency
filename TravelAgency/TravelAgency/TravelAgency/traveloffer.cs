namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("travel_agency.traveloffer")]
    public partial class traveloffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public traveloffer()
        {
            clients = new HashSet<client>();
        }

        [Key]
        public int idTravelOffer { get; set; }

        [Required]
        [StringLength(45)]
        public string title { get; set; }

        public decimal price { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime departureDate { get; set; }

        public DateTime arrivalDate { get; set; }

        public int maxPassangerNumber { get; set; }

        public int passangerNumber { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public int idTransportationType { get; set; }

        public int idCity { get; set; }

        public virtual city city { get; set; }

        [Required]
        public bool isActive { get; set; }

        public virtual transportationtype transportationtype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> clients { get; set; }
    }
}
