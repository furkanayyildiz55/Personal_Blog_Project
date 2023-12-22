using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("blog")]
    public class Blog : Base
    {
        [Column("title")]
        public String? Title { get; set; }

        [Column("content")]
        public String? Content { get; set; }
        
        [Column("thumbnail_image")]
        public String? ThumbnailImage { get; set; }
        
        [Column("main_image")]
        public String? MainImage { get; set; }

        [Column("views_count")]
        public String? ViewsCount { get; set; }
        
        [Column("comment_count")]
        public String? CommnetCount { get; set; }

        //Navigation Prorety
        public List<Comment>? Comment { get; set; }
        public List<BlogTag>? BlogTag { get; set; }


        //Navigation Property
        [Column("category_id")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Column("writer_id")]
        public int? WriterId { get; set; }
        public Writer? Writer { get; set; }
    }
}
