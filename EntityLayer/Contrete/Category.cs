using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("category")]
    public class Category : Base
    {
        [Column("name")]
        public String Name { get; set; }

        //Navigation Property
        public List<Blog>? Blog{ get; set; }

    }
}
