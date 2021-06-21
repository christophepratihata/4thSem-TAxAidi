using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Model
{
    public class TransactionGridList
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ShowName { get; set; }
        public DateTime ShowTime { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}