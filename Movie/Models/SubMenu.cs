namespace Movie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubMenu")]
    public partial class SubMenu
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(70)]
        public string Metatitle { get; set; }

        [StringLength(100)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        public int? MenuID { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }
    }
}
