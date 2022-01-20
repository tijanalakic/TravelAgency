namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("travel_agency.user")]
    public partial class user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPerson { get; set; }

        [Required]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        public int idRole { get; set; }

        [Required]
        public bool isActive { get; set; }

        public virtual person person { get; set; }

        public virtual role role { get; set; }
    }
}
