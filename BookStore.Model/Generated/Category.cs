namespace BookStore.Model.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category: EntityBase
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastUpdateTime { get; set; }

        public virtual IList<Book> Books { get; set; }
    }
}
