using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class TransactionDb
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public UserDb User { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
    }
}
