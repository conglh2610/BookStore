namespace BookStore.Model.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book : EntityBase
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int? AuthorId { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(250)]
        public string Cover { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }

        public int Year { get; set; }

        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdateTime { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
