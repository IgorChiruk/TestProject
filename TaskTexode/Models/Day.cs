using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTexode
{
    class Day
    {
        public Day()
        {
            UserRecords = new List<UserRecord>();
        }
        public int Id { get; set; }

        public ICollection<UserRecord> UserRecords { get; set; }
        
    }
}
