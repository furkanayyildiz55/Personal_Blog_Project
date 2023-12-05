using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("tag")]
    public class Tag : Base
    {
        [Column("name")]
        public String? Name { get; set; }

        [Column("description")]
        public String? Description { get; set; }

        //Navigation Property
        public List<BlogTag>? BlogTag { get; set; }

    }
}
