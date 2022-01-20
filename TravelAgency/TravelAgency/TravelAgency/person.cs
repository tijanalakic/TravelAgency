namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("travel_agency.person")]
    public partial class person
    {
        [Key]
        public int idPerson { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(13)]
        public string pid { get; set; }

        [Required]
        [StringLength(45)]
        public string firstName { get; set; }

        [Required]
        [StringLength(45)]
        public string lastName { get; set; }

        [Required]
        [StringLength(45)]
        public string address { get; set; }

        [Required]
        [StringLength(45)]
        public string phone { get; set; }

        [Required]
        [StringLength(45)]
        public string email { get; set; }

        public int idCity { get; set; }

        public virtual city city { get; set; }

        public virtual client client { get; set; }

        public virtual user user { get; set; }
    }
}
