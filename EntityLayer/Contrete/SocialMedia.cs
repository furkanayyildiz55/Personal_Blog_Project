using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("social_media")]
    public class SocialMedia : Base
    {
        [Column("platform_name")]
        public String? PlatformName { get; set; }
        
        [Column("platform_icon")]
        public String? PlatformIcon  { get; set; }

        [Column("url")]
        public String? Url  { get; set; }

        [Column("blog_view")]
        public Boolean BlogView  { get; set; }

        [Column("profile_view")]
        public Boolean ProfileView  { get; set; }

        //Navigation Property
        [Column("writer_id")]
        public int WriterId { get; set; }
        public Writer? Writers { get; set; }

    }
}
