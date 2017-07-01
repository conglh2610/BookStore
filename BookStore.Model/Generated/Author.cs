namespace BookStore.Model.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author : EntityBase
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Cover { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdateTime { get; set; }
    }
}
