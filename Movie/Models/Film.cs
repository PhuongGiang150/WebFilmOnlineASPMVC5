namespace Movie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }
        [StringLength(70)]
        public string Metatile { get; set; }

        [StringLength(250)]
        public string Avartar { get; set; }
        [StringLength(250)]
        public string Background { get; set; }

        public int? Year { get; set; }

        [StringLength(10)]
        public string Quality { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(250)]
        public string Genre { get; set; }

        [Column(TypeName = "ntext")]
        public string Rateting { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(250)]
        public string Trailler { get; set; }

        [StringLength(250)]
        public string Video { get; set; }
        public int? UpSlice { get; set; }
        public int? UpHome { get; set; }
        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }
    
    }
}
