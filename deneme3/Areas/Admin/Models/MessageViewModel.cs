using System;

namespace deneme3.Areas.Admin.Models
{
    public class MessageViewModel
    {
        public int id { get; set; }

        public int userid { get; set; }

        public int ReceiverId { get; set; }

        public int SenderId { get; set; }

        public string subject { get; set; }

        public string details { get; set; }

        public DateTime Date { get; set; }

        public bool status { get; set; }

        public bool ReceiverDeleteStatus { get; set; }

        public bool SenderDeleteStatus { get; set; }

    }
}
