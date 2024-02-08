using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Contrete
{
    [Table("mail_log")]
    public class MailLog : Base
    {

        [Column("send_status")]
        public Boolean? SendStatus { get; set; }

        [Column("error_cycle")]
        public int? ErrorCycle { get; set; }

        [Column("log_message")]
        public String? LogMessage { get; set; }

        [Column("mail_receiver")]
        public String? MailReceiver { get; set; }

        [Column("mail_subject")]
        public String? MailSubject { get; set; }

        [Column("mail_body")]
        public String? MailBody { get; set; }

        [Column("subscribe_id")]
        public int? SubscribeId { get; set; }

        [Column("blog_id")]
        public int? BlogId { get; set; }


    }
}
