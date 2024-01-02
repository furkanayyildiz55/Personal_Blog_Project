using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("blog_tag")]
    public class BlogTag : Base
    {
        //Navigation Property
        [Column("blog_id")]
        public int BlogId { get; set; }
        public Blog? Blogs { get; set; }

        //Navigation Property
        [Column("tag_id")]
        public int TagId { get; set; }
        public Tag? Tags { get; set; }
    }
}
