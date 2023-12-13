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
        [Column("user_email")]
        public String? UserEmail { get; set; }

        [Column("user_ip")]
        public String? UserIp { get; set; }
    }
}
