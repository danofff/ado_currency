namespace ado6_3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class curs
    {
        [Key]
        public int curId { get; set; }

        [StringLength(5)]
        public string title { get; set; }

        public DateTime? pubDate { get; set; }

        public double? dDescription { get; set; }
    }
}
