using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("comment")]
    public class Comment : Base
    {
        [Column("user_name")]
        public String? UserName { get; set; }
        
        [Column("user_email")]
        public String? Useremail { get; set; }
        
        [Column("user_ip")]
        public String? UserIp { get; set; }

        [Column("content")]
        public String? Content { get; set; }

        [Column("reply_id")]
        public int? ReplyId { get; set; }

        //Navigation Property
        [Column("blog_id")]
        public int BlogId { get; set; }
        public Blog? Blogs { get; set; }

        //Navigation Property
        public List<Report>? Report { get; set; }


    }
}
