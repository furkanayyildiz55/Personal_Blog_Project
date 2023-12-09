using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("writer")]
    public class Writer : Base
    {
        [Column("name")]
        public String? Name { get; set; }

        [Column("surname")]
        public String? Surname { get; set; }

        [Column("email")]
        public String? Email { get; set; }

        [Column("password")]
        public String? Password { get; set; }

        [Column("about")]
        public String? About { get; set; }

        [Column("profile_image")]
        public String? ProfileImage { get; set; }

        //Navigation Prorety
        public List<Blog>? Blog { get; set; }
        public List<SocialMedia>? SocialMedia { get; set; }
    }
}
