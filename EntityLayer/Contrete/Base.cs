using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Base
    {
        [Key]
        [Column("objectid")]
        public Int32 ObjectId { get; set; }

        [Column("object_status")]
        public Int32 ObjectStatus { get; set; }

        [Column("object_idate")]
        public DateTime? ObjectIDate { get; set; }

        [Column("object_udate")]
        public DateTime? ObjectUDate { get; set; }
    }
}
