using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.Domain.Model
{
    public class Item : AggregateRoot
    {
        public int ID { get; set; }

        public string ItemName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ItemNo { get; set; }

        public int ItemMode { get; set; }

        public string File1 { get; set; }

        public string File2 { get; set; }

        public int InputPerson { get; set; }

        public DateTime InputTime { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
