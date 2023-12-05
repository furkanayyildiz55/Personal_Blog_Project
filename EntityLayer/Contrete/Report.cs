using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("report")]
    public class Report : Base
    {
        //Navigation Property
        [Column("comment_id")]
        public int CommentId { get; set; }
        public Comment? Comments { get; set; }
    }
}
