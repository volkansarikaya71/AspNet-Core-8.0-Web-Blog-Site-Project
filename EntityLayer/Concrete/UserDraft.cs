using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserDraft
    {
        [Key]
        public int DraftId { get; set; }

        public int UserId { get; set; }

        public string DraftSubject { get; set; }

        public string DraftMessageDetails { get; set; }

        public DateTime DraftDate { get; set; }

        public bool DraftStatus { get; set; }
    }
}
