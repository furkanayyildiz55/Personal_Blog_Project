using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("subscribe")]
    public class Subscribe : Base
    {
        [Column("subscribe_email")]
        public String? SubscribeEmail { get; set; }

        [Column("subscribe_guid")]
        public String? SubscribeGuid { get; set; }

        [Column("user_ip")]
        public String? UserIp { get; set; }
    }
}
