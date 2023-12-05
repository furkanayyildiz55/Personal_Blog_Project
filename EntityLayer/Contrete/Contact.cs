using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("contact_user")]
    public class ContactUser : Base
    {
        [Column("user_name")]
        public String? UserName { get; set; } 
        
        [Column("user_email")]
        public String? UserEmail { get; set; }

        [Column("user_ip")]
        public String? UserIp { get; set; }

        [Column("message")]
        public String? Message { get; set; }
    }
}
